//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechProjectHub.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UploadCodeMaster
    {
        public int Upload_Id { get; set; }
        public string Upload_Title { get; set; }
        public string Code_Descrip { get; set; }
        public string Uploaded_By { get; set; }
        public string CodeFile_Name { get; set; }
        public Nullable<System.DateTime> Uploaded_DT { get; set; }
    
        public virtual DeveloperMaster DeveloperMaster { get; set; }
    }
}
