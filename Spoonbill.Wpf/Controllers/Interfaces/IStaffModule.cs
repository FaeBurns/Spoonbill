using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface IStaffModule
{
    Staff? GetStaff(int id);
    IResult CreateStaff(Staff staff);
    IResult UpdateStaff(Staff staff);
    IResult DeleteStaff(Staff staff);
    StaffWorker? GetStaffWorker(int id);
    Pilot? GetPilot(int id);
    ICollection<Staff> ListStaff();
}