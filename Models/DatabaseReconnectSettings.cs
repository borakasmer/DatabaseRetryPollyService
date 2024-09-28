namespace LinqToDBBlog.Models
{
    public class DatabaseReconnectSettings
    {
        public int RetryCount { get; set; }
        public int RetryWaitPeriodInSeconds { get; set; }
    }
}
