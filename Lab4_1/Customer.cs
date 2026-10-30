namespace Lab4_1
{
    class Customer
    {
        public int Id { get; }
        public float Cash { get; private set; }
        public int ItemsBought { get; private set; }
        public float MoneySpent { get; private set; }

        public Customer(int cstmr_id, float cstmr_cash) 
        {
            Id = cstmr_id;
            Cash = cstmr_cash;
            ItemsBought = 0;
            MoneySpent = 0;
        }


        //Перевіряє, чи вистачає покупцю грошей на товар і чи є товар у наявності взагалі
        //Повертає true, якщо обидві умови виконуються. Якщо одна з них не виконується - false
        public bool CanAfford(Product product)
        {
            if (Cash >= product.Price && product.Quantity > 0 )
            {
                return true;
            }
            else { return false; }
        }


        //Якщо товар доступний і покупцю вистачає грошей, списує ціну товару,
        //збільшує кількість придбаних товарів і витрачену суму,
        //зменшує залишок товару та повертає true.
        //Якщо покупка неможлива, то повертає false
        public bool Buy(Product product)
        {
            if (CanAfford(product))
            {
                Cash -= product.Price;
                ItemsBought++;
                MoneySpent += product.Price;
                product.Sell_Product();
                return true;
            }
            return false;

        }
    }
}
