using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace Database_Connection_using_ADO.Net
{
  
    public class Program
    {
        public const string ConnectionString = "data source=MD4KYC2C\\SQLEXPRESS; database=College_Database; integrated security = SSPI";
        
        

        

        public static void Main()
        {
            Program p=new Program();

            //DataSet ds = new DataSet();
            //ds = p.GetPersonData();
            //Console.WriteLine();

            Connected_Architecture.printCityTable();
            //Connected_Architecture.InsertIntoCity();

            Disconnected_Architecture.GetPersonData();


        }
    }
}