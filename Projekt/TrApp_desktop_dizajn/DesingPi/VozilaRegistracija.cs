using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class VozilaRegistracija : vozilo
    {
        public DateTime posljednja_registracija { get; set; }
        public DateTime sljedeca_registracija { get; set; }
        public string napomena { get; set; }
        public Nullable<int> id_tehnickog_pregleda { get; set; }
    }
}
