namespace Spoonbill.Data.Models;

public class Plane
{
    public string Serial { get; set; } = null!;
    public PlaneModel Model { get; set; } = null!;

    public int GetModelNumber() => Model.ModelNumber;
}