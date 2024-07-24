namespace ISE_ODL.Odl
{
    internal class ModificaOdl : BaseCommand
    {
        public override bool CanExecute(object parameter) => ObjContainer.MenuPrincipale_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            ObjContainer.MenuPrincipale_VM.OdlSelezionata.OdlInModifica = true;
            Odl_V odl_V = new Odl_V();
            odl_V.DataContext = ObjContainer.MenuPrincipale_VM.OdlSelezionata;
            odl_V.ShowDialog();
        }
    }
}
