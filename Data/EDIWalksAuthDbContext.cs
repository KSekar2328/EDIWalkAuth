using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EDIWalks.Data
{
    public class EDIWalksAuthDbContext : IdentityDbContext
    {
        public EDIWalksAuthDbContext(DbContextOptions<EDIWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "19969aa7-9ba0-4dec-a4e4-94e013deecc6";
            var writerRoldId = "766b5c87-282f-4816-8f4d-db027adb33bb";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoldId,
                    ConcurrencyStamp = writerRoldId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
