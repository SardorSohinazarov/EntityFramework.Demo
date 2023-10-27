namespace EF.Demo.Services.GeneraterService.DDL;

public class Database
{
    public static string CreateDatabase(string connectionString)
    {
        var databasename = GetDatabaseName(connectionString);

        return $"CREATE DATABASE {databasename}";
    }

    public static string DropDatabase(string connectionString)
    {
        var databasename = GetDatabaseName(connectionString);

        return $"DROP DATABASE {databasename};";
    }

    private static string GetDatabaseName(string connectionString)
    {
        var startIndex = connectionString.IndexOf("Initial Catalog=") + 16;// 16 soni Initial Catalog= uzunligi

        var endIndex = connectionString.IndexOf(';', startIndex);

        return connectionString.Substring(startIndex, endIndex - startIndex);
    }
}
