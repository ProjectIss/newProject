using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace issNewDAL.sqlHandler
{
    public class Handler
    {
        public SqlConnection Connection;


        public SqlConnection OpenConnection()

        {

            Connection = new SqlConnection();

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["issModel"].ConnectionString;
                if (ConnectionString != null && ConnectionString != string.Empty)

                {
                    HttpContext.Current.Session["Connstring"] = ConnectionString;
                    Connection.ConnectionString = ConnectionString;

                }

                else

                {

                    if (HttpContext.Current.Session != null && HttpContext.Current.Session["Connstring"] != null)

                    {

                        Connection.ConnectionString = HttpContext.Current.Session["Connstring"].ToString();

                    }

                    else

                    {

                        if (HttpContext.Current.Session != null && HttpContext.Current.Session["SuperadminConnectionString"] != null)

                        {

                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["SuperadminConnectionString"].ToString();

                        }

                        else

                        {

                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["STSOracleConnectionString"].ToString();

                        }

                    }

                }

                if (Connection.State == ConnectionState.Open)

                {

                    Connection.Close();

                    Connection.Dispose();

                }

                Connection.Open();

            }

            catch (Exception e)
            {
                
            }

            return Connection;

        }


        //Execute the insert,update,delete queries

        public int ExecuteCommand(string query)
        {

            int RowsAffected = 0;

            SqlCommand Command = null;

            Connection = OpenConnection();

            try

            {

                Command = new SqlCommand(query, Connection);

                RowsAffected = Command.ExecuteNonQuery();

            }

            catch (Exception e)

            {

                throw new Exception(e.Message + "<BR>" + query);

            }

            finally

            {

                Command.Dispose();

                Command = null;

                Connection.Close();

            }

            return RowsAffected;

        }
    }
}
