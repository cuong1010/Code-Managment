//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTTTDN_Code
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ma
    {
        public int IdMa { get; set; }
        public string NoiDung { get; set; }
        public int TrangThai { get; set; }
        public System.DateTime ThoiGianKhoiTao { get; set; }
        public System.DateTime ThoiGianHetHan { get; set; }
        public Nullable<System.DateTime> ThoiGianLay { get; set; }
        public Nullable<int> IDNguoiLay { get; set; }
        public int IDNguoiTao { get; set; }
        public int SoKiTu { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
