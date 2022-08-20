using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int WriterId { get; set; }
        public Writer writer { get; set; }
    }
}
