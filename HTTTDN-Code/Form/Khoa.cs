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
    public partial class Khoa : Form
    {
        List<Ma> dsmakhoa=new List<Ma>();
        bool isKhoaND = false;
        NguoiDung nd = new NguoiDung();
        QLMaBUS bus = new QLMaBUS();
        QLTKBus bustk = new QLTKBus();
        public Khoa(object dskhoa)
        {
            if (dskhoa.GetType().ToString().IndexOf("NguoiDung") > 1)
            {
                nd = (NguoiDung)dskhoa;isKhoaND = true;
            }
            else
            dsmakhoa = (List<Ma>)dskhoa;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVV.Checked) txtNgay.Enabled = false;
            else txtNgay.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int ngay;
            try
            {
                
                if (txtLido.Text == "") MessageBox.Show("Hãy nhập lí do khóa mã");
                else
                {
                    bool kq = false;
                    if (checkVV.Checked == false)
                    {
                        ngay = Convert.ToInt32(txtNgay.Text);
                        if (!isKhoaND)
                            kq = bus.KhoaMa(dsmakhoa, ngay, txtLido.Text);
                        //else khoand here
                        else kq = bustk.Lock(nd, ngay, txtLido.Text);
                    }
                    else
                    {
                        if(!isKhoaND)
                        kq = bus.KhoaMa(dsmakhoa, 0, txtLido.Text);
                        //else khoand here
                        else kq = bustk.Lock(nd, 0, txtLido.Text);
                    }
                    if (!kq) MessageBox.Show("Xảy ra lỗi khóa không thành công");
                    else { MessageBox.Show("Khóa thành công"); this.Dispose(); }
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu ngày không hợp lệ");
            }
           
        }
    }
}
