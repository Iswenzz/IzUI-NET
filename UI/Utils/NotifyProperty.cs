using Iswenzz.UI.Design;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iswenzz.UI.Utils
{
    /// <summary>
    /// Utils for the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    public static class NotifyProperty
    {
        /// <summary>
        /// Callback on property changed.
        /// </summary>
        /// <typeparam name="T">The class where the property changed.</typeparam>
        /// <param name="instance">The class instance.</param>
        /// <param name="e">Property changed event.</param>
        /// <param name="args">Property changed event args.</param>
        public static void Callback<T>(T instance, PropertyChangedEventHandler e, 
            PropertyChangedEventArgs args) where T : INotifyPropertyChanged
        {
            e?.Invoke(instance, args);

            if (instance is Control)
                (instance as Control).Invalidate();
            if (instance is Design.AbstractDesign)
                (instance as Design.AbstractDesign).Owner.Invalidate();
        }
    }
}
