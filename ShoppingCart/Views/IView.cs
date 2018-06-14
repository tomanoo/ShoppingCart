using System;

namespace ShoppingCart
{
    public interface IView
    {
        event Action<object, EventArgs> AddProduct;
        event Action<object, EventArgs> ClearCart;
        event Action<object, EventArgs> DeleteProduct;
    }
}