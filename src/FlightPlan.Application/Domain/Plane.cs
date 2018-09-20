using System;

namespace FlightPlan.Application.Domain
{
    public class Plane
    {
        public Guid Id { get; set; }

        public string Model { get; set; }
        public double FuelConsumptionPer100Km { get; set; }
        public double TakeoffFuelConsumption { get; set; }

        public Plane()
        {
        }

        public Plane(Guid id, string model, double fuelConsumptionPer100Km, double takeoffFuelConsumption)
        {
            Id = id;
            Model = model;
            FuelConsumptionPer100Km = fuelConsumptionPer100Km;
            TakeoffFuelConsumption = takeoffFuelConsumption;
        }
    }
}
