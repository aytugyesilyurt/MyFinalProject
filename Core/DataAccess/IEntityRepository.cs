using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Expressionlu idafede linq ile yapıcağımız sorgularda kategoriye göre getir fiyata göre getir gibi filtreleme kodlarını tekrar tekrar yazmamamız için oluşturulmuş denklem
    //T Get ifadesi ise örneğin hesaplarım listesinden bir hesabı seçip detaylı bilgi görebileceğimiz ekranı sağlar (seçtiğimiz nesne hakkında bilgilerin gelmesi gibi)
    //IEntityRepository kullanan Dal'ların parametresine yanlış bilgi girilmesini önlemek için T ye verilebilecek değerleri sınırlandırmalıyız. Buna generic constraint denir
    //:class demek sadece class atanabilir değil REFERANS TİPLER atanabilir demek.
    //ayrıca kullanmadığımız classlar değilde sacede entities kısmında olan nesneleri atayabilmek için IEntity yazarız(ordaki classları IEntitye atamıştık)
    //IEntity : IEntity olabilir yada IEntity implemente eden bir nesne olabilir.
    //Fakat IEntity gibi soyut nesne olmasını istemiyoruz.Bunun için new() yazarız buda newlenebilen bir nesne olmasını sağlar(Interfaceler newlenemez)
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
