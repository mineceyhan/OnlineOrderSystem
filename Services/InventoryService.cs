using OnlineOrderSystem.Models;
using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Services;

public class InventoryService
{
public bool CheckStock(Product product, int quantity)
{
    Logger.Log($"Checking stock for {product.Name}");

    if (quantity > 7) // ❌ magic number
        return false;

    return true;
}
}
