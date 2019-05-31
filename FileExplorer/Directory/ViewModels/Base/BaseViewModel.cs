using System.ComponentModel;
using PropertyChanged;
namespace FileExplorer
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterfaceAttribute]
    class BaseViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Event that that is fired when any child changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {
        };
    }
}
