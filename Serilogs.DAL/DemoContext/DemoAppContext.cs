using DemoApp.DAL.Entities;

namespace DemoApp.DAL.DemoContext
{
	public class DemoAppContext:DbContext
	{
        public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAB4INS;database=Appdb;integrated security=true;");
		}
	}
}
