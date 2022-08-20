using FinalTest.Core.Contract.Facade;
using FinalTest.Core.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBookFacade bookFacade;
        private readonly IWriterFacade writerFacade;
        public AdminController(IBookFacade bookFacade, IWriterFacade writerFacade)
        {
            this.bookFacade = bookFacade;
            this.writerFacade = writerFacade;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<BookDTO> Books = bookFacade.GetAll();
            IEnumerable<WriterDTO> writers = writerFacade.GetAll();
            AdminViewModel model = new AdminViewModel()
            {
                Books = Books,
                Writers = writers,
            };
            return Ok();
        }

        [HttpPost]
        public IActionResult AddBook(BookDTO model)
        {
            if (model.BookName != null)
            {
                BookDTO book = new BookDTO
                {
                    BookId = model.BookId,
                    BookName = model.BookName,
                    Price = model.Price,
                    Category = model.Category,
                    WriterId = model.WriterId,
                };
                bookFacade.Add(book);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddWriter(WriterDTO model)
        {
            if (model.WriterName != null)
            {
                WriterDTO writer = new WriterDTO
                {
                    WriterId = model.WriterId,
                    WriterName = model.WriterName,
                    WriterPicture = model.WriterPicture,
                    BirthDayDate = model.BirthDayDate,
                };
                writerFacade.Add(writer);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BooksInfo()
        {
            IEnumerable<BookDTO> booksDTO = bookFacade.GetAll().ToList();
            AdminViewModel books = new AdminViewModel()
            {
                Books = booksDTO,
            };
            return Ok(books);
        }
        public IActionResult WritersInfo()
        {
            IEnumerable<WriterDTO> writersDTO = writerFacade.GetAll().ToList();
            AdminViewModel writers = new AdminViewModel()
            {
                Writers = writersDTO,
            };
            return Ok(writers);
        }
        [HttpGet]
        [Route("EditBook/{id}")]
        public IActionResult EditBook(int id)
        {
            BookDTO book = bookFacade.GetById(id);
            AdminViewModel model = new AdminViewModel()
            {
                Book = book,
            };
            return Ok(model);
        }
        [HttpPut]
        [Route("Edit/{book}")]
        public IActionResult EditBook(BookDTO books)
        {
            bookFacade.Update(books);
            return RedirectToAction("index");
        }
         [HttpGet]
        [HttpGet]
        [Route("EditWriter/{id}")]
        public IActionResult EditWriter(int id)
        {
            WriterDTO writer = writerFacade.getById(id);
            AdminViewModel model = new AdminViewModel()
            {
                Writer = writer,
            };
            return Ok(model);
        }
        [HttpPut]
        [Route("Edit/{writer}")]
        public IActionResult EditWriter(WriterDTO writer)
        {
            writerFacade.Update(writer);
            return RedirectToAction("index");
        }
        [HttpDelete]
        [Route("Delete/{book}")]
        public IActionResult DeleteBook(BookDTO book)
        {
            bookFacade.Remove(book);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        [Route("Delete/{writer}")]
        public IActionResult DeleteWriter(WriterDTO writer)
        {
            writerFacade.Remove(writer);
            return RedirectToAction("Index");
        }

    }
}

