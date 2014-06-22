using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    /// <summary>
    /// Klasa koja nasljeđuje klasu vozilo i dodaje joj svojstva Trenutno stanje kilometraže, Stanje na zadnjem servisu, Razlika u kilometraži, Datum servisa i ID servisa
    /// </summary>
    class VozilaServis : vozilo
    {
        public Nullable<int> trenutno_stanje_km { get; set; } //trenutno stanje kilometraže
        public Nullable<int> stanje_na_zadnjem_servisu { get; set; } //stanje kilometraže na zadnjem servisu

        public Nullable<int> razlika_km { get; set; }
        public Nullable<System.DateTime> datum_servisa { get; set; }
        public Nullable<int> id_servisa { get; set; }
    }
}
