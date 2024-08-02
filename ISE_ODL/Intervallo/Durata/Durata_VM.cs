namespace ISE_ODL.Intervallo.Durata
{
    public class Durata_VM : BaseBinding
    {
        public TimeSpan Ore { get; set; }
        public DateOnly Data { get; set; }
        public bool Scaricato { get; set; }
    }
}
