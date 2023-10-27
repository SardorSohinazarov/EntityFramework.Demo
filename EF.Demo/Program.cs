using EF.Demo.GeneraterService;
using EF.Demo.GeneraterService.DML;
using EF.Demo.Models;

internal class Program
{
    public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF.Demo;Integrated Security=True;";
    public static void Main(string[] args)
    {
        Car car = new Car()
        {
           Name = "Malibu",
           MadeDate = DateTime.Now,
        };
        Console.WriteLine(Context.InsertInto<Car>(car));
        Console.WriteLine(Context.GetAll<Car>());
    }

    public static string GetDatabaseName(string connectionString)
    {
        var startIndex = connectionString.IndexOf("Initial Catalog=") + 16;// 16 soni Initial Catalog= uzunligi

        var endIndex = connectionString.IndexOf(';', startIndex);

        return connectionString.Substring(startIndex,endIndex - startIndex);
    }
}