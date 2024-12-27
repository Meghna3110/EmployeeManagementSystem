using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Default value for RoleName
        //    modelBuilder.Entity<Employee>()
        //        .Property(e => e.RoleName)
        //        .HasDefaultValue("DefaultRole");

        //    /*modelBuilder.Entity<Department>()
        //        .HasOne<Employee>()
        //        .WithMany()
        //        .HasForeignKey(p => p.EmployeeId)
        //        .OnDelete(DeleteBehavior.Cascade);*/

        //    // Payroll-Employee relationship
        //    modelBuilder.Entity<Payroll>()
        //        .HasOne<Employee>()
        //        .WithMany()
        //        .HasForeignKey(p => p.EmployeeId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // Attendance-Employee relationship
        //    modelBuilder.Entity<Attendance>()
        //        .HasOne<Employee>()
        //        .WithMany()
        //        .HasForeignKey(a => a.EmployeeId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // Seed data for Department
        //    //modelBuilder.Entity<Department>().HasData(
        //    //    new Department { Id = 1, Name = "HR" },
        //    //    new Department { Id = 2, Name = "Finance" }
        //    //);

        //    // Add indexes if necessary
        //    //modelBuilder.Entity<Employee>()
        //    //    .HasIndex(e => e.Email)
        //    //    .IsUnique();
        //}

        // DbSets for entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
    }
}
