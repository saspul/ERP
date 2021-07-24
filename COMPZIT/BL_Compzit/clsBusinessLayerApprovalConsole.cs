using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using DL_Compzit;

namespace BL_Compzit
{
    public class clsBusinessLayerApprovalConsole
    {
        clsDataLayerApprovalConsole objDataApprvlCnsl = new clsDataLayerApprovalConsole();

        public DataTable ReadDocuments()
        {
            DataTable dt = objDataApprvlCnsl.ReadDocuments();
            return dt;
        }

        public DataTable ReadApprovalPendingList(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadApprovalPendingList(objEntityApprvlCnsl);
            return dt;
        }

        public DataTable ReadHierarchy(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadHierarchy(objEntityApprvlCnsl);
            return dt;
        }

        public DataTable ReadConditions(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadConditions(objEntityApprvlCnsl);
            return dt;
        }

        public DataTable CheckConditions(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.CheckConditions(objEntityApprvlCnsl);
            return dt;
        }

        public void ApproveRejectPurchaseOrder(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslList, List<clsEntityApprovalConsole> objEntityApprvlCnslAddList)
        {
            objDataApprvlCnsl.ApproveRejectPurchaseOrder(objEntityApprvlCnsl, objEntityApprvlCnslList, objEntityApprvlCnslAddList);
        }

        public DataTable ReadCommentDtls(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadCommentDtls(objEntityApprvlCnsl);
            return dt;
        }

        public void InsertComments(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            objDataApprvlCnsl.InsertComments(objEntityApprvlCnsl);
        }

        public DataTable ReadNoteDetails(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadNoteDetails(objEntityApprvlCnsl);
            return dt;
        }

        public void InsertNote(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslAttchmnts)
        {
            objDataApprvlCnsl.InsertNote(objEntityApprvlCnsl, objEntityApprvlCnslAttchmnts);
        }

        public DataTable ReadAdditionalDetails(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadAdditionalDetails(objEntityApprvlCnsl);
            return dt;
        }

        public void InsertAdditionalDetails(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslAttchmnts)
        {
            objDataApprvlCnsl.InsertAdditionalDetails(objEntityApprvlCnsl, objEntityApprvlCnslAttchmnts);
        }

        public void InsertUsrViewComments(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            objDataApprvlCnsl.InsertUsrViewComments(objEntityApprvlCnsl);
        }

        public void InsertDelegate(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            objDataApprvlCnsl.InsertDelegate(objEntityApprvlCnsl);
        }

        public DataTable ReadDelegateDtls(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            DataTable dt = objDataApprvlCnsl.ReadDelegateDtls(objEntityApprvlCnsl);
            return dt;
        }

        public void DeleteForMajorityApproval(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            objDataApprvlCnsl.DeleteForMajorityApproval(objEntityApprvlCnsl);
        }


    }
}
