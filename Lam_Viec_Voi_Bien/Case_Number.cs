using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Number
    {
        public static void Test_Number()
        {
            int a, b;
            a = b = 0;
            double c = 0;
            bool inputFinish = false;
            do
            {
                try
                {
                    Console.Write("nhập vào tham số a : ");
                    a = Convert.ToInt32(Console.ReadLine());

                    Console.Write("nhập vào tham số b : ");
                    b = Convert.ToInt32(Console.ReadLine());

                    Console.Write("nhập vào tham số c (theo định dạng 00,00) : ");
                    c = Convert.ToDouble(Console.ReadLine());

                    inputFinish = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (inputFinish != true);

            //làm tròn số
            Console.WriteLine("số c được là tròn thành : {0} \n", Math.Round(c, 2));

            // Tính tổng
            int sumInt = a + b;
            Console.WriteLine("tổng 2 số a và b : {0} \n", sumInt);

            // Ép kiểu
            int sumDouble = a + b + (int)c;
            Console.WriteLine("tổng 3 số a , b và c : {0} \n", sumDouble);

            //So sánh 2 số
            if (a > b) Console.WriteLine("a>b");
            else if (b > a) Console.WriteLine("a<b");
            else Console.WriteLine("a=b");

            //tìm số lớn nhất||nhỏ nhất 
            double[] d = { a, b, c };

            double max = d[0];
            double min = d[0];
            for (int i = 0; i < d.Length; i++)
            {
                if (max < d[i]) max = d[i];
                if (min > d[i]) min = d[i];
            }
            Console.WriteLine("mảng số : {0}", d);
            Console.WriteLine("số lớn nhất là : {0}", max);
            Console.WriteLine("số nhỏ nhất là : {0}", min);
        }
    }
}
