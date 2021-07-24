using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
using CL_Compzit;

namespace BL_Compzit.BusinessLayer_PMS
{
   public class clsBusinessLayerApprovalAssign
    {
        clsDataLayerApprovalAssignment ObjDataAcco = new clsDataLayerApprovalAssignment();

        public DataTable ReadDesgDDL(clsEntityApprovalAssign objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadDesgDDL(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable Readwrkflw(string strLikeName, clsEntityApprovalAssign objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.Readwrkflw(strLikeName, objEntityAcco);
            return dtAccodetails;
        }
        public DataTable Readapproval(string strLikeName,clsEntityApprovalAssign objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.Readapproval(strLikeName,objEntityAcco);
            return dtAccodetails;
        }
        public void insertApprovalAssignment(clsEntityApprovalAssign objentityPass, List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList)
        {
            ObjDataAcco.insertApprovalAssignment(objentityPass, objEntityTrficVioltnDetilsList);
        }
        public DataTable ReadApprovalAss(clsEntityApprovalAssign objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadApprovalAss(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable ReadAppAssignment(clsEntityApprovalAssign objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadAppAssignment(objEntityAcco);
            return dtAccodetails;
        }
        public void cancelApprovalAss(clsEntityApprovalAssign objEntityAcco)
        {
            ObjDataAcco.cancelApprovalAss(objEntityAcco);
        }
        public void updatewrkflwftl(clsEntityApprovalAssign objentityPass)
        {
            ObjDataAcco.updatewrkflwftl(objentityPass);
        }
        public void UpdateApprovalAssign(clsEntityApprovalAssign objentityPass, List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList)
        {
            ObjDataAcco.UpdateApprovalAssign(objentityPass, objEntityTrficVioltnDetilsList);
        }
    }
}
