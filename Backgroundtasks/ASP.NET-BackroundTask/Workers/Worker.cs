using System.Data.SqlClient;

namespace ASP.NET_BackroundTask.Workers
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;

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
            string sqlCommand = "DELETE FROM [dbo].[Articles] WHERE CreatedOn < DATEADD(SECOND, -2, GETDATE());";

            command = new SqlCommand(sqlCommand, cnn);

            while (!cancellationToken.IsCancellationRequested)
            {
                adapter.DeleteCommand = new SqlCommand(sqlCommand, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                await Task.Delay(2000);
                logger.LogInformation("SQL COmand executed");
            }

            command.Dispose();
            cnn.Close();
        }
    }
}
