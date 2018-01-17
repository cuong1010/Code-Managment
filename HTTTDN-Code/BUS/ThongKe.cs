using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTTDN_Code
{
    class ThongKe
    {
        Database db = new Database();
        private List<int> dssokitu(ref List<Ma> dsma)
        {
            int n = dsma.Count;
            for (int i = 0; i < n; i++)
                for (int j = i+1; j < n; j++)
                    if (dsma[i].SoKiTu > dsma[j].SoKiTu)
                    {
                        var temp = dsma[i];
                        dsma[i] = dsma[j];
                        dsma[j] = temp;
                        j--;
                    }           
            List<int> dskitu = new List<int>();
            for (int i = 0; i < n - 1; i++)
                if (dsma[i].SoKiTu != dsma[i + 1].SoKiTu) dskitu.Add(dsma[i].SoKiTu);
            if (dsma[n - 1].SoKiTu != dskitu[dskitu.Count - 1]) dskitu.Add(dsma[n - 1].SoKiTu);
            return dskitu;
        }
        public int[] ThongkeTongQuat(DateTime frm,DateTime to)
        {            
            var dsma = db.Thongke(frm, to);            
            var KQTK = new int[6];
            if (dsma .Count==0) return null;
            foreach (var j in dsma)
            {
                if (j.IDNguoiLay != null && j.TrangThai == 0) KQTK[0]++; // đã lấy và chua su dung
                else if (j.IDNguoiLay != null && j.TrangThai == 1) KQTK[1]++; // da su dung
                else if (j.TrangThai == 2) KQTK[2]++; // het han
                else if (j.TrangThai == 3) KQTK[3]++; // dang khoa chua het han
                else if (j.IDNguoiLay == null) KQTK[4]++; // chua lay
            }
            KQTK[5] = dsma.Count;           
           return KQTK;
        }
        public int[,] ThongkeChiTiet(DateTime frm, DateTime to)
        {
            var dsma = db.Thongke(frm, to);
            if (dsma.Count == 0) return null;
            var dskituma = dssokitu(ref dsma);           
            int [,]KQTK = new int[dskituma.Count,6];int vt = 0;
            for (int i = 0; i < dsma.Count; i++)
            {
                if (i>0 && dsma[i].SoKiTu != dsma[i-1].SoKiTu)
                {
                    vt++;
                }
                if (dsma[i].IDNguoiLay != null && dsma[i].TrangThai == 0) KQTK[vt,0]++; // đã lấy và chua su dung
                else if (dsma[i].IDNguoiLay != null && dsma[i].TrangThai == 1) KQTK[vt,1]++; // da su dung
                else if (dsma[i].TrangThai == 2) KQTK[vt,2]++; // het han
                else if (dsma[i].TrangThai == 3) KQTK[vt,3]++; // dang khoa chua het han
                else if (dsma[i].IDNguoiLay == null) KQTK[vt,4]++; // chua lay               
            }
            for (int i = 0; i < dskituma.Count; i++)
            {
                KQTK[i, 5] = dskituma[i];//5 la vi tri luu so ki tu cua ma
            }
            return KQTK;

        }
    }
}
