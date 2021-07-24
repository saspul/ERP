using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerDutyRosterReports
    {
        clsDataLayerDutyRosterReports objDtalayerDutyRosterReptr = new clsDataLayerDutyRosterReports();
        
        // This Method will fetch emlpoyee datas
        public DataTable ReadDutyRosterReptr(clsEntityLayerDutyRosterReports objEntityDutyRostReprt, List<clsEntityDutyRosterReportEmpselection> objlistEmplyList)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadDutyRosterReports(objEntityDutyRostReprt, objlistEmplyList);
            return dtDutyRosterList;
        }

        public DataTable ReadEmployeeDetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadEmployeeDetails(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }

        public DataTable ReadEmployeeJobdetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            {
                DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadEmployeeJobdetails(objEntityDutyRostReprt);
                return dtDutyRosterList;
            }
        }

        public DataTable ReadCorporateAddress(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadCorporateAddress(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }

        public DataTable ReadHolidayDate(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadHolidayDate(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }
        public DataTable ReadLeaveDate(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadLeaveDate(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }
        //Read Additional job deatails
        public DataTable ReadEmployeeAdditionalJobdetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadEmployeeAdditionalJobdetails(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }
        public DataTable ReadAllEmployee(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            DataTable dtDutyRosterList = objDtalayerDutyRosterReptr.ReadAllEmployee(objEntityDutyRostReprt);
            return dtDutyRosterList;
        }

    }
}
