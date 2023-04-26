using ConsoleTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // Tạo bảng mới
        public static DataTable CreateDataTable(string nameTable, string[] nameColumns,Type[] types)
        {
            DataTable dataTable = new DataTable(@nameTable);
            // lấy tên cột và kiểu dữ liệu tương ứng đã khai báo để thêm vào dataTable
            for (int i = 0; i < nameColumns.Length;)
            {
                for (int j = i; j < types.Length;)
                {
                    string namCol = nameColumns[i].ToString();
                    Type type = types[j];
                    dataTable.Columns.Add(namCol, type);
                    break;
                }
                i++;
            }    
            return dataTable;
        }

        // Hiển thị dữ liệu 
        public static void SelectDataTable(DataTable dataTable)
        {
            string filterData = @"Id<105";
            // khai báo 1 mảng row để nhận những row thỏa mãn Filter
            DataRow[] rows = dataTable.Select(filterData);

            // lấy ra 1 mảng chứa tên các cột trong dataTable để truyền vào bảng select
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            var table = new ConsoleTable(columnNames);

            // lấy dữ liệu từng row trong mảng row để thêm vào bảng select
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            Console.Read();
        }

        // xóa theo rows ID
        public static void DeleteRowById(DataTable dataTable, int rowID)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["Id"].ToString() == rowID.ToString())
                {
                    // Xóa row chứa ID khỏi bảng
                    dataTable.Rows.Remove(dataRow);
                    dataTable.AcceptChanges();
                    Console.WriteLine("Xóa thành công !!!");

                    // Hiển thị dữ liệu sau khi đã xóa
                    SelectDataTable(dataTable);
                    break;
                }
            }
        }

        // Sửa dữ liệu theo rowID
        public static void EditRowById(DataTable dataTable, int rowID)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // sửa dữ liệu row theo ID và tên cột muốn sửa
                if (dataRow["Id"].ToString() == rowID.ToString())
                {
                    dataRow["Name"] = "Manhdd";
                    dataTable.AcceptChanges();
                    Console.WriteLine("Sửa thành công !!!");

                    // Hiển thị dữ liệu sau khi đã sửa
                    SelectDataTable(dataTable);
                    break;
                }
            }
        }


        // Import dữ liệu vào bảng
        public static void ImportData(DataTable dataTable)
        {

        }

    }
}
