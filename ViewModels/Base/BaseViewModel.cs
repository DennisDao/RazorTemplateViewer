using System.ComponentModel;

namespace RazorTemplateViewer.ViewModels.Base
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {

        }

        public BaseViewModel()
        {
            PropertyChanged += PropertyChangedHandler;
        }

        protected void RaisePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }

        public void Refresh()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
