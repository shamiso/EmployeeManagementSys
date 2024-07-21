using EmployeeManagementSys.Data.Migrations;
using EmployeeManagementSys.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagementSys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelbuilder.Entity<LApplication>()
                .HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey(f => f.StatusId)
                .OnDelete(DeleteBehavior.Cascade);
            modelbuilder.Entity<LApplication>().ToTable("LApplication");
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Models.Designation> Designations{ get; set; }
        public DbSet<SystemCode> SystemCodes{ get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails{ get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<LeaveType>LeaveTypes { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LApplication> LApplications { get; set; }
    }
}
