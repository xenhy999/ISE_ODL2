using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ISE_ODL.Converter
{
    internal class EsecuzioneOdl : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value && ObjContainer.MenuPrincipale_VM.OdlInEsecuzione) return true;
            return false;
            //if ((bool)value)
            //{
            //    if (ObjContainer.MenuPrincipale_VM.OdlInEsecuzione) return true;
            //    else return false;
            //}
            //else
            //{
            //    if (ObjContainer.MenuPrincipale_VM.OdlInEsecuzione) return false;
            //    else return true;
            //}

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
