//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesingPi
{
    using System;
    using System.Collections.Generic;
    
    public partial class dnevnik
    {
        public int id_zapisa { get; set; }
        public byte[] datum { get; set; }
        public int vozilo_id_vozilo { get; set; }
        public int status_id_statusa { get; set; }
    
        public virtual status status { get; set; }
        public virtual vozilo vozilo { get; set; }
    }
}