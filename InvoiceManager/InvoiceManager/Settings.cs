using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager
{
    public partial class Settings : Form
    {
        DataBase dataBase = new DataBase();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadCompanyInfo();
        }

        private void LoadCompanyInfo()
        {
            string queryString = "SELECT name, zip_code, city, street, building_number, phone, account, bank, bank_city FROM сompanyInfo";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtSurnameClient.Text = reader["name"].ToString();
                textBox1.Text = reader["zip_code"].ToString();
                textBox2.Text = reader["city"].ToString();
                textBox3.Text = reader["street"].ToString();
                textBox4.Text = reader["building_number"].ToString();
                textBox5.Text = reader["phone"].ToString();
                textBox6.Text = reader["account"].ToString();
                textBox7.Text = reader["bank"].ToString();
                textBox8.Text = reader["bank_city"].ToString();
            }

            reader.Close();
            dataBase.closeConnection();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE сompanyInfo " +
                                 "SET name = @name, zip_code = @zip_code, city = @city, street = @street, building_number = @building_number, phone = @phone, account = @account, bank = @bank, bank_city = @bank_city " +
                                 "WHERE id = @id;";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            command.Parameters.AddWithValue("@name", txtSurnameClient.Text);
            command.Parameters.AddWithValue("@zip_code", textBox1.Text);
            command.Parameters.AddWithValue("@city", textBox2.Text);
            command.Parameters.AddWithValue("@street", textBox3.Text);
            command.Parameters.AddWithValue("@building_number", textBox4.Text);
            command.Parameters.AddWithValue("@phone", textBox5.Text);
            command.Parameters.AddWithValue("@account", textBox6.Text);
            command.Parameters.AddWithValue("@bank", textBox7.Text);
            command.Parameters.AddWithValue("@bank_city", textBox8.Text);
            command.Parameters.AddWithValue("@id", 1);

            dataBase.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            dataBase.closeConnection();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Дані оновлено успішно!");
            }
            else
            {
                MessageBox.Show("Помилка: Запис не знайдено або не оновлено.");
            }
        }
    }
}
