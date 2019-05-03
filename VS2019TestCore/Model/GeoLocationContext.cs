using Microsoft.EntityFrameworkCore;

namespace VS2019TestCore.Model
{
    public class GeoLocationContext: DbContext
    {
        public GeoLocationContext(DbContextOptions<GeoLocationContext> options)
            : base(options)
        { }

        public DbSet<GeoLocations> GeoLocation { get; set; }
    }
}
