using System.Windows.Media;

namespace WpfAmsterdam
{
    public static class ThemeManager
    {
        public static string CurrentTheme { get; set; } = "Light Minimalist";

        public static readonly string[] ThemeNames = new string[]
        {
            "Light Minimalist",
            "Dark Modern",
            "Luxury Restaurant"
        };

        // --- Window / pozadina ---
        public static Color WindowBackground
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(15, 15, 26);
                    case "Luxury Restaurant": return Color.FromRgb(44, 24, 16);
                    default: return Color.FromRgb(245, 246, 248);
                }
            }
        }

        public static Color ContainerBackground
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(26, 26, 46);
                    case "Luxury Restaurant": return Color.FromRgb(58, 34, 24);
                    default: return Colors.White;
                }
            }
        }

        // --- Header ---
        public static Color HeaderGradient1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(22, 22, 40);
                    case "Luxury Restaurant": return Color.FromRgb(74, 44, 26);
                    default: return Color.FromRgb(250, 251, 252);
                }
            }
        }

        public static Color HeaderGradient2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(18, 18, 34);
                    case "Luxury Restaurant": return Color.FromRgb(58, 34, 24);
                    default: return Color.FromRgb(240, 242, 245);
                }
            }
        }

        public static Color HeaderBorder
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(40, 40, 65);
                    case "Luxury Restaurant": return Color.FromRgb(107, 62, 38);
                    default: return Color.FromRgb(232, 236, 241);
                }
            }
        }

        // --- Tekst ---
        public static Color TextPrimary
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(224, 224, 224);
                    case "Luxury Restaurant": return Color.FromRgb(245, 236, 215);
                    default: return Color.FromRgb(45, 52, 54);
                }
            }
        }

        public static Color TextSecondary
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(165, 165, 192);
                    case "Luxury Restaurant": return Color.FromRgb(201, 169, 78);
                    default: return Color.FromRgb(99, 110, 114);
                }
            }
        }

        public static Color TextMuted
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(100, 100, 130);
                    case "Luxury Restaurant": return Color.FromRgb(139, 94, 60);
                    default: return Color.FromRgb(178, 190, 195);
                }
            }
        }

        // --- Dugmad - Kraj (crveno) ---
        public static Color BtnKraj1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(220, 38, 38);
                    case "Luxury Restaurant": return Color.FromRgb(163, 59, 44);
                    default: return Color.FromRgb(255, 118, 117);
                }
            }
        }

        public static Color BtnKraj2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(185, 28, 28);
                    case "Luxury Restaurant": return Color.FromRgb(140, 45, 30);
                    default: return Color.FromRgb(225, 112, 85);
                }
            }
        }

        // --- Dugmad - Stolovi (plavo/indigo) ---
        public static Color BtnStolovi1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(99, 102, 241);
                    case "Luxury Restaurant": return Color.FromRgb(201, 169, 78);
                    default: return Color.FromRgb(116, 185, 255);
                }
            }
        }

        public static Color BtnStolovi2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(79, 70, 229);
                    case "Luxury Restaurant": return Color.FromRgb(168, 137, 58);
                    default: return Color.FromRgb(9, 132, 227);
                }
            }
        }

        // --- Dugmad - Konobari (ljubičasto/teal) ---
        public static Color BtnKonobari1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(20, 184, 166);
                    case "Luxury Restaurant": return Color.FromRgb(90, 140, 90);
                    default: return Color.FromRgb(162, 155, 254);
                }
            }
        }

        public static Color BtnKonobari2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(13, 148, 136);
                    case "Luxury Restaurant": return Color.FromRgb(70, 115, 70);
                    default: return Color.FromRgb(108, 92, 231);
                }
            }
        }

        // --- Dugmad - Raspored (zeleno/amber) ---
        public static Color BtnRaspored1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(245, 158, 11);
                    case "Luxury Restaurant": return Color.FromRgb(196, 168, 78);
                    default: return Color.FromRgb(85, 239, 196);
                }
            }
        }

        public static Color BtnRaspored2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(217, 119, 6);
                    case "Luxury Restaurant": return Color.FromRgb(168, 137, 58);
                    default: return Color.FromRgb(0, 184, 148);
                }
            }
        }

        // --- Dugmad - Secondary (ghost) ---
        public static Color BtnSecondary1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(35, 35, 55);
                    case "Luxury Restaurant": return Color.FromRgb(74, 44, 26);
                    default: return Color.FromRgb(240, 242, 245);
                }
            }
        }

        public static Color BtnSecondary2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(45, 45, 70);
                    case "Luxury Restaurant": return Color.FromRgb(90, 55, 35);
                    default: return Color.FromRgb(223, 230, 233);
                }
            }
        }

        public static Color BtnSecondaryFg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(165, 165, 192);
                    case "Luxury Restaurant": return Color.FromRgb(201, 169, 78);
                    default: return Color.FromRgb(99, 110, 114);
                }
            }
        }

        // --- Dugmad - Admin (žuto) ---
        public static Color BtnAdmin1
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(245, 158, 11);
                    case "Luxury Restaurant": return Color.FromRgb(212, 148, 58);
                    default: return Color.FromRgb(253, 203, 110);
                }
            }
        }

        public static Color BtnAdmin2
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(217, 119, 6);
                    case "Luxury Restaurant": return Color.FromRgb(180, 120, 40);
                    default: return Color.FromRgb(240, 147, 43);
                }
            }
        }

        // --- Stolovi - status ---
        public static Color StatusEmpty
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(30, 30, 50);
                    case "Luxury Restaurant": return Color.FromRgb(217, 206, 174);
                    default: return Color.FromRgb(240, 242, 245);
                }
            }
        }

        public static Color StatusEmptyFg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(100, 100, 130);
                    case "Luxury Restaurant": return Color.FromRgb(107, 62, 38);
                    default: return Color.FromRgb(178, 190, 195);
                }
            }
        }

        public static Color StatusMine
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(16, 80, 60);
                    case "Luxury Restaurant": return Color.FromRgb(90, 140, 90);
                    default: return Color.FromRgb(184, 245, 216);
                }
            }
        }

        public static Color StatusMineFg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(110, 231, 183);
                    case "Luxury Restaurant": return Color.FromRgb(245, 236, 215);
                    default: return Color.FromRgb(0, 184, 148);
                }
            }
        }

        public static Color StatusOther
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(80, 55, 10);
                    case "Luxury Restaurant": return Color.FromRgb(201, 139, 63);
                    default: return Color.FromRgb(255, 224, 178);
                }
            }
        }

        public static Color StatusOtherFg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(252, 211, 77);
                    case "Luxury Restaurant": return Color.FromRgb(245, 236, 215);
                    default: return Color.FromRgb(225, 112, 85);
                }
            }
        }

        public static Color StatusNewOrder
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(80, 25, 25);
                    case "Luxury Restaurant": return Color.FromRgb(163, 59, 44);
                    default: return Color.FromRgb(255, 184, 184);
                }
            }
        }

        public static Color StatusNewOrderRecent
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(239, 68, 68);
                    case "Luxury Restaurant": return Color.FromRgb(196, 75, 58);
                    default: return Color.FromRgb(255, 118, 117);
                }
            }
        }

        public static Color StatusNewOrderFg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(252, 165, 165);
                    case "Luxury Restaurant": return Color.FromRgb(245, 236, 215);
                    default: return Color.FromRgb(214, 48, 49);
                }
            }
        }

        // --- Canvas / grid ---
        public static Color CanvasBackground
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(18, 18, 30);
                    case "Luxury Restaurant": return Color.FromRgb(46, 26, 16);
                    default: return Color.FromRgb(250, 251, 252);
                }
            }
        }

        public static Color GridLine
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(35, 35, 55);
                    case "Luxury Restaurant": return Color.FromRgb(65, 40, 28);
                    default: return Color.FromRgb(232, 236, 241);
                }
            }
        }

        public static Color TableBorder
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(50, 50, 80);
                    case "Luxury Restaurant": return Color.FromRgb(107, 62, 38);
                    default: return Color.FromRgb(223, 230, 233);
                }
            }
        }

        // --- Footer / legenda ---
        public static Color FooterBackground
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(20, 20, 35);
                    case "Luxury Restaurant": return Color.FromRgb(50, 28, 18);
                    default: return Color.FromRgb(250, 251, 252);
                }
            }
        }

        public static Color WaiterAccent
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return Color.FromRgb(99, 102, 241);
                    case "Luxury Restaurant": return Color.FromRgb(201, 169, 78);
                    default: return Color.FromRgb(9, 132, 227);
                }
            }
        }

        // --- Helper za kreiranje LinearGradientBrush ---
        public static LinearGradientBrush MakeGradient(Color c1, Color c2)
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new System.Windows.Point(0, 0);
            brush.EndPoint = new System.Windows.Point(1, 1);
            brush.GradientStops.Add(new GradientStop(c1, 0));
            brush.GradientStops.Add(new GradientStop(c2, 1));
            return brush;
        }

        // --- WinForms tema helper ---
        public static System.Drawing.Color WfBackground
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(20, 20, 35);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(50, 28, 18);
                    default: return System.Drawing.Color.FromArgb(245, 246, 248);
                }
            }
        }

        public static System.Drawing.Color WfPanel
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(26, 26, 46);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(58, 34, 24);
                    default: return System.Drawing.Color.White;
                }
            }
        }

        public static System.Drawing.Color WfTextColor
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(224, 224, 224);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(245, 236, 215);
                    default: return System.Drawing.Color.FromArgb(45, 52, 54);
                }
            }
        }

        public static System.Drawing.Color WfAccent
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(99, 102, 241);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(201, 169, 78);
                    default: return System.Drawing.Color.FromArgb(9, 132, 227);
                }
            }
        }

        public static System.Drawing.Color WfButtonBg
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(35, 35, 55);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(74, 44, 26);
                    default: return System.Drawing.Color.FromArgb(240, 242, 245);
                }
            }
        }

        public static System.Drawing.Color WfButtonDa
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(16, 185, 129);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(90, 140, 90);
                    default: return System.Drawing.Color.FromArgb(0, 184, 148);
                }
            }
        }

        public static System.Drawing.Color WfButtonNe
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(220, 38, 38);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(163, 59, 44);
                    default: return System.Drawing.Color.FromArgb(225, 112, 85);
                }
            }
        }

        public static System.Drawing.Color WfHeader
        {
            get
            {
                switch (CurrentTheme)
                {
                    case "Dark Modern": return System.Drawing.Color.FromArgb(30, 30, 50);
                    case "Luxury Restaurant": return System.Drawing.Color.FromArgb(74, 44, 26);
                    default: return System.Drawing.Color.FromArgb(99, 110, 114);
                }
            }
        }

        public static void ApplyWinFormsTheme(System.Windows.Forms.Form form)
        {
            form.BackColor = WfBackground;
            form.ForeColor = WfTextColor;
            ApplyThemeToControls(form.Controls);
        }

        private static void ApplyThemeToControls(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (System.Windows.Forms.Control ctrl in controls)
            {
                if (ctrl is System.Windows.Forms.Button btn)
                {
                    if (btn.Text == "DA" || btn.Text == "OK")
                    {
                        btn.BackColor = WfButtonDa;
                        btn.ForeColor = System.Drawing.Color.White;
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Text == "NE" || btn.Text == "Cancel")
                    {
                        btn.BackColor = WfButtonNe;
                        btn.ForeColor = System.Drawing.Color.White;
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else
                    {
                        btn.BackColor = WfButtonBg;
                        btn.ForeColor = WfTextColor;
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                }
                else if (ctrl is System.Windows.Forms.Label lbl)
                {
                    if (lbl.BackColor != System.Drawing.Color.Transparent &&
                        lbl.BackColor != System.Drawing.SystemColors.Control)
                    {
                        lbl.BackColor = WfHeader;
                        lbl.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        lbl.ForeColor = WfTextColor;
                    }
                }
                else if (ctrl is System.Windows.Forms.Panel || ctrl is System.Windows.Forms.FlowLayoutPanel)
                {
                    ctrl.BackColor = WfPanel;
                    ctrl.ForeColor = WfTextColor;
                }
                else if (ctrl is System.Windows.Forms.TextBox || ctrl is System.Windows.Forms.ComboBox)
                {
                    ctrl.BackColor = WfPanel;
                    ctrl.ForeColor = WfTextColor;
                }
                else if (ctrl is System.Windows.Forms.DataGridView dgv)
                {
                    dgv.BackgroundColor = WfPanel;
                    dgv.DefaultCellStyle.BackColor = WfPanel;
                    dgv.DefaultCellStyle.ForeColor = WfTextColor;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = WfHeader;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.GridColor = WfBackground;
                }

                if (ctrl.HasChildren)
                    ApplyThemeToControls(ctrl.Controls);
            }
        }
    }
}
