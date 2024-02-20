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
using System.Collections;

namespace InvoiceManager
{
    enum RowState
    {
        Existate,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class app : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        string frmvisible = "client";

        public app()
        {
            InitializeComponent();
        }

        private void CreateColums()
        {
            dataGridView1.Columns.Clear();
            switch (frmvisible)
            {
                case "client":
                    dataGridView1.Columns.Add("id_client", "ID");
                    dataGridView1.Columns.Add("surname", "Прізвище");
                    dataGridView1.Columns.Add("name", "Ім'я");
                    dataGridView1.Columns.Add("patronymic", "По батькові");
                    dataGridView1.Columns.Add("phone", "Телефон");
                    dataGridView1.Columns.Add("company", "Назва компанії");
                    dataGridView1.Columns.Add("IsNew", String.Empty);
                    break;
                case "product":
                    dataGridView1.Columns.Add("id", "ID");
                    dataGridView1.Columns.Add("name", "Назва товару");
                    dataGridView1.Columns.Add("Price", "Ціна");
                    dataGridView1.Columns.Add("IsNew", String.Empty);
                    break;
                case "invoice":
                    dataGridView1.Columns.Add("id", "ID");
                    dataGridView1.Columns.Add("id_client", "ID client");
                    dataGridView1.Columns.Add("surname", "Прізвище");
                    dataGridView1.Columns.Add("name", "Ім'я");
                    dataGridView1.Columns.Add("patronymic", "По батькові");
                    dataGridView1.Columns.Add("company", "Назва компанії");
                    dataGridView1.Columns.Add("date", "Дата");
                    dataGridView1.Columns.Add("IsNew", String.Empty);
                    dataGridView1.Columns[1].Visible = false;
                    break;
            }
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            switch (frmvisible)
            {
                case "client":
                    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
                    break;
                case "product":
                    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), RowState.ModifiedNew);
                    break;
                case "invoice":
                    dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5),  record.GetDateTime(6).ToShortDateString(), RowState.ModifiedNew);
                    break;
            }
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querryString;
            if (frmvisible == "client" || frmvisible == "product")
                querryString = $"select * from {frmvisible}";
            else
                querryString = $"select invoice.id_invoice, client.id_client, client.surname, client.client_name, client.patronymic, client.company_name, invoice.date_dispatch from {frmvisible} join client on invoice.id_client = client.id_client";
            SqlCommand command = new SqlCommand(querryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            
            reader.Close();
            
        }

        private void app_Load(object sender, EventArgs e)
        {
            groupClient.Dock = DockStyle.Bottom;
            groupProduct.Visible = false;
            groupInvoice.Visible = false;
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                switch (frmvisible)
                {
                    case "client":
                        txtIDClient.Text = row.Cells[0].Value.ToString();
                        txtSurnameClient.Text = row.Cells[1].Value.ToString();
                        txtNameClient.Text = row.Cells[2].Value.ToString();
                        txtPatronymicClient.Text = row.Cells[3].Value.ToString();
                        txtPhoneClient.Text = row.Cells[4].Value.ToString();
                        txtNameComanyClient.Text = row.Cells[5].Value.ToString();
                        break;
                    case "product":
                        IDbread.Text = row.Cells[0].Value.ToString();
                        nameBread.Text = row.Cells[1].Value.ToString();
                        priceBread.Text = row.Cells[2].Value.ToString();
                        break;
                    case "invoice":
                        txtIDInvoice.Text = row.Cells[0].Value.ToString();
                        selectClient.Text = row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString() + " " + row.Cells[5].Value.ToString();
                        dateTimePicker1.Text = row.Cells[6].Value.ToString();
                        break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = "";

            switch (frmvisible)
            {
                case "client":
                    searchString = $"select * from client where concat (surname, ' ', client_name, ' ', patronymic, ' ', phone, ' ', company_name) like '%" + txt_search.Text + "%'";
                    
                    break;
                case "product":
                    searchString = $"select * from product where concat (id_product,' ' ,product_name,' ' , price) like '%" + txt_search.Text + "%'";

                    break;
                case "invoice":
                    searchString = $"select invoice.id_invoice, client.id_client, client.surname, client.client_name, client.patronymic, client.company_name, invoice.date_dispatch from invoice join client on invoice.id_client = client.id_client where concat (invoice.id_invoice,' ' , client.id_client,' ', client.surname,' ' , client.client_name,' ', client.patronymic,' ', client.company_name,' ', invoice.date_dispatch) like '%" + txt_search.Text + "%'";

                    break;
            }

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = com.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }

            reader.Close();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString()== string.Empty)
            {
                dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();
        }


        
        private void update()
        {
            dataBase.openConnection();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                RowState rowState = (RowState)dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value;

                if (rowState == RowState.Deleted)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value); ;
                    string delete = "";
                    SqlCommand command;
                    switch (frmvisible)
                    {
                        case "client":
                            delete = $"DELETE FROM invoiceDetail WHERE id_invoice IN (SELECT id_invoice FROM invoice WHERE id_client = '{id}');" +
                                $"DELETE FROM invoice WHERE id_client = '{id}';" +
                                $"DELETE FROM client WHERE id_client = '{id}';";

                            break;
                        case "product":
                            delete = $"DELETE FROM product WHERE id_product = '{id}';" +
                                     $"DELETE FROM invoiceDetail WHERE id_product = '{id}';";

                            break;
                        case "invoice":
                            delete = $"DELETE FROM invoice WHERE id_invoice = '{id}';" +
                                     $"DELETE FROM invoiceDetail WHERE id_invoice = '{id}';";

                            break;
                    }

                    command = new SqlCommand(delete, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    string id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string change = "";

                    switch (frmvisible)
                    {
                        case "client":
                            string surname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            string nameClient = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            string patronymic = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            string phone = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            string company = dataGridView1.Rows[i].Cells[5].Value.ToString();

                            change = $"update client set surname = '{surname}', client_name = '{nameClient}', patronymic = '{patronymic}', phone = '{phone}', company_name = '{company}' where id_client = '{id}'";

                            break;
                        case "product":
                            string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            string price = dataGridView1.Rows[i].Cells[2].Value.ToString();

                            change = $"update product set product_name = '{name}', price = '{price}' where id_product = '{id}'";
                            break;
                        case "invoice":
                            string idClient = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            DateTime date = DateTime.ParseExact(dataGridView1.Rows[i].Cells[6].Value.ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            string txtDate = date.ToString("yyyy-MM-dd");

                            change = $"update invoice set id_client = '{idClient}', date_dispatch = '{txtDate}' where id_invoice = '{id}'";
                            break;
                    }
                    SqlCommand command = new SqlCommand(change, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update();
        }

        private void Chage()
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            switch (frmvisible)
            {
                case "client":
                    string idclient = txtIDClient.Text;
                    string surname = txtSurnameClient.Text;
                    string nameclient = txtNameClient.Text;
                    string patronymic = txtPatronymicClient.Text;
                    string phone = txtPhoneClient.Text;
                    string company = txtNameComanyClient.Text;
                    dataGridView1.Rows[selectedIndex].SetValues(idclient, surname, nameclient, patronymic, phone, company);
                    dataGridView1.Rows[selectedIndex].Cells[6].Value = RowState.Modified;
                    break;

                case "product":
                    string id = IDbread.Text;
                    string name = nameBread.Text;
                    int price;

                    if (dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString() != string.Empty)
                    {
                        if (int.TryParse(priceBread.Text, out price))
                        {
                            dataGridView1.Rows[selectedIndex].SetValues(id, name, price);
                            dataGridView1.Rows[selectedIndex].Cells[3].Value = RowState.Modified;
                        }
                        else
                        {
                            MessageBox.Show("Помилка! Ціна повинна мати числовий формат!");
                        }
                    }
                    break;
                case "invoice":
                    string idinvoice = txtIDInvoice.Text;
                    string idClient = selectClient.Text.Substring(0, selectClient.Text.IndexOf(' '));


                    string searchString = $"select surname, client_name, patronymic, company_name from client where id_client = '{idClient}'";


                    SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

                    dataBase.openConnection();
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();

                    string Surname = reader.GetString(0);
                    string nameClient = reader.GetString(1);
                    string Patronymic = reader.GetString(2);
                    string Company = reader.GetString(3);

                    reader.Close();

                    string date = dateTimePicker1.Text;

                    dataGridView1.Rows[selectedIndex].SetValues(idinvoice, idClient, Surname, nameClient, Patronymic, Company, date);
                    dataGridView1.Rows[selectedIndex].Cells[7].Value = RowState.Modified;
                    break;
            }
        }
        
        private void btnChange_Click(object sender, EventArgs e)
        {
            Chage();
        }

        private void toolProduct_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            frmvisible = "product";
            groupClient.Visible = false;
            groupProduct.Visible = true;
            groupInvoice.Visible = false;

            groupProduct.Dock = DockStyle.Bottom;
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }

        private void toolClient_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            frmvisible = "client";
            groupClient.Visible = true;
            groupProduct.Visible = false;
            groupInvoice.Visible = false;

            groupClient.Dock = DockStyle.Bottom;
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            ADDClient aDDClient = new ADDClient();
            aDDClient.Show();
        }

        private void toolInvoice_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            frmvisible = "invoice";
            groupClient.Visible = false;
            groupProduct.Visible = false;
            groupInvoice.Visible = true;

            groupInvoice.Dock = DockStyle.Bottom;
            CreateColums();
            RefreshDataGrid(dataGridView1);
            addSelectClient();
        }

        private void toolCreate_Click(object sender, EventArgs e)
        {
            ADDInvoice aDDInvoice = new ADDInvoice();
            aDDInvoice.Show();
        }

        private void addSelectClient()
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

        private void selectClient_TextChanged(object sender, EventArgs e)
        {
            addSelectClient();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(frmvisible == "invoice")
            {
                ADDInvoiceDetail aDDInvoiceDetail = new ADDInvoiceDetail(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                aDDInvoiceDetail.Show();
            }
        }
    }
}
