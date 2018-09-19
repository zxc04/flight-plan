using FlightPlan.Application.Repositories;
using FlightPlan.Sql.Entities;
using System;
using Plane = FlightPlan.Application.Domain.Plane;

namespace FlightPlan.Sql.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly DatabaseContext context;

        public PlaneRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddOrUpdate(Plane plane)
        {
            if (plane.Id == null || plane.Id == Guid.Empty)
                Add(plane);
            else
                Update(plane);
        }

        public void Delete(Guid id)
        {
            Entities.Plane entity = context.Planes.Find(id);
            if (entity != null)
            {
                context.Planes.Remove(entity);
                context.SaveChanges();
            }
        }

        private void Add(Plane plane)
        {
            Entities.Plane entity = new Entities.Plane()
            {
                Id = Guid.NewGuid(),
                Model = plane.Model,
                FuelConsumptionPer100Km = plane.FuelConsumptionPer100Km,
                TakeoffFuelConsumption = plane.TakeoffFuelConsumption
            };

            context.Add(entity);
            context.SaveChanges();
        }

        private void Update(Plane plane)
        {
            Entities.Plane entity = context.Planes.Find(plane.Id);

            entity.Model = plane.Model;
            entity.FuelConsumptionPer100Km = plane.FuelConsumptionPer100Km;
            entity.TakeoffFuelConsumption = plane.TakeoffFuelConsumption;

            context.Update(entity);
            context.SaveChanges();
        }
    }
}
