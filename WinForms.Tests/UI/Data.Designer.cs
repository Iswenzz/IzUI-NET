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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data));
            TreeNode treeNode1 = new TreeNode("Node3");
            TreeNode treeNode2 = new TreeNode("Node4");
            TreeNode treeNode3 = new TreeNode("Node0", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Node1");
            TreeNode treeNode5 = new TreeNode("Node2");
            label1 = new Label();
            labelSpecial2 = new WinForms.UI.Controls.Data.LabelSpecial();
            treeViewer1 = new WinForms.UI.Controls.Data.TreeViewer();
            labelSpecial3 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial1 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial4 = new WinForms.UI.Controls.Data.LabelSpecial();
            labelSpecial5 = new WinForms.UI.Controls.Data.LabelSpecial();
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
            label1.Size = new Size(588, 54);
            label1.TabIndex = 24;
            label1.Text = "Data";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSpecial2
            // 
            labelSpecial2.BackColor = Color.Transparent;
            labelSpecial2.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial2.Border.Radius = new Size(0, 0);
            labelSpecial2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial2.ForeColor = Color.MediumBlue;
            labelSpecial2.Icon.IconImage = (Image)resources.GetObject("resource.IconImage");
            labelSpecial2.Icon.IconSize = 150;
            labelSpecial2.Layouts.Angle = 0;
            labelSpecial2.Location = new Point(510, 79);
            labelSpecial2.Margin = new Padding(3, 4, 3, 4);
            labelSpecial2.Name = "labelSpecial2";
            labelSpecial2.Size = new Size(46, 186);
            labelSpecial2.TabIndex = 30;
            labelSpecial2.Text = "LabelSpecial";
            labelSpecial2.TextLayouts.Angle = 90;
            // 
            // treeViewer1
            // 
            treeViewer1.BackColor = Color.FromArgb(30, 30, 30);
            treeViewer1.Border.Radius = new Size(0, 0);
            treeViewer1.BorderStyle = BorderStyle.None;
            treeViewer1.DefaultIcon = null;
            treeViewer1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeViewer1.ForeColor = Color.Gainsboro;
            treeViewer1.Layouts.Angle = 0;
            treeViewer1.Location = new Point(185, 144);
            treeViewer1.Margin = new Padding(3, 2, 3, 2);
            treeViewer1.MinusIcon = (Image)resources.GetObject("treeViewer1.MinusIcon");
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
            treeViewer1.PlusIcon = (Image)resources.GetObject("treeViewer1.PlusIcon");
            treeViewer1.Size = new Size(242, 121);
            treeViewer1.TabIndex = 31;
            // 
            // labelSpecial3
            // 
            labelSpecial3.BackColor = Color.Transparent;
            labelSpecial3.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial3.Border.Radius = new Size(0, 0);
            labelSpecial3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial3.ForeColor = Color.Gainsboro;
            labelSpecial3.Icon.IconImage = (Image)resources.GetObject("resource.IconImage1");
            labelSpecial3.Icon.IconSize = 32;
            labelSpecial3.Layouts.Angle = 0;
            labelSpecial3.Location = new Point(185, 79);
            labelSpecial3.Margin = new Padding(3, 4, 3, 4);
            labelSpecial3.Name = "labelSpecial3";
            labelSpecial3.Size = new Size(242, 46);
            labelSpecial3.TabIndex = 32;
            labelSpecial3.Text = "LabelSpecial";
            labelSpecial3.TextLayouts.Angle = 0;
            // 
            // labelSpecial1
            // 
            labelSpecial1.BackColor = Color.Transparent;
            labelSpecial1.Border.Locations = WinForms.UI.Data.RectLocation.Top | WinForms.UI.Data.RectLocation.Right | WinForms.UI.Data.RectLocation.Bottom | WinForms.UI.Data.RectLocation.Left;
            labelSpecial1.Border.Radius = new Size(0, 0);
            labelSpecial1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial1.ForeColor = Color.Gainsboro;
            labelSpecial1.Layouts.Angle = 0;
            labelSpecial1.Location = new Point(446, 79);
            labelSpecial1.Margin = new Padding(3, 4, 3, 4);
            labelSpecial1.Name = "labelSpecial1";
            labelSpecial1.Size = new Size(46, 186);
            labelSpecial1.TabIndex = 33;
            labelSpecial1.Text = "LabelSpecial";
            labelSpecial1.TextLayouts.Angle = 90;
            // 
            // labelSpecial4
            // 
            labelSpecial4.BackColor = Color.Transparent;
            labelSpecial4.Border.Radius = new Size(0, 0);
            labelSpecial4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial4.ForeColor = Color.Gainsboro;
            labelSpecial4.Layouts.Angle = 0;
            labelSpecial4.Location = new Point(23, 178);
            labelSpecial4.Margin = new Padding(3, 4, 3, 4);
            labelSpecial4.Name = "labelSpecial4";
            labelSpecial4.Size = new Size(144, 46);
            labelSpecial4.TabIndex = 35;
            labelSpecial4.Text = "TreeViewer";
            labelSpecial4.TextLayouts.Angle = 0;
            labelSpecial4.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSpecial5
            // 
            labelSpecial5.BackColor = Color.Transparent;
            labelSpecial5.Border.Radius = new Size(0, 0);
            labelSpecial5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelSpecial5.ForeColor = Color.Gainsboro;
            labelSpecial5.Layouts.Angle = 0;
            labelSpecial5.Location = new Point(23, 79);
            labelSpecial5.Margin = new Padding(3, 4, 3, 4);
            labelSpecial5.Name = "labelSpecial5";
            labelSpecial5.Size = new Size(144, 46);
            labelSpecial5.TabIndex = 34;
            labelSpecial5.Text = "LabelSpecial";
            labelSpecial5.TextLayouts.Angle = 0;
            labelSpecial5.TextLayouts.ContentAlign = ContentAlignment.MiddleLeft;
            // 
            // Data
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            Controls.Add(labelSpecial4);
            Controls.Add(labelSpecial5);
            Controls.Add(labelSpecial1);
            Controls.Add(labelSpecial3);
            Controls.Add(treeViewer1);
            Controls.Add(labelSpecial2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Data";
            Size = new Size(588, 296);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial2;
        private IzUI.WinForms.UI.Controls.Data.TreeViewer treeViewer1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial3;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial1;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial4;
        private IzUI.WinForms.UI.Controls.Data.LabelSpecial labelSpecial5;
    }
}
