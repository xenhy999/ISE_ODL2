using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Resoconto.Giorno
{
    public class Giorno_VM:BaseBinding
    {
        private DateOnly data;
        public Giorno_VM(DateOnly data) => Data = data;
        public DateOnly Data
        {
            get => data;
            set
            {
                data = value;
                if(data==DateOnly.FromDateTime(DateTime.Now)) DataOdierna=true;
                else DataOdierna=false;
                OnPropertyChanged(nameof(DataOdierna));
            }
        }
        public Dictionary<Odl_VM, TimeSpan> OdlLavorati { get; set; } = [];
        public bool DataOdierna { get; set; }
    }
}
