using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe gestisce un timer per monitorare il tempo trascorso su un'attività.
    /// Fornisce metodi per avviare, resettare e fermare il timer, nonché per mostrare notifiche quando il tempo trascorso supera una certa soglia.
    /// </summary>
    public class OdlTimer
    {
        private const string Message = "Attenzione";
        private const string Title = "Hai trascorso molto tempo su questa attività";
        /// <summary>
        /// L'istanza del timer utilizzato per monitorare il tempo trascorso.
        /// </summary>
        private Timer Timer = null;
        /// <summary>
        /// Resetta il timer, avviandolo con la durata specificata nelle impostazioni.
        /// </summary>
        public void ResetTimer()
        {
            Timer?.Stop();
            Timer = new Timer(ObjContainer.Menuprincipale_VM.Settings_VM.DurataDelTimer) { AutoReset = true };
            Timer.Start();
            Timer.Elapsed += Time_Elapsed;
        }
        /// <summary>
        /// Ferma il timer corrente.
        /// </summary>
        public void Stop() => Timer.Stop();
        /// <summary>
        /// Evento chiamato quando il timer scade.
        /// Mostra una notifica se il timer è abilitato nelle impostazioni.
        /// </summary>
        private void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (ObjContainer.Menuprincipale_VM.Settings_VM.TimerAbilitato) ShowNotifications(Message, Title);
        }
        /// <summary>
        /// Mostra una notifica con il messaggio e il titolo specificati.
        /// </summary>
        /// <param name="message">Il messaggio della notifica.</param>
        /// <param name="title">Il titolo della notifica.</param>
        public static void ShowNotifications(string message, string title) => new ToastContentBuilder().AddText(message).AddText(title).Show();
    }
}
