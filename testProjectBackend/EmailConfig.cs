namespace testProjectBackend
{
    public class EmailConfig
    {
        public string SupportMail { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool SmtpEnableSsl { get; set; }
        public bool SmtpEnableCredentials { get; set; }
        public bool SmtpUseDefaultCredentials { get; set; }
    }
}