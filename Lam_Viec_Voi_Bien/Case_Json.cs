using Newtonsoft.Json;
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
        public static string AddJson(List<Employee> lstEmp,string path) 
        { 
            string JSONresult = JsonConvert.SerializeObject(lstEmp, Formatting.Indented);
            //Employee deseri   alizedProduct = JsonConvert.DeserializeObject<Employee>(JSONresult);

            if (File.Exists(path))
            {
                File.Delete(path);
                using (var tw = new StreamWriter(path, true))
                {
                    //tw.WriteLine("Employee :");
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }else if (!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    //tw.WriteLine("Employee :");
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
            Console.WriteLine("Insert Success !!! \n"+JSONresult);
            return JSONresult;
        }

        private static string AddSquareBrackets(string json)
        {
            return $"[{json}]";
        }

        //private static DataTable ConvertJsonToDataTable(Object obj)
        //    {
        //    string JSONresult = JsonConvert.SerializeObject(obj);

        //    JSONresult = AddSquareBrackets(JSONresult);

        //    var dt = ConvertJsonToDataTable(JSONresult);
        //    try
        //        {
        //            return JsonConvert.DeserializeObject<DataTable>(jsonData);
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        }
        
    }
