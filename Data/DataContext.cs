using calculator.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace calculator.Data
{
	public class DataContext : DbContext
	{

		private IConfiguration _configuration;
		public DataContext(IConfiguration configuration) 
		{
			_configuration = configuration;
		}

		public void SetConfig(IConfiguration configuration) 
		{
			this._configuration = configuration;
		}

		public DataContext() { }

		public void Init()
		{
			Console.WriteLine("Migration");
			IMigrator migration = Database.GetService<IMigrator>();
			migration.Migrate();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			string connection = _configuration.GetConnectionString("mssql");
			Console.WriteLine("Connection: " + connection);
			optionsBuilder.UseSqlServer(connection);
			
		}

		public DbSet<City> cities { get; set; }
		public DbSet<Price> prices { get; set; }
	}
}
