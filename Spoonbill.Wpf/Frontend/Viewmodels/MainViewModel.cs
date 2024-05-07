using Spoonbill.Wpf.Frontend.Builders;
using Spoonbill.Wpf.Frontend.ViewModels.PageTree;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class MainViewModel : ViewModel
{
    public MainViewModel(IBuilder<PageTreeHostViewModel> pageTreeHostBuilder)
    {
        PageTreeHost = pageTreeHostBuilder.Build();
    }

    public PageTreeHostViewModel PageTreeHost { get; }
}