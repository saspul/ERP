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
    public class clsBusinessLayerApprovalset
    {
        clsDataLayerApprovalset objApproval = new clsDataLayerApprovalset();
        
        public DataTable ReadAppCondition()
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadAppCondition();
            return dtdoc;
        }
        public DataTable ReadAppConditionType()
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadAppConditionType();
            return dtdoc;
        }
        public DataTable LoadAppCondition(clsEntityApprovalHierarchyTemp objentityPass)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.LoadAppCondition(objentityPass);
            return dtdoc;
        }
        public DataTable ReadApprovalCnfmsts(clsEntityApprovalHierarchyTemp objentityPass)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalCnfmsts(objentityPass);
            return dtdoc;
        }
        public DataTable LoadAppConditionType(clsEntityApprovalHierarchyTemp objentityPass)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.LoadAppConditionType(objentityPass);
            return dtdoc;
        }
        public DataSet ReadProcedurecnd(clsEntityApprovalHierarchyTemp objentityPass)
        {
           DataSet dtCommon = objApproval.ReadProcedurecnd(objentityPass);
            return dtCommon;
        }
        public void insertApprovalSet(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn)
        {
            objApproval.insertApprovalSet(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn);
        }
        public DataTable Readappwname(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.Readappwname(objentityPass1);
            return dtdoc;
        }
        public DataTable ReadAppsetsts(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadAppsetsts(objentityPass1);
            return dtdoc;
        }
        public void cancelApprovalset(clsEntityApprovalHierarchyTemp objentityPass)
        {
            objApproval.cancelApprovalset(objentityPass);
        }
        public DataTable ReadApproval(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApproval(objentityPass1);
            return dtdoc;
        }
        public void UpdateApprovalSet(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            objApproval.UpdateApprovalSet(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn, objEntityTrficVioltnDetilsListDele);
        }
        public void updateApprovalSetconfrm(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            objApproval.updateApprovalSetconfrm(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn, objEntityTrficVioltnDetilsListDele);
        }
        public DataTable ReadApprovalActive(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalActive(objentityPass1);
            return dtdoc;
        }
        public DataTable ReadApprovallist(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovallist(objentityPass1);
            return dtdoc;
        }
        public DataTable ReadApprovalcncl()
        {

            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalcncl();
            return dtdoc;
        }
        public void ReopenApprovalset(clsEntityApprovalHierarchyTemp objentityPass)
        {
            objApproval.ReopenApprovalset(objentityPass);
        }
        public DataTable ReadApprovalAss(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalAss(objentityPass1);
            return dtdoc;
        }
        public DataTable ReadApprovalAll(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalAll(objentityPass1);
            return dtdoc;
        }
        public DataTable ReadApprovalWrkflowList(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            DataTable dtdoc = new DataTable();
            dtdoc = objApproval.ReadApprovalWrkflowList(objentityPass1);
            return dtdoc;
        }
    }
}
