using AutoMapper;
using FinalTest.Core.Domain.DTOs;
using FinalTest.Core.Domain.Entities;

namespace FinalTest.Core.ApplicationService.Config
{
    public class WriterProfile : Profile
    {
        public WriterProfile()
        {
            CreateMap<Writer, WriterDTO>();
            CreateMap<WriterDTO, Writer>();
        }
    }
}
