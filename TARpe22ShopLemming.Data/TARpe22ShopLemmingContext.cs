using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopLemming.Core.Domain;
using TARpe22ShopLemming.Core.Domain.CarDomain;

namespace TARpe22ShopLemming.Data
{
    public class TARpe22ShopLemmingContext :DbContext
    {
        public TARpe22ShopLemmingContext(DbContextOptions<TARpe22ShopLemmingContext> options) : base(options) { }
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<FileToApi> CarFileToApis { get; set; }
    }
}
