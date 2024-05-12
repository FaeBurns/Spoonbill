using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class FlightIntrospectViewModel : IntrospectViewModel<Flight>
{
    private readonly ISpoonbillContainer m_container;

    public int Id { get; }
    public string Name { get; set; }
    public string PlaneSerial { get; set; }

    public ObservableCollection<PassengerReference> Passengers { get; }
    public ObservableCollection<PilotReference> Pilots { get; }
    public ObservableCollection<StaffWorkerReference> StaffWorkers { get; }

    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }

    public LazyLoadViewModel<IEnumerable<string>> AvailablePlanes { get; }
    public LazyLoadViewModel<IEnumerable<PassengerReference>> AvailablePassengers { get; }
    public LazyLoadViewModel<IEnumerable<PilotReference>> AvailablePilots { get; }
    public LazyLoadViewModel<IEnumerable<StaffWorkerReference>> AvailableStaffWorkers { get; }

    public ICommand AddPassengerCommand { get; }
    public ICommand AddPilotCommand { get; }
    public ICommand AddStaffWorkerCommand { get; }

    public ICommand RemovePassengerCommand { get; }
    public ICommand RemovePilotCommand { get; }
    public ICommand RemoveStaffWorkerCommand { get; }

    public FlightIntrospectViewModel(ISpoonbillContainer container, Flight model) : base(model)
    {
        m_container = container;
        Id = model.FlightId;
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        Name = model.Name ?? String.Empty;
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        PlaneSerial = model.Plane?.Serial ?? String.Empty;

        Passengers = new ObservableCollection<PassengerReference>(model.Passengers.Select(p => new PassengerReference(p)));
        Pilots = new ObservableCollection<PilotReference>(model.Pilots.Select(p => new PilotReference(p)));
        StaffWorkers = new ObservableCollection<StaffWorkerReference>(model.WorkerStaff.Select(s => new StaffWorkerReference(s)));

        ArrivalTime = model.ArrivalTime == DateTime.MinValue ? DateTime.UtcNow : model.ArrivalTime;
        DepartureTime = model.DepartureTime == DateTime.MinValue ? DateTime.UtcNow : model.DepartureTime;

        // TODO: Add flight stops

        AvailablePlanes = new LazyLoadViewModel<IEnumerable<string>>(() =>
        {
            return container.AirplaneModule.ListPlanes().Select(p => p.Serial);
        });
        AvailablePassengers = new LazyLoadViewModel<IEnumerable<PassengerReference>>(() =>
        {
            return container.PassengerModule.ListPassengers().Select(p => new PassengerReference(p));
        });
        AvailablePilots = new LazyLoadViewModel<IEnumerable<PilotReference>>(() =>
        {
            return container.StaffModule.ListPilots().Select(p => new PilotReference(p));
        });
        AvailableStaffWorkers = new LazyLoadViewModel<IEnumerable<StaffWorkerReference>>(() =>
        {
            return container.StaffModule.ListStaffWorkers().Select(s => new StaffWorkerReference(s));
        });

        AddPassengerCommand = new EasyInstantiateToCollectionCommand<PassengerReference>(Passengers);
        AddPilotCommand = new EasyInstantiateToCollectionCommand<PilotReference>(Pilots);
        AddStaffWorkerCommand = new EasyInstantiateToCollectionCommand<StaffWorkerReference>(StaffWorkers);

        RemovePassengerCommand = new RemoveFromCollectionCommand<PassengerReference>(Passengers);
        RemovePilotCommand = new RemoveFromCollectionCommand<PilotReference>(Pilots);
        RemoveStaffWorkerCommand = new RemoveFromCollectionCommand<StaffWorkerReference>(StaffWorkers);
    }

    public override IResult Apply()
    {
        Plane? plane = m_container.AirplaneModule.GetPlane(PlaneSerial);
        if (plane == null)
            return new Error("Invalid plane selected");

        List<Passenger> validPassengers = new List<Passenger>();
        foreach (PassengerReference reference in Passengers)
        {
            Passenger? passenger = m_container.PassengerModule.GetPassenger(reference.Id);
            if (passenger == null)
                return new Error($"Invalid passenger selected\nId: {reference.Id}\nName: {reference.FullName}");
            validPassengers.Add(passenger);
        }

        List<Pilot> validPilots = new List<Pilot>();
        foreach (PilotReference reference in Pilots)
        {
            Pilot? pilot = m_container.StaffModule.GetPilot(reference.Id);
            if (pilot == null)
                return new Error($"Invalid pilot selected\nId: {reference.Id}\nName: {reference.FullName}");
            validPilots.Add(pilot);
        }

        List<StaffWorker> validStaff = new List<StaffWorker>();
        foreach (StaffWorkerReference reference in StaffWorkers)
        {
            StaffWorker? staff = m_container.StaffModule.GetStaffWorker(reference.Id);
            if (staff == null)
                return new Error($"Invalid staff selected\nId: {reference.Id}\nName: {reference.FullName}");
            validStaff.Add(staff);
        }

        Model.Name = Name;
        Model.Plane = plane;
        Model.Passengers = validPassengers;
        Model.Pilots = validPilots;
        Model.WorkerStaff = validStaff;
        Model.ArrivalTime = ArrivalTime;
        Model.DepartureTime = DepartureTime;

        // TODO: Add flight stops

        return new Ok();
    }
}