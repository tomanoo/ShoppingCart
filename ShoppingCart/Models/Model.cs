using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Views.AddProductView;
using ShoppingCart;

namespace ShoppingCart.Models
{
    public class Model
    {
        //Product product;
        public List<Product> Products { get; set; }
        public List<Product> Cartos { get; set; }
        
        
        

        
        public double Cost { get; set; }
        public void AddProductToProducts(Product product)
        {
            Products.Add(product);
        }
        public void AddProductToCart(Product product)
        {
            Cartos.Add(product);
        }
    }
}
