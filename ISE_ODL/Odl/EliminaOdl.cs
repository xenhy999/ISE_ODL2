namespace ISE_ODL.Odl
{
    internal class EliminaOdl : BaseCommand
    {
        public override bool CanExecute(object parameter) => BaseClasse.MenuPrincipale_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            Odl_VM odlDaRimuovere = BaseClasse.MenuPrincipale_VM.OdlSelezionata;
            BaseClasse.MenuPrincipale_VM.Commisioni.Remove(odlDaRimuovere);
        }
    }
}
