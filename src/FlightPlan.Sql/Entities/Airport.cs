using System;
using System.Collections.Generic;

namespace FlightPlan.Sql.Entities
{
    public class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Flight> DepartureFlights { get; set; }
        public ICollection<Flight> ArrivalFlights { get; set; }
    }
}