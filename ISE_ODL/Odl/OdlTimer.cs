using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    public class OdlTimer:BaseBinding
    {
        public string Message;
        public string Title;
        private TimeSpan durataTimer;
        private bool timerAbilitato;

        public bool TimerAbilitato
        {
            get { 
                return timerAbilitato; 
            }
            set
            {
                timerAbilitato = value;
                if (timerAbilitato)
                {
                    Timer.Start();
                    Timer.Elapsed += Time_Elapsed;
                }
                else Timer.Stop();
            }
        }
        public  Timer Timer { get; set; }
        public TimeSpan DurataTimer
        {
            get => durataTimer;
            set
            {
                durataTimer = value;
                Timer = new Timer(durataTimer);
            }
        }
        public OdlTimer()
        {
            DurataTimer=new TimeSpan(0,0,10);
            Message = "Attenzione";
            Title = "Hai Passato più di un ora su questa attività";
        }
        public void Start() 
        {
            if (TimerAbilitato)
            {
                Timer.Start();
                Timer.Elapsed += Time_Elapsed;
            }
        }
        public void End()
        {
            if (TimerAbilitato) Timer.Stop();
        }
        //public void TimerAbilitato(bool stato)=> timer.Enabled = stato;
        public void Time_Elapsed(object? sender, ElapsedEventArgs e) => ShowNotifications(Title, Message);
        public static void ShowNotifications(string message, string title) => new ToastContentBuilder().AddText(message).AddText(title).Show();

    }
}
