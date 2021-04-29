using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{    
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb'den geliyormuş gibi 
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            //yeni ürün geldiğinde listeye ekler
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ kullanmasak yazacağımız kod ama linq ile tek satırda yapılabiliyor
            /*Product productToDelete = null;
              foreach (var p in _products)
              {
              if (product.ProductId == p.ProductId)
              {
                    productToDelete = p;
              }
            }*/


            //LINQ - Language Integrated Query
            // => Lambda
            //SingleOfDefault tek bir eleman bulmaya yarar
            //p=> kodu foreach yerine tek tek dolaşmaya yarar (linq)[method]
            //Id bazlı yapılarda SingleOfDefault kullanılabilir
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId ==p.ProductId);

            _products.Remove(productToDelete);


        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == p.CategoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün Idsine sahip olan listedeki ürünü bul demek
            // ardından o ürünü bulup adını günceller
            //imzadaki product UIdan gelen müşterinin yolladığı veridir.Onu dbde güncellemek için öcne dbdeki halini buluruz ardından kullanıcının gönderdiklerini dbdekine eşitleyerek güncelleriz.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == p.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }


    }
}
