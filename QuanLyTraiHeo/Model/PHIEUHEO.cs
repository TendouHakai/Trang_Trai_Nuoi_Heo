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
    using QuanLyTraiHeo.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUHEO: BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUHEO()
        {
            this.CT_PHIEUHEO = new HashSet<CT_PHIEUHEO>();
        }
    
        public string SoPhieu { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaDoiTac { get; set; }
        private string _TrangThai;
        public string TrangThai { get=>_TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }
        public string LoaiPhieu { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUHEO> CT_PHIEUHEO { get; set; }
        public virtual DOITAC DOITAC { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
