using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HTTTDN_Code
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bnDN_Click(object sender, EventArgs e)
        {
            new QLTKBus().MoKhoaTK();
            if (txtTK.Text != "" && txtPass.Text != "")
            {
                Form a;
                string pass = new BaoMat().MaHoa(txtPass.Text);
                HTTTDN_Code.NguoiDung nd = (HTTTDN_Code.NguoiDung)new Database().Login(txtTK.Text, pass);
                if (nd == null) MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                else if (nd.TrangThai == true)
                {
                    if (nd.ChucVu == true) a = new Quanli(nd);
                    else a = new Nhanvien(nd);
                    a.Show();
                    //ghi log dnhap
                    new Database().LichsuDN(nd.IdND);
                    this.Hide();
                }
                else if (!nd.TrangThai)
                {
                    var db = new Database();
                    LSKhoa ls = (LSKhoa)db.getinfo("LSKhoas", nd.IdND);
                    if (ls.SoNgayKhoa == 0)
                        MessageBox.Show("Tài Khoản này đã bị khóa vô thời hạn", "Thông Báo");
                    else
                        MessageBox.Show("Tài Khoản này đã bị khóa " + ls.SoNgayKhoa + " ngày \nCó hiệu lực từ " + ls.ThoiGianKhoa, "Thông Báo");
                    MessageBox.Show(ls.LiDoKhoa, "Lí Do");
                }
            }
            else MessageBox.Show("Hãy nhập đầy đủ tài khoản và mật khẩu");
            
        }
     
        private void txtPass_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bnDN_Click(this, new EventArgs());
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
