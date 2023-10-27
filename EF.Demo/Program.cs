using EF.Demo.GeneraterService;
using EF.Demo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Table.CreateTable(typeof(Car)));
        Console.WriteLine(Table.DropTable(typeof(Car)));
    }
}