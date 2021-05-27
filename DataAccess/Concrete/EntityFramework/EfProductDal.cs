using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet : Farklı insanların payklaştığı kod paylaşma ortamı
    public class EfProductDal : EfEntityRepositoryBase<Product,NortwindContext>,IProductDal
    {
        
    }
}
