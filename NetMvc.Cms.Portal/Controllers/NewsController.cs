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

        // GET: News
        public ActionResult Index(int? page)
        {
            //paging
            int pageSize = 2;
            int initPage = 1;
            if (page != null) initPage = page.Value;

            PagedListViewModel<NewsDto> viewModel = new PagedListViewModel<NewsDto>();

            try
            {
                var data = _newsService.GetDataPaging(CultureName, initPage, pageSize, out var transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<NewsDto>(data, initPage, pageSize, transaction.Pager.TotalRows);

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
        public ActionResult NewsCates()
        {
            var viewModel = new ListViewModel<CategoryDto>();
            TransactionalInformation transaction;

            try
            {
                var cates = _categoryService.GetAll(CultureName, transaction: out transaction);
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

        public ActionResult NewsByCate(long id, int? page)
        {

            //paging
            int pageSize = 2;
            int initPage = 1;
            if (page != null) initPage = page.Value;

            PagedListViewModel<NewsDto> viewModel = new PagedListViewModel<NewsDto>();

            try
            {
                var data = _newsService.GetDataByCategoryIdPaging(CultureName, id, initPage, pageSize, out var transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<NewsDto>(data, initPage, pageSize, transaction.Pager.TotalRows);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);

            }

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            NewsDetailViewModel viewModel = new NewsDetailViewModel();
            TransactionalInformation transactional;

            try
            {
                var newsItem = _newsService.GetItemByID(id, out transactional);
                viewModel.NewsDetail = newsItem;
                viewModel.HotNewses = _newsService.GetTopList(CultureName, out transactional);
                viewModel.RelatedNewses =_newsService.GetRelatedNewses(CultureName, newsItem.CategoryID, out transactional);
            }
            catch (Exception ex)
            {
               _logger.Error(ex.ToString());
            }

            return View(viewModel);
        }
    }
}