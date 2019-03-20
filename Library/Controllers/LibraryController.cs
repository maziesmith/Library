
using DAL.ContextFolder;
using Domain;
using FluentValidation.Mvc;
using FluentValidation.Results;
using Library.Infrastructure;
using Library.Infrastructure.Validations;
using Library.Models;
using Services.LibraryServices;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;
        private IBookCopiesService _bookCopiesService;
        private IBookService _bookService;

        
        public LibraryController(ILibraryService libraryService,
                                 IBookCopiesService bookCopiesService,
                                 IBookService bookService)
        {
            _libraryService = libraryService;
            _bookCopiesService = bookCopiesService;
            _bookService = bookService;
            
        }

        // GET: Library
        public ActionResult Index()
        {
            
            return View(new LibraryViewModel());
        }
        public JsonResult GetLibraries()
        {
            try
            {
                var libs = _libraryService.GetAllLibraries().Select(x => x.ToModel()).ToList();
                return Json(libs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
               
            }
        }
        
        
        [HttpPost]
        public ActionResult Create(LibraryViewModel model)
        {

            try
            {
                var validator = new LibraryCreateVAlidations();
                var result = validator.Validate(model);
                if (result.IsValid)
                {
                    if (model.Id==0)
                    {
                        var Library = model.ToEntity();
                        _libraryService.InsertLibrary(Library); 
                    }
                    else
                    {
                        var libray = _libraryService.GetAllLibraries().SingleOrDefault(x => x.LibraryID == model.Id);
                        libray = model.Edit(libray);
                        _libraryService.UpdateLibrary(libray);

                    }
                    return Json(new { success = true });
                }
                return Json(new { keys = ModelState.Keys.ToList(),values=ModelState.Values.ToList()});
            }
            catch (Exception exc)
            {
                return Json(new { success = false });
                throw;
            }
        }
        public ActionResult Details(int id)
        {

            var lib = _libraryService.GetLibrary(id).ToModel(_bookCopiesService);
            return Json(lib,JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult Edit(int id)
        {
            
            var library = _libraryService.GetAllLibraries().SingleOrDefault(x => x.LibraryID == id).ToModel();
            return Json(library, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int Id)
        {
            var library = _libraryService.GetLibrary(Id);
            _libraryService.DeleteLibrary(library);
            return Json(library, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddBook(int Id,int LibId)
        {
           
            var bCopy = new BookCopy()
            {
                FK_Book = Id,
                FK_Library = LibId,
                NumberOfCopies = 1
            };
            _bookCopiesService.InsertBookCopy(bCopy);
            return Json(new { success=true}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteBookCopy(int Id)
        {
            var bCpy = _bookCopiesService.GetBookCopy(Id);
            _bookCopiesService.DeleteBookCopy(bCpy);
            return Json(bCpy, JsonRequestBehavior.AllowGet);
        }

    }
} 