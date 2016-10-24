﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myWebAPIService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DBSampleEntities2 : DbContext
    {
        public DBSampleEntities2()
            : base("name=DBSampleEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblSample> tblSamples { get; set; }
    
        public virtual int sp_InsertTempData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertTempData");
        }
    
        public virtual ObjectResult<byte[]> GetPictureByID()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("GetPictureByID");
        }
    
        public virtual ObjectResult<byte[]> GetPictureByID1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("GetPictureByID1", idParameter);
        }
    
        public virtual ObjectResult<sp_SelectAll_Result3> sp_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectAll_Result3>("sp_SelectAll");
        }
    }
}
