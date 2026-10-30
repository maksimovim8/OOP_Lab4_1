namespace Lab4_1
{
    class Product
    {
        public string Name { get; }
        public float Price { get; }
        public int Quantity { get; private set; }

        public Product(string pdct_name, float pdct_price, int pdct_quantity) 
        {
            Name = pdct_name;
            Price = pdct_price;
            Quantity = pdct_quantity;
        }

        // Зменшує кількість товару на 1, якщо він є в наявності
        public void Sell_Product()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }


        }
    }
}
