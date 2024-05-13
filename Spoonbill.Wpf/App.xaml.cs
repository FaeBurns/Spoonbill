using System.IO;
using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spoonbill.Wpf.Controllers;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.Builders;
using Spoonbill.Wpf.Frontend.Builders.Impl;
using Spoonbill.Wpf.Frontend.Extensions;
using Spoonbill.Wpf.Frontend.ViewModels;
using Spoonbill.Wpf.Frontend.ViewModels.PageTree;

namespace Spoonbill.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
    }

    public static IConfiguration Configuration { get; private set; } = null!;
    public static IContainer Container { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // build appsettings configuration
        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = configBuilder.Build();

        // build dependency injection
        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterSource<AnyConcreteTypeNotAlreadyRegisteredSource>();

        builder.RegisterType<SpoonbillContext>()
            .WithParameter("options", GetDatabaseOptions())
            .InstancePerDependency();

        builder.RegisterType<SpoonbillContainer>().As<ISpoonbillContainer>()
            .InstancePerDependency();

        builder.RegisterType<AirplaneModule>().As<IAirplaneModule>().InstancePerDependency();
        builder.RegisterType<FlightsModule>().As<IFlightsModule>().InstancePerDependency();
        builder.RegisterType<LocationsModule>().As<ILocationsModule>().InstancePerDependency();
        builder.RegisterType<PassengerModule>().As<IPassengerModule>().InstancePerDependency();
        builder.RegisterType<StaffModule>().As<IStaffModule>().InstancePerDependency();

        builder.RegisterType<TabledAirplaneModule>()
            .As<ITabledCrudModule<Plane, string>>()
            .As<ITabledCrudModule<PlaneModel, int>>()
            .As<ITabledCrudModule<Manufacturer, string>>()
            .InstancePerDependency();

        builder.RegisterType<TabledFlightsModule>().As<ITabledCrudModule<Flight, int>>();
        builder.RegisterType<TabledLocationsModule>()
            .As<ITabledCrudModule<City, string>>()
            .As<ITabledCrudModule<County, string>>()
            .As<ITabledCrudModule<Airport, string>>()
            .InstancePerDependency();

        builder.RegisterType<TabledPassengerModule>()
            .As<ITabledCrudModule<Passenger, int>>()
            .InstancePerDependency();

        builder.RegisterType<TabledStaffModule>()
            .As<ITabledCrudModule<StaffWorker, int>>()
            .As<ITabledCrudModule<Pilot, int>>()
            .InstancePerDependency();

        // register viewmodel types
        builder.RegisterType<PageTreeHostViewModelBuilder>().As<IBuilder<PageTreeHostViewModel>>();
        builder.RegisterType<MainWindowViewModel>().SingleInstance();

        // set up viewmodel resolver
        Container = builder.Build();
        DISource.Resolver = (type) => Container.Resolve(type);
    }

    private DbContextOptions<SpoonbillContext> GetDatabaseOptions()
    {
        return new DbContextOptionsBuilder<SpoonbillContext>()
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .Options;
    }
}