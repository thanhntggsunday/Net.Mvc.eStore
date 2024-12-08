using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Class;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Portal.Areas.Admin.Models;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IProductCategoryService<ProductCategoryDto> _categoryService;

        public ProductCategoryController(IProductCategoryService<ProductCategoryDto> categoryService)
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
            var viewModel = new ApiResult<ProductCategoryDto>(new ProductCategoryDto());

            try
            {
                var items = GetCategoryViewModel();
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

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApiResult<ProductCategoryDto> viewModel)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;

                    if (viewModel.ResultObj.ParentID != null && viewModel.ResultObj.ParentID.Value.Equals(0))
                        viewModel.ResultObj.ParentID = null;

                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _categoryService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("",errors[i]);
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
            var viewModel = new ApiResult<ProductCategoryDto>();

            try
            {
                viewModel.ResultObj = _categoryService.GetItemByID(id, out TransactionalInformation transaction);

                if (viewModel.ResultObj.Status != null)
                {
                    viewModel.ResultObj.StatusBoolable.Value = viewModel.ResultObj.Status.Value;
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
        public ActionResult Edit(ApiResult<ProductCategoryDto> vm)
        {
            var viewModel = new ApiResult<ProductCategoryDto>();
            viewModel.ResultObj = vm.ResultObj;

            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;

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

                PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);
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

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new ProductCategoryDto();
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

        private List<ProductCategoryViewModel> GetCategoryViewModel(long? selectedParent = null)
        {
            List<ProductCategoryViewModel> items = new List<ProductCategoryViewModel>();

            //get all of them from DB
            IEnumerable<ProductCategoryDto> allCategorys = _categoryService.GetAll(CultureName, out TransactionalInformation transaction);

            //get parent categories
            IEnumerable<ProductCategoryDto> parentCategorys = allCategorys.Where(c => c.ParentID == null);

            foreach (var cat in parentCategorys)
            {
                //add the parent category to the item list
                items.Add(new ProductCategoryViewModel
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

        private void GetSubTree(IList<ProductCategoryDto> allCats, ProductCategoryDto parent, IList<ProductCategoryViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.ID);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new ProductCategoryViewModel
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