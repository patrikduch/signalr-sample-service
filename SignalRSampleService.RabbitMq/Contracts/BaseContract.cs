using System;

namespace SignalRSampleService.RabbitMq.Contracts
{
    public interface BaseContract
    {
        Guid EventId { get; }
        DateTime Timestamp { get; }
    }
}
