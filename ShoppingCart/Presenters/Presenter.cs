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
        //private AddProducts addProducts;
        
        public Presenter(View view, Model model)//, AddProducts addProducts)
        {
            this.view = view;
            this.model = model;
            //this.addProducts = addProducts;
            // z 2/3 klasy, bazowa i abstrakcyjna, potem 2 ktore dziedziczaca, stworzyc kolekcje, powrzucamy tam elementy klasy pochodnej i potraktujemy metoda z klasy abstrakcyjnej
            view.AddProduct += View_AddProduct;
            view.ClearCart += View_ClearCart;
            view.DeleteProduct += View_DeleteProduct;
            //addProducts.AddNewProduct += AddProducts_AddNewProduct;
            view.AddProductToProducts += View_AddProductToProducts;
            view.UpdateCost += View_UpdateCost;
        }

        private double View_UpdateCost(double arg)
        {
            return model.Cost += arg;
        }

        private void View_AddProductToProducts(Product obj)
        {
            model.Products.Add(obj);
        }

        private void View_ClearCart(object arg1, EventArgs arg2)
        {
           // model.
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
