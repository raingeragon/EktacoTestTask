using EktacoTestTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EktacoTestTask.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        bool ProductIsValid(Product product);
    }
}
