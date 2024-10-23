namespace IzUI.WinForms.Tests.UI
{
    partial class Data
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
            TreeNode treeNode1 = new TreeNode("Node3");
            TreeNode treeNode2 = new TreeNode("Node4");
            TreeNode treeNode3 = new TreeNode("Node0", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Node1");
            TreeNode treeNode5 = new TreeNode("Node2");
            label1 = new Label();
            treeViewer1 = new WinForms.UI.Controls.Data.TreeViewer();
            labelSpecial3 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial1 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial4 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial5 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial2 = new WinForms.UI.Controls.Data.LabelSpecial();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(30, 30, 30);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1290, 68);
            label1.TabIndex = 24;
            label1.Text = "Data";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // treeViewer1
            // 
            treeViewer1.Animations.ColorHover = Color.Empty;
            treeViewer1.Animations.CursorHover = Cursors.Hand;
            treeViewer1.Animations.Enabled = false;
            treeViewer1.Animations.TextColorHover = Color.Empty;
            treeViewer1.BackColor = Color.FromArgb(30, 30, 30);
            treeViewer1.Border.Color = Color.DodgerBlue;
            treeViewer1.Border.Enabled = true;
            treeViewer1.Border.Radius = new Size(0, 0);
            treeViewer1.Border.Width = 4F;
            treeViewer1.BorderStyle = BorderStyle.None;
            treeViewer1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeViewer1.Font = new Font("Segoe UI", 10F);
            treeViewer1.ForeColor = Color.Gainsboro;
            treeViewer1.Layouts.Angle = 0;
            treeViewer1.Layouts.Enabled = true;
            treeViewer1.Location = new Point(28, 428);
            treeViewer1.Margin = new Padding(4, 2, 4, 2);
            treeViewer1.Name = "treeViewer1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeViewer1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode4, treeNode5 });
            treeViewer1.Size = new Size(302, 151);
            treeViewer1.TabIndex = 31;
            // 
            // labelSpecial3
            // 
            labelSpecial3.Alpha.Enabled = true;
            labelSpecial3.Animations.ColorHover = Color.Empty;
            labelSpecial3.Animations.CursorHover = Cursors.Hand;
            labelSpecial3.Animations.Enabled = false;
            labelSpecial3.Animations.TextColorHover = Color.Empty;
            labelSpecial3.BackColor = Color.Transparent;
            labelSpecial3.Border.Color = Color.DodgerBlue;
            labelSpecial3.Border.Enabled = true;
            labelSpecial3.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial3.Border.Radius = new Size(0, 0);
            labelSpecial3.Border.Width = 4F;
            labelSpecial3.Font = new Font("Segoe UI", 10F);
            labelSpecial3.ForeColor = Color.Gainsboro;
            labelSpecial3.Icon.Enabled = true;
            labelSpecial3.Icon.IconImage = null;
            labelSpecial3.Icon.IconSize = 32;
            labelSpecial3.Layouts.Angle = 0;
            labelSpecial3.Layouts.Enabled = true;
            labelSpecial3.Location = new Point(28, 179);
            labelSpecial3.Margin = new Padding(4, 5, 4, 5);
            labelSpecial3.Name = "labelSpecial3";
            labelSpecial3.Size = new Size(240, 58);
            labelSpecial3.TabIndex = 32;
            labelSpecial3.Text = "Special";
            labelSpecial3.TextLayouts.Angle = 0;
            labelSpecial3.TextLayouts.ContentAlign = ContentAlignment.MiddleCenter;
            labelSpecial3.TextLayouts.Enabled = true;
            // 
            // labelSpecial1
            // 
            labelSpecial1.Alpha.Enabled = true;
            labelSpecial1.Animations.ColorHover = Color.Empty;
            labelSpecial1.Animations.CursorHover = Cursors.Hand;
            labelSpecial1.Animations.Enabled = false;
            labelSpecial1.Animations.TextColorHover = Color.Empty;
            labelSpecial1.BackColor = Color.Transparent;
            labelSpecial1.Border.Color = Color.DodgerBlue;
            labelSpecial1.Border.Enabled = true;
            labelSpecial1.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial1.Border.Radius = new Size(0, 0);
            labelSpecial1.Border.Width = 4F;
            labelSpecial1.Font = new Font("Segoe UI", 10F);
            labelSpecial1.ForeColor = Color.Gainsboro;
            labelSpecial1.Icon.Enabled = true;
            labelSpecial1.Icon.IconImage = null;
            labelSpecial1.Icon.IconSize = 0;
            labelSpecial1.Layouts.Angle = 0;
            labelSpecial1.Layouts.Enabled = true;
            labelSpecial1.Location = new Point(276, 179);
            labelSpecial1.Margin = new Padding(4, 5, 4, 5);
            labelSpecial1.Name = "labelSpecial1";
            labelSpecial1.Size = new Size(58, 126);
            labelSpecial1.TabIndex = 33;
            labelSpecial1.Text = "Special";
            labelSpecial1.TextLayouts.Angle = 90;
            labelSpecial1.TextLayouts.ContentAlign = ContentAlignment.MiddleCenter;
            labelSpecial1.TextLayouts.Enabled = true;
            // 
            // labelSpecial4
            // 
            labelSpecial4.Alpha.Enabled = false;
            labelSpecial4.Animations.ColorHover = Color.Empty;
            labelSpecial4.Animations.CursorHover = Cursors.Hand;
            labelSpecial4.Animations.Enabled = false;
            labelSpecial4.Animations.TextColorHover = Color.Empty;
            labelSpecial4.BackColor = Color.Transparent;
            labelSpecial4.Border.Color = Color.DodgerBlue;
            labelSpecial4.Border.Enabled = true;
            labelSpecial4.Border.Radius = new Size(0, 0);
            labelSpecial4.Border.Width = 4F;
            labelSpecial4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSpecial4.ForeColor = Color.Gainsboro;
            labelSpecial4.Icon.Enabled = true;
            labelSpecial4.Icon.IconImage = null;
            labelSpecial4.Icon.IconSize = 0;
            labelSpecial4.Layouts.Angle = 0;
            labelSpecial4.Layouts.Enabled = true;
            labelSpecial4.Location = new Point(28, 376);
            labelSpecial4.Margin = new Padding(4, 5, 4, 5);
            labelSpecial4.Name = "labelSpecial4";
            labelSpecial4.Size = new Size(180, 30);
            labelSpecial4.TabIndex = 35;
            labelSpecial4.Text = "TreeViewer";
            labelSpecial4.TextLayouts.Angle = 0;
            labelSpecial4.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            labelSpecial4.TextLayouts.Enabled = true;
            // 
            // labelSpecial5
            // 
            labelSpecial5.Alpha.Enabled = true;
            labelSpecial5.Animations.ColorHover = Color.Empty;
            labelSpecial5.Animations.CursorHover = Cursors.Hand;
            labelSpecial5.Animations.Enabled = false;
            labelSpecial5.Animations.TextColorHover = Color.Empty;
            labelSpecial5.BackColor = Color.Transparent;
            labelSpecial5.Border.Color = Color.DodgerBlue;
            labelSpecial5.Border.Enabled = true;
            labelSpecial5.Border.Radius = new Size(0, 0);
            labelSpecial5.Border.Width = 4F;
            labelSpecial5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSpecial5.ForeColor = Color.Gainsboro;
            labelSpecial5.Icon.Enabled = true;
            labelSpecial5.Icon.IconImage = null;
            labelSpecial5.Icon.IconSize = 0;
            labelSpecial5.Layouts.Angle = 0;
            labelSpecial5.Layouts.Enabled = true;
            labelSpecial5.Location = new Point(28, 120);
            labelSpecial5.Margin = new Padding(4, 5, 4, 5);
            labelSpecial5.Name = "labelSpecial5";
            labelSpecial5.Size = new Size(180, 30);
            labelSpecial5.TabIndex = 34;
            labelSpecial5.Text = "LabelSpecial";
            labelSpecial5.TextLayouts.Angle = 0;
            labelSpecial5.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            labelSpecial5.TextLayouts.Enabled = true;
            // 
            // labelSpecial2
            // 
            labelSpecial2.Alpha.Enabled = true;
            labelSpecial2.Animations.ColorHover = Color.Empty;
            labelSpecial2.Animations.CursorHover = Cursors.Hand;
            labelSpecial2.Animations.Enabled = false;
            labelSpecial2.Animations.TextColorHover = Color.Empty;
            labelSpecial2.BackColor = Color.Transparent;
            labelSpecial2.Border.Color = Color.Cyan;
            labelSpecial2.Border.Enabled = true;
            labelSpecial2.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial2.Border.Radius = new Size(0, 0);
            labelSpecial2.Border.Width = 4F;
            labelSpecial2.Font = new Font("Segoe UI", 10F);
            labelSpecial2.ForeColor = Color.Gainsboro;
            labelSpecial2.Icon.Enabled = true;
            labelSpecial2.Icon.IconImage = null;
            labelSpecial2.Icon.IconSize = 32;
            labelSpecial2.Layouts.Angle = 0;
            labelSpecial2.Layouts.Enabled = true;
            labelSpecial2.Location = new Point(28, 247);
            labelSpecial2.Margin = new Padding(4, 5, 4, 5);
            labelSpecial2.Name = "labelSpecial2";
            labelSpecial2.Size = new Size(240, 58);
            labelSpecial2.TabIndex = 36;
            labelSpecial2.Text = "Special";
            labelSpecial2.TextLayouts.Angle = 0;
            labelSpecial2.TextLayouts.ContentAlign = ContentAlignment.MiddleCenter;
            labelSpecial2.TextLayouts.Enabled = true;
            // 
            // Data
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            Controls.Add(labelSpecial2);
            Controls.Add(labelSpecial4);
            Controls.Add(labelSpecial5);
            Controls.Add(labelSpecial1);
            Controls.Add(labelSpecial3);
            Controls.Add(treeViewer1);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Data";
            Size = new Size(1290, 720);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private IzUI.WinForms.UI.Controls.Data.TreeViewer treeViewer1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial3;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial4;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial5;
        private WinForms.UI.Controls.Data.LabelSpecial labelSpecial2;
    }
}
