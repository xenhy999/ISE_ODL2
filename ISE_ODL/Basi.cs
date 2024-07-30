using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ISE_ODL
{
    public /*internal*/ abstract class BaseBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public /*internal*/ abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public void OnRaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);
    }
}
