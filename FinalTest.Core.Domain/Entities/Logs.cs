using System;

namespace FinalTest.Core.Domain.Entities
{
    public class Logs
    {
        public Logs()
        {
            Id = Guid.NewGuid();
            InsertDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public string Operation { get; set; }
        public string Data { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
