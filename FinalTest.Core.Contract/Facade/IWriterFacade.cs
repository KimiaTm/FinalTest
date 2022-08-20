using FinalTest.Core.Domain.DTOs;
using System.Collections.Generic;

namespace FinalTest.Core.Contract.Facade
{
    public interface IWriterFacade
    {
        WriterDTO getById(int id);
        IEnumerable<WriterDTO> GetAll();
        void Update(WriterDTO entity);
        void Remove(WriterDTO entity);
        int Add(WriterDTO entity);
    }
}