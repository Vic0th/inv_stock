using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_track
{
    public partial class Form1 : Form{
        public Form1() => InitializeComponent();

        string key = "";
        int unitValue = 0;
        int typeValue = 0;
        float price = 0;
        Dictionary<string, int> prodUnit = new Dictionary<string, int>();
        Dictionary<string, int> prodType = new Dictionary<string, int>();
        DatabaseCommand dbCom = new DatabaseCommand();

        // Form yüklenirken çalışan metot
        private void Form1_Load(object sender, EventArgs e){
            dbCom.DatabaseConnect();

            // Tüm ürünleri görüntüle
            dbCom.DisplayRecords("SELECT * FROM ViewAllProducts", dataGridProducts);
            dbCom.LoadOptions("SELECT * FROM ProductUnit", comboUnit, prodUnit);
            dbCom.LoadOptions("SELECT productType_id, productType_name FROM ProductType", comboProductType, prodType);

            Reset();
        }

        // Kaydet düğmesine tıklanınca çalışan metot
        private void buttonSave_Click(object sender, EventArgs e){
            try {
                InputConversion();
                string query = "INSERT INTO Product VALUES (NULL,'" + textProductName.Text + "'," + typeValue + ",'" + textDescription.Text + "'," + unitValue + "," + textQuantity.Text + "," + price + ")";
                SQLProcess(query);
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

        // Güncelle düğmesine tıklanınca çalışan metot
        private void buttonUpdate_Click(object sender, EventArgs e){
            try {
                InputConversion();

                string query = "UPDATE Product SET product_name = '" + textProductName.Text + "', productType_id = " + typeValue + ", product_description = '" + textDescription.Text + "', productUnit_id = " + unitValue + ", product_quantity = " + textQuantity.Text + ", product_price = " + price + " WHERE product_id = " + labelID.Text + "";

                SQLProcess(query);
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

        // Temizle düğmesine tıklanınca çalışan metot
        private void buttonClear_Click(object sender, EventArgs e) => Reset();

        // Sil düğmesine tıklanınca çalışan metot
        private void buttonDelete_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Confirmation", MessageBoxButtons.YesNo);
            
            if(dialogResult == DialogResult.Yes) {
                string query = "DELETE FROM Product WHERE product_id = " + labelID.Text + "";
                SQLProcess(query);
                Reset();
            }        
        }

        // Veritabanında bir hücreye tıklanınca çalışan metot
        private void dataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e){
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
        private void dataGridProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){}

        // SQL işlemlerini gerçekleştiren metot
        public void SQLProcess(string stringQuery){
            dbCom.SQLManager(stringQuery);
            stringQuery = "SELECT * FROM ViewAllProducts";
            dbCom.DisplayRecords(stringQuery, dataGridProducts);
        }

        // Kullanıcı girdilerini işleyen metot
        public void InputConversion(){
            // Dictionary lookup
            key = comboUnit.SelectedItem.ToString();
            prodUnit.TryGetValue(key, out unitValue);

            key = comboProductType.SelectedItem.ToString();
            prodType.TryGetValue(key, out typeValue);

            price = (float)Convert.ToDouble(textPrice.Text);
        }

        // Formu sıfırlayan metot
        public void Reset(){
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

        // Düğmeleri ayarlayan metot
        public void SetButtons(){
            buttonSave.Enabled = false;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonSave_EnabledChanged(object sender, EventArgs e){
            if (buttonSave.Enabled == false)
                buttonSave.BackColor = Color.DarkGray;
            else if (buttonSave.Enabled == true)
                buttonSave.BackColor = Color.LimeGreen;
        }

        private void buttonUpdate_EnabledChanged(object sender, EventArgs e){
            if (buttonUpdate.Enabled == false) 
                buttonUpdate.BackColor = Color.DarkGray;
            else if (buttonUpdate.Enabled == true)
                buttonUpdate.BackColor = Color.DodgerBlue;
        }

        private void buttonDelete_EnabledChanged(object sender, EventArgs e){
            if (buttonDelete.Enabled == false)
                buttonDelete.BackColor = Color.DarkGray;
            else if (buttonDelete.Enabled == true)
                buttonDelete.BackColor = Color.Red;
        }


        private void textSearch_TextChanged(object sender, EventArgs e){
            string query = "SELECT Product.product_id 'Product ID', Product.product_name 'Product Name', ProductType.productType_name 'Type', ProductCategory.productCategory_name 'Category', Product.product_description 'Description', Product.product_price 'Price', Product.product_quantity 'Qty.', ProductUnit.productUnit_name 'Unit' FROM Product INNER JOIN ProductUnit USING (productUnit_id) INNER JOIN ProductType USING (productType_id) INNER JOIN ProductCategory USING (productCategory_id) WHERE Product.product_id LIKE '%" + textSearch.Text + "%' OR Product.product_name LIKE '%" + textSearch.Text + "%'";
            dbCom.DisplayRecords(query, dataGridProducts);
        }

        private void labelProductName_Click(object sender, EventArgs e){}

        private void labelHeader_Click(object sender, EventArgs e){}
    }
}
