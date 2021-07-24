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
    public class cls_Business_Resignation_Approval
    {
        clsDataResignation_Approval objDataLayerLevAllo = new clsDataResignation_Approval();

        public DataTable ReadResignationreqBySearch(clsEntityLayerresignationApproval objEntityLayerLeaveApproval)
        {
            clsDataResignation_Approval objDataLayerLevAllo = new clsDataResignation_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavallocndtlBySearch(objEntityLayerLeaveApproval);
            return dtReadLeav;
        }
        public DataTable ReadResignationreqByid(clsEntityLayerresignationApproval objEntityLayerLeaveApproval)
        {
            clsDataResignation_Approval objDataLayerLevAllo = new clsDataResignation_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavallocndtlByid(objEntityLayerLeaveApproval);
            return dtReadLeav;
        }
        //public DataTable ReadEmployeeTotalLeave(clsEntityLayerLeaveApproval objEntityLev)
        //{
        //    cls_Business_Resignation_Approval objDataLayerLevAllo = new cls_Business_Resignation_Approval();
        //    DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployeeTotalLve(objEntityLev);
        //    return dtReadLeav;

        //}
        public void DivsionManagerApproval(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.DIVMANAGER_APPROVA(objEntityLev);

        }
        public void Hr_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.Hr_Approve(objEntityLev);

        }
        public void Gm_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.Gm_Approve(objEntityLev);

        }
        public void ReprtingEmploy_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.ReprtingEmploy_Approve(objEntityLev);

        }
        public void Reject(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.Reject(objEntityLev);

        }
        public void Close(clsEntityLayerresignationApproval objEntityLev)
        {
            objDataLayerLevAllo.Close(objEntityLev);


        }
        public DataTable ReadEmployeeDivsn(clsEntityLayerresignationApproval objEntityLev)
        {
            clsDataResignation_Approval objDataLayerLevAllo = new clsDataResignation_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployeeDivsn(objEntityLev);
            return dtReadLeav;
        }
        public DataTable ReadEmployee(clsEntityLayerresignationApproval objEntityLev)
        {
            clsDataResignation_Approval objDataLayerLevAllo = new clsDataResignation_Approval();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadEmployee(objEntityLev);
            return dtReadLeav;

        }
    }
    }
