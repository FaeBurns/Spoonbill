using System.IO;
using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spoonbill.Wpf.Controllers;
using Spoonbill.Wpf.Controllers.Interfaces;
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
            .InstancePerLifetimeScope();

        builder.RegisterType<SpoonbillContainer>().As<ISpoonbillContainer>()
            .InstancePerLifetimeScope();

        builder.RegisterType<AirplaneModule>().As<IAirplaneModule>();
        builder.RegisterType<FlightsModule>().As<IFlightsModule>();
        builder.RegisterType<LocationsModule>().As<ILocationsModule>();
        builder.RegisterType<PassengerModule>().As<IPassengerModule>();
        builder.RegisterType<StaffModule>().As<IStaffModule>();
        
        // register viewmodel types
        builder.RegisterType<PageTreeHostViewModelBuilder>().As<IBuilder<PageTreeHostViewModel>>();

        // set up viewmodel resolver
        Container = builder.Build();
        DISource.Resolver = (type) => Container.Resolve(type);

        Container.Resolve<IPassengerModule>().CreatePassenger(new Passenger()
        {
            Name = "Johnny",
            Surname = "Test",
            Address = "3",
            PhoneNumber = "42069"
        });
    }

    private DbContextOptions<SpoonbillContext> GetDatabaseOptions()
    {
        return new DbContextOptionsBuilder<SpoonbillContext>()
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            .Options;
    }
}