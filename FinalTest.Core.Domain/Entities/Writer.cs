using System;
using System.Collections.Generic;

namespace FinalTest.Core.Domain.Entities
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterPicture { get; set; }
        public DateTime BirthDayDate { get; set; }
        public List<Book> Book { get; set; }
    }
}
