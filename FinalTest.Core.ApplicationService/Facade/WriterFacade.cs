using AutoMapper;
using FinalTest.Core.Contract.Facade;
using FinalTest.Core.Contract.UnitOfWork;
using FinalTest.Core.Domain.DTOs;
using FinalTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FinalTest.Core.ApplicationService.Facade
{
   
        public class WriterFacade : IWriterFacade
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IUnitOfWork unitofWork;
            private readonly IMapper mapper;
            public WriterFacade(IUnitOfWork unitofWork, IMapper mapper)
            {
                this.unitofWork = unitofWork;
                this.mapper = mapper;
            }
            public int Add(WriterDTO entity)
            {
                Writer writer = mapper.Map<WriterDTO, Writer>(entity);
                unitofWork.Writer.Add(writer);
                unitofWork.save();
                return writer.WriterId;
            }

            public IEnumerable<WriterDTO> GetAll()
            {
                IEnumerable<Writer> writers = unitofWork.Writer.GetAll();
                IEnumerable<WriterDTO> writerDTOs = mapper.Map<IEnumerable<Writer>, IEnumerable<WriterDTO>>(writers);
                return writerDTOs;
            }

            public WriterDTO getById(int id)
            {
                Writer writer = unitofWork.Writer.GetById(id);
                WriterDTO writerDTO = mapper.Map<Writer, WriterDTO>(writer);
                return writerDTO;
            }

            public void Remove(WriterDTO entity)
            {
            unitofWork.Writer.Remove(unitofWork.Writer.GetById(entity.WriterId));
                unitofWork.save();
            }

            public void Update(WriterDTO entity)
            {
                Writer writer = mapper.Map<WriterDTO, Writer>(entity);
                unitofWork.Writer.Update(writer);
                unitofWork.save();
            }
        }
}
