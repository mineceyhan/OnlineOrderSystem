using OnlineOrderSystem.Models;
using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Services;

public class NotificationService
{
    public void SendOrderConfirmation(Customer customer)
    {
        Logger.Log($"Email sent to {customer.Email}");
    }
}
