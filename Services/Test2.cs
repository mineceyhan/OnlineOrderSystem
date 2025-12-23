public class Test2
{
    public void M2()
    {
        Test1 test1 = new Test1();
        var result = test1.M1();
        var p = JsonHelper.Deserialize<Person>(result);
        Console.WriteLine($"JSON Parse Başarılı: Name={p.Name}, Age={p.Age}");
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        Test2 test2 = new Test2();
        test2.M2();
    }
}
 