using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.Core.Domain;

namespace TARpe22ShopLemming.Data
{
    public class TARpe22ShopLemmingContext :DbContext
    {
        public TARpe22ShopLemmingContext(DbContextOptions<TARpe22ShopLemmingContext> options) : base(options) { }
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<CarFileToApi> CarFileToApis { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
