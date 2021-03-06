﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace ShoppingCart.Views.AddProductView
{
    public partial class AddProducts : Form
    {
        public event Action<Product> AddNewProduct;

        
        View view = new View();
        public AddProducts(View view)
        {
            InitializeComponent();
            this.view = view;
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
                Product product = new Product(NameBox.Text, Double.Parse(PriceBox.Text), Int32.Parse(QuantityBox.Text));
                var json = JsonConvert.SerializeObject(product, Formatting.Indented);
                var jsonData = File.ReadAllText("./Products.json");
                var productList = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();
                productList.Add(product);
                jsonData = JsonConvert.SerializeObject(productList);
                File.WriteAllText("./Products.json", jsonData);
                AddNewProduct(product);
                this.Close();
            
        }
    }
}
