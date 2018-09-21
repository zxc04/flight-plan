using System;
using System.ComponentModel.DataAnnotations;

namespace FlightPlan.Application.Domain
{
    public class Plane
    {
        public Guid Id { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Fuel Consumption (L / 100Km)")]
        public double FuelConsumptionPer100Km { get; set; }

        [Display(Name = "Takeoff Effort (L)")]
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
