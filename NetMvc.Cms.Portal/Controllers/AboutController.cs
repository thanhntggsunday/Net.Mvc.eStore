using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using PagedList;

namespace NetMvc.Cms.Portal.Controllers
{
    public class AboutController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IAboutService<AboutDto> _aboutService;
        private IProductService<ProductDto> _productService;

        public AboutController(IAboutService<AboutDto> aboutService, IProductService<ProductDto> productService)
        {
            _aboutService = aboutService;
            _productService = productService;
        }
        //
        // GET: /About/

        public ActionResult Index(int? page)
        {
            //paging
            int pageSize = 2;
            int initPage = 1;
            if (page != null) initPage = page.Value;

            PagedListViewModel<AboutDto> viewModel = new PagedListViewModel<AboutDto>();

            try
            {
                var data = _aboutService.GetDataPaging(CultureName, initPage, pageSize, out var transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = new StaticPagedList<AboutDto>(data, initPage, pageSize, transaction.Pager.TotalRows);
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);

            }

            return View(viewModel);
        }

        //
        // GET: /About/Details/5

        public ActionResult Details(int id)
        {
            var viewModel = new ApiResult<AboutDto>();

            try
            {
                var itemDto = _aboutService.GetItemByID(id, out var transaction);

                viewModel.ResultObj = itemDto;
                viewModel.ReturnStatus = transaction.ReturnStatus;
                viewModel.ReturnMessage.AddRange(transaction.ReturnMessage.ToArray());

            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }
        [ChildActionOnly]
        public ActionResult AboutCates()
        {
            var viewModel = new ListViewModel<AboutDto>();

            try
            {
                TransactionalInformation transaction;

                viewModel.Data = _aboutService.GetAll(CultureName, out  transaction);
                viewModel.Transactional = transaction;

                ViewBag.HotProducts = _productService.GetTopList(CultureName, out  transaction);

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
