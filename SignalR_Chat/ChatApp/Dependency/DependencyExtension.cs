using ChatApp.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Dependency
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MsSql"));

            });

          
        }
    }
}
