namespace LinqToDBBlog.Service
{
    public interface IDatabaseRetryService
    {
        public T ExecuteWithRetry<T>(Func<T> action);
        Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> action);
    }
}
