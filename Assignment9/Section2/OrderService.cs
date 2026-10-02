using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Section2
{
    public class OrderService
    {
        public event Action<Order> OrderProcessed;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing Order {order.Id}...");

            Console.WriteLine("Order has been processed.");

            OrderProcessed?.Invoke(order);
        }
    }
}
