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
    
    public partial class iCare_Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iCare_Worker()
        {
            this.DocumentMetadata = new HashSet<DocumentMetadata>();
            this.ModificationHistory = new HashSet<ModificationHistory>();
            this.PatientRecord = new HashSet<PatientRecord>();
            this.TreatmentRecord = new HashSet<TreatmentRecord>();
        }
    
        public string profession { get; set; }
        public string ID { get; set; }
        public string userroleID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentMetadata> DocumentMetadata { get; set; }
        public virtual iCareUser iCareUser { get; set; }
        public virtual UserRole UserRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModificationHistory> ModificationHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientRecord> PatientRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentRecord> TreatmentRecord { get; set; }
    }
}
