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
    
    public partial class radni_sati
    {
        public int putni_radni_list { get; set; }
        public int zaposlenik { get; set; }
        public Nullable<int> br_sati { get; set; }
    
        public virtual PutniRadniList PutniRadniList { get; set; }
        public virtual zaposlenici zaposlenici { get; set; }
    }
}
