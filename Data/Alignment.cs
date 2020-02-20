using System.Drawing;

namespace Iswenzz.UI.Data
{
    public static class Alignment
    {
        public static StringAlignment GetAlignment(ContentAlignment textAlign) => textAlign switch
        {
            ContentAlignment.BottomCenter   => StringAlignment.Far,
            ContentAlignment.BottomLeft     => StringAlignment.Far,
            ContentAlignment.BottomRight    => StringAlignment.Far, 
            ContentAlignment.MiddleCenter   => StringAlignment.Center,
            ContentAlignment.MiddleLeft     => StringAlignment.Center,
            ContentAlignment.MiddleRight    => StringAlignment.Center, 
            ContentAlignment.TopCenter      => StringAlignment.Near,
            ContentAlignment.TopLeft        => StringAlignment.Near,
            ContentAlignment.TopRight       => StringAlignment.Near,
            _                               => StringAlignment.Center
        };
            
        public static StringAlignment GetLineAlignment(ContentAlignment textAlign) => textAlign switch
        {
            ContentAlignment.BottomCenter   => StringAlignment.Center,
            ContentAlignment.BottomLeft     => StringAlignment.Near,
            ContentAlignment.BottomRight    => StringAlignment.Far, 
            ContentAlignment.MiddleCenter   => StringAlignment.Center,
            ContentAlignment.MiddleLeft     => StringAlignment.Near,
            ContentAlignment.MiddleRight    => StringAlignment.Far, 
            ContentAlignment.TopCenter      => StringAlignment.Center,
            ContentAlignment.TopLeft        => StringAlignment.Near,
            ContentAlignment.TopRight       => StringAlignment.Far,
            _                               => StringAlignment.Center
        };
    }
}
