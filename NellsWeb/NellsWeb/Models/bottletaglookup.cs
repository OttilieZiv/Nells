//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NellsWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bottletaglookup
    {
        public int ID { get; set; }
        public int BottleID { get; set; }
        public int TagID { get; set; }
    
        public virtual bottle bottle { get; set; }
        public virtual bottletag bottletag { get; set; }
    }
}