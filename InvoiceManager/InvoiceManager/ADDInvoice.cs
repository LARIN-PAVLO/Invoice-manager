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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;


namespace InvoiceManager
{
    public partial class ADDInvoice : Form
    {
        DataBase dataBase = new DataBase();
        
        public ADDInvoice()
        {
            InitializeComponent();
        }

        private void ADDInvoice_Load(object sender, EventArgs e)
        {
            string searchString = $"select id_client, surname, client_name, patronymic, company_name from client";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                selectClient.Items.Add(reader[0].ToString() + "   " + reader[1].ToString() + "   " + reader[2].ToString() + "   " + reader[3].ToString() + "   " + reader[4].ToString());
            }

            reader.Close();
            dataBase.closeConnection();
        }

        private void selectClient_TextChanged(object sender, EventArgs e)
        {
            if (selectClient.SelectedText.Length == 0)
            {
                foreach (var item in new ArrayList(selectClient.Items))
                {
                    selectClient.Items.Remove(item);
                }
                string searchString = $"select id_client, surname, client_name, patronymic, company_name from client where concat (id_client, '', surname, ' ', client_name, ' ', patronymic, ' ', company_name) like '%" + selectClient.Text + "%'";

                SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    selectClient.Items.Add(reader[0].ToString() + "   " + reader[1].ToString() + "   " + reader[2].ToString() + "   " + reader[3].ToString() + "   " + reader[4].ToString());
                    selectClient.ValueMember = reader[0].ToString();
                }

                reader.Close();
                dataBase.closeConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectClient.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            string id = selectClient.Text.Substring(0, selectClient.Text.IndexOf(' '));

            var add = $"insert into invoice (id_client, date_dispatch) values ('{id}', '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}')";
            var command = new SqlCommand(add, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Накладну створено!", "Виконано!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
