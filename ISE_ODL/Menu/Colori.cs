using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ISE_ODL.Menu
{
    public class Colori:BaseBinding
    {
        BrushConverter brushConverter = new BrushConverter();
        public Colori()
        {
            Palette.Add((SolidColorBrush)brushConverter.ConvertFrom("#1B262C"));
            Palette.Add((SolidColorBrush)brushConverter.ConvertFrom("#0F4C75"));
            Palette.Add((SolidColorBrush)brushConverter.ConvertFrom("#3282B8"));
            Palette.Add((SolidColorBrush)brushConverter.ConvertFrom("#BBE1FA"));
        }

        public List<SolidColorBrush> Palette { get; set; } = new List<SolidColorBrush>();

    }
}
