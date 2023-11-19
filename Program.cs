using Microsoft.EntityFrameworkCore;
using Npgsql;

using var db = new AppDbContext();
var products = db.Products.ToList();

class AppDbContext : DbContext
{
	static AppDbContext()
	{
#pragma warning disable
		NpgsqlConnection.GlobalTypeMapper
			.MapEnum<ProductTrait>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasPostgresEnum<ProductTrait>();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder
			.UseNpgsql(new NpgsqlConnectionStringBuilder
			{
				Host = "localhost",
				Username = "arad",
				Password = "1301381",
				Database = "ef_migrations_test_db",
			}.ToString())
			.LogTo(Console.WriteLine);

	public DbSet<Product> Products => Set<Product>();
}

class Product
{
	public required int Id { get; set; }
	public required List<ProductTrait> Traits { get; set; }
}

enum ProductTrait
{
	Foo,
	Bar,
	Buzz,
}
