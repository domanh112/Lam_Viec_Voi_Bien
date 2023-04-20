// See https://aka.ms/new-console-template for more information
using System.Text;

namespace VietJackCsharp
{
    class TestCsharp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Test_String();
            //Test_Number();
            Test_Date_Time();
        }

        public static void Test_String()
        {

            Console.Write("nhập vào chuỗi 1 : ");
            string str1 = Console.ReadLine();

            // độ dài
            Console.WriteLine("số kí tự :" + str1.Length);

            int l = 0;
            // tách từng kí tự của chuỗi 
            Console.WriteLine("tách từng kí tự của chuỗi : ");
            while (l <= str1.Length - 1)
            {
                Console.Write("{0} ", str1[l]);
                l++;
            }
            Console.WriteLine("\n");

            // in các ký tự riêng lẻ của chuỗi theo chiều đảo ngược
            l = str1.Length - 1;

            Console.WriteLine("in các ký tự riêng lẻ của chuỗi theo chiều đảo ngược : ");
            while (l >= 0)
            {
                Console.Write("{0} ", str1[l]);
                l--;
            }
            Console.WriteLine("\n");

            // đếm số chữ có trong một chuỗi không bao gồm khoảng trắng
            string strNoSpace = str1.Replace(" ", "");
            Console.WriteLine("Số chữ trong chuỗi :" + strNoSpace.Length);

            Console.Write("nhập vào chuỗi 2 : ");
            string str2 = Console.ReadLine();

            string[] lstStr = { str1, str2 };
            int chu_cai, chu_so, ky_tu_dac_biet, i;
            chu_cai = chu_so = ky_tu_dac_biet = i = 0;

            // đếm số chữ cái, số chữ số, số ký tự đặc biệt trong 2 chuỗi
            foreach (string a in lstStr)
            {
                while (i < a.Length)
                {
                    if ((a[i] >= 'a' && a[i] <= 'z') || (a[i] >= 'A' && a[i] <= 'Z'))
                        chu_cai++;

                    else if (a[i] >= '0' && a[i] <= '9')
                        chu_so++;

                    else ky_tu_dac_biet++;
                    i++;
                }
                Console.WriteLine("chuỗi : {0}", a);
                Console.WriteLine("số chữ cái : {0}\n", chu_cai);
                Console.WriteLine("số chữ sô : {0}\n", chu_so);
                Console.WriteLine("số kí tự đặc biệt : {0}\n", ky_tu_dac_biet);
            }

            // Cộng chuỗi
            Console.WriteLine("2 chuỗi cộng lại : {0}\n", (str1 + str2));
            // Hoặc 
            Console.WriteLine("2 chuỗi cộng lại : " + String.Concat(str1, str2));

            // so sánh độ dài 2 chuỗi
            if (str1.Length == str2.Length)
            {
                Console.WriteLine(" độ dài = nhau \n");

                //tìm kiếm kí tự trùng giữa 2 chuỗi
                if (String.Compare(str1, str2) == 0)
                    Console.WriteLine("trùng lặp");
                else Console.WriteLine("ko trùng lặp");
            }
            else Console.WriteLine(" độ dài != nhau");

            //Sao chép chuỗi
            string[] strCop = new string[str1.Length];
            i = 0;
            while (i < str1.Length)
            {
                string a = str1[i].ToString();
                strCop[i] = a;
                i++;
            }
            Console.Write("\nIn chuoi ban dau: {0}\n", str1);
            Console.WriteLine(" chuỗi đã cop : {0}\n ", string.Join("", strCop));

            // cắt chuỗi
            Console.WriteLine("Chuỗi đã cắt : " + str1.Substring(0, str1.Length - 2));

            // kiểm tra chuỗi 2 có là chuỗi con của chuỗi 1 ko
            if (str1.Contains(str2))
                Console.WriteLine("{0} là chuỗi con " + "của chuỗi {1}", str2, str1);
            else
                Console.WriteLine("{0} ko là chuỗi con " + "của chuỗi {1}", str2, str1);

            //
        }

        static void Test_Number()
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

        }

        static void Test_Date_Time()
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
                    if (day >31) Console.WriteLine("nhập lại ngày theo định dạng 'dd' và ko lớn hơn 31");

                    Console.Write("nhập vào Tháng(MM):");
                    month = Convert.ToInt32(Console.ReadLine());
                    if(month>12) Console.WriteLine("nhập lại tháng theo định dạng 'MM' và ko lớn hơn 12");

                    Console.Write("nhập vào năm(yyyy):");
                    year = Convert.ToInt32(Console.ReadLine());
                    if (year>9999) Console.WriteLine("nhập lại năm theo định dạng 'yyyy' và ko lớn hơn 9999");

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










