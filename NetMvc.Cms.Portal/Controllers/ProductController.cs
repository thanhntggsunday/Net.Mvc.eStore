using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Portal.Models;
using PagedList;

namespace NetMvc.Cms.Portal.Controllers
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

        // GET: Product
        public ActionResult Index(int? page)
        {
            var viewModel = new PagedListViewModel<ProductDto>();
            TransactionalInformation transaction;
            int initPage = 1;
            int pageSize = 12;
            if (page != null) initPage = page.Value;

            try
            {
                var data = _productService.GetDataPaging(CultureName, initPage, pageSize, out transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<ProductDto>(data, initPage, pageSize, transaction.Pager.TotalRows);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        public ActionResult ProductByCate(string metatitle, long id, int? page)
        {
            var viewModel = new PagedListViewModel<ProductDto>();
            TransactionalInformation transaction;
            int initPage = 1;
            int pageSize = 6;
            if (page != null) initPage = page.Value;

            try
            {
                var data = _productService.GetProductByCateIdPaging(CultureName, id, initPage, pageSize, out transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<ProductDto>(data, initPage, pageSize, transaction.Pager.TotalRows);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult ProductCates()
        {
            var viewModel = new ListViewModel<ProductCategoryDto>();
            TransactionalInformation transaction;

            try
            {
                var cates = _productCategoryService.GetAll(CultureName, transaction: out transaction);
                viewModel.Data = cates;

                ViewBag.HotProducts = _productService.GetTopList(CultureName, out transaction);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        public ActionResult Detail(long id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            TransactionalInformation transactional;

            try
            {
                var product = _productService.GetItemByID(id, out transactional);
                viewModel.ProductDetail = product;
                viewModel.NewProducts = _productService.GetTopList(CultureName, out transactional);
                viewModel.RelatedProducts = _productService.GetRelatedProducts(CultureName, product.CategoryID, out transactional);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }

            return View(viewModel);
        }

        public ActionResult Search(string keyWords, int? page)
        {
            var viewModel = new PagedListViewModel<ProductDto>();
            TransactionalInformation transaction;
            int initPage = 1;
            int pageSize = 6;
            if (page != null) initPage = page.Value;

            try
            {
                var data = _productService.SearchProducts(CultureName, keyWords, initPage, pageSize, out transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<ProductDto>(data, initPage, pageSize, transaction.Pager.TotalRows);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

    }
}