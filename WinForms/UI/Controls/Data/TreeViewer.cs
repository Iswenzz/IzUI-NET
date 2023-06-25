using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Controls.Data
{
    /// <summary>
    /// Tree viewer control.
    /// </summary>
    public partial class TreeViewer : AbstractTreeView
    {
        /// <summary>
        /// Collapase icon.
        /// </summary>
        [Category("Appearance"), Description("The collapase icon.")]
        public virtual Image MinusIcon { get; set; }

        /// <summary>
        /// Expand icon.
        /// </summary>
        [Category("Appearance"), Description("The expand icon.")]
        public virtual Image PlusIcon { get; set; }

        /// <summary>
        /// Default icon.
        /// </summary>
        [Category("Appearance"), Description("The default icon.")]
        public virtual Image DefaultIcon { get; set; }

        /// <summary>
        /// Initialize a new <see cref="TreeViewer"/> object.
        /// </summary>
        public TreeViewer() : base()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            DrawNode += OnDrawIcons;
        }

        /// <summary>
        /// Expand callback.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);
            Invalidate();
        }

        /// <summary>
        /// Render all <see cref="TreeNode"/>.
        /// </summary>
        public virtual void OnDrawIcons(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = e.Node.Bounds;
            Graphics g;

            // Node Icon
            bool hasImage = false;
            Point ptNodeIcon = new(nodeRect.Location.X - 18, nodeRect.Location.Y + 2);
            if (e.Node.ImageKey != null && e.Node.TreeView.ImageList != null)
            {
                hasImage = true;
                Image nodeImg = e.Node.TreeView.ImageList.Images[e.Node.ImageKey];
                if (nodeImg != null)
                {
                    g = Graphics.FromImage(nodeImg);
                    _ = g.GetHdc();
                    g.ReleaseHdc();
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImage(nodeImg, ptNodeIcon);
                }
            }

            // Plus / Minus icon
            Point ptExpand = new(nodeRect.Location.X - (hasImage ? 40 : 20), nodeRect.Location.Y + 2);

            // Expand icon
            Image expandImg;
            if (e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = MinusIcon;
            else if (!e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = PlusIcon;
            else
                expandImg = DefaultIcon;

            // Render icon
            if (expandImg != null)
            {
                expandImg = new Bitmap(expandImg, new Size(nodeRect.Size.Height - 4, nodeRect.Size.Height - 4));
                g = Graphics.FromImage(expandImg);
                _ = g.GetHdc();
                g.ReleaseHdc();
                e.Graphics.DrawImage(expandImg, ptExpand);
                expandImg.Dispose();
            }

            // Node Text
            Rectangle textRect = nodeRect;
            Font nodeFont = e.Node.NodeFont;
            Brush textBrush = new SolidBrush(e.Node.TreeView.ForeColor);

            if (nodeFont == null)
                nodeFont = e.Node.TreeView.Font;
            if ((e.State & TreeNodeStates.Focused) != 0)
                textBrush = new SolidBrush(ControlPaint.Dark(e.Node.TreeView.ForeColor, 0.2f));

            textRect.Width += 40;
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, textRect);
            textBrush.Dispose();
        }
    }
}
