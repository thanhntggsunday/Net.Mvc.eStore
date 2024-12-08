using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Model.Entities;
using NetMvc.Cms.Portal.Areas.Admin.Models;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class FunctionController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private IBaseService _baseService;
        private IFunctionService<FunctionDto> _functionService;

        public FunctionController(IBaseService baseService, IFunctionService<FunctionDto> functionService)
        {
            _baseService = baseService;
            _functionService = functionService;
        }

        //
        // GET: /Admin/Function/
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View(GetFunctionViewModel());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            PopulateParentIDDropDownList();
            var viewModel = new ApiResult<FunctionDto>(new FunctionDto());

            return View(viewModel);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApiResult<FunctionDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    
                    _functionService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                 
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }
           

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            FunctionDto dto = new FunctionDto();
            var viewModel = new ApiResult<FunctionDto>();

            try
            {
                dto = _functionService.GetItemByID(id, out TransactionalInformation transaction);
                viewModel.ResultObj = dto;
                PopulateParentIDDropDownList(dto.ParentID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApiResult<FunctionDto> viewModel)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    _functionService.Update(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }
            
            return View(viewModel);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            try
            {
                var dto = new FunctionDto();
                dto.ID = id;

                if (ModelState.IsValid)
                {
                    _functionService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
            }
            return RedirectToAction("Index");
        }

        #region Private Method
        private void PopulateParentIDDropDownList(object selectedParent = null)
        {
            var items = GetFunctionViewModel();
            ViewBag.Parents = new SelectList(items, "ID", "Text", selectedParent);
        }

        private List<FunctionViewModel> GetFunctionViewModel()
        {
            
            List<FunctionViewModel> items = new List<FunctionViewModel>();

            //get all of them from DB
            IEnumerable<Function> allFunctions = _baseService.GetContext().Functions.OrderBy(x => x.Order).ToList();
            //get parent categories
            IEnumerable<Function> parentFunctions = allFunctions.Where(c => c.ParentID == null).OrderBy(c => c.Order);

            foreach (var cat in parentFunctions)
            {
                //add the parent category to the item list
                items.Add(new FunctionViewModel
                {
                    ID = cat.ID,
                    Text = cat.Text,
                    Order = cat.Order,
                    IsLocked = cat.IsLocked,
                    CreatedDate = cat.CreatedDate
                });
                //now get all its children (separate function in case you need recursion)
                GetSubTree(allFunctions.ToList(), cat, items);
            }
            return items;
        }
        private void GetSubTree(IList<Function> allCats, Function parent, IList<FunctionViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.ID);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new FunctionViewModel
                {
                    ID = cat.ID,
                    Text = parent.Text + " >> " + cat.Text,
                    Order = cat.Order,
                    IsLocked = cat.IsLocked,
                    CreatedDate = cat.CreatedDate
                });
                //recursive call in case your have a hierarchy more than 1 level deep
                GetSubTree(allCats, cat, items);
            }
        }
        #endregion

    }
}