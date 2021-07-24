using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class ClsBusinessExpiryNotificationReport
    {
        ClsDataExpiryNotificationReport objdataExpiryNotificationReport = new ClsDataExpiryNotificationReport();
        public DataTable Read_Expiry_Notification_List(ClsEntityExpiryNotificationReport objEntityReport)
        {
            DataTable dt = objdataExpiryNotificationReport.Read_Expiry_Notification_List(objEntityReport);
            return dt;

        }

        public DataTable ReadCorporateAddress(ClsEntityExpiryNotificationReport objEntityReport)
        {
            DataTable dtCorp = objdataExpiryNotificationReport.ReadCorporateAddress(objEntityReport);
            return dtCorp;
        }
        //EVM-0027
        public DataTable ReadDivision(ClsEntityExpiryNotificationReport objEntityReport)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objdataExpiryNotificationReport.ReadDivision(objEntityReport);
            return dtDivision;
        }


        public DataTable ReadDepts(ClsEntityExpiryNotificationReport objEntityReport)
        {
            DataTable dtDepts = new DataTable();
            dtDepts = objdataExpiryNotificationReport.ReadDepts(objEntityReport);
            return dtDepts;
        }
        //End
    }
}
