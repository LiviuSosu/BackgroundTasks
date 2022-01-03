namespace ASP.NET_BackroundTask.Workers
{
    //https://www.youtube.com/watch?v=1Fe7QD7Ovi8&ab_channel=DotNetCoreCentral
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-6.0&tabs=visual-studio
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
