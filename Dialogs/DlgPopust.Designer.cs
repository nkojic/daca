namespace WpfAmsterdam
{
    partial class DlgPopust
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
            this.Panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnNE
            //
            this.btnNE.BackColor = System.Drawing.Color.Red;
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNE.ForeColor = System.Drawing.Color.White;
            this.btnNE.Location = new System.Drawing.Point(519, 363);
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
            this.btnDA.Location = new System.Drawing.Point(616, 363);
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
            this.Panel1.Size = new System.Drawing.Size(261, 382);
            this.Panel1.TabIndex = 16;
            //
            // Panel3
            //
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Location = new System.Drawing.Point(270, 50);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(437, 307);
            this.Panel3.TabIndex = 29;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(3, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(261, 40);
            this.Label1.TabIndex = 30;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(270, 7);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(437, 40);
            this.Label2.TabIndex = 31;
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // DlgPopust
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 436);
            this.ControlBox = false;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDA);
            this.DoubleBuffered = true;
            this.Name = "DlgPopust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popust";
            this.Load += new System.EventHandler(this.dlgPopust_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnDA;
        private System.Windows.Forms.FlowLayoutPanel Panel1;
        private System.Windows.Forms.FlowLayoutPanel Panel3;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
    }
}
