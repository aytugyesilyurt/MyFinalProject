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
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c# (ürün kullanıldıktan sonra sistemden silinerek performans artışı sağlar [using tabtab a newlediğimiz nesne])
            // var (belirtilmemiş değişken türü * ne atarsam onu alır variable ) -- addedEntity ( eklenen varlık * değişken )
            // context.Entry(entity) --> dbye git [context aracı ile] verdiğim nesne ile eşlerştir [ yeni ürün ekliyeceğim için Add işleminde eşleştirme olmaz]
            //addedEntity.State ise bu nesneye ne yapılacağını yazarız. = EntityState.Added --> veriyi dbye ekle demek
            //context.SaveChanges --> işlemleri dbye kaydet

            using (NortwindContext context = new NortwindContext())
            {
                var addedEntity = context.Entry(entity);        
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            // null ise ? durumunu -- null değil filtre varsa : olan durumu getir. (binevi select*from products yada select*from products where gibi düşünülebilir)
            using (NortwindContext context = new NortwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
