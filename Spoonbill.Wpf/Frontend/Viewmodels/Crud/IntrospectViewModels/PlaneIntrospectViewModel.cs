using System.Collections;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class PlaneIntrospectViewModel : IntrospectViewModel<Plane>
{
    private readonly IAirplaneModule m_airplaneModule;
    public string Serial { get; set; }
    public int ModelNumber { get; set; }
    
    public LazyLoadViewModel<IEnumerable<int>> AvailableModels { get; }
    
    public PlaneIntrospectViewModel(IAirplaneModule airplaneModule, Plane model) : base(model)
    {
        m_airplaneModule = airplaneModule;
        Serial = model.Serial;
        ModelNumber = model.Model?.ModelNumber ?? 0;

        AvailableModels = new LazyLoadViewModel<IEnumerable<int>>(() =>
        {
            return airplaneModule.ListModels().Select(m => m.ModelNumber);
        });
    }

    public override IResult Apply()
    {
        if (ModelNumber == 0)
            return new Invalid("Invalid Plane Model selected");

        PlaneModel? targetedModel = m_airplaneModule.GetModel(ModelNumber);
        if (targetedModel == null)
            return new Invalid("Could not find a Plane Model that matched the given model number.");

        Model.Serial = Serial;
        Model.Model = targetedModel;

        return new Ok();
    }
}