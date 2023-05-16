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

            if (File.Exists(path))
            {
                File.Delete(path);
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("{\n\"" + nameJson + "\" :");
                    tw.WriteLine(JSONresult);
                    tw.WriteLine("}");
                    tw.Close();
                }
            }
            else if (!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("{\n\"" + nameJson + "\" :");
                    tw.WriteLine(JSONresult);
                    tw.WriteLine("}");
                    tw.Close();
                }
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String readJson = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu thoy, ReadToEnd là đọc hết
            Console.WriteLine(readJson.Replace("\\", ""));
            rd.Close();

            Console.WriteLine("Insert Success !!! \n");
            return JSONresult;
        }

        public static void AddnewJson(string path, string[] addNew)
        {
            var newMember = "{ \"Id\": " + addNew[0] + ",\n\"Name\": \"" + addNew[1] + "\",\n\"Email\": \"" + addNew[2] + "\",\n\"Salary\": " + addNew[3] + ",\n}";
            //var newAddress = "\"Address\": [\n{\n\"Num\": \"" + addNew[4] + "\",\n\"Street\": \"" + addNew[5] + "\"\n}\n]\n}";
            try
            {
                var json = File.ReadAllText(path);
                var jsonObj = JObject.Parse(json);
                var experienceArrary = jsonObj.GetValue("Employee") as JArray;
                var newItem = JObject.Parse(newMember );
                experienceArrary.Add(newItem);

                jsonObj["Employee"] = experienceArrary;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                            Console.WriteLine("Thêm thành công !!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public static void SelectNewDataJson(string path)
        {

            var json = File.ReadAllText(path);
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["Employee"];
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);

                    if (experiencesArrary != null && jsonObj["Employee"][0]["Id"] == 201)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            Console.WriteLine("Id :" + item["Id"].ToString());
                            Console.WriteLine("Name :" + item["Name"].ToString());
                            Console.WriteLine("Email :" + item["Email"].ToString());
                            Console.WriteLine("Salary :" + item["Salary"].ToString());
                            //JArray Addr = (JArray)item["Address"];
                            //if (Addr != null)
                            //{
                            //    foreach (var ar in Addr)
                            //    {
                            //        Console.WriteLine("Num :" + ar["Num"].ToString());
                            //        Console.WriteLine("Street :" + ar["Street"].ToString());
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        public static void DeleteDataJson(string path, string nameJson)
        {
            JObject tmpResult = JObject.Parse(File.ReadAllText(path));
            var resultObject = tmpResult[nameJson].Values<JObject>()
                        .Where(n => n["Id"].Value<string>() != "201");

            string json = JsonConvert.SerializeObject(resultObject, Formatting.Indented);

            File.Delete(path);
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine("{\n\"" + nameJson + "\" :");
                tw.WriteLine(json.ToString());
                tw.WriteLine("}");
                tw.Close();
            }
            SelectDataJson(json);
        }

        public static void EditDataJson(string path, string nameJson)
        {
            string json = File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj[nameJson][1]["Id"] = 204;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            string output2 = output.Replace("  \"Employee\": [", "\"Employee\": \n[");
            File.Delete(path);
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(output2);
                tw.Close();
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String readJson = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu thoy, ReadToEnd là đọc hết
            Console.WriteLine(readJson);
            //SelectDataJson(output2);
        }
    }
}
