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
    
    public partial class bottletagtype
    {
        public bottletagtype()
        {
            this.bottletags = new HashSet<bottletag>();
        }
    
        public int ID { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<bottletag> bottletags { get; set; }
    }
}
