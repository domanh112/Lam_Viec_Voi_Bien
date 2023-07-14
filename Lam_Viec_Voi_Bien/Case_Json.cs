using ConsoleTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
using TaiLieuC;
using static TaiLieuC.CaseJson2;

namespace Lam_Viec_Voi_Bien
{
    internal class Case_Json
    {
        //public static string AddJson(List<Employee> lstEmp, string path, string nameJson)
        //{
        //    string JSONresult = JsonConvert.SerializeObject(lstEmp, Formatting.Indented);

        //    if (File.Exists(path))
        //    {
        //        File.Delete(path);
        //        using (var tw = new StreamWriter(path, true))
        //        {
        //            tw.WriteLine("{\n\"" + nameJson + "\" :");
        //            tw.WriteLine(JSONresult);
        //            tw.WriteLine("}");
        //            tw.Close();
        //        }
        //    }
        //    else if (!File.Exists(path))
        //    {
        //        using (var tw = new StreamWriter(path, true))
        //        {
        //            tw.WriteLine("{\n\"" + nameJson + "\" :");
        //            tw.WriteLine(JSONresult);
        //            tw.WriteLine("}");
        //            tw.Close();
        //        }
        //    }
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    StreamReader rd = new StreamReader(fs, Encoding.UTF8);
        //    String readJson = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu thoy, ReadToEnd là đọc hết
        //    Console.WriteLine(readJson.Replace("\\", ""));
        //    rd.Close();

        //    Console.WriteLine("Insert Success !!! \n");
        //    return JSONresult;
        //}

        //public static void AddnewJson(string path, string[] addNew)
        //{
        //    var newMember = "{ \"Id\": " + addNew[0] + ",\n\"Name\": \"" + addNew[1] + "\",\n\"Email\": \"" + addNew[2] + "\",\n\"Salary\": " + addNew[3] + ",\n}";
        //    //var newAddress = "\"Address\": [\n{\n\"Num\": \"" + addNew[4] + "\",\n\"Street\": \"" + addNew[5] + "\"\n}\n]\n}";
        //    try
        //    {
        //        var json = File.ReadAllText(path);
        //        var jsonObj = JObject.Parse(json);
        //        var jsonArray = jsonObj.GetValue("Employee") as JArray;
        //        var newItem = JObject.Parse(newMember);
        //        jsonArray.Add(newItem);

        //        jsonObj["Employee"] = jsonArray;
        //        string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        //        File.WriteAllText(path, newJsonResult);
        //        Console.WriteLine("Thêm thành công !!");

        //        string output2 = newJsonResult.Replace("{\r\n  \"Employee\": ", "");
        //        string output3 = output2.Replace("]\r\n}", "]");
        //        SelectDataJson(output3);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Add Error : " + ex.Message.ToString());
        //    }
        //}

        //public static void SelectNewDataJson(string path)
        //{

        //    var json = File.ReadAllText(path);
        //    try
        //    {
        //        var jObject = JObject.Parse(json);
        //        if (jObject != null)
        //        {
        //            JArray experiencesArrary = (JArray)jObject["Employee"];
        //            dynamic jsonObj = JsonConvert.DeserializeObject(json);

        //            if (experiencesArrary != null && jsonObj["Employee"][0]["Id"] == 201)
        //            {
        //                foreach (var item in experiencesArrary)
        //                {
        //                    Console.WriteLine("Id :" + item["Id"].ToString());
        //                    Console.WriteLine("Name :" + item["Name"].ToString());
        //                    Console.WriteLine("Email :" + item["Email"].ToString());
        //                    Console.WriteLine("Salary :" + item["Salary"].ToString());
        //                    //JArray Addr = (JArray)item["Address"];
        //                    //if (Addr != null)
        //                    //{
        //                    //    foreach (var ar in Addr)
        //                    //    {
        //                    //        Console.WriteLine("Num :" + ar["Num"].ToString());
        //                    //        Console.WriteLine("Street :" + ar["Street"].ToString());
        //                    //    }
        //                    //}
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void SelectDataJson(string resultJson)
        //{
        //    // Đưa dữ liệu vào dataTable để hiển thị theo dạng bảng
        //    DataTable dt = (DataTable)JsonConvert.DeserializeObject(resultJson, (typeof(DataTable)));

        //    DataRow[] rows = dt.Select();

        //    // lấy ra 1 mảng chứa tên các cột trong dataTable để truyền vào bảng select
        //    string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
        //    var table = new ConsoleTable(columnNames);

        //    // lấy dữ liệu từng row trong mảng row để thêm vào bảng select
        //    foreach (DataRow row in rows)
        //    {
        //        table.AddRow(row.ItemArray);
        //    }
        //    table.Write(Format.MarkDown);
        //}

        //public static void FilterDataJson(string path)
        //{
        //    // Đưa dữ liệu file Json vào JObject1 sau đó khởi tạo 1 JObject2 để hứng dữ liệu sau khi filter từ JObject1
        //    var readFileJson = JObject.Parse(File.ReadAllText(path));
        //    var resultJObject = readFileJson["Employee"].Values<JObject>()
        //                .Where(n => n["Id"].Value<string>() == "201");

        //    // Convert dữ liệu sau khi filter từ JObject => string để hiển thị
        //    string json = JsonConvert.SerializeObject(resultJObject, Formatting.Indented);
        //    SelectDataJson(json);
        //}

        //public static void DeleteDataJson(string path, string nameJson)
        //{
        //    // Đưa dữ liệu file Json vào JObject1 sau đó khởi tạo 1 JObject2 để hứng dữ liệu sau khi filter từ JObject1
        //    var readFileJson = JObject.Parse(File.ReadAllText(path));
        //    var resultJObject = readFileJson[nameJson].Values<JObject>()
        //                .Where(n => n["Id"].Value<string>() != "201");

        //    // Convert dữ liệu sau khi filter từ JObject => string 
        //    string json = JsonConvert.SerializeObject(resultJObject, Formatting.Indented);

        //    // Xóa file trước khi sửa
        //    File.Delete(path);

        //    // Mở file Json để viết chuỗi Json sau khi đã đc filter , sau đó hiển thị lại dữ liệu
        //    using (var tw = new StreamWriter(path, true))
        //    {
        //        tw.WriteLine("{\n\"" + nameJson + "\" :");
        //        tw.WriteLine(json.ToString());
        //        tw.WriteLine("}");
        //        tw.Close();
        //    }
        //    SelectDataJson(json);
        //}

        //public static void EditDataJson(string path, string nameJson)
        //{
        //    // Đưa dữ liệu file Json sau khi đã đọc vào JObject
        //    string readFileJson = File.ReadAllText(path);

        //    // Khai báo 1 biến dynamic(biến kiểu động) để hứng sau khi đã convert từ Json
        //    dynamic jsonObj = JsonConvert.DeserializeObject(readFileJson);

        //    // Sửa dữ liệu tại Index = 1
        //    jsonObj[nameJson][1]["Id"] = 204;
        //    jsonObj[nameJson][1]["Name"] = "Manhme";

        //    // convert ngược object sang string để hiển thị
        //    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

        //    // Xóa file cũ và viết dữ liệu mới vào file mới
        //    File.Delete(path);
        //    using (var tw = new StreamWriter(path, true))
        //    {
        //        tw.WriteLine(output);
        //        tw.Close();
        //    }

        //    // Xử lý chuỗi đúng format để hiển thị
        //    string output2 = output.Replace("{\r\n  \"Employee\": ", "");
        //    string output3 = output2.Replace("]\r\n}", "]");
        //    SelectDataJson(output3);
        //}



    }

    public class Jsonnnnnnnnnnn
    {
        public static void CreateFileJson(string pathCre ,ClassUniversities university1)
        {
            using (StreamWriter sw = File.CreateText(pathCre))
            {
                string jsonC = JsonConvert.SerializeObject(university1, Formatting.Indented);
                sw.WriteLine(jsonC);
                sw.Close();
                Console.Write("Create suscess!!! : ");
                Console.WriteLine(jsonC);
                Console.ReadLine();
            }
        }

        public static void ReadFileJson(string pathRUD, Example ex)
        {
            using (StreamReader sr = File.OpenText(pathRUD))
            {
                var obj = sr.ReadToEnd();
                ex = JsonConvert.DeserializeObject<Example>(obj);
                string jsonR = JsonConvert.SerializeObject(ex, Formatting.Indented);

                Console.Write("Read File Json :");
                Console.WriteLine(jsonR);
            }
        }

        public static void UpdateFileJson(string pathRUD, Example ex, string No)
        {
            using (StreamReader sr = File.OpenText(pathRUD))
            {
                var obj = sr.ReadToEnd();
                ex = JsonConvert.DeserializeObject<Example>(obj);
                if (ex.orders[0].tableNo == No)
                {
                    string jsonU = JsonConvert.SerializeObject(ex.orders[0].tableNo, Formatting.Indented);
                    Console.WriteLine(jsonU);
                }
            }

            //using (StreamWriter sw = File.CreateText(pathRUD))
            //{
            //    string jsonU = JsonConvert.SerializeObject(ex, Formatting.Indented);
            //    sw.WriteLine(jsonU);
            //    sw.Close();
            //    Console.WriteLine(jsonU);
            //}
        }

        public static void DeleteFileJson(string pathRUD, Example ex)
        {
            using (StreamReader sr = File.OpenText(pathRUD))
            {
                var obj = sr.ReadToEnd();
                ex = JsonConvert.DeserializeObject<Example>(obj);
                ex.orders[0].orderdetails[0].name = "manh";
            }

            using (StreamWriter sw = File.CreateText(pathRUD))
            {
                string jsonU = JsonConvert.SerializeObject(ex, Formatting.Indented);
                sw.WriteLine(jsonU);
                sw.Close();
                Console.WriteLine(jsonU);
            }
        }
    }

}
