using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;


namespace pr19
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnect = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString);
            sqlConnect.Open();
            
            /*if (sqlConnect.State == ConnectionState.Open)
            {
                MessageBox.Show("Всё работает!");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int opt_s = int.Parse(textBox2.Text);
            int rozn_s = int.Parse(textBox3.Text);
            int counter = int.Parse(textBox4.Text);

            Nomenclature product = new Nomenclature(name, opt_s, rozn_s, counter);


            SqlCommand newProduct = new SqlCommand($"INSERT INTO Products (Name, WPrice, RPrice, Stock) VALUES (@Name, @WPrice, @RPrice, @Stock)", sqlConnect);
            newProduct.Parameters.AddWithValue("Name", product.name);
            newProduct.Parameters.AddWithValue("WPrice", product.opt_sum);
            newProduct.Parameters.AddWithValue("RPrice", product.rozn_sum);
            newProduct.Parameters.AddWithValue("Stock", product.count);
            newProduct.ExecuteNonQuery();

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
        public void DataUpdate()
        {
            string letter = textBox5.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                $"SELECT * FROM Products WHERE Name LIKE N'%{letter}%'", sqlConnect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox6.Text);
                SqlCommand adapter = new SqlCommand(
                $"DELETE FROM Products WHERE id LIKE '{id}'", sqlConnect);
                adapter.ExecuteNonQuery();
            }
            catch(FormatException)
            {

            }
            DataUpdate();
        }
    }
}
