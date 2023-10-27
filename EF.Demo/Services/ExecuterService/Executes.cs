using System.Data.SqlClient;

namespace EF.Demo.Services.ExecuterService
{
    public class Executes
    {
        public static (bool, string) Execute(string query)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection("");
                SqlCommand cm = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                cm.ExecuteNonQuery();
                return (true, "Complated Successfully");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static (bool, string,List<T>?) Execute<T>(string query)
        {
            SqlConnection sqlConnection = null;
            try
            {
                List<T> result = new List<T>();
                var objectType = typeof(T);
                var properties = typeof(T).GetProperties();

                sqlConnection = new SqlConnection("");//configuratsiyadanmi biror joydan olamizda

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));

                    foreach (var property in properties)
                    {
                        Console.WriteLine(sqlDataReader[property.Name]);

                        var objectProperty = objectType.GetProperty(property.Name);
                        objectProperty.SetValue(instance, sqlDataReader[property.Name]);
                    }

                    result.Add(instance);
                }
                return (true, "Complated Successfully",new List<T>());
            }
            catch (Exception e)
            {
                return (false, e.Message,null);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
