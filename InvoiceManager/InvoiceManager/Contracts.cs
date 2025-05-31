using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace InvoiceManager
{
    public partial class Contracts : Form
    {
        DataBase dataBase = new DataBase();

        public Contracts()
        {
            InitializeComponent();
        }

        enum RowState
        {
            Existate,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }

        private void CreateColums()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id_contract", "ID");
            dataGridView1.Columns.Add("id_client", "id_client");
            dataGridView1.Columns.Add("surname", "Прізвище");
            dataGridView1.Columns.Add("client_name", "Ім'я");
            dataGridView1.Columns.Add("patronymic", "По батькові");
            dataGridView1.Columns.Add("company_name", "Компанія");
            dataGridView1.Columns.Add("contract_date", "Дата укладання");
            dataGridView1.Columns.Add("contract_number", "Номер контракту");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3),
                         record.GetString(4), record.GetString(5), record.GetDateTime(6).ToShortDateString(),
                         record.GetInt32(7), RowState.ModifiedNew);
        }


        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT contract.id_contract, contract.id_client, client.surname, client.client_name, client.patronymic, client.company_name, contract.contract_date, contract.contract_number " +
                         $"FROM contract " +
                         $"JOIN client ON contract.id_client = client.id_client";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
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

        private void Contracts_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
            addSelectClient();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            addSelectClient();
        }

        private void searchInput_KeyUp(object sender, KeyEventArgs e)
        {
                        dataGridView1.Rows.Clear();

            string searchString = $@"SELECT contract.id_contract, contract.id_client, client.surname, client.client_name, client.patronymic, 
                             client.company_name, contract.contract_date, contract.contract_number 
                             FROM contract 
                             JOIN client ON contract.id_client = client.id_client
                             WHERE CONCAT(client.surname, ' ', client.client_name, ' ', client.patronymic, ' ', 
                             client.company_name, ' ', contract.contract_number, ' ', contract.contract_date) LIKE @searchTerm";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
            com.Parameters.AddWithValue("@searchTerm", "%" + searchInput.Text + "%");

            dataBase.openConnection();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dataGridView1, reader);
            }

            reader.Close();

            dataBase.closeConnection();
        }

        private void ADDContract_Click(object sender, EventArgs e)
        {
            if (contractNumber.Text == "")
            {
                MessageBox.Show("Увага! Введіть номер контракту!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            else if (selectClient.SelectedItem != null && selectClient.SelectedIndex != -1)
            {
                try
                {
                    selectClient.Text = selectClient.Text + " ";
                    string id = selectClient.Text.Substring(0, selectClient.Text.IndexOf(' '));
                    int amount = Convert.ToInt32(contractNumber.Text);

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1[7, i].Value) == Convert.ToInt32(contractNumber.Text))
                        {
                            MessageBox.Show("Помилка! Такий договір вже існує!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    dataBase.openConnection();

                    string add = $"insert into contract (id_client, contract_date, contract_number) values ('{id}', '{contractDate.Value.ToString("yyyy-MM-dd")}', '{amount}')";
                    SqlCommand command = new SqlCommand(add, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Контракт додано!", "Виконано!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataBase.closeConnection();

                    RefreshDataGrid(dataGridView1);
                }
                catch
                {
                    MessageBox.Show("Сталася помилка!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Помилка! Спочатку виберіть клієнта!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deleteContract_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Контракт не обрано!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
        }

        private void ChanchedContrat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Клієнта не обрано!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contractNumber.Text == "")
            {
                MessageBox.Show("Увага! Введіть номер контракту!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            else if (selectClient.SelectedItem != null && selectClient.SelectedIndex != -1)
            {
                try
                {
                    int selectedIndex = dataGridView1.CurrentCell.RowIndex;

                    int idDetail = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string idClient = selectClient.Text.Substring(0, selectClient.Text.IndexOf(' '));
                    string date = contractDate.Text;
                    int number = Convert.ToInt32(contractNumber.Text);

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1[7, i].Value) == Convert.ToInt32(contractNumber.Text))
                        {
                            if (i == selectedIndex)
                                continue;

                            MessageBox.Show("Помилка! Такий договір вже існує!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string searchString = $"select * from client where id_client = '{idClient}'";

                    SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

                    dataBase.openConnection();
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();

                    string surname = reader.GetString(1);
                    string client_name = reader.GetString(2);
                    string patronymic = reader.GetString(3);
                    string company_name = reader.GetString(5);

                    reader.Close();

                    dataGridView1.Rows[selectedIndex].SetValues(idDetail, idClient, surname, client_name, patronymic, company_name, date, number);
                    dataGridView1.Rows[selectedIndex].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Modified;
                }
                catch
                {
                    MessageBox.Show("Сталася помилка!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Помилка! Спочатку виберіть клієнта!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);

            DataGridViewRow row = dataGridView1.Rows[0];

            string idToFind = row.Cells[1].Value.ToString();

            for (int i = 0; i < selectClient.Items.Count; i++)
            {
                string itemText = selectClient.Items[i].ToString();
                if (itemText.StartsWith(idToFind + " "))
                {
                    selectClient.SelectedIndex = i;
                    break;
                }
            }

            contractDate.Text = row.Cells[6].Value.ToString();
            contractNumber.Text = row.Cells[7].Value.ToString();
        }

        private void SaveContract_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                RowState rowState = (RowState)dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value;

                if (rowState == RowState.Deleted)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value); ;
                    string delete = $"DELETE FROM contract WHERE id_contract = '{id}';";
                    SqlCommand command;
                    command = new SqlCommand(delete, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    string id = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    string id_client = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string number = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    DateTime date = DateTime.ParseExact(dataGridView1.Rows[i].Cells[6].Value.ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string txtDate = date.ToString("yyyy-MM-dd");

                    string change = $"update contract set id_client = '{id_client}', contract_date = '{txtDate}', contract_number = '{number}' where id_contract = '{id}'";
                    SqlCommand command = new SqlCommand(change, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                string idToFind = row.Cells[1].Value.ToString();

                for (int i = 0; i < selectClient.Items.Count; i++)
                {
                    string itemText = selectClient.Items[i].ToString();
                    if (itemText.StartsWith(idToFind + " "))
                    {
                        selectClient.SelectedIndex = i;
                        break;
                    }
                }

                contractDate.Text = row.Cells[6].Value.ToString();
                contractNumber.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
