### Questions


Q1

PriceCalculator is a custom delegate created by the programmer.
Func<Order, decimal> is a built-in delegate provided by C#.
Both can take an Order and return a decimal.

Q2

Action<Order> takes an Order and does not return a value.
Func<Order, decimal> takes an Order and returns a decimal value.

Q3

Predicate<T> returns bool because it is used to check a condition.
The result is either true or false.

Q4

A delegate is used to reference and call a method.
An event is used to notify other parts of the program when something happens.

Q5

External code cannot normally invoke an event because the class that owns the event should control when the event is raised.
External code can only subscribe or unsubscribe from the event.

Q6

When multiple handlers subscribe to the same event, all of them are called when the event is raised.
This is called multicast behavior.

Q7

OrderProcessed is the event.
+= means subscribing to the event.
HandleOrderProcessed is the method that will be called when the event occurs.

So, the code means: subscribe HandleOrderProcessed to the OrderProcessed event.

Q8

Action<Order> is a delegate that represents a method that takes an Order and returns nothing.

event Action<Order> is an event that uses this delegate to notify subscribers.
We use an event because it allows other code to subscribe or unsubscribe, while the class that owns the event controls when it is raised.
