using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShoppingCart.Views.AddProductView;

namespace ShoppingCart
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            View view = new View();
            Productos products = new Productos();
            Cart cart = new Cart();
            AddProducts addProducts = new AddProducts(view);
            Presenter presenter = new Presenter(view, products, cart);//Presenter(view, model);//Presenter(view, model, addProducts);
            Application.Run(view);
        }
    }
}
