using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_track{
    class DatabaseCommand{
        MySqlConnection databaseConnection = new MySqlConnection();
        MySqlCommand sqlCommand = new MySqlCommand();
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        DataTable dataTable = new DataTable();

        // Veritabanı bağlantı dizesi
        private string connectionString = "server=localhost; database=inventory_db; user=root; port=3306;";

        // Veritabanı bağlantısını oluşturan metot
        public void DatabaseConnect() => databaseConnection = new MySqlConnection(connectionString);

        // Kayıtları görüntülemek için kullanılan metot
        public void DisplayRecords(string SQL, DataGridView dataGridView){
            databaseConnection.Open();

            dataAdapter = new MySqlDataAdapter(SQL, databaseConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;

            databaseConnection.Close();
        }

        // Seçenekleri yüklemek için kullanılan metot
        public void LoadOptions(string SQL, ComboBox comboBox, Dictionary<string, int> dict){
            databaseConnection.Open();

            dataAdapter = new MySqlDataAdapter(SQL, databaseConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                string options = string.Format("{0}", row.ItemArray[1]);
                comboBox.Items.Add(options);
                dict.Add(row.ItemArray[1].ToString(), Convert.ToInt32(row.ItemArray[0]));
                }
            databaseConnection.Close();
        }

        // SQL sorgularını yöneten metot
        public void SQLManager(string SQL){
            databaseConnection.Open();

            sqlCommand = new MySqlCommand(SQL, databaseConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();

            databaseConnection.Close();
        }
    }
}
