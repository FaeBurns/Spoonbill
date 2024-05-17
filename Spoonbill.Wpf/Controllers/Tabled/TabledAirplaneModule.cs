using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public class TabledAirplaneModule : ITabledCrudModule<Plane, string>, ITabledCrudModule<PlaneModel, int>, ITabledCrudModule<Manufacturer, string>
{
    private readonly IAirplaneModule m_airplaneModule;

    public TabledAirplaneModule(IAirplaneModule airplaneModule)
    {
        m_airplaneModule = airplaneModule;
    }

    IResult ITabledCrudModule<Plane, string>.Create(Plane model)
    {
        return m_airplaneModule.CreatePlane(model);
    }

    IResult ITabledCrudModule<Manufacturer, string>.Create(Manufacturer model)
    {
        return m_airplaneModule.CreateManufacturer(model);
    }

    Manufacturer? ITabledCrudModule<Manufacturer, string>.Read(string key)
    {
        return m_airplaneModule.GetManufacturer(key);
    }

    IResult ITabledCrudModule<Manufacturer, string>.Update(Manufacturer model)
    {
        return m_airplaneModule.UpdateManufacturer(model);
    }

    IResult ITabledCrudModule<Manufacturer, string>.Destroy(Manufacturer model)
    {
        return m_airplaneModule.DeleteManufacturer(model);
    }

    ICollection<Manufacturer> ITabledCrudModule<Manufacturer, string>.List()
    {
        return m_airplaneModule.ListManufacturers();
    }

    Plane? ITabledCrudModule<Plane, string>.Read(string key)
    {
        return m_airplaneModule.GetPlane(key);
    }

    IResult ITabledCrudModule<Plane, string>.Update(Plane model)
    {
        return m_airplaneModule.UpdatePlane(model);
    }

    IResult ITabledCrudModule<Plane, string>.Destroy(Plane model)
    {
        return m_airplaneModule.DeletePlane(model);
    }

    IResult ITabledCrudModule<PlaneModel, int>.Create(PlaneModel model)
    {
        return m_airplaneModule.CreateModel(model);
    }

    PlaneModel? ITabledCrudModule<PlaneModel, int>.Read(int key)
    {
        return m_airplaneModule.GetModel(key);
    }

    IResult ITabledCrudModule<PlaneModel, int>.Update(PlaneModel model)
    {
        return m_airplaneModule.UpdateModel(model);
    }

    IResult ITabledCrudModule<PlaneModel, int>.Destroy(PlaneModel model)
    {
        return m_airplaneModule.DeleteModel(model);
    }

    ICollection<PlaneModel> ITabledCrudModule<PlaneModel, int>.List()
    {
        return m_airplaneModule.ListModels();
    }

    ICollection<Plane> ITabledCrudModule<Plane, string>.List()
    {
        return m_airplaneModule.ListPlanes();
    }
}