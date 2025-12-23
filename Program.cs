using OnlineOrderSystem.Models;
using OnlineOrderSystem.Services;

class Program
{
    static void Main()
    {
        var customer = new Customer(1, "mine@example.com" , 5234);
        var product = new Product(101, "Laptop", 35000);

        var inventoryService = new InventoryService();
        var pricingService = new PricingService();
        var paymentService = new PaymentService();
        var shippingService = new ShippingService();
        var notificationService = new NotificationService();

        if (!inventoryService.CheckStock(product, 1))
            return;

        var order = new Order(customer);
        order.AddItem(new OrderItem(product, 1));

        var total = pricingService.CalculateTotal(order);

        if (!paymentService.ProcessPayment(total))
            return;

        shippingService.ShipOrder();
        notificationService.SendOrderConfirmation(customer);
    }
}
