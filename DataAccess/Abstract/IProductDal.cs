using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Product ile ilgili veritabanında yapılacak işlemleri içeren interface
    //Entitiesdeki productı kullanmak için katmanı referans vermek gerekir.(sağ tuş add to project referance)
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring
