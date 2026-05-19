namespace WpfAmsterdam
{
    partial class DlgPrilozi
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
            this.btnNE = new System.Windows.Forms.Button();
            this.btnDA = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnNE
            //
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(149, 252);
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
            this.btnDA.Location = new System.Drawing.Point(246, 252);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(91, 69);
            this.btnDA.TabIndex = 3;
            this.btnDA.Text = "DA";
            this.btnDA.UseVisualStyleBackColor = false;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            //
            // Panel1
            //
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(3, 50);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(334, 196);
            this.Panel1.TabIndex = 16;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(3, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(334, 40);
            this.Label1.TabIndex = 30;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DlgPrilozi
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 327);
            this.ControlBox = true;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.DoubleBuffered = true;
            this.Name = "DlgPrilozi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prilozi";
            this.Load += new System.EventHandler(this.dlgPrilozi_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
        private System.Windows.Forms.FlowLayoutPanel Panel1;
        private System.Windows.Forms.Label Label1;
    }
}
