using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Product ile ilgili veritabanında yapılacak işlemleri içeren interface
    //Entitiesdeki productı kullanmak için katmanı referans vermek gerekir.(sağ tuş add to referance)
    public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        // ürünleri kategoriye göre listele
        List<Product> GetAllByCategory(int categoryId);

    }
}
