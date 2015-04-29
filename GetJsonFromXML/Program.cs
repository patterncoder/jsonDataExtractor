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



namespace GetJsonFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string _conn = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            string result;
            string sql = "otd_sp_MenuGetByIDXML";

            using (SqlConnection myConnection = new SqlConnection(_conn))
            {
                using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MenuID", 596);
                    myConnection.Open();
                    XmlReader reader = myCommand.ExecuteXmlReader();
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(reader);
                    
                    result = JsonConvert.SerializeXmlNode(xdoc);
                }
            }

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
