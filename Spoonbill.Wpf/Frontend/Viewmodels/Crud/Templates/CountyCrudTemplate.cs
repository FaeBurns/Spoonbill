using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class CountyCrudTemplate : GenericCrudTemplate<County, string>
{
    public CountyCrudTemplate(ITabledCrudModule<County, string> crudModule) : base(crudModule, "County")
    {
    }
    
    public override IIntrospectViewModel CreateItemViewmodel(object model) => new CountyIntrospectViewModel((County)model);
}