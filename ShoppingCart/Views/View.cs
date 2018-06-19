using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShoppingCart.Views.AddProductView;

namespace ShoppingCart
{
    public partial class View : Form, IView
    {
        public List<string> NamesOfProductsInProductList
        {
            set
            {
                ProductList.Items.Clear();
                List<string> namesOfProductsInProductList = new List<string>(value);
                foreach (string n in namesOfProductsInProductList)
                {
                    ProductList.Items.Add(n);
                }
            }
        }
        public List<string> NamesOfProductsInCartList
        {
            set
            {
                CartList.Items.Clear();
                List<string> namesOfProductsInCartList = new List<string>(value);
                foreach(string n in namesOfProductsInCartList)
                {
                    CartList.Items.Add(n);
                }
            }
        }
        public event Action<Product> AddProductToProducts;
        public event Func<double, double> UpdateCost;
        public event Action<object, EventArgs> ClearCart;
        public event Action<int> DeleteProductFromCart;
        public event Action<int> AddProductToCart;
        public event Func<int, int> ReturnQuantity;
        public event Func<int, double> ReturnPrice;
        public event Func<int, double> ReturnCartProductPrice;
        public View()
        {
            InitializeComponent();
        }

        public void loadProducts()
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(lblQuantity.Text) > 0)
            {
                lblQuantity.Text = (ReturnQuantity(ProductList.SelectedIndex) - 1).ToString();
                lblCost.Text = UpdateCost(ReturnPrice(ProductList.SelectedIndex)).ToString();
                AddProductToCart(ProductList.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Product no longer available!");
            }
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                lblCost.Text = UpdateCost(ReturnCartProductPrice(CartList.SelectedIndex)*(-1)).ToString();
                if (lblCost.Text == "0")
                    lblCost.Text = "";
                for(int i = 0; i < ProductList.Items.Count; i++)
                {
                    if (CartList.Items[CartList.SelectedIndex].Equals(ProductList.Items[i]))
                    {
                        lblQuantity.Text = (ReturnQuantity(i) + 1).ToString();
                        break;
                    }
                }
                DeleteProductFromCart(CartList.SelectedIndex);
                CartList.Items.RemoveAt(CartList.SelectedIndex);
            }
            catch (Exception ex)
            {
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearCart(sender, e);
                lblCost.Text = "";
                lblQuantity.Text = (ReturnQuantity(ProductList.SelectedIndex)).ToString();
                CartList.Items.Clear();

            }
            catch (Exception ex)
            {

            }
        }

        public void AddProductToList(string x)
        {
            ProductList.Items.Add(x);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProducts AddProducts = new AddProducts(this);
            AddProducts.AddNewProduct += AddProducts_AddNewProduct;
            AddProducts.Show();
        }
        

        private void AddProducts_AddNewProduct(Product obj)
        {
            ProductList.Items.Add(obj.Name);
            AddProductToProducts(obj);
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblPrice.Text = ReturnPrice(ProductList.SelectedIndex).ToString();
                lblQuantity.Text =  ReturnQuantity(ProductList.SelectedIndex).ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
