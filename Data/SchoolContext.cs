#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        // EF의 DbSet class를 통해 각각의 Entity가 DB Table로 mapping 됨
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        // 본 class(SchoolContext)가 init은 되었지만 사용되어 잠기기 전에 호출되는 Method
        // 나중에 Student entity가 다른 entity에 reference를 가질 때 생길 수 있는 문제를 해결하고자 추가
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Course>().ToTable("Course");
        }
    }
}
