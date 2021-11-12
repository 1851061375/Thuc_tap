using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bai4
{
    class Program
    {
        #region methods
        // Nhap n (1.1)
        static int nhapN()
        {
            int n;
            do
            {
                Console.Write("Nhap N = ");
                n = Convert.ToInt32(Console.ReadLine());
            }
                
            while (n < 0 || n >= 50);
            return n;
        }
        // Nhap mang String n phan tu (1.2)
        static string[] nhapMangChuoi(int n)
        {
            string[] s = new string[n];
            for (int i = 0; i < n; i++)
                do
                {
                    Console.Write("s[{0}] = ", i);
                    s[i] = Console.ReadLine();
                }
                while (s[i].Length > 30);
            return s;
        }
        // Tim chuoi co kich thuoc lon nhat (2.1)
        static string chuoiDaiNhat(string[] s)
        {
            int sizeMax = s[0].Length, index = 0;
            for (int i = 1; i < s.Length; i++)
                if (s[i].Length > sizeMax)
                {
                    sizeMax = s[i].Length;
                    index = i;
                }
            return s[index];
        }
        // Tim chuoi co kich thuc nho nhat (2.2)
        static string chuoiNganNhat(string[] s)
        {
            int sizeMin = s[0].Length, index = 0;
            for (int i = 1; i < s.Length; i++)
                if (s[i].Length < sizeMin)
                {
                    sizeMin = s[i].Length;
                    index = i;
                }
            return s[index];
        }
        // Tinh kich thuoc trung binh cua cac chuoi (3)
        static double trungBinh(string[] s)
        {
            double tb = 0;
            for (int i = 0; i < s.Length; i++)
                tb += (int)s[i].Length;
            return tb / s.Length;
        }
        // Tim chuoi co kich thuc lon hon trung binh (4)
        static ArrayList lonHonTBC(string[] s)
        {
            ArrayList output = new ArrayList();
            double tb = trungBinh(s);
            for (int i = 0; i < s.Length; i++)
                if (s[i].Length > tb) output.Add(s[i]);
            return output;
        }
        // Sap xep chuoi tang dan theo kich thuoc (5.1)
        static string[] sapXepTD(string[] s)
        {
            // Sap xep noi bot (nhe noi len tren)
            for (int i = 0; i < s.Length - 1; i++)
                for (int j = 1; j < s.Length; j++)
                    if (s[j].Length < s[j - 1].Length)
                    {
                        string tmp = s[j - 1];
                        s[j - 1] = s[j];
                        s[j] = tmp;
                    }
            return s;
        }
        // Sap xep chuoi giam dan theo kich thuoc (5.2)
        static string[] sapXepGD(string[] s)
        {
            for (int i = 0; i < s.Length - 1; i++)
                for (int j = 1; j < s.Length; j++)
                    if (s[j].Length > s[j - 1].Length)
                    {
                        string tmp = s[j - 1];
                        s[j - 1] = s[j];
                        s[j] = tmp;
                    }
            return s;
        }
        // Tim chuoi nho nhat theo ASCII (6.1)
        // Tinh tong theo ASCII
        static int tong(string s)
        {
            int tong = 0;
            for (int i = 0; i < s.Length; i++)
                tong += (int)s[i];
            return tong;
        }
        static string nhoNhatASCII(string[] s)
        {
            int min = tong(s[0]), index = 0;
            for (int i = 1; i < s.Length; i++)
                if (tong(s[i]) < min)
                {
                    min = tong(s[i]);
                    index = i;
                }
            return s[index];

        }
        // Tim chuoi lon nhat theo ASCII (6.2)
        static string lonNhatASCII(string[] s)
        {
            int max = tong(s[0]), index = 0;
            for (int i = 1; i < s.Length; i++)
                if (tong(s[i]) > max)
                {
                    max = tong(s[i]);
                    index = i;
                }
            return s[index];

        }
        // Sap xep tang dan theo ASCII (7.1)
        static string[] sapXepTDASCII(string[] s)
        {
            for (int i = 0; i < s.Length - 1; i++)
                for (int j = 1; j < s.Length; j++)
                    if (tong(s[j]) < tong(s[j - 1]))
                    {
                        string tmp = s[j - 1];
                        s[j - 1] = s[j];
                        s[j] = tmp;
                    }
            return s;
        }
        // Sap xep giam dan theo ASCII (7.1)
        static string[] sapXepGDASCII(string[] s)
        {
            for (int i = 0; i < s.Length - 1; i++)
                for (int j = 1; j < s.Length; j++)
                    if (tong(s[j]) > tong(s[j - 1]))
                    {
                        string tmp = s[j - 1];
                        s[j - 1] = s[j];
                        s[j] = tmp;
                    }
            return s;
        }
        // nhap chuoi
        static string nhapChuoi()
        {
            string s;
            do
            {
                Console.Write("Nhap chuoi: ");
                s = Console.ReadLine();
            }
            while (s.Length > 30);
            return s;
        }
        // Tim nhung chuoi co cung kich thuoc (8.1)
        static ArrayList coCungKichThuoc(string[] s, string kt)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (s[i].Length == kt.Length) output.Add(s[i]);
            return output;
        }
        // Tim nhung chuoi trong mang a co chua chuoi kt (8.2)
        static ArrayList coChuaKT(string[] s, string kt)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (s[i].Contains(kt)) output.Add(s[i]);
            return output;
        }
        // Kiem tra doi xung (9)
        static string nghichDaoChuoi(string s)
        {
            string a = "";
            for (int i = s.Length - 1; i >= 0; i--)
                a += s[i];
            return a;
        }
        static bool kiemTraDoiXung(string s)
        {
            string a = nghichDaoChuoi(s);
            if (a == s) return true;
            return false;
        }
        static ArrayList chuoiDX(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (kiemTraDoiXung(s[i])) output.Add(s[i]);
            return output;
        }

        // Kiem tra email (10)
        static bool kiemTraEmail(string s)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(s);
            return match.Success;
        }
        static ArrayList emailHopLe(string [] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (kiemTraEmail(s[i])) output.Add(s[i]);
            return output;
        }
        // Tim nhung chuoi co chua so (11)
        static bool kiemTraSo(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (int.TryParse(s[i].ToString(), out int n)) return true;
            return false;
        }
        static ArrayList coChuaSo(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (kiemTraSo(s[i])) output.Add(s[i]);
            return output;
        }
        // Tim nhung chuoi co ky tu in hoa (12)
        static bool kiemTraInHoa(string s)
        {
            //s.Any(char.IsUpper); 
            for (int i = 0; i < s.Length; i++)
                // if (char.IsUpper(s[i])) return true;
                // A: 65 -> Z: 90
                if ((int)s[i] >= 65 && (int)s[i] <= 90) return true;
            return false;
        }
        static ArrayList coInHoa(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (kiemTraInHoa(s[i])) output.Add(s[i]);
            return output;
        }

        // Tim cac chuoi co chua ky tu c (13)
        static bool kiemTraKT(string s, char c)
        {
            // s.Contains(c);
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c) return true;
            return false;
        }

        static ArrayList coKTC(string[] s, char c)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (kiemTraKT(s[i], c)) output.Add(s[i]);
            return output;
        }
        // Dem chu? (14)
        static int demTu(string s)
        {
            // char.IsLetter(s[i]);
            int dem = 0;
            for (int i = 0; i < s.Length; i++)
                if (((int)s[i] >= 65 && (int)s[i] <= 90) ||
                    ((int)s[i] >= 97 && (int)s[i] <= 122)) dem++;
            return dem;
        }
        static Dictionary<string, int> soTuCuaChuoi(string[] s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i++)
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], demTu(s[i]));
            return dic;
        }

        // Dem so lan xuat hien cua chuoi x trong mang s (16)
        static int nhapM(int n)
        {
            int m;
            do
            {
                Console.Write("M = ");
                m = Convert.ToInt32(Console.ReadLine());
            }
                
            while (m < 0 || m >= n);
            return m;
        }
        static int demChuoi(string[] s, string x)
        {
            int dem = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i].Contains(x)) dem++;
            return dem;
        }
        
        static Dictionary<string, int> ketQuaDemChuoi(string[] a, string [] b)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < b.Length; i++)
                if (!dic.ContainsKey(b[i]))
                    dic.Add(b[i], demChuoi(a, b[i]));
            return dic;
        }
        // Noi tat ca cac chuoi roi in ra (17)
        static string noiChuoi(string[] s)
        {
            string output = "";
            for (int i = 0; i < s.Length; i++)
                output += s[i];
            return output;
        }
        // Tim cac chuoi chua chuoi dau tien (18)
        static ArrayList chuaChuoiDauTien(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 1; i < s.Length; i++)
                if (s[i].Contains(s[0])) output.Add(s[i]);
            return output;
        }
        
        // Tinh trung binh theo ASCII (20)
        static double trungBinh(string s)
        {
            double tb = 0;
            for (int i = 0; i < s.Length; i++)
                tb += (int)s[i];
            return tb / s.Length;
        }
        static Dictionary<string, double> trungBinhCacChuoi(string[] s)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
            for (int i = 0; i < s.Length; i++)
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], trungBinh(s[i]));
            return dic;
        }

        // Tim cac chuoi co do dai lon hon do dai nho nhat (21.1)
        static ArrayList chuoiDaiHonMin(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (s[i].Length > chuoiNganNhat(s).Length) output.Add(s[i]);
            return output;
        }
        // Tim cac chuoi co do dai ngan hon do dai lon nhat (21.2)
        static ArrayList chuoiNganHonMax(string[] s)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (s[i].Length < chuoiDaiNhat(s).Length) output.Add(s[i]);
            return output;
        }
        // Tim cac chuoi co do dai bang do dai truyen vao (22)
        static ArrayList chuoiCungDoDai(string[] s, int dodai)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < s.Length; i++)
                if (s[i].Length == dodai) output.Add(s[i]);
            return output;
        }

        static void inMang(ArrayList arr)
        {
            for (int i = 0; i < arr.Count; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static void inMang(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
                Console.Write(s[i] + " ");
            Console.WriteLine();
        }
        #endregion

        static void Main(string[] args)
        {
            int n = nhapN();
            string[] s = nhapMangChuoi(n);

            Console.WriteLine("Chuoi dai nhat: {0}", chuoiDaiNhat(s));

            Console.WriteLine("Chuoi ngan nhat: {0}", chuoiNganNhat(s));

            Console.WriteLine("Trung binh: {0}", trungBinh(s));

            Console.Write("Cac chuoi lon hon TBC: ");
            ArrayList tbc = lonHonTBC(s);
            inMang(tbc);

            Console.Write("Sap xep tang dan theo kich thuoc: ");
            string[] sTangDan = sapXepTD(s);
            inMang(sTangDan);

            Console.Write("Sap xep giam dan theo kich thuoc: ");
            string[] sGiamDan = sapXepGD(s);
            inMang(sGiamDan);

            Console.WriteLine("Chuoi nho nhat theo ASCII: {0}", nhoNhatASCII(s));
            Console.WriteLine("Chuoi lon nhat theo ASCII: {0}", lonNhatASCII(s));

            Console.Write("Sap xep tang dan theo ma ASCII: ");
            string[] tangDanASCII = sapXepTDASCII(s);
            inMang(tangDanASCII);

            Console.Write("Sap xep giam dan theo ma ASCII: ");
            string[] giamDanASCII = s;
            giamDanASCII = sapXepGDASCII(giamDanASCII);
            inMang(giamDanASCII);

            string kt = nhapChuoi();
            Console.Write("Cac chuoi co cung kich thuoc: ");
            ArrayList cungKT = coCungKichThuoc(s, kt);
            inMang(cungKT);

            Console.Write("Cac chuoi co chua chuoi vua nhap: ");
            ArrayList chuaKT = coChuaKT(s, kt);
            inMang(chuaKT);

            Console.Write("Cac chuoi doi xung: ");
            ArrayList chuoiDoiXung = chuoiDX(s);
            inMang(chuoiDoiXung);

            Console.Write("Cac chuoi co dang email: ");
            ArrayList email = emailHopLe(s);
            inMang(email);

            Console.Write("Cac chuoi co ky tu so: ");
            ArrayList so = coChuaSo(s);
            inMang(so);

            Console.Write("Cac chuoi co ky tu in hoa: ");
            ArrayList inHoa = coInHoa(s);
            inMang(inHoa);

            Console.Write("Nhap ky tu: ");
            char c = (char)Console.ReadLine()[0];
            ArrayList coKT = coKTC(s, c);
            Console.Write("Cac chuoi co chua ky tu vua nhap: ");
            inMang(coKT);

            Dictionary<string, int> dic = soTuCuaChuoi(s);
            foreach (var item in dic)
                Console.WriteLine("Chuoi: {0}, So tu: {1}", item.Key, item.Value);
 
            Console.Write("Nhap ky tu: ");
            char c2 = (char)Console.ReadLine()[0];
            if (s[s.Length - 1].Length >= 6)
            {
                s[s.Length - 1] = s[s.Length - 1].Insert(5, c2.ToString());
                Console.WriteLine("Chen ky tu vua nhap vao vi tri so 5 cua chuoi cuoi cung: " + s[s.Length - 1]);
            }
            else
                Console.WriteLine("Chuoi cuoi cung co do dai nho hon 6");

            int m = nhapM(n);
            string[] s2 = nhapMangChuoi(m);
            Dictionary<string, int> kqDem = ketQuaDemChuoi(s, s2);
            foreach (var item in kqDem)
                Console.WriteLine("Chuoi: {0}, So lan xuat hien: {1}", item.Key, item.Value);

            Console.Write("Noi cac chuoi: " + noiChuoi(s));

            ArrayList chuaChuoiDT = chuaChuoiDauTien(s);
            Console.Write("Cac chuoi chua chuoi dau tien: ");
            inMang(chuaChuoiDT);

            if (s[0].StartsWith("Hello"))
                Console.WriteLine("Chuoi dau tien co bat dau bang Hello");
            else
                Console.WriteLine("Chuoi dau tien khong bat dau bang Hello");

            Dictionary<string, double> tb = trungBinhCacChuoi(s);
            foreach (var item in tb)
                Console.WriteLine("Chuoi: {0}, Trung binh: {1}", item.Key, item.Value);

            Console.Write("Cac chuoi co do dai lon hon chuoi ngan nhat: ");
            ArrayList daiHonMin = chuoiDaiHonMin(s);
            inMang(daiHonMin);

            Console.Write("Cac chuoi co do dai nho hon chuoi dai nhat: ");
            ArrayList nganHonMax = chuoiNganHonMax(s);
            inMang(nganHonMax);

            Console.Write("Nhap do dai: ");
            int dodai = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cac chuoi co do dai nho hon chuoi dai nhat: ");
            ArrayList cungDoDai = chuoiCungDoDai(s, dodai);
            inMang(cungDoDai);

            Console.WriteLine("So tu trong chuoi N-1: " + demTu(s[n - 1]));

            Console.WriteLine("Chuyen chuoi thu 2 thanh in hoa: " + s[1].ToUpper());

            Console.WriteLine("Cat ky tu trang o cuoi chuoi cuoi cung: " + s[n - 1].TrimEnd());
            Console.WriteLine("Cat ky tu trang o dau chuoi cuoi cung: " + s[n - 1].TrimStart());
            s[n - 1] = s[n - 1].Replace("  ", " ");
            Console.WriteLine("Cat ky tu trang o dau chuoi cuoi cung: " + s[n - 1]);
            Console.ReadKey();           
        }
    }
}
