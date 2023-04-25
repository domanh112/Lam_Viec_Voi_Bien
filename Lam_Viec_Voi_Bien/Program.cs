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
            string nameTable = "TestHamKhoiTao";
            string[] nameColumns = { "Id" + "," + typeof(int), "Name" + "," + typeof(string), "Email" + "," + typeof(string), "Salary" + "," + typeof(decimal) };
            int rowID  = 102;
            //Case_Data.Test_DataTable_DataSet_DataSet();
            //Case_Date.Test_Date_Time();
            //Case_Number.Test_Number();
            //Case_String.Test_String();
            DataTable TestHamKhoiTao = Case_Data.CreateDataTable(nameTable, nameColumns);
            Case_Data.DeleteDataRowById(TestHamKhoiTao, rowID);
        }
    }
}










