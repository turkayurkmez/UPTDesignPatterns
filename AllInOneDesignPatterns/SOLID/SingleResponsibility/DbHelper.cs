using System.Data.SqlClient;

namespace SingleResponsibility
{
    public class DbHelper
    {
        SqlConnection sqlConnection;

        void deneme()
        {

        }
        public DbHelper(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public int Execute(string commandText, Dictionary<string, object> parameters)
        {
            SqlCommand command = createCommand(commandText, parameters);
            int result = 0;
            using (command.Connection)
            {
                command.Connection.Open();
                result = command.ExecuteNonQuery();
            }

            return result;
        }

        private SqlCommand createCommand(string commandText, Dictionary<string, object> parameters)
        {
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = commandText;
            addParametersToCommand(command, parameters);
            return command;
        }

        private void addParametersToCommand(SqlCommand command, Dictionary<string, object> parameters)
        {
            foreach (var parmeter in parameters)
            {
                command.Parameters.AddWithValue(parmeter.Key, parmeter.Value);
            }

        }
    }
}
