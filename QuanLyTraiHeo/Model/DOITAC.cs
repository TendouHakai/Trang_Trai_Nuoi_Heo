//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTraiHeo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOITAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOITAC()
        {
            this.PHIEUHEOs = new HashSet<PHIEUHEO>();
            this.PHIEUHANGHOAs = new HashSet<PHIEUHANGHOA>();
            this.PHIEUSUACHUAs = new HashSet<PHIEUSUACHUA>();
        }
    
        public string MaDoiTac { get; set; }
        public string LoaiDoiTac { get; set; }
        public string TenDoiTac { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUHEO> PHIEUHEOs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUHANGHOA> PHIEUHANGHOAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUSUACHUA> PHIEUSUACHUAs { get; set; }
    }
}
