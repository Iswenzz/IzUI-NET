using Iswenzz.UI.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Containers
{
    public partial class FlagCheckedListBox : CheckedListBox
    {
        private bool isUpdatingCheckStates = false;
        private Type enumType;
        private Enum enumValue;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Enum EnumValue
        {
            get
            {
                object e = Enum.ToObject(enumType, GetCurrentValue());
                return (Enum)e;
            }
            set
            {
                Items.Clear();
                enumValue = value;
                enumType = value.GetType();
                FillEnumMembers();
                ApplyEnumValue();
            }
        }

        /// <summary>
        /// Initialize a new <see cref="FlagCheckedListBox"/> object.
        /// </summary>
        public FlagCheckedListBox()
        {
            InitializeComponent();
            CheckOnClick = true;
        }

        /// <summary>
        /// Add a new element.
        /// </summary>
        /// <param name="v">Value</param>
        /// <param name="c">Caption string</param>
        /// <returns></returns>
        public FlagCheckedListBoxItem Add(int v, string c)
        {
            FlagCheckedListBoxItem item = new FlagCheckedListBoxItem(v, c);
            Items.Add(item);
            return item;
        }

        /// <summary>
        /// Add a new element.
        /// </summary>
        /// <param name="item">Item object</param>
        /// <returns></returns>
        public FlagCheckedListBoxItem Add(FlagCheckedListBoxItem item)
        {
            Items.Add(item);
            return item;
        }

        /// <summary>
        /// Item check callback.
        /// </summary>
        /// <param name="e">Callback data</param>
        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            base.OnItemCheck(e);
            if (isUpdatingCheckStates) return;

            FlagCheckedListBoxItem item = Items[e.Index] as FlagCheckedListBoxItem;
            UpdateCheckedItems(item, e.NewValue);
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        /// <param name="value">Item value</param>
        protected void UpdateCheckedItems(int value)
        {
            isUpdatingCheckStates = true;

            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (item.value == 0)
                    SetItemChecked(i, value == 0);
                else
                {
                    if ((item.value & value) == item.value && item.value != 0)
                        SetItemChecked(i, true);
                    else
                        SetItemChecked(i, false);
                }
            }
            isUpdatingCheckStates = false;
        }

        /// <summary>
        /// Update flags
        /// </summary>
        /// <param name="composite"></param>
        /// <param name="cs"></param>
        protected void UpdateCheckedItems(FlagCheckedListBoxItem composite, CheckState cs)
        {
            if (composite.value == 0)
                UpdateCheckedItems(0);

            int sum = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (GetItemChecked(i))
                    sum |= item.value;
            }

            if (cs == CheckState.Unchecked)
                sum &= ~composite.value;
            else
                sum |= composite.value;

            UpdateCheckedItems(sum);
        }

        /// <summary>
        /// Get flags value.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentValue()
        {
            int sum = 0;

            for (int i = 0; i < Items.Count; i++)
            {
                FlagCheckedListBoxItem item = Items[i] as FlagCheckedListBoxItem;

                if (GetItemChecked(i))
                    sum |= item.value;
            }
            return sum;
        }

        /// <summary>
        /// Fill the listbox.
        /// </summary>
        private void FillEnumMembers()
        {
            foreach (string name in Enum.GetNames(enumType))
            {
                object val = Enum.Parse(enumType, name);
                int intVal = (int)Convert.ChangeType(val, typeof(int));

                Add(intVal, name);
            }
        }

        /// <summary>
        /// Update flags.
        /// </summary>
        private void ApplyEnumValue()
        {
            int intVal = (int)Convert.ChangeType(enumValue, typeof(int));
            UpdateCheckedItems(intVal);
        }
    }
}
