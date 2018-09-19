using System;

namespace FlightPlan.Application.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
