using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SO58831661
{
    internal class PaymentQueueService : IHostedService, IDisposable
    {
        private readonly ILogger<Program> _logService;
        private Timer _timerEnqueue;

        public PaymentQueueService(ILogger<Program> logService)
        {
            _logService = logService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logService.LogInformation("Starting processing payments.");

            _timerEnqueue = new Timer(EnqueuePayments, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void EnqueuePayments(object state)
        {
            _logService.LogInformation("Enqueueing Payments.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logService.LogInformation("Stopping processing payments.");

            _timerEnqueue?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerEnqueue?.Dispose();
        }
    }
}