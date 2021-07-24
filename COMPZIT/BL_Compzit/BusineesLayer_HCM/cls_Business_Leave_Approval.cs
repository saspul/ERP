using DL_Compzit.DataLayer_AWMS;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_AWMS;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class cls_Business_Leave_Approval
    {
        clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();

        //public DataTable ReadEmployeedtl(clsEntityLayerLeaveApproval objEntityLayerLeaveApproval)
        //{
        //    clsDataLeave_Approval objDataLayerApproval = new clsDataLeave_Approval();
        //    DataTable dtReadEmp = objDataLayerApproval.ReadEmployeedtl(objEntityLayerLeaveApproval);
        //    return dtReadEmp;
        //}

        public DataTable ReadLeavTypdtl(clsEntityLayerLeaveApproval objEntityLayerLeaveApproval)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavTypdtl(objEntityLayerLeaveApproval);
            return dtReadLeav;
        }

        public DataTable ReadRemLeav(clsEntityLayerLeaveApproval objEntLev)
        {
            clsDataLeave_Approval objDataLayerRemLeav = new clsDataLeave_Approval();
            DataTable count = objDataLayerRemLeav.ReadRemLeav(objEntLev);
            return count;
        }
        public DataTable ReadOPeningLeav(clsEntityLayerLeaveApproval objEntLev)
        {
            clsDataLeave_Approval objDataLayerRemLeav = new clsDataLeave_Approval();
            DataTable count = objDataLayerRemLeav.ReadOPeningLeav(objEntLev);
            return count;
        }
        public DataTable ReadLeavallocndtlBySearch(clsEntityLayerLeaveApproval objEntityLayerLeaveApproval)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavallocndtlBySearch(objEntityLayerLeaveApproval);
            return dtReadLeav;
        }
        public DataTable ReadLeavallocndtlByid(clsEntityLayerLeaveApproval objEntityLayerLeaveApproval)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavallocndtlByid(objEntityLayerLeaveApproval);
            return dtReadLeav;
        }
        public DataTable ReadEmployeeTotalLeave(clsEntityLayerLeaveApproval objEntityLev)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployeeTotalLve(objEntityLev);
            return dtReadLeav;

        }
        public void DivsionManagerApproval(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.DIVMANAGER_APPROVA(objEntityLev);

        }
        public void Hr_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.Hr_Approve(objEntityLev);

        }
        public void Gm_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.Gm_Approve(objEntityLev);

        }
        public void ReprtingEmploy_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.ReprtingEmploy_Approve(objEntityLev);

        }
        public void Reject(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.Reject(objEntityLev);

        }
        public void Close(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.Close(objEntityLev);


        }
        public DataTable ReadEmployeeDependent(clsEntityLayerLeaveApproval objEntityLev)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployeeDependent(objEntityLev);
            return dtReadLeav;

        }
        public DataTable ReadEmployeelastleave(clsEntityLayerLeaveApproval objEntityLev)
        {
            clsDataLeave_Approval objDataLayerLevAllo = new clsDataLeave_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployeelastleave(objEntityLev);
            return dtReadLeav;

        }
        public DataTable ReadLeaveRqstById(clsEntityLayerLeaveApproval objEntityLev)
        {
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeaveRqstById(objEntityLev);
            return dtReadLeav;
        }
        public string chkUserLevCount(clsEntityLayerLeaveApproval objEntityLev)
        {

            string count = objDataLayerLevAllo.chkUserLevCount(objEntityLev);
            return count;
        }
        public void InsertUserNewLevRow(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.InsertUserNewLevRow(objEntityLev);

        }
        public void InsertUserLeavTyp(clsEntityLayerLeaveApproval objEntityLev)
        {

            objDataLayerLevAllo.InsertUserLeavTyp(objEntityLev);

        }

        public void DeleteLeaveAllocationByLveRequestID(clsEntityLayerLeaveApproval objEntityLev)
        {
            objDataLayerLevAllo.DeleteLeaveAllocationByLveRequestID(objEntityLev);
        }


      
    }
    
}
