using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Models;

public class Customer
{
    public int Id { get; }
    public string Email { get; }

    public Customer(int id, string email)
    {
        Id = id;
        Email = email;
        Logger.Log($"Customer registered: {Email}");
    }
}
