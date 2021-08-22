using Microsoft.EntityFrameworkCore;

namespace Game.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<GameData> GameData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Title = "Japan",
                    Name = "Japanese"
                },
                new Country
                {
                    Id = 2,
                    Title = "China",
                    Name = "Chinese"
                },
                new Country
                {
                    Id = 3,
                    Title = "Korea",
                    Name = "Korean"
                },
                new Country
                {
                    Id = 4,
                    Title = "Thailand",
                    Name = "Thai"
                }
            );

            builder.Entity<GameData>().HasData(
                new GameData
                {
                    Id = 1,
                    Answer = 1,
                    ImgUrl = "/Images/1_1.jpg"
                },
                new GameData
                {
                    Id = 2,
                    Answer = 1,
                    ImgUrl = "/Images/1_2.jpg"
                },
                new GameData
                {
                    Id = 3,
                    Answer = 1,
                    ImgUrl = "/Images/1_3.jpg"
                },
                new GameData
                {
                    Id = 4,
                    Answer = 2,
                    ImgUrl = "/Images/2_1.jpg"
                },
                new GameData
                {
                    Id = 5,
                    Answer = 2,
                    ImgUrl = "/Images/2_2.jpg"
                },
                new GameData
                {
                    Id = 6,
                    Answer = 2,
                    ImgUrl = "/Images/2_3.jpg"
                },
                new GameData
                {
                    Id = 7,
                    Answer = 3,
                    ImgUrl = "/Images/3_1.jpg"
                },
                new GameData
                {
                    Id = 8,
                    Answer = 3,
                    ImgUrl = "/Images/3_2.jpg"
                },
                new GameData
                {
                    Id = 9,
                    Answer = 3,
                    ImgUrl = "/Images/3_3.jpg"
                },
                new GameData
                {
                    Id = 10,
                    Answer = 4,
                    ImgUrl = "/Images/4_1.jpg"
                },
                new GameData
                {
                    Id = 11,
                    Answer = 4,
                    ImgUrl = "/Images/4_2.jpg"
                },
                new GameData
                {
                    Id = 12,
                    Answer = 4,
                    ImgUrl = "/Images/4_3.jpg"
                },
                new GameData
                {
                    Id = 13,
                    Answer = 4,
                    ImgUrl = "/Images/4_4.jpg"
                }
            );

        }
    }
}
