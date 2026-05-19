namespace WpfAmsterdam
{
    partial class DlgRacun
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
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
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
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.SuspendLayout();
            //
            // btnNE
            //
            this.btnNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(266, 411);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 4;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            //
            // btnDA
            //
            this.btnDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDA.BackColor = System.Drawing.Color.Red;
            this.btnDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDA.ForeColor = System.Drawing.Color.White;
            this.btnDA.Location = new System.Drawing.Point(358, 411);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 3;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // RichTextBox1
            //
            this.RichTextBox1.Location = new System.Drawing.Point(3, 415);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(257, 60);
            this.RichTextBox1.TabIndex = 18;
            this.RichTextBox1.Text = "";
            //
            // lblPopust
            //
            this.lblPopust.BackColor = System.Drawing.Color.Transparent;
            this.lblPopust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopust.ForeColor = System.Drawing.Color.Black;
            this.lblPopust.Location = new System.Drawing.Point(172, 307);
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
            this.Label4.Location = new System.Drawing.Point(3, 307);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(158, 64);
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
            this.Label5.Location = new System.Drawing.Point(266, 307);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(183, 64);
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
            this.Label6.Location = new System.Drawing.Point(3, 379);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(158, 29);
            this.Label6.TabIndex = 23;
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Red;
            this.Label7.Location = new System.Drawing.Point(266, 379);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(183, 29);
            this.Label7.TabIndex = 24;
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DataGridView2
            //
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.AllowUserToOrderColumns = true;
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdArtikal1,
            this.DeoPorcije1,
            this.Komada1,
            this.JedMere1,
            this.Cena1,
            this.Ukupno1});
            this.DataGridView2.Location = new System.Drawing.Point(3, 4);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.RowHeadersWidth = 11;
            this.DataGridView2.Size = new System.Drawing.Size(446, 291);
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
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeoPorcije1.DefaultCellStyle = DataGridViewCellStyle2;
            this.DeoPorcije1.HeaderText = "deo";
            this.DeoPorcije1.Name = "DeoPorcije1";
            this.DeoPorcije1.ReadOnly = true;
            this.DeoPorcije1.Width = 40;
            //
            // Komada1
            //
            this.Komada1.DataPropertyName = "Komada";
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Komada1.DefaultCellStyle = DataGridViewCellStyle3;
            this.Komada1.HeaderText = "kom";
            this.Komada1.Name = "Komada1";
            this.Komada1.ReadOnly = true;
            this.Komada1.Width = 40;
            //
            // JedMere1
            //
            this.JedMere1.DataPropertyName = "JedMere";
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JedMere1.DefaultCellStyle = DataGridViewCellStyle4;
            this.JedMere1.HeaderText = "jm.";
            this.JedMere1.Name = "JedMere1";
            this.JedMere1.ReadOnly = true;
            this.JedMere1.Width = 40;
            //
            // Cena1
            //
            this.Cena1.DataPropertyName = "Cena";
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle5.Format = "N0";
            DataGridViewCellStyle5.NullValue = "0";
            this.Cena1.DefaultCellStyle = DataGridViewCellStyle5;
            this.Cena1.HeaderText = "cena";
            this.Cena1.Name = "Cena1";
            this.Cena1.ReadOnly = true;
            this.Cena1.Width = 50;
            //
            // Ukupno1
            //
            this.Ukupno1.DataPropertyName = "Ukupno";
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle6.Format = "N0";
            DataGridViewCellStyle6.NullValue = "0";
            this.Ukupno1.DefaultCellStyle = DataGridViewCellStyle6;
            this.Ukupno1.HeaderText = "Uk.";
            this.Ukupno1.Name = "Ukupno1";
            this.Ukupno1.ReadOnly = true;
            this.Ukupno1.Width = 60;
            //
            // Button1
            //
            this.Button1.BackColor = System.Drawing.Color.Red;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(172, 344);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(88, 65);
            this.Button1.TabIndex = 29;
            this.Button1.Text = "0";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            //
            // DlgRacun
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 487);
            this.ControlBox = true;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblPopust);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.DoubleBuffered = true;
            this.Name = "DlgRacun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgPlacanje";
            this.Load += new System.EventHandler(this.dlgPlacanje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
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
        private System.Windows.Forms.Button Button1;
    }
}
