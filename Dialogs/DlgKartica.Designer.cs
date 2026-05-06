namespace WpfAmsterdam
{
    partial class DlgKartica
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
            this.SuspendLayout();
            //
            // DlgKartica
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 48);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgKartica";
            this.Text = "dlgKartica";
            this.Load += new System.EventHandler(this.dlgKartica_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
