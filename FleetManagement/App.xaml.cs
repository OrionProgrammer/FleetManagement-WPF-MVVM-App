using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FleetManagement.DbContexts;
using FleetManagement.Exceptions;
using FleetManagement.HostBuilders;
using FleetManagement.Models;
using FleetManagement.Services;
using FleetManagement.Services.VehicleConflictValidators;
using FleetManagement.Services.VehicleCreators;
using FleetManagement.Services.VehicleProviders;
using FleetManagement.Stores;
using FleetManagement.ViewModels;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FleetManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
                {
                    bool isEndToEndTest = Environment.GetCommandLineArgs().Any(a => a == "E2E");

                    string connectionString = hostContext.Configuration.GetConnectionString("Default");
                    services.AddSingleton<IFleetManagementDbContextFactory>(new FleetManagementDbContextFactory(connectionString));

                    services.AddSingleton<IVehicleProvider, DatabaseVehicleProvider>();
                    services.AddSingleton<IVehicleCreator, DatabaseVehicleCreator>();
                    services.AddSingleton<IVehicleConflictValidator, DatabaseVehicleConflictValidator>();

                    services.AddTransient<VehicleModelManage>();
                    services.AddTransient<VehicleModel>();

                    services.AddSingleton<VehicleStore>();
                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            NavigationService<VehicleListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<VehicleListingViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
