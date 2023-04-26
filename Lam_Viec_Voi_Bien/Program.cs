// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Text;
using TaiLieuC;

namespace Lam_Viec_Voi_Bien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Case_Data.Test_DataTable_DataSet_DataSet();

            ////Sử dụng Datetime
            //Case_Date.Test_Date_Time();

            ////Sử dụng Number
            //Case_Number.Test_Number();

            //// Sử dụng String
            //Case_String.Test_String();

            //// Sử Dụng DataTable-DataSet
            //// Tạo Bảng 
            //string nameTable = "TestHamKhoiTao";
            //string[] nameColumns = { "Id", "Name", "Email", "Salary" };
            //Type[] type = { typeof(int), typeof(string), typeof(string), typeof(decimal) };
            //DataTable TestHamKhoiTao = Case_Data.CreateDataTable(nameTable, nameColumns,type);

            //// Thêm dữ liệu 
            //TestHamKhoiTao.Rows.Add(101, "Cus1", "Manhdd@mic.vn1", 100000000);
            //TestHamKhoiTao.Rows.Add(102, "Cus2", "Manhdd@mic.vn2", 100000000);
            //TestHamKhoiTao.Rows.Add(103, "Cus3", "Manhdd@mic.vn3", 100000000);
            //TestHamKhoiTao.Rows.Add(104, "Cus4", "Manhdd@mic.vn4", 100000000);
            //TestHamKhoiTao.Rows.Add(105, "Cus5", "Manhdd@mic.vn5", 100000000);

            //// Hiển thị dữ liệu Có Filter
            //Console.WriteLine("Bảng sau khi Filter (Id<105) : ");
            //Case_Data.SelectDataTable(TestHamKhoiTao);

            //int rowID = 102;
            //// Sửa dữ liệu theo rowID
            //Case_Data.EditRowById(TestHamKhoiTao, rowID);

            //// Xóa Dữ liệu theo rowID
            //Case_Data.DeleteRowById(TestHamKhoiTao, rowID);


            // Sử Dụng Json
            string path = @"C:\Users\ADMIN\source\repos\domanh112\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\employee.json";
            Employee employee = new Employee();
            employee.Id = 201;
            employee.Name = "Manh";
            employee.Email = "Manhdd@mic.vn";
            employee.Salary = 100000;

            Case_Json.AddJson(employee, path);
        }
    }
}










