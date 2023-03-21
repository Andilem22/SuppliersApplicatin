using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Suppliers
{
    public class Database
    {
        public static SqlConnection DefaultConnection()
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] == null)
                throw new ApplicationException("Could not find connection string: DefaultConnection");

            string sConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sCon = new SqlConnection(sConString);
            sCon.Open();
            return sCon;
        }
    }
}