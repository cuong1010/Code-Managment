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
    
    public partial class LogDangXuat
    {
        public int Id { get; set; }
        public System.DateTime ThoiGianDX { get; set; }
        public int IdND { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
