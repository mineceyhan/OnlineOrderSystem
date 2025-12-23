using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Models;

public class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
        Logger.Log($"OrderItem added: {product.Name} x{quantity}");
    }

    public decimal GetTotal()
        => Product.Price * Quantity;
}
