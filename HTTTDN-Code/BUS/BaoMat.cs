using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTTDN_Code
{
    class BaoMat
    {
        private string key = "htttdn";
        //su dung mã vigenere để mã hóa và giải mã
        string[] arrUpper = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K", "L", "M", "N",
                               "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        string[] arrLower = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
                               "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
        string[] arrSo = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string MaHoa(string banRo)
        {
            string khoa = taoChuoiKhoa(banRo,key);
            string banMa = "";
            for (int i = 0; i < banRo.Length; i++)
            {
                if (banRo[i] >= '0' && banRo[i] <= '9') banMa += maHoaSo(banRo[i], khoa[i]);
                else
                    banMa += maHoaKyTu(banRo[i], khoa[i]);
            }
            return banMa;
        }

        public string GiaiMa(string banMa)
        {
            string khoa = taoChuoiKhoa(banMa,key);
            string banRo = "";
            for (int i = 0; i < banMa.Length; i++)
            {
                if (banMa[i] >= '0' && banMa[i] <= '9') banRo += giaiMaSo(banMa[i], khoa[i]);
                else
                    banRo += giaiMaKyTu(banMa[i], khoa[i]);
            }
            return banRo;
        }     
        private string maHoaKyTu(char p, char k)
        {
            int vt = viTriKyTu(p);
            int so = viTriCuaKhoa(k);
            if (Char.IsUpper(p))
            {
               
                return arrUpper[(vt + so) % 26];
            }
            else
            {
                return arrLower[(vt + so) % 26];
            }
        }
        private string maHoaSo(char p, char k)
        {

            int vt =Convert.ToInt32(p.ToString());
            int so = viTriCuaKhoa(k)%10;

            return arrSo[(vt + so) % 10];
        }
        private string giaiMaSo(char c, char k)
        {
            int vt = Convert.ToInt32(c.ToString());
            int so = viTriCuaKhoa(k)%10;
            if ((vt - so) < 0)
                return ((vt - so) + 10).ToString();
            else
                return ((vt - so) % 10).ToString();
        }
        private string giaiMaKyTu(char c, char k)
        {
            int vt = viTriKyTu(c);
            int so = viTriCuaKhoa(k);
            if (Char.IsUpper(c))
            {
                if ((vt - so) < 0)
                    return arrUpper[(vt - so) + 26];
                else
                    return arrUpper[(vt - so) % 26];
            }
            else
            {
                if ((vt - so) < 0)
                    return arrLower[(vt - so) + 26];
                else
                    return arrLower[(vt - so) % 26];
            }
        }

        private string taoChuoiKhoa(string str, string key)
        {
            string khoa ="";
            while (key.Length < str.Length)
                key += key;
            for (int i = 0; i < str.Length; i++)
                khoa = khoa + key[i];
            return khoa.ToUpper();
        }

        private int viTriKyTu(char kytu)
        {
            int vt = 0;
            if (Char.IsUpper(kytu))
            {
                for (int i = 0; i < arrUpper.Length; i++)
                    if (arrUpper[i].Equals(kytu.ToString()))
                        vt = i;
            }
            else
            {
                for (int i = 0; i < arrLower.Length; i++)
                    if (arrLower[i].Equals(kytu.ToString()))
                        vt = i;
            }

            return vt;
        }

        private int viTriCuaKhoa(char key)
        {
            int vt = 0;
            for (int i = 0; i < arrUpper.Length; i++)
                if (arrUpper[i].Equals(key.ToString()))
                    vt = i;
            return vt;
        }
    }
}
