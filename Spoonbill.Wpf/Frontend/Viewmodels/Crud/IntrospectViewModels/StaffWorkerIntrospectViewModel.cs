using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class StaffWorkerIntrospectViewModel : IntrospectViewModel<StaffWorker>
{
    private readonly IFlightsModule m_flightsModule;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Role { get; set; }

    public ObservableCollection<ContainedReference<FlightReference>> Flights { get; }

    public LazyLoadViewModel<IEnumerable<FlightReference>> AvailableFlights { get; }

    public ICommand AddFlightCommand { get; }
    public ICommand RemoveFlightCommand { get; }

    public StaffWorkerIntrospectViewModel(IFlightsModule flightsModule, StaffWorker model) : base(model)
    {
        m_flightsModule = flightsModule;
        Id = model.Id;
        Name = model.Name;
        Surname = model.Surname;
        PhoneNumber = model.PhoneNumber;
        Address = model.Address;
        Role = model.Role;

        AvailableFlights = new LazyLoadViewModel<IEnumerable<FlightReference>>(() => m_flightsModule.ListFlights().Select(f => new FlightReference(f)).ToList());

        Flights = new ObservableCollection<ContainedReference<FlightReference>>(model.AssignedFlights.Select(f => new ContainedReference<FlightReference>(new FlightReference(f), AvailableFlights.Value)));

        AddFlightCommand = new InstantiateToCollectionCommand<ContainedReference<FlightReference>>(Flights, () => new ContainedReference<FlightReference>(AvailableFlights.Value));
        RemoveFlightCommand = new RemoveFromCollectionCommand<ContainedReference<FlightReference>>(Flights);
    }

    public override IResult Apply()
    {
        List<Flight> flights = new List<Flight>();
        foreach (ContainedReference<FlightReference> reference in Flights)
        {
            Flight? foundFlight = m_flightsModule.GetFlight(reference.Value.Id);
            if (foundFlight == null)
            {
                return new Invalid("Flight reference is invalid");
            }
            flights.Add(foundFlight);
        }

        Model.Id = Id;
        Model.Name = Name;
        Model.Surname = Surname;
        Model.PhoneNumber = PhoneNumber;
        Model.Address = Address;

        Model.AssignedFlights = flights;
        Model.Role = Role;

        return new Ok();
    }
}