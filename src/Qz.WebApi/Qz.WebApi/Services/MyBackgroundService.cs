
using Qz.Utility.Extensions;

namespace Qz.WebApi.Services
{
    public class MyBackgroundService : BackgroundService
    {
        ILogger<MyBackgroundService> logger;

        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"now: {DateTime.Now.ToLong()}");
                await Task.Delay(1000);
            }
        }
    }
}
