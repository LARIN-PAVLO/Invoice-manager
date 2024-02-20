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
    public partial class ADDClient : Form
    {
        DataBase dataBase = new DataBase();

        public ADDClient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            string surname = txtSurnameClient.Text;
            string nameclient = txtNameClient.Text;
            string patronymic = txtPatronymicClient.Text;
            string phone = txtPhoneClient.Text;
            string company = txtNameComanyClient.Text;

            var add = $"insert into client (surname, client_name, patronymic, phone, company_name) values ('{surname}', '{nameclient}', '{patronymic}', '{phone}', '{company}')";
            var command = new SqlCommand(add, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Клієнта додано!", "Виконано!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameClient.Text = "";
            txtNameComanyClient.Text = "";
            txtPatronymicClient.Text = "";
            txtPhoneClient.Text = "";
            txtSurnameClient.Text = "";
        }
    }
}
