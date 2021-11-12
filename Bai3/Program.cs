using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        #region methods
        // Nhap chuoi (1)
        static string nhapChuoi()
        {
            string s;
            do
                s = Console.ReadLine();
            while (s.Length <= 0 || s.Length > 50);
            return s;
        }
        // Kiem tra trong chuoi co so khong (2)
        static bool kiemTraSo(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (int.TryParse(s[i].ToString(), out int n)) return true;
            return false;
        }
        // Kiem tra trong chuoi co ky tu in hoa khong (3)
        static bool kiemTraInHoa(string s)
        {
            // s.Any(char.IsUpper); 
            for (int i = 0; i < s.Length; i++)
                // if (char.IsUpper(s[i])) return true;
                // A: 65 -> Z: 90
                if ((int)s[i] >= 65 && (int)s[i] <= 90) return true;
            return false;
        }
        // Kiem tra ky tu co trong chuoi khong (4)
        static bool kiemTraKT(string s, char c)
        {
            // s.Contains(c);
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c) return true;
            return false;
        }
        // Kiem tra chuoi a co chua chuoi b khong (5.1)
        static bool kiemTraChuoi(string a, string b)
        {
            // a.Contains(b)
            for (int i = 0; i < b.Length; i++)
                if (!kiemTraKT(a, b[i])) return false;
            return true;
        }
        // Kiem tra chuoi b co do dai lon hon chuoi khong (5.2)
        static bool kiemTraDoDai(string a, string b)
        {
            return b.Length > a.Length ? true : false;
        }
        // Kiem tra xem chuoi co doi xung khong (6)
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
        // Dem so tu(7)
        static int demTu(string s)
        {
            // char.IsLetter(s[i]);
            int dem = 0;
            for (int i = 0; i < s.Length; i++)
                if (((int)s[i] >= 65 && (int)s[i] <= 90) ||
                    ((int)s[i] >= 97 && (int)s[i] <= 122)) dem++;
            return dem;
        }
        // Cat dau cach o cuoi chuoi (8)
        static string xoaDauCachCuoi(string s)
        {
            // s.TrimEnd();
            int i = s.Length - 1;
            while (s[i] == ' ')
            {
                s = s.Remove(i);
                i--;
            }
            return s;
        }

        // Tinh trung binh theo ASCII
        static double trungBinh(string s)
        {
            double tb = 0;
            for (int i = 0; i < s.Length; i++)
                tb += (int)s[i];
            return tb / s.Length;
        }
        // Dem ky so lan xuat hien (12)
        static int dem(string s, char c)
        {
            int dem = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c) dem++;
            return dem;
        }
        static Dictionary<char, int> demCacKT(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], dem(s, s[i]));
            return dic;
        }
        #endregion
        // Main
        static void Main(string[] args)
        {
            string a, b;
            Console.Write("Nhap chuoi a: ");
            a = nhapChuoi();

            if (kiemTraSo(a)) Console.WriteLine("Co chua so");

            if (kiemTraInHoa(a)) Console.WriteLine("Co ky tu in hoa");

            Console.Write("Nhap ky tu: ");
            char c = (char)Console.Read();
            if (kiemTraKT(a, c)) Console.WriteLine("Chuoi co chua ky tu vua nhap");

            Console.Write("Nhap chuoi b: ");
            b = nhapChuoi();
            if (kiemTraChuoi(a, b)) Console.WriteLine("Chuoi a co chua chuoi b");

            if (kiemTraDoDai(a, b)) Console.WriteLine("Chuoi b co doi dai lon hon chuoi a");

            if (kiemTraDoiXung(a)) Console.WriteLine("Chuoi doi xung");

            //a = "..........nnn.....a";
            Console.WriteLine("So tu trong chuoi: " + demTu(a));

            Console.WriteLine("Cat dau cach o cuoi chuoi: " + a.TrimStart());
            Console.WriteLine("Cat dau cach o dau chuoi: " + a.TrimStart());
            a = a.Replace("  ", " ");
            Console.WriteLine("Giua cac tu co toi da 1 dau cach: " +  a);
            Console.WriteLine("Gia tri trung binh cua chuoi theo ma ASCII: " + trungBinh(a));


            Dictionary<char, int> dic = demCacKT(a);
            foreach (var item in dic)
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            
            Console.ReadKey();
        }
    }
}
