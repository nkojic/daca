namespace WpfAmsterdam
{
    partial class DlgOkno
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
            this.btnDA = new System.Windows.Forms.Button();
            this.btnNE = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnDA
            //
            this.btnDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDA.BackColor = System.Drawing.Color.Red;
            this.btnDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDA.Location = new System.Drawing.Point(12, 106);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 0;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // btnNE
            //
            this.btnNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNE.Location = new System.Drawing.Point(140, 106);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(91, 69);
            this.btnNE.TabIndex = 1;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(219, 70);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Label1";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DlgOkno
            //
            this.AcceptButton = this.btnDA;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNE;
            this.ClientSize = new System.Drawing.Size(243, 187);
            this.ControlBox = false;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgOkno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DA / NE";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnDA;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Label Label1;
    }
}
