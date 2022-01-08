using System.Data.SqlClient;

namespace ASP.NET_BackroundTask.Workers
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;

        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            string connetionString = "Data Source = DESKTOP-M80MDUC\\SQLEXPRESS;Initial Catalog=BackgroundTasks;Integrated Security = True;";
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sqlCommand = "DELETE FROM [dbo].[Articles] WHERE CreatedOn > DATEADD(SECOND, -8, GETDATE());";

            command = new SqlCommand(sqlCommand, cnn);

            while (!cancellationToken.IsCancellationRequested)
            {
                //Interlocked.Increment(ref number);
                //logger.LogInformation($"Worker printing number: {number}");

                adapter.DeleteCommand = new SqlCommand(sqlCommand, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                await Task.Delay(5000);
            }

            command.Dispose();
            cnn.Close();
        }
    }
}
