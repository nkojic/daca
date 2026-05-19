namespace WpfAmsterdam
{
    partial class DlgPlacanje
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
            this.btnKes = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnKartica = new System.Windows.Forms.Button();
            this.btnRacun = new System.Windows.Forms.Button();
            this.btnTek = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblPopust = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdArtikal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeoPorcije1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Komada1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JedMere1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cena1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPodela = new System.Windows.Forms.Button();
            this.btnNova = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnKalk = new System.Windows.Forms.Button();
            this.btnGoreDole = new System.Windows.Forms.Button();
            this.tbSuma = new System.Windows.Forms.TextBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.NacinPlacanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potpis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIdIme = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // btnNE
            //
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(700, 299);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 4;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            //
            // btnDA
            //
            this.btnDA.BackColor = System.Drawing.Color.Red;
            this.btnDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDA.ForeColor = System.Drawing.Color.White;
            this.btnDA.Location = new System.Drawing.Point(797, 299);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 3;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // btnKes
            //
            this.btnKes.BackColor = System.Drawing.Color.OrangeRed;
            this.btnKes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKes.ForeColor = System.Drawing.Color.White;
            this.btnKes.Location = new System.Drawing.Point(455, 79);
            this.btnKes.Name = "btnKes";
            this.btnKes.Size = new System.Drawing.Size(88, 65);
            this.btnKes.TabIndex = 8;
            this.btnKes.Text = "Pazar";
            this.btnKes.UseVisualStyleBackColor = false;
            this.btnKes.Click += new System.EventHandler(this.btnKes_Click);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(455, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 65);
            this.Label1.TabIndex = 6;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnKartica
            //
            this.btnKartica.BackColor = System.Drawing.Color.OrangeRed;
            this.btnKartica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKartica.ForeColor = System.Drawing.Color.White;
            this.btnKartica.Location = new System.Drawing.Point(455, 154);
            this.btnKartica.Name = "btnKartica";
            this.btnKartica.Size = new System.Drawing.Size(88, 65);
            this.btnKartica.TabIndex = 10;
            this.btnKartica.Text = "Kartica";
            this.btnKartica.UseVisualStyleBackColor = false;
            this.btnKartica.Click += new System.EventHandler(this.btnKes_Click);
            //
            // btnRacun
            //
            this.btnRacun.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRacun.ForeColor = System.Drawing.Color.White;
            this.btnRacun.Location = new System.Drawing.Point(455, 229);
            this.btnRacun.Name = "btnRacun";
            this.btnRacun.Size = new System.Drawing.Size(88, 65);
            this.btnRacun.TabIndex = 11;
            this.btnRacun.Text = "Račun";
            this.btnRacun.UseVisualStyleBackColor = false;
            this.btnRacun.Click += new System.EventHandler(this.btnKes_Click);
            //
            // btnTek
            //
            this.btnTek.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTek.ForeColor = System.Drawing.Color.White;
            this.btnTek.Location = new System.Drawing.Point(455, 303);
            this.btnTek.Name = "btnTek";
            this.btnTek.Size = new System.Drawing.Size(88, 65);
            this.btnTek.TabIndex = 13;
            this.btnTek.Text = "Tekući";
            this.btnTek.UseVisualStyleBackColor = false;
            this.btnTek.Click += new System.EventHandler(this.btnTek_Click);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(549, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(339, 31);
            this.Label3.TabIndex = 15;
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // RichTextBox1
            //
            this.RichTextBox1.Location = new System.Drawing.Point(13, 337);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(437, 30);
            this.RichTextBox1.TabIndex = 18;
            this.RichTextBox1.Text = "";
            //
            // lblPopust
            //
            this.lblPopust.BackColor = System.Drawing.Color.Transparent;
            this.lblPopust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopust.ForeColor = System.Drawing.Color.Black;
            this.lblPopust.Location = new System.Drawing.Point(191, 266);
            this.lblPopust.Name = "lblPopust";
            this.lblPopust.Size = new System.Drawing.Size(88, 34);
            this.lblPopust.TabIndex = 19;
            this.lblPopust.Text = "Popust %";
            this.lblPopust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(13, 266);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(170, 34);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Iznos";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(285, 266);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(165, 34);
            this.Label5.TabIndex = 22;
            this.Label5.Text = "Ukupno";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Red;
            this.Label6.Location = new System.Drawing.Point(13, 303);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(170, 29);
            this.Label6.TabIndex = 23;
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Red;
            this.Label7.Location = new System.Drawing.Point(285, 303);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(165, 29);
            this.Label7.TabIndex = 24;
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DataGridView2
            //
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdArtikal1,
            this.DeoPorcije1,
            this.Komada1,
            this.JedMere1,
            this.Cena1,
            this.Ukupno1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView2.Location = new System.Drawing.Point(3, 11);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView2.RowHeadersWidth = 11;
            this.DataGridView2.Size = new System.Drawing.Size(446, 252);
            this.DataGridView2.TabIndex = 25;
            //
            // Id
            //
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 30;
            //
            // IdArtikal1
            //
            this.IdArtikal1.DataPropertyName = "ImeArtikal";
            this.IdArtikal1.HeaderText = "Artikal";
            this.IdArtikal1.Name = "IdArtikal1";
            this.IdArtikal1.ReadOnly = true;
            this.IdArtikal1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdArtikal1.Width = 170;
            //
            // DeoPorcije1
            //
            this.DeoPorcije1.DataPropertyName = "DeoPorcije";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeoPorcije1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DeoPorcije1.HeaderText = "deo";
            this.DeoPorcije1.Name = "DeoPorcije1";
            this.DeoPorcije1.ReadOnly = true;
            this.DeoPorcije1.Width = 40;
            //
            // Komada1
            //
            this.Komada1.DataPropertyName = "Komada";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Komada1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Komada1.HeaderText = "kom";
            this.Komada1.Name = "Komada1";
            this.Komada1.ReadOnly = true;
            this.Komada1.Width = 40;
            //
            // JedMere1
            //
            this.JedMere1.DataPropertyName = "JedMere";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JedMere1.DefaultCellStyle = dataGridViewCellStyle7;
            this.JedMere1.HeaderText = "jm.";
            this.JedMere1.Name = "JedMere1";
            this.JedMere1.ReadOnly = true;
            this.JedMere1.Width = 40;
            //
            // Cena1
            //
            this.Cena1.DataPropertyName = "Cena";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.Cena1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Cena1.HeaderText = "cena";
            this.Cena1.Name = "Cena1";
            this.Cena1.ReadOnly = true;
            this.Cena1.Width = 50;
            //
            // Ukupno1
            //
            this.Ukupno1.DataPropertyName = "Ukupno";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.Ukupno1.DefaultCellStyle = dataGridViewCellStyle9;
            this.Ukupno1.HeaderText = "Uk.";
            this.Ukupno1.Name = "Ukupno1";
            this.Ukupno1.ReadOnly = true;
            this.Ukupno1.Width = 60;
            //
            // btnPodela
            //
            this.btnPodela.BackColor = System.Drawing.Color.Red;
            this.btnPodela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPodela.ForeColor = System.Drawing.Color.White;
            this.btnPodela.Location = new System.Drawing.Point(552, 303);
            this.btnPodela.Name = "btnPodela";
            this.btnPodela.Size = new System.Drawing.Size(88, 65);
            this.btnPodela.TabIndex = 26;
            this.btnPodela.Text = "podela računa";
            this.btnPodela.UseVisualStyleBackColor = false;
            this.btnPodela.Click += new System.EventHandler(this.btnPodela_Click);
            //
            // btnNova
            //
            this.btnNova.BackColor = System.Drawing.Color.Green;
            this.btnNova.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNova.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNova.ForeColor = System.Drawing.Color.White;
            this.btnNova.Location = new System.Drawing.Point(3, 74);
            this.btnNova.Name = "btnNova";
            this.btnNova.Size = new System.Drawing.Size(88, 65);
            this.btnNova.TabIndex = 27;
            this.btnNova.UseVisualStyleBackColor = false;
            this.btnNova.Click += new System.EventHandler(this.btnNova_Click);
            //
            // Panel2
            //
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.btnKalk);
            this.Panel2.Controls.Add(this.btnGoreDole);
            this.Panel2.Controls.Add(this.tbSuma);
            this.Panel2.Controls.Add(this.DataGridView1);
            this.Panel2.Controls.Add(this.btnObrisi);
            this.Panel2.Controls.Add(this.btnNova);
            this.Panel2.Location = new System.Drawing.Point(549, 79);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(339, 214);
            this.Panel2.TabIndex = 28;
            //
            // btnKalk
            //
            this.btnKalk.BackColor = System.Drawing.Color.Blue;
            this.btnKalk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKalk.ForeColor = System.Drawing.Color.White;
            this.btnKalk.Location = new System.Drawing.Point(97, 145);
            this.btnKalk.Name = "btnKalk";
            this.btnKalk.Size = new System.Drawing.Size(88, 65);
            this.btnKalk.TabIndex = 33;
            this.btnKalk.UseVisualStyleBackColor = false;
            this.btnKalk.Click += new System.EventHandler(this.btnKalk_Click);
            //
            // btnGoreDole
            //
            this.btnGoreDole.BackColor = System.Drawing.Color.Blue;
            this.btnGoreDole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGoreDole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoreDole.ForeColor = System.Drawing.Color.White;
            this.btnGoreDole.Location = new System.Drawing.Point(3, 3);
            this.btnGoreDole.Name = "btnGoreDole";
            this.btnGoreDole.Size = new System.Drawing.Size(88, 65);
            this.btnGoreDole.TabIndex = 32;
            this.btnGoreDole.UseVisualStyleBackColor = false;
            this.btnGoreDole.Click += new System.EventHandler(this.btnGoreDole_Click);
            //
            // tbSuma
            //
            this.tbSuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSuma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSuma.ForeColor = System.Drawing.Color.Red;
            this.tbSuma.Location = new System.Drawing.Point(188, 145);
            this.tbSuma.Name = "tbSuma";
            this.tbSuma.Size = new System.Drawing.Size(148, 29);
            this.tbSuma.TabIndex = 31;
            this.tbSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // DataGridView1
            //
            this.DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Bisque;
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NacinPlacanja,
            this.Iznos,
            this.Potpis,
            this.dgcIdIme});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            this.DataGridView1.Location = new System.Drawing.Point(94, 3);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.DataGridView1.Name = "DataGridView1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowHeadersWidth = 11;
            this.DataGridView1.Size = new System.Drawing.Size(242, 136);
            this.DataGridView1.TabIndex = 30;
            //
            // btnObrisi
            //
            this.btnObrisi.BackColor = System.Drawing.Color.Red;
            this.btnObrisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.White;
            this.btnObrisi.Location = new System.Drawing.Point(3, 145);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(88, 65);
            this.btnObrisi.TabIndex = 28;
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            //
            // Button1
            //
            this.Button1.BackColor = System.Drawing.Color.Red;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(191, 303);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(88, 29);
            this.Button1.TabIndex = 29;
            this.Button1.Text = "0";
            this.Button1.UseVisualStyleBackColor = false;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(549, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(339, 31);
            this.Label2.TabIndex = 30;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // NacinPlacanja
            //
            this.NacinPlacanja.DataPropertyName = "NacinPlacanja";
            this.NacinPlacanja.HeaderText = "Tip";
            this.NacinPlacanja.Name = "NacinPlacanja";
            this.NacinPlacanja.Width = 47;
            //
            // Iznos
            //
            this.Iznos.DataPropertyName = "Iznos";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            this.Iznos.DefaultCellStyle = dataGridViewCellStyle14;
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.Width = 57;
            //
            // Potpis
            //
            this.Potpis.DataPropertyName = "Potpis";
            this.Potpis.HeaderText = "Potpis";
            this.Potpis.Name = "Potpis";
            this.Potpis.Width = 61;
            //
            // dgcIdIme
            //
            this.dgcIdIme.DataPropertyName = "IdIme";
            this.dgcIdIme.DisplayStyleForCurrentCellOnly = true;
            this.dgcIdIme.HeaderText = "Korisnik";
            this.dgcIdIme.Name = "dgcIdIme";
            this.dgcIdIme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIdIme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIdIme.Width = 69;
            //
            // DlgPlacanje
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 378);
            this.ControlBox = true;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.btnPodela);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblPopust);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnTek);
            this.Controls.Add(this.btnRacun);
            this.Controls.Add(this.btnKartica);
            this.Controls.Add(this.btnKes);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.DoubleBuffered = true;
            this.Name = "DlgPlacanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgPlacanje";
            this.Load += new System.EventHandler(this.dlgPlacanje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
        private System.Windows.Forms.Button btnKes;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnKartica;
        private System.Windows.Forms.Button btnRacun;
        private System.Windows.Forms.Button btnTek;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.RichTextBox RichTextBox1;
        private System.Windows.Forms.Label lblPopust;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.DataGridView DataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArtikal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeoPorcije1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Komada1;
        private System.Windows.Forms.DataGridViewTextBoxColumn JedMere1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cena1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ukupno1;
        private System.Windows.Forms.Button btnPodela;
        private System.Windows.Forms.Button btnNova;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button btnKalk;
        private System.Windows.Forms.Button btnGoreDole;
        private System.Windows.Forms.TextBox tbSuma;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NacinPlacanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potpis;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIdIme;
    }
}
