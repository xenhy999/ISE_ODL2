using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    public class OdlTimer
    {
        public string Message;
        public string Title;
        static public TimeSpan DurataTimer = new TimeSpan(0, 0,10);
        private Timer timer = new Timer(DurataTimer);
        public OdlTimer(string title, string message)
        {
            Message = message;
            Title = title;
        }
        public void Start() { 
            timer.Start();
            timer.Enabled = true;
            timer.Elapsed += Time_Elapsed;
        }
        public void End() => timer.Stop();
        public void Time_Elapsed(object? sender, ElapsedEventArgs e) => ShowNotifications(Title, Message);
        public static void ShowNotifications(string message, string title) => new ToastContentBuilder().AddText(message).AddText(title).Show();

    }
}
