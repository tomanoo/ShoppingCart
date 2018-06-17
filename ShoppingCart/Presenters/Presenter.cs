using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.Views.AddProductView;

namespace ShoppingCart
{
    class Presenter
    {
        private View view;
        private Model model;
        private Productos products = new Productos();
        private Cart cart = new Cart();
        
        public Presenter(View view, Model model, Productos products, Cart cart)//, AddProducts addProducts)
        {
            this.view = view;
            this.model = model;
            this.products = products;
            this.cart = cart;
            //this.addProducts = addProducts;
            // z 2/3 klasy, bazowa i abstrakcyjna, potem 2 ktore dziedziczaca, stworzyc kolekcje, powrzucamy tam elementy klasy pochodnej i potraktujemy metoda z klasy abstrakcyjnej
            view.AddProduct += View_AddProduct;
            view.ClearCart += View_ClearCart;
            view.DeleteProduct += View_DeleteProduct;
            view.loadProducts();
            //addProducts.AddNewProduct += AddProducts_AddNewProduct;
            view.AddProductToProducts += View_AddProductToProducts;
            view.UpdateCost += View_UpdateCost;
            view.DeleteProductFromCart += View_DeleteProductFromCart;
            view.AddProductToCart += View_AddProductToCart;
            LoadProductList();
        }

        private void View_AddProductToCart(int obj)
        {
            cart.AddProductToCart(products.ReturnProduct(obj));
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
        }

        private double View_UpdateCost(double arg)
        {
            return model.Cost += arg;
        }

        private void View_AddProductToProducts(Product obj)
        {
            model.Products.Add(obj);
            products.AddProductToProductos(obj);
        }

        private void View_ClearCart(object arg1, EventArgs arg2)
        {
            cart.ClearCart();
        }

        private void View_DeleteProduct(object arg1, EventArgs arg2)
        {
            
        }

        private void View_AddProduct(object arg1, EventArgs arg2)
        {
            
        }

     //   private void AddProducts_AddNewProduct(Product obj)
     //   {
     //       model.Products.Add(obj);
     //   }
    }
}
