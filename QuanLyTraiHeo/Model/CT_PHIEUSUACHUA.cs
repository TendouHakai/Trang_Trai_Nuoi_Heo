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
    
    public partial class CT_PHIEUSUACHUA
    {
        public string SoPhieu { get; set; }
        public string MaChuong { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual CHUONGTRAI CHUONGTRAI { get; set; }
        public virtual PHIEUSUACHUA PHIEUSUACHUA { get; set; }
    }
}
