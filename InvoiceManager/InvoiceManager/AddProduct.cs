using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InvoiceManager
{
    public partial class AddProduct : Form
    {
        DataBase dataBase = new DataBase();

        public AddProduct()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nameBread.Text = "";
            priceBread.Text = "";
            textBox1.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nameBread.Text == "" || textBox1.Text == "" || priceBread.Text == "")
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataBase.openConnection();

            string name = nameBread.Text;
            string unit_of_measurement = textBox1.Text;
            decimal price;

            if (decimal.TryParse(priceBread.Text, out price))
            {
                string decimalSTR = price.ToString().Replace(",", ".");
                string add = $"insert into product (product_name, price, unit_of_measurement) values ('{name}', '{decimalSTR}', '{unit_of_measurement}')";
                SqlCommand command = new SqlCommand(add, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Товар додано!", "Виконано!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Помилка! Ціна повинна бути в числовому форматі!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();
        }
    }
}
