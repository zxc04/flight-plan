using GeoCoordinatePortable;
using System;

namespace FlightPlan.Application.Domain
{
    public class Airport : IEntity
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }
        public GeoCoordinate Coordinates { get; set; }

        public Airport(Guid id, string name, GeoCoordinate coordinates)
        {
            Id = id;
            Name = name;
            Coordinates = coordinates;
        }
    }
}