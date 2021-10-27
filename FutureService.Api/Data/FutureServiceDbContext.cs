using Microsoft.EntityFrameworkCore;

namespace FutureService.Api.Data
{
    public class FutureServiceDbContext: DbContext
    {
        public FutureServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
