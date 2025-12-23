namespace OnlineOrderSystem.Utils;

public static class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine(message); // ❌ gereksiz tekrar
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }

}
