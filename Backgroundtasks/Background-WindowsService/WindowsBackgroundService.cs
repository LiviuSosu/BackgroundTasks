using System;
using System.Collections.Generic;
using System.Text;

namespace Background_WindowsService
{
    public sealed class WindowsBackgroundService : BackgroundService
    {
        private readonly JokeService _jokeService;
        private readonly ILogger<WindowsBackgroundService> _logger;

        public WindowsBackgroundService(
            JokeService jokeService,
            ILogger<WindowsBackgroundService> logger) =>
            (_jokeService, _logger) = (jokeService, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _jokeService.GetJokeAsync();
                Console.WriteLine("Bogdan Gheorghiu");
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
