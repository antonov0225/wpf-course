using System;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// Basic command that runs actions
    /// </summary>
    class RelayCommand: ICommand
    {
        private Action _action;

        /// <summary>
        /// Event that's fired when the <see cref="CanExcute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// A relay command can always be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
