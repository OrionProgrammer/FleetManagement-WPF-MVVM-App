using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FleetManagement.Services;
using FleetManagement.Stores;
using FleetManagement.ViewModels;
using System;

namespace FleetManagement.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient((s) => CreateVehicleListingViewModel(s));
                services.AddSingleton<Func<VehicleListingViewModel>>((s) => () => s.GetRequiredService<VehicleListingViewModel>());
                services.AddSingleton<NavigationService<VehicleListingViewModel>>();

                services.AddTransient<ManageVehicleViewModel>();
                services.AddSingleton<Func<ManageVehicleViewModel>>((s) => () => s.GetRequiredService<ManageVehicleViewModel>());
                services.AddSingleton<NavigationService<ManageVehicleViewModel>>();

                services.AddSingleton<MainViewModel>();
            });

            return hostBuilder;
        }

        private static VehicleListingViewModel CreateVehicleListingViewModel(IServiceProvider services)
        {
            return VehicleListingViewModel.LoadViewModel(
                services.GetRequiredService<VehicleStore>(),
                services.GetRequiredService<NavigationService<ManageVehicleViewModel>>());
        }
    }
}
