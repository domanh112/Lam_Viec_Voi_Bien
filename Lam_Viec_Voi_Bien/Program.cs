// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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

            // Sử dụng String
            string str1 = @"abcdef,fedcba";
            string str2 = @"abcâôê";
            Case_String.Test_String(str1,str2);

            //// Sử Dụng DataTable-DataSet
            //// Tạo Bảng 
            //string nameTable = "TestHamKhoiTao";
            //string[] nameColumns = { "Id", "Name", "Email", "Salary" };
            //Type[] type = { typeof(int), typeof(string), typeof(string), typeof(decimal) };
            //DataTable TestHamKhoiTao = Case_Data.CreateDataTable(nameTable, nameColumns, type);

            //// Thêm dữ liệu 
            //TestHamKhoiTao.Rows.Add(101, "Cus1", "Manhdd@mic.vn1", 100000000);
            //TestHamKhoiTao.Rows.Add(102, "Cus2", "Manhdd@mic.vn2", 100000000);
            //TestHamKhoiTao.Rows.Add(103, "Cus3", "Manhdd@mic.vn3", 100000000);
            //TestHamKhoiTao.Rows.Add(104, "Cus4", "Manhdd@mic.vn4", 100000000);
            //TestHamKhoiTao.Rows.Add(105, "Cus5", "Manhdd@mic.vn5", 100000000);

            //// Hiển thị dữ liệu Có Filter
            //Console.WriteLine("Bảng sau khi Filter (Id<105) : ");
            //string filterData = @"Id<105";
            //Case_Data.SelectDataTable(TestHamKhoiTao,filterData);

            //int rowID = 102;
            //// Sửa dữ liệu theo rowID
            //Case_Data.EditRowById(TestHamKhoiTao, rowID);

            //// Xóa Dữ liệu theo rowID
            //Case_Data.DeleteRowById(TestHamKhoiTao, rowID);

            //// Import Dữ liệu từ Json sang DataTable
            //string path = @"C:\Users\Admin\source\repos\domanh112\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\employee.json";
            //Case_Data.ImportData(TestHamKhoiTao,path);

            //// Sử Dụng Json
            //string path = @"C:\Users\Admin\source\repos\domanh112\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\employee.json";
            //List<Employee> list = new List<Employee>();

            //Employee employee = new Employee();
            //employee.Id = 201;
            //employee.Name = "Manh";
            //employee.Email = "Manhdd@mic.vn";
            //employee.Salary = 100000;
            //list.Add(employee);

            //Employee employee2 = new Employee();
            //employee2.Id = 202;
            //employee2.Name = "Manh2";
            //employee2.Email = "Manhdd@mic.vn2";
            //employee2.Salary = 200000;
            //list.Add(employee2);
            //string resultJson = Case_Json.AddJson(list, path);

            //// Đưa dữ liệu vào dataTable để hiển thị theo dạng bảng
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(resultJson, (typeof(DataTable)));

            //DataRoTw[] rows = dt.Select();

            //// lấy ra 1 mảng chứa tên các cột trong dataTable để truyền vào bảng select
            //string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            //var table = new ConsoleTable(columnNames);

            //// lấy dữ liệu từng row trong mảng row để thêm vào bảng select
            //foreach (DataRow row in rows)
            //{
            //    table.AddRow(row.ItemArray);
            //}
            //table.Write(Format.MarkDown);
            //Console.Read();
        }
    }
}










