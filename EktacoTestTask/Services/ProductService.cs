using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EktacoTestTask.Entities;
using EktacoTestTask.Repository;

namespace EktacoTestTask.Services
{
    public class ProductService //: IProductService
    {
        private IRepository<Product> db;

        public ProductService()
        {
            db = new Repository<Product>();
        }
        public Product GetProduct(int id)
        {
            return db.Get(id);
            
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.All();
        }

        public void AddProduct(Product product)
        {

            product.CreatedTime = DateTime.Now;
            CountPrices(product);
            db.Add(product);
        }

        public bool ProductIsValid(Product product)
        {
            if (product == null)
                return false;
            if (product.GroupId == 0)
                return false;
            if (product.Price < 0 || product.VATRate < 0)
                return false;
            if (product.VATRate < 0 || product.VATRate > 100)
                return false;
            return true;
        }

        private void CountPrices(Product product)
        {
            if (product.Price == null && product.VATPrice != null && product.VATRate != null)
            {
                product.Price = product.VATPrice / (1 + product.VATRate / 100);
            }
            else
            if (product.Price != null && product.VATPrice == null && product.VATRate != null)
            {
                product.VATPrice = (1 + product.VATRate / 100) * product.Price;
            }
            else
            if (product.Price != null && product.VATPrice != null && product.VATRate == null)
            {
                product.VATRate = (product.VATPrice - product.Price) * 100 / product.Price;
            }

        }
    }
}