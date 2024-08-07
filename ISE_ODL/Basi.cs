using System.ComponentModel;
using System.Windows.Input;
namespace ISE_ODL
{
    /// <summary>
    /// Classe base astratta che implementa l'interfaccia INotifyPropertyChanged.
    /// Fornisce il meccanismo per notificare i cambiamenti delle proprietà.
    /// </summary>
    public abstract class BaseBinding : INotifyPropertyChanged
    {
        /// <summary>
        /// Evento che viene sollevato quando una proprietà cambia.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Metodo che solleva l'evento PropertyChanged per notificare i cambiamenti di una proprietà.
        /// </summary>
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    /// <summary>
    /// Classe base astratta che implementa l'interfaccia ICommand.
    /// Fornisce il meccanismo di comando con implementazioni predefinite per CanExecuteChangede CanExecute.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Evento che viene sollevato quando il risultato di CanExecute cambia.
        /// </summary>
        public event EventHandler? CanExecuteChanged;
        /// <summary>
        /// Metodo che solleva l'evento "CanExecuteChanged per notificare i cambiamenti di eseguibilità di un comando.
        /// </summary
        public void OnRaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        /// <summary>
        /// Determina se il comando può essere eseguito.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando.</param>
        /// <returns>Restituisce sempre <c>true</c> nella implementazione di default.</returns>
        public virtual bool CanExecute(object parameter) => true;
        /// <summary>
        /// Metodo astratto che esegue l'azione del comando.
        /// Deve essere implementato nelle classi derivate.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando.</param>
        public abstract void Execute(object parameter);
    }
}
