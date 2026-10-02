using Assignment9.Section1;
using Assignment9.Section2;

namespace Assignment9
{
    internal class Program
    {
        static void Section1()
        {
            Console.WriteLine("------ Section 1: Library Engine ------\n");

            List<Book> books = new List<Book>()
            {
                new Book("978-3-16-148410-0", "The Great Gatsby", new string[] { "F. Scott Fitzgerald, William Faulkner" }, new DateTime(1925, 4, 10), 10.99m),
                new Book("978-0-7432-7356-5", "To Kill a Mockingbird", new string[] { "Harper Lee , John Steinbeck" }, new DateTime(1960, 7, 11), 7.99m)
            };


            Console.WriteLine("Titles:");
            LibraryEngine.ProcessBooks_UserDefined(books, BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, BookFunctions.GetTitle);
            Console.WriteLine();

            Console.WriteLine("Authors:");
            LibraryEngine.ProcessBooks_UserDefined(books, BookFunctions.GetAuthors);
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, BookFunctions.GetAuthors);
            Console.WriteLine();

            Console.WriteLine("ISBNs:");
            LibraryEngine.ProcessBooks_UserDefined(books, delegate (Book B) { return B.ISBN; });
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, delegate (Book B) { return B.ISBN; });
            Console.WriteLine();

            Console.WriteLine("Publication Dates:");
            LibraryEngine.ProcessBooks_BuiltIn<DateTime>(books, book => book.PublicationDate);
            Console.WriteLine();
        }

        public delegate decimal PriceCalculator(Order order);

        public static void Section2()
        {
            Console.WriteLine("------ Section 2: Order Processing ------\n");


            Order order = new Order {Id = 1,CustomerName = "Abdallah",Price = 100,Quantity = 5};


            // Part 1 - User-Defined Delegate

            Console.WriteLine("===== Part 1 =====");

            decimal total1 =CalculateOrderPrice(order, CalculateTotal);
            Console.WriteLine($"Normal Total: {total1}");


            decimal total2 =CalculateOrderPrice(order, CalculateTotalWithDiscount);
            Console.WriteLine($"Discount Total: {total2}");


            // Part 2 - Func<Order, decimal>

            Console.WriteLine("\n===== Part 2 =====");

            decimal normalPrice = CalculateOrderPriceFunc(order,x => x.Price * x.Quantity);
            Console.WriteLine($"Normal Price: {normalPrice}");


            decimal discountPrice =  CalculateOrderPriceFunc(order,x => x.Price * x.Quantity * 0.90m);
            Console.WriteLine($"Discount Price: {discountPrice}");


            // Part 3 - Predicate<Order>

            Console.WriteLine("\n===== Part 3 =====");

            bool validQuantity = ValidateOrder(order,order => order.Quantity > 0);
            Console.WriteLine($"Valid Quantity: {validQuantity}");


            bool validPrice = ValidateOrder(order,order => order.Price > 0);
            Console.WriteLine($"Valid Price: {validPrice}");


            bool validCustomer = ValidateOrder(order,order => !string.IsNullOrEmpty(order.CustomerName));
            Console.WriteLine($"Valid Customer: {validCustomer}");


            // Part 4 - Action<Order>

            Console.WriteLine("\n===== Part 4 =====");


            Action<Order> printOrder = order =>
            {
                Console.WriteLine($"Order ID: {order.Id}");
                Console.WriteLine($"Customer: {order.CustomerName}");
                Console.WriteLine($"Price: {order.Price}");
                Console.WriteLine($"Quantity: {order.Quantity}");
            };


            Action<Order> sendConfirmation = order =>
            {
                Console.WriteLine($"Confirmation sent to {order.CustomerName}");
            };


            Action<Order> auditOrder = order =>
            {
                Console.WriteLine($"Audit: Order {order.Id} processed.");
            };

            ProcessOrder(order, printOrder);

            ProcessOrder(order, sendConfirmation);

            ProcessOrder(order, auditOrder);

            // Part 5 + Part 6 - Events

            Console.WriteLine("\n===== Part 5 & 6 =====");

            OrderService orderService = new OrderService();

            void Handler1(Order order)
            {
                Console.WriteLine($"Handler 1: Order {order.Id} completed.");
            }

            void Handler2(Order order)
            {
                Console.WriteLine("Handler 2: Notification sent.");
            }

            void Handler3(Order order)
            {
                Console.WriteLine("Handler 3: Audit completed.");
            }

            // Subscribe

            orderService.OrderProcessed += Handler1;

            orderService.OrderProcessed += Handler2;

            orderService.OrderProcessed += Handler3;


            // Process Order

            orderService.ProcessOrder(order);


            // Unsubscribe Handler1

            Console.WriteLine("\n===== After Unsubscribe =====");


            orderService.OrderProcessed -= Handler1;


            orderService.ProcessOrder(order);
        }

        static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }

        static decimal CalculateTotalWithDiscount(Order order)
        {
            decimal total =order.Price * order.Quantity;

            return total * 0.90m;
        }

        static decimal CalculateOrderPrice(Order order,PriceCalculator calculator)
        {
            return calculator(order);
        }

        static decimal CalculateOrderPriceFunc(Order order,Func<Order, decimal> calculator)
        {
            return calculator(order);
        }


        static bool ValidateOrder(Order order,Predicate<Order> validationRule)
        {
            return validationRule(order);
        }

        static void ProcessOrder(Order order,Action<Order> action)
        {
            action(order);
        }

        static void Main(string[] args)
        {
            // Section1();
            Section2();
        }
    }
}