using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Program
    {
        // ref: chuyen bien kieu tham chieu
        static void swap<T>(ref T left,ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
        // Phan hoach mang lam 2
        static int partition(int[] a, int L, int R)
        {
            int mid = (L + R) / 2;
            int pivot = a[mid];
            swap(ref a[mid],ref a[R]);
            int store = L;
            for (int i = L; i < R; i++)
                if (a[i] < pivot)
                {
                    swap(ref a[store],ref a[i]);
                    store++;
                }
            swap(ref a[store],ref a[R]);
            return store;
        }
        // Sap xep nhanh: n phan tu tu vi tri L den vi tri R
        static void quick_sort(ref int[] a, int L, int R)
        {
            if (L < R)
            {
                int M = partition(a, L, R);
                quick_sort(ref a, L, M - 1);
                quick_sort(ref a, M + 1, R);
            }
        }
        // Xoa trung
        static void remove_duplicate(ref int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
                if (a[i] == a[i + 1])
                {
                    List<int> list = new List<int>(a);
                    list.RemoveAt(i);
                    a = list.ToArray();
                }
        }
        static void Main(string[] args)
        {           
            Console.Write("Nhap n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            //int[] a = {1, 5, 9, 1, 6, 5};
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
                a[i] = r.Next(0, 100);
            //Array.Sort(a);
            quick_sort(ref a, 0, a.Length - 1);
            //a = a.Distinct().ToArray();
            remove_duplicate(ref a);
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.ReadKey();
        }
    }
}
