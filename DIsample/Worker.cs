using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIsample
{


    public sealed class Worker(IMessageWriter messageWriter) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(1_000, stoppingToken);
            }
        }
    }
}
