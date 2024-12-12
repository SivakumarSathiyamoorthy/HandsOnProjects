using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.DBContext
{
    public class MyDBContext : IdentityDbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { StuId = 1, StuName = "Lisa", StuCity = "Liverpool", StuDepID = 1 },
                new Student { StuId = 2, StuName = "Siva", StuCity = "Widnes", StuDepID = 2 },
                new Student { StuId = 3, StuName = "Nagu", StuCity = "Birmingham", StuDepID = 3 }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepId = 1, DepName = "SocialWork" },
                new Department { DepId = 2, DepName = "Information Technology" },
                new Department { DepId = 3, DepName = "Computer Science" }
            );

        }

    }

    //Without Identity implementation

    //public class MyDBContext:DbContext
    //{
    //    public DbSet<Student> students { get; set; }
    //    public DbSet<Department> departments { get; set; }

    //    public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
    //    {

    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Student>().HasData(
    //            new Student {StuId=1, StuName="Lisa",StuCity="Liverpool",StuDepID=1},
    //            new Student { StuId = 2, StuName = "Siva", StuCity = "Widnes", StuDepID = 2 },
    //            new Student { StuId = 3, StuName = "Nagu", StuCity = "Birmingham", StuDepID = 3 }
    //            );

    //        modelBuilder.Entity<Department>().HasData(
    //            new Department { DepId=1,DepName="SocialWork" },
    //            new Department { DepId = 2, DepName = "Information Technology" },
    //            new Department { DepId = 3, DepName = "Computer Science" }
    //        );

    //    }

    //}
}
