using FutureService.Api.Models;

namespace FutureService.Api.Data
{
    public class FutureServiceDbContext: DbContext
    {
        public FutureServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
