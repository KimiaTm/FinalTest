using FinalTest.Core.Domain.DTOs;
using System.Collections.Generic;

namespace Presentation.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public IEnumerable<BookDTO> Books { get; set; }
        public IEnumerable<WriterDTO> Writers { get; set; }
        public BookDTO Book { get; set; }
        public WriterDTO Writer { get; set; }

    }
}
