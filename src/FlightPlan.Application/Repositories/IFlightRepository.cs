using FlightPlan.Application.Domain;
using System;

namespace FlightPlan.Application.Repositories
{
    public interface IFlightRepository
    {
        void AddOrUpdate(Flight flight);
        void Delete(Guid id);
    }
}
