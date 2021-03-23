namespace SignalRSampleService.RabbitMq.Contracts
{
    /// <summary>
    /// RabbitMQ contracts.
    /// </summary>
    public class Contracts
    {
        /// <summary>
        /// Contract of message that will be sended after updating ProjectDetail entity.
        /// </summary>
        public record ProjectDetailUpdated(string Name);
    }
}
