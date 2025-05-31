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
using InvoiceManager.Properties;
using System.Globalization;
using System.IO;

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
                    dataGridView1.Columns.Add("unit_of_measurement", "Одиниці");
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
                    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2), record.GetString(3), RowState.ModifiedNew);
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
                        textBox1.Text = row.Cells[3].Value.ToString();
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
            addProduct.ShowDialog();
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
                    searchString = $"select * from product where concat (id_product,' ' ,product_name,' ' , price,' ' ,unit_of_measurement) like '%" + txt_search.Text + "%'";

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
            if (dataGridView1.CurrentCell == null)
                return; // Без вибраної клітинки — вихід

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
                            string price = dataGridView1.Rows[i].Cells[2].Value.ToString()?.Replace(",", ".");
                            string unit_of_measurement = dataGridView1.Rows[i].Cells[1].Value.ToString();

                            change = $"update product set product_name = '{name}', price = '{price}', unit_of_measurement = '{unit_of_measurement}' where id_product = '{id}'";
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
            if (dataGridView1.CurrentCell == null)
                return; // Без вибраної клітинки — вихід

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
                    string unit_of_measurement = textBox1.Text;
                    decimal price;

                    if (dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString() != string.Empty)
                    {
                        if (decimal.TryParse(priceBread.Text, out price))
                        {
                            dataGridView1.Rows[selectedIndex].SetValues(id, name, price, unit_of_measurement);
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
            aDDClient.ShowDialog();
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
            aDDInvoice.ShowDialog();
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


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(frmvisible == "invoice")
            {
                ADDInvoiceDetail aDDInvoiceDetail = new ADDInvoiceDetail(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                aDDInvoiceDetail.ShowDialog();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void selectClient_KeyUp(object sender, KeyEventArgs e)
        {
            addSelectClient();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Клієнта не обрано!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int invoiceId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            // Створення екземпляра класу WordRender
            string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invoice.docx");
            string tempPath = Path.Combine(Path.GetTempPath(), "invoice_temp.docx");
            File.Copy(sourcePath, tempPath, true);
            WordRender render = new WordRender(tempPath);

            string contractDateLong = "24.05.2025";
            string contractDate = GetContractDate(invoiceId);

            if (!string.IsNullOrEmpty(contractDate) && DateTime.TryParseExact(contractDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                // Форматуємо дату як "dd MMMM yyyy" (наприклад: 01 квітня 2025)
                contractDateLong = date.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("uk-UA"));
            }

            // Створення словника для заміни маркерів
            var items = new Dictionary<string, string>
            {
                {"<Organization>", getOrganizationInfo().Replace(Environment.NewLine, "^p")},
                {"<Client>", getClientInfo(invoiceId).Replace(Environment.NewLine, "^p")},
                {"<ContractNumber>", GetContractNumber(invoiceId)},
                {"<ContractDate>", contractDate},
                {"<ContractDateLong>", contractDateLong},
                {"<Number>", invoiceId.ToString()},
                {"<Date>", GetInvoiceDate(invoiceId).ToString("dd MMMM yyyy")},
                {"<TotalWithoutVAT>", GetInvoiceTotal(invoiceId).ToString("0.00")},
                {"<VATAmount>", GetVATAmount(invoiceId).ToString("0.00")},
                {"<TotalWithVAT>", (GetInvoiceTotal(invoiceId) + GetVATAmount(invoiceId)).ToString("0.00")},
                {"<Sum>", ConvertToWords(GetInvoiceTotal(invoiceId) + GetVATAmount(invoiceId))},
                {"<VAT>", ConvertToWords(GetVATAmount(invoiceId))}
            };

            // Створення списку продуктів для таблиці
            var products = GetProductList(invoiceId);

            // Кількість різних товарів у накладній (по суті — кількість рядків у таблиці)
            int realProductCount = products.Count(p =>
                !string.IsNullOrWhiteSpace(p["<NameProduct>"]) &&
                !string.IsNullOrWhiteSpace(p["<Amount>"]) &&
                !string.IsNullOrWhiteSpace(p["<UnitName>"]) &&
                !string.IsNullOrWhiteSpace(p["<UnitPrice>"]) &&
                !string.IsNullOrWhiteSpace(p["<SumProdact>"])
            );

            items["<AmountUnits>"] = realProductCount.ToString();


            // Викликаємо метод для обробки документа
            render.Process(items, products);
        }

        private string getOrganizationInfo()
        {
            // Формуємо SQL-запит для отримання даних про компанію
            string searchString = @"SELECT TOP (1) 
                                [name], 
                                [zip_code], 
                                [city], 
                                [street], 
                                [building_number], 
                                [phone], 
                                [account], 
                                [bank], 
                                [bank_city]
                            FROM [invoiceManager].[dbo].[сompanyInfo]";

            // Виконання SQL-запиту
            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = com.ExecuteReader();

            // Перевірка, чи є результат
            string nl = Environment.NewLine;
            string organizationInfo = string.Empty;
            if (reader.Read())
            {
                organizationInfo = $"{reader["name"]},{nl}" +
                                   $"{reader["zip_code"]}, " +
                                   $"м. {reader["city"]}, " +
                                   $"вул. {reader["street"]}, " +
                                   $"{reader["building_number"]}, " +
                                   $"тел. {reader["phone"]},{nl}" +
                                   $"р/р {reader["account"]} " +
                                   $"у банку {reader["bank"]}, " +
                                   $"м. {reader["bank_city"]}";
            }


            // Закриваємо рідер та з'єднання
            reader.Close();
            dataBase.closeConnection();

            // Повертаємо сформований рядок
            return organizationInfo;
        }

        private decimal GetInvoiceTotal(int invoiceId)
        {
            string query = "SELECT total_amount FROM [invoiceManager].[dbo].[invoice] WHERE id_invoice = @invoiceId";
            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();
                object result = cmd.ExecuteScalar();
                dataBase.closeConnection();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(result);
            }
        }

        private string ConvertToWords(decimal amount)
        {
            if (amount == 0)
                return "Нуль гривень 00 копійок";

            int integerPart = (int)amount;
            int fractionalPart = (int)((amount - integerPart) * 100);

            string words = ConvertIntegerToWords(integerPart) + " гривень ";

            if (fractionalPart > 0)
            {
                words += ConvertIntegerToWords(fractionalPart) + " копійок";
            }
            else
            {
                words += "00 копійок";
            }

            return words.Trim();
        }

        private string ConvertIntegerToWords(int number)
        {
            if (number == 0)
                return "";

            string[] ones = new string[] { "", "одна", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };
            string[] teens = new string[] { "десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };
            string[] tens = new string[] { "", "", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
            string[] hundreds = new string[] { "", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };
            string[] thousands = new string[] { "", "тисяча", "дві тисячі", "три тисячі", "чотири тисячі", "п'ять тисяч", "шість тисяч", "сім тисяч", "вісім тисяч", "дев'ять тисяч" };

            string words = "";

            if (number >= 1000)
            {
                words += thousands[number / 1000] + " ";
                number %= 1000;
            }

            if (number >= 100)
            {
                words += hundreds[number / 100] + " ";
                number %= 100;
            }

            if (number >= 20)
            {
                words += tens[number / 10] + " ";
                number %= 10;
            }

            if (number >= 10)
            {
                words += teens[number - 10] + " ";
                number = 0;
            }

            if (number > 0)
            {
                words += ones[number] + " ";
            }

            return words.Trim();
        }


        private DateTime GetInvoiceDate(int invoiceId)
        {
            DateTime invoiceDate = DateTime.MinValue;

            string query = "SELECT date_dispatch FROM [invoiceManager].[dbo].[invoice] WHERE id_invoice = @invoiceId";
            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();
                invoiceDate = Convert.ToDateTime(cmd.ExecuteScalar());
                dataBase.closeConnection();
            }

            return invoiceDate;
        }

        private decimal GetVATAmount(int invoiceId)
        {
            string query = "SELECT vat_amount FROM [invoiceManager].[dbo].[invoice] WHERE id_invoice = @invoiceId";
            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();
                object result = cmd.ExecuteScalar();
                dataBase.closeConnection();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(result);
            }
        }


        private string getClientInfo(int invoiceId)
        {
            // Отримуємо id_client з таблиці invoice за допомогою invoiceId
            string clientId = string.Empty; // Змінна для зберігання clientId
            string searchClientIdQuery = @"SELECT id_client 
                                   FROM [invoiceManager].[dbo].[invoice] 
                                   WHERE id_invoice = @invoiceId";

            SqlCommand clientIdCommand = new SqlCommand(searchClientIdQuery, dataBase.getConnection());
            clientIdCommand.Parameters.AddWithValue("@invoiceId", invoiceId);

            dataBase.openConnection();
            SqlDataReader clientIdReader = clientIdCommand.ExecuteReader();

            if (clientIdReader.Read())
            {
                clientId = clientIdReader["id_client"].ToString(); // Отримуємо id_client
            }

            clientIdReader.Close();

            // Якщо clientId знайдений, то шукаємо інформацію про клієнта
            if (!string.IsNullOrEmpty(clientId))
            {
                string searchString = @"SELECT
                                [company_name], 
                                [zip_code], 
                                [city], 
                                [street], 
                                [building_number],
                                [phone], 
                                [account], 
                                [bank], 
                                [bank_city]
                            FROM [invoiceManager].[dbo].[client] 
                            WHERE id_client = @clientId";

                SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
                com.Parameters.AddWithValue("@clientId", clientId); // Передаємо id клієнта

                SqlDataReader reader = com.ExecuteReader();
                string nl = Environment.NewLine;
                string clientInfo = string.Empty;

                if (reader.Read())
                {
                    clientInfo = $"{reader["company_name"]},{nl}" +
                                 $"{reader["zip_code"]}, " +
                                 $"м. {reader["city"]}, " +
                                 $"вул. {reader["street"]}, " +
                                 $"{reader["building_number"]}, " +
                                 $"тел. {reader["phone"]},{nl}" +
                                 $"р/р {reader["account"]} " +
                                 $"у банку {reader["bank"]}, " +
                                 $"м. {reader["bank_city"]}";
                }

                reader.Close();
                dataBase.closeConnection();

                return clientInfo;
            }
            else
            {
                // Якщо id_client не знайдений
                dataBase.closeConnection();
                return "Клієнт не знайдений.";
            }
        }

        private string GetContractNumber(int invoiceId)
        {
            string contractNumber = string.Empty;

            string query = @"
    SELECT c.contract_number
    FROM [invoiceManager].[dbo].[contract] c
    JOIN [invoiceManager].[dbo].[client] cl ON c.id_contract = cl.id_contract
    JOIN [invoiceManager].[dbo].[invoice] i ON cl.id_client = i.id_client
    WHERE i.id_invoice = @invoiceId";

            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contractNumber = reader["contract_number"].ToString();
                    }
                }

                dataBase.closeConnection();
            }

            return contractNumber;
        }

        private string GetContractDate(int invoiceId)
        {
            string contractDate = string.Empty;

            string query = @"
    SELECT c.contract_date
    FROM [invoiceManager].[dbo].[contract] c
    JOIN [invoiceManager].[dbo].[client] cl ON c.id_contract = cl.id_contract
    JOIN [invoiceManager].[dbo].[invoice] i ON cl.id_client = i.id_client
    WHERE i.id_invoice = @invoiceId";

            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Форматуємо дату як "dd.MM.yyyy"
                        contractDate = reader["contract_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["contract_date"]).ToString("dd.MM.yyyy", new CultureInfo("uk-UA"))
                            : "Дата не вказана";
                    }
                }

                dataBase.closeConnection();
            }

            return contractDate;
        }



        private List<Dictionary<string, string>> GetProductList(int invoiceId)
        {
            var productList = new List<Dictionary<string, string>>();
            bool hasRows = false;

            string query = @"
        SELECT p.product_name, d.amount, p.price, p.unit_of_measurement
        FROM invoiceDetail d
        JOIN product p ON d.id_product = p.id_product
        WHERE d.id_invoice = @invoiceId";

            using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                dataBase.openConnection();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hasRows = true;

                        string name = reader["product_name"]?.ToString() ?? "";
                        string unit = reader["unit_of_measurement"]?.ToString() ?? "";

                        int amount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0;
                        decimal price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0;
                        decimal sum = amount * price;

                        productList.Add(new Dictionary<string, string>
                {
                    {"<NameProduct>", name},
                    {"<Amount>", amount == 0 ? "" : amount.ToString()},
                    {"<UnitName>", unit},
                    {"<UnitPrice>", price == 0 ? "" : price.ToString("0.00")},
                    {"<SumProdact>", sum == 0 ? "" : sum.ToString("0.00")}
                });
                    }
                }
                dataBase.closeConnection();
            }

            // Якщо немає жодного товару – додати порожній запис
            if (!hasRows)
            {
                productList.Add(new Dictionary<string, string>
        {
            {"<NameProduct>", ""},
            {"<Amount>", ""},
            {"<UnitName>", ""},
            {"<UnitPrice>", ""},
            {"<SumProdact>", ""}
        });
            }

            return productList;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Клієнта не обрано!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int clientId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            ClientDetails clientDetails = new ClientDetails(clientId);
            clientDetails.ShowDialog();
        }

        private void ContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contracts contracts = new Contracts();
            contracts.ShowDialog();
        }
    }
}
