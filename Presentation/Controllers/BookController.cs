using FinalTest.Core.Contract.Facade;
using FinalTest.Core.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookFacade bookFacade;
        private readonly IWriterFacade writerFacade;

        public BookController(IBookFacade bookFacade, IWriterFacade writerFacade)
        {
            this.bookFacade = bookFacade;
            this.writerFacade = writerFacade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<BookDTO>> model = new ResponseViewModel<IEnumerable<BookDTO>>();
            try
            {
                model.Data = bookFacade.GetAll().ToList();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<BookDTO> model=new ResponseViewModel<BookDTO>();
            try
            {
                model.Data = bookFacade.GetById(id);
            }
            catch (Exception ex)
            {

                model.AddError("کتاب وجود ندارد");
                return NotFound(model);

            }
            return Ok(model);

        }

        [HttpPost]
        [Route("PostBook")]

        public IActionResult PostBook(BookDTO book)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                var writer = writerFacade.getById(book.WriterId);
                if (writer != null)
                {
                    model.Data = bookFacade.Add(book);
                    return Created($"/api/book/{model.Data}", model);
                }
                else
                {
                    model.AddError("Writer ID IS NOT EXIST!");
                }
            }
            catch (Exception ex)
            {
                model.AddError(ex.InnerException.ToString());
                
            }
            return BadRequest(model);
        }
        [HttpPut]
        [Route("Edit/{book}")]
        public IActionResult EditBook(BookDTO book) { 
 
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                var writer = writerFacade.getById(book.WriterId);
                if (writer != null) { 
                    var oldbook = bookFacade.GetById(book.BookId);
                    if (oldbook != null)
                    {
                        bookFacade.Update(book);
                        return Created($"/api/book/{book}", model);
                    }
                    else
                    {
                        model.AddError("Book IS NOT EXIST!");
                    }
                }
                else
                {
                    model.AddError("Writer ID IS NOT EXIST!");
                }
            }
            catch (Exception ex)
            {
                model.AddError(ex.InnerException.ToString());

            }
            return BadRequest(model);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = bookFacade.GetById(id);
            bookFacade.Remove(book);
            return Ok($"/api/book/Delete/{book}");
        }


    }
}
