using GeoCoordinatePortable;
using System;

namespace FlightPlan.Application.Domain
{
    public class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinate Coordinates => new GeoCoordinate(Latitude, Longitude);

        public Airport()
        {
        }

        public Airport(Guid id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}