using System.Collections.Generic;

namespace EktacoTestTask.Entities
{
    public class Store : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}