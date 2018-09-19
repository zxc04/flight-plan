using FlightPlan.Application.Domain;
using System;

namespace FlightPlan.Application.Repositories
{
    public interface IAirportRepository
    {
        void AddOrUpdate(Airport airport);
        void Delete(Guid id);
    }
}
