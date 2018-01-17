using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTTDN_Code
{
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }
        public Nhanvien(NguoiDung nd)
        {
            this.nd = nd;
            InitializeComponent();
        }
       
        public NguoiDung nd;
        List<Ma> dsmalay = new List<Ma>();
        QLMaBUS busQLma = new QLMaBUS();
        QLTKBus busQLTK = new QLTKBus();
        private void Nhanvien_Load(object sender, EventArgs e)
        {
            TKCN_lbID.Text = nd.IdND.ToString();
            TKCN_Ten.Text = nd.TenNhanVien;
            TKCN_MatKhau.Text = new BaoMat().GiaiMa(nd.MatKhau);
            if (nd.TrangThai) TKCN_TrangThai.Text = "Hoạt Động";
            TKCN_ChucVu.Text = "Nhân Viên";
        }

        private void btnLay_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = Convert.ToInt32(txtSL.Text);
                int slkitu = Convert.ToInt32(txtSoKiTu.Text);                         
                GridLayMa.Rows.Clear();
                dsmalay = busQLma.LayMa(sl, slkitu, nd.IdND);
                if (dsmalay == null) MessageBox.Show("Không có mã nào có " + slkitu + " kí tự");
                else if (sl > dsmalay.Count) MessageBox.Show("SL mã k đủ, hệ thống chỉ còn " + dsmalay.Count + " mã " + slkitu + " kí tự có thể lấy");
                else
                {
                    int stt = GridLayMa.Rows.Count + 1;
                    foreach (var i in dsmalay)
                    {
                        DataGridViewRow row = new DataGridViewRow(); row.CreateCells(GridLayMa);
                        row.Cells[0].Value = stt;
                        row.Cells[1].Value = i.IdMa;
                        row.Cells[2].Value = new BaoMat().GiaiMa(i.NoiDung);
                        row.Cells[3].Value = i.ThoiGianHetHan;
                        GridLayMa.Rows.Add(row);
                        stt++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ");
            }
        }

        private void btnSuaTKQL_Click(object sender, EventArgs e)
        {
            string s = TKCN_MatKhau.Text;
            bool isValid = true;
            foreach (var i in s)
                if (!(i >= '0' && i <= '9') && !(i >= 'a' && i <= 'z') && !(i >= 'A' && i <= 'Z'))
                {
                    MessageBox.Show("Mật khẩu không thể chứa kí tư đặc biệt");
                    isValid = false;
                    break;
                }
            if (s.Length < 5)
            {
                MessageBox.Show("Tài khoản có ít nhất 5 kí tự");
                isValid = false;
            }
           if(isValid)
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

        private void Nhanvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Database().LichsuDX(nd.IdND); Application.Restart();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dsmalay != null && dsmalay.Count > 0)
                {
                    PrintDialog log = new PrintDialog();
                    PrintDocument doc = new PrintDocument();
                    log.Document = doc;
                    doc.PrintPage += new PrintPageEventHandler(InHoaDon);
                    DialogResult result = log.ShowDialog();
                    if (result == DialogResult.OK) doc.Print();
                }
                else MessageBox.Show("Không Có Mã Để In", "Thông Báo");
            }
            catch (Exception)
            {

            }
        }
        private void InHoaDon(object sender, PrintPageEventArgs e)
        {
            Graphics HoaDon = e.Graphics;

            int startX = 0;
            int startY = 0;
            int Offset = 20;

            HoaDon.DrawString("Xin Chào", new Font("Courier New", 8),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 20;


            HoaDon.DrawString("Ngày :" + DateTime.Now,
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            String underLine = "------------------------------------------";

            HoaDon.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 20;
            foreach (var i in dsmalay)
            {
                HoaDon.DrawString(i.NoiDung, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 20;
            }
            Offset += 20;


            Offset += 20;
            underLine = "------------------------------------------";
            HoaDon.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 20;
        }
    }
}
