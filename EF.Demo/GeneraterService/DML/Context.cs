using System.Text;

namespace EF.Demo.GeneraterService.DML
{
    public class Context
    {
        public static string InsertInto<T>(T @object)
        {
            var table_name = typeof(T).Name;
            var properties = typeof(T).GetProperties();

            StringBuilder query = new StringBuilder($"INSERT INTO {table_name} (");

            foreach (var property in properties)
            {
                query.Append(property.Name + ",");
            }

            query.Remove(query.Length - 1, 1);
            query.Append(") VALUES (");

            foreach (var property in properties)
            {
                if(property.PropertyType != typeof(DateTime))
                {
                    query.Append(property.GetValue(@object) + ",");
                }
                else
                {
                    var date = (DateTime)(property.GetValue(@object));
                    var dateString = date.ToString("MM/dd/yyyy HH:mm:ss");
                    query.Append(dateString + ",");
                }
            }

            query.Remove(query.Length - 1, 1);
            query.Append(");");

            return query.ToString();
        }

        public static string GetAll<T>()
        {
            string table_name = typeof(T).Name;

            return $"SELECT * FROM {table_name}";
        }
    }
}
