using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InvoiceManager
{
    internal class DataBase
    {
        private string dataSource = Properties.Settings.Default.DataSource;
        private string database = Properties.Settings.Default.Database;
        private bool useWindowsAuth = Properties.Settings.Default.IntegratedSecurity;
        private string username = Properties.Settings.Default.DatabaseLogin;
        private string password = Properties.Settings.Default.DatabasePassword;

        private SqlConnection sqlConnection;

        public DataBase()
        {
            string connectionString;

            if (useWindowsAuth)
            {
                connectionString = $"Server={dataSource}; Database={database}; Integrated Security=True;";
            }
            else
            {
                connectionString = $"Server={dataSource}; Database={database}; User Id={username}; Password={password};";
            }

            sqlConnection = new SqlConnection(connectionString);
        }

        public void openConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Помилка підключення до бази даних:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

        public bool TestConnection()
        {
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Не вдалося підключитися:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
