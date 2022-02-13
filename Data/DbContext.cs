#nullable disable
using Microsoft.EntityFrameworkCore;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public DbSet<backend_crud.User> User { get; set; }
}
