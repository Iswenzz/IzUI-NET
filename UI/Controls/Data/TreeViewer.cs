using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Data
{
    public partial class TreeViewer : TreeView
    {
        private Image minusIcon;
        /// <summary>
        /// Collapase Icon.
        /// </summary>
        [Description("The collapase icon.")]
        public Image MinusIcon
        {
            get => minusIcon;
            set { minusIcon = value; Invalidate(); }
        }

        private Image plusIcon;
        [Description("The expand icon.")]
        public Image PlusIcon
        {
            get => plusIcon;
            set { plusIcon = value; Invalidate(); }
        }

        private Image defaultIcon;
        /// <summary>
        /// Default icon.
        /// </summary>
        [Description("The default icon.")]
        public Image DefaultIcon
        {
            get => defaultIcon;
            set { defaultIcon = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="TreeViewer"/> object.
        /// </summary>
        public TreeViewer()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            DrawNode += Tree_DrawIcons;
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
        /// Drawing of all <see cref="TreeNode"/>.
        /// </summary>
        public virtual void Tree_DrawIcons(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = e.Node.Bounds;
            Graphics g;

            // Node Icon
            bool hasImage = false;
            Point ptNodeIcon = new Point(nodeRect.Location.X - 18, nodeRect.Location.Y + 2);
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

            // Plus / Minus Icon
            Point ptExpand;
            if (!hasImage)
                ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
            else
                ptExpand = new Point(nodeRect.Location.X - 40, nodeRect.Location.Y + 2);

            Image expandImg;
            if (e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = MinusIcon;
            else if (!e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = PlusIcon;
            else
                expandImg = DefaultIcon;

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
