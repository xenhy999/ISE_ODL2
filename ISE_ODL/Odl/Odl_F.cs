namespace ISE_ODL.Odl
{
    internal class Odl_F
    {
        public static Odl_VM Create()
        {
            AggiungiOdl aggiungiOdl = new AggiungiOdl();
            AggiornaOdl aggiornaOdl = new AggiornaOdl();
            Odl_VM odl_VM = new(new Odl_M(), aggiungiOdl, aggiornaOdl);
            aggiungiOdl.OdlDaAggiungere = odl_VM;
            aggiornaOdl.OdlDaAggiornare = odl_VM;
            return odl_VM;
        }
        public static Odl_VM CreateFromFile(string Id, string Cliente, string Note)
        {
            Odl_VM odl_VM = Create();
            odl_VM.Id = Id;
            odl_VM.Cliente = Cliente;
            odl_VM.Note = Note;
            return odl_VM;
        }
        public static Odl_VM CreateWithData(string Id, string Cliente, string Note, bool Stato, List<DateTime>  OrariInizio, List<DateTime> OrariFine, List<TimeSpan> DurataOrari)
        {
            Odl_VM odl_VM = Create();
            odl_VM.Id = Id;
            odl_VM.Cliente = Cliente;
            odl_VM.Note = Note;
            odl_VM.Stato = Stato;
            odl_VM.OrariInizio = OrariInizio;
            odl_VM.OrariFine = OrariFine;
            odl_VM.DurataOrari = DurataOrari;
            return odl_VM;
        }
    }
}
