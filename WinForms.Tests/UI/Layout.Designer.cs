namespace IzUI.WinForms.Tests.UI
{
    partial class Layout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            separator1 = new WinForms.UI.Controls.Layout.Separator();
            labelSpecial3 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial2 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial1 = new WinForms.UI.Controls.Data.LabelSpecial();
            panelSeparator1 = new WinForms.UI.Controls.Layout.PanelSeparator();
            panelBorder1 = new WinForms.UI.Controls.Layout.PanelBorder();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(30, 30, 30);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(315, 54);
            label1.TabIndex = 24;
            label1.Text = "Layout";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // separator1
            // 
            separator1.BackColor = Color.Transparent;
            separator1.Border.Color = Color.Empty;
            separator1.Border.Radius = new Size(0, 0);
            separator1.Border.Width = 0F;
            separator1.ForeColor = Color.DarkGray;
            separator1.Layouts.Angle = 0;
            separator1.Location = new Point(185, 74);
            separator1.Margin = new Padding(3, 2, 3, 2);
            separator1.Name = "separator1";
            separator1.Size = new Size(106, 30);
            separator1.TabIndex = 28;
            separator1.Thickness = 0F;
            // 
            // labelSpecial3
            // 
            labelSpecial3.BackColor = Color.Transparent;
            labelSpecial3.Border.Radius = new Size(0, 0);
            labelSpecial3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial3.ForeColor = Color.Gainsboro;
            labelSpecial3.Layouts.Angle = 0;
            labelSpecial3.Location = new Point(15, 282);
            labelSpecial3.Margin = new Padding(3, 4, 3, 4);
            labelSpecial3.Name = "labelSpecial3";
            labelSpecial3.Size = new Size(144, 30);
            labelSpecial3.TabIndex = 27;
            labelSpecial3.Text = "PanelSeparator";
            labelSpecial3.TextLayouts.Angle = 0;
            labelSpecial3.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSpecial2
            // 
            labelSpecial2.BackColor = Color.Transparent;
            labelSpecial2.Border.Radius = new Size(0, 0);
            labelSpecial2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial2.ForeColor = Color.Gainsboro;
            labelSpecial2.Layouts.Angle = 0;
            labelSpecial2.Location = new Point(15, 172);
            labelSpecial2.Margin = new Padding(3, 4, 3, 4);
            labelSpecial2.Name = "labelSpecial2";
            labelSpecial2.Size = new Size(144, 30);
            labelSpecial2.TabIndex = 26;
            labelSpecial2.Text = "PanelBorder";
            labelSpecial2.TextLayouts.Angle = 0;
            labelSpecial2.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSpecial1
            // 
            labelSpecial1.BackColor = Color.Transparent;
            labelSpecial1.Border.Radius = new Size(0, 0);
            labelSpecial1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial1.ForeColor = Color.Gainsboro;
            labelSpecial1.Layouts.Angle = 0;
            labelSpecial1.Location = new Point(15, 74);
            labelSpecial1.Margin = new Padding(3, 4, 3, 4);
            labelSpecial1.Name = "labelSpecial1";
            labelSpecial1.Size = new Size(144, 30);
            labelSpecial1.TabIndex = 25;
            labelSpecial1.Text = "Separator";
            labelSpecial1.TextLayouts.Angle = 0;
            labelSpecial1.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            // 
            // panelSeparator1
            // 
            panelSeparator1.Border.Locations = WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Left;
            panelSeparator1.Border.Radius = new Size(0, 0);
            panelSeparator1.Layouts.Angle = 0;
            panelSeparator1.Location = new Point(185, 262);
            panelSeparator1.Margin = new Padding(3, 4, 3, 4);
            panelSeparator1.Name = "panelSeparator1";
            panelSeparator1.Size = new Size(106, 81);
            panelSeparator1.TabIndex = 23;
            // 
            // panelBorder1
            // 
            panelBorder1.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            panelBorder1.Border.Radius = new Size(0, 0);
            panelBorder1.Layouts.Angle = 0;
            panelBorder1.Location = new Point(185, 148);
            panelBorder1.Margin = new Padding(3, 4, 3, 4);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new Size(106, 81);
            panelBorder1.TabIndex = 15;
            // 
            // Layout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            Controls.Add(separator1);
            Controls.Add(labelSpecial3);
            Controls.Add(labelSpecial2);
            Controls.Add(labelSpecial1);
            Controls.Add(label1);
            Controls.Add(panelSeparator1);
            Controls.Add(panelBorder1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Layout";
            Size = new Size(315, 365);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private IzUI.WinForms.UI.Controls.Layout.PanelBorder panelBorder1;
        private IzUI.WinForms.UI.Controls.Layout.PanelSeparator panelSeparator1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial2;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial3;
        private IzUI.WinForms.UI.Controls.Layout.Separator separator1;
    }
}
