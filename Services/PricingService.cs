using OnlineOrderSystem.Models;
using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Services;

public class PricingService
{
    public decimal CalculateTotal(Order order)
    {
        Logger.Log("Calculating total price");
        return order.Items.Sum(i => i.GetTotal());
    }
}
