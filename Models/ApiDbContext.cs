using Microsoft.EntityFrameworkCore;

namespace web_api_hello;

public class ApiDbContext : DbContext
{


	public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
	{

	}


	public DbSet<Place>? Places { get; set; }

}