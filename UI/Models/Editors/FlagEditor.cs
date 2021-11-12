using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using Iswenzz.UI.Controls.Data;

namespace Iswenzz.UI.Models.Editors
{
    /// <summary>
    /// Represent a flag <see cref="UITypeEditor"/>.
    /// </summary>
    public class FlagEditor : UITypeEditor
    {
        private FlagCheckedListBox FlagListBox { get; } = new FlagCheckedListBox();

        /// <summary>
        /// Edit value callback.
        /// </summary>
        /// <param name="context">The editor context.</param>
        /// <param name="provider">The service provider.</param>
        /// <param name="value">The value to update.</param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider
                    .GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null)
                {
                    Enum e = (Enum)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);
                    FlagListBox.Enum = e;
                    edSvc.DropDownControl(FlagListBox);
                    return FlagListBox.Enum;
                }
            }
            return null;
        }

        /// <summary>
        /// Get the <see cref="UITypeEditorEditStyle"/> style.
        /// </summary>
        /// <param name="context">The editor context.</param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
