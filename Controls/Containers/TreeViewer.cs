using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Containers
{
    public partial class TreeViewer : TreeView
    {
        private Image minusIcon;
        [Description("The minus icon.")]
        public Image MinusIcon
        {
            get => minusIcon;
            set { minusIcon = value; Invalidate(); }
        }

        private Image plusIcon;
        [Description("The plus icon.")]
        public Image PlusIcon
        {
            get => plusIcon;
            set { plusIcon = value; Invalidate(); }
        }

        private Image defaultIcon;
        [Description("The default icon.")]
        public Image DefaultIcon
        {
            get => defaultIcon;
            set { defaultIcon = value; Invalidate(); }
        }

        public TreeViewer()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            DrawNode += Tree_DrawIcons;
        }

        /// <summary>
        /// Drawing of all <see cref="TreeNode"/>.
        /// </summary>
        public virtual void Tree_DrawIcons(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = e.Node.Bounds;
            Graphics g;
            IntPtr imgPtr;

            // Plus / Minus Icon
            Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
            Image expandImg = null;

            if (e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = MinusIcon;
            else if (!e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                expandImg = PlusIcon;
            else
                expandImg = DefaultIcon;

            if (expandImg != null)
            {
                expandImg = new Bitmap(expandImg, new Size(14, 14));
                g = Graphics.FromImage(expandImg);
                imgPtr = g.GetHdc();
                g.ReleaseHdc();
                e.Graphics.DrawImage(expandImg, ptExpand);
            }

            // Node Icon
            Point ptNodeIcon = new Point(nodeRect.Location.X - 4, nodeRect.Location.Y + 2);
            if (e.Node.ImageKey != null && e.Node.TreeView.ImageList != null)
            {
                Image nodeImg = e.Node.TreeView.ImageList.Images[e.Node.ImageKey];
                if (nodeImg != null)
                {
                    g = Graphics.FromImage(nodeImg);
                    imgPtr = g.GetHdc();
                    g.ReleaseHdc();
                    e.Graphics.DrawImage(nodeImg, ptNodeIcon);
                }
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
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush,
                Rectangle.Inflate(textRect, -12, 0));
        }
    }
}
