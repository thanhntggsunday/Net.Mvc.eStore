using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Portal.Models;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace NetMvc.Cms.Portal.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private ISlideService<SlideDto> _slideService;
        private INewsService<NewsDto> _newsService;
        private IProductCategoryService<ProductCategoryDto> _productCategoryService;
        private IMenuService<MenuDto> _menuService;
        private IFooterService<FooterDto> _footerService;
        private IProductService<ProductDto> _productService;

        public HomeController(ISlideService<SlideDto> slideService,
            INewsService<NewsDto> newsService,
            IProductService<ProductDto> productService,
            IProductCategoryService<ProductCategoryDto> productCategoryService,
            IMenuService<MenuDto> menuService,
            IFooterService<FooterDto> footerService)
        {
            _slideService = slideService;
            _newsService = newsService;
            _productCategoryService = productCategoryService;
            _menuService = menuService;
            _footerService = footerService;
            _productService = productService;
        }

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            TransactionalInformation transaction;

            try
            {
                homeViewModel.SlideDtos = _slideService.GetAll(CultureName, out transaction);
                homeViewModel.TopNewsDtos = _newsService.GetTopList(CultureName, out transaction);
                homeViewModel.TopProductDtos = _productService.GetTopList(CultureName, out transaction);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                homeViewModel.ReturnMessage.Add(ex.Message);
                homeViewModel.ReturnStatus = false;
            }

            return View(homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerViewModel = new FooterViewModel();
            var transaction = new TransactionalInformation();

            try
            {
                footerViewModel.ProductCategoryDtos = _productCategoryService.GetAll(CultureName, out transaction);
                footerViewModel.BottomMenus = _menuService.GetBottomMenuAll(CultureName, out transaction);
                footerViewModel.FooterContentHtml = _footerService.GetDefaultFooter(CultureName, out transaction);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return View(footerViewModel);
        }
    }
}