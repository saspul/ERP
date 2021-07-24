
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
    public class clsBusinessLayerBankGuarantee
    {

        clsDataLayerBankGuarantee objDataBankGuarnt = new clsDataLayerBankGuarantee();
        public DataTable GuaranteeMode(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.GuaranteeMode(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadSubContract(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadSubContract(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadBankLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadBankLoad(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadCurrency(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadCurrency(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadEmployee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadEmployee(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadEmployeeData(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadEmployeeData(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadcusAddress(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadcusAddress(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public void AddBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.AddBankGuarantee(objEntityBnkGuarnte);

        }
        public DataTable Read_Attachment(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.Read_Attachment(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public void Add_Pictures(clsEntityLayerBankGuarantee objEntityBnkGuarnte, List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuranteeAtchmntDtlList)
        {

            objDataBankGuarnt.Add_Pictures(objEntityBnkGuarnte, objEntityLayerGuranteeAtchmntDtlList);

        }
        public void Delete_Pictures(clsEntityLayerBankGuarantee objEntityBnkGuarnte, List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuranteeAtchmntDtlList)
        {

            objDataBankGuarnt.Delete_Pictures(objEntityBnkGuarnte, objEntityLayerGuranteeAtchmntDtlList);

        }
        public DataTable GuaranteeModeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.GuaranteeModeList(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadSuplierLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadSuplierLoad(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadCustomerLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadCustomerLoad(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadRequestGuaranteeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadRequestGuaranteeList(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadGuranteeById(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadGuranteeById(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable Read_Picture(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.Read_Picture(objEntityBnkGuarnte);
            return dtGuarnt;
        }


        public void UpdateBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.UpdateBankGuarantee(objEntityBnkGuarnte);

        }
        public void CancelRequest(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.CancelRequest(objEntityBnkGuarnte);

        }

        public void ReCallRequest(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.ReCallRequest(objEntityBnkGuarnte);

        }

        public string ChckDuplGurntNo(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string GurntNo;
            GurntNo = objDataBankGuarnt.ChckDuplGurntNo(objEntityBnkGuarnte);
            return GurntNo;
        }

        public void ConfirmBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.ConfirmBankGuarantee(objEntityBnkGuarnte);

        }
        public void ReOpenRequest(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.ReOpenRequest(objEntityBnkGuarnte);

        }

        public void CloseRequest(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.CloseRequest(objEntityBnkGuarnte);

        }

        public void RenewBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.RenewBankGuarantee(objEntityBnkGuarnte);

        }

        public DataTable ChkConfirmBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ChkConfirmBankGuarantee(objEntityBnkGuarnte);
            return dtGuarnt;
        }


        public DataTable ReadRequesClienttGuaranteeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadRequesClienttGuaranteeList(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadRequestByID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadRequestByID(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable GuaranteeModeClient(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.GuaranteeModeClient(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable ReadDefualtCurrency(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadDefualtCurrency(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public string ChckDupReqstId(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string GurntNo;
            GurntNo = objDataBankGuarnt.ChckDupReqstId(objEntityBnkGuarnte);
            return GurntNo;
        }

        public void UpdateReqstGuarnteStats(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.UpdateReqstGuarnteStats(objEntityBnkGuarnte);

        }

        public void UpdateReqstGuarnteStatsonReopn(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.UpdateReqstGuarnteStatsonReopn(objEntityBnkGuarnte);

        }


        public DataTable ReadNotifyTemplates(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadNotifyTemplates(objEntityBnkGuarnte);
            return dtGuarnt;

        }
        public DataTable ReadDefaultNotifyTemplates(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadDefaultNotifyTemplates(objEntityBnkGuarnte);
            return dtGuarnt;

        }
        // This Method adds template details to the table
        public void AddTemplateDetail(clsEntityLayerBankGuarantee objEntityBnkGuarnte, BnkGrntyTemplateDetail objEntityNotTempDetail, List<BnkGrntyTemplateAlert> objEntityTempAlertList)
        {
            objDataBankGuarnt.AddTemplateDetail(objEntityBnkGuarnte, objEntityNotTempDetail, objEntityTempAlertList);

        }

        // This Method will fetCH template DEATILS table BY ID
        public DataTable ReadTemplateDetailById(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadTemplateDetailById(objEntityBnkGuarnte);
            return dtGuarnt;

        }
        //this table will fetch template alert table datas
        public DataTable ReadTemplateAlertById(BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadTemplateAlertById(objEntityNotTempDetail);
            return dtGuarnt;

        }
        // This Method Update template detail table
        public void UpdateNotifyTemplateDetail(BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            objDataBankGuarnt.UpdateNotifyTemplateDetail(objEntityNotTempDetail);

        }

        // This Method Update template alert table
        public void UpdateNotifyTemplateAlert(BnkGrntyTemplateAlert objEntityTempAlert, BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            objDataBankGuarnt.UpdateNotifyTemplateAlert(objEntityTempAlert, objEntityNotTempDetail);

        }
        // This Method DELETE ALERT details OF the table
        public void DeleteTemplateAlert(List<BnkGrntyTemplateAlert> objEntityTempAlertList)
        {
            objDataBankGuarnt.DeleteTemplateAlert(objEntityTempAlertList);

        }
         // This Method DELETE DETAIL DATA details OF the table
        public void DeleteTemplateDetByGr(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            objDataBankGuarnt.DeleteTemplateDetByGr(objEntityBnkGuarnte);

        }
         // This Method DELETE ALERT details OF the table
        public void DeleteTemplateAlertByGr(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            objDataBankGuarnt.DeleteTemplateAlertByGr(objEntityBnkGuarnte);

        }
        // This Method adds job category details to the table
        public void AddTemplateAlert(List<BnkGrntyTemplateAlert> objEntityTempAlertList, clsEntityLayerBankGuarantee objEntityBnkGuarnte, BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            objDataBankGuarnt.AddTemplateAlert(objEntityTempAlertList, objEntityBnkGuarnte, objEntityNotTempDetail);

        }
        public string ChkCatagory(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string GurntNo;
            GurntNo = objDataBankGuarnt.ChkCatagory(objEntityBnkGuarnte);
            return GurntNo;
        }
        public void MailStatusChange(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {

            objDataBankGuarnt.MailStatusChange(objEntityBnkGuarnte);

        }

        public string ChckDuplRFQIdChek(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            // DataTable dtGuarnt = new DataTable();
            string GurntNo;
            GurntNo = objDataBankGuarnt.ChckDuplRFQIdChek(objEntityBnkGuarnte);
            return GurntNo;
        }
        // This Method will fetch Guarantee Type list
        public DataTable GteeTypeClient(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtCategory = new DataTable();
            dtCategory = objDataBankGuarnt.GteeTypeClient(objEntityBnkGuarnte);
            return dtCategory;
        }
        //READ PROJECTS BY GTEE TYPE ID
        public DataTable ReadProjectGteeTypeID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtProject = new DataTable();
            dtProject = objDataBankGuarnt.ReadProjectGteeTypeID(objEntityBnkGuarnte);
            return dtProject;
        }
        //READ Customer Address BY Customer ID
        public DataTable ReadCustomerAddrByID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtProject = new DataTable();
            dtProject = objDataBankGuarnt.ReadCustomerAddrByID(objEntityBnkGuarnte);
            return dtProject;
        }
        //READ Customer Address, Customer ID BY PROJECT ID
        public DataTable ReadCustomerDtlByPrjID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtCustomerDtl = new DataTable();
            dtCustomerDtl = objDataBankGuarnt.ReadCustomerDtlByPrjID(objEntityBnkGuarnte);
            return dtCustomerDtl;
        }
        public DataTable ReadAlertsByGteeID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGteeAlerts = new DataTable();
            dtGteeAlerts = objDataBankGuarnt.ReadAlertsByGteeID(objEntityBnkGuarnte);
            return dtGteeAlerts;
        }

        public DataTable ReadRequestGuaranteeList1(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGteeAlerts = new DataTable();
            dtGteeAlerts = objDataBankGuarnt.ReadRequestGuaranteeList1(objEntityBnkGuarnte);
            return dtGteeAlerts;
        }

        public DataTable ReadPolicyNumLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataBankGuarnt.ReadPolicyNumLoad(objEntityBnkGuarnte);
            return dtGuarnt;
        }
    }
}
