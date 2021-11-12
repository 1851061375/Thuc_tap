using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Program
    {
        #region methods
        // Nhap so nguyen  0 < n < 50 (1)
        static int nhapN()
        {
            int n;
            do
            {
                Console.Write("Nhap n = ");
                n = Convert.ToInt32(Console.ReadLine());
            }
                
            while (n < 1 || n > 50);
            return n;
        }
        // Nhap mang so thuc (2)
        static double[] nhapMang(int n) 
        {
            double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("arr[" + i + "] = ");
                arr[i] = Convert.ToDouble(Console.ReadLine());
            }
            return arr;
        }
        // Tim so lon nhat (3)
        static double timMax(double[] arr)
        {
            double max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max;
        }
        // Tim so nho nhat (4)
        static double timMin(double[] arr)
        {
            double min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min) min = arr[i];
            return min;
        }
        // Tim so chan duong lon nhat (5)
        static double soChanMax(double[] arr)
        {
            double even = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 == 0 && arr[i] > even) even = arr[i];
            return even;
        }
        // Tim so le am nho nhat (6)
        static double soLeMin(double[] arr)
        {
            double odd = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 != 0 && arr[i] < odd) odd = arr[i];
            return odd;
        }
        // Tim cac so chinh phuong (7)
        // Kiem tra 1 so co phai CP ko
        static bool CP(double n)
        {
            int dem = 0;
            for (int i = 1; i < n / 2 + 1; i++)
                if (i * i == n) dem++;
            return (dem == 1) ? true : false;
        }
        // Lay ra cac so chinh phuong trong mang
        static ArrayList soChinhPhuong(double[] arr)
        {
            ArrayList output = new ArrayList();
            for (int i = 0; i < arr.Length; i++)
                if (CP(arr[i])) output.Add(arr[i]);
            return output;
        }
        // Tinh tong mang (8)
        static double tong(double[] arr)
        {
            double tong = 0;
            for (int i = 0; i < arr.Length; i++)
                tong += arr[i];
            return tong;
        }
        // Tinh trung binh cong (9)
        static double trungBinhCong(double[] arr)
        {
            return tong(arr) / arr.Length;
        }
        // Tim cac phan tu lon hon TBC (10)
        static ArrayList lonHonTBC(double[] arr)
        {
            ArrayList output = new ArrayList();
            double tbc = trungBinhCong(arr);
            for (int i = 0; i < arr.Length; i++) 
                if (arr[i] > tbc) output.Add(arr[i]);
            return output;
        }
        // Sap xep mang tang dan (11)
        static double[] sapXepTD(double[] arr)
        {
            // Sap xep noi bot (nhe noi len tren)
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 1; j < arr.Length; j++)
                    if (arr[j] < arr[j - 1])
                    {
                        double tmp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tmp;
                    }
            return arr;
        }
        // Sap xem mang giam dan (12)
        static double[] sapXepGD(double[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 1; j < arr.Length; j++)
                    if (arr[j] > arr[j - 1])
                    {
                        double tmp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tmp;
                    }
            return arr;
        }
        static void inMang(ArrayList  arr)
        {
            for (int i = 0; i < arr.Count; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static void inMang(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        #endregion
        // Main
        static void Main(string[] args)
        {
            int luaChon, n = 1;
            double[] a = {0}; // do phai kiem tra size cua mang
            do
            {
                Console.WriteLine("**********Menu*********");
                Console.WriteLine("1. Nhap n");
                Console.WriteLine("2. Nhap mang so thuc");
                Console.WriteLine("3. Tim so lon nhat trong mang");
                Console.WriteLine("4. Tim so nho nhat trong mang");
                Console.WriteLine("5. Tim so chan lon nhat trong mang");
                Console.WriteLine("6. Tim le nho lon nhat trong mang");
                Console.WriteLine("7. Tim cac so chinh phuong trong mang");
                Console.WriteLine("8. Tinh tong mang");
                Console.WriteLine("9. Tinh trung binh cong cac phan tu trong mang");
                Console.WriteLine("10. Tim cac phan tu lon hon trung binh cong");
                Console.WriteLine("11. Sap xep tang dan");
                Console.WriteLine("12. Sap xep giam dan");
                Console.WriteLine("13. Thoat");
                Console.Write("Nhap lua chon: ");
                luaChon = Convert.ToInt32(Console.ReadLine());
                switch(luaChon)
                {
                    case 1: 
                        n = nhapN();
                        break;
                    case 2: 
                        a = nhapMang(n);
                        break;
                    case 3:
                        Console.WriteLine("So lon nhat trong mang la = " + timMax(a));
                        break;
                    case 4:
                        Console.WriteLine("So nho nhat trong mang la = " + timMin(a));
                        break;

                    case 5:
                        Console.WriteLine("So chan lon nhat trong mang la = " + soChanMax(a));
                        break;
                    case 6:
                        Console.WriteLine("So le nho nhat trong mang la = " + soLeMin(a));
                        break;
                    case 7:
                        ArrayList soCP = soChinhPhuong(a);
                        Console.WriteLine("Cac so chinh phuong trong mang la: ");
                        inMang(soCP);
                        break;
                    case 8:
                        Console.WriteLine("Tinh tong mang = " + tong(a));
                        break;
                    case 9:
                        Console.WriteLine("Tinh trung binh cong cac phan tu trong mang = " + trungBinhCong(a));
                        break;
                    case 10:
                        ArrayList arrayList  = lonHonTBC(a);
                        Console.WriteLine("Cac lon hon trung binh cong la: ");
                        inMang(arrayList);
                        break;
                    case 11:
                        a = sapXepTD(a);
                        Console.WriteLine("Sap xep tang dan: ");
                        inMang(a);
                        break;
                    case 12:
                        a = sapXepGD(a);
                        Console.WriteLine("Sap xep giam dan: ");
                        inMang(a);
                        break;
                    case 13: Environment.Exit(0);
                        break;
                }
            }
            while (luaChon != 13);
            
            Console.ReadKey();
        }
    }
}
