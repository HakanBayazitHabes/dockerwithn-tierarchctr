
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ApplyConfigurationsFromAssembly Bulunduğumuz assembliy deki dosyaları alır
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly ( ) );
            //Tek Tek vermek istediğimişz de bu şekilde veirrz
            //modelBuilder.ApplyConfiguration(new ProductConfiguration())


            //Best Practices açısından burası kirleitilmez. Seeds Dosyasına yazılır. Eklenir ise bu şekilde eklenir
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 200,
                ProductId = 2
            });



            base.OnModelCreating(modelBuilder); 
        }
    }
}
