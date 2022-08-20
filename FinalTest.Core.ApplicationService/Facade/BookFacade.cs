using AutoMapper;
using FinalTest.Core.Contract.Facade;
using FinalTest.Core.Contract.UnitOfWork;
using FinalTest.Core.Domain.DTOs;
using FinalTest.Core.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.ApplicationService.Facade
{
    public class BookFacade : IBookFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;
        public BookFacade(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(BookDTO entity)
        {
          Book book=mapper.Map<BookDTO,Book>(entity);
            unitofWork.Book.Add(book);
            unitofWork.save();
            return book.BookId;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            IEnumerable<Book> books=unitofWork.Book.GetAll();
            IEnumerable<BookDTO> bookDTOs = mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
            return bookDTOs;
        }

        public BookDTO GetById(int id)
        {
           Book book=unitofWork.Book.GetById(id);
            BookDTO bookDTO=mapper.Map<Book,BookDTO>(book);
            return bookDTO;
        }

        public void Remove(BookDTO entity)
        {
            unitofWork.Book.Remove(unitofWork.Book.GetById(entity.BookId));
            unitofWork.save();
        }
        public void Update(BookDTO entity)
        {
            Book oldbook = unitofWork.Book.GetById(entity.BookId);
            oldbook.Price = entity.Price;   
            oldbook.Category = entity.Category;
            oldbook.BookName = entity.BookName;
            oldbook.BookId = entity.BookId;
            oldbook.WriterId = entity.WriterId; 
            oldbook.writer = unitofWork.Writer.GetById(entity.WriterId);


            unitofWork.Book.Update(oldbook);
            unitofWork.save();
        }
    }
}
