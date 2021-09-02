using Microsoft.Extensions.DependencyInjection;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure;
using smsc.SenderAPI.Infrastructure.Repositories;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using smsc.SenderAPI.Infrastructure.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMessagePartRepository, MessagePartRepository>();
            services.AddTransient<IAlphanumericRepository, AlphanumericRepository>();
            services.AddTransient<IAlphanumericAccessRepository, AlphanumericAccessRepository>();
            services.AddTransient<IQueueRepository, QueueRepository>();
            services.AddTransient<IContext, Context>();
        }
    }
}
