using FinalTest.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.Contract.Facade
{
    public interface IBookFacade
    {
        BookDTO GetById(int id);
        IEnumerable<BookDTO> GetAll();
        int Add(BookDTO entity);
        void Remove(BookDTO entity);
        void Update(BookDTO entity);
    }
}