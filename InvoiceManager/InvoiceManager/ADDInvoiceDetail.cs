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
using System.Text.RegularExpressions;

namespace InvoiceManager
{
    public partial class ADDInvoiceDetail : Form
    {
        DataBase dataBase = new DataBase();

        enum RowState
        {
            Existate,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }

        public ADDInvoiceDetail(int id_invoice)
        {
            this.id_invoice = id_invoice;
            InitializeComponent();
        }

        int id_invoice;
        private void CreateColums()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id_detail", "ID");
            dataGridView1.Columns.Add("id_product", "id_product");
            dataGridView1.Columns.Add("name", "Продукція");
            dataGridView1.Columns.Add("price", "Ціна");
            dataGridView1.Columns.Add("amount", "Кількість");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetDecimal(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT invoiceDetail.id_detail, product.id_product, product.product_name, product.price, invoiceDetail.amount " +
                                 $"FROM invoiceDetail " +
                                 $"JOIN product ON invoiceDetail.id_product = product.id_product " +
                                 $"WHERE invoiceDetail.id_invoice = @id_invoice"; // Додаємо фільтр за id_invoice

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            command.Parameters.AddWithValue("@id_invoice", id_invoice); // Передаємо id_invoice як параметр

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
            if (selectProduct.SelectedText.Length == 0)
            {
                foreach (var item in new ArrayList(selectProduct.Items))
                {
                    selectProduct.Items.Remove(item);
                }
                string searchString = $"select id_product, product_name from product where concat (id_product, ' ', product_name) like '%" + selectProduct.Text + "%'";

                SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    selectProduct.Items.Add(reader[0].ToString() + "   " + reader[1].ToString());
                    selectProduct.ValueMember = reader[0].ToString();
                }

                reader.Close();
                dataBase.closeConnection();
            }
        }


        private void ADDInvoiceDetail_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
            addSelectClient();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (amountProduct.Value <= 0)
            {
                MessageBox.Show("Помилка! Кількість повинна бути більшою 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectProduct.SelectedItem != null && selectProduct.SelectedIndex != -1)
            {
                try
                {
                    selectProduct.Text = selectProduct.Text + " ";
                    string id = selectProduct.Text.Substring(0, selectProduct.Text.IndexOf(' '));
                    string amount = amountProduct.Value.ToString();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1[1, i].Value) == Convert.ToInt32(id))
                        {
                            MessageBox.Show("Помилка! Додано двоє однакових продуктів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    dataBase.openConnection();

                    string add = $"insert into invoiceDetail (id_invoice, id_product, amount) values ('{id_invoice}', '{id}', '{amount}')";
                    SqlCommand command = new SqlCommand(add, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Товар додано!", "Виконано!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataBase.closeConnection();

                    RefreshDataGrid(dataGridView1);
                }
                catch
                {
                    MessageBox.Show("Сталася помилка!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Помилка! Спочатку виберіть продукцію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                IDDetail.Text = row.Cells[0].Value.ToString();

                string idToFind = row.Cells[1].Value.ToString();

                for (int i = 0; i < selectProduct.Items.Count; i++)
                {
                    string itemText = selectProduct.Items[i].ToString();
                    if (itemText.StartsWith(idToFind + " "))
                    {
                        selectProduct.SelectedIndex = i;
                        break;
                    }
                }

                amountProduct.Text = row.Cells[4].Value.ToString();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = RowState.Deleted;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            string idDetail = IDDetail.Text;
            string idproduct = selectProduct.Text.Substring(0, selectProduct.Text.IndexOf(' '));
            string amount = amountProduct.Value.ToString();


            string searchString = $"select * from product where id_product = '{idproduct}'";


            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();

            string product = reader.GetString(1);
            decimal price = reader.GetDecimal(2);

            reader.Close();

            dataGridView1.Rows[selectedIndex].SetValues(idDetail, idproduct, product, price, amount);
            dataGridView1.Rows[selectedIndex].Cells[5].Value = RowState.Modified;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                RowState rowState = (RowState)dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value;

                if (rowState == RowState.Deleted)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value); ;
                    string delete = $"DELETE FROM invoiceDetail WHERE id_detail = '{id}';";
                    SqlCommand command;
                    command = new SqlCommand(delete, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    string id = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    string id_product = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string amount = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    string change = $"update invoiceDetail set id_product = '{id_product}', amount = '{amount}' where id_detail = '{id}'";
                    SqlCommand command = new SqlCommand(change, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void selectProduct_KeyUp(object sender, KeyEventArgs e)
        {
            addSelectClient();
        }
    }
}
