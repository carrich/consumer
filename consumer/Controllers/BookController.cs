using consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumer.Controllers
{
    public class BookController : Controller
    {
        BookServiceClient bookClient = new BookServiceClient();
        // GET: Book
      
        public ActionResult Index()
        {
            List<Book> books = bookClient.getAllBooks();
            return View(books);
        }
        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                string createBook = bookClient.AddBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = bookClient.getBook(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                bookClient.UpdateBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = bookClient.getBook(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                // TODO: Add delete logic here
                bookClient.DeleteBook(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
