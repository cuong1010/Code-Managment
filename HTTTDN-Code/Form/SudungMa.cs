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
    public partial class SudungMa : Form
    {
        public SudungMa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;bool isValid = true;
            foreach (var i in s)
                if (i < 'A' || i > 'Z') { MessageBox.Show("Mã không hợp lệ"); isValid = false; }
            if(isValid)
            {
                string tbao;
                int kq = new QLMaBUS().Nhapma(s);
                if (kq == -1) tbao = "Mã không đúng";
                else if (kq == 1) tbao = "Mã đã được sử dụng";
                else if (kq == 2) tbao = "Mã đã hết hạn";
                else if (kq == 3) tbao = "Mã hiện tại không thể sử dụng";
                else tbao = "Kích hoạt mã thành công";
                MessageBox.Show(tbao);
            }

        }
    }
}
