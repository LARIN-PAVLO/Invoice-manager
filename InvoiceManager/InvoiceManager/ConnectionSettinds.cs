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
    public partial class ConnectionSettinds : Form
    {
        public ConnectionSettinds()
        {
            InitializeComponent();

            txtSurnameClient.Text = Properties.Settings.Default.DataSource;
            textBox1.Text = Properties.Settings.Default.Database;
            windows_authentication.Checked = Properties.Settings.Default.IntegratedSecurity;
            textBox2.Text = Properties.Settings.Default.DatabaseLogin;
            textBox3.Text = Properties.Settings.Default.DatabasePassword;
        }

        private void windows_authentication_CheckedChanged(object sender, EventArgs e)
        {
            if (windows_authentication.Checked)
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
            else
            {
                textBox2.Visible = true;
                textBox3.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
        }

        private bool CheckDatabaseConnection()
        {
            string dataSource = txtSurnameClient.Text;
            string database = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;

            string connectionString;

            if (windows_authentication.Checked)
            {
                connectionString = $"Server={dataSource}; Database={database}; Integrated Security=True;";
            }
            else
            {
                connectionString = $"Server={dataSource}; Database={database}; User Id={username}; Password={password};";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Підключення успішне!", "Статус підключення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Помилка підключення: {ex.Message}", "Помилка підключення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataSource = txtSurnameClient.Text;
            Properties.Settings.Default.Database = textBox1.Text;
            Properties.Settings.Default.IntegratedSecurity = windows_authentication.Checked;
            Properties.Settings.Default.DatabaseLogin = textBox2.Text;
            Properties.Settings.Default.DatabasePassword = textBox3.Text;

            Properties.Settings.Default.Save();
        }

    }
}
