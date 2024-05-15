using System.Collections.Generic;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface IAirplaneModule
{
    Plane? GetPlane(string serial);
    IResult CreatePlane(Plane plane);
    IResult UpdatePlane(Plane plane);
    IResult DeletePlane(Plane plane);
    ICollection<Plane> ListPlanes();

    PlaneModel? GetModel(int modelNumber);
    IResult CreateModel(PlaneModel model);
    IResult UpdateModel(PlaneModel model);
    IResult DeleteModel(PlaneModel model);
    ICollection<PlaneModel> ListModels();

    Manufacturer? GetManufacturer(string name);
    IResult CreateManufacturer(Manufacturer manufacturer);
    IResult UpdateManufacturer(Manufacturer manufacturer);
    IResult DeleteManufacturer(Manufacturer manufacturer);
    ICollection<Manufacturer> ListManufacturers();
}