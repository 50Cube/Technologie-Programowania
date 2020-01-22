using System;
using System.Windows.Input;

namespace ViewModel
{
    public class MyCommand : ICommand
    {
        private Action execute;
        public event EventHandler CanExecuteChanged;

        public MyCommand(Action command)
        {
            this.execute = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute();
        }
        }
}
