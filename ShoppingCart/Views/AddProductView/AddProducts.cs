using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShoppingCart.Views;
using ShoppingCart.Models;
using Newtonsoft.Json;
using System.IO;

namespace ShoppingCart.Views.AddProductView
{
    public partial class AddProducts : Form
    {
        public event Action<Product> AddNewProduct;

        
        Model model = new Model();
        View view = new View();
        public AddProducts(View view)
        {
            InitializeComponent();
            this.view = view;
        }
        

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product(NameBox.Text, Double.Parse(PriceBox.Text), Int32.Parse(QuantityBox.Text));
                var json = JsonConvert.SerializeObject(product, Formatting.Indented);
                var jsonData = File.ReadAllText("./Products.json");
                var productList = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();
                productList.Add(product);
                jsonData = JsonConvert.SerializeObject(productList);
                File.WriteAllText("./Products.json", jsonData);
                AddNewProduct(product);
                //model.Products.Add(product);
                this.Close();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
