using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Controls.Data
{
    /// <summary>
    /// Flag checked list box control.
    /// </summary>
    public class FlagCheckedListBox : CheckedListBox
    {
        protected virtual Type EnumType { get; set; }
        protected virtual Enum EnumValue { get; set; }

        /// <summary>
        /// The enum value.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Enum Enum
        {
            get => (Enum)Enum.ToObject(EnumType, GetValue());
            set
            {
                Items.Clear();

                EnumValue = value;
                EnumType = value.GetType();

                LoadEnum();
            }
        }

        /// <summary>
        /// Initialize a new <see cref="FlagCheckedListBox"/> object.
        /// </summary>
        public FlagCheckedListBox() : base()
        {
            CheckOnClick = true;
        }

        /// <summary>
        /// On create control.
        /// </summary>
        /// <exception cref="NotImplementedException">Not implemented.</exception>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="label">Label string.</param>
        /// <returns></returns>
        public virtual FlagCheckedListBoxItem Add(int value, string label)
        {
            FlagCheckedListBoxItem item = new(value, label);
            Items.Add(item);
            return item;
        }

        /// <summary>
        /// Add a new element.
        /// </summary>
        /// <param name="item">Item object.</param>
        /// <returns></returns>
        public virtual FlagCheckedListBoxItem Add(FlagCheckedListBoxItem item)
        {
            Items.Add(item);
            return item;
        }

        /// <summary>
        /// Item check callback.
        /// </summary>
        /// <param name="e">Callback data.</param>
        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            base.OnItemCheck(e);
            FlagCheckedListBoxItem item = Items[e.Index] as FlagCheckedListBoxItem;
            UpdateValue(item, e.NewValue);
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        /// <param name="value">Item value.</param>
        protected virtual void UpdateValue(int value)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (item.Value == 0)
                    SetItemChecked(i, value == 0);
                else
                {
                    if ((item.Value & value) == item.Value && item.Value != 0)
                        SetItemChecked(i, true);
                    else
                        SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="cs">Checked state.</param>
        protected virtual void UpdateValue(FlagCheckedListBoxItem item, CheckState cs)
        {
            if (item.Value == 0)
                UpdateValue(0);

            int sum = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem current = Items[i] as FlagCheckedListBoxItem;
                if (GetItemChecked(i))
                    sum |= current.Value;
            }
            if (cs == CheckState.Unchecked)
                sum &= ~item.Value;
            else
                sum |= item.Value;

            UpdateValue(sum);
        }

        /// <summary>
        /// Get flags value.
        /// </summary>
        /// <returns></returns>
        public virtual int GetValue()
        {
            int sum = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (GetItemChecked(i))
                    sum |= item.Value;
            }
            return sum;
        }

        /// <summary>
        /// Load the listbox.
        /// </summary>
        protected virtual void LoadEnum()
        {
            foreach (string name in Enum.GetNames(EnumType))
            {
                object val = Enum.Parse(EnumType, name);
                int intVal = (int)Convert.ChangeType(val, typeof(int));

                Add(intVal, name);
            }
            UpdateValue((int)Convert.ChangeType(EnumValue, typeof(int)));
        }

        /// <summary>
        /// Represent a <see cref="FlagCheckedListBox"/> item.
        /// </summary>
        public class FlagCheckedListBoxItem
        {
            public int Value { get; set; }
            public string Label { get; set; }

            /// <summary>
            /// Initialize a new <see cref="FlagCheckedListBoxItem"/> object.
            /// </summary>
            /// <param name="v">Item value.</param>
            /// <param name="c">Label string.</param>
            public FlagCheckedListBoxItem(int v, string c)
            {
                Value = v;
                Label = c;
            }

            /// <summary>
            /// Return the label name.
            /// </summary>
            /// <returns></returns>
            public override string ToString() => Label;

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
}
