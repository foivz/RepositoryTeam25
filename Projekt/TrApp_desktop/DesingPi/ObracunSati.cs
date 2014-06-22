using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    /// <summary>
    /// Klasa koja nasljeđuje klasu zaposlenici, te joj dodaje svojstva ID putnog radnog lista, suma sati i izračunata satnica
    /// </summary>
    class ObracunSati: zaposlenici
    {
        public Nullable<int> putni_radni_list { get; set; }
        public Nullable<int> suma_sati { get; set; }
        public Nullable<float> izracunataSatnica { get; set; }
    }
}
