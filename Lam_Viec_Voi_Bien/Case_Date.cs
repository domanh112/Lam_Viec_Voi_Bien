using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Date
    {
        public static void Test_Date_Time()
        {
            //DateTime dt = DateTime.Now;
            //Console.WriteLine(dt);
            bool inputFinish = false;
            int day, month, year;
            DateTime dt;
            do
            {
                try
                {
                    Console.Write("nhập vào ngày(dd):");
                    day = Convert.ToInt32(Console.ReadLine());
                    if (day > 31) Console.WriteLine("nhập lại ngày theo định dạng 'dd' và ko lớn hơn 31");

                    Console.Write("nhập vào Tháng(MM):");
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month > 12) Console.WriteLine("nhập lại tháng theo định dạng 'MM' và ko lớn hơn 12");

                    Console.Write("nhập vào năm(yyyy):");
                    year = Convert.ToInt32(Console.ReadLine());
                    if (year > 9999) Console.WriteLine("nhập lại năm theo định dạng 'yyyy' và ko lớn hơn 9999");

                    dt = new DateTime(year, month, day);

                    //lấy ra thứ trong dt
                    Console.WriteLine("thứ tại thời điểm dt : {0} ", dt.DayOfWeek);

                    // thay đổi format DateTime
                    Console.WriteLine("MM/dd/yyyy : {0}\n", dt.ToString("MM/dd/yyyy"));
                    Console.WriteLine("dd/MM/yyyy HH/mm/ss : {0}\n", dt.ToString("dd/MM/yyyy HH/mm/ss"));
                    Console.WriteLine("dd : {0}\n", dt.ToString("dd"));

                    //tăng giảm Ngày||Tháng||Năm
                    DateTime up = dt.AddDays(1).AddMonths(1).AddYears(1);
                    Console.WriteLine("Tăng 1 ngày,tháng,năm : {0} \n", up);

                    //tăng giảm Ngày||Tháng||Năm
                    DateTime down = dt.AddHours(-1).AddMinutes(-1).AddSeconds(-1);
                    Console.WriteLine("Giảm 1 giờ,phút,giây : {0} \n", down);

                    inputFinish = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (inputFinish != true);
        }
    }
}
