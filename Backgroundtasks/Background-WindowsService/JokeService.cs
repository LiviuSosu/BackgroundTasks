using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Background_WindowsService
{
    public class JokeService
    {
        public void GetJokeAsync()
        {
            string connetionString = "Data Source = DESKTOP-M80MDUC\\SQLEXPRESS;Initial Catalog=BackgroundTasks;Integrated Security = True;";
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sqlCommand = "DELETE FROM [dbo].[Articles] WHERE CreatedOn < DATEADD(SECOND, -2, GETDATE());";

            command = new SqlCommand(sqlCommand, cnn);

            adapter.DeleteCommand = new SqlCommand(sqlCommand, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }
    }
}
