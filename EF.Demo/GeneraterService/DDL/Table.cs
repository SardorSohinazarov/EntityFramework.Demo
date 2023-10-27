using System.Text;

namespace EF.Demo.GeneraterService.DDL;

public class Table
{
    public static string CreateTable(Type type)
    {
        var table_name = type.Name;
        StringBuilder query = new StringBuilder($"CREATE TABLE {table_name} (");
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            string propertyType = property.PropertyType.Name switch
            {
                "Int32" => "int",
                "String" => "nvarchar(255)",
                "DateTime" => "DATETIME",
                _ => "nvarchar(50)",
            };


            if (property.Name != "Id")
            {
                query.Append($"{property.Name} {propertyType},");
            }
            else
            {
                query.Append($"{property.Name} {propertyType} NOT NULL PRIMARY KEY,");
            }
        }

        query = query.Remove(query.Length - 1, 1);

        query.Append(");");

        return query.ToString();
    }

    public static string DropTable(Type type)
    {
        var table_name = type.Name;

        return $"DROP TABLE {table_name};";
    }
}
