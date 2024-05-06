using Spoonbill.Wpf.Frontend.Viewmodels.PageTree;

namespace Spoonbill.Wpf.Frontend.Viewmodels;

public class MainViewModel : ViewModel
{
    public MainViewModel()
    {
        PageTreeHost = new PageTreeHostViewModel()
        {
            Items =
            {
                new PageTreeItemViewModel("People")
                {
                    Children =
                    {
                        new PageTreeItemViewModel("Passengers"),
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

    public PageTreeHostViewModel PageTreeHost { get; private set; }
}