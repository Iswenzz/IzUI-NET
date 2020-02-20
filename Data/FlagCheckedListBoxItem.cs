namespace Iswenzz.UI.Data
{
    /// <summary>
    /// Represent a <see cref="FlagCheckedListBox"/> item.
    /// </summary>
    public class FlagCheckedListBoxItem
    {
        public int value;
        public string caption;

        /// <summary>
        /// Initialize a new <see cref="FlagCheckedListBoxItem"/> object.
        /// </summary>
        /// <param name="v">Itme value.</param>
        /// <param name="c">Caption string.</param>
        public FlagCheckedListBoxItem(int v, string c)
        {
            value = v;
            caption = c;
        }

        /// <summary>
        /// Return the caption name.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => caption;

        public bool IsFlag { get => (value & (value - 1)) == 0; }

        public bool IsMemberFlag(FlagCheckedListBoxItem composite) =>
            IsFlag && ((value & composite.value) == value);
    }
}
