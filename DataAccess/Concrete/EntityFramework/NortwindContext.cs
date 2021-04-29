using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak için kullanılan nesne
    public class NortwindContext:DbContext
    {
        // önce DbContext inheritance yapılır. Ardından use EntittyFrameworkCore ile ilişki eklenir ve sonra onconfig... yazan eklenir. İçindeki silinerek aşağıdaki yazılır.
        //Server için SQLServerObjectExplorerden serverin adresi sonra databese verilir ve trusted connection true verilir (TrstdCnnct doğrulama sistemi şimdi kullanmıyoruz ama büyük projelerde kullanılır: kullanıcı adı, şifre doğrulaması)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
