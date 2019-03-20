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
    public class ClientController : Controller
    {
        //   private ILibraryService _libraryService;
        private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: Publisher
        public ActionResult Index() => View();

        public JsonResult GetClients()
        {
            try
            {
                var cli = _clientService.GetAllClients().Select(x => x.ToModel()).ToList();
                return Json(cli, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(ClientViewModel model)
        {
            try
            {
                var validator = new ClientCreateValidations();
                var result = validator.Validate(model);
                if (result.IsValid)
                {
                    if (model.Id == 0)
                    {
                        var Client = model.ToEntity();
                        _clientService.InsertClient(Client);
                    }
                    else
                    {
                        var client = _clientService.GetAllClients().SingleOrDefault(x => x.ClientID == model.Id);
                        client = model.Edit(client);
                        _clientService.UpdateClient(client);
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
            var client = _clientService.GetAllClients().SingleOrDefault(x => x.ClientID == id).ToModel();
            return Json(client, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            var client = _clientService.GetAllClients().SingleOrDefault(x => x.ClientID == id).ToModel();
            return Json(client, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var cli = _clientService.GetClient(id);
            _clientService.DeleteClient(cli);
            return Json(cli, JsonRequestBehavior.AllowGet);
        }
    }
}