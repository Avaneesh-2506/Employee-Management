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
    
    public partial class RequestMaster
    {
        public int Request_Id { get; set; }
        public Nullable<int> Request_For { get; set; }
        public string Request_Msg { get; set; }
        public string Requested_By { get; set; }
        public Nullable<System.DateTime> Request_DT { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual DeveloperMaster DeveloperMaster { get; set; }
        public virtual ProjectMaster ProjectMaster { get; set; }
    }
}
