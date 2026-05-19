namespace WpfAmsterdam
{
    partial class DlgZamenaKonobara
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
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // Panel1
            //
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(12, 81);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(770, 269);
            this.Panel1.TabIndex = 0;
            //
            // btnNE
            //
            this.btnNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(594, 6);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 1;
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
            this.btnDA.Location = new System.Drawing.Point(691, 6);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 2;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(313, 64);
            this.Label1.TabIndex = 3;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(331, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(257, 64);
            this.Label2.TabIndex = 4;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DlgZamenaKonobara
            //
            this.ClientSize = new System.Drawing.Size(784, 359);
            this.ControlBox = true;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnDA);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.Panel1);
            this.Name = "DlgZamenaKonobara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zamena Stolova";
            this.Load += new System.EventHandler(this.dlgZamenaKonobara_Load);
            this.ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel Panel1;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
    }
}
