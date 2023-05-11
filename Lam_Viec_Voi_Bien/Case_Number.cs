using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Number
    {
        public static void Test_Number(int n1, int n2, double n3)
        {
            //làm tròn số
            Console.WriteLine("số c được là tròn thành : {0} \n", Math.Round(n3, 2));

            // Tính tổng
            int sumInt = n1 + n2;
            Console.WriteLine("tổng 2 số n1 và n2 : {0} \n", sumInt);

            // Tính tổng
            double tong = (double)n1 + (double)n2 + n3;
            Console.WriteLine("tổng 3 số n1 , n2 và n3 : {0} \n", Math.Round(tong, 2));

            // Phép nhân và Ép kiểu
            double nhan = (double)n1 * (double)n2 * n3;
            Console.WriteLine("tích 3 số n1 , n2 và n3 : {0} \n", Math.Round(nhan, 2));

            // Phép chia và Ép kiểu
            double chia = (double)n1 / n3;
            Console.WriteLine("chia số n1 cho n3 : {0} \n", Math.Round(chia, 2));
            
            // Phép chia lấy dư
            int chiaLayDu = n2%n1;
            Console.WriteLine("chia số n2 cho n1 dư : {0} \n", chiaLayDu);

            //So sánh 2 số
            if (n1 > n2) Console.WriteLine("n1 > n2");
            else if (n2 > n1) Console.WriteLine("n1 < n2");
            else Console.WriteLine("n1 = n2");

            //tìm số lớn nhất||nhỏ nhất 
            double[] arr = { n1, n2, n3 };

            double max = arr[0];
            double min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i]) max = arr[i];

                if (min > arr[i]) min = arr[i];
            }
            Console.WriteLine("mảng số : {0} , {1} , {2}\n", arr[0], arr[1], arr[2]);
            Console.WriteLine("số lớn nhất là : {0}\n", max);
            Console.WriteLine("số nhỏ nhất là : {0}\n", min);

            // Kiểm tra số chẵn lẻ
            Console.Write("Số chẵn là :");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0) Console.Write(arr[i]);
            }

            Console.WriteLine("\n");
            Console.Write("Số lẻ là :");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0) Console.Write(arr[i] + " ; ");
            }
            Console.WriteLine("\n");
        }
    }
}
