using ChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}
