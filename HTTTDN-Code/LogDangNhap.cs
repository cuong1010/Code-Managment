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
    
    public partial class LogDangNhap
    {
        public int Id { get; set; }
        public System.DateTime ThoiGianDN { get; set; }
        public int IdND { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
