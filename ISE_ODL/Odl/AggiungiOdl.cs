namespace ISE_ODL.Odl
{
    public/*internal*/ class AggiungiOdl : BaseCommand
    {
        public Odl_VM OdlDaAggiungere;
        public override bool CanExecute(object parameter) => !(string.IsNullOrEmpty(OdlDaAggiungere.Cliente));
        public override void Execute(object parameter) => ObjContainer.MenuPrincipale_VM.Commisioni.Add(OdlDaAggiungere);
    }
}
