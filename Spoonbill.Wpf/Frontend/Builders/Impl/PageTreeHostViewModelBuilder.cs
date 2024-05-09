using Autofac;
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

    private Func<CrudHost> Resolve<T>() where T : ICrudTemplate
    {
        return () => new CrudHost(m_scope.Resolve<T>());
    }
}