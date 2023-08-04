using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Linq;
//XML Ser
using System.Xml.Serialization;
//SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JSON
using System.Text.Json;

namespace SerelationFroms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.dat";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                Product p1 = new Product();
                p1.Id = Convert.ToInt32(ProductId.Text);
                p1.Name = Productname.Text;
                p1.Price = Convert.ToInt32(ProductPrice.Text);
                formatter.Serialize(fileStream, p1);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BinarRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.dat";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                Product p1 = new Product();
                // we done explicit type casting from Object --> Product
                p1 = (Product)formatter.Deserialize(fileStream);
                ProductId.Text = p1.Id.ToString();
                Productname.Text = p1.Name;
                ProductPrice.Text = p1.Price.ToString();

                fileStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void xmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.xml";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product p1 = new Product();
                p1.Id = Convert.ToInt32(ProductId.Text);
                p1.Name = Productname.Text;
                p1.Price = Convert.ToInt32(ProductPrice.Text);
                xmlSerializer.Serialize(fileStream, p1);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void XmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.xml";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer= new XmlSerializer(typeof(Product));    
                Product p1 = new Product();
                // we done explicit type casting from Object --> Product
                p1 = (Product)xmlSerializer.Deserialize(fileStream);
                ProductId.Text = p1.Id.ToString();
                Productname.Text = p1.Name;
                ProductPrice.Text = p1.Price.ToString();

                fileStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SoapWrite_Click(object sender, EventArgs e)
        {

            try
            {
                string path = @"D:\DP4\product.soap";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                SoapFormatter soapFormatter = new SoapFormatter();
                Product p1 = new Product();
                p1.Id = Convert.ToInt32(ProductId.Text);
                p1.Name = Productname.Text;
                p1.Price = Convert.ToInt32(ProductPrice.Text);
                soapFormatter.Serialize(fileStream, p1);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.soap";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
               SoapFormatter soapFormatter = new SoapFormatter();
                Product p1 = new Product();
                // we done explicit type casting from Object --> Product
                p1 = (Product)soapFormatter.Deserialize(fileStream);
                ProductId.Text = p1.Id.ToString();
                Productname.Text = p1.Name;
                ProductPrice.Text = p1.Price.ToString();

                fileStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void JsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.json";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                Product p1 = new Product();
                p1.Id = Convert.ToInt32(ProductId.Text);
                p1.Name = Productname.Text;
                p1.Price = Convert.ToInt32(ProductPrice.Text);
                JsonSerializer.Serialize<Product>(fileStream, p1);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DP4\product.json";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                Product p1 = new Product();
                // we done explicit type casting from Object --> Product
                p1 = JsonSerializer.Deserialize<Product>(fileStream);
                ProductId.Text = p1.Id.ToString();
                Productname.Text = p1.Name;
                ProductPrice.Text = p1.Price.ToString();

                fileStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
