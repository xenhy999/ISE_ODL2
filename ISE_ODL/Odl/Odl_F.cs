namespace ISE_ODL.Odl
{
    internal class Odl_F
    {
        public static Odl_VM Create(Odl_M odl_M)
        {
            AggiungiOdl aggiungiOdl = new();
            AggiornaOdl aggiornaOdl = new();
            Odl_VM odl_VM = new(odl_M, aggiungiOdl, aggiornaOdl);
            aggiungiOdl.OdlDaAggiungere = odl_VM;
            aggiornaOdl.OdlDaAggiornare = odl_VM;
            return odl_VM;
        }
        public static Odl_VM Create()
        {
            Odl_M odl_M = new() { Completata=false};
            return Create(odl_M);
        }
    }
}
