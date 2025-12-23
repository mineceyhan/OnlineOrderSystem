using OnlineOrderSystem.Models;
using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Services;

public class PricingService
{
    public decimal CalculateTotal(Order order)
    {
        //deneme
        Logger.Log("Calculating total price, denem, mine deneme  ");
        Logger.Log("PRICE ");
        return order.Items.Sum(i => i.GetTotal());
    }
}
