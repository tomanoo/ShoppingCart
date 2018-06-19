using System;

namespace ShoppingCart
{
    class Presenter
    {
        private View view;
        private Productos products;
        private Cart cart;
        
        public Presenter(View view, Productos products, Cart cart)
        {
            this.view = view;
            this.products = products;
            this.cart = cart;
            view.ClearCart += View_ClearCart;
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
            cart.AddProductToCart(products.ReturnProductos()[obj]);
            --products.ReturnProduct(obj).Quantity;
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
            for (int i=0; i<products.ReturnProductos().Count; i++)
            {
                for (int j=0; j<cart.ReturnCart().Count; j++)
                {
                    if (cart.ReturnProductFromCart(j).Name == products.ReturnProduct(i).Name)
                    {
                        ++products.ReturnProduct(i).Quantity;
                    }
                }
            }
            cart.Cost = 0;
            cart.ClearCart();
        }
    }
}
