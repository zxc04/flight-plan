using System;

namespace FlightPlan.Sql.Entities
{
    public class Flight
    {
        public Guid Id { get; set; }

        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }

        public Plane Plane { get; set; }
    }
}
