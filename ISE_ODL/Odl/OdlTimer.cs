using System.Timers;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    public class OdlTimer
    {
        private Timer Timer = null;
        public void ResetTimer()
        {
            Timer?.Stop();
            Timer = new Timer(ObjContainer.Menuprincipale_VM.Settings_VM.DurataDelTimer) { AutoReset = true };
            Timer.Start();
            Timer.Elapsed += Time_Elapsed;
        }
        public void Stop() => Timer.Stop();
        private void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (ObjContainer.Menuprincipale_VM.Settings_VM.TimerAbilitato) ShowNotifications("Attenzione", "...");
        }
        public static void ShowNotifications(string message, string title) => new ToastContentBuilder().AddText(message).AddText(title).Show();
    }
}
