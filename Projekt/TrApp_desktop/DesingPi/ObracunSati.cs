using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class ObracunSati: zaposlenici
    {
        public Nullable<int> putni_radni_list { get; set; }
        public Nullable<int> suma_sati { get; set; }
        public Nullable<float> izracunataSatnica { get; set; }
    }
}
