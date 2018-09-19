using System;
using System.Collections.Generic;

namespace FlightPlan.Sql.Entities
{
    public class Plane
    {
        public Guid Id { get; set; }

        public string Model { get; set; }
        public double FuelConsumptionPer100Km { get; set; }
        public double TakeoffFuelConsumption { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
