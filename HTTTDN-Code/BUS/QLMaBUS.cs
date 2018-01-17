using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTTDN_Code
{
    class QLMaBUS
    {
        /// <summary>
        /// mã khi sinh ra sẽ có trạng thái la 0 khi dc nd sd sẽ là 1 hết hạn la 2,khóa sẽ la 3
        /// khi ma dc nv lay xuong se dc gan id nv lấy
        /// nếu mã đã dc lấy xuống va dc khách hàng nhập vào cai ô nhập mã se dc chuyen thanh đã sd
        /// mã khi khóa (3) khi toi ngay het han se dc gan la 2 va k dc thay doi tt
        /// mã ở trạng thái đã sử dụng(1) va 2 se k thể khóa(3)
        /// </summary>
        
        Random r = new Random();
        Database db = new Database();
        public bool GioiHanSinhMa(int sl, int skt,int slgrid)
        {
            db = new Database();
            double gioihan = (Math.Pow(26, skt));
            List<Ma> dsma = (List<Ma>)db.Laytatcathongtin("Mas", "SoKiTu", "=", skt);
            int slmaduoidb;
            if (dsma[dsma.Count - 1] == null) slmaduoidb = 0;
            else slmaduoidb = dsma.Count;
            if (gioihan - sl - slmaduoidb-slgrid >= 0) return true;
            return false;
        }
        private bool isTrungma(List<Ma> dsma,string s) // trùng la return true k trung la false
        {
            //kiem tra trùng tren grid
            if (dsma.Count>0)
                foreach (var i in dsma)
                    if (i.NoiDung.Equals(s)) return true;

            //kiem tra trung tren db
            s = new BaoMat().MaHoa(s);
            var chuoikq =(List<Ma>)db.Laytatcathongtin("Mas", "NoiDung", "=", s);
            var kq = chuoikq[chuoikq.Count - 1];
            if (kq == null) return false;
            return true;
        }

        public List<Ma> SinhMa(List<Ma> dsma,int sl, int sokitu,DateTime ngayhethan)
        {
           
            for (int i = 0; i < sl; i++)
            {
               
                string s ="";
                for (int j = 0; j < sokitu; j++)
                {
                    char kitu = (char)r.Next(65,91);                    
                    s += kitu;                    
                }
                if (isTrungma(dsma,s)) {  i--; }
                //mã sinh ra hop lệ k bi trùng
                else
                {
                    Ma ma = new Ma();
                    ma.NoiDung = s;                   
                    ma.ThoiGianHetHan = ngayhethan;
                    ma.SoKiTu = sokitu;
                    dsma.Add(ma);
                }
            }
            return dsma;
        }

        public bool LuuMa(List<Ma> dsma,int idngtao)
        {
            try
            {
                foreach (var i in dsma)
                {
                    i.NoiDung = new BaoMat().MaHoa(i.NoiDung);
                    i.IDNguoiTao = idngtao;
                    i.ThoiGianKhoiTao = DateTime.Now;
                    i.TrangThai = 0;
                    if(db.Them(i)==0)return false;
                   
                }
                return true;
            }
            catch { return false; }
        }

        public void CapNhatMaHetHan()
        {
            var dsma=(List<Ma>)db.Laytatcathongtin("Mas");
            if(dsma[dsma.Count-1]!=null)
            foreach (var i in dsma)
                if (i.ThoiGianHetHan.Date <= DateTime.Now.Date)
                    {
                        
                        i.TrangThai = 2; db.Sua(i);
                        
                    }
        }

        public List<Ma> XemMa(int idngtao)
        {
            List<Ma> dsmadatao = (List<Ma>)db.Laytatcathongtin("Mas", "IDNguoiTao", "=",idngtao);           
            if (dsmadatao[dsmadatao.Count - 1] != null)
            foreach (var i in dsmadatao)
                i.NoiDung = new BaoMat().GiaiMa(i.NoiDung);
            return dsmadatao;
        }

        public List<Ma> LocMa(List<Ma> dsmadeloc,int dkloc,object giatriloc)
        {
            var temp = new List<Ma>();
            foreach (var i in dsmadeloc)
                if (dkloc == 0 && i.IDNguoiLay == Convert.ToInt32(giatriloc))
                   temp.Add(i);
                else if(dkloc==1 && i.ThoiGianKhoiTao.Date ==Convert.ToDateTime(giatriloc).Date)
                    temp.Add(i);
                else if (dkloc == 2 && i.ThoiGianHetHan.Date == Convert.ToDateTime(giatriloc).Date)
                    temp.Add(i);
            return temp;
        }

        public List<Ma> LocMa(List<Ma> dsmadeloc,bool ChuaSD, bool DaSD,bool DaLay,bool Hethan,bool Khoa,bool ChuaLay)
        {
            List<Ma> kq = new List<Ma>();
            foreach (var i in dsmadeloc)
            {
                if (ChuaSD && i.TrangThai == 0) kq.Add(i);
                if (DaSD && i.TrangThai == 1) kq.Add(i);               
                if (Hethan && i.TrangThai == 2) kq.Add(i);
                if (Khoa && i.TrangThai == 3) kq.Add(i);               
            }
            if (DaLay && ChuaLay)
            {
                if (kq.Count == 0) kq = dsmadeloc;// không chọn trang thái nào mà chỉ click vao dalay va chualay
                else // co chọn it nhat 1 trang thai va co tichvao dalay va chua lay
                    return kq;

            }
            else if (DaLay)
            {
                if (kq.Count == 0) kq = dsmadeloc;
                for (int i = 0; i < kq.Count; i++)
                    if (kq[i].IDNguoiLay == null) { kq.RemoveAt(i); i--; }
            }
            else if (ChuaLay)
            {
                if (kq.Count == 0) kq = dsmadeloc;
                for (int i = 0; i < kq.Count; i++)
                    if (kq[i].IDNguoiLay != null) { kq.RemoveAt(i); i--; }
            }

            return kq;
        }

        public bool isMaCoTheKhoa(Ma ma)
        {
            if (ma.TrangThai != 2 && ma.TrangThai != 1 && ma.TrangThai !=3) {return true; }
            else return false;
        }

        public bool KhoaMa(List<Ma> dskhoa,object thoihankhoa,string lido )
        {
            foreach (var i in dskhoa)
            {              
                i.TrangThai = 3;
                i.NoiDung= new BaoMat().MaHoa(i.NoiDung);
                var lskhoa = new LSKhoa();
                lskhoa.IdDTKhoa = i.IdMa; 
                lskhoa.ThoiGianKhoa = DateTime.Now;
                lskhoa.SoNgayKhoa = Convert.ToInt32(thoihankhoa);          
                lskhoa.LiDoKhoa = lido;
                lskhoa.DoiTuong = true;              
                if (db.Sua(i)==0 || db.Them(lskhoa)==0) return false;
            }
            return true;
        }
        public LSKhoa timlskhoama(int idma)
        {         
                var lskhoa = (List<LSKhoa>)db.Laytatcathongtin("LSKhoas", "DoiTuong", "=", true);
                for (int i = lskhoa.Count - 1; i >= 0; i--)
                    if (lskhoa[i].IdDTKhoa == idma) { return lskhoa[i]; }
                return null;              
           
        }

        public void MoKhoaMa()
        {
            var dsma = (List<Ma>)db.Laytatcathongtin("Mas", "TrangThai", "=",3);
            if (dsma[dsma.Count - 1] != null)
                foreach (var i in dsma)
                {                    
                    var lskhoa = timlskhoama(i.IdMa);
                    if (lskhoa.SoNgayKhoa>0)
                    {
                        double ngaymokhoa=lskhoa.ThoiGianKhoa.Date.ToOADate() +Convert.ToDouble(lskhoa.SoNgayKhoa);
                        if (ngaymokhoa <= DateTime.Now.Date.ToOADate())
                        {                          
                            i.TrangThai = 0;
                            db.Sua(i);
                        }
                    }
                    
                }
        }

        public List<Ma> LayMa(int sl,int slkitu, int idnglay)
        {
            var dsmalay = (List<Ma>)db.Laytatcathongtin("Mas", "SoKiTu", "=", slkitu);
            List<Ma> dsmacothelay = new List<Ma>();
            if (dsmalay[dsmalay.Count - 1] == null) return null;         
            else
            {
                var temp = sl;
                foreach (var i in dsmalay)
                {
                    if (temp == 0) break;
                    if (i.TrangThai == 0 && i.IDNguoiLay == null)
                    {
                        temp--;
                        dsmacothelay.Add(i);
                    }
                }
            }
            if (dsmacothelay.Count < sl) return dsmacothelay; //khi so lg ma co the cung cap < solg can lay
            //khi sl lay co the cug cap
            else
            {
                foreach (var i in dsmacothelay)
                {
                    i.IDNguoiLay = idnglay;
                    i.ThoiGianLay = DateTime.Now;
                    db.Sua(i);
                }
                return dsmacothelay;
            }
        }

        public int Nhapma(string s)
        {
            var a = (List<Ma>)db.Laytatcathongtin("Mas", "NoiDung", "=", new BaoMat().MaHoa(s));
            var ma = a[a.Count - 1];
            if (ma == null) return -1;
            if (ma.TrangThai == 3 && ma.IDNguoiLay != null) return 3;
            else if (ma.TrangThai == 2 && ma.IDNguoiLay != null) return 2;
            else if (ma.TrangThai == 1 && ma.IDNguoiLay != null) return 1;
            else if (ma.TrangThai == 0 && ma.IDNguoiLay != null)
            {
                ma.TrangThai = 1;
                db.Sua(ma);
                return 0;
            }
            else return -1;
        }
    }
}
