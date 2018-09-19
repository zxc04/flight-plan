using FlightPlan.Application.Domain;
using System;

namespace FlightPlan.Application.Repositories
{
    public interface IPlaneRepository
    {
        void AddOrUpdate(Plane plane);
        void Delete(Guid id);
    }
}
