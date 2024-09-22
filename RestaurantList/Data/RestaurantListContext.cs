using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using RestaurantList.Models;

namespace RestaurantList.Data
{
    public class RestaurantListContext : DbContext
    {
        public RestaurantListContext(DbContextOptions<RestaurantListContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantDish>()
                .HasKey(rd => new
            {
                rd.RestaurantId,
                rd.DishId,
            });
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(r => r.Restaurant)
                .WithMany(rd => rd.RestaurantDishes)
                .HasForeignKey(r => r.RestaurantId);

            modelBuilder.Entity<RestaurantDish>()
                .HasOne(d => d.Dish)
                .WithMany(rd => rd.RestaurantDishes)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "DiDomenico's Pizzaria",
                    Address = "23rd Cheese St, Guancialle, NY 202428",
                    ImageURL = ""
                });
            modelBuilder.Entity<Dish>()
                .HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Pepperonni Pizza",
                    Price = 10
                },
                new Dish
                {
                    Id = 2,
                    Name = "Margheritta Pizza",
                    Price = 12
                });

            modelBuilder.Entity<RestaurantDish>()
                .HasData(
                new RestaurantDish
                {
                    RestaurantId = 1,
                    DishId = 1,
                },
                new RestaurantDish
                {
                    RestaurantId = 1,
                    DishId = 2,
                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurant> Restaurants { get; set;}
        public DbSet<Dish> Dishes { get; set;}
        public DbSet<RestaurantDish> RestaurantsDishes { get; set;}
    }
}
