using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class PhotoController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IPhotoService<PhotoDto> _photoService;
        private IAlbumService<AlbumDto> _albumService;

        public PhotoController(IPhotoService<PhotoDto> photoService, IAlbumService<AlbumDto> albumService)
        {
            _photoService = photoService;
            _albumService = albumService;
        }


        // GET: Admin/MenuType
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<PhotoDto>();
            TransactionalInformation transactional;

            try
            {
                viewModel.Data = _photoService.GetAll(CultureName, out transactional);
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

        //
        // GET: /Admin/Slide/Create

        public ActionResult Create()
        {
            var viewModel = new ApiResult<PhotoDto>(new PhotoDto());

            try
            {
                BindingAlbumDropDown();
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
        // POST: /Admin/Slide/Create

        [HttpPost]
        public ActionResult Create(ApiResult<PhotoDto> viewModel)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                  
                    _photoService.Create(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    viewModel.ReturnStatus = transaction.ReturnStatus;

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingAlbumDropDown();
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
        // GET: /Admin/Slide/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            var viewModel = new ApiResult<PhotoDto>();

            try
            {
                viewModel.ResultObj = _photoService.GetItemByID(id, out TransactionalInformation transaction);
                viewModel.ReturnStatus = true;
                BindingAlbumDropDown(viewModel.ResultObj.AlbumID);
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
        // POST: /Admin/Slide/Edit/5

        [HttpPost]
        public ActionResult Edit(ApiResult<PhotoDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _photoService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;
                   
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingAlbumDropDown(viewModel.ResultObj.AlbumID);
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

        // POST: /Admin/Slide/Delete/5

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string message = string.Empty;
            var dto = new PhotoDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _photoService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
            }

            return RedirectToAction("Index");
        }
    
        private void BindingAlbumDropDown(long? selectedID = null)
        {
            var albums = _albumService.GetAll(CultureName, out TransactionalInformation transaction);

            ViewBag.Albums = new SelectList(albums, "ID", "Title", selectedID);
        }
    }
}
