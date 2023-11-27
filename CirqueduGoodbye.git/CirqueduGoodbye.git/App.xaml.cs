using DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using ApplicationCore.Interfaces;
using ApplicationCore;
using DataAccessLayer;
using Microsoft.Extensions.Hosting;

namespace CirqueduGoodbye.git
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public static IHost? Instance { get; private set; }

        public App()
        {
            Instance = Host.CreateDefaultBuilder().ConfigureServices((httpcontext, services) =>
            {
                services.AddDbContext<CirqueduGoodbyeContext>(option =>
                {
                    option.UseSqlServer("Data Source=localhost;Initial Catalog=CirqueduGoodbye;Integrated Security=True;");
                });
                services.AddSingleton<MainWindow>();
                services.AddTransient<IAnimalService, AnimalService>();
                services.AddTransient<IAnimalRepository, AnimalRepository>();
                services.AddTransient<ICircusService, CircusService>();
                services.AddTransient<ICircusRepository, CircusRepository>();
            }).Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Instance!.StartAsync();   
            var mainWindow = Instance.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Instance!.StopAsync();
            base.OnExit(e);
        }

    }
}
