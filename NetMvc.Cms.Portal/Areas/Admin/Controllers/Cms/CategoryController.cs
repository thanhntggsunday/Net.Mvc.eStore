using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Portal.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private ICategoryService<CategoryDto> _categoryService;

        public CategoryController(ICategoryService<CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View(GetCategoryViewModel());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var items = GetCategoryViewModel();
            PopulateParentIDDropDownList();

            var viewModel = new ApiResult<CategoryDto>(new CategoryDto());

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApiResult<CategoryDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    if (viewModel.ResultObj.ParentID != null && viewModel.ResultObj.ParentID.Equals(0))
                        viewModel.ResultObj.ParentID = null;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.IsIntroduced = viewModel.ResultObj.IsIntroducedBoolable.Value;

                    _categoryService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }


                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateParentIDDropDownList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var viewModel = new ApiResult<CategoryDto>();

            try
            {
                viewModel.ResultObj = _categoryService.GetItemByID(id, out TransactionalInformation transaction);

                if (viewModel.ResultObj.Status != null)
                {
                    viewModel.ResultObj.StatusBoolable.Value = viewModel.ResultObj.Status.Value;
                }

                if (viewModel.ResultObj.IsIntroduced != null)
                {
                    viewModel.ResultObj.IsIntroducedBoolable.Value = viewModel.ResultObj.IsIntroduced.Value;
                }

                var items = GetCategoryViewModel();
                PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);
                viewModel.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex);
                HandleException(ex);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApiResult<CategoryDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.IsIntroduced = viewModel.ResultObj.IsIntroducedBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;

                    _categoryService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }


                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
            }
            PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);
            return View(viewModel);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new CategoryDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
            }
            return RedirectToAction("Index");
        }

        #region Private Method

        private void PopulateParentIDDropDownList(long? selectedParent = null)
        {
            var items = GetCategoryViewModel(selectedParent);
            ViewBag.Parents = new SelectList(items, "ID", "Title", selectedParent);
        }

        private List<CategoryViewModel> GetCategoryViewModel(long? selectedParent = null)
        {
            List<CategoryViewModel> items = new List<CategoryViewModel>();

            //get all of them from DB
            IEnumerable<CategoryDto> allCategorys = _categoryService.GetAll(CultureName, out TransactionalInformation transaction);

            //get parent categories
            IEnumerable<CategoryDto> parentCategorys = allCategorys.Where(c => c.ParentID == null);

            foreach (var cat in parentCategorys)
            {
                //add the parent category to the item list
                items.Add(new CategoryViewModel
                {
                    ID = cat.ID,
                    Title = cat.Title,
                    Order = cat.Order,
                    Status = cat.Status,
                    CreatedDate = cat.CreatedDate
                });
                //now get all its children (separate Category in case you need recursion)
                GetSubTree(allCategorys.ToList(), cat, items);
            }
            return items;
        }

        private void GetSubTree(IList<CategoryDto> allCats, CategoryDto parent, IList<CategoryViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.ID);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new CategoryViewModel
                {
                    ID = cat.ID,
                    Title = parent.Title + " >> " + cat.Title,
                    Order = cat.Order,
                    Status = cat.Status,
                    CreatedDate = cat.CreatedDate
                });
                //recursive call in case your have a hierarchy more than 1 level deep
                GetSubTree(allCats, cat, items);
            }
        }

        #endregion Private Method
    }
}