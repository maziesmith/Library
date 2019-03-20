using Domain;
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
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IBookCopiesService _bookCopiesService;
        
        public BookController(IBookService bookService,
                              IBookCopiesService bookCopiesService)
        {
            _bookService = bookService;
            _bookCopiesService = bookCopiesService;
        }
        public ActionResult Index() => View();
        public JsonResult GetBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks().ToList();
                return Json(books, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetBooksForLibrary()
        {
            try
            {
                var books = _bookService.GetAllBooks().ToList();
                return Json(books, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
       
        [HttpPost]
        public ActionResult Create(BookViewModel model)
        {
            try
            {
                var validator = new BookCreateValidations();
                var result = validator.Validate(model);
                if(result.IsValid)
                {
                    if(model.Id == 0)
                    { 
                    var book = model.ToEntity();
                    _bookService.InsertBook(book);
                    }
                    else
                    {
                        var kniga = _bookService.GetBook(model.Id);
                        kniga = model.Edit(kniga);
                        _bookService.UpdateBook(kniga);
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

        public ActionResult Details(int Id)
        {
            var book = _bookService.GetBookWithInclude(Id).ToModel();
            //var book = _bookService.GetAllBooks().SingleOrDefault(x => x.BookID).ToModel();
            return Json(book, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var kniga = _bookService.GetBook(id);
            return Json(kniga, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);
            _bookService.DeleteBook(book);
            return Json(book, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBooksInLibrary(int id)
        {
            try
            {
                var kniga = _bookCopiesService.GetAllBookCopiesWithInclude(x => x.Book)
                                                    .Where(x => x.FK_Library == id).ToList()
                                                    .Select(x => _bookService.GetBook(x.FK_Book))
                                                    .Distinct()
                                                    .ToList();
            
                return Json(kniga, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception exc)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult NewBookViewModel() => PartialView("_NewBookModalPartial",new BookViewModel());

    }
}