using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Settings
{
    internal class Settings_VM : BaseBinding
    {
        public bool TimerAbilitato{ get => Properties.Settings.Default.TimerAttivo;set => Properties.Settings.Default["TimerAttivo"] = value; }
        public TimeSpan DurataDelTimer
        {
            get => Properties.Settings.Default.DurataDelTimer;
            set
            {
                Properties.Settings.Default["DurataDelTimer"] = value;
                ObjContainer.OdlTimer?.ResetTimer();
            }
        }
    }
}
