namespace HSBlacklist.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlEntity : DbContext
    {
        public SqlEntity()
            : base("name=SqlEntityConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employees1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee1>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee1>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Employee1>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee1>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee1>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
