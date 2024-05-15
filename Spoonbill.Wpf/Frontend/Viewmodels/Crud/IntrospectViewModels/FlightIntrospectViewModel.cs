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

    public ObservableCollection<ContainedReference<PassengerReference>> Passengers { get; private set; }
    public ObservableCollection<ContainedReference<PilotReference>> Pilots { get; private set; }
    public ObservableCollection<ContainedReference<StaffWorkerReference>> StaffWorkers { get; private set; }

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

        Passengers = new ObservableCollection<ContainedReference<PassengerReference>>(model.Passengers.Select(p => new ContainedReference<PassengerReference>(new PassengerReference(p))));
        Pilots = new ObservableCollection<ContainedReference<PilotReference>>(model.Pilots.Select(p => new ContainedReference<PilotReference>(new PilotReference(p))));
        StaffWorkers = new ObservableCollection<ContainedReference<StaffWorkerReference>>(model.WorkerStaff.Select(s => new ContainedReference<StaffWorkerReference>(new StaffWorkerReference(s))));

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

        AddPassengerCommand = new InstantiateToCollectionCommand<ContainedReference<PassengerReference>>(Passengers, () => new ContainedReference<PassengerReference>(new PassengerReference()));
        AddPilotCommand = new EasyInstantiateToCollectionCommand<ContainedReference<PilotReference>>(Pilots);
        AddStaffWorkerCommand = new EasyInstantiateToCollectionCommand<ContainedReference<StaffWorkerReference>>(StaffWorkers);

        RemovePassengerCommand = new RemoveFromCollectionCommand<ContainedReference<PassengerReference>>(Passengers);
        RemovePilotCommand = new RemoveFromCollectionCommand<ContainedReference<PilotReference>>(Pilots);
        RemoveStaffWorkerCommand = new RemoveFromCollectionCommand<ContainedReference<StaffWorkerReference>>(StaffWorkers);
    }

    public override IResult Apply()
    {
        Plane? plane = m_container.AirplaneModule.GetPlane(PlaneSerial);
        if (plane == null)
            return new Invalid("Invalid plane selected");

        List<Passenger> validPassengers = new List<Passenger>();
        foreach (ContainedReference<PassengerReference> reference in Passengers)
        {
            Passenger? passenger = m_container.PassengerModule.GetPassenger(reference.Value.Id);
            if (passenger == null)
                return new Invalid($"Invalid passenger selected\nId: {reference.Value.Id}\nName: {reference.Value.FullName}");
            validPassengers.Add(passenger);
        }

        List<Pilot> validPilots = new List<Pilot>();
        foreach (ContainedReference<PilotReference> reference in Pilots)
        {
            Pilot? pilot = m_container.StaffModule.GetPilot(reference.Value.Id);
            if (pilot == null)
                return new Invalid($"Invalid pilot selected\nId: {reference.Value.Id}\nName: {reference.Value.FullName}");
            validPilots.Add(pilot);
        }

        List<StaffWorker> validStaff = new List<StaffWorker>();
        foreach (ContainedReference<StaffWorkerReference> reference in StaffWorkers)
        {
            StaffWorker? staff = m_container.StaffModule.GetStaffWorker(reference.Value.Id);
            if (staff == null)
                return new Invalid($"Invalid staff selected\nId: {reference.Value.Id}\nName: {reference.Value.FullName}");
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