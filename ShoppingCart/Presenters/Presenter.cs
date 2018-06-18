using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.Views.AddProductView;
using System.Windows.Forms;

namespace ShoppingCart
{
    class Presenter
    {
        private View view;
        private Model model;
        private Productos products;// = new Productos();
        private Cart cart;// = new Cart();
        
        public Presenter(View view, Model model, Productos products, Cart cart)//, AddProducts addProducts)
        {
            this.view = view;
            this.model = model;
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
            view.ReturnQuantity += View_ReturnQuantity;
            LoadProductList();
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
            MessageBox.Show(products.ReturnProductos().Capacity.ToString());
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
            cart.DeleteProductFromCart(obj);
            LoadCartList();
        }

        private double View_UpdateCost(double arg)
        {
            return model.Cost += arg;
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
