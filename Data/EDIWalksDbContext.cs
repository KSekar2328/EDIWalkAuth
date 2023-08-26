using EDIWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EDIWalks.Data
{
    public class EDIWalksDbContext : DbContext
    {
        public EDIWalksDbContext(DbContextOptions<EDIWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public DbSet<Difficulty> Difficulities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed data for Difficulty
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("b00305b1-a91c-4b1a-ae80-da02bab22205"),
                    Name = "Easy",
                    Code = "ESY"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("fe95adbf-afe9-4704-ab14-a8407d70f40a"),
                    Name = "Hard",
                    Code = "HRD"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a40e2a92-05ae-4fc9-8382-883f12a0fe6d"),
                    Name = "Normal",
                    Code = "NRL"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            #endregion

            #region Seed data for Region
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("06dd9b35-5b29-458d-9683-86df17ddfd42"),
                    Name = "Edinburgh",
                    Code = "EDI"
                },
                new Region()
                {
                    Id = Guid.Parse("83841134-708a-430f-b4fa-00c1bd678773"),
                    Name = "Livingston",
                    Code = "LIV"
                 },
                new Region()
                {
                    Id = Guid.Parse("3438ff32-5b2d-4224-a3c0-a86e235bcccc"),
                    Name = "Isle of Key",
                    Code = "IOK"
                },
                new Region()
                {
                    Id = Guid.Parse("ee0100bd-e0e4-4448-82ff-85d3042ef5d6"),
                    Name = "Glasgow",
                    Code = "GLW"
                 }
            };

            modelBuilder.Entity<Region>().HasData(regions);
            #endregion

        }
    }
}
