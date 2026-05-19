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
            this.btnDA.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnDA.ForeColor = System.Drawing.Color.White;
            this.btnDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDA.FlatAppearance.BorderSize = 0;
            this.btnDA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDA.Location = new System.Drawing.Point(16, 110);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(130, 55);
            this.btnDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDA.TabIndex = 0;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // btnNE
            //
            this.btnNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNE.BackColor = System.Drawing.Color.FromArgb(225, 112, 85);
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNE.FlatAppearance.BorderSize = 0;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNE.Location = new System.Drawing.Point(160, 110);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(130, 55);
            this.btnNE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNE.TabIndex = 1;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = false;
            this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.FromArgb(44, 43, 74);
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(16, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(274, 78);
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
            this.ClientSize = new System.Drawing.Size(306, 180);
            this.ControlBox = true;
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
