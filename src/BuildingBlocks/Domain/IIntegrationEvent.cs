using MediatR;

namespace Hababk.BuildingBlocks.Domain;

public interface IIntegrationEvent : INotification
{
    int Id { get; }
    DateTime OccurredOn { get; }
}