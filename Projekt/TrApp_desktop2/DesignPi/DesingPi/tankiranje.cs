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
    
    public partial class tankiranje
    {
        public int id_tankiranja { get; set; }
        public Nullable<int> vrsta_goriva { get; set; }
        public Nullable<int> zaposlenik { get; set; }
        public Nullable<int> PutniRadniList { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
        public Nullable<double> kolicina { get; set; }
    
        public virtual PutniRadniList PutniRadniList1 { get; set; }
        public virtual vrsta_goriva vrsta_goriva1 { get; set; }
        public virtual zaposlenici zaposlenici { get; set; }
    }
}
