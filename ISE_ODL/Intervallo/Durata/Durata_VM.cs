using ISE_ODL.Resoconto.Giorno;

namespace ISE_ODL.Intervallo.Durata
{
    public class Durata_VM : BaseBinding
    {
        private DateOnly data;

        public TimeSpan Ore { get; set; }
        public DateOnly Data
        {
            get => data;
            set
            {
                data = value;
                
            }

        }
        public bool Scaricato { get; set; }

    }
}
