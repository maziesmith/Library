using Library.Infrastructure;
using Library.Infrastructure.Validations;
using Library.Models;
using Services.LibraryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class PublisherController : Controller
    {
     //   private ILibraryService _libraryService;
        private IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        // GET: Publisher
        public ActionResult Index() => View();

        public JsonResult GetPublishers()
        {
            try
            {
                var pubs = _publisherService.GetAllPublishers().Select(x => x.ToModel()).ToList();
                return Json(pubs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(PublisherViewModel model)
        {
            try
            {
                var validator = new PublisherCreateValidations();
                var result = validator.Validate(model);
                if(result.IsValid)
                {
                    if(model.Id == 0)
                    {
                        var Publisher = model.ToEntity();
                        _publisherService.InsertPublisher(Publisher);
                    }
                    else
                    {
                        var publish = _publisherService.GetAllPublishers().SingleOrDefault(x => x.PublisherID == model.Id);
                        publish = model.Edit(publish);
                        _publisherService.UpdatePublisher(publish);
                    }
                    return Json(new { success = true });
                }
                return Json(new { keys = ModelState.Keys.ToList(), values = ModelState.Values.ToList() });
            }
            catch (Exception exc)
            {
                return Json(new { success = false });
                throw;
            }
        }
        public ActionResult Details(int id)
        {
            var publisher = _publisherService.GetAllPublishers().SingleOrDefault(x => x.PublisherID == id).ToModel();
            return Json(publisher, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            var publisher = _publisherService.GetAllPublishers().SingleOrDefault(x => x.PublisherID == id).ToModel();
            return Json(publisher, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var pub = _publisherService.GetPublisher(id);
            _publisherService.DeletePublisher(pub);
            return Json(pub, JsonRequestBehavior.AllowGet);
        }
    }
}