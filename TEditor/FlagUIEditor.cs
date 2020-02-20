using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using Iswenzz.UI.Controls.Containers;

namespace Iswenzz.UI.TEditor
{
    public class FlagUIEditor : UITypeEditor
    {
        private readonly FlagCheckedListBox flagListBox = new FlagCheckedListBox();

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null)
                {
                    Enum e = (Enum)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);
                    flagListBox.EnumValue = e;
                    edSvc.DropDownControl(flagListBox);
                    return flagListBox.EnumValue;
                }
            }
            return null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
