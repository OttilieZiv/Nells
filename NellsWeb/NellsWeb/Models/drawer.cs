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
    using System.ComponentModel.DataAnnotations;
    
    public partial class drawer
    {
        public drawer()
        {
            this.bottles = new HashSet<bottle>();
        }

        public int ID { get; set; }

        [Display(Name = "Drawer name")]
        public string DrawerName { get; set; }
    
        public virtual ICollection<bottle> bottles { get; set; }
    }
}
