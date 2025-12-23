using OnlineOrderSystem.Utils;

namespace OnlineOrderSystem.Models;

public class Order
{
    public Customer Customer { get; }
    public List<OrderItem> Items { get; } = new();

    public Order(Customer customer)
    {
        Customer = customer;
        Logger.Log("Order created");
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        Logger.Log("Item added to order");
    }

       public void SaveOrder()
    {
        Logger.Log("Order Save");
    }

    public void FinalizeOrder()
    {
        Logger.Log("Order finalized");
    }
}
