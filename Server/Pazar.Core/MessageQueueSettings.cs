namespace Pazar.Core
{
    public class MessageQueueSettings
    {
        public MessageQueueSettings(string? host = "localhost", string? userName = "guest", string? password = "guest")
        {
            //this.Host = host;
            //this.UserName = userName;
            //this.Password = password;
        }

        public string Host { get; set; } = "localhost";

        public string UserName { get; set; } = "guest";

        public string Password { get; set; } = "guest";
    }
}
