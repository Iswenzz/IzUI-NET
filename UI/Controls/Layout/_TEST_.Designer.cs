namespace Iswenzz.UI.Controls.Layout
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node2");
            this.panelSeparator1 = new Iswenzz.UI.Controls.Layout.PanelSeparator();
            this.treeViewer1 = new Iswenzz.UI.Controls.Data.TreeViewer();
            this.separator1 = new Iswenzz.UI.Controls.Layout.Separator();
            this.panelBorder1 = new Iswenzz.UI.Controls.Layout.PanelBorder();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSpecial1 = new Iswenzz.UI.Controls.Data.LabelSpecial();
            this.labelSpecial2 = new Iswenzz.UI.Controls.Data.LabelSpecial();
            this.labelSpecial3 = new Iswenzz.UI.Controls.Data.LabelSpecial();
            this.labelSpecial4 = new Iswenzz.UI.Controls.Data.LabelSpecial();
            this.SuspendLayout();
            // 
            // panelSeparator1
            // 
            this.panelSeparator1.BorderColor = System.Drawing.Color.SteelBlue;
            this.panelSeparator1.Location = new System.Drawing.Point(145, 241);
            this.panelSeparator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSeparator1.Name = "panelSeparator1";
            this.panelSeparator1.SeparatorLocation = ((Iswenzz.UI.Data.RectLocation)((Iswenzz.UI.Data.RectLocation.Right | Iswenzz.UI.Data.RectLocation.Left)));
            this.panelSeparator1.Size = new System.Drawing.Size(106, 69);
            this.panelSeparator1.TabIndex = 23;
            this.panelSeparator1.Thickness = 5F;
            // 
            // treeViewer1
            // 
            this.treeViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.treeViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewer1.DefaultIcon = null;
            this.treeViewer1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeViewer1.ForeColor = System.Drawing.Color.Gainsboro;
            this.treeViewer1.Location = new System.Drawing.Point(145, 338);
            this.treeViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeViewer1.MinusIcon = ((System.Drawing.Image)(resources.GetObject("treeViewer1.MinusIcon")));
            this.treeViewer1.Name = "treeViewer1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Node0";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Node1";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Node2";
            this.treeViewer1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewer1.PlusIcon = ((System.Drawing.Image)(resources.GetObject("treeViewer1.PlusIcon")));
            this.treeViewer1.Size = new System.Drawing.Size(106, 104);
            this.treeViewer1.TabIndex = 22;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.Transparent;
            this.separator1.ForeColor = System.Drawing.Color.DimGray;
            this.separator1.IsTransparent = true;
            this.separator1.Location = new System.Drawing.Point(15, 111);
            this.separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.separator1.Name = "separator1";
            this.separator1.SeparatorThickness = 0F;
            this.separator1.Size = new System.Drawing.Size(236, 18);
            this.separator1.TabIndex = 18;
            this.separator1.Text = "separator1";
            // 
            // panelBorder1
            // 
            this.panelBorder1.BorderColor = System.Drawing.Color.SteelBlue;
            this.panelBorder1.Location = new System.Drawing.Point(145, 147);
            this.panelBorder1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(106, 68);
            this.panelBorder1.TabIndex = 15;
            this.panelBorder1.Thickness = 5F;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 54);
            this.label1.TabIndex = 24;
            this.label1.Text = "Layout";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpecial1
            // 
            this.labelSpecial1.Angle = 0;
            this.labelSpecial1.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpecial1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial1.IsTransparent = true;
            this.labelSpecial1.Location = new System.Drawing.Point(15, 74);
            this.labelSpecial1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSpecial1.Name = "labelSpecial1";
            this.labelSpecial1.RoundedCorner = 0;
            this.labelSpecial1.Size = new System.Drawing.Size(97, 30);
            this.labelSpecial1.TabIndex = 25;
            this.labelSpecial1.Text = "Separator";
            this.labelSpecial1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSpecial2
            // 
            this.labelSpecial2.Angle = 0;
            this.labelSpecial2.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpecial2.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial2.IsTransparent = true;
            this.labelSpecial2.Location = new System.Drawing.Point(15, 171);
            this.labelSpecial2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSpecial2.Name = "labelSpecial2";
            this.labelSpecial2.RoundedCorner = 0;
            this.labelSpecial2.Size = new System.Drawing.Size(109, 26);
            this.labelSpecial2.TabIndex = 26;
            this.labelSpecial2.Text = "PanelBorder";
            this.labelSpecial2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSpecial3
            // 
            this.labelSpecial3.Angle = 0;
            this.labelSpecial3.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpecial3.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial3.IsTransparent = true;
            this.labelSpecial3.Location = new System.Drawing.Point(15, 263);
            this.labelSpecial3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSpecial3.Name = "labelSpecial3";
            this.labelSpecial3.RoundedCorner = 0;
            this.labelSpecial3.Size = new System.Drawing.Size(130, 28);
            this.labelSpecial3.TabIndex = 27;
            this.labelSpecial3.Text = "PanelSeparator";
            this.labelSpecial3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSpecial4
            // 
            this.labelSpecial4.Angle = 0;
            this.labelSpecial4.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpecial4.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial4.IsTransparent = true;
            this.labelSpecial4.Location = new System.Drawing.Point(15, 374);
            this.labelSpecial4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSpecial4.Name = "labelSpecial4";
            this.labelSpecial4.RoundedCorner = 0;
            this.labelSpecial4.Size = new System.Drawing.Size(97, 25);
            this.labelSpecial4.TabIndex = 28;
            this.labelSpecial4.Text = "TreeViewer";
            this.labelSpecial4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.labelSpecial4);
            this.Controls.Add(this.labelSpecial3);
            this.Controls.Add(this.labelSpecial2);
            this.Controls.Add(this.labelSpecial1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSeparator1);
            this.Controls.Add(this.treeViewer1);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.panelBorder1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Test";
            this.Size = new System.Drawing.Size(272, 471);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.Layout.PanelBorder panelBorder1;
        private Controls.Layout.Separator separator1;
        private Controls.Data.TreeViewer treeViewer1;
        private Controls.Layout.PanelSeparator panelSeparator1;
        private System.Windows.Forms.Label label1;
        private Data.LabelSpecial labelSpecial1;
        private Data.LabelSpecial labelSpecial2;
        private Data.LabelSpecial labelSpecial3;
        private Data.LabelSpecial labelSpecial4;
    }
}
