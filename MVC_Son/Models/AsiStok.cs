//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Son.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class AsiStok
    {
        public int AsiStokId { get; set; }
        [DisplayName("Asi Adi:")]
        public int AsiId { get; set; }
        public Nullable<int> Stok { get; set; }
    
        public virtual Asi Asi { get; set; }
    }
}
