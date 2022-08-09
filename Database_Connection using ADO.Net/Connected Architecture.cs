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
    public class Connected_Architecture
    {



        //Passing simple query & stored procedure to SqlCommand
        //using EXECUTEREADER() Method to Execute sqlcmd 
        //Printing details returned by EXECUTEREADER using READ()
        public static void printCityTable()
        {
            SqlConnection sqlCon = null;
            try
            {
                using (sqlCon = new SqlConnection(Program.ConnectionString))
                {
                    ////Passing simple query to SqlCommand
                    ///
                    //string query = "Select * from City";
                    //SqlCommand sqlcmd = new SqlCommand(query, sqlCon);

                    //Passing stored procedure to SqlCommand
                    string query = "CityDetails"; //CityDetails here is a stored procedure
                    SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                    //Command Type property of SqlCommmand used to execute Stored procedure
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    sqlCon.Open();
                    //EXECUTEREADER executes our sqlCmd and returns DataReader type data
                    SqlDataReader dr = sqlcmd.ExecuteReader();

                    //PRINTING DETAILS
                    while (dr.Read())
                    {
                        Console.WriteLine("c_Id={0}  cityName={1}  pinCode={2}", dr["c_Id"], dr["cityName"], dr["pinCode"]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }




        //Taking Input from user and inserting into City table
        //using ExecuteNonQuery() Function to execute sqlcmd
        //Parameters.AddWithValue() to pass value to the parameter of our query
        public static void InsertIntoCity() //update & delete can be done with some changes
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(Program.ConnectionString))
                {
                    Console.WriteLine("Enter CityName: ");
                    string name=Console.ReadLine();
                    Console.WriteLine("Enter Pincode: ");
                    string pin = Console.ReadLine();
                    Console.WriteLine("Enter Country: ");
                    string country = Console.ReadLine();

                    string query = "INSERT into City VALUES(@cityName,@pinCode,@country)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@cityName",name);
                    cmd.Parameters.AddWithValue("@pinCode", pin);
                    cmd.Parameters.AddWithValue("@country", country);

                    con.Open();
                    int x=cmd.ExecuteNonQuery();//executes cmd and returns 1 if successful and 0 if fails
                    if(x>0)
                    {
                        Console.WriteLine("Insertion into City table successful");
                    }
                    else 
                    { 
                        Console.WriteLine("Insertion into City table successful"); 
                    }
                }
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message);}
            finally
            {
                con.Close();
                Console.WriteLine("\n|||||City Table After your insertion|||||");
                printCityTable();
            }
        }
       
    }

}
