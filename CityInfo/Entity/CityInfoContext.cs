using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Entity
{
    // sql baglantıları için   18-06-2019
    // for migration => Microsoft.EntityFrameworkCore.Tools
    //  ekle => Microsoft.EntityFrameworkCore.SqlServer  # sql için 18-06-2019

    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            // ilk kurulumda bu => method ile Create etmiştik database'ii
            // Database.EnsureCreated();

            // yine api isteğiyle Create Edicez
            //migration update işleminde ise
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterest { get; set; }


        #region alternatif 
        // Configuring
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //} 
        #endregion
    }
}
