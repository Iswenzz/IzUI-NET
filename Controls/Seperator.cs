using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    public partial class Seperator : Control
    {
        public Seperator()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Rectangle rect = new Rectangle(0, 0, Width, Height);


        }
    }
}
