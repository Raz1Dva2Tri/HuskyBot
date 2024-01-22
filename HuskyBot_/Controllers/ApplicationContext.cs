using HuskyBot_.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace HuskyBot_.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<LocationModel> Locations { get; set; } = null!;

        public DbSet<UserModel> Users  { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           /// Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}