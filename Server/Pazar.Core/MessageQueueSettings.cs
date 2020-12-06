namespace Pazar.Core
{
    public class MessageQueueSettings
    {
        public MessageQueueSettings(string host, string userName, string password)
        {
            this.Host = host;
            this.UserName = userName;
            this.Password = password;
        }

        public string Host { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
