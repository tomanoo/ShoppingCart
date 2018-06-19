using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Cart
    {
        private List<Product> cart = new List<Product>();
        private List<string> cartProductNames = new List<string>();

        public double Cost { get; set; }

        public Cart() { }

        public List<Product> ReturnCart()
        {
            return cart;
        }

        public void AddProductToCart(Product product)
        {
            cart.Add(product);
        }

        public Product ReturnProductFromCart(int i)
        {
            return cart[i];
        }

        public void ClearCart()
        {
            cart.Clear();
        }

        public void DeleteProductFromCart(int i)
        {
            cart.RemoveAt(i);
        }

        public List<string> ReturnNameOfProductsInCart()
        {
            cartProductNames.Clear();
            foreach (Product p in cart)
            {
                cartProductNames.Add(p.Name);
            }
            return cartProductNames;
        }
        
    }
}
