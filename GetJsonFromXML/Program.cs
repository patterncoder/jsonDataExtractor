using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Xml;
using OTDJsonData;




namespace GetJsonFromXML
{
    class Program
    {
        static void Main(string[] args)
        {

            var qryEngine = new QueryEngine();
            Dictionary<string,string> myParams = new Dictionary<string, string>();
            myParams.Add("@MenuID", "596");
            Dictionary<string, string> myParams2 = new Dictionary<string, string>();
            myParams2.Add("@Date", "20150425");
            
            Console.Write(qryEngine.GetData("otd_sp_MenuGetByIDXML", myParams));
            qryEngine.ClearXDoc();
            Console.Write(qryEngine.GetData("otd_sp_entertainmentSchedule", myParams2));
            Console.ReadKey();
        }
    }

    
}
