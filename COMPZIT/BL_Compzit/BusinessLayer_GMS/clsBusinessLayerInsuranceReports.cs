using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using EL_Compzit;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class clsBusinessLayerInsuranceReports
    {
        clsDataLayerInsuranceReports objDataLayerReports = new clsDataLayerInsuranceReports();
        public DataTable ReadDivision(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            DataTable dtDiv = new DataTable();
            dtDiv = objDataLayerReports.ReadDivision(ObjEntityInsuraceReports);
            return dtDiv;
        }
        public DataTable ReadCurrency(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency = objDataLayerReports.ReadCurrency(ObjEntityInsuraceReports);
            return dtCurrency;
        }
        public DataTable ReadDefualtCurrency(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            DataTable dtDefCurrency = new DataTable();
            dtDefCurrency = objDataLayerReports.ReadDefualtCurrency(ObjEntityInsuraceReports);
            return dtDefCurrency;
        }

        public DataTable Read_ExpiryRange_LIstDetails(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            DataTable dtList = objDataLayerReports.Read_ExpiryRange_LIstDetails(ObjEntityInsuraceReports);
            return dtList;
        }
        public DataTable ReadCorporateAddress(clsEntityInsuraceReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadCorporateAddress(objEntityReport);
            return dtCorp;
        }
    }
}
