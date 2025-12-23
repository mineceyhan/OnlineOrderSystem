using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Services;

public class PaymentService
{
    public bool ProcessPayment(decimal amount)
    {
        Logger.Log($"Processing payment: {amount}₺");
        return true;
    }
}
