using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace ShoppingCart
{
    class Productos
    {
        private List<Product> productos = new List<Product>();
        private List<string> namesOfProducts = new List<string>();

        public Productos()
        {
            using (StreamReader r = new StreamReader("./Products.json"))
            {
                string json = r.ReadToEnd();
                productos = JsonConvert.DeserializeObject<List<Product>>(json);
            }

        }

        public List<Product> ReturnProductos()
        {
            return productos;
        }

        public void AddProductToProductos(Product product)
        {
            productos.Add(product);
        }

        public Product ReturnProduct(int i)
        {
            return productos[i];
        }
        public List<string> ReturnNamesOfProducts()
        {
            foreach(Product p in productos)
            {
                namesOfProducts.Add(p.Name);
            }
            return namesOfProducts;
        }
    }
}
