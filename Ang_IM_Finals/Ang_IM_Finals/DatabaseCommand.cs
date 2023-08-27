using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ang_IM_Finals
{
    class DatabaseCommand
    {
        MySqlConnection databaseConnection = new MySqlConnection();
        MySqlCommand sqlCommand = new MySqlCommand();
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        DataTable dataTable = new DataTable();

        private string connectionString = "server=localhost; database=inventory_db; user=root; port=3306;";

        public void DatabaseConnect()
        {
            databaseConnection = new MySqlConnection(connectionString);

            // databaseConnection.Open();
            // MessageBox.Show("Test Connection Successful!");
            // databaseConnection.Close();
        }

        public void DisplayRecords(string SQL, DataGridView dataGridView)
        {
            databaseConnection.Open();

            dataAdapter = new MySqlDataAdapter(SQL, databaseConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;

            databaseConnection.Close();
        }

        public void LoadOptions(string SQL, ComboBox comboBox, Dictionary<string, int> dict)
        {
            databaseConnection.Open();

            dataAdapter = new MySqlDataAdapter(SQL, databaseConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                string options = string.Format("{0}", row.ItemArray[1]);
                comboBox.Items.Add(options);
                dict.Add(row.ItemArray[1].ToString(), Convert.ToInt32(row.ItemArray[0]));
                }

            /*foreach (KeyValuePair<string, int> entry in dict) {
                Console.WriteLine("{0} and {1}", entry.Key, entry.Value);
            }*/

            databaseConnection.Close();
        }

        public void SQLManager(string SQL)
        {
            databaseConnection.Open();

            sqlCommand = new MySqlCommand(SQL, databaseConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();

            /*try {
                sqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException e) {
                MessageBox.Show("Please do not leave any important fields blank.");
            }*/

            databaseConnection.Close();
        }
    }
}
