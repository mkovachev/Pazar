namespace Pazar.Core
{
    public class MessageQueueSettings
    {
        public MessageQueueSettings(string? host, string? userName, string? password)
        {
        }

        public string Host { get; set; } = "localhost";

        public string UserName { get; set; } = "rabbitmquser";

        public string Password { get; set; } = "rabbitmq1234";
    }
}
