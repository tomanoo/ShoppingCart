namespace ShoppingCart
{
    public class Product
    {
        public Product() { }

        public Product(string Name, double Price, int Quantity)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
