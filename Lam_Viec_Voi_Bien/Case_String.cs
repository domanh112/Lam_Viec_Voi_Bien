using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_String
    {
        public static void Test_String(string str1,string str2)
        {
            // độ dài
            Console.WriteLine("số kí tự chuỗi 1 :" + str1.Length);
            Console.WriteLine("số kí tự chuỗi 2 :" + str2.Length);

            // cắt chuỗi trc dấu phẩy
            Console.WriteLine("căt chuỗi : {0}" ,str1.Split(','));

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

            // cắt chuỗi
            Console.WriteLine("Chuỗi đã cắt : " + str1.Substring(0, str1.Length - 2));

            // kiểm tra chuỗi 2 có là chuỗi con của chuỗi 1 ko
            if (str1.Contains(str2))
                Console.WriteLine("{0} là chuỗi con " + "của chuỗi {1}", str2, str1);
            else
                Console.WriteLine("{0} ko là chuỗi con " + "của chuỗi {1}", str2, str1);

            //thay thế chuỗi con vào 1 khoảng chuỗi cha
            if (str1.Contains("abc"))
            {
                string strThay = str1.Replace("abc", str2);

                // thay thế 2 kí tự cuối 
                string strChon = str1.Substring(str1.Length - 2, 2);
                string strThay2 = str1.Replace(strChon, str2);
                Console.WriteLine("chuỗi str1 sau khi đc thay thế là : {0} ", strThay);
                Console.WriteLine("chuỗi str1 sau khi đc thay thế là : {0} ", strThay2);
            }

            // Thao tác với mảng String
            string[] lstStr = { str1, str2 };
            int chu_thuong, chu_hoa, chu_so, ky_tu_dac_biet, i;
            chu_hoa = chu_thuong = chu_so = ky_tu_dac_biet = i = 0;

            // đếm số chữ cái, số chữ số, số ký tự đặc biệt trong 2 chuỗi
            foreach (string a in lstStr)
            {
                string b = RemoveSign4VietnameseString(a);
                while (i < b.Length)
                {
                    if ((b[i] >= 'A' && b[i] <= 'Z'))
                        chu_hoa++;

                    if (b[i] >= 'a' && b[i] <= 'z')
                        chu_thuong++;

                    else if (b[i] >= '0' && b[i] <= '9')
                        chu_so++;

                    else ky_tu_dac_biet++;
                    i++;
                }
                Console.WriteLine("chuỗi : {0}", a);
                Console.WriteLine("số chữ thường : {0}\n", chu_thuong);
                Console.WriteLine("số chữ hoa : {0}\n", chu_hoa);
                Console.WriteLine("số chữ số : {0}\n", chu_so);
                Console.WriteLine("số kí tự đặc biệt : {0}\n", ky_tu_dac_biet);
                i = 0;
            }

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

        }

        private static readonly string[] VietnameseSigns = new string[]
  {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
  };

        // Hàm chuyển đổi tiếng việt có dấu sang ko dấu
        public static string RemoveSign4VietnameseString(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }
    }
}
