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
        
       // public List<Product> products = new List<Product>() { new Product("Leather Boots", 25, 13), new Product("Boots of Haste", 40000, 4) };
        public List<Product> cart = new List<Product>();
        public List<Product> products = new List<Product>();
        public event Action<object, EventArgs> AddProduct;
        public event Action<Product> AddProductToProducts;
        public event Func<double, double> UpdateCost;
        public event Action<object, EventArgs> ClearCart;
        public event Action<object, EventArgs> DeleteProduct;
        double cost = 0;
        public View()
        {
            InitializeComponent();
            using (StreamReader r = new StreamReader("./Products.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            foreach (Product p in products)
            {
                ProductList.Items.Add(p.Name);
            }
        }

        public void loadProducts()
        {
            using (StreamReader r = new StreamReader("./Products.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            ProductList.Items.Clear();
            foreach (Product p in products)
            {
                ProductList.Items.Add(p.Name);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (products[ProductList.SelectedIndex].Quantity > 0)
            {
                //AddProduct(sender, e);
                //UpdateCost(products[ProductList.SelectedIndex].Price);
                cart.Add(products[ProductList.SelectedIndex]);
                --products[ProductList.SelectedIndex].Quantity;
                lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
                CartList.Items.Add(ProductList.SelectedItem.ToString());
                //cost += products[ProductList.SelectedIndex].Price;
                lblCost.Text = UpdateCost(products[ProductList.SelectedIndex].Price).ToString();
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
                ++products[ProductList.SelectedIndex].Quantity;
                lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
                cart.RemoveAt(CartList.SelectedIndex);
                CartList.Items.RemoveAt(CartList.SelectedIndex);
                lblCost.Text = UpdateCost(products[ProductList.SelectedIndex].Price*(-1)).ToString();
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
                cost = 0;
                lblCost.Text = "";
                cart.Clear();
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
            this.loadProducts();
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblPrice.Text = products[ProductList.SelectedIndex].Price.ToString();
                lblQuantity.Text = products[ProductList.SelectedIndex].Quantity.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        
    }
}
