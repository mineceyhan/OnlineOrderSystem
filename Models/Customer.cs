using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Models;

public class Customer
{
    public int Id { get; }
    public string Email { get; }
    public int Phone { get; }
    public string Address { get; }
    public Customer(int id, string email,int Phone , string address )
    {
        Id = id;
        Email = email;
        Address = address;
        Logger.Log($"Customer registered: {Email}");
    }
}
