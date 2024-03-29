﻿// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using LanguageExt.ClassInstances;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using TaiLieuC;
using static TaiLieuC.CaseJson2;

namespace Lam_Viec_Voi_Bien
{
    class Program
    {
        static void Main(string[] args)
        {

            Example ex = new Example() { orders = new List<Order>() };
            List<Orderdetail> lstO_detail = new List<Orderdetail>() { };

            string path = @"C:\Users\manhdd\source\repos\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\employee.json";
            string pathCre = @"C:\Users\manhdd\source\repos\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\university.json";
            string pathRUD = @"C:\Users\manhdd\source\repos\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\Orders.json";

            int chon;
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Black;
            //Case_Data.Test_DataTable_DataSet_DataSet();

            do
            {
                Console.WriteLine("-------------Danh sách Case-------------");
                Console.WriteLine("1. String.");
                Console.WriteLine("2. Number.");
                Console.WriteLine("3. DateTime.");
                Console.WriteLine("4. DataTable");
                Console.WriteLine("5. Json.");
                Console.WriteLine("6. regEx.");
                Console.WriteLine("7. CreateFileJson.");
                Console.WriteLine("8. ReadFileJson.");
                Console.WriteLine("9. UpdateFileJson.");
                Console.WriteLine("10. DeleteItemFileJson.");
                Console.WriteLine("11. Close.");
                Console.WriteLine("nhập vào lựa chọn (1-11) :");
                chon = Convert.ToInt32(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        // Sử dụng String
                        string str1 = @"abcde AKHDASDf,fedcb a1233--*)";
                        string str2 = @"abc âôGDH ê+_+13123";
                        Case_String.Test_String(str1, str2);
                        break;

                    case 2:
                        //Sử dụng Number
                        int n1 = 56; int n2 = 65;
                        double n3 = 55.55532;
                        Case_Number.Test_Number(n1, n2, n3);
                        break;

                    case 3:
                        //Sử dụng Datetime
                        DateTime dt = DateTime.Now;
                        Case_Date.Test_Date_Time(dt);
                        break;

                    case 4:
                        // Sử Dụng DataTable-DataSet
                        // Tạo Bảng 
                        string nameTable = "TestHamKhoiTao";
                        string nameImportJson = "TestImportJson";
                        string[] nameColumns = { "Id", "Name", "Email", "Salary" };
                        Type[] type = { typeof(int), typeof(string), typeof(string), typeof(decimal) };
                        DataTable TestHamKhoiTao = Case_Data.CreateDataTable(nameTable, nameColumns, type);

                        DataTable TestImportJson = Case_Data.CreateDataTable(nameImportJson, nameColumns, type);

                        // Thêm dữ liệu 
                        TestHamKhoiTao.Rows.Add(101, "Cus1", "Manhdd@mic.vn1", 100000000);
                        TestHamKhoiTao.Rows.Add(102, "Cus2", "Manhdd@mic.vn2", 100000000);
                        TestHamKhoiTao.Rows.Add(103, "Cus3", "Manhdd@mic.vn3", 100000000);
                        TestHamKhoiTao.Rows.Add(104, "Cus4", "Manhdd@mic.vn4", 100000000);
                        TestHamKhoiTao.Rows.Add(105, "Cus5", "Manhdd@mic.vn5", 100000000);

                        // Hiển thị dữ liệu Có Filter
                        Console.WriteLine("Bảng sau khi Filter (Id<105) : ");
                        string filterData = @"Id<105";

                        Case_Data.SelectDataTable(TestHamKhoiTao, filterData, nameTable);

                        int rowID = 102;
                        // Sửa dữ liệu theo rowID
                        Case_Data.EditRowById(TestHamKhoiTao, rowID, nameTable);

                        // Xóa Dữ liệu theo rowID
                        Case_Data.DeleteRowById(TestHamKhoiTao, rowID, nameTable);

                        // Import Dữ liệu từ Json sang DataTable
                        DataTable dataTable = Case_Data.ImportData(TestImportJson, path, nameImportJson);

                        // Count Dữ liệu DataTable
                        Case_Data.CountData(dataTable, nameImportJson);

                        //Order by Dữ liệu DataTable
                        Case_Data.SortData(dataTable, nameImportJson);

                        // Copy dữ liệu 
                        Case_Data.CopData(dataTable);
                        break;

                    case 5:
                        // Sử Dụng Json
                        string nameJson = "Employee";
                        string[] addNew = { "301", "Manh", "Manhdd@mic.vn", "2000" };
                        List<Employee> list = new List<Employee>();
                        List<Address> listAdd = new List<Address>();
                        Address addr = new Address();
                        addr.Num = "so 87";
                        addr.Street = "Hoa Bang";
                        listAdd.Add(addr);

                        Employee employee = new Employee();
                        employee.Id = 201;
                        employee.Name = "Manh1";
                        employee.Email = "Manhdd@mic.vn";
                        employee.Salary = 100000;
                        //employee.Address = JsonConvert.SerializeObject(addr);
                        list.Add(employee);

                        Employee employee2 = new Employee();
                        employee2.Id = 202;
                        employee2.Name = "Manh";
                        employee2.Email = "Manhdd@mic.vn2";
                        employee2.Salary = 200000;
                        //employee2.Address = JsonConvert.SerializeObject(addr);
                        list.Add(employee2);

                        Employee employee3 = new Employee();
                        employee3.Id = 203;
                        employee3.Name = "Manh";
                        employee3.Email = "Manhdd@mic.vn3";
                        employee3.Salary = 300000;
                        //employee3.Address = JsonConvert.SerializeObject(addr);
                        list.Add(employee3);

                        //// Thêm list dữ liệu vào file json
                        //Console.WriteLine("Thêm Dữ vào Json :");
                        //Case_Json.AddnewJson(path, addNew);
                        //string resultAddJson = Case_Json.AddJson(list, path, nameJson);

                        //// Hiển thị file Json dạng bảng
                        //Console.WriteLine("Hiển thị file Json dạng bảng :");
                        ////Case_Json.SelectNewDataJson(path);
                        //Case_Json.SelectDataJson(resultAddJson);

                        //// Lọc dữ liệu Json
                        //Console.WriteLine("Lọc dữ liệu Json :");
                        //Case_Json.FilterDataJson(path);

                        //// Xóa dữ liệu Json
                        //Console.WriteLine("Xóa dữ liệu Json :");
                        //Case_Json.DeleteDataJson(path, nameJson);

                        //// Sửa dữ liệu Json
                        //Console.WriteLine("Sửa dữ liệu Json :");
                        //Case_Json.EditDataJson(path, nameJson);

                        break;

                    case 6:
                        string mail1 = @"Domanh112113114@gmail.com";
                        string mail2 = @"Domanh112@gmail.com";
                        string mail3 = @"Domanh112113@gmail.com";
                        string mail5 = @"manh5@gmail.com";
                        string mail4 = @"Manhcomdd@mic.vn";
                        string text = mail1 + " " + mail2;

                        string[] str_Text_Regex = { mail1, mail2, mail3, mail4, mail5, text };
                        Case_regEx.Test_Regex(str_Text_Regex);
                        break;

                    case 7:
                        ClassUniversities university1 = new ClassUniversities();

                        university1.universities = new Universities();
                        university1.universities.university = "South Carolina StateUniversity";

                        List<Student> listStudent = new List<Student>();
                        Student student1 = new Student
                        {
                            name = "StephenCousins"
                        };
                        Student student2 = new Student
                        {
                            name = "Austin A. Newton"
                        };
                        Student student3 = new Student
                        {
                            name = "Adam Wilhite"
                        };
                        Student student4 = new Student
                        {
                            name = "Enis Kurtay YILMAZ"
                        };

                        listStudent.Add(student1);
                        listStudent.Add(student2);
                        listStudent.Add(student3);
                        listStudent.Add(student4);

                        university1.universities.students = listStudent;
                        Jsonnnnnnnnnnn.CreateFileJson(pathCre, university1);
                       
                        break;

                    case 8:
                        Jsonnnnnnnnnnn.ReadFileJson(pathRUD,ex);
                        break;
                        
                    case 9:
                        string No = "1";
                        Jsonnnnnnnnnnn.UpdateFileJson(pathRUD,ex, No);
                        break;
                           
                    case 10:
                        Jsonnnnnnnnnnn.DeleteFileJson(pathRUD,ex);
                        break;


                    default:
                        Console.WriteLine("hihi");
                        break;
                }
            } while (chon < 10);
        }
    }
}










