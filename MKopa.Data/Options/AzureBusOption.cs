namespace MKopa.Data.Options
{
    public class AzureBusOption
    {
        public string AzureServiceBusEndPoint { get; set; }
        public string AzureServiceBusBaseURL { get; set; }
        public string SendSMSQueueName { get; set; }
        public string ProcessedSMSQueueName { get; set; }
    }
}
