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
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBox_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            txtBox_login.MaxLength = 50;
            txtBox_password.MaxLength = 50;
            txtBox_login.Text = "admin";
            txtBox_password.Text = "admin";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (!dataBase.TestConnection())
            {
                return;
            }

            string loginManager = txtBox_login.Text;
            string passwordManager = txtBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_manager, login_manager, password_manager from manager where login_manager = '{loginManager}' and password_manager = '{passwordManager}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                app app = new app();
                this.Hide();
                app.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Невірний логін або пароль! Спробуйте ще раз.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtBox_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtBox_password.UseSystemPasswordChar = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ConnectionSettinds connectionSettings = new ConnectionSettinds();
            connectionSettings.ShowDialog();
        }
    }
}
