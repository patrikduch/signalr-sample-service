using System;

namespace SignalRSampleService.RabbitMq.Contracts
{
    public interface SubmitToken : BaseContract
    {
        string Token { get; }
    }
}
