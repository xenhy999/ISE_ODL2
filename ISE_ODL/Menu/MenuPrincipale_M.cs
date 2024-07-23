using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ISE_ODL.Odl;

namespace ISE_ODL.Menu
{
    public class MenuPrincipale_M : BaseBinding
    {
        [XmlElement("Odl_M")]
        public ObservableCollection<Odl_M> Commisioni_M{ 
            get; 
            set;
        } = new ObservableCollection<Odl_M>();

    }
}
