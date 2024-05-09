using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Serial))]
public class Plane
{
    [StringLength(20)]
    public string Serial { get; set; } = null!;

    public PlaneModel Model { get; set; } = null!;

    public int GetModelNumber()
    {
        return Model.ModelNumber;
    }
}