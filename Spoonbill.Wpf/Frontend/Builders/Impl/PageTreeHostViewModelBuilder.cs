using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Frontend.View.UserControls.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.PageTree;

namespace Spoonbill.Wpf.Frontend.Builders.Impl;

public class PageTreeHostViewModelBuilder : IBuilder<PageTreeHostViewModel>
{
    private readonly IPassengerModule m_passengerModule;

    public PageTreeHostViewModelBuilder(IPassengerModule passengerModule)
    {
        m_passengerModule = passengerModule;
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
                        new PageTreeItemViewModel("Passengers", () => new CrudHost(),
                        new PageTreeItemViewModel("Staff"),
                        new PageTreeItemViewModel("Pilots"),
                    },
                },
                new PageTreeItemViewModel("Locations")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Counties"),
                        new PageTreeItemViewModel("Cities"),
                        new PageTreeItemViewModel("Airports"),
                    },
                },
                new PageTreeItemViewModel("Flights"),
                new PageTreeItemViewModel("Planes")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Planes"),
                        new PageTreeItemViewModel("Models"),
                        new PageTreeItemViewModel("Manufacturers"),
                    },
                },
            },
        };
    }
}