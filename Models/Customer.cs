using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Models;

public class Customer
{
    public int Id { get; }
    public string Email { get; }
    public int Phone { get; }

    public Customer(int id, string email,int Phone )
    {
        Id = id;
        Email = email;
        Logger.Log($"Customer registered: {Email}");
    }
}
