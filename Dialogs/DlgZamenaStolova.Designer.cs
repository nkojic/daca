namespace WpfAmsterdam
{
    partial class DlgZamenaStolova
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
            this.Panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // Panel1
            //
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(12, 81);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(630, 555);
            this.Panel1.TabIndex = 0;
            //
            // Panel2
            //
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Location = new System.Drawing.Point(652, 81);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(630, 555);
            this.Panel2.TabIndex = 1;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(179, 64);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Zameni Sto:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(197, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(114, 64);
            this.Label2.TabIndex = 3;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(317, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(114, 64);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "sa Stolom:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(437, 9);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(114, 64);
            this.Label4.TabIndex = 5;
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnNE
            //
            this.btnNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(1094, 6);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 6;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
            //
            // btnDA
            //
            this.btnDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDA.BackColor = System.Drawing.Color.Red;
            this.btnDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnDA.ForeColor = System.Drawing.Color.White;
            this.btnDA.Location = new System.Drawing.Point(1191, 6);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 7;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // DlgZamenaStolova
            //
            this.ClientSize = new System.Drawing.Size(1294, 645);
            this.ControlBox = false;
            this.Controls.Add(this.btnDA);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Name = "DlgZamenaStolova";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zamena Stolova";
            this.Load += new System.EventHandler(this.dlgZamenaStolova_Load);
            this.ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel Panel1;
        internal System.Windows.Forms.FlowLayoutPanel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
    }
}
