using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Data
{
    /// <summary>
    /// Flag checked list box control.
    /// </summary>
    public class FlagCheckedListBox : CheckedListBox
    {
        protected virtual bool IsUpdatingCheckStates { get; set; }
        protected virtual Type EnumType { get; set; }
        protected virtual Enum EnumValue { get; set; }

        /// <summary>
        /// The enum value.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Enum Enum
        {
            get => (Enum)Enum.ToObject(EnumType, GetCurrentValue());
            set
            {
                Items.Clear();

                EnumValue = value;
                EnumType = value.GetType();

                FillEnumMembers();
                ApplyEnumValue();
            }
        }

        /// <summary>
        /// Initialize a new <see cref="FlagCheckedListBox"/> object.
        /// </summary>
        public FlagCheckedListBox()
        {
            CheckOnClick = true;
        }

        /// <summary>
        /// Add a new element.
        /// </summary>
        /// <param name="v">Value.</param>
        /// <param name="c">Caption string.</param>
        /// <returns></returns>
        public virtual FlagCheckedListBoxItem Add(int v, string c)
        {
            FlagCheckedListBoxItem item = new(v, c);
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
            if (IsUpdatingCheckStates) return;

            FlagCheckedListBoxItem item = Items[e.Index] as FlagCheckedListBoxItem;
            UpdateCheckedItems(item, e.NewValue);
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        /// <param name="value">Item value.</param>
        protected virtual void UpdateCheckedItems(int value)
        {
            IsUpdatingCheckStates = true;

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
            IsUpdatingCheckStates = false;
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        /// <param name="composite">Composite item.</param>
        /// <param name="cs">Checked state.</param>
        protected virtual void UpdateCheckedItems(FlagCheckedListBoxItem composite, CheckState cs)
        {
            if (composite.Value == 0)
                UpdateCheckedItems(0);

            int sum = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (GetItemChecked(i))
                    sum |= item.Value;
            }
            if (cs == CheckState.Unchecked)
                sum &= ~composite.Value;
            else
                sum |= composite.Value;
            UpdateCheckedItems(sum);
        }

        /// <summary>
        /// Get flags value.
        /// </summary>
        /// <returns></returns>
        public virtual int GetCurrentValue()
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
        /// Fill the listbox.
        /// </summary>
        protected virtual void FillEnumMembers()
        {
            foreach (string name in Enum.GetNames(EnumType))
            {
                object val = Enum.Parse(EnumType, name);
                int intVal = (int)Convert.ChangeType(val, typeof(int));

                Add(intVal, name);
            }
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        protected virtual void ApplyEnumValue()
        {
            int intVal = (int)Convert.ChangeType(Enum, typeof(int));
            UpdateCheckedItems(intVal);
        }
    }
}
