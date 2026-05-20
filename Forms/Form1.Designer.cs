namespace WpfAmsterdam
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnZatvoriSto = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdArtikal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ArtikliBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DsArtikli = new WpfAmsterdam.DsArtikli();
            this.DeoPorcije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Komada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JedMere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnPrebaci = new System.Windows.Forms.Button();
            this.lblSuma = new System.Windows.Forms.Label();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.KategorijaDataGridView = new System.Windows.Forms.DataGridView();
            this.btnKat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.KategorijaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.flPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnUpisi = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.btnCena = new System.Windows.Forms.Button();
            this.lblCena = new System.Windows.Forms.Label();
            this.lblJM = new System.Windows.Forms.Label();
            this.btnDeo = new System.Windows.Forms.Button();
            this.lblDeo = new System.Windows.Forms.Label();
            this.btnKomada = new System.Windows.Forms.Button();
            this.lblKomada = new System.Windows.Forms.Label();
            this.flPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.KategorijaTableAdapter = new WpfAmsterdam.KategorijaTableAdapter();
            this.Kategorija1TableAdapter = new WpfAmsterdam.Kategorija1TableAdapter();
            this.ArtikliTableAdapter = new WpfAmsterdam.ArtikliTableAdapter();
            this.btnRacun = new System.Windows.Forms.Button();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdArtikal1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DeoPorcije1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Komada1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JedMere1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cena1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikliBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsArtikli)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KategorijaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KategorijaBindingSource)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            //
            // btnZatvoriSto
            //
            this.btnZatvoriSto.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnZatvoriSto.BackColor = System.Drawing.Color.Red;
            this.btnZatvoriSto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.btnZatvoriSto.ForeColor = System.Drawing.Color.White;
            this.btnZatvoriSto.Location = new System.Drawing.Point(924, 1);
            this.btnZatvoriSto.Name = "btnZatvoriSto";
            this.btnZatvoriSto.Size = new System.Drawing.Size(94, 62);
            this.btnZatvoriSto.TabIndex = 0;
            this.btnZatvoriSto.Text = "Zatvori sto";
            this.btnZatvoriSto.UseVisualStyleBackColor = false;
            this.btnZatvoriSto.Click += new System.EventHandler(this.btnZatvoriSto_Click);
            //
            // DataGridView1
            //
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToOrderColumns = true;
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            this.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Id, this.IdArtikal, this.DeoPorcije, this.Komada, this.JedMere, this.Cena, this.Ukupno });
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersWidth = 11;
            this.DataGridView1.Size = new System.Drawing.Size(150, 120);
            this.DataGridView1.TabIndex = 1;
            //
            // Id
            //
            this.Id.DataPropertyName = "Id";
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = DataGridViewCellStyle2;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            //
            // IdArtikal
            //
            this.IdArtikal.DataPropertyName = "IdArtikal";
            this.IdArtikal.DataSource = this.ArtikliBindingSource1;
            this.IdArtikal.DisplayMember = "NazivKasa";
            this.IdArtikal.DisplayStyleForCurrentCellOnly = true;
            this.IdArtikal.HeaderText = "Artikal";
            this.IdArtikal.Name = "IdArtikal";
            this.IdArtikal.ReadOnly = true;
            this.IdArtikal.ValueMember = "IdArtikal";
            this.IdArtikal.Width = 170;
            //
            // ArtikliBindingSource1
            //
            this.ArtikliBindingSource1.DataMember = "Artikli";
            this.ArtikliBindingSource1.DataSource = this.DsArtikli;
            //
            // DsArtikli
            //
            this.DsArtikli.DataSetName = "dsArtikli";
            //
            // DeoPorcije
            //
            this.DeoPorcije.DataPropertyName = "DeoPorcije";
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeoPorcije.DefaultCellStyle = DataGridViewCellStyle3;
            this.DeoPorcije.HeaderText = "deo";
            this.DeoPorcije.Name = "DeoPorcije";
            this.DeoPorcije.ReadOnly = true;
            this.DeoPorcije.Width = 40;
            //
            // Komada
            //
            this.Komada.DataPropertyName = "Komada";
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Komada.DefaultCellStyle = DataGridViewCellStyle4;
            this.Komada.HeaderText = "kom.";
            this.Komada.Name = "Komada";
            this.Komada.ReadOnly = true;
            this.Komada.Width = 50;
            //
            // JedMere
            //
            this.JedMere.DataPropertyName = "JedMere";
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JedMere.DefaultCellStyle = DataGridViewCellStyle5;
            this.JedMere.HeaderText = "jm.";
            this.JedMere.Name = "JedMere";
            this.JedMere.ReadOnly = true;
            this.JedMere.Width = 40;
            //
            // Cena
            //
            this.Cena.DataPropertyName = "Cena";
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            DataGridViewCellStyle6.Format = "N0";
            DataGridViewCellStyle6.NullValue = "0";
            this.Cena.DefaultCellStyle = DataGridViewCellStyle6;
            this.Cena.HeaderText = "cena";
            this.Cena.Name = "Cena";
            this.Cena.ReadOnly = true;
            this.Cena.Width = 60;
            //
            // Ukupno
            //
            this.Ukupno.DataPropertyName = "Ukupno";
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle7.Format = "N0";
            DataGridViewCellStyle7.NullValue = "0";
            this.Ukupno.DefaultCellStyle = DataGridViewCellStyle7;
            this.Ukupno.HeaderText = "Uk.";
            this.Ukupno.Name = "Ukupno";
            this.Ukupno.ReadOnly = true;
            this.Ukupno.Width = 60;
            //
            // SplitContainer2
            //
            this.SplitContainer2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.SplitContainer2.Location = new System.Drawing.Point(873, 65);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // SplitContainer2.Panel1
            //
            this.SplitContainer2.Panel1.Controls.Add(this.DataGridView1);
            //
            // SplitContainer2.Panel2
            //
            this.SplitContainer2.Panel2.Controls.Add(this.btnPrebaci);
            this.SplitContainer2.Panel2.Controls.Add(this.lblSuma);
            this.SplitContainer2.Panel2.Controls.Add(this.DataGridView2);
            this.SplitContainer2.Panel2.Controls.Add(this.rtb1);
            this.SplitContainer2.Size = new System.Drawing.Size(150, 479);
            this.SplitContainer2.SplitterDistance = 120;
            this.SplitContainer2.TabIndex = 0;
            //
            // btnPrebaci
            //
            this.btnPrebaci.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnPrebaci.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrebaci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrebaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnPrebaci.ForeColor = System.Drawing.Color.White;
            this.btnPrebaci.Location = new System.Drawing.Point(28, 276);
            this.btnPrebaci.Name = "btnPrebaci";
            this.btnPrebaci.Size = new System.Drawing.Size(119, 74);
            this.btnPrebaci.TabIndex = 14;
            this.btnPrebaci.UseVisualStyleBackColor = false;
            this.btnPrebaci.Click += new System.EventHandler(this.btnPrebaci_Click);
            //
            // lblSuma
            //
            this.lblSuma.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.lblSuma.BackColor = System.Drawing.Color.Gold;
            this.lblSuma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblSuma.ForeColor = System.Drawing.Color.Black;
            this.lblSuma.Location = new System.Drawing.Point(0, 276);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Size = new System.Drawing.Size(22, 36);
            this.lblSuma.TabIndex = 13;
            this.lblSuma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DataGridView2
            //
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.AllowUserToOrderColumns = true;
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
            this.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8;
            this.DataGridView2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Id1, this.IdArtikal1, this.DeoPorcije1, this.Komada1, this.JedMere1, this.Cena1, this.Ukupno1, this.vreme });
            this.DataGridView2.Location = new System.Drawing.Point(0, 3);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.RowHeadersWidth = 11;
            this.DataGridView2.Size = new System.Drawing.Size(150, 267);
            this.DataGridView2.TabIndex = 0;
            //
            // rtb1
            //
            this.rtb1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.rtb1.Location = new System.Drawing.Point(0, 315);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(22, 35);
            this.rtb1.TabIndex = 16;
            this.rtb1.Text = "";
            //
            // KategorijaDataGridView
            //
            this.KategorijaDataGridView.AllowUserToAddRows = false;
            this.KategorijaDataGridView.AllowUserToDeleteRows = false;
            this.KategorijaDataGridView.AllowUserToResizeColumns = false;
            this.KategorijaDataGridView.AllowUserToResizeRows = false;
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.BurlyWood;
            this.KategorijaDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15;
            this.KategorijaDataGridView.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.KategorijaDataGridView.AutoGenerateColumns = false;
            this.KategorijaDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.KategorijaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KategorijaDataGridView.ColumnHeadersVisible = false;
            this.KategorijaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.btnKat });
            this.KategorijaDataGridView.DataSource = this.KategorijaBindingSource;
            this.KategorijaDataGridView.Location = new System.Drawing.Point(2, 8);
            this.KategorijaDataGridView.Name = "KategorijaDataGridView";
            this.KategorijaDataGridView.RowHeadersVisible = false;
            this.KategorijaDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.SaddleBrown;
            this.KategorijaDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.KategorijaDataGridView.RowTemplate.Height = 70;
            this.KategorijaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.KategorijaDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.KategorijaDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KategorijaDataGridView.RowTemplate.ReadOnly = true;
            this.KategorijaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.KategorijaDataGridView.Size = new System.Drawing.Size(130, 536);
            this.KategorijaDataGridView.TabIndex = 0;
            this.KategorijaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KategorijaDataGridView_CellContentClick);
            //
            // btnKat
            //
            this.btnKat.DataPropertyName = "Kategorija";
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.btnKat.DefaultCellStyle = DataGridViewCellStyle16;
            this.btnKat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKat.HeaderText = "Kategorija";
            this.btnKat.Name = "btnKat";
            this.btnKat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnKat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnKat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.btnKat.Width = 126;
            //
            // KategorijaBindingSource
            //
            this.KategorijaBindingSource.DataMember = "Kategorija";
            this.KategorijaBindingSource.DataSource = this.DsArtikli;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(107, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(185, 60);
            this.Label1.TabIndex = 3;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // flPanel2
            //
            this.flPanel2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.flPanel2.AutoScroll = true;
            this.flPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flPanel2.Location = new System.Drawing.Point(427, 67);
            this.flPanel2.Name = "flPanel2";
            this.flPanel2.Size = new System.Drawing.Size(478, 477);
            this.flPanel2.TabIndex = 15;
            //
            // Button1
            //
            this.Button1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.Button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(644, 1);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(79, 65);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "--";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            //
            // btnUpisi
            //
            this.btnUpisi.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnUpisi.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnUpisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpisi.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.btnUpisi.ForeColor = System.Drawing.Color.White;
            this.btnUpisi.Text = "Upiši";
            this.btnUpisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpisi.FlatAppearance.BorderSize = 0;
            this.btnUpisi.Location = new System.Drawing.Point(729, 2);
            this.btnUpisi.Name = "btnUpisi";
            this.btnUpisi.Size = new System.Drawing.Size(90, 62);
            this.btnUpisi.TabIndex = 13;
            this.btnUpisi.UseVisualStyleBackColor = false;
            this.btnUpisi.Click += new System.EventHandler(this.btnUpisi_Click);
            //
            // Label2
            //
            this.Label2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.Label2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(298, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(248, 60);
            this.Label2.TabIndex = 4;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUkupno
            //
            this.lblUkupno.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblUkupno.BackColor = System.Drawing.Color.Gold;
            this.lblUkupno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblUkupno.ForeColor = System.Drawing.Color.Black;
            this.lblUkupno.Location = new System.Drawing.Point(193, 90);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(90, 74);
            this.lblUkupno.TabIndex = 12;
            this.lblUkupno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnPonisti
            //
            this.btnPonisti.BackColor = System.Drawing.SystemColors.Control;
            this.btnPonisti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPonisti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnPonisti.ForeColor = System.Drawing.Color.White;
            this.btnPonisti.Location = new System.Drawing.Point(193, 170);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(90, 74);
            this.btnPonisti.TabIndex = 15;
            this.btnPonisti.UseVisualStyleBackColor = false;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            //
            // btnCena
            //
            this.btnCena.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnCena.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnCena.ForeColor = System.Drawing.Color.White;
            this.btnCena.Location = new System.Drawing.Point(1, 170);
            this.btnCena.Name = "btnCena";
            this.btnCena.Size = new System.Drawing.Size(90, 74);
            this.btnCena.TabIndex = 11;
            this.btnCena.Text = "cena";
            this.btnCena.UseVisualStyleBackColor = false;
            this.btnCena.Click += new System.EventHandler(this.btnCena_Click);
            //
            // lblCena
            //
            this.lblCena.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.lblCena.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblCena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblCena.ForeColor = System.Drawing.Color.White;
            this.lblCena.Location = new System.Drawing.Point(97, 170);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(90, 74);
            this.lblCena.TabIndex = 10;
            this.lblCena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblJM
            //
            this.lblJM.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.lblJM.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblJM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblJM.ForeColor = System.Drawing.Color.White;
            this.lblJM.Location = new System.Drawing.Point(193, 10);
            this.lblJM.Name = "lblJM";
            this.lblJM.Size = new System.Drawing.Size(90, 74);
            this.lblJM.TabIndex = 9;
            this.lblJM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnDeo
            //
            this.btnDeo.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnDeo.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnDeo.ForeColor = System.Drawing.Color.White;
            this.btnDeo.Location = new System.Drawing.Point(2, 90);
            this.btnDeo.Name = "btnDeo";
            this.btnDeo.Size = new System.Drawing.Size(90, 74);
            this.btnDeo.TabIndex = 8;
            this.btnDeo.Text = "deo porcije";
            this.btnDeo.UseVisualStyleBackColor = false;
            this.btnDeo.Click += new System.EventHandler(this.btnDeo_Click);
            //
            // lblDeo
            //
            this.lblDeo.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.lblDeo.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblDeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblDeo.ForeColor = System.Drawing.Color.White;
            this.lblDeo.Location = new System.Drawing.Point(97, 90);
            this.lblDeo.Name = "lblDeo";
            this.lblDeo.Size = new System.Drawing.Size(90, 74);
            this.lblDeo.TabIndex = 7;
            this.lblDeo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnKomada
            //
            this.btnKomada.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnKomada.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnKomada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnKomada.ForeColor = System.Drawing.Color.White;
            this.btnKomada.Location = new System.Drawing.Point(2, 10);
            this.btnKomada.Name = "btnKomada";
            this.btnKomada.Size = new System.Drawing.Size(90, 74);
            this.btnKomada.TabIndex = 6;
            this.btnKomada.Text = "komada";
            this.btnKomada.UseVisualStyleBackColor = false;
            this.btnKomada.Click += new System.EventHandler(this.btnKomada_Click);
            //
            // lblKomada
            //
            this.lblKomada.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblKomada.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblKomada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKomada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblKomada.ForeColor = System.Drawing.Color.White;
            this.lblKomada.Location = new System.Drawing.Point(552, 4);
            this.lblKomada.Name = "lblKomada";
            this.lblKomada.Size = new System.Drawing.Size(86, 60);
            this.lblKomada.TabIndex = 5;
            this.lblKomada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // flPanel1
            //
            this.flPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.flPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flPanel1.Location = new System.Drawing.Point(138, 65);
            this.flPanel1.Name = "flPanel1";
            this.flPanel1.Size = new System.Drawing.Size(295, 234);
            this.flPanel1.TabIndex = 4;
            //
            // Panel2
            //
            this.Panel2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.btnPonisti);
            this.Panel2.Controls.Add(this.lblUkupno);
            this.Panel2.Controls.Add(this.lblJM);
            this.Panel2.Controls.Add(this.btnKomada);
            this.Panel2.Controls.Add(this.lblDeo);
            this.Panel2.Controls.Add(this.btnCena);
            this.Panel2.Controls.Add(this.btnDeo);
            this.Panel2.Controls.Add(this.lblCena);
            this.Panel2.Location = new System.Drawing.Point(105, 295);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(295, 249);
            this.Panel2.TabIndex = 0;
            //
            // btnRacun
            //
            this.btnRacun.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRacun.BackColor = System.Drawing.Color.Red;
            this.btnRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.btnRacun.ForeColor = System.Drawing.Color.White;
            this.btnRacun.Location = new System.Drawing.Point(825, 1);
            this.btnRacun.Name = "btnRacun";
            this.btnRacun.Size = new System.Drawing.Size(93, 62);
            this.btnRacun.TabIndex = 14;
            this.btnRacun.Text = "Račun";
            this.btnRacun.UseVisualStyleBackColor = false;
            this.btnRacun.Click += new System.EventHandler(this.btnRacun_Click);
            //
            // Id1
            //
            this.Id1.DataPropertyName = "Id";
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id1.DefaultCellStyle = DataGridViewCellStyle9;
            this.Id1.HeaderText = "Id";
            this.Id1.Name = "Id1";
            this.Id1.ReadOnly = true;
            this.Id1.Width = 40;
            //
            // IdArtikal1
            //
            this.IdArtikal1.DataPropertyName = "IdArtikal";
            this.IdArtikal1.DataSource = this.ArtikliBindingSource1;
            this.IdArtikal1.DisplayMember = "NazivKasa";
            this.IdArtikal1.DisplayStyleForCurrentCellOnly = true;
            this.IdArtikal1.HeaderText = "Artikal";
            this.IdArtikal1.Name = "IdArtikal1";
            this.IdArtikal1.ReadOnly = true;
            this.IdArtikal1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdArtikal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IdArtikal1.ValueMember = "IdArtikal";
            this.IdArtikal1.Width = 170;
            //
            // DeoPorcije1
            //
            this.DeoPorcije1.DataPropertyName = "DeoPorcije";
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeoPorcije1.DefaultCellStyle = DataGridViewCellStyle10;
            this.DeoPorcije1.HeaderText = "deo";
            this.DeoPorcije1.Name = "DeoPorcije1";
            this.DeoPorcije1.ReadOnly = true;
            this.DeoPorcije1.Width = 40;
            //
            // Komada1
            //
            this.Komada1.DataPropertyName = "Komada";
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Komada1.DefaultCellStyle = DataGridViewCellStyle11;
            this.Komada1.HeaderText = "kom";
            this.Komada1.Name = "Komada1";
            this.Komada1.ReadOnly = true;
            this.Komada1.Width = 50;
            //
            // JedMere1
            //
            this.JedMere1.DataPropertyName = "JedMere";
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JedMere1.DefaultCellStyle = DataGridViewCellStyle12;
            this.JedMere1.HeaderText = "jm.";
            this.JedMere1.Name = "JedMere1";
            this.JedMere1.ReadOnly = true;
            this.JedMere1.Width = 40;
            //
            // Cena1
            //
            this.Cena1.DataPropertyName = "Cena";
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle13.Format = "N0";
            DataGridViewCellStyle13.NullValue = "0";
            this.Cena1.DefaultCellStyle = DataGridViewCellStyle13;
            this.Cena1.HeaderText = "cena";
            this.Cena1.Name = "Cena1";
            this.Cena1.ReadOnly = true;
            this.Cena1.Width = 60;
            //
            // Ukupno1
            //
            this.Ukupno1.DataPropertyName = "Ukupno";
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle14.Format = "N0";
            DataGridViewCellStyle14.NullValue = "0";
            this.Ukupno1.DefaultCellStyle = DataGridViewCellStyle14;
            this.Ukupno1.HeaderText = "Uk.";
            this.Ukupno1.Name = "Ukupno1";
            this.Ukupno1.ReadOnly = true;
            this.Ukupno1.Width = 60;
            //
            // vreme
            //
            this.vreme.DataPropertyName = "vreme";
            this.vreme.HeaderText = "Vreme";
            this.vreme.Name = "vreme";
            this.vreme.ReadOnly = true;
            this.vreme.Width = 70;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1025, 588);
            this.ControlBox = true;
            this.Controls.Add(this.flPanel2);
            this.Controls.Add(this.btnRacun);
            this.Controls.Add(this.lblKomada);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.flPanel1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label1);
            // Panel za kategorije tastere (zamena za KategorijaDataGridView)
            this.flPanelKategorije = new System.Windows.Forms.FlowLayoutPanel();
            this.flPanelKategorije.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.flPanelKategorije.Location = new System.Drawing.Point(2, 8);
            this.flPanelKategorije.Size = new System.Drawing.Size(132, 570);
            this.flPanelKategorije.AutoScroll = true;
            this.flPanelKategorije.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flPanelKategorije);
            this.Controls.Add(this.btnUpisi);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.SplitContainer2);
            this.Controls.Add(this.btnZatvoriSto);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Naručivanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikliBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsArtikli)).EndInit();
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KategorijaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KategorijaBindingSource)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.Button btnZatvoriSto;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.DataGridView DataGridView2;
        internal WpfAmsterdam.DsArtikli DsArtikli;
        internal System.Windows.Forms.BindingSource KategorijaBindingSource;
        internal WpfAmsterdam.KategorijaTableAdapter KategorijaTableAdapter;
        internal WpfAmsterdam.Kategorija1TableAdapter Kategorija1TableAdapter;
        internal WpfAmsterdam.ArtikliTableAdapter ArtikliTableAdapter;
        internal System.Windows.Forms.DataGridView KategorijaDataGridView;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblKomada;
        internal System.Windows.Forms.Button btnKomada;
        internal System.Windows.Forms.Button btnDeo;
        internal System.Windows.Forms.Label lblDeo;
        internal System.Windows.Forms.Button btnCena;
        internal System.Windows.Forms.Label lblCena;
        internal System.Windows.Forms.Label lblJM;
        internal System.Windows.Forms.Label lblUkupno;
        internal System.Windows.Forms.Button btnUpisi;
        internal System.Windows.Forms.BindingSource ArtikliBindingSource1;
        internal System.Windows.Forms.FlowLayoutPanel flPanel1;
        internal System.Windows.Forms.Button btnPrebaci;
        internal System.Windows.Forms.Button btnPonisti;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.DataGridViewButtonColumn btnKat;
        internal System.Windows.Forms.FlowLayoutPanel flPanel2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.RichTextBox rtb1;
        internal System.Windows.Forms.Label lblSuma;
        internal System.Windows.Forms.Button btnRacun;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewComboBoxColumn IdArtikal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeoPorcije;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Komada;
        internal System.Windows.Forms.DataGridViewTextBoxColumn JedMere;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Cena;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Ukupno;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        internal System.Windows.Forms.DataGridViewComboBoxColumn IdArtikal1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeoPorcije1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Komada1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn JedMere1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Cena1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Ukupno1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn vreme;
        internal System.Windows.Forms.FlowLayoutPanel flPanelKategorije;
    }
}
