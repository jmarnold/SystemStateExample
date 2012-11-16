namespace SystemStateExample.Infrastructure
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            From = "no-reply@test.com";
            Host = "localhost";
            Port = 25;
        }

        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}