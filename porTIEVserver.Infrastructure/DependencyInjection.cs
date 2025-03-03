using System.Reflection;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Infrastructure.Context;
using porTIEVserver.Infrastructure.Options;
using porTIEVserver.Infrastructure.Services;
using Scrutor;

namespace porTIEVserver.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCacheService>();

            services.AddScoped<FirmDbContext>();

            string? cString = configuration.GetConnectionString("AppSqlServer"); //  AppSqlServer
            if (cString is not null)
                cString = cString
                    .Replace("#SrvrName#", Parameters.DbServ)
                    .Replace("#DtbsName#", Parameters.DbName)
                    .Replace("#UserName#", Parameters.DbUser)
                    .Replace("#PassWord#", Parameters.DbPass);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(cString);
            });

            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());
            services.AddScoped<IUnitOfWorkFirm>(srv => srv.GetRequiredService<FirmDbContext>());

            services
                .AddIdentity<AppUser, IdentityRole<Guid>>(cfr =>
                {
                    cfr.Password.RequiredLength = Parameters.RequiredLengthPassword;
                    cfr.Password.RequireNonAlphanumeric = false;
                    cfr.Password.RequireUppercase = false;
                    cfr.Password.RequireLowercase = false;
                    cfr.Password.RequireDigit = false;
                    cfr.SignIn.RequireConfirmedEmail = true;
                    cfr.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Parameters.DefaultLockoutTimeSpan);
                    cfr.Lockout.MaxFailedAccessAttempts = Parameters.MaxFailedAccessAttempts;
                    cfr.Lockout.AllowedForNewUsers = true;
                }
                )
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.ConfigureOptions<JwtTokenOptionsSetup>();
            services.AddAuthentication().AddJwtBearer();
            services.AddAuthorizationBuilder();

            services.Scan(action =>
            {
                action
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });

            return services;
        }
    }
}
