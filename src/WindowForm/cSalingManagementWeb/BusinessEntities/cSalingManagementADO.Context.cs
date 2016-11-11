﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class cSalingManagementEntities : DbContext
    {
        public cSalingManagementEntities()
            : base("name=cSalingManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<M_Account> M_Account { get; set; }
        public DbSet<M_Category> M_Category { get; set; }
        public DbSet<M_Customer> M_Customer { get; set; }
        public DbSet<M_Department> M_Department { get; set; }
        public DbSet<M_Employee> M_Employee { get; set; }
        public DbSet<M_Role> M_Role { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<M_ProductInfo> M_ProductInfo { get; set; }
        public DbSet<T_Import> T_Import { get; set; }
        public DbSet<M_Supplier> M_Supplier { get; set; }
    
        public virtual ObjectResult<Nullable<short>> InsertM_CategoryInfo(string cate_name, string description, string image, Nullable<int> status)
        {
            var cate_nameParameter = cate_name != null ?
                new ObjectParameter("cate_name", cate_name) :
                new ObjectParameter("cate_name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<short>>("InsertM_CategoryInfo", cate_nameParameter, descriptionParameter, imageParameter, statusParameter);
        }
    
        public virtual ObjectResult<M_Category> SelectAll_M_Category()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M_Category>("SelectAll_M_Category");
        }
    
        public virtual ObjectResult<M_Category> SelectAll_M_Category(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M_Category>("SelectAll_M_Category", mergeOption);
        }
    
        public virtual ObjectResult<SelectAll_M_ProductInfoWithImportInfo_Result> SelectAll_M_ProductInfoWithImportInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAll_M_ProductInfoWithImportInfo_Result>("SelectAll_M_ProductInfoWithImportInfo");
        }
    
        public virtual ObjectResult<SelectAll_M_ProductInfoWithImportInfo_Result> SelectAll_M_ProductInfoWithImportInfo_ByProductID(string productID)
        {
            var productIDParameter = productID != null ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAll_M_ProductInfoWithImportInfo_Result>("SelectAll_M_ProductInfoWithImportInfo_ByProductID", productIDParameter);
        }
    
        public virtual ObjectResult<Nullable<short>> InsertM_ProductInfo(string product_name, string category, Nullable<int> instock, string image, Nullable<double> price, string description, string preservation, string howtouse, string origin, Nullable<int> status)
        {
            var product_nameParameter = product_name != null ?
                new ObjectParameter("product_name", product_name) :
                new ObjectParameter("product_name", typeof(string));
    
            var categoryParameter = category != null ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(string));
     
            var instockParameter = instock.HasValue ?
                new ObjectParameter("instock", instock) :
                new ObjectParameter("instock", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(double));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var preservationParameter = preservation != null ?
                new ObjectParameter("preservation", preservation) :
                new ObjectParameter("preservation", typeof(string));
    
            var howtouseParameter = howtouse != null ?
                new ObjectParameter("howtouse", howtouse) :
                new ObjectParameter("howtouse", typeof(string));
    
            var originParameter = origin != null ?
                new ObjectParameter("origin", origin) :
                new ObjectParameter("origin", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<short>>("InsertM_ProductInfo", product_nameParameter, categoryParameter, instockParameter, imageParameter, priceParameter, descriptionParameter, preservationParameter, howtouseParameter, originParameter, statusParameter);
        }
    }
}
