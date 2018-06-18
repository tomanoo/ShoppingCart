using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShoppingCart.Views.AddProductView;
using Newtonsoft.Json;
using System.IO;

namespace ShoppingCart
{
    public partial class View : Form, IView
    {
        
       // public List<Product> cart = new List<Product>();
       // public List<Product> products = new List<Product>();
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
        public event Action<Product> AddProductToProductos;
        public event Action<int> DeleteProductFromCart;
        public event Action<int> AddProductToCart;
        public event Func<int, int> ReturnQuantity;
        public event Func<int, double> ReturnPrice;
        public View()
        {
            InitializeComponent();
            //using (StreamReader r = new StreamReader("./Products.json"))
            //{
            //    string json = r.ReadToEnd();
            //    products = JsonConvert.DeserializeObject<List<Product>>(json);
            //}
            //foreach (Product p in products)
            //{
            //    ProductList.Items.Add(p.Name);
            //}
      //      loadProducts();
        }

        public void loadProducts()
        {
         /*   using (StreamReader r = new StreamReader("./Products.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            ProductList.Items.Clear();
            foreach (Product p in products)
            {
                ProductList.Items.Add(p.Name);
            }*/
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(lblQuantity.Text) > 0)
            {
                //AddProduct(sender, e);
                // UpdateCost(ReturnPrice(ProductList.SelectedIndex));

                //cart.Add(products[ProductList.SelectedIndex]);
                //--products[ProductList.SelectedIndex].Quantity;
                // lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
                //  CartList.Items.Add(ProductList.SelectedItem.ToString());
                // NamesOfProductsInCartList.Add(ProductList.SelectedItem.ToString());
                //cost += products[ProductList.SelectedIndex].Price;
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
                //DeleteProduct(sender, e);
                //cost -= cart[CartList.SelectedIndex].Price;
                //++products[ProductList.SelectedIndex].Quantity;
                //lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
                // cart.RemoveAt(CartList.SelectedIndex);
                lblCost.Text = UpdateCost(ReturnPrice(CartList.SelectedIndex)*(-1)).ToString();
                CartList.Items.RemoveAt(CartList.SelectedIndex);
                DeleteProductFromCart(CartList.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearCart(sender, e);
                lblCost.Text = "";
               // cart.Clear();
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
         //   AddProductToProductos(obj);
           // this.loadProducts();
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lblPrice.Text = products[ProductList.SelectedIndex].Price.ToString();
                lblPrice.Text = ReturnPrice(ProductList.SelectedIndex).ToString();
                lblQuantity.Text =  ReturnQuantity(ProductList.SelectedIndex).ToString();
               //lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        
        
    }
}
