using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTTDN_Code   
{
    class QLTKBus
    {
        Database DB = new Database();
        public List<NguoiDung> dsnd = new List<NguoiDung>();
        
        public bool isTKHople(string tk)
        {
            dsnd = (List<NguoiDung>)DB.Laytatcathongtin("NguoiDungs");
            if (dsnd[dsnd.Count-1]!=null)
            {
                foreach (var i in dsnd)
                    if (i.TaiKhoan.Equals(tk)) return false;
            }
            return true;
        }
        public int themNguoiDung(NguoiDung n)
        {
            n.MatKhau = new BaoMat().MaHoa(n.MatKhau);
            if (DB.Them(n) > 0) return 1;
            else return 0;
        }
        public bool suaNguoiDung(NguoiDung n)
        {
            if (DB.Sua(n) == 1) return true;
            return false;
        }
        public bool Lock(NguoiDung n, object thoihan, string lido)
        {
            var lskhoa = new LSKhoa();
            n.TrangThai = false;
            lskhoa.IdDTKhoa = n.IdND;
            lskhoa.ThoiGianKhoa = DateTime.Now;
            lskhoa.SoNgayKhoa = Convert.ToInt32(thoihan);
            lskhoa.LiDoKhoa = lido;
            lskhoa.DoiTuong = false;
            if (DB.Sua(n) == 0 || DB.Them(lskhoa) == 0) return false;
            return true;
        }
        public LSKhoa timlskhoand(int idnd)
        {
            var lskhoa = (List<LSKhoa>)DB.Laytatcathongtin("LSKhoas", "DoiTuong", "=", false);
            for (int i = lskhoa.Count - 1; i >= 0; i--)
                if (lskhoa[i].IdDTKhoa == idnd) { return lskhoa[i]; }
            return null;

        }
        public void MoKhoaTK()
        {
            var dsnd = (List<NguoiDung>)DB.Laytatcathongtin("NguoiDungs", "TrangThai", "=", false);
            if (dsnd[dsnd.Count - 1] != null)
                foreach (var i in dsnd)
                {
                    var lskhoa = timlskhoand(i.IdND);
                    if (lskhoa.SoNgayKhoa > 0)
                    {
                        double ngaymokhoa = lskhoa.ThoiGianKhoa.Date.ToOADate() + Convert.ToDouble(lskhoa.SoNgayKhoa);
                        if (ngaymokhoa <= DateTime.Now.Date.ToOADate())
                        {
                            i.TrangThai = true;
                            DB.Sua(i);
                        }
                    }

                }
        }
    }
}
