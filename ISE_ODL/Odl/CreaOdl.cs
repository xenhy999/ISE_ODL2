namespace ISE_ODL.Odl
{
    internal class CreaOdl : BaseCommand
    {
        public override void Execute(object parameter)
        {
            Odl_V old_V = new() { DataContext = Odl_F.Create() };
            old_V.ShowDialog();
        }
    }
}
