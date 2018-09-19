using FlightPlan.Application.Domain;
using Xunit;

namespace FlightPlan.UnitTests
{
    public class Flight_Should
    {
        [Fact]
        public void ComputeDistance_WhenAirportsPresent()
        {
            Airport departure = new Airport()
            {
                Name = "Departure",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.53)
            };
            Airport arrival = new Airport()
            {
                Name = "Arrival",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.55)
            };
            Flight flight = new Flight()
            {
                DepartureAirport = departure,
                ArrivalAirport = arrival
            };
            int expected = 1;

            int actual = flight.GetDistanceInKm();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComputeZeroDistance_WhenArrivalIsMissing()
        {
            Airport departure = new Airport()
            {
                Name = "Departure",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.53)
            };
            Flight flight = new Flight()
            {
                DepartureAirport = departure
            };
            int expected = 0;

            int actual = flight.GetDistanceInKm();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComputeZeroDistance_WhenDepartureIsMissing()
        {
            Airport arrival = new Airport()
            {
                Name = "Arrival",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.55)
            };
            Flight flight = new Flight()
            {
                ArrivalAirport = arrival
            };
            int expected = 0;

            int actual = flight.GetDistanceInKm();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComputeTotalFuelConsumption_WhenPlaneIsPresent()
        {
            Airport departure = new Airport()
            {
                Name = "Departure",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.53)
            };
            Airport arrival = new Airport()
            {
                Name = "Arrival",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.55)
            };
            Plane plane = new Plane()
            {
                Model = "Model",
                TakeoffFuelConsumption = 10,
                FuelConsumptionPer100Km = 200
            };
            Flight flight = new Flight()
            {
                DepartureAirport = departure,
                ArrivalAirport = arrival,
                Plane = plane
            };
            double expected = 12;

            double actual = flight.GetTotalFuelConsumption();

            Assert.Equal(expected, actual, 0);
        }

        [Fact]
        public void ComputeZeroFuelConsumption_WhenPlaneIsMissing()
        {
            Airport departure = new Airport()
            {
                Name = "Departure",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.53)
            };
            Airport arrival = new Airport()
            {
                Name = "Arrival",
                Coordinates = new GeoCoordinatePortable.GeoCoordinate(49, 2.55)
            };
            Flight flight = new Flight()
            {
                DepartureAirport = departure,
                ArrivalAirport = arrival
            };
            double expected = 0;

            double actual = flight.GetTotalFuelConsumption();

            Assert.Equal(expected, actual, 0);
        }
    }
}
