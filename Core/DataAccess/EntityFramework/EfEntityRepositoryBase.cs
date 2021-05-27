using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c# (ürün kullanıldıktan sonra sistemden silinerek performans artışı sağlar [using tabtab a newlediğimiz nesne])
            // var (belirtilmemiş değişken türü * ne atarsam onu alır variable ) -- addedEntity ( eklenen varlık * değişken )
            // context.Entry(entity) --> dbye git [context aracı ile] verdiğim nesne ile eşlerştir [ yeni ürün ekliyeceğim için Add işleminde eşleştirme olmaz]
            //addedEntity.State ise bu nesneye ne yapılacağını yazarız. = EntityState.Added --> veriyi dbye ekle demek
            //context.SaveChanges --> işlemleri dbye kaydet
            //using mantığı kullanınca at demek -- dispose

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // öğenin özelliklerini getirmek için kullanılır. Örneğin bankada hesaplarım sekmesi var, oradan bir hesaba tıklayıp özelliklerini getirmek için kullanırız.
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // null ise ? durumunu -- null değil filtre varsa : olan durumu getir. (binevi select*from products yada select*from products where gibi düşünülebilir)
            // filtre null ise hepsini getir ve listele, null değil ise (filtre varsa) filtreye göre getir ve listele.
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
