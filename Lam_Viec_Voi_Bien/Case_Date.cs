using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Date
    {
        public static void Test_Date_Time(DateTime dt)
        {
            // So sánh với ngày đầu tháng
            DateTime ngayDauThang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            TimeSpan timeSpan = dt - ngayDauThang;
            int soNgayTuDauThang = timeSpan.Days + 1;
            Console.WriteLine("số ngày từ đầu tháng đến thời điểm dt : {0}", soNgayTuDauThang);

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

        }
    }
}
