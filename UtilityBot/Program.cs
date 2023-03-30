using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using System;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Threading;
using System.Threading.Tasks;
using UtilityBot.Controllers;
using UtilityBot.Services;
using UtilityBot.Configuration;

namespace UtilityBot
{
   
        public class Program
        {
       
        public static async Task Main()
            {
                Console.OutputEncoding = Encoding.Unicode;
                var host = new HostBuilder()
                    .ConfigureServices((hostContext, services) =>
                    ConfigureServices(services))
                    .UseConsoleLifetime()
                    .Build();
                Console.WriteLine("Сервис запущен");

                await host.RunAsync();
                Console.WriteLine("Сервис остановлен");
            }
            static void ConfigureServices(IServiceCollection services)
            {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddTransient<DefaultMessageController>();
            services.AddTransient<InlineKeyboardController>();
            services.AddTransient<TextMessageController>();

            services.AddSingleton<ITelegramBotClient>(provider =>
                new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();

        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "",
                BotToken = "5809038993:AAEAqKgnL6kA9uwa8QdPKJ1WgsCcFZpgV70"
            };
        }


    }
        
}