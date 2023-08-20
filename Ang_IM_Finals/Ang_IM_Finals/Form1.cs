using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ang_IM_Finals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string stringQuery = "";
        string key = "";
        int unitValue = 0;
        int typeValue = 0;
        float price = 0;
        Dictionary<string, int> prodUnit = new Dictionary<string, int>();
        Dictionary<string, int> prodType = new Dictionary<string, int>();
        DatabaseCommand databaseCommand = new DatabaseCommand();

        //kod deneme1

        //List<string> queryQueue = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            databaseCommand.DatabaseConnect();

            stringQuery = "SELECT * FROM ViewAllProducts";
            databaseCommand.DisplayRecords(stringQuery, dataGridProducts);

            stringQuery = "SELECT * FROM ProductUnit";
            databaseCommand.LoadOptions(stringQuery, comboUnit, prodUnit);

            stringQuery = "SELECT productType_id, productType_name FROM ProductType";
            databaseCommand.LoadOptions(stringQuery, comboProductType, prodType);

            /*queryQueue.Add(stringQuery);
            for (int i = 0; i < queryQueue.Count; i++) {
                databaseCommand.DisplayRecords(queryQueue[i], dataGridProducts);
            }*/

            Reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try {
                InputConversion();

                stringQuery = "INSERT INTO Product VALUES (NULL,'" + textProductName.Text + "'," + typeValue + ",'" + textDescription.Text + "'," + unitValue + "," + textQuantity.Text + "," + price + ")";

                SQLProcess(stringQuery);
                MessageBox.Show("Record successfully added.");

                Reset();
            }
            catch (FormatException) {
                MessageBox.Show("Please do not leave the price blank.");
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please select a Product Type or Unit.");
            }
            catch (MySqlException) {
                MessageBox.Show("Please do not leave any important fields blank.");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try {
                InputConversion();

                stringQuery = "UPDATE Product SET product_name = '" + textProductName.Text + "', productType_id = " + typeValue + ", product_description = '" + textDescription.Text + "', productUnit_id = " + unitValue + ", product_quantity = " + textQuantity.Text + ", product_price = " + price + " WHERE product_id = " + labelID.Text + "";

                SQLProcess(stringQuery);
                MessageBox.Show("Record successfully updated.");

                Reset();
            }
            catch (FormatException) {
                MessageBox.Show("Please do not leave the price blank.");
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please select a Product Type or Unit.");
            }  
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Confirmation", MessageBoxButtons.YesNo);
            
            if(dialogResult == DialogResult.Yes) {
                stringQuery = "DELETE FROM Product WHERE product_id = " + labelID.Text + "";

                SQLProcess(stringQuery);

                Reset();
            }        
        }

        private void dataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            labelID.Text = Convert.ToString((int)dataGridProducts[0, rowIndex].Value);
            textProductName.Text = (string)dataGridProducts[1, rowIndex].Value;
            comboProductType.Text = (string)dataGridProducts[2, rowIndex].Value;
            textDescription.Text = (string)dataGridProducts[4, rowIndex].Value;
            textPrice.Text = Convert.ToString((double)dataGridProducts[5, rowIndex].Value);
            textQuantity.Text = Convert.ToString((int)dataGridProducts[6, rowIndex].Value);
            comboUnit.Text = (string)dataGridProducts[7, rowIndex].Value;

            SetButtons();
        }
        private void dataGridProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        public void SQLProcess(string stringQuery)
        {
            databaseCommand.SQLManager(stringQuery);
            stringQuery = "SELECT * FROM ViewAllProducts";
            databaseCommand.DisplayRecords(stringQuery, dataGridProducts);
        }

        public void InputConversion()
        {
            // Dictionary lookup
            key = comboUnit.SelectedItem.ToString();
            prodUnit.TryGetValue(key, out unitValue);

            key = comboProductType.SelectedItem.ToString();
            prodType.TryGetValue(key, out typeValue);

            price = (float)Convert.ToDouble(textPrice.Text);
        }

        public void Reset()
        {
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            labelID.Text = "N/A";
            textProductName.Clear();
            textDescription.Clear();
            textPrice.Clear();
            textQuantity.Clear();
            comboProductType.SelectedIndex = 0;
            comboUnit.SelectedIndex = 0;
        }

        public void SetButtons()
        {
            buttonSave.Enabled = false;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonSave_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonSave.Enabled == false) {
                buttonSave.BackColor = Color.DarkGray;
            }
            else if (buttonSave.Enabled == true) {
                buttonSave.BackColor = Color.LimeGreen;
            }
        }

        private void buttonUpdate_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonUpdate.Enabled == false) {
                buttonUpdate.BackColor = Color.DarkGray;
            }
            else if (buttonUpdate.Enabled == true) {
                buttonUpdate.BackColor = Color.DodgerBlue;
            }
        }

        private void buttonDelete_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonDelete.Enabled == false) {
                buttonDelete.BackColor = Color.DarkGray;
            }
            else if (buttonDelete.Enabled == true) {
                buttonDelete.BackColor = Color.Red;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            stringQuery = "SELECT Product.product_id 'Product ID', Product.product_name 'Product Name', ProductType.productType_name 'Type', ProductCategory.productCategory_name 'Category', Product.product_description 'Description', Product.product_price 'Price', Product.product_quantity 'Qty.', ProductUnit.productUnit_name 'Unit' FROM Product INNER JOIN ProductUnit USING (productUnit_id) INNER JOIN ProductType USING (productType_id) INNER JOIN ProductCategory USING (productCategory_id) WHERE Product.product_id LIKE '%" + textSearch.Text + "%' OR Product.product_name LIKE '%" + textSearch.Text + "%'";
            databaseCommand.DisplayRecords(stringQuery, dataGridProducts);
        }
    }
}
