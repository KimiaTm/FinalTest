using System.Text;

namespace FinalTest.Core.Domain.DTOs
{
    public class BookDTO
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int WriterId { get; set; }
        
    }
}
