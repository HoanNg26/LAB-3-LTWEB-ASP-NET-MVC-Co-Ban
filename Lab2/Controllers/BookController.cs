﻿using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Nguyen Dinh Anh - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS The complete manual - Author Name Book");
            books.Add("HTML5 & CSS Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS The complete manual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name Book 3", "/Content/Images/book3cover.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS The complete manual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name Book 3", "/Content/Images/book3cover.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS The complete manual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name Book 3", "/Content/Images/book3cover.jpg"));
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "Id, Title, Author, ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS The complete manual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name Book 3", "/Content/Images/book3cover.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
    }
}