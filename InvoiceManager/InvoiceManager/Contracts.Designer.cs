namespace InvoiceManager
{
    partial class Contracts
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
            if (disposing && (components != null))
            {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChanchedContrat = new System.Windows.Forms.Button();
            this.SaveContract = new System.Windows.Forms.Button();
            this.deleteContract = new System.Windows.Forms.Button();
            this.ADDContract = new System.Windows.Forms.Button();
            this.contractNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contractDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.selectClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.ChanchedContrat);
            this.groupBox1.Controls.Add(this.SaveContract);
            this.groupBox1.Controls.Add(this.deleteContract);
            this.groupBox1.Controls.Add(this.ADDContract);
            this.groupBox1.Controls.Add(this.contractNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.contractDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.selectClient);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.searchInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 481);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ChanchedContrat
            // 
            this.ChanchedContrat.Location = new System.Drawing.Point(15, 369);
            this.ChanchedContrat.Name = "ChanchedContrat";
            this.ChanchedContrat.Size = new System.Drawing.Size(197, 34);
            this.ChanchedContrat.TabIndex = 32;
            this.ChanchedContrat.Text = "Редагувати контракт";
            this.ChanchedContrat.UseVisualStyleBackColor = true;
            this.ChanchedContrat.Click += new System.EventHandler(this.ChanchedContrat_Click);
            // 
            // SaveContract
            // 
            this.SaveContract.Location = new System.Drawing.Point(15, 409);
            this.SaveContract.Name = "SaveContract";
            this.SaveContract.Size = new System.Drawing.Size(197, 34);
            this.SaveContract.TabIndex = 31;
            this.SaveContract.Text = "Зберегти";
            this.SaveContract.UseVisualStyleBackColor = true;
            this.SaveContract.Click += new System.EventHandler(this.SaveContract_Click);
            // 
            // deleteContract
            // 
            this.deleteContract.Location = new System.Drawing.Point(15, 329);
            this.deleteContract.Name = "deleteContract";
            this.deleteContract.Size = new System.Drawing.Size(197, 34);
            this.deleteContract.TabIndex = 30;
            this.deleteContract.Text = "Видалити контракт";
            this.deleteContract.UseVisualStyleBackColor = true;
            this.deleteContract.Click += new System.EventHandler(this.deleteContract_Click);
            // 
            // ADDContract
            // 
            this.ADDContract.Location = new System.Drawing.Point(15, 289);
            this.ADDContract.Name = "ADDContract";
            this.ADDContract.Size = new System.Drawing.Size(197, 34);
            this.ADDContract.TabIndex = 29;
            this.ADDContract.Text = "Додати контракт";
            this.ADDContract.UseVisualStyleBackColor = true;
            this.ADDContract.Click += new System.EventHandler(this.ADDContract_Click);
            // 
            // contractNumber
            // 
            this.contractNumber.Location = new System.Drawing.Point(15, 247);
            this.contractNumber.Name = "contractNumber";
            this.contractNumber.Size = new System.Drawing.Size(197, 20);
            this.contractNumber.TabIndex = 28;
            this.contractNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Номер договору";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Клієнт";
            // 
            // contractDate
            // 
            this.contractDate.CustomFormat = "dd.MM.yyyy";
            this.contractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.contractDate.Location = new System.Drawing.Point(15, 196);
            this.contractDate.Margin = new System.Windows.Forms.Padding(2);
            this.contractDate.Name = "contractDate";
            this.contractDate.Size = new System.Drawing.Size(197, 20);
            this.contractDate.TabIndex = 25;
            this.contractDate.Value = new System.DateTime(2025, 4, 13, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Дата договору";
            // 
            // selectClient
            // 
            this.selectClient.FormattingEnabled = true;
            this.selectClient.Location = new System.Drawing.Point(15, 146);
            this.selectClient.Name = "selectClient";
            this.selectClient.Size = new System.Drawing.Size(197, 21);
            this.selectClient.TabIndex = 22;
            this.selectClient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Контракти";
            // 
            // searchInput
            // 
            this.searchInput.Location = new System.Drawing.Point(15, 32);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(197, 20);
            this.searchInput.TabIndex = 1;
            this.searchInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchInput_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пошук";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(238, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(996, 481);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::InvoiceManager.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(15, 57);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Contracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1234, 481);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1050, 520);
            this.Name = "Contracts";
            this.Text = "Contracts";
            this.Load += new System.EventHandler(this.Contracts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectClient;
        private System.Windows.Forms.TextBox contractNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker contractDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteContract;
        private System.Windows.Forms.Button ADDContract;
        private System.Windows.Forms.Button ChanchedContrat;
        private System.Windows.Forms.Button SaveContract;
        private System.Windows.Forms.PictureBox btnRefresh;
    }
}