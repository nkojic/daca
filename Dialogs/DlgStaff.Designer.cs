namespace WpfAmsterdam
{
    partial class DlgStaff
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
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.IdArtikal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.SuspendLayout();
            //
            // btnNE
            //
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(732, 445);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 4;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            //
            // btnDA
            //
            this.btnDA.BackColor = System.Drawing.Color.Red;
            this.btnDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDA.ForeColor = System.Drawing.Color.White;
            this.btnDA.Location = new System.Drawing.Point(856, 445);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 3;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // Panel1 - kategorije levo
            //
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(3, 7);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(120, 500);
            this.Panel1.TabIndex = 16;
            //
            // DataGridView2
            //
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdArtikal1,
            this.Cena});
            this.DataGridView2.Location = new System.Drawing.Point(732, 86);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.RowHeadersWidth = 11;
            this.DataGridView2.Size = new System.Drawing.Size(220, 350);
            this.DataGridView2.TabIndex = 25;
            //
            // IdArtikal1
            //
            this.IdArtikal1.DataPropertyName = "Artikal";
            this.IdArtikal1.HeaderText = "Artikal";
            this.IdArtikal1.Name = "IdArtikal1";
            this.IdArtikal1.ReadOnly = true;
            this.IdArtikal1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdArtikal1.Width = 120;
            //
            // Cena
            //
            this.Cena.DataPropertyName = "Cena";
            this.Cena.HeaderText = "Cena";
            this.Cena.Name = "Cena";
            this.Cena.ReadOnly = true;
            this.Cena.Width = 50;
            //
            // Panel3 - imena zaposlenih
            //
            this.Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Location = new System.Drawing.Point(130, 7);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(250, 500);
            this.Panel3.TabIndex = 29;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.FromArgb(44, 43, 74);
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(732, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(220, 38);
            this.Label1.TabIndex = 30;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Panel2 - artikli
            //
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Location = new System.Drawing.Point(386, 7);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(340, 500);
            this.Panel2.TabIndex = 31;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.FromArgb(44, 43, 74);
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.Label2.Location = new System.Drawing.Point(732, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(220, 38);
            this.Label2.TabIndex = 32;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DlgStaff
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.ControlBox = true;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.DoubleBuffered = true;
            this.Name = "DlgStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zaposleni v2";
            this.Load += new System.EventHandler(this.dlgPlacanje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
        private System.Windows.Forms.FlowLayoutPanel Panel1;
        private System.Windows.Forms.DataGridView DataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArtikal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cena;
        private System.Windows.Forms.FlowLayoutPanel Panel3;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.FlowLayoutPanel Panel2;
        private System.Windows.Forms.Label Label2;
    }
}
