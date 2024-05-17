using Autofac;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.View.UserControls.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;
using Spoonbill.Wpf.Frontend.ViewModels.PageTree;

namespace Spoonbill.Wpf.Frontend.Builders.Impl;

public class PageTreeHostViewModelBuilder : IBuilder<PageTreeHostViewModel>
{
    private readonly ILifetimeScope m_scope;

    public PageTreeHostViewModelBuilder(ILifetimeScope scope)
    {
        m_scope = scope;
    }

    public PageTreeHostViewModel Build()
    {
        return new PageTreeHostViewModel()
        {
            Items =
            {
                new PageTreeItemViewModel("People")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Passengers", Resolve<PassengerCrudTemplate>()),
                        new PageTreeItemViewModel("Staff", Resolve<StaffWorkerCrudTemplate>()),
                        new PageTreeItemViewModel("Pilots", Resolve<PilotCrudTemplate>()),
                    },
                },
                new PageTreeItemViewModel("Locations")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Counties", Resolve<CountyCrudTemplate>()),
                        new PageTreeItemViewModel("Cities", Resolve<CityCrudTemplate>()),
                        new PageTreeItemViewModel("Airports", Resolve<AirportCrudTemplate>()),
                    },
                },
                new PageTreeItemViewModel("Flights", Resolve<FlightsCrudTemplate>()),
                new PageTreeItemViewModel("Planes")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Planes", Resolve<PlaneCrudTemplate>()),
                        new PageTreeItemViewModel("Models", Resolve<PlaneModelCrudTemplate>()),
                        new PageTreeItemViewModel("Manufacturers", Resolve<ManufacturerCrudTemplate>()),
                    },
                },
            },
        };
    }

    private Func<CrudHost> Resolve<T>() where T : ICrudTemplate
    {
        return () => new CrudHost(m_scope.Resolve<T>());
    }
}