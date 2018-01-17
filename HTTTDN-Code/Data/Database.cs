using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTTDN_Code
{
    class Database
    {
        QLMaEntities db = new QLMaEntities();
        public void LichsuDN(int idND)
        {
            db = new QLMaEntities();
            var ls = new LogDangNhap();
            ls.IdND = idND;
            ls.ThoiGianDN = DateTime.Now;
            db.LogDangNhaps.Add(ls);
            db.SaveChanges();
        }
        public void LichsuDX(int idND)
        {
            db = new QLMaEntities();
            var ls = new LogDangXuat();
            ls.IdND = idND;
            ls.ThoiGianDX = DateTime.Now;
            db.LogDangXuats.Add(ls);
            db.SaveChanges();
        }
        public object Login(string tk, string mk)
        {
            db=new QLMaEntities();
            var a = (from c in db.NguoiDungs
                     where c.TaiKhoan == tk && c.MatKhau == mk
                     select c).FirstOrDefault();          
            return a;
        }
        public object Laytatcathongtin(string bang)
        {

            db = new QLMaEntities();
            if (bang == "NguoiDungs") return (from c in db.NguoiDungs select c).DefaultIfEmpty().ToList();
            else if (bang == "Mas") return (from c in db.Mas select c).DefaultIfEmpty().ToList();
            else if (bang == "LogDangNhaps") return (from c in db.LogDangNhaps select c).DefaultIfEmpty().ToList();
            else if (bang == "LogDangXuats") return (from c in db.LogDangXuats select c).DefaultIfEmpty().ToList();
            else return (from c in db.LSKhoas select c).DefaultIfEmpty().ToList();

        }
        public object Laytatcathongtin(string bang, string cotdieukien, string dieukientimkiem, object giatri)
        {
            db = new QLMaEntities();
            string s = "select * from " + bang + " where " + cotdieukien + " " + dieukientimkiem + " '" + giatri + "'";
            if (bang == "NguoiDungs") return db.NguoiDungs.SqlQuery(s).DefaultIfEmpty().ToList();
            else if (bang == "Mas") return db.Mas.SqlQuery(s).DefaultIfEmpty().ToList();
            else if (bang == "LogDangNhaps") return db.LogDangNhaps.SqlQuery(s).DefaultIfEmpty().ToList();
            else if (bang == "LogDangXuats") return db.LogDangXuats.SqlQuery(s).DefaultIfEmpty().ToList();
            else return db.LSKhoas.SqlQuery(s).DefaultIfEmpty().ToList();

        }
        public object getinfo(string bang, int id)
        {
            db = new QLMaEntities();
            if (bang == "NguoiDungs")
            {
                NguoiDung n = db.NguoiDungs.Where(c => c.IdND == id).FirstOrDefault();
                return n;
            }      
            LSKhoa ls = db.LSKhoas.Where(c => c.IdDTKhoa == id && c.DoiTuong==false).FirstOrDefault();
            return ls;
        }
        public int Them(object a)
        {
            try
            {
                if (a.GetType().ToString().IndexOf("NguoiDung") > 1) db.NguoiDungs.Add((NguoiDung)a);
                else
                if (a.GetType().ToString().IndexOf("Ma") > 1) db.Mas.Add((Ma)a);
                else
                if (a.GetType().ToString().IndexOf("LogDangNhap") > 1) db.LogDangNhaps.Add((LogDangNhap)a);
                else
                if (a.GetType().ToString().IndexOf ("LogDangXuas") > 1) db.LogDangXuats.Add((LogDangXuat)a);
                else
                    if (a.GetType().ToString().IndexOf("LSKhoa") > 1) db.LSKhoas.Add((LSKhoa)a);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Sua(object a)
        {   DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                if (a.GetType().ToString().IndexOf("NguoiDung") > 1)
                {
                    NguoiDung temp = (NguoiDung)a;
                    temp = db.NguoiDungs.Where(s =>s.IdND==temp.IdND).FirstOrDefault();
                    db.Entry(temp).CurrentValues.SetValues(a);
                }
                else
                {
                    Ma temp = (Ma)a;
                    temp = db.Mas.Where(s => s.IdMa == temp.IdMa).First();                         
                    db.Entry(temp).CurrentValues.SetValues(a);
                }
                db.SaveChanges();
                transaction.Commit();
                return 1;
            }
            catch
            {
                transaction.Rollback();
                return 0;
            }

        }
        public List<Ma> Thongke(DateTime frm, DateTime to)
        {
            to = to.AddDays(1);
            db = new QLMaEntities();
            List<Ma> dsma = (from n in db.Mas
                             where (n.ThoiGianKhoiTao >= frm.Date && n.ThoiGianKhoiTao <= to.Date)
                             select n).ToList();
            return dsma;
        }
    }
}
