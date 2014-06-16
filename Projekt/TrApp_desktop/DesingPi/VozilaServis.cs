using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class VozilaServis: vozilo
    {
        public int trenutno_stanje_km { get; set; }
        public int stanje_na_zadnjem_servisu { get; set; }

        public int razlika_km { get; set; }
        public Nullable<System.DateTime> datum_servisa { get; set; }
    }
}
