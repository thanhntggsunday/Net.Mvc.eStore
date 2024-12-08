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
using NetMvc.Cms.Portal.Areas.Admin.Models;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IMenuService<MenuDto> _menuService;
        private IMenuTypeService<MenuTypeDto> _menuTypeService;

        public MenuController(IMenuService<MenuDto> menuService, IMenuTypeService<MenuTypeDto> menuTypeService)
        {
            _menuService = menuService;
            _menuTypeService = menuTypeService;
        }

        //
        // GET: /Admin/Menu/
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View(GetClientMenuViewModel());
        }
        /// <summary>
        /// Get menu top
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [AllowAnonymous]
        public ViewResult GetMenuTop()
        {
            var viewModel = new ListViewModel<MenuDto>();

            try
            {
                var menus = _menuService.GetTopMenuAll(CultureName, out TransactionalInformation transaction);

                viewModel.Data = menus;
                viewModel.Transactional = transaction;
            }
            catch (Exception ex)
            {
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
                _logger.Error(ex.ToString());
                
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<MenuDto>(new MenuDto());

            try
            {
                var items = GetClientMenuViewModel();
                ViewBag.ParentID = new SelectList(items, "ID", "Text");

                ViewBag.GroupID = new SelectList(_menuTypeService.GetAll(CultureName, out TransactionalInformation transaction), "ID", "Name");

                viewModel = new ApiResult<MenuDto>(new MenuDto());
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex.ToString());
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApiResult<MenuDto> viewModel)
        {
            try
            {
                viewModel.ResultObj.LanguageCode = CultureName;
                viewModel.ResultObj.CreatedDate = DateTime.Now;
                viewModel.ResultObj.CreatedBy = User.Identity.Name;

                if (ModelState.IsValid)
                {
                    _menuService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            PopulateGroupIDDropDownList();
            PopulateParentIDDropDownList();

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            var viewModel = new ApiResult<MenuDto>();

            try
            {
                viewModel.ResultObj = _menuService.GetItemByID(id, out TransactionalInformation transaction);
                var items = GetClientMenuViewModel();
                ViewBag.ParentID = new SelectList(items, "ID", "Text", viewModel.ResultObj.ParentID);
                var menuTypes = _menuTypeService.GetAll(CultureName, out transaction);
                ViewBag.GroupID = new SelectList(menuTypes, "ID", "Name", viewModel.ResultObj.GroupID);

               
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
        public ActionResult Edit(ApiResult<MenuDto> viewModel)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _menuService.Update(viewModel.ResultObj, out  TransactionalInformation transaction);
                    var items = GetClientMenuViewModel();

                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateGroupIDDropDownList(viewModel.ResultObj.GroupID);
                PopulateParentIDDropDownList(viewModel.ResultObj.ParentID);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);

            }
           
            return View(viewModel);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            var dto = new MenuDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _menuService.Delete(dto, out TransactionalInformation transaction);
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
        private void PopulateParentIDDropDownList(object selectedParent = null)
        {
            var items = GetClientMenuViewModel();
            ViewBag.Parents = new SelectList(items, "ID", "Text", selectedParent);
        }
        private void PopulateGroupIDDropDownList(object selectedParent = null)
        {
            var menuTypes = _menuTypeService.GetAll(CultureName, out TransactionalInformation transaction);
            ViewBag.Groups = new SelectList(menuTypes, "ID", "Name", selectedParent);
        }
        private List<ClientMenuViewModel> GetClientMenuViewModel()
        {
          
            List<ClientMenuViewModel> items = new List<ClientMenuViewModel>();

            //get all of them from DB
            IEnumerable<MenuDto> allMenus = _menuService.GetAll(CultureName, out TransactionalInformation transaction);
            //get parent categories
            IEnumerable<MenuDto> parentMenus = allMenus.Where(c => c.ParentID == null).OrderBy(c => c.Order);

            foreach (var cat in parentMenus)
            {
                //add the parent category to the item list
                items.Add(new ClientMenuViewModel
                {
                    ID = cat.ID,
                    Text = cat.Text,
                    Order = cat.Order,
                    IsLocked = cat.IsLocked,
                    CreatedDate = cat.CreatedDate
                });
                //now get all its children (separate Menu in case you need recursion)
                GetSubTree(allMenus.ToList(), cat, items);
            }
            return items;
        }
        private void GetSubTree(IList<MenuDto> allCats, MenuDto parent, IList<ClientMenuViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.ID).OrderBy(x => x.Order);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new ClientMenuViewModel
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
