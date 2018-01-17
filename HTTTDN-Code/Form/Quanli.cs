using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HTTTDN_Code
{
    public partial class Quanli : Form
    {
        public Quanli()
        {
            InitializeComponent();
        }
        public Quanli(NguoiDung nd)
        {
            this.nd = nd;
            InitializeComponent();
            this.Text="Quản lí: "+ nd.TenNhanVien;
        }
        public NguoiDung nd;
        QLMaBUS busQLma = new QLMaBUS();
        QLTKBus busQLTK = new QLTKBus();
        //cap nhat ma da het han
        private void Quanli_Load(object sender, EventArgs e)
        {
            busQLma.MoKhoaMa();
            LoadDSND();
        }
        #region SinhMa 

        List<Ma> dsma=new List<Ma>();
        //Khi bấm nút sinh mã
        private void btnSinhMa_Click(object sender, EventArgs e)
        {
            try
            {
               
                int sl = Convert.ToInt32(txtSLMa.Text);
                int slkitu = Convert.ToInt32(txtSLKitu.Text);
                if (busQLma.GioiHanSinhMa(sl, slkitu,dsma.Count))
                {
                    DateTime ngayhethan = Convert.ToDateTime(dateHetHan.Text);
                    if (ngayhethan.Date <= DateTime.Now.Date) throw new Exception();
                    //gan mã moi vua duoc sinh ra vào lại ds mã trên form
                    dsma = busQLma.SinhMa(dsma, sl, slkitu, Convert.ToDateTime(dateHetHan.Text));
                    
                    GridSinhMa.Rows.Clear();
                    int stt = GridSinhMa.Rows.Count + 1;
                    foreach (var i in dsma)
                    {
                        DataGridViewRow row = new DataGridViewRow(); row.CreateCells(GridSinhMa);
                        row.Cells[0].Value = stt;
                        row.Cells[1].Value = i.NoiDung;
                        row.Cells[2].Value = i.ThoiGianHetHan;
                        row.Cells[3].Value = "Hủy";
                        GridSinhMa.Rows.Add(row);
                        stt++;
                    }
                }
                else MessageBox.Show("Số lượng mã sinh ra vượt quá giới hạn", "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ");
            }
        }
        //Khi bấm nút hủy trên grid
        private void GridSinhMa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = GridSinhMa.CurrentRow.Index;
            if (Convert.ToBoolean(GridSinhMa[3, row].Selected) == true)
            {
                dsma.RemoveAt(row);
                GridSinhMa.Rows.RemoveAt(row);
            }
            for (int i = row; i < GridSinhMa.Rows.Count; i++)
            {
                GridSinhMa[0, i].Value = i + 1;
            }
        }
        //Khi bấm nút lưu
        private void btnLuuMa_Click(object sender, EventArgs e)
        {

            if (dsma != null)
            {
                var kq = busQLma.LuuMa(dsma, nd.IdND);
                if (kq) { MessageBox.Show("Lưu thành công"); GridSinhMa.Rows.Clear(); dsma.Clear(); }
                else MessageBox.Show("Xảy ra lỗi không thể lưu");
            }
            else MessageBox.Show("Ko có mã để lưu");
        }
        #endregion

        #region KhoaMa
        List<Ma> dsqlma = new List<Ma>();
        private void cbDKLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDKLoc.SelectedIndex == 3)
            {
                CheckDSD.Visible = true; CheckCSD.Visible = true; CheckHH.Visible = true;
                checkKhoa.Visible = true;
                checkDaLay.Visible = true; checkChuaLay.Visible = true;
                txtLoc.Enabled = false;
            }
            else
            { CheckDSD.Visible = false; CheckCSD.Visible = false; CheckHH.Visible = false;
                checkKhoa.Visible = false;
                checkDaLay.Visible = false; checkChuaLay.Visible = false;
                txtLoc.Enabled = true;
            }
        }
        void Refesh()
        {
            busQLma.MoKhoaMa();
            busQLma.CapNhatMaHetHan();
            dsqlma = busQLma.XemMa(nd.IdND);
            GridQLMa.Rows.Clear();
            if (dsqlma[dsqlma.Count - 1] != null)
            {
                foreach (var i in dsqlma)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(GridQLMa);
                    row.Cells[1].Value = i.IdMa;
                    row.Cells[2].Value = i.NoiDung;
                    row.Cells[3].Value = i.IDNguoiLay;
                    if (i.TrangThai == 0) row.Cells[4].Value = "Chưa sử dụng";
                    if (i.TrangThai == 1) row.Cells[4].Value = "Đã sử dụng";
                    if (i.TrangThai == 2) row.Cells[4].Value = "Hết hạn";
                    if (i.TrangThai == 3) row.Cells[4].Value = "Đã khóa";
                    row.Cells[5].Value = i.ThoiGianKhoiTao;
                    row.Cells[6].Value = i.ThoiGianHetHan.Date;
                    GridQLMa.Rows.Add(row);
                }
            }
        }
        private void tabKhoaMa_Enter(object sender, EventArgs e)
        {
            Refesh();
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Refesh();
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            int select = cbDKLoc.SelectedIndex;
            if (select == 3 && !CheckCSD.Checked && !CheckDSD.Checked && !checkDaLay.Checked && !CheckHH.Checked && !checkChuaLay.Checked && !checkKhoa.Checked)
                MessageBox.Show("Chọn mục cần lọc");
            else
                try
                {

                    if (select != 3)
                    {
                        dsqlma = busQLma.LocMa(dsqlma, select, txtLoc.Text);
                    }
                    else
                    {
                        dsqlma = busQLma.LocMa(dsqlma, CheckCSD.Checked, CheckDSD.Checked, checkDaLay.Checked, CheckHH.Checked, checkKhoa.Checked, checkChuaLay.Checked);
                    }
                    GridQLMa.Rows.Clear();
                    if (dsqlma != null)
                    {
                        foreach (var i in dsqlma)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(GridQLMa);
                            row.Cells[1].Value = i.IdMa;
                            row.Cells[2].Value = i.NoiDung;
                            row.Cells[3].Value = i.IDNguoiLay;
                            if (i.TrangThai == 0) row.Cells[4].Value = "Chưa sử dụng";
                            if (i.TrangThai == 1) row.Cells[4].Value = "Đã sử dụng";
                            if (i.TrangThai == 2) row.Cells[4].Value = "Hết hạn";
                            if (i.TrangThai == 3) row.Cells[4].Value = "Đã Khóa";
                            row.Cells[5].Value = i.ThoiGianKhoiTao;
                            row.Cells[6].Value = i.ThoiGianHetHan.Date;
                            GridQLMa.Rows.Add(row);
                        }
                    }
                }
                catch { MessageBox.Show("Dữ liệu nhập không hợp lệ"); }

        }
        private void cbCheckAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = cbCheckAll.SelectedIndex;
            bool value;
            if (select == 0) value = true;
            else value = false;
            for (int i = 0; i < GridQLMa.RowCount; i++)
            {
                GridQLMa[0, i].Value = value;
            }
        }
        private void GridQLMa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = GridQLMa.CurrentRow.Index;LSKhoa lskhoa = new LSKhoa();
            if (dsqlma[i].TrangThai == 3)
            {
                lskhoa = busQLma.timlskhoama(dsqlma[i].IdMa);
                string tbao = "Mã bị khóa ";
                if (lskhoa.SoNgayKhoa == 0) tbao += "vĩnh viễn ";
                else tbao += lskhoa.SoNgayKhoa+ " ngày ";
                tbao += "vào ngày " + lskhoa.ThoiGianKhoa + " với lí do " + lskhoa.LiDoKhoa;
                lbLSK.Text = tbao;
            }
            else lbLSK.Text = "";
            
        }
        private void btnKhoaMa_Click(object sender, EventArgs e)
        {
            var dskhoa = new List<Ma>();
            for (int i = 0; i < GridQLMa.RowCount; i++)
            {
                if (Convert.ToBoolean(GridQLMa[0, i].Value) == true) dskhoa.Add(dsqlma[i]);
            }
            bool iskhoa = true;
            if (dskhoa.Count == 0)
            { MessageBox.Show("Hãy chọn mã để khóa"); iskhoa = false; }
            else
                foreach (var i in dskhoa)
                    if (!busQLma.isMaCoTheKhoa(i))
                    {
                        string tbao = "Mã có Id:" + i.IdMa + " không thể khóa vì ";
                        if (i.TrangThai == 1) tbao += "Mã đã được sử dụng";
                        if (i.TrangThai == 2) tbao += "Mã đã hết hạn";
                        if (i.TrangThai == 3) tbao += "Mã đã bị khóa";
                        MessageBox.Show(tbao);
                        iskhoa = false;
                        break;
                    }
            if (iskhoa)
            {
                var frmKhoa = new Khoa(dskhoa);
                frmKhoa.ShowDialog();
                if (frmKhoa.IsDisposed) Refesh();
            };
        }
        #endregion

        #region QLTK
        public void ClearQLTK()
        {
            lbIDNV.Text = "";
            txtChuThich.Clear();
            txtTaiKhoan.Clear();
            txtTenNV.Clear();
        }      
        public void LoadDSND()
        {
            GridviewDSNV.Rows.Clear();
            var db = new Database();
            var dsnd = (List<NguoiDung>)db.Laytatcathongtin("NguoiDungs", "ChucVu","=",false);
            if (dsnd[dsnd.Count - 1] != null)
            {
                int stt = 1;
                foreach (var i in dsnd)
                {                    
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(GridviewDSNV);
                    row.Cells[0].Value = stt;
                    row.Cells[1].Value = i.IdND;
                    row.Cells[2].Value = i.TaiKhoan;
                    row.Cells[3].Value = i.TenNhanVien;                                  
                    if (i.TrangThai == false) row.Cells[4].Value = "Đã Khóa";
                    if (i.TrangThai == true) row.Cells[4].Value = "Hoạt Động";
                    row.Cells[5].Value = i.ChuThich;
                    GridviewDSNV.Rows.Add(row);
                    stt++;
                }
            }

        }
        public bool checkTT(string taikhoan,string ten)
        {
            if (ten == "" || taikhoan == "" )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông Báo");
                return false;
            }
                     return true;

        }

        private void GridviewDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var db = new Database();
            int id = Convert.ToInt32(GridviewDSNV.CurrentRow.Cells[1].Value.ToString());
            NguoiDung n = (NguoiDung)db.getinfo("NguoiDungs", id);
            lbIDNV.Text = n.IdND.ToString();
            txtTaiKhoan.Text = n.TaiKhoan;
            txtTenNV.Text = n.TenNhanVien;
            txtChuThich.Text = n.ChuThich;         
        }

        private void btnRSMK_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (lbIDNV.Text != "")
            {
                int id = Convert.ToInt32(lbIDNV.Text);
                NguoiDung n = (NguoiDung)db.getinfo("NguoiDungs", id);
                n.MatKhau = new BaoMat().MaHoa("123456");
                busQLTK.suaNguoiDung(n);
                MessageBox.Show("Mật khẩu được khôi phục về mặc định", "Thông Báo");
            }
            else MessageBox.Show("Chọn tài khoản cần khôi phục mật khẩu", "Thông Báo");
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NguoiDung n = new NguoiDung();
            n.TenNhanVien = txtTenNV.Text;
            n.TaiKhoan = txtTaiKhoan.Text;
            n.MatKhau = "123456";
            n.TrangThai = true;
            n.ChuThich = txtChuThich.Text;
            n.ChucVu = false;
            if (checkTT(n.TaiKhoan,n.TenNhanVien) == true)
            {
                if (busQLTK.isTKHople(n.TaiKhoan) == false)
                {
                    MessageBox.Show("Tài Khoản đã tồn tại", "Thông Báo");
                }
                else
                {
                    if(busQLTK.themNguoiDung(n)>0)
                        MessageBox.Show("Thêm người dùng thành công", "Thông Báo");
                    else
                        MessageBox.Show("Thêm thất bại", "Thông Báo");
                    ClearQLTK();
                    LoadDSND();
                }
            }
        }
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                int id = Convert.ToInt32(lbIDNV.Text);
                NguoiDung n = (NguoiDung)db.getinfo("NguoiDungs", id);
                if (n.TaiKhoan.Equals(txtTaiKhoan.Text))
                {
                    n.TenNhanVien = txtTenNV.Text;
                    n.ChuThich = txtChuThich.Text;
                    if (busQLTK.suaNguoiDung(n)) MessageBox.Show("Sửa thông tin thành công", "Thông Báo");
                    else MessageBox.Show("Sửa thông tin thất bại", "Thông Báo");
                    LoadDSND();
                    ClearQLTK();
                }
                else MessageBox.Show("Tài khoản không được sửa");
            }
            catch { MessageBox.Show("Hãy chọn tài khoản cần sửa", "Thông Báo"); }
        }

        private void btnKhoaNV_Click(object sender, EventArgs e)
        {
            var db = new Database();
            try
            {
                int id = Convert.ToInt32(lbIDNV.Text);
                NguoiDung n = (NguoiDung)db.getinfo("NguoiDungs", id);               
                if (n.TrangThai == false)
                    {
                        LSKhoa ls = (LSKhoa)db.getinfo("LSKhoas", n.IdND);
                        MessageBox.Show("Tài Khoản này đã bị khóa", "Thông Báo");
                        MessageBox.Show("Lí do khóa: " + ls.LiDoKhoa, "Thông Báo");
                    }
                    else
                    {
                        var frmKhoa = new Khoa(n);
                        frmKhoa.ShowDialog();
                        if (frmKhoa.IsDisposed)
                        {
                            ClearQLTK();
                            LoadDSND();
                        }
                    }               
            }
            catch { MessageBox.Show("Hãy chọn tài khoản cần khóa", "Thông Báo"); }
        }
        #endregion

        #region Chinh sua TKCN
        private void btnSuaTKQL_Click(object sender, EventArgs e)
        {
            nd.TenNhanVien = TKCN_TenNV.Text;
            nd.TaiKhoan = txtTKCN.Text;
            string s = TKCN_MatKhau.Text;
            bool isValid = true;
            if (TKCN_TenNV.Text == "")
            {
                MessageBox.Show("Tên không được bỏ trống"); isValid = false;
            }
            if (txtTKCN.Text == "")
            {
                MessageBox.Show("Tài khoản không được bỏ trống");isValid = false;
            }
            foreach (var i in s)
                if (!(i >= '0' && i <= '9') && !(i >= 'a' && i <= 'z') && !(i >= 'A' && i <= 'Z'))
                {
                    MessageBox.Show("Mật khẩu không thể chứa kí tư đặc biệt");
                    isValid = false;
                    break;
                }
            if (s.Length < 5)
            {
                MessageBox.Show("Mật khẩu có ít nhất 5 kí tự");
                isValid = false;
            }
            if (isValid)
            {
                nd.MatKhau = new BaoMat().MaHoa(TKCN_MatKhau.Text);
                if (busQLTK.suaNguoiDung(nd))
                {
                    MessageBox.Show("Sửa Thông Tin Thành Công", "Thông Báo");
                }
                else
                    MessageBox.Show("Thất Bại", "Thông Báo");
            }
        }

        private void TKCaNhan_Load(object sender, TabControlEventArgs e)
        {
            TKCN_lbID.Text = nd.IdND.ToString();
            txtTKCN.Text = nd.TaiKhoan;
            TKCN_TenNV.Text = nd.TenNhanVien;
            TKCN_MatKhau.Text = new BaoMat().GiaiMa(nd.MatKhau);
            if (nd.TrangThai) TKCN_TrangThai.Text = "Hoạt Động";
            TKCN_ChucVu.Text = "Quản Lí";
           
        }
        #endregion

        private void Quanli_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Database().LichsuDX(nd.IdND); Application.Restart();
        }
        #region Thongke
        private void btnThongKe_TQ_Click(object sender, EventArgs e)
        {

            foreach (var series in TKTQ_Char.Series)
            {
                series.Points.Clear();
            }          
            DateTime frm = Convert.ToDateTime(tq_From.Text);        
            DateTime to = Convert.ToDateTime(tq_To.Text);
            if (to < frm) MessageBox.Show("Ngày Sau Phải Lớn Hơn Ngày Trước", "Thông Báo");
            else
            {
                var kqtke = new ThongKe().ThongkeTongQuat(frm, to);              
                if (kqtke== null) MessageBox.Show("Không Có Mã Được Tạo Ra Trong Thời Gian Này", "Thông Báo");
                else
                {
                    double tong = kqtke[5];
                    TKTQ_Char.Series[0].Points.AddXY(0,kqtke[1] / tong);
                    TKTQ_Char.Series[0].Points.AddXY(1,kqtke[0] / tong);
                    TKTQ_Char.Series[0].Points.AddXY(2,kqtke[2] / tong);
                    TKTQ_Char.Series[0].Points.AddXY(3,kqtke[3] / tong);
                    TKTQ_Char.Series[0].Points.AddXY(4,kqtke[4] / tong);
                    foreach (Series s in TKTQ_Char.Series)
                    {
                        s.Points[0].LegendText = "Đã Sử Dụng";
                        s.Points[1].LegendText = "Chưa Sử Dụng";
                        s.Points[2].LegendText = "Hết Hạn";
                        s.Points[3].LegendText = "Khóa";
                        s.Points[4].LegendText = "Chưa Lấy";
                    }
                    foreach (Series s in TKTQ_Char.Series)
                        foreach (DataPoint dp in s.Points)
                        {
                            if (dp.YValues[0] == 0) { dp.IsValueShownAsLabel = false; }
                        }
                }
            }
        }

        private void btnThongKe_CT_Click(object sender, EventArgs e)
        {
            foreach (var series in TKCT_Chart.Series)
            {
                series.Points.Clear();
            }
            
            DateTime frm = Convert.ToDateTime(CT_From.Text);
            DateTime to = Convert.ToDateTime(CT_To.Text);
            if (to < frm) MessageBox.Show("Ngày Sau Phải Lớn Hơn Ngày Trước", "Thông Báo");
            else
            {
                var kqtke = new ThongKe().ThongkeChiTiet(frm, to);
                if (kqtke == null) MessageBox.Show("Không Có Mã Được Tạo Ra Trong Thời Gian Này", "Thông Báo");
                else
                {
                    for (int i = 0; i<(kqtke.Length/6); i++)
                    {
                        TKCT_Chart.Series[0].Points.AddXY("Mã " + kqtke[i,5] + " Ký Tự", kqtke[i, 1]);
                        TKCT_Chart.Series[1].Points.AddY(kqtke[i, 0]);
                        TKCT_Chart.Series[2].Points.AddY(kqtke[i, 2]);
                        TKCT_Chart.Series[3].Points.AddY(kqtke[i, 3]);
                        TKCT_Chart.Series[4].Points.AddY(kqtke[i, 4]); ;
                    }
                    foreach (Series srs in TKCT_Chart.Series)
                    {
                        srs.IsValueShownAsLabel = false;
                        foreach (DataPoint point in srs.Points)
                        {
                            if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) != 0)
                            {
                                point.IsValueShownAsLabel = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

    }
}
