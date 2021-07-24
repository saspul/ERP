using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
 public class clsBusinessManpwrJobAssignemntReport
    {
     clsDataLayerManpwrJobAssignmentReport objDataMnpwrJobAssignmentReport = new clsDataLayerManpwrJobAssignmentReport();
     public DataTable ReadManpwrJobAssignment(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
     {
         DataTable dtMnpwr = new DataTable();
         dtMnpwr = objDataMnpwrJobAssignmentReport.ReadManpwrJobAssignment(objEntityLayerManpwr);
         return dtMnpwr;
     }
     public DataTable ReadProject(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
     {
         DataTable dtGuarnt = new DataTable();
         dtGuarnt = objDataMnpwrJobAssignmentReport.ReadProject(objEntityReqrmntAlctn);
         return dtGuarnt;
     }
     public DataTable ReadEmployeeList(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
     {
         DataTable dtGuarnt = new DataTable();
         dtGuarnt = objDataMnpwrJobAssignmentReport.ReadEmployeeList(objEntityReqrmntAlctn);
         return dtGuarnt;
     
     }
     public DataTable ReadCorporateAddress(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
     {
         DataTable dtCorp = new DataTable();
         dtCorp = objDataMnpwrJobAssignmentReport.ReadCorporateAddress(objEntityReqrmntAlctn);
         return dtCorp;
     }
     public string ReadCountCandShrtlst(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
     {
         string strReturn = objDataMnpwrJobAssignmentReport.ReadCountCandShrtlst(objEntityReqrmntAlctn);
         return strReturn;
     }
     public string ReadCountIntrvwPrcs(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
     {
         string strReturn = objDataMnpwrJobAssignmentReport.ReadCountIntrvwPrcs(objEntityLayerManpwr);
         return strReturn;
     }
    }
}
