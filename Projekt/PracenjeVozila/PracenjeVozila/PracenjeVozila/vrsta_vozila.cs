//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracenjeVozila
{
    using System;
    using System.Collections.Generic;
    
    public partial class vrsta_vozila
    {
        public vrsta_vozila()
        {
            this.vozilo = new HashSet<vozilo>();
        }
    
        public int id_vrsta_vozila { get; set; }
        public string naziv { get; set; }
    
        public virtual ICollection<vozilo> vozilo { get; set; }
    }
}
