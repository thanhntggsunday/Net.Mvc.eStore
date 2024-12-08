using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Portal.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NetMvc.Cms.Portal.Controllers
{
    public class AlbumController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IAlbumService<AlbumDto> _albumService;
        private IProductService<ProductDto> _productService;
        private IPhotoService<PhotoDto> _photoService;

        public AlbumController(IAlbumService<AlbumDto> albumService,
            IProductService<ProductDto> productService, 
            IPhotoService<PhotoDto> photoService
            )
        {
            _albumService = albumService;
            _productService = productService;
            _photoService = photoService;
        }

        // GET: Album
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<AlbumDto>();
            TransactionalInformation transactional;
            try
            {
                viewModel.Data = _albumService.GetAll(CultureName, out transactional);
                viewModel.Transactional = transactional;
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
        public ActionResult AlbumPhotoList()
        {
            var viewModel = new ListViewModel<AlbumDto>();
            TransactionalInformation transactional;
            try
            {
                viewModel.Data = _albumService.GetAll(CultureName, out transactional);
                viewModel.Transactional = transactional;

                ViewBag.HotProducts = _productService.GetTopList(CultureName, out transactional);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        public ActionResult AlbumDetail(long id)
        {
            var viewModel = new AlbumViewModel();
            TransactionalInformation transactional;
            try
            {
                var album = _albumService.GetItemByID(id, out transactional);
                List<PhotoDto> photos = _photoService.GetAllPhotosByAlbumID(CultureName, id, out transactional);

                viewModel.Album = album;
                viewModel.PhotoList = photos;
                viewModel.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }
    }
}