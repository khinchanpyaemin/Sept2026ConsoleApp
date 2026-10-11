
using System;

namespace Sep2026ShoppingCartConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CartService cartService = new CartService(); 

            while (true)
            {
                Console.WriteLine("\n===== Shopping Cart Management =====");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Show All Items");
                Console.WriteLine("4. Proceed to Checkout");
                Console.WriteLine("5. Exit");

                Console.Write("Please select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter item price: ");
                        decimal price  = decimal.Parse(Console.ReadLine());
                        
                        Console.Write("Enter quantity: ");

                        int quantity = int.Parse(Console.ReadLine());
                        cartService.AddItem(name, price, quantity);   
                        break;

                    case "2":
                        Console.Write("Enter item ID to remove: ");

                        if (int.TryParse(
                            Console.ReadLine(), out int id))
                        {
                            cartService.RemoveItem(id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid item ID.");
                        }
                        break;

                    case "3":
                        cartService.ShowItems();
                        break;

                    case "4":
                        cartService.Checkout();
                        break;

                    case "5":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
