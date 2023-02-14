// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var help1 = DatabaseHelper.CreateHelper();
help1.SampleNumber = 8;

var help2 = DatabaseHelper.CreateHelper();
Console.WriteLine(help2.SampleNumber);

var help3 = DatabaseHelper.CreateHelper();
//help3.SampleNumber = 9;
var help4 = DatabaseHelper.CreateHelper();
Console.WriteLine(help4.SampleNumber);
//Bir sınıftan SADECE 1 ADET instance yeterli ise bu pattern'i kullanabilrsiniz!

public class DatabaseHelper
{
    private DatabaseHelper()
    {
        //if (instance == null)
        //{
        //    instance = new DatabaseHelper();
        //}
    }
    //public DatabaseHelper Instance { get; set; }

    public int SampleNumber { get; set; }

    private static DatabaseHelper instance;
    public static DatabaseHelper CreateHelper()
    {
        if (instance == null)
        {
            instance = new DatabaseHelper();
        }

        return instance;
    }
}


public static class DBHelper
{
    public static int SampleNumber { get; set; }
}


public interface IHelper
{
    int SampleNumber { get; set; }
}