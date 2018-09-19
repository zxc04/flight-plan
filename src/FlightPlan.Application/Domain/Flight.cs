using System;

namespace FlightPlan.Application.Domain
{
    public class Flight : IEntity
    {
        public Guid Id { get; private set; }

        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }

        public Plane Plane { get; set; }
    
        public Flight(Guid id, Airport departureAirport, Airport arrivalAirport, Plane plane)
        {
            Id = id;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            Plane = plane;
        }

        public int GetDistanceInKm()
        {
            if (DepartureAirport?.Coordinates == null || ArrivalAirport?.Coordinates == null)
                return 0;

            return (int)(DepartureAirport.Coordinates.GetDistanceTo(ArrivalAirport.Coordinates) / 1000);
        }

        public double GetTotalFuelConsumption()
        {
            if (Plane == null)
                return 0;

            double distance = GetDistanceInKm();
            return Math.Round(Plane.TakeoffFuelConsumption + Plane.FuelConsumptionPer100Km * distance / 100, 2);
        }
    }
}
