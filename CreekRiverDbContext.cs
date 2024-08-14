using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
                {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}

                });
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
    new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
    new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Camp Andrew", ImageUrl="https://blog-assets.thedyrt.com/uploads/2018/05/picking-a-campsite.jpg"},
    new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Camp Taylor", ImageUrl="https://www.nps.gov/noca/planyourvisit/images/cleancampsite.jpg"},
    new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Camp Derek", ImageUrl="https://www.fs.usda.gov/Internet/FSE_MEDIA/fseprd923724.jpg"},
    new Campsite {Id = 5, CampsiteTypeId = 3, Nickname = "Camp Ross", ImageUrl="https://cdn.vox-cdn.com/thumbor/FMUIaXcnBaKK9YqdP8qtxUog150=/0x0:4741x3161/1200x800/filters:focal(1992x1202:2750x1960)/cdn.vox-cdn.com/uploads/chorus_image/image/59535149/shutterstock_625918454.0.jpg"},
    new Campsite {Id = 6, CampsiteTypeId = 2, Nickname = "Camp Odie", ImageUrl="https://algonquinbeyond.com/wp-content/uploads/2010/01/Farm-Lake-Algonquin-Park-Campsite-3-Interior-2.jpg"}
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
{
    new UserProfile {Id = 1, FirstName = "Ross", LastName = "Morgan", Email="rossm399@aol.com"},

});
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
{
    new Reservation {Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate= new DateTime(2023, 12, 21), CheckoutDate = new DateTime(2024, 01, 03) },

});
    }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

}