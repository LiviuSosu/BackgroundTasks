
using System.Data.SqlClient;

namespace Background_WindowsService
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger<DefaultScopedProcessingService> _logger;

        public DefaultScopedProcessingService(
            ILogger<DefaultScopedProcessingService> logger) =>
            _logger = logger;

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            string connetionString = "Data Source = DESKTOP-M80MDUC\\SQLEXPRESS;Initial Catalog=BackgroundTasks;Integrated Security = True;";
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sqlCommand = "DELETE FROM [dbo].[Articles] WHERE CreatedOn < DATEADD(SECOND, -2, GETDATE());";

            command = new SqlCommand(sqlCommand, cnn);

            while (!stoppingToken.IsCancellationRequested)
            {
                adapter.DeleteCommand = new SqlCommand(sqlCommand, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                await Task.Delay(2000);
                _logger.LogInformation("SQL Comand executed");

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
