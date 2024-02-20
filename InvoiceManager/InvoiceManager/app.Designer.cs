namespace InvoiceManager
{
    partial class app
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(app));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolClient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.groupProduct = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.priceBread = new System.Windows.Forms.TextBox();
            this.nameBread = new System.Windows.Forms.TextBox();
            this.IDbread = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.groupClient = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNameComanyClient = new System.Windows.Forms.TextBox();
            this.txtPhoneClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIDClient = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPatronymicClient = new System.Windows.Forms.TextBox();
            this.txtNameClient = new System.Windows.Forms.TextBox();
            this.txtSurnameClient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnCreateClient = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupInvoice = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.selectClient = new System.Windows.Forms.ComboBox();
            this.txtIDInvoice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupProduct.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupClient.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.groupInvoice.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClient,
            this.toolProduct,
            this.toolInvoice,
            this.toolCreate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolClient
            // 
            this.toolClient.Name = "toolClient";
            this.toolClient.Size = new System.Drawing.Size(101, 31);
            this.toolClient.Text = "Клієнти";
            this.toolClient.Click += new System.EventHandler(this.toolClient_Click);
            // 
            // toolProduct
            // 
            this.toolProduct.Name = "toolProduct";
            this.toolProduct.Size = new System.Drawing.Size(99, 31);
            this.toolProduct.Text = "Товари";
            this.toolProduct.Click += new System.EventHandler(this.toolProduct_Click);
            // 
            // toolInvoice
            // 
            this.toolInvoice.Name = "toolInvoice";
            this.toolInvoice.Size = new System.Drawing.Size(116, 31);
            this.toolInvoice.Text = "Накладні";
            this.toolInvoice.Click += new System.EventHandler(this.toolInvoice_Click);
            // 
            // toolCreate
            // 
            this.toolCreate.Name = "toolCreate";
            this.toolCreate.Size = new System.Drawing.Size(221, 31);
            this.toolCreate.Text = "Створити накладну";
            this.toolCreate.Click += new System.EventHandler(this.toolCreate_Click);
            // 
            // groupProduct
            // 
            this.groupProduct.Controls.Add(this.groupBox2);
            this.groupProduct.Controls.Add(this.groupBox3);
            this.groupProduct.Location = new System.Drawing.Point(0, 130);
            this.groupProduct.Margin = new System.Windows.Forms.Padding(0);
            this.groupProduct.Name = "groupProduct";
            this.groupProduct.Padding = new System.Windows.Forms.Padding(0);
            this.groupProduct.Size = new System.Drawing.Size(1051, 320);
            this.groupProduct.TabIndex = 3;
            this.groupProduct.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.priceBread);
            this.groupBox2.Controls.Add(this.nameBread);
            this.groupBox2.Controls.Add(this.IDbread);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(40, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 259);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // priceBread
            // 
            this.priceBread.Location = new System.Drawing.Point(251, 165);
            this.priceBread.Name = "priceBread";
            this.priceBread.Size = new System.Drawing.Size(197, 22);
            this.priceBread.TabIndex = 6;
            // 
            // nameBread
            // 
            this.nameBread.Location = new System.Drawing.Point(251, 125);
            this.nameBread.Name = "nameBread";
            this.nameBread.Size = new System.Drawing.Size(197, 22);
            this.nameBread.TabIndex = 5;
            // 
            // IDbread
            // 
            this.IDbread.Location = new System.Drawing.Point(251, 85);
            this.IDbread.Name = "IDbread";
            this.IDbread.ReadOnly = true;
            this.IDbread.Size = new System.Drawing.Size(197, 22);
            this.IDbread.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(155, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ціна";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(155, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Назва";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(155, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InvoiceManager.Properties.Resources.bread;
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.btnChange);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(644, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(329, 247);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  Панель курування";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(96, 193);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "Зберегти";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChange.Location = new System.Drawing.Point(96, 144);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(162, 38);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Змінити";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(96, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Видалити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(96, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Додати товар";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1204, 415);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(781, 5);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(116, 22);
            this.txt_search.TabIndex = 5;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // groupClient
            // 
            this.groupClient.Controls.Add(this.groupBox4);
            this.groupClient.Controls.Add(this.groupBox5);
            this.groupClient.Location = new System.Drawing.Point(291, 103);
            this.groupClient.Margin = new System.Windows.Forms.Padding(0);
            this.groupClient.Name = "groupClient";
            this.groupClient.Padding = new System.Windows.Forms.Padding(0);
            this.groupClient.Size = new System.Drawing.Size(965, 320);
            this.groupClient.TabIndex = 4;
            this.groupClient.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNameComanyClient);
            this.groupBox4.Controls.Add(this.txtPhoneClient);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtIDClient);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtPatronymicClient);
            this.groupBox4.Controls.Add(this.txtNameClient);
            this.groupBox4.Controls.Add(this.txtSurnameClient);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Location = new System.Drawing.Point(40, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 280);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txtNameComanyClient
            // 
            this.txtNameComanyClient.Location = new System.Drawing.Point(351, 239);
            this.txtNameComanyClient.Name = "txtNameComanyClient";
            this.txtNameComanyClient.Size = new System.Drawing.Size(197, 22);
            this.txtNameComanyClient.TabIndex = 14;
            // 
            // txtPhoneClient
            // 
            this.txtPhoneClient.Location = new System.Drawing.Point(351, 199);
            this.txtPhoneClient.Name = "txtPhoneClient";
            this.txtPhoneClient.Size = new System.Drawing.Size(197, 22);
            this.txtPhoneClient.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(155, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Назва компанії";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(155, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Телефон";
            // 
            // txtIDClient
            // 
            this.txtIDClient.Location = new System.Drawing.Point(351, 37);
            this.txtIDClient.Name = "txtIDClient";
            this.txtIDClient.ReadOnly = true;
            this.txtIDClient.Size = new System.Drawing.Size(197, 22);
            this.txtIDClient.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(155, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "ID";
            // 
            // txtPatronymicClient
            // 
            this.txtPatronymicClient.Location = new System.Drawing.Point(351, 159);
            this.txtPatronymicClient.Name = "txtPatronymicClient";
            this.txtPatronymicClient.Size = new System.Drawing.Size(197, 22);
            this.txtPatronymicClient.TabIndex = 6;
            // 
            // txtNameClient
            // 
            this.txtNameClient.Location = new System.Drawing.Point(351, 119);
            this.txtNameClient.Name = "txtNameClient";
            this.txtNameClient.Size = new System.Drawing.Size(197, 22);
            this.txtNameClient.TabIndex = 5;
            // 
            // txtSurnameClient
            // 
            this.txtSurnameClient.Location = new System.Drawing.Point(351, 79);
            this.txtSurnameClient.Name = "txtSurnameClient";
            this.txtSurnameClient.Size = new System.Drawing.Size(197, 22);
            this.txtSurnameClient.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(155, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "По батькові";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(155, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ім\'я";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(155, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Прізвище";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InvoiceManager.Properties.Resources.client;
            this.pictureBox2.Location = new System.Drawing.Point(6, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.btnCreateClient);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(644, 33);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(329, 268);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "  Панель курування";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(96, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "Зберегти";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(96, 144);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 38);
            this.button5.TabIndex = 2;
            this.button5.Text = "Змінити";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(96, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 38);
            this.button6.TabIndex = 1;
            this.button6.Text = "Видалити";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreateClient
            // 
            this.btnCreateClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateClient.Location = new System.Drawing.Point(96, 47);
            this.btnCreateClient.Name = "btnCreateClient";
            this.btnCreateClient.Size = new System.Drawing.Size(162, 38);
            this.btnCreateClient.TabIndex = 0;
            this.btnCreateClient.Text = "Додати клієнта";
            this.btnCreateClient.UseVisualStyleBackColor = true;
            this.btnCreateClient.Click += new System.EventHandler(this.btnCreateClient_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::InvoiceManager.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(597, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 27);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(718, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Пошук:";
            // 
            // groupInvoice
            // 
            this.groupInvoice.Controls.Add(this.groupBox6);
            this.groupInvoice.Controls.Add(this.groupBox7);
            this.groupInvoice.Location = new System.Drawing.Point(86, 87);
            this.groupInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.groupInvoice.Name = "groupInvoice";
            this.groupInvoice.Padding = new System.Windows.Forms.Padding(0);
            this.groupInvoice.Size = new System.Drawing.Size(965, 320);
            this.groupInvoice.TabIndex = 5;
            this.groupInvoice.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateTimePicker1);
            this.groupBox6.Controls.Add(this.selectClient);
            this.groupBox6.Controls.Add(this.txtIDInvoice);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.pictureBox3);
            this.groupBox6.Location = new System.Drawing.Point(40, 21);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(571, 280);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(353, 167);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // selectClient
            // 
            this.selectClient.FormattingEnabled = true;
            this.selectClient.Location = new System.Drawing.Point(353, 127);
            this.selectClient.Name = "selectClient";
            this.selectClient.Size = new System.Drawing.Size(197, 24);
            this.selectClient.TabIndex = 25;
            this.selectClient.TextChanged += new System.EventHandler(this.selectClient_TextChanged);
            // 
            // txtIDInvoice
            // 
            this.txtIDInvoice.Location = new System.Drawing.Point(353, 85);
            this.txtIDInvoice.Name = "txtIDInvoice";
            this.txtIDInvoice.ReadOnly = true;
            this.txtIDInvoice.Size = new System.Drawing.Size(197, 22);
            this.txtIDInvoice.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(157, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "ID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(157, 169);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Дата";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(157, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Клієнт";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::InvoiceManager.Properties.Resources.invoice;
            this.pictureBox3.Location = new System.Drawing.Point(6, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(87, 79);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(644, 33);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox7.Size = new System.Drawing.Size(329, 268);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "  Панель курування";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(96, 169);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(162, 38);
            this.button7.TabIndex = 3;
            this.button7.Text = "Зберегти";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button4_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(96, 120);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(162, 38);
            this.button8.TabIndex = 2;
            this.button8.Text = "Змінити";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(96, 71);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(162, 38);
            this.button9.TabIndex = 1;
            this.button9.Text = "Видалити";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button2_Click);
            // 
            // app
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 450);
            this.Controls.Add(this.groupInvoice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupClient);
            this.Controls.Add(this.groupProduct);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "app";
            this.Text = "InvoiceManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.app_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupProduct.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupClient.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.groupInvoice.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolClient;
        private System.Windows.Forms.ToolStripMenuItem toolProduct;
        private System.Windows.Forms.ToolStripMenuItem toolInvoice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceBread;
        private System.Windows.Forms.TextBox nameBread;
        private System.Windows.Forms.TextBox IDbread;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.GroupBox groupProduct;
        private System.Windows.Forms.GroupBox groupClient;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPatronymicClient;
        private System.Windows.Forms.TextBox txtNameClient;
        private System.Windows.Forms.TextBox txtSurnameClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnCreateClient;
        private System.Windows.Forms.TextBox txtNameComanyClient;
        private System.Windows.Forms.TextBox txtPhoneClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIDClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem toolCreate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupInvoice;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtIDInvoice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox selectClient;
    }
}