using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EktacoTestTask.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public decimal? Price { get; set; }
        public decimal? VATPrice { get; set; }
        public decimal? VATRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<Store> Stores { get; set; }
    }
}