using System.Net.Mail;
using System.Net;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using porTIEVserver.Application.Behaviors;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace porTIEVserver.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentEmail("info@portiev.com.tr").AddSmtpSender("localhost", 2525);

            // this IServiceCollection services, INotificationSmtpOptions options = null
            //if (options is null)
            //{
            //    throw new ArgumentNullException(nameof(options));
            //}
            //else if (string.IsNullOrWhiteSpace(options?.SenderAddress))
            //{
            //    throw new ArgumentException($"Option 'SenderAddress' must not null or empty");
            //}
            //else if (string.IsNullOrWhiteSpace(options?.Host))
            //{
            //    throw new ArgumentException($"Option 'Host' must not null or empty");
            //}

            //services
            //    .AddFluentEmail(options.SenderAddress, options.SenderName)
            //    .AddSmtpSender(() => new SmtpClient(options.Host, options.Port)
            //    {
            //        EnableSsl = options.SSL,
            //        Credentials = new NetworkCredential(options.Username, options.Password)
            //    });

            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(
                    typeof(DependencyInjection).Assembly,
                    typeof(AppUser).Assembly
                    );
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }

    //public static IServiceCollection AddTeamCloudNotificationSmtpSender(this IServiceCollection services, INotificationSmtpOptions options = null)

    }
