using System.Windows.Input;

namespace RazorTemplateViewer.ViewModels.MainWindow
{
    internal class RelayCommand : ICommand
    {
        #region Private Members 
        /// <summary>
        /// action to run
        /// </summary>
        private Action<object> mAction;

        private Action cAction;
        #endregion

        #region Public Events
        /// <summary>
        /// Fired when CanExecute(object) value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for actions with parameters
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action<object> action)
        {
            mAction = action;
        }

        /// <summary>
        /// Constructor for actions with parameters
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action<object> action, Action completeAction)
        {
            mAction = action;
            cAction = completeAction;
        }

        /// <summary>
        /// Constructor for actions without parameters
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            // convert delegate with parameter to delegate without parameter for command methods that don't require parameters
            mAction = (parameter) => { action(); };
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// relay commands to execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }
        #endregion
    }
}
