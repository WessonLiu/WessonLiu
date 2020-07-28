using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeXieCheng.API.Database
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //private readonly UIDWorker _worker;

        public DbSet<TouristRoute> TOURISTROUTE { get; set; }

        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        /// <summary>
        /// y用于模型映射
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TouristRoute>();
//                .HasData(new TouristRoute()
//            {
//                id = Guid.NewGuid().ToString(),
//                Title = "ceshisj",
//                Description = "dksjfldksajflkasjkj",
//                OriginalPrice = 0,
//                CreateTime = DateTime.UtcNow
//            });
            //手动映射模型和表之间的关系
            //例如你们数据库是test 但是在模型中不想用这个名字，想换成 test1
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
