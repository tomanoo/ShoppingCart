using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Views.AddProductView;

namespace ShoppingCart.Models
{
    public class Model
    {
        //Product product;
        public List<Product> Products { get; set; }
        public List<Product> Cart { get; set; }

        
        public double Cost { get; set; }

        public void AddProductToProducts(Product product)
        {
            Products.Add(product);
        }
        public void AddProductToCart(Product product)
        {
            Cart.Add(product);
        }
    }
}
