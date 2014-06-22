using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    /// <summary>
    /// Klasa koja nasljeđuje klasu zaposlenici, te dodaje svojstva ID godišnjeg odmora te početak i kraj
    /// </summary>
    class GodisnjiOdmor : zaposlenici
    {
        public int id_godisnjeg_odmora { get; set; } 
        public DateTime pocetak_godisnjeg { get; set; } 
        public DateTime kraj_godisnjeg{ get; set; }
    }
}
