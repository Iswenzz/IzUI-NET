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
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node2");
            this.label1 = new System.Windows.Forms.Label();
            this.labelSpecial2 = new IzUI.WinForms.UI.Controls.Data.LabelSpecial();
            this.treeViewer1 = new IzUI.WinForms.UI.Controls.Data.TreeViewer();
            this.labelSpecial3 = new IzUI.WinForms.UI.Controls.Data.LabelSpecial();
            this.labelSpecial1 = new IzUI.WinForms.UI.Controls.Data.LabelSpecial();
            this.labelSpecial4 = new IzUI.WinForms.UI.Controls.Data.LabelSpecial();
            this.labelSpecial5 = new IzUI.WinForms.UI.Controls.Data.LabelSpecial();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 43);
            this.label1.TabIndex = 24;
            this.label1.Text = "Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpecial2
            // 
            this.labelSpecial2.Animations.ColorHover = System.Drawing.Color.Empty;
            this.labelSpecial2.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial2.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            this.labelSpecial2.Animations.CursorHoverLeave = null;
            this.labelSpecial2.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.labelSpecial2.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial2.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial2.Border.Locations = ((IzUI.WinForms.UI.Data.RectLocation)((((IzUI.WinForms.UI.Data.RectLocation.Top | IzUI.WinForms.UI.Data.RectLocation.Right) 
            | IzUI.WinForms.UI.Data.RectLocation.Bottom) 
            | IzUI.WinForms.UI.Data.RectLocation.Left)));
            this.labelSpecial2.Border.Radius = new System.Drawing.Size(0, 0);
            this.labelSpecial2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelSpecial2.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelSpecial2.Icon.IconImage = global::IzUI.WinForms.UI.Controls.Resources.ControlResources.Icon_Colors;
            this.labelSpecial2.Icon.IconSize = 150;
            this.labelSpecial2.Location = new System.Drawing.Point(510, 63);
            this.labelSpecial2.Name = "labelSpecial2";
            this.labelSpecial2.Size = new System.Drawing.Size(46, 149);
            this.labelSpecial2.TabIndex = 30;
            this.labelSpecial2.Text = "LabelSpecial";
            this.labelSpecial2.TextLayouts.Angle = 90;
            // 
            // treeViewer1
            // 
            this.treeViewer1.Animations.ColorHover = System.Drawing.Color.Empty;
            this.treeViewer1.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.treeViewer1.Animations.CursorHover = null;
            this.treeViewer1.Animations.CursorHoverLeave = null;
            this.treeViewer1.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.treeViewer1.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.treeViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeViewer1.Border.Radius = new System.Drawing.Size(0, 0);
            this.treeViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewer1.DefaultIcon = null;
            this.treeViewer1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewer1.ForeColor = System.Drawing.Color.Gainsboro;
            this.treeViewer1.Layouts.Angle = 0;
            this.treeViewer1.Location = new System.Drawing.Point(185, 115);
            this.treeViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewer1.MinusIcon = global::IzUI.WinForms.UI.Controls.Resources.ControlResources.Icon_Down;
            this.treeViewer1.Name = "treeViewer1";
            treeNode6.Name = "Node3";
            treeNode6.Text = "Node3";
            treeNode7.Name = "Node4";
            treeNode7.Text = "Node4";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Node0";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Node1";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Node2";
            this.treeViewer1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            this.treeViewer1.PlusIcon = global::IzUI.WinForms.UI.Controls.Resources.ControlResources.Icon_Right;
            this.treeViewer1.Size = new System.Drawing.Size(242, 97);
            this.treeViewer1.TabIndex = 31;
            // 
            // labelSpecial3
            // 
            this.labelSpecial3.Animations.ColorHover = System.Drawing.Color.Empty;
            this.labelSpecial3.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial3.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            this.labelSpecial3.Animations.CursorHoverLeave = null;
            this.labelSpecial3.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.labelSpecial3.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial3.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial3.Border.Locations = ((IzUI.WinForms.UI.Data.RectLocation)((((IzUI.WinForms.UI.Data.RectLocation.Top | IzUI.WinForms.UI.Data.RectLocation.Right) 
            | IzUI.WinForms.UI.Data.RectLocation.Bottom) 
            | IzUI.WinForms.UI.Data.RectLocation.Left)));
            this.labelSpecial3.Border.Radius = new System.Drawing.Size(0, 0);
            this.labelSpecial3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelSpecial3.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial3.Icon.IconImage = global::IzUI.WinForms.UI.Controls.Resources.ControlResources.Icon_Colors;
            this.labelSpecial3.Icon.IconSize = 32;
            this.labelSpecial3.Location = new System.Drawing.Point(185, 63);
            this.labelSpecial3.Name = "labelSpecial3";
            this.labelSpecial3.Size = new System.Drawing.Size(242, 37);
            this.labelSpecial3.TabIndex = 32;
            this.labelSpecial3.Text = "LabelSpecial";
            this.labelSpecial3.TextLayouts.Angle = 0;
            // 
            // labelSpecial1
            // 
            this.labelSpecial1.Animations.ColorHover = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            this.labelSpecial1.Animations.CursorHoverLeave = null;
            this.labelSpecial1.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial1.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial1.Border.Locations = ((IzUI.WinForms.UI.Data.RectLocation)((((IzUI.WinForms.UI.Data.RectLocation.Top | IzUI.WinForms.UI.Data.RectLocation.Right) 
            | IzUI.WinForms.UI.Data.RectLocation.Bottom) 
            | IzUI.WinForms.UI.Data.RectLocation.Left)));
            this.labelSpecial1.Border.Radius = new System.Drawing.Size(0, 0);
            this.labelSpecial1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelSpecial1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial1.Icon.IconImage = null;
            this.labelSpecial1.Icon.IconSize = 0;
            this.labelSpecial1.Location = new System.Drawing.Point(446, 63);
            this.labelSpecial1.Name = "labelSpecial1";
            this.labelSpecial1.Size = new System.Drawing.Size(46, 149);
            this.labelSpecial1.TabIndex = 33;
            this.labelSpecial1.Text = "LabelSpecial";
            this.labelSpecial1.TextLayouts.Angle = 90;
            // 
            // labelSpecial4
            // 
            this.labelSpecial4.Animations.ColorHover = System.Drawing.Color.Empty;
            this.labelSpecial4.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial4.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            this.labelSpecial4.Animations.CursorHoverLeave = null;
            this.labelSpecial4.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.labelSpecial4.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial4.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial4.Border.Radius = new System.Drawing.Size(0, 0);
            this.labelSpecial4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelSpecial4.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial4.Icon.IconImage = null;
            this.labelSpecial4.Icon.IconSize = 0;
            this.labelSpecial4.Location = new System.Drawing.Point(23, 142);
            this.labelSpecial4.Name = "labelSpecial4";
            this.labelSpecial4.Size = new System.Drawing.Size(144, 37);
            this.labelSpecial4.TabIndex = 35;
            this.labelSpecial4.Text = "TreeViewer";
            this.labelSpecial4.TextLayouts.Angle = 0;
            this.labelSpecial4.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSpecial5
            // 
            this.labelSpecial5.Animations.ColorHover = System.Drawing.Color.Empty;
            this.labelSpecial5.Animations.ColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial5.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            this.labelSpecial5.Animations.CursorHoverLeave = null;
            this.labelSpecial5.Animations.TextColorHover = System.Drawing.Color.Empty;
            this.labelSpecial5.Animations.TextColorHoverLeave = System.Drawing.Color.Empty;
            this.labelSpecial5.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial5.Border.Radius = new System.Drawing.Size(0, 0);
            this.labelSpecial5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelSpecial5.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial5.Icon.IconImage = null;
            this.labelSpecial5.Icon.IconSize = 0;
            this.labelSpecial5.Location = new System.Drawing.Point(23, 63);
            this.labelSpecial5.Name = "labelSpecial5";
            this.labelSpecial5.Size = new System.Drawing.Size(144, 37);
            this.labelSpecial5.TabIndex = 34;
            this.labelSpecial5.Text = "LabelSpecial";
            this.labelSpecial5.TextLayouts.Angle = 0;
            this.labelSpecial5.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.labelSpecial4);
            this.Controls.Add(this.labelSpecial5);
            this.Controls.Add(this.labelSpecial1);
            this.Controls.Add(this.labelSpecial3);
            this.Controls.Add(this.treeViewer1);
            this.Controls.Add(this.labelSpecial2);
            this.Controls.Add(this.label1);
            this.Name = "Data";
            this.Size = new System.Drawing.Size(588, 237);
            this.ResumeLayout(false);

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
