using System.Windows;

namespace ISE_ODL.Odl
{
    internal class EliminaOdl : BaseCommand
    {
        public override bool CanExecute(object parameter) => ObjContainer.MenuPrincipale_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            //RichiestaEliminazione_VM richiestaEliminazione_VM= new RichiestaEliminazione_VM(new ConfermaEliminazione());
            //RichiestaEliminazioneOdl_V richiestaEliminazioneOdl_V = new RichiestaEliminazioneOdl_V();
            //richiestaEliminazioneOdl_V.Show();
            MessageBoxResult risposta = MessageBox.Show("Vuoi davvero eliminare...", "Eliminazione ODL", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (risposta == MessageBoxResult.OK)
            {
                Odl_VM odlDaRimuovere = ObjContainer.MenuPrincipale_VM.OdlSelezionata;
                ObjContainer.MenuPrincipale_VM.Commisioni.Remove(odlDaRimuovere);
            }
        }
    }
}
