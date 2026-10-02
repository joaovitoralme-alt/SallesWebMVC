using Microsoft.EntityFrameworkCore;

public class SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options) : DbContext(options)
{
    public DbSet<SalesWebMvc.Models.Departments> Departments { get; set; } = default!;
}
