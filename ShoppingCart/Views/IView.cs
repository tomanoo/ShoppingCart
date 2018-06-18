using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public interface IView
    {
        List<string> NamesOfProductsInCartList { set; }
        event Action<object, EventArgs> ClearCart;
    }
}