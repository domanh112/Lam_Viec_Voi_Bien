// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_regEx
    {
        public static void Test_Regex(string[] text_Regex)
        {
            // check dkien chuỗi 1 có bao gồm chuỗi 2 ko 
            string Hau_To = "@gmail.com";

            // check dkien chuỗi 1 trước hậu tố có kết thúc bằng 2 hoặc 3 số bất kì ko
            string pattern = @"[0-9]{2,3}" + Hau_To;

            // check dkien chuỗi 1 trước hậu tố có kết thúc bằng 6 số bất kì ko (phủ định chỉ cần thay d=>D)
            string pattern2 = @"\d{6}" + Hau_To;

            // check dkien cuối chuỗi 1 có bao gồm "com" ko
            string pattern3 = @"com$";

            // check dkien đầu chuỗi 1 có bao gồm "manh" ko phân biệt hoa thường
            string pattern4 = @"^[M|m]anh";

            //check dkien khoảng trắng trong chuỗi (phủ định chỉ cần thay s=>S)
            string pattern5 = @"^\S";

            string[] arrStr = { Hau_To, pattern, pattern2, pattern3, pattern4, pattern5 };

            for (int i = 0; i < arrStr.Length; i++)
            {
                Regex regex = new Regex(arrStr[i]);
                Console.WriteLine("\n\nnhững string thỏa mãn đkiện ({0}) :", arrStr[i]);
                foreach (string mail in text_Regex)
                {
                    bool b_tim = regex.IsMatch(mail);
                    if (b_tim)
                    {
                        Console.WriteLine(mail);
                    }
                }
            }
        }
    }
}