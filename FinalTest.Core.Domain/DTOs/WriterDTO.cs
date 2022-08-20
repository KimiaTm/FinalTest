using FinalTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FinalTest.Core.Domain.DTOs
{
    public class WriterDTO
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterPicture { get; set; }
        public DateTime BirthDayDate { get; set; }
        public List<Book> Book { get; set; }

    }
}
