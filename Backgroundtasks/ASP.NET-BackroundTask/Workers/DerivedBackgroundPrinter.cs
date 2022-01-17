namespace ASP.NET_BackroundTask.Workers
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorker worker;

        public DerivedBackgroundPrinter(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);
        }
    }
}
