//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group11_007_iCAREAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientRecord
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string bloodGroup { get; set; }
        public string bedID { get; set; }
        public string treatmentArea { get; set; }
        public string geoID { get; set; }
        public string userID { get; set; }
    
        public virtual GeoCodes GeoCodes { get; set; }
        public virtual iCare_Worker iCare_Worker { get; set; }
    }
}
