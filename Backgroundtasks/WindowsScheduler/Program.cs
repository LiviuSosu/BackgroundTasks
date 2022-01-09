using System.Data;
using System.Data.SqlClient;

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

Console.WriteLine("Hello, World!");
