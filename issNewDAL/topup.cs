using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issNewDAL
{
    public class topup
    {

        static string SPInsertTopup = "[dbo].[InsertTopupDetails]";
        static string SPGetTopup = "[dbo].[GetTblTopup]";

        sqlHandler.Handler objHandler = new sqlHandler.Handler();
        public int InsertMenthod(int TopupID, DateTime TDate, int InvID, int UID, int TAmount, string Status)
        {
            try
            {
                SqlConnection sqlConnection = objHandler.OpenConnection();
                SqlCommand sql_cmnd = new SqlCommand(SPInsertTopup, sqlConnection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@TopupID", SqlDbType.Int).Value = TopupID;
                sql_cmnd.Parameters.AddWithValue("@TDate", SqlDbType.DateTime).Value = TDate;
                sql_cmnd.Parameters.AddWithValue("@InvID", SqlDbType.Int).Value = InvID;
                sql_cmnd.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = UID;
                sql_cmnd.Parameters.AddWithValue("@TAmount", SqlDbType.Int).Value = TAmount;
                sql_cmnd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Status;
                sql_cmnd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;
        }

        public DataSet getTopup()
        {
            DataSet ds = new DataSet();
            try
            {
               
                SqlConnection sqlConnection = objHandler.OpenConnection();
                SqlCommand sql_cmnd = new SqlCommand(SPGetTopup, sqlConnection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sql_cmnd;

                da.Fill(ds);

            }
            catch (Exception ex)
            {
              
            }

            return ds;
        }

        public int Delete(int TopupID,int InvID, int UID,  string Status)
        {
            try
            {
                SqlConnection sqlConnection = objHandler.OpenConnection();
                SqlCommand sql_cmnd = new SqlCommand(SPInsertTopup, sqlConnection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@TopupID", SqlDbType.Int).Value = TopupID;
                sql_cmnd.Parameters.AddWithValue("@TDate", SqlDbType.DateTime).Value = DateTime.Now;
                sql_cmnd.Parameters.AddWithValue("@InvID", SqlDbType.Int).Value = InvID;
                sql_cmnd.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = UID;
                sql_cmnd.Parameters.AddWithValue("@TAmount", SqlDbType.Int).Value = 0;
                sql_cmnd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Status;
                sql_cmnd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;
        }
    }
}
