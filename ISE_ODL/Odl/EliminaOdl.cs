using System.Windows;
namespace ISE_ODL.Odl
{
    internal class EliminaOdl : BaseCommand
    {
        private const string MessageBoxText = "Vuoi davvero eliminare questa ODL";
        private const string Caption = "Eliminazione ODL";
        public override bool CanExecute(object parameter) => ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            if (MessageBox.Show(MessageBoxText, Caption, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Odl_VM odlDaRimuovere = ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata;
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Remove(odlDaRimuovere);
            }
        }
    }
}
