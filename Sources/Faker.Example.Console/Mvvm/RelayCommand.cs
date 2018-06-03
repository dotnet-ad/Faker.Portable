using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Faker.Example.Console.Mvvm
{
    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members

        /// <summary>
        /// Sets Can Execute Property to True or False
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Whether or not the action can execute</returns>
        /// <remarks>
        /// Uses DebuggerStepThrough from System.Diagnostics
        /// CanExecute can happen a lot as the UI checks if it CanExecute something.
        /// Debugger will step over unless there is an explicit break point inside of it
        /// </remarks>
        [DebuggerStepThrough()]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Listener when CanExecute Property Changes
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Launches Execute ICommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
