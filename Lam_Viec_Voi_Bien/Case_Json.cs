using ConsoleTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiLieuC;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Json
    {
        public static string AddJson(List<Employee> lstEmp, string path, string nameJson)
        {
            string JSONresult = JsonConvert.SerializeObject(lstEmp, Formatting.Indented);
            //Employee deseri   alizedProduct = JsonConvert.DeserializeObject<Employee>(JSONresult);

            if (File.Exists(path))
            {
                File.Delete(path);
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("{\n\"" + nameJson + "\" :");
                    tw.WriteLine(JSONresult.ToString());
                    tw.WriteLine("}");
                    tw.Close();
                }
            }
            else if (!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("{\n\"" + nameJson + "\" :");
                    tw.WriteLine(JSONresult.ToString());
                    tw.WriteLine("}");
                    tw.Close();
                }
            }
            FileStream fs = new FileStream(@"C:\Users\Admin\source\repos\domanh112\Lam_Viec_Voi_Bien\Lam_Viec_Voi_Bien\bin\Debug\net7.0\employee.json", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String readJson = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu thoy, ReadToEnd là đọc hết
            Console.WriteLine(readJson);
            rd.Close();

            Console.WriteLine("Insert Success !!! \n");
            return JSONresult;
        }

        public static void SelectDataJson(string resultJson)
        {
            // Đưa dữ liệu vào dataTable để hiển thị theo dạng bảng
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(resultJson, (typeof(DataTable)));

            DataRow[] rows = dt.Select();

            // lấy ra 1 mảng chứa tên các cột trong dataTable để truyền vào bảng select
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            var table = new ConsoleTable(columnNames);

            // lấy dữ liệu từng row trong mảng row để thêm vào bảng select
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
        }

        public static void FilterDataJson(string path)
        {
            // Đưa dữ liệu file Json vào JObject 
            var tmpResult = JObject.Parse(File.ReadAllText(path));
            // 
            var resultObject = tmpResult["Employee"].Values<JObject>()
                        .Where(n => n["Id"].Value<string>() == "201");

            string json = JsonConvert.SerializeObject(resultObject, Formatting.Indented);
            SelectDataJson(json);
        }

        public static void DeleteDataJson(string path)
        {
            var tmpResult = JObject.Parse(File.ReadAllText(path));
            // 
            var resultObject = tmpResult["Employee"].Values<JObject>()
                        .Where(n => n["Id"].Value<string>() != "201");

            string json = JsonConvert.SerializeObject(resultObject, Formatting.Indented);

                File.Delete(path);
                File.WriteAllText(path, json);

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String readJson = rd.ReadToEnd();
            SelectDataJson(readJson);
        }
    }
}
