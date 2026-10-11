namespace Sep2026ShoppingCartConsoleApp;

public class CartService
{
       
        public static List<CartItemDto> Cart = new List<CartItemDto>();

        public void AddItem(string name, decimal price, int quantity)
        {
            int maxId = Cart.Count == 0 ? 0 : Cart.Max(x => x.Id);

            CartItemDto item = new CartItemDto
            {
                Id = maxId + 1,
                Name = name,
                Price = price,
                Quantity = quantity
            };

            Cart.Add(item);
            Console.WriteLine("Item added successfully.");
        }

        public void RemoveItem(int id)
        {
            CartItemDto item = Cart.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Cart.Remove(item);
            Console.WriteLine("Item removed successfully.");
        }

        public void ShowItems()
        {
            if (Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            foreach (var item in Cart)
            {
                decimal subtotal = item.Price * item.Quantity;

                Console.WriteLine(
                    $"Id: {item.Id} | Name: {item.Name} | " +
                    $"Price: {item.Price} | Quantity: {item.Quantity} | " +
                    $"Subtotal: {subtotal}");
            }

            Console.WriteLine($"Total: {GetTotal()}");
        }

        public decimal GetTotal()
        {
            return Cart.Sum(x => x.Price * x.Quantity);
        }

        public void Checkout()
        {
            if (Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("\n===== Checkout =====");
            ShowItems();

            Console.Write("Confirm purchase? (y/n): ");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.WriteLine($"Purchase successful! Total: {GetTotal()}");
                Cart.Clear();
            }
            else
            {
                Console.WriteLine("Checkout cancelled.");
            }
        }
}

