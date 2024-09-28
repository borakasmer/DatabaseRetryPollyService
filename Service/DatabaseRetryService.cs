using LinqToDB.SqlQuery;
using LinqToDBBlog.Models;
using Microsoft.Extensions.Options;
using Polly;

namespace LinqToDBBlog.Service
{
    public class DatabaseRetryService : IDatabaseRetryService
    {
        private readonly IOptions<DatabaseReconnectSettings> _databaseReconnectSettings;
        private readonly string _logFilePath = @"C:\Logs\ReconnectLog.txt";

        public DatabaseRetryService(IOptions<DatabaseReconnectSettings> settings)
        {
            _databaseReconnectSettings = settings;
            EnsureLogDirectoryExists();
        }

        public TResult ExecuteWithRetry<TResult>(Func<TResult> action)
        {
            var retryPolicy = Policy<TResult>
                .Handle<Exception>()
                .WaitAndRetry(
                    _databaseReconnectSettings.Value.RetryCount,
                    retryAttempt => TimeSpan.FromSeconds(_databaseReconnectSettings.Value.RetryWaitPeriodInSeconds),
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        LogRetryAttempt(retryCount, exception.Exception);
                    });

            var fallbackPolicy = Policy<TResult>
                .Handle<Exception>()
                .Fallback(
                    fallbackValue: default(TResult),  // Return default value for TResult (null for reference types)
                    onFallback: (exception) =>
                    {
                        File.AppendAllText(_logFilePath, $"Failed after maximum retries. Exception Message: {exception.Exception.Message}" + Environment.NewLine);
                        throw exception.Exception;
                    });

            var retryWrapPolicy = Policy.Wrap(fallbackPolicy, retryPolicy);

            return retryWrapPolicy.Execute(() => action());
        }

        public async Task<TResult> ExecuteWithRetryAsync<TResult>(Func<Task<TResult>> action)
        {
            var retryPolicy = Policy<TResult>
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    _databaseReconnectSettings.Value.RetryCount,
                    retryAttempt => TimeSpan.FromSeconds(_databaseReconnectSettings.Value.RetryWaitPeriodInSeconds),
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        LogRetryAttempt(retryCount, exception.Exception);
                    });

            var fallbackPolicy = Policy<TResult>
                .Handle<Exception>()
                .FallbackAsync(
                    fallbackValue: default(TResult),  // Return default value for TResult (null for reference types)
                     onFallbackAsync: async e =>
                     {
                         await Task.Run(() => File.AppendAllText(_logFilePath, $"Failed after maximum retries. Exception Message: {e.Exception.Message}" + Environment.NewLine));
                         throw e.Exception;

                     });

            var retryWrapPolicy = Policy.WrapAsync(fallbackPolicy, retryPolicy);

            return await retryWrapPolicy.ExecuteAsync(() => action());
        }

        private void LogRetryAttempt(int retryCount, Exception exception)
        {
            System.IO.File.AppendAllText(_logFilePath, $"Connection lost, retry attempt {retryCount} at {DateTime.Now}. Exception Message: {exception.Message}" + Environment.NewLine);
        }

        private void EnsureLogDirectoryExists()
        {
            var directory = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
