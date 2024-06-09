using HXT.Domain.Departments;
using HXT.Domain.Interfaces;
using HXT.Domain.Salaries;
using HXT.Domain.Users;
using HXT.Infrastructure;
using HXT.Infrastructure.Repositories;
using HXT.RedisCache;
using HXT.Service.Department;
using HXT.Service.User;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace HXT.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies(false);
            }
            );

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISalaryRepository, SalaryRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<DepartmentService>()
                .AddScoped<UserService>();
        }


        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRedisDbProvider>(provider =>
            {
                var redisConnectionString = configuration.GetConnectionString("RedisConnectionString");

                return new RedisDbProvider(redisConnectionString);
            });
            services.AddSingleton<ICacheHandler, RedisCacheHandler>();

            return services;
        }
    }
}
