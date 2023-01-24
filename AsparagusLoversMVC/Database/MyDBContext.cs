using AsparagusLoversMVC.Database.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AsparagusLoversMVC.Database
{
	public class MyDBContext : DbContext
	{
		public MyDBContext(DbContextOptions opts) : base(opts)
		{
		//	Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source= DESKTOP-522TD1V\\TEW_SQLEXPRESS; Initial Catalog=Asparagus;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true");
		}
		public DbSet<Asparagus> Asparaguss { get; set;}
	}
}
