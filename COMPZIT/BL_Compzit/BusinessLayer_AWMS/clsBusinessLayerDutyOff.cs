using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0015
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerDutyOff
    {
        // This Method insert  details into the database.
        public void AddDutyOffDetails(clsEntityLayerDutyOff objEntDuty)
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
            objDataLayerDutyoff.AddDutyOffDetails(objEntDuty);

        }
        // This Method update  details into the database.
        public void UpdateutyOffdetails(clsEntityLayerDutyOff objEntDuty)
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
            objDataLayerDutyoff.AddDutyOffDetails(objEntDuty);
        }
                // This Method update  fetch from the database.
        public DataTable getdutyoff(clsEntityLayerDutyOff objEntDuty)
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
            return objDataLayerDutyoff.getdutyoff(objEntDuty);
            
        }
        public DataTable getmonthlytype( )
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
            return objDataLayerDutyoff.getmonthlytype();

        }

        public void updatemnthlyoffdetails(clsEntityLayerDutyOff objEntDuty)
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
            objDataLayerDutyoff.updatemnthlyoffdetails(objEntDuty);

        }
        public string CheckDuplication(clsEntityLayerDutyOff objEntDuty)
        {
            clsDataLayerDutyOff objDataLayerDutyoff = new clsDataLayerDutyOff();
           string strReturn =objDataLayerDutyoff.CheckDuplication(objEntDuty);
           return strReturn;
        }
        
        }
    }

