using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseGroup>().HasKey(sc => new { sc.CourseId, sc.GroupId });

            modelBuilder.Entity<CourseGroup>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.Groups)
                .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<CourseGroup>()
                .HasOne<Group>(sc => sc.Group)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.GroupId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseGroup> CourseGroups { get; set; }




    }
}
