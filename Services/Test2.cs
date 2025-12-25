using OnlineOrderSystem.Services;

public class Test2
{
    public void M2()
    {
        Test1 test1 = new Test1();
        var result = test1.M1();

        var zero = test1.CodeAnt0();
        var x = 3/zero;
        Console.WriteLine(x);
        var p = JsonHelper.Deserialize<Person>(result);
        Console.WriteLine($"JSON Parse Başarılı: Name={p.Name}, Age={p.Age}");
    }
}

 