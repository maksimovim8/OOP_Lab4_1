
namespace Lab4_1
{
    class Program
    {
        static void Main()
        {
            //Додеп, він же генератор рандомних чисел
            Random rnd = new Random();

            //Список початкового запасу товарів
            List<Product> allProducts = new List<Product>();

            allProducts.Add(new Product("Bread", 200f, rnd.Next(10, 80)));
            allProducts.Add(new Product("Milk", 670f, rnd.Next(3, 20)));
            allProducts.Add(new Product("Potato", 60f, rnd.Next(34, 70)));
            allProducts.Add(new Product("Pepsi", 540f, rnd.Next(6, 60)));


            //Створення списку покупців
            Console.WriteLine("Enter quantity of customers:");

            List<Customer> customers = new List<Customer>();

            int customerCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < customerCount; i++)
            {
                customers.Add(new Customer(rnd.Next(1, 1001), rnd.Next(1000, 10001)));
            }


            //Симуляція покупок. нище створення змінної профіт магазину
            float profit = 0;

            //Береться кожен покупець
            foreach (Customer customer in customers)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Customer Id: " + customer.Id);
                Console.WriteLine("Starting cash " + customer.Cash + " UAH, ");
                Console.WriteLine();
                // Цикл покупок поточного покупця
                while (true)
                {
                    //На початку кожного проходу створюється список
                    List<Product> avaliableProducts = new List<Product>();

                    //Пошук і додавання товарів, які покупець може придбати
                    foreach (Product product in allProducts)
                    {
                        //Перевірка покупця на можливість покупки, якщо true - додається товар
                        if (customer.CanAfford(product))
                        {
                            avaliableProducts.Add(product);
                        }
                    }

                    // Якщо нічого не добавилось, то виходимо з циклу
                    if (avaliableProducts.Count == 0)
                    {
                        break;
                    }


                    //Рандомний товар з доступних
                    int random_prod = rnd.Next(avaliableProducts.Count);
                    Product chosenProduct = avaliableProducts[random_prod];


                    // Якщо покупку проходить, то додаємо в прибуток магазину
                    if (customer.Buy(chosenProduct))
                    {
                        profit += chosenProduct.Price;
                        Console.WriteLine("Bought: " + chosenProduct.Name);
                        Console.WriteLine("Price: " + chosenProduct.Price);
                    }
                }
                //Результати покупця
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Item bought: " + customer.ItemsBought);
                Console.WriteLine("Money spent: " + customer.MoneySpent + " UAH");
                Console.WriteLine("Remaining cash: " + customer.Cash + " UAH");
            }


            //Визначення в кого найбільше покупок і Найбільше потрачено грошей
            Customer mostItem = customers[0];
            Customer mostSpent = customers[0];

            foreach (Customer customer in customers)
            {
                if (customer.ItemsBought > mostItem.ItemsBought)
                {
                    mostItem = customer;
                }


                if (customer.MoneySpent > mostSpent.MoneySpent)
                {
                    mostSpent = customer;
                }
            }


            //РЕЗУЛЬТАТИ
            Console.WriteLine("\n\n\n__________Results__________");
            Console.WriteLine("Store profit: " + profit+ " UAH");

            Console.WriteLine("\nMost items bought: Customer ID >" + mostItem.Id);
            Console.WriteLine("Items bought >" + mostItem.ItemsBought);

            Console.WriteLine("\nMost money spent: Customer ID >" + mostSpent.Id);
            Console.WriteLine("Money spent >" + mostSpent.MoneySpent);

        }
    }
}
