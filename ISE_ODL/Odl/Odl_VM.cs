namespace ISE_ODL.Odl
{
    internal class Odl_VM : BaseBinding
    {
        public Odl_M Odl_M;
        public string Id { get => Odl_M.Id; set => Odl_M.Id = value; }
        public string Cliente { get => Odl_M.Cliente; set => Odl_M.Cliente = value; }
        public string Note { get => Odl_M.Note; set => Odl_M.Note = value; }
        public bool Stato { get => Odl_M.Stato; set => Odl_M.Stato = value; }
        public AggiungiOdl AggiungiOdl { get; set; }
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl)
        {
            Odl_M = odl_M;
            AggiungiOdl = aggiungiOdl;
        }
    }
}
