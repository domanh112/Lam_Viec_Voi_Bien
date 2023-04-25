using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Data
    {
        public static void Test_DataTable_DataSet_DataSet()
        {
            try
            {
                string isClose = null;

                // khởi tạo DataTable Customer
                DataTable Customer = new DataTable("Customer");

                DataColumn IdCus = new DataColumn("Id");
                IdCus.DataType = typeof(int);
                IdCus.Unique = true;
                IdCus.AllowDBNull = false;
                IdCus.Caption = "Customer ID";
                Customer.Columns.Add(IdCus);

                DataColumn NameCus = new DataColumn("Name");
                NameCus.DataType = typeof(string);
                NameCus.MaxLength = 50;
                NameCus.AllowDBNull = false;
                Customer.Columns.Add(NameCus);

                DataColumn EmailCus = new DataColumn("Email");
                EmailCus.DataType = typeof(string);
                Customer.Columns.Add(EmailCus);

                DataColumn Salary = new DataColumn("Salary");
                Salary.DataType = typeof(Int32);
                Customer.Columns.Add(Salary);

                Customer.PrimaryKey = new DataColumn[] { IdCus };

                // Thêm rows
                //Cách 1:
                DataRow rowCus = Customer.NewRow();
                rowCus["Id"] = 101;
                rowCus["Name"] = "Manh";
                rowCus["Email"] = "Manhdd@mic.vn1";
                rowCus["Salary"] = 100000000;
                Customer.Rows.Add(rowCus);

                //Cách 2:
                Customer.Rows.Add(102, "Cus2", "Manhdd@mic.vn2", 100000000);
                Customer.Rows.Add(103, "Cus3", "Manhdd@mic.vn3", 100000000);
                Customer.Rows.Add(104, "Cus4", "Manhdd@mic.vn4", 100000000);
                Customer.Rows.Add(105, "Cus5", "Manhdd@mic.vn5", 100000000);


                // khởi tạo DataTable Student
                DataTable Student = new DataTable("Student");

                DataColumn Id = new DataColumn("ID");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AllowDBNull = false;
                Id.Caption = "Student ID";
                Student.Columns.Add(Id);

                DataColumn Name = new DataColumn("Name");
                Name.DataType = typeof(string);
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                Student.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                Email.DataType = typeof(string);
                Student.Columns.Add(Email);

                DataColumn SalaryStud = new DataColumn("Salary");
                SalaryStud.DataType = typeof(Int32);
                Student.Columns.Add(SalaryStud);

                Student.PrimaryKey = new DataColumn[] { Id };


                // khởi tạo DataTable DtCop
                DataTable DtCop = new DataTable("DtCop");

                DataColumn IdCop = new DataColumn("ID");
                IdCop.DataType = typeof(int);
                IdCop.Unique = true;
                IdCop.AllowDBNull = false;
                IdCop.Caption = " ID";
                DtCop.Columns.Add(IdCop);

                DataColumn NameCop = new DataColumn("Name");
                NameCop.DataType = typeof(string);
                NameCop.MaxLength = 50;
                NameCop.AllowDBNull = false;
                DtCop.Columns.Add(NameCop);

                DataColumn EmailCop = new DataColumn("Email");
                EmailCop.DataType = typeof(string);
                DtCop.Columns.Add(EmailCop);

                DataColumn SalaryCop = new DataColumn("Salary");
                SalaryCop.DataType = typeof(Int32);
                DtCop.Columns.Add(SalaryCop);

                DtCop.PrimaryKey = new DataColumn[] { IdCop };


                // Thêm rows
                DataRow row = Student.NewRow();
                row["Id"] = 101;
                row["Name"] = "Manhdd";
                row["Email"] = "Manhdd@mic.vn1";
                row["Salary"] = 1000000000;
                Student.Rows.Add(row);

                Student.Rows.Add(102, "Manhdd", "Manhdd@mic.vn2", 1000000000);
                Student.Rows.Add(103, "Manhdd", "Manhdd@mic.vn3", 1000000000);
                Student.Rows.Add(104, "Student4", "Manhdd@mic.vn4", 2000000000);
                Student.Rows.Add(105, "Student5", "Manhdd@mic.vn5", 2000000000);
                Student.Rows.Add(106, "Manhdd", "Manhdd@mic.vn6", 1000000000);

                // sửa rows theo ID
                foreach (DataRow dataRow in Student.Rows)
                {
                    if (dataRow[0].ToString() == "101")
                    {
                        dataRow[1] = "Manhme";
                        break;
                    }
                }


                // Cop dữ liệu từ bảng này sang bảng khác
                Console.WriteLine("datatable đã chỉnh sửa và lấy Dữ liệu :");
                foreach (DataRow dataRow in Student.Rows)
                {
                    Console.WriteLine(dataRow["ID"] + ",  " + dataRow["Name"] + ",  " + dataRow["Email"] + ",  " + dataRow["Salary"]);
                    DtCop.ImportRow(dataRow);
                }

                Console.WriteLine("****************************************************************\n");

                // Filter dữ liệu
                Console.WriteLine(" Filter dữ liệu :");
                foreach (DataRow dataRow in Student.Rows)
                {
                    if (dataRow["Name"].ToString().Contains("Manh"))
                    {
                        Console.WriteLine(dataRow["ID"] + ",  " + dataRow["Name"] + ",  " + dataRow["Email"] + ",  " + dataRow["Salary"]);
                    }
                }
                Console.WriteLine("****************************************************************\n");

                // Count dữ liệu (Hàm tính toán)
                int sum = Convert.ToInt32(Student.Compute("SUM(Salary)", "Name = 'Manhdd'"));
                Console.WriteLine("Tổng Salary :" + sum);
                Console.WriteLine("****************************************************************\n");

                // order by dữ liệu 
                Console.WriteLine("Order by dữ liệu  : ");
                var sortedRows = Student.AsEnumerable().OrderBy(r => r.Field<Int32>("Salary"));
                DataTable sortedDt = sortedRows.CopyToDataTable();
                foreach (DataRow dataRow in sortedDt.Rows)
                {
                    Console.WriteLine(dataRow["ID"] + ",  " + dataRow["Name"] + ",  " + dataRow["Email"] + ",  " + dataRow["Salary"]);
                }

                Console.WriteLine("****************************************************************\n");

                // hiển thị giữ liệu trực tiếp qua datatable
                Console.WriteLine("datatable Đã Copy Dữ liệu :");
                foreach (DataRow dataRow in DtCop.Rows)
                {
                    Console.WriteLine(dataRow["ID"] + ",  " + dataRow["Name"] + ",  " + dataRow["Email"] + ",  " + dataRow["Salary"]);
                }
                Console.WriteLine("****************************************************************\n");

                // thêm các dataTable vào DataSet
                DataSet ds = new DataSet();
                //ds.Tables.Add(Customer);
                ds.Tables.Add(Student);
                ds.Tables.Add(DtCop);

                Console.WriteLine("********* Hiển thị dữ liệu từng Table trong DataSet *********\n");
                // hiển thị dữ liệu từng Table trong DataSet
                foreach (DataTable dt in ds.Tables)
                {
                    Console.WriteLine(dt.TableName == "Student" ? "dataTable Student" : "dataTable DtCop");
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        Console.WriteLine(dataRow["Id"] + ",  " + dataRow["Name"] + ",  " + dataRow["Email"] + ",  " + dataRow["Salary"]);

                    }
                    Console.WriteLine("****************************************************************\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Co loi!!!\n" + ex);
            }

        }

        public static DataTable CreateDataTable(string nameTable, string[] nameColumns)
        {
            DataTable dataTable = new DataTable(@nameTable);

            foreach (string namCol in nameColumns)
            {
                dataTable.Columns.Add(namCol);
            }
            dataTable.Rows.Add(102, "Cus2", "Manhdd@mic.vn2", 100000000);
            dataTable.Rows.Add(103, "Cus3", "Manhdd@mic.vn3", 100000000);
            dataTable.Rows.Add(104, "Cus4", "Manhdd@mic.vn4", 100000000);
            dataTable.Rows.Add(105, "Cus5", "Manhdd@mic.vn5", 100000000);

            DataRow[] rows = dataTable.Select();

            //string[] columnNames = dataTable.Columns.Cast<DataColumn>()
            //                   .Select(x => x.ColumnName)
            //                   .ToArray();
            //string[] columnNames = new string[nameColumns.Length];
            //// Hiển thị dữ liệu đã được lọc ra
            //for (int i = 0; i < columnNames.Length; i++)
            //{
            //    foreach (string nameCol in nameColumns)
            //    {
            //        string[] changName = nameCol.Split(',');

            //        if (columnNames[i] != changName[0])
            //        {
            //            columnNames[i] = changName[0];
            //            break;
            //        }
            //    }
            //}
            var table = new ConsoleTable(nameColumns);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            Console.Read();

            return dataTable;
        }

        public static void DeleteDataRowById(DataTable dataTable, int rowID)
        {
            // xóa theo rows ID
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow[0].ToString() == rowID.ToString())
                {
                    dataTable.Rows.Remove(dataRow);
                    dataTable.AcceptChanges();
                    Console.WriteLine("success!!!");
                    DataRow[] rows = dataTable.Select();

                    string[] columnNames = dataTable.Columns.Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToArray();

                    // Hiển thị dữ liệu đã được lọc ra
                    var table = new ConsoleTable(columnNames);
                    foreach (DataRow row in rows)
                    {
                        table.AddRow(row.ItemArray);
                    }
                    table.Write(Format.MarkDown);
                    Console.Read();

                    break;
                }
            }
        }


    }
}
