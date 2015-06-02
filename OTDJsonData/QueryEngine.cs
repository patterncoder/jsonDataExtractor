using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace OTDJsonData
{
    public class QueryEngine
    {
        private string _conn;
        private XmlDocument _xdoc;

        public QueryEngine()
        {
            _conn = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            _xdoc = new XmlDocument();
        }

        public void ClearXDoc() 
        {
            _xdoc = new XmlDocument();
        }
        public string GetData(string query) 
        {
            
            string result = "";
            //string sql = "otd_sp_MenuGetByIDXML";

            //using (SqlConnection myConnection = new SqlConnection(_conn))
            //{
            //    using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
            //    {
            //        myCommand.CommandType = CommandType.StoredProcedure;

            //        myCommand.Parameters.AddWithValue("@MenuID", 596);
            //        myConnection.Open();
            //        XmlReader reader = myCommand.ExecuteXmlReader();
            //        XmlDocument xdoc = new XmlDocument();
            //        xdoc.Load(reader);

            //        result = JsonConvert.SerializeXmlNode(xdoc);
            //    }
            //}

            return result;
        }

        public string GetData(string query, Dictionary<string,string> parameters)
        {
         
            using (SqlConnection myConnection = new SqlConnection(_conn))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    foreach (var pair in parameters)
                    {
                        myCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    
                    myConnection.Open();
                    XmlReader reader = myCommand.ExecuteXmlReader();
                   
                    _xdoc.Load(reader);

                    return JsonConvert.SerializeXmlNode(_xdoc);
                }
            }
        }

        


    }
}
