namespace ISE_ODL.Odl
{
    internal class EliminaOdl : BaseCommand
    {
        public override bool CanExecute(object parameter) => ObjContainer.MenuPrincipale_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            Odl_VM odlDaRimuovere = ObjContainer.MenuPrincipale_VM.OdlSelezionata;
            ObjContainer.MenuPrincipale_VM.Commisioni.Remove(odlDaRimuovere);
        }
    }
}
