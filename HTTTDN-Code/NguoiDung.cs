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
    
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            this.LogDangNhaps = new HashSet<LogDangNhap>();
            this.LogDangXuats = new HashSet<LogDangXuat>();
            this.Mas = new HashSet<Ma>();
        }
    
        public int IdND { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenNhanVien { get; set; }
        public bool ChucVu { get; set; }
        public bool TrangThai { get; set; }
        public string ChuThich { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogDangNhap> LogDangNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogDangXuat> LogDangXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ma> Mas { get; set; }
    }
}
