namespace ASP.NET_BackroundTask.Workers
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
