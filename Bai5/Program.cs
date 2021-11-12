using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    class Program
    {
        #region methods
        static int[,] taoMang(int n)
        {
            int[,] a = new int[n, n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    /*Console.Write("a[{0}][{1}] = ", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());*/
                    a[i, j] = r.Next(1, 100);
                }
            return a;
        }
        // Tinh tong cac phan tu duong cua mang (a)
        static int tongDuong(int[,] a)
        {
            int tong = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > 0) tong += a[i, j];
            return tong;
        }
        // Tinh tong cac phan tu mang trong do (i + j) chia het cho 5 (b)
        static int tongTheoIJ(int[,] a)
        {
            int tong = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if ((i + j) % 5 == 0) tong += a[i, j];
            return tong;
        }
        // Kiem tra 1 so co phai so nguyen to khong
        static bool kiemTraNguyenTo(int n)
        {
            if (n < 2) return false;           
            for (int i = 2; i < n / 2 + 1; i++)
                if (n % i == 0) return false;
            return true;
        }
        // In so nguyen to theo tung hang (c)
        static void inSoNguyenTo(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (kiemTraNguyenTo(a[i, j]))
                        Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }            
        }
        // Sap xep tang dan theo tung hang (d)      
        static int[,] sapXepTDTheoHang(int[,] a)
        {
            // Cho cot chay
            for (int c = 0; c < a.GetLength(1); c++)
                for (int i = 0; i < a.GetLength(0) - 1; i++)
                    for (int j = 1; j < a.GetLength(0); j++)
                        if (a[c, j] < a[c, j - 1])
                        {
                            int tmp = a[c, j - 1];
                            a[c, j - 1] = a[c, j];
                            a[c, j] = tmp;
                        }
            return a;
        }
        // Sap xep giam dan theo cot (e)
        static int[,] sapXepGDTheoCot(int[,] a)
        {
            // Cho hang chay
            for (int h = 0; h < a.GetLength(1); h++)
                for (int i = 0; i < a.GetLength(0) - 1; i++)
                    for (int j = 1; j < a.GetLength(0); j++)
                        if (a[j, h] > a[j - 1, h])
                        {
                            int tmp = a[j - 1, h];
                            a[j - 1, h] = a[j, h];
                            a[j, h] = tmp;
                        }
            return a;
        }

        // Tinh tong cac phan tu tren duong cheo chinh (f.1)
        static int tongDuongCheoChinh(int[,] a)
        {
            int tong = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (i == j) tong += a[i, j];
            return tong;
        }
        // Tinh tong cac phan tu tren duong bien (f.2)
        static int tongDuongBien(int[,] a)
        {
            int tong = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (i == 0 || j == 0 || i == a.GetLength(0) - 1 || j == a.GetLength(1) - 1) 
                        tong += a[i, j];
            return tong;
        }
        // Tim MAX theo hang (g.1)
        static void maxTheoHang(int[,] a)
        {
            a = sapXepTDTheoHang(a);
            for (int i = 0; i < a.GetLength(0); i++)
                Console.WriteLine("--Max hang {0}: {1}", i, a[i, a.GetLength(1) - 1]);
        }
        // Tim MIN theo hang (g.2)
        static void minTheoHang(int[,] a)
        {
            a = sapXepTDTheoHang(a);
            for (int i = 0; i < a.GetLength(0); i++)
                Console.WriteLine("--Min hang {0}: {1}", i, a[i, 0]);
        }
        // Tim MAX theo cot (g.3)
        static void maxTheoCot(int[,] a)
        {
            a = sapXepGDTheoCot(a);
            for (int i = 0; i < a.GetLength(0); i++)
                Console.WriteLine("--Max cot {0}: {1}", i, a[0, i]);
        }
        // Tim MIN theo cot (g.4)
        static void minTheoCot(int[,] a)
        {
            a = sapXepGDTheoCot(a);
            for (int i = 0; i < a.GetLength(0); i++)
                Console.WriteLine("--Max cot {0}: {1}", i, a[a.GetLength(0) - 1, i]);
        }
        // Tim MAX cua toan bo ma tran (g.5)
        static int timMax(int[,] a)
        {
            int max = a[0, 0];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max) max = a[i, j];
            return max;
        }
        // Tim MIN cua toan bo ma tran (g.6)
        static int timMin(int[,] a)
        {
            int min = a[0, 0];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] < min) min = a[i, j];
            return min;
        }

        // In cac phan tu cua mang
        static void inMang(int [,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            
        }
        #endregion
        // Main
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] a = taoMang(n);
            //int[,] aClone = a;

            Console.WriteLine("-Ma tran ban dau: ");
            inMang(a);

            Console.WriteLine("-Tong cac phan tu duong cua mang: {0}", tongDuong(a));
            Console.WriteLine("-Tong cac phan tu ma i + j = 5: {0}", tongTheoIJ(a));
            Console.WriteLine("-Cac so nguyen to theo hang: ");
            inSoNguyenTo(a);

            Console.WriteLine("-Sap xep tang dan theo hang: ");
            int[,] tangDanTheoHang = sapXepTDTheoHang(a);
            inMang(tangDanTheoHang);

            Console.WriteLine("-Sap xep giam dan theo cot: ");
            int[,] giamDanTheoCot = sapXepGDTheoCot(a);
            inMang(giamDanTheoCot);

            Console.WriteLine("-Tong duong cheo chinh: {0}", tongDuongCheoChinh(a));
            Console.WriteLine("-Tong duong bien: {0}", tongDuongBien(a));

            Console.WriteLine("-Max, min theo hang: ");
            maxTheoHang(a);
            minTheoHang(a);

            Console.WriteLine("-Max, min theo cot: ");
            maxTheoCot(a);
            minTheoCot(a);

            Console.WriteLine("-Max cua ma tran: {0}", timMax(a));
            Console.WriteLine("-Min cua ma tran: {0}", timMin(a));

            Console.ReadKey();
        }
    }
}
