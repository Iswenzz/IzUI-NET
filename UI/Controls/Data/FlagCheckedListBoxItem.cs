namespace Iswenzz.UI.Controls.Data
{
    /// <summary>
    /// Represent a <see cref="FlagCheckedListBox"/> item.
    /// </summary>
    public class FlagCheckedListBoxItem
    {
        public int Value { get; set; }
        public string Caption { get; set; }

        /// <summary>
        /// Initialize a new <see cref="FlagCheckedListBoxItem"/> object.
        /// </summary>
        /// <param name="v">Itme value.</param>
        /// <param name="c">Caption string.</param>
        public FlagCheckedListBoxItem(int v, string c)
        {
            Value = v;
            Caption = c;
        }

        /// <summary>
        /// Return the caption name.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Caption;

        /// <summary>
        /// Check if a flag is set.
        /// </summary>
        public bool IsFlag { get => (Value & (Value - 1)) == 0; }

        /// <summary>
        /// Check if item value is set.
        /// </summary>
        /// <param name="composite"><see cref="FlagCheckedListBoxItem"/> item value.</param>
        /// <returns></returns>
        public bool IsMemberFlag(FlagCheckedListBoxItem composite) =>
            IsFlag && ((Value & composite.Value) == Value);
    }
}
