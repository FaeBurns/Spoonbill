using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public class TabledStaffModule : ITabledCrudModule<StaffWorker, int>, ITabledCrudModule<Pilot, int>
{
    private readonly IStaffModule m_staffModule;

    public TabledStaffModule(IStaffModule staffModule)
    {
        m_staffModule = staffModule;
    }
    
    IResult ITabledCrudModule<StaffWorker, int>.Create(StaffWorker model)
    {
        return m_staffModule.CreateStaff(model);
    }

    IResult ITabledCrudModule<Pilot, int>.Create(Pilot model)
    {
        return m_staffModule.CreateStaff(model);
    }

    Pilot? ITabledCrudModule<Pilot, int>.Read(int key)
    {
        return m_staffModule.GetPilot(key);
    }

    IResult ITabledCrudModule<Pilot, int>.Update(Pilot model)
    {
        return m_staffModule.UpdateStaff(model);
    }

    IResult ITabledCrudModule<Pilot, int>.Destroy(Pilot model)
    {
        return m_staffModule.DeleteStaff(model);
    }

    ICollection<Pilot> ITabledCrudModule<Pilot, int>.List()
    {
        return m_staffModule.ListPilots();
    }

    StaffWorker? ITabledCrudModule<StaffWorker, int>.Read(int key)
    {
        return m_staffModule.GetStaffWorker(key);
    }

    IResult ITabledCrudModule<StaffWorker, int>.Update(StaffWorker model)
    {
        return m_staffModule.UpdateStaff(model);
    }

    IResult ITabledCrudModule<StaffWorker, int>.Destroy(StaffWorker model)
    {
        return m_staffModule.DeleteStaff(model);
    }

    ICollection<StaffWorker> ITabledCrudModule<StaffWorker, int>.List()
    {
        return m_staffModule.ListStaffWorkers();
    }
}