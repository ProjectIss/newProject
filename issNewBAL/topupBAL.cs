using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issNewBAL
{
    public class topupBAL
    {
        issNewDAL.topup objTopup = new issNewDAL.topup();
        public DataSet GetTopup()
        {
            DataSet ds = objTopup.getTopup();
            return ds;
        }


        public int InsertUpdate(int TopupID, DateTime TDate, int InvID, int UID, int TAmount, string Status)
        {
            int resp = objTopup.InsertMenthod(TopupID, TDate, InvID, UID, TAmount, Status);
            return resp;
        }
    }
}
