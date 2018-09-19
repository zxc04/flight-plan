using System;

namespace FlightPlan.Application.Domain
{
    public class Plane : IEntity
    {
        public Guid Id { get; private set; }

        public string Model { get; set; }
        public double FuelConsumptionPer100Km { get; set; }
        public double TakeoffFuelConsumption { get; set; }

        public Plane(Guid id, string model, double fuelConsumptionPer100Km, double takeoffFuelConsumption)
        {
            Id = id;
            Model = model;
            FuelConsumptionPer100Km = fuelConsumptionPer100Km;
            TakeoffFuelConsumption = takeoffFuelConsumption;
        }
    }
}
