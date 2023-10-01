

using back_end_alpha.Models;
using Microsoft.EntityFrameworkCore;
using Task = back_end_alpha.Models.Task;

namespace back_end_alpha.Data
{
    public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

        public DataContext() : base()
        {

        }
        public DbSet<Client> Clients { get; set;}
		public DbSet<Employee> Employees { get; set;}
		public DbSet<Task> Tasks { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(e => e.NationalIdentity).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(e => e.NationalIdentity).IsUnique();

            modelBuilder.Entity<Task>()
            .HasOne(t => t.Client)
            .WithMany()
            .HasForeignKey(t => t.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(modelBuilder);

        }


    }
}

