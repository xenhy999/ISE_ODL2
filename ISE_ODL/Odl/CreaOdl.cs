namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe rappresenta un comando per creare un nuovo ordine di lavoro (Odl).
    /// </summary>
    public class CreaOdl : BaseCommand
    {
        /// <summary>
        /// Esegue il comando per creare un nuovo ordine di lavoro.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando. Non utilizzato in questa implementazione.</param>
        public override void Execute(object parameter)
        {
            Odl_V old_V = new() { DataContext = Odl_F.Create() };
            old_V.ShowDialog();
        }
    }
}
