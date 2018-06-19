using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Views.AddProductView;
using System.Windows.Forms;

namespace ShoppingCart
{
    class Presenter
    {
        private View view;
        private Productos products;// = new Productos();
        private Cart cart;// = new Cart();
        
        public Presenter(View view, Productos products, Cart cart)//, AddProducts addProducts)
        {
            this.view = view;
            this.products = products;
            this.cart = cart;
            //this.addProducts = addProducts;
            // z 2/3 klasy, bazowa i abstrakcyjna, potem 2 ktore dziedziczaca, stworzyc kolekcje, powrzucamy tam elementy klasy pochodnej i potraktujemy metoda z klasy abstrakcyjnej
            view.ClearCart += View_ClearCart;
            //view.loadProducts();
            //addProducts.AddNewProduct += AddProducts_AddNewProduct;
            view.AddProductToProducts += View_AddProductToProducts;
            view.UpdateCost += View_UpdateCost;
            view.DeleteProductFromCart += View_DeleteProductFromCart;
            view.AddProductToCart += View_AddProductToCart;
            view.ReturnPrice += View_ReturnPrice;
            view.ReturnCartProductPrice += View_ReturnCartProductPrice;
            view.ReturnQuantity += View_ReturnQuantity;
            LoadProductList();
        }

        private double View_ReturnCartProductPrice(int arg)
        {
            return cart.ReturnProductFromCart(arg).Price;
        }

        private int View_ReturnQuantity(int arg)
        {
            return products.ReturnProduct(arg).Quantity;
        }

        private double View_ReturnPrice(int arg)
        {
            return products.ReturnProduct(arg).Price;
        }

        private void View_AddProductToCart(int obj)
        {
            // cart.AddProductToCart(products.ReturnProduct(obj));
            cart.AddProductToCart(products.ReturnProductos()[obj]);
            --products.ReturnProduct(obj).Quantity;
            //MessageBox.Show(cart.ReturnNameOfProductsInCart().Count.ToString());
            LoadCartList();
        }

        private void LoadProductList()
        {
            view.NamesOfProductsInProductList = products.ReturnNamesOfProducts();
        }
        private void LoadCartList()
        {
            view.NamesOfProductsInCartList = cart.ReturnNameOfProductsInCart();
        }

        private void View_DeleteProductFromCart(int obj)
        {
            for (int i=0; i<products.ReturnProductos().Count; i++)
            {
                if (products.ReturnProduct(i).Name == cart.ReturnProductFromCart(obj).Name)
                {
                    ++products.ReturnProduct(i).Quantity;
                    break;
                }
            }
            cart.DeleteProductFromCart(obj);
            LoadCartList();
        }

        private double View_UpdateCost(double arg)
        {
            return cart.Cost += arg;
        }

        private void View_AddProductToProducts(Product obj)
        {
            products.AddProductToProductos(obj);
        }

        private void View_ClearCart(object arg1, EventArgs arg2)
        {
            cart.ClearCart();
        }
    }
}
