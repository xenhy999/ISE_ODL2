using System.Timers;
using System.Windows;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    public class OdlTimer
    {
        static private int DurataTimer = 3600000;
        public Timer timer = new Timer(DurataTimer);
        public void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            MessageBoxResult risposta = MessageBox.Show("Hai passato piu di un'ora su questa attivita. Vuoi Cambiare attività?", "Timer inattività ODL", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (risposta == MessageBoxResult.Yes) Stato = false;
        }
    }
}
