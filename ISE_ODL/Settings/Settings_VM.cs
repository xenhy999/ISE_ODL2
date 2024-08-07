namespace ISE_ODL.Settings
{
    public class Settings_VM : BaseBinding
    {
        public bool TimerAbilitato { get => Properties.Settings.Default.TimerAttivo; set => Properties.Settings.Default["TimerAttivo"] = value; }
        public TimeSpan DurataDelTimer
        {
            get => Properties.Settings.Default.DurataDelTimer;
            set
            {
                OnPropertyChanged(nameof(DurataDelTimer));
                Properties.Settings.Default["DurataDelTimer"] = value;
                ObjContainer.OdlTimer?.ResetTimer();
            }
        }
        public TimeSpan DurataMinimaOdl
        {
            get => Properties.Settings.Default.DurataMinimaOdl;
            set
            {
                OnPropertyChanged(nameof(DurataMinimaOdl));
                Properties.Settings.Default["DurataMinimaOdl"] = value;
            }
        }
        public TimeSpan IntervalloInModifica
        {
            get => Properties.Settings.Default.IntervalloInModifica;
            set
            {
                OnPropertyChanged(nameof(IntervalloInModifica));
                Properties.Settings.Default["IntervalloInModifica"] = value;
            }
        }
    }
}
