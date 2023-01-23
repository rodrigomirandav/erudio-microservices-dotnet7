using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context;

public class MySqlContext: DbContext
{
	public MySqlContext(){}

	public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

	public DbSet<Product> Products { get; set;}

	protected override void OnModelCreating(ModelBuilder modelBuilder) { 
		modelBuilder.Entity<Product>().HasData(new Product
		{
			Id = 3,
			Name = "Name",	
			Price = new Decimal(10.25),
			Description	= "Description",
			CategoryName= "T-Shirt",
			ImageURL = "teste"
		});
	}
}
