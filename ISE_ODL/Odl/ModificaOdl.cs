namespace ISE_ODL.Odl
{
    internal class ModificaOdl : BaseCommand
    {
        public override bool CanExecute(object parameter) => ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata != null;
        public override void Execute(object parameter)
        {
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata.OdlInModifica = true;
            Odl_V odl_V = new() { DataContext = ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata };
            odl_V.ShowDialog();
        }
    }
}
