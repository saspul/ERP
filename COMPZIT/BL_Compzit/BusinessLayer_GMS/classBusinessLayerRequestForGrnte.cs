using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_GMS
{

    public class classBusinessLayerRequestForGrnte
    {
        classDataLayerRequestForGrnte objDataReqstForGrnte = new classDataLayerRequestForGrnte();
        public DataTable ReadProjects(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtProjects = new DataTable();
            dtProjects = objDataReqstForGrnte.ReadProjects(objEntityRqstFrGrnty);
            return dtProjects;
        }
        // This Method will fetCH guarantee cat
        public DataTable ReadGuaranteeCat(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtGuarantee = new DataTable();
            dtGuarantee = objDataReqstForGrnte.ReadGuaranteeCat(objEntityRqstFrGrnty);
            return dtGuarantee;
        }
        // This Method will fetch customer
        public DataTable ReadCustomer(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtCustomer = new DataTable();
            dtCustomer = objDataReqstForGrnte.ReadCustomer(objEntityRqstFrGrnty);
            return dtCustomer;
        }
        // This Method will fetCH employee
        public DataTable ReadEmployee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtEmployee = new DataTable();
            dtEmployee = objDataReqstForGrnte.ReadEmployee(objEntityRqstFrGrnty);
            return dtEmployee;
        }
        // This Method will fetCH currency
        public DataTable ReadCurrency(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency = objDataReqstForGrnte.ReadCurrency(objEntityRqstFrGrnty);
            return dtCurrency;
        }
        // This Method will fetCH job category
        public DataTable ReadJobCategory(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtJobCategory = new DataTable();
            dtJobCategory = objDataReqstForGrnte.ReadJobCategory(objEntityRqstFrGrnty);
            return dtJobCategory;
        }

        // This Method adds request for Guarantee details to the table
        public void AddRqstForGuarantee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.AddRqstForGuarantee(objEntityRqstFrGrnty);
        }

        // This Method update request for Guarantee details to the table
        public void UpdateRqstForGuarantee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.UpdateRqstForGuarantee(objEntityRqstFrGrnty);
        }

        //Method for cancel request
        public void CancelRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.CancelRequest(objEntityRqstFrGrnty);
        }

        //method for recall request whx=ich is cancelled
        public void ReCallRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.ReCallRequest(objEntityRqstFrGrnty);
        }
        public void ChangeRequestStatus(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.ChangeRequestStatus(objEntityRqstFrGrnty);
        }
        public void ConfirmRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.ConfirmRequest(objEntityRqstFrGrnty);
        }

        public void ReOpenRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.ReOpenRequest(objEntityRqstFrGrnty);
        }
        // This Method will request for guarantee DEATILS BY ID
        public DataTable ReadRqstFrGrntyById(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqById = new DataTable();
            dtReqById = objDataReqstForGrnte.ReadRqstFrGrntyById(objEntityRqstFrGrnty);
            return dtReqById;
        }
        // This Method will fetch job category list
        public DataTable ReadRequestFrGrntyList(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.ReadRequestFrGrntyList(objEntityRqstFrGrnty);
            return dtReqList;
        }
        
        // This Method WILL READ EMPLOYEE BY ID
        public DataTable ReadEmployeeData(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.ReadEmployeeData(objEntityRqstFrGrnty);
            return dtReqList;
        }
                //Method for CLOSE job category
        public void CloseRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            objDataReqstForGrnte.CloseRequest(objEntityRqstFrGrnty);
        }
  // This Method will request for guarantee DEATILS BY ID
        public DataTable ReadpRrojectById(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.ReadpRrojectById(objEntityRqstFrGrnty);
            return dtReqList;
        }
        // METHOD FOR RETREIVE INFO FOR PRINT OUT

        public DataTable ReqgurnteePrint(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)//////////////////2
        {
            DataTable dtprint = new DataTable();
            dtprint = objDataReqstForGrnte.ReqgurnteePrint(objEntityRqstFrGrnty);////////////////////retrieving;
            return dtprint;
        }
        public string ReadBankGuranteeById(classEntityLayerRequestForGrnte objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string GurntNo;
            GurntNo = objDataReqstForGrnte.ReadBankGuranteeById(objEntityBnkGuarnte);
            return GurntNo;
        }
        public string ChkAwardedBiding(classEntityLayerRequestForGrnte objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string ChkGrNo;
            ChkGrNo = objDataReqstForGrnte.ChkAwardedBiding(objEntityBnkGuarnte);
            return ChkGrNo;
        }
         public string ChkCatagory(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string ChkGrNo;
            ChkGrNo = objDataReqstForGrnte.ChkCatagory(objEntityRqstFrGrnty);
            return ChkGrNo;
        }
         // EVM-0016
         public DataTable BindCorptShortName(classEntityLayerRequestForGrnte ObjEntityRFG)
         {
             DataTable dtCorptShortName = new DataTable();
             dtCorptShortName = objDataReqstForGrnte.BindCorptShortName(ObjEntityRFG);
             return dtCorptShortName;
         }
        //EVM-0016

         public DataTable ChekAwardOrBiddg(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.ChekAwardOrBiddg(objEntityRqstFrGrnty);
            return dtReqList;
        }

         public void ChangeReqToProcd(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {

            objDataReqstForGrnte.ChangeReqToProcd(objEntityRqstFrGrnty);
           
        }

         public void ChangeToReissue(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {

            objDataReqstForGrnte.ChangeToReissue(objEntityRqstFrGrnty);
           
        }

         public DataTable ReadRFGStatusdtails(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.ReadRFGStatusdtails(objEntityRqstFrGrnty);
            return dtReqList;
        }

         public DataTable HistoryList(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            DataTable dtReqList = new DataTable();
            dtReqList = objDataReqstForGrnte.HistoryList(objEntityRqstFrGrnty);
            return dtReqList;
        }

         public void UpdateRqstForGuaranteeReissue(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {

            objDataReqstForGrnte.UpdateRqstForGuaranteeReissue(objEntityRqstFrGrnty);
           
        }
    }
}
