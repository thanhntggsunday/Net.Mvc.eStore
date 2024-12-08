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
    public class ProductController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IProductCategoryService<ProductCategoryDto> _productCategoryService;
        private IProductService<ProductDto> _productService;

        public ProductController(IProductService<ProductDto> productService,
            IProductCategoryService<ProductCategoryDto> productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }


        //public ActionResult Index()
        //{
        //    var viewModel = new ListViewModel<ProductDto>();
        //    TransactionalInformation transactional;

        //    try
        //    {
        //        viewModel.Data = _productService.GetAll(CultureName, out transactional);
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
        // GET: /Admin/Product/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<ProductDto>(new ProductDto());

            try
            {
                BindingProductCateDropDown();
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
        // POST: /Admin/Product/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ApiResult<ProductDto> viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;

                    if (viewModel.ResultObj.StrStatus == "1")
                    {
                        viewModel.ResultObj.Status = true;
                    }
                    else
                    {
                        viewModel.ResultObj.Status = false;
                    }

                    _productService.Create(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    viewModel.ReturnStatus = transaction.ReturnStatus;
                    
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingProductCateDropDown();
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
        // GET: /Admin/Product/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var viewModel = new ApiResult<ProductDto>();

            try
            {
                viewModel.ResultObj = _productService.GetItemByID(id, out TransactionalInformation transaction);
               
                viewModel.ReturnStatus = true;
                BindingProductCateDropDown(viewModel.ResultObj.CategoryID);
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
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ApiResult<ProductDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    viewModel.ResultObj.LanguageCode = CultureName;

                    if (viewModel.ResultObj.StrStatus == "1")
                    {
                        viewModel.ResultObj.Status = true;
                    }
                    else
                    {
                        viewModel.ResultObj.Status = false;
                    }

                    _productService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingProductCateDropDown(viewModel.ResultObj.CategoryID);
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
        // POST: /Admin/Product/Delete/5

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new ProductDto();
            dto.ID = id;
            ApiResult<ProductDto> viewModel = new ApiResult<ProductDto>();
            viewModel.ResultObj = dto;

            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Delete(dto, out TransactionalInformation transaction);
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
        private void BindingProductCateDropDown(long? selectedValue = null)
        {
            var items = GetProductCategoryViewModel();
            ViewBag.Category = new SelectList(items, "ID", "Title", selectedValue);
        }
        private List<ProductCategoryViewModel> GetProductCategoryViewModel()
        {
            
            List<ProductCategoryViewModel> items = new List<ProductCategoryViewModel>();

            //get all of them from DB
            IEnumerable<ProductCategoryDto> allProductCategorys = _productCategoryService.GetAll(CultureName, out TransactionalInformation transaction);
            //get parent categories
            IEnumerable<ProductCategoryDto> parentProductCategorys = allProductCategorys.Where(c => c.ParentID == null).OrderBy(c => c.Order);

            foreach (var cat in parentProductCategorys)
            {
                //add the parent ProductCategory to the item list
                items.Add(new ProductCategoryViewModel
                {
                    ID = cat.ID,
                    Title = cat.Title,
                    Order = cat.Order,
                    Status = cat.Status,
                    CreatedDate = cat.CreatedDate
                });
                //now get all its children (separate ProductCategory in case you need recursion)
                GetSubTree(allProductCategorys.ToList(), cat, items);
            }
            return items;
        }
        private void GetSubTree(IList<ProductCategoryDto> allCats, ProductCategoryDto parent, IList<ProductCategoryViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.ID);
            foreach (var cat in subCats)
            {
                //add this ProductCategory
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
        #endregion



        [Route("GetAllPaging")]
        [HttpGet]
        public ActionResult GetAllPaging()
        {
            var result = new DataTableViewModel<ProductDto>();

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
               
                var items = _productService.GetDataTablePaging(CultureName, skipItemCount, pageSize, out var transaction);

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
