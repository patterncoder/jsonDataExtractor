using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace getJson
{
    public class DataRetriever
    {
        private string _conn;
        public DataRetriever()
        {
            _conn = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        }

        public string getJson(string now)
        {

            string result;
            string sql = "otd_sp_entertainmentSchedule";
            
            using(SqlConnection myConnection = new SqlConnection(_conn))
            {
                using(SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@date", now);
                    myConnection.Open();
                    
                    DataTable dt = new DataTable();
                    dt.Load(myCommand.ExecuteReader());
                    result = JsonConvert.SerializeObject(dt);
                }
            }

            return result;

            //JsonConvert.SerializeObject();
        }
        
        

    }
}
