using FutureService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureService.Dal
{
    public class FutureServiceDbContext : DbContext
    {
        public FutureServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
