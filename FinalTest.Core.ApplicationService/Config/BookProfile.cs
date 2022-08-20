using AutoMapper;
using FinalTest.Core.Domain.DTOs;
using FinalTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.ApplicationService.Config
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
