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
    public class NewsController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private INewsService<NewsDto> _newsService;
        private ICategoryService<CategoryDto> _categoryService;
        private IProductService<ProductDto> _productService;

        public NewsController(INewsService<NewsDto> newsService,
            ICategoryService<CategoryDto> categoryService,
            IProductService<ProductDto> productService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
            _productService = productService;
        }



        //// GET: Admin/News
        //public ActionResult Index()
        //{
        //    var viewModel = new ListViewModel<NewsDto>();
        //    TransactionalInformation transactional;

        //    try
        //    {
        //        viewModel.Data = _newsService.GetAll(CultureName, out transactional);
        //        viewModel.Transactional = transactional;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error(ex.ToString());
        //        viewModel.Transactional.ReturnStatus = false;
        //        viewModel.Transactional.ReturnMessage.Add(ex.Message);
        //    }

        //    return View(viewModel);
        //}

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/News/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<NewsDto>(new NewsDto());

            try
            {
                var items = GetCategoryViewModel();
                PopulateGroupIDDropDownList();
               
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

        //
        // POST: /Admin/News/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ApiResult<NewsDto> viewModel, String tags)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;
                    viewModel.ResultObj.Status = true;

                    _newsService.Create(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    viewModel.ReturnStatus = transaction.ReturnStatus;
                 
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateGroupIDDropDownList();
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

        //
        // GET: /Admin/News/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            
            var viewModel = new ApiResult<NewsDto>();

            try
            {
                viewModel.ResultObj = _newsService.GetItemByID(id, out TransactionalInformation transaction);
                viewModel.ReturnStatus = true;
                PopulateGroupIDDropDownList(viewModel.ResultObj.CategoryID);
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

        //
        // POST: /Admin/News/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ApiResult<NewsDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;
                    viewModel.ResultObj.Status = true;

                    _newsService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                PopulateGroupIDDropDownList(viewModel.ResultObj.CategoryID);
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


        //
        // POST: /Admin/News/Delete/5

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new NewsDto();
            dto.ID = id;

            ApiResult<NewsDto> viewModel = new ApiResult<NewsDto>();
            viewModel.ResultObj = dto;

            try
            {
                if (ModelState.IsValid)
                {
                    _newsService.Delete(dto, out TransactionalInformation transaction);
                }
                else
                {
                    var errors = Utils.GetErrorListFromModelState(ModelState);

                    for (int i = 0; i < errors.Count(); i++)
                    {
                        viewModel.ReturnMessage.Add(errors[i]);
                    }
                }

                viewModel.ReturnStatus = ModelState.IsValid;


                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        #region Private Method
        private void CreateNewsTag(NewsTagDto newsTag)
        {
           // Todo
        }
        private void PopulateGroupIDDropDownList(object selectedParent = null)
        {
            var items = GetCategoryViewModel();
            ViewBag.Categories = new SelectList(items, "ID", "Title", selectedParent);
        }
        private List<CategoryViewModel> GetCategoryViewModel()
        {
           
            List<CategoryViewModel> items = new List<CategoryViewModel>();

            //get all of them from DB
            IEnumerable<CategoryDto> allCategorys = _categoryService.GetAll(CultureName, out TransactionalInformation transaction);
            //get parent categories
            IEnumerable<CategoryDto> parentCategorys = allCategorys.Where(c => c.ParentID == null).OrderBy(c => c.Order);

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
        #endregion

        [Route("GetAllPaging")]
        [HttpGet]
        public ActionResult GetAllPaging()
        {
            var result = new DataTableViewModel<NewsDto>();

            try
            {
                var draw = Request.Params.GetValues("draw").FirstOrDefault();
                var start = Request.Params.GetValues("start").FirstOrDefault();
                var length = Request.Params.GetValues("length").FirstOrDefault();
                var search = Request.Params.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int startIndex = start != null ? Convert.ToInt32(start) : 0;
                int intDraw = draw != null ? Convert.ToInt32(draw) : 0;

                var skipItemCount = startIndex;

                var items = _newsService.GetDataTablePaging(CultureName, skipItemCount, pageSize, out var transaction);

                result.data = items.ToArray();
                result.returnStatus = true;
                result.returnMessage.Add("OK");
                result.recordsTotal = transaction.Pager.TotalRows;
                result.recordsFiltered = transaction.Pager.TotalRows;
                result.draw = intDraw;


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                result.returnStatus = false;
                result.returnMessage.Add(ex.Message);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
