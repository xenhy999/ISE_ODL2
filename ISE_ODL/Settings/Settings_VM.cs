using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Settings
{
    internal class Settings_VM:BaseBinding
    {
        private bool timerAbilitato;
        private TimeSpan intervallo;

        public bool TimerAbilitato
        {
            get => ObjContainer.OdlTimer.TimerAbilitato;
            set => ObjContainer.OdlTimer.TimerAbilitato = value;
        }
        public TimeSpan Intervallo
        {
            get => ObjContainer.OdlTimer.DurataTimer;
            set => ObjContainer.OdlTimer.DurataTimer = value;
        }
    }
}
