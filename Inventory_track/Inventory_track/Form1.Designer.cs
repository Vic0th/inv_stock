namespace Inventory_track
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            this.groupBoxID = new System.Windows.Forms.GroupBox();
            this.labelID = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.labelUnit = new System.Windows.Forms.Label();
            this.comboProductType = new System.Windows.Forms.ComboBox();
            this.labelProductType = new System.Windows.Forms.Label();
            this.textProductName = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.groupBoxFields.SuspendLayout();
            this.groupBoxID.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Location = new System.Drawing.Point(12, 49);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.ReadOnly = true;
            this.dataGridProducts.Size = new System.Drawing.Size(844, 513);
            this.dataGridProducts.TabIndex = 0;
            this.dataGridProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellClick);
            this.dataGridProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridProducts_CellFormatting);
            // 
            // groupBoxFields
            // 
            this.groupBoxFields.Controls.Add(this.groupBoxID);
            this.groupBoxFields.Controls.Add(this.textDescription);
            this.groupBoxFields.Controls.Add(this.labelDescription);
            this.groupBoxFields.Controls.Add(this.textPrice);
            this.groupBoxFields.Controls.Add(this.labelPrice);
            this.groupBoxFields.Controls.Add(this.textQuantity);
            this.groupBoxFields.Controls.Add(this.labelQuantity);
            this.groupBoxFields.Controls.Add(this.comboUnit);
            this.groupBoxFields.Controls.Add(this.labelUnit);
            this.groupBoxFields.Controls.Add(this.comboProductType);
            this.groupBoxFields.Controls.Add(this.labelProductType);
            this.groupBoxFields.Controls.Add(this.textProductName);
            this.groupBoxFields.Controls.Add(this.labelProductName);
            this.groupBoxFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFields.Location = new System.Drawing.Point(856, 49);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Size = new System.Drawing.Size(279, 374);
            this.groupBoxFields.TabIndex = 1;
            this.groupBoxFields.TabStop = false;
            this.groupBoxFields.Text = "Properties";
            // 
            // groupBoxID
            // 
            this.groupBoxID.Controls.Add(this.labelID);
            this.groupBoxID.Location = new System.Drawing.Point(13, 17);
            this.groupBoxID.Name = "groupBoxID";
            this.groupBoxID.Size = new System.Drawing.Size(48, 56);
            this.groupBoxID.TabIndex = 13;
            this.groupBoxID.TabStop = false;
            this.groupBoxID.Text = "ID";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelID.Location = new System.Drawing.Point(6, 24);
            this.labelID.Name = "ID";
            this.labelID.Size = new System.Drawing.Size(32, 18);
            this.labelID.TabIndex = 0;
            this.labelID.Text = " ";
            // 
            // textDescription
            // 
            this.textDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescription.Location = new System.Drawing.Point(11, 213);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(240, 100);
            this.textDescription.TabIndex = 12;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(7, 190);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(91, 18);
            this.labelDescription.TabIndex = 10;
            this.labelDescription.Text = "Description :";
            // 
            // textPrice
            // 
            this.textPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrice.Location = new System.Drawing.Point(61, 153);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(89, 24);
            this.textPrice.TabIndex = 9;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(7, 156);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(50, 18);
            this.labelPrice.TabIndex = 8;
            this.labelPrice.Text = "Price :";
            // 
            // textQuantity
            // 
            this.textQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuantity.Location = new System.Drawing.Point(87, 116);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(48, 24);
            this.textQuantity.TabIndex = 7;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantity.Location = new System.Drawing.Point(5, 117);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(90, 18);
            this.labelQuantity.TabIndex = 6;
            this.labelQuantity.Text = "Quantity :";
            // 
            // comboUnit
            // 
            this.comboUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Location = new System.Drawing.Point(200, 152);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(78, 26);
            this.comboUnit.TabIndex = 5;
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnit.Location = new System.Drawing.Point(155, 155);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(42, 18);
            this.labelUnit.TabIndex = 4;
            this.labelUnit.Text = "Unit :";
            // 
            // comboProductType
            // 
            this.comboProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProductType.FormattingEnabled = true;
            this.comboProductType.Location = new System.Drawing.Point(74, 80);
            this.comboProductType.Name = "comboProductType";
            this.comboProductType.Size = new System.Drawing.Size(154, 26);
            this.comboProductType.TabIndex = 3;
            // 
            // labelProductType
            // 
            this.labelProductType.AutoSize = true;
            this.labelProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductType.Location = new System.Drawing.Point(7, 83);
            this.labelProductType.Name = "labelProductType";
            this.labelProductType.Size = new System.Drawing.Size(104, 18);
            this.labelProductType.TabIndex = 2;
            this.labelProductType.Text = "Type :";
            // 
            // textProductName
            // 
            this.textProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProductName.Location = new System.Drawing.Point(74, 47);
            this.textProductName.Name = "textProductName";
            this.textProductName.Size = new System.Drawing.Size(194, 24);
            this.textProductName.TabIndex = 1;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(72, 24);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(112, 18);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Name :";
            this.labelProductName.Click += new System.EventHandler(this.labelProductName_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSave.Location = new System.Drawing.Point(990, 380);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 56);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.EnabledChanged += new System.EventHandler(this.buttonSave_EnabledChanged);
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.Location = new System.Drawing.Point(856, 380);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 56);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "UPDATE";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.EnabledChanged += new System.EventHandler(this.buttonUpdate_EnabledChanged);
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonClear
            // 
            

            this.buttonUpdate.BackColor = System.Drawing.Color.Red;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonClear.Location = new System.Drawing.Point(990, 450);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 56);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.Location = new System.Drawing.Point(856, 450);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 56);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.EnabledChanged += new System.EventHandler(this.buttonDelete_EnabledChanged);
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(43, 13);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(252, 25);
            this.labelHeader.TabIndex = 6;
            this.labelHeader.Text = "DATABASE";
            this.labelHeader.Click += new System.EventHandler(this.labelHeader_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(300, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search :";
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(373, 12);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(340, 26);
            this.textSearch.TabIndex = 15;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1149, 562);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxFields);
            this.Controls.Add(this.dataGridProducts);
            this.Name = "Form1";
            this.Text = "Inventory Track";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.groupBoxFields.ResumeLayout(false);
            this.groupBoxFields.PerformLayout();
            this.groupBoxID.ResumeLayout(false);
            this.groupBoxID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.GroupBox groupBoxFields;
        private System.Windows.Forms.Label labelProductType;
        private System.Windows.Forms.TextBox textProductName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.ComboBox comboProductType;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.GroupBox groupBoxID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSearch;
    }
}

