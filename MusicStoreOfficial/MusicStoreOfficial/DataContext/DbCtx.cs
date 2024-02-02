using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace MusicStoreOfficial.DataContext
{
    public class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albuns { get; set; }
    }
}
