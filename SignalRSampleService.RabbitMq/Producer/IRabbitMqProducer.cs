namespace SignalRSampleService.RabbitMq.Producer
{
    public interface IRabbitMqProducer
    {
        void Publish(string message);
    }
}
