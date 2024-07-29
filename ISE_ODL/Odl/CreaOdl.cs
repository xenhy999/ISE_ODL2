using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    internal class CreaOdl : BaseCommand
    {
        public override void Execute(object parameter)
        {
            Odl_V old_V = new() { DataContext = Odl_F.Create() };
            old_V.ShowDialog();
        }
    }
}
