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
    public class Disconnected_Architecture
    {
        public static void GetPersonData()
        {
            //to ensure that connection automatically gets closed use USING BLOCK
            using (SqlConnection sqlCon = new SqlConnection(Program.ConnectionString))
            {

                try
                {

                    //sqlCon.Open();//NO need in disconnected architecture
                    //Just to check if our connection was estbalished succesfully
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection Has been created succesfully");
                    }
                    //string query = "Select * from Person";
                    //SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                    //OR
                    //SqlCommand sqlcmd = new SqlCommand("Select * from Person", sqlCon);
                    SqlDataAdapter sda = new SqlDataAdapter("Select * from Person", sqlCon);
                    DataSet dsData = new DataSet();
                    sda.Fill(dsData);
                    
                    foreach(DataRow dr in dsData.Tables[0].Rows)
                    {
                        Console.WriteLine("Person_Id:{0} First_Name:{1}",dr[0],dr[1]);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("OOPs, something went wrong." + ex.Message);

                }
                finally
                {
                    sqlCon.Close(); //nOT WRITING THIS WILL NOT CREATE ANY PROBLEM AS USING BLOCK AUTOMATICALLY
                                    //CLOSES OUR CONNECTION
                }
               
            }
        }
    }
}
