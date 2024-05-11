using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class PassengerIntrospectViewModel : IntrospectViewModel<Passenger>
{
    private IEnumerable<FlightReference>? m_availableFlights = null;

    private readonly IFlightsModule m_flightsModule;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public ObservableCollection<FlightReference> Flights { get; } = new ObservableCollection<FlightReference>();

    public IEnumerable<FlightReference> AvailableFlights
    {
        get
        {
            // lazy load flight references
            if (m_availableFlights == null) m_availableFlights = m_flightsModule.ListFlights().Select(f => new FlightReference(f));

            return m_availableFlights;
        }
    }

    public ICommand AddFlightCommand { get; }

    public PassengerIntrospectViewModel(IFlightsModule flightsModule, Passenger model) : base(model)
    {
        m_flightsModule = flightsModule;
        Id = model.Id;
        Name = model.Name;
        Surname = model.Surname;
        PhoneNumber = model.PhoneNumber;
        Address = model.Address;

        foreach (Flight flight in model.Flights)
        {
            Flights.Add(new FlightReference(flight));
        }

        AddFlightCommand = new InstantiateToCollectionCommand<FlightReference>(Flights, () => new FlightReference(0, ""));
    }

    public override IResult Apply()
    {
        List<Flight> flights = new List<Flight>();
        foreach (FlightReference flight in Flights)
        {
            Flight? foundFlight = m_flightsModule.GetFlight(flight.Id);
            if (foundFlight == null)
            {
                return new Error("Flight reference is invalid");
            }
            flights.Add(foundFlight);
        }

        Model.Id = Id;
        Model.Name = Name;
        Model.Surname = Surname;
        Model.PhoneNumber = PhoneNumber;
        Model.Address = Address;

        Model.Flights.Clear();
        foreach (Flight flight in flights)
        {
            Model.Flights.Add(flight);
        }

        return new Ok();
    }
}