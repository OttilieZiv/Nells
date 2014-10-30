﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NellsEntities : DbContext
    {
        public NellsEntities()
            : base("name=NellsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bottle> bottles { get; set; }
        public virtual DbSet<bottletaglookup> bottletaglookups { get; set; }
        public virtual DbSet<bottletag> bottletags { get; set; }
        public virtual DbSet<bottletagtype> bottletagtypes { get; set; }
        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<drawer> drawers { get; set; }
        public virtual DbSet<lemming> lemmings { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<ordered> ordereds { get; set; }
    
        public virtual ObjectResult<RPT_BrandCount_Result> RPT_BrandCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_BrandCount_Result>("RPT_BrandCount");
        }
    
        public virtual ObjectResult<RPT_BrandCountSubset_Result> RPT_BrandCountSubset(string startletter, string endletter)
        {
            var startletterParameter = startletter != null ?
                new ObjectParameter("startletter", startletter) :
                new ObjectParameter("startletter", typeof(string));
    
            var endletterParameter = endletter != null ?
                new ObjectParameter("endletter", endletter) :
                new ObjectParameter("endletter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_BrandCountSubset_Result>("RPT_BrandCountSubset", startletterParameter, endletterParameter);
        }
    
        public virtual ObjectResult<RPT_BrandTypeCount_Result> RPT_BrandTypeCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_BrandTypeCount_Result>("RPT_BrandTypeCount");
        }
    
        public virtual ObjectResult<RPT_CountryCount_Result> RPT_CountryCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_CountryCount_Result>("RPT_CountryCount");
        }
    
        public virtual ObjectResult<RPT_DrawerCount_Result> RPT_DrawerCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_DrawerCount_Result>("RPT_DrawerCount");
        }
    
        public virtual int RPT_FullyUsedBrandList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RPT_FullyUsedBrandList");
        }
    
        public virtual ObjectResult<Nullable<int>> RPT_FullyUsedBrands()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RPT_FullyUsedBrands");
        }
    
        public virtual ObjectResult<RPT_TaglessBottles_Result> RPT_TaglessBottles(Nullable<int> p_tagtype)
        {
            var p_tagtypeParameter = p_tagtype.HasValue ?
                new ObjectParameter("p_tagtype", p_tagtype) :
                new ObjectParameter("p_tagtype", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RPT_TaglessBottles_Result>("RPT_TaglessBottles", p_tagtypeParameter);
        }
    
        public virtual int RPT_UnusedBrandList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RPT_UnusedBrandList");
        }
    
        public virtual ObjectResult<Nullable<int>> RPT_UnusedBrands()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RPT_UnusedBrands");
        }
    }
}
