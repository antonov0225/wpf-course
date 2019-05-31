using System.ComponentModel;
using PropertyChanged;
namespace Fasetto.Word
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    class BaseViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Event that that is fired when any child changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {
        };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
