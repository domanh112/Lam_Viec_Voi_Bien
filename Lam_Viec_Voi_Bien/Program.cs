// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Text;

namespace Lam_Viec_Voi_Bien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Test_String();
            //Test_Number();
            //Test_Date_Time();
            Test_DataTable_DataSet_DataSet();
        }

        static void Test_String()
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

            // Thao tác với mảng String
            string[] lstStr = { str1, str2 };
            int chu_thuong, chu_hoa, chu_so, ky_tu_dac_biet, i;
            chu_hoa = chu_thuong = chu_so = ky_tu_dac_biet = i = 0;

            // đếm số chữ cái, số chữ số, số ký tự đặc biệt trong 2 chuỗi
            foreach (string a in lstStr)
            {
                while (i < a.Length)
                {
                    if ((a[i] >= 'A' && a[i] <= 'Z'))
                        chu_hoa++;

                    if (a[i] >= 'a' && a[i] <= 'z')
                        chu_thuong++;

                    else if (a[i] >= '0' && a[i] <= '9')
                        chu_so++;

                    else ky_tu_dac_biet++;
                    i++;
                }
                Console.WriteLine("chuỗi : {0}", a);
                Console.WriteLine("số chữ thường : {0}\n", chu_thuong);
                Console.WriteLine("số chữ hoa : {0}\n", chu_hoa);
                Console.WriteLine("số chữ số : {0}\n", chu_so);
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

            //So sánh 2 số
            if (a > b) Console.WriteLine("a>b");
            else if (b > a) Console.WriteLine("a<b");
            else Console.WriteLine("a=b");

            //tìm số lớn nhất||nhỏ nhất 
            double[] d = { a, b, c };

            double max = d[0];
            double min = d[0];
            for (int i = 0; i < d.Length; i++)
            {
                if (max < d[i]) max = d[i];
                if (min > d[i]) min = d[i];
            }
            Console.WriteLine("mảng số : {0}", d);
            Console.WriteLine("số lớn nhất là : {0}", max);
            Console.WriteLine("số nhỏ nhất là : {0}", min);
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

        static void Test_DataTable_DataSet_DataSet()
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


                // Thêm rows bằng tay
                //do
                //{
                //    Console.Write("nhập vào ID :");
                //    int idHand = Convert.ToInt32(Console.ReadLine());
                //    Console.Write("nhập vào Name :");
                //    string nameHand = Console.ReadLine();
                //    Console.Write("nhập vào Email :");
                //    string emailHand = Console.ReadLine();
                //    Console.Write("Nếu muốn dừng hãy nhập 'close' : ");
                //    isClose = Console.ReadLine();

                //    DataRow rowByHand = Student.NewRow();
                //    rowByHand["Id"] = idHand;
                //    rowByHand["Name"] = nameHand;
                //    rowByHand["Email"] = emailHand;
                //    Student.Rows.Add(rowByHand);
                //} while (isClose != "  ");


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

                // xóa theo rows ID
                foreach (DataRow dataRow in Student.Rows)
                {
                    if (dataRow[0].ToString() == "102")
                    {
                        Student.Rows.Remove(dataRow);
                        Student.AcceptChanges();

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
    }
}










