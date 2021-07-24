using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;

namespace BL_Compzit
{
    public class clsBusinessLayerLeadIndividual
    {

        clsDataLayerLeadIndividual objDataLayerLeadIndividual = new clsDataLayerLeadIndividual();
        //for individual List
        public DataTable Read_Indvidual_Lead_List(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_List(objEntityLead);
            return dtList;
        }
        // individual page attachment list
        public DataTable Read_Indvidual_Lead_Atch(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_Atch(objEntityLead);
            return dtList;
        }
        // individual page for quotation list
        public DataTable Read_Indvidual_Lead_Qtan(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_Qtan(objEntityLead);
            return dtList;
        }
        // individual page for mail list
        public DataTable Read_Indvidual_Lead_Mail(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_Mail(objEntityLead);
            return dtList;
        }
        // individual page for TAsk list
        public DataTable Read_Indvidual_Lead_Task(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_Task(objEntityLead);
            return dtList;
        }
        // FOR STATUS TRACKING
        public DataTable Read_Lead_Sts_Track(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Lead_Sts_Track(objEntityLead);
            return dtList;
        }
        // individual page for Follow up list
        public DataTable Read_Indvidual_Lead_Followup(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_Indvidual_Lead_Followup(objEntityLead);
            return dtList;
        }
        // for reading all active LeadSource to show in ddl of FollowUp
        public DataTable Read_LeadSource()
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_LeadSource();
            return dtList;
        }


        //insert into Follow up
        public void InsertFollowUp(clsEntityFollowUp objEntityFollowUp)
        {
            objDataLayerLeadIndividual.InsertFollowUp(objEntityFollowUp);
        }
        // InsertTask     
        public void InsertTask(clsEntityTask objEntityTask)
        {
            objDataLayerLeadIndividual.InsertTask(objEntityTask);
        }
        //UpdateTask
        public void UpdateTask(clsEntityTask objEntityTask)
        {
            objDataLayerLeadIndividual.UpdateTask(objEntityTask);
        }
        //cancel task

        public void DeleteTask(clsEntityTask objEntityTask)
        {
            objDataLayerLeadIndividual.DeleteTask(objEntityTask);
        }
        // for reading all active Task subject to show in ddl of Task
        public DataTable Read_TaskSubject()
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_TaskSubject();
            return dtList;
        }
        // for reading READING LEAD STATUS BY TASK ID     
        public DataTable Read_LeadStatus_By_TaskId(clsEntityTask objEntityTask)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_LeadStatus_By_TaskId(objEntityTask);
            return dtList;
        }
        // for reading all active Reason to show in ddl of Lose Reason
        public DataTable Read_LoseRsn()
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_LoseRsn();
            return dtList;
        }
        // This Method change Lead status to Loss and insert to status tracking table
        public void LossLead(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.LossLead(objEntityLead);
        }
        // This Method change Lead status to Win and insert to status tracking table
        public void WinLead(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.WinLead(objEntityLead);
        }
        // This Method change Lead status to Previous status of lead before close and insert to status tracking table
        public void ReOpenLead(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.ReOpenLead(objEntityLead);
        }
        // METHORD FOR READING ALL USER BASED ON TEAM THE USER IS IN AND THAT HE LEADS 
        public DataTable Read_UserForAllocate(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerLeadIndividual.Read_UserForAllocate(objEntityLead);
            return dtList;
        }
        // This Method change  Active user of lead  and also insert to allocation tracking table
        public void AllocateLead(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.AllocateLead(objEntityLead);
        }
        //fetch 'From Mail' address based on user id
        public DataTable ReadFromMailAddress(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtFromMail = objDataLayerLeadIndividual.ReadFromMailDetails(objEntityLead);
            return dtFromMail;
        }
        //fetch 'To Mail' address based on lead id
        public DataTable ReadToMailAddress(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtToMail = objDataLayerLeadIndividual.ReadToMail(objEntityLead);
            return dtToMail;
        }
        //fetch customer email address based on leads id
        public DataTable ReadOtherToMail(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtToMail = objDataLayerLeadIndividual.ReadOtherToMail(objEntityLead);
            return dtToMail;
        }
        // This Method insert mail and mail attchment details based on lead id
        public void InsertLeadMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachmentList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList, int intSucessSts = 1)
        {
            objDataLayerLeadIndividual.InsertLeadMail(objEntityMail, objEntityMailAttachmentList, objEntityMailCcBCcList, objEntityToMailAddressList, intSucessSts);
        }
        // This Method Update mail and mail attchment details based on lead id
        public void UpdateLeadMail(clsEntityMailConsole objEntityMail, int intSucessSts = 1)
        {
            objDataLayerLeadIndividual.UpdateLeadMail(objEntityMail, intSucessSts);
        }
        //fetch send mail list based on lead id
        public DataTable ReadMailList(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtMailList = objDataLayerLeadIndividual.ReadMailList(objEntityLead);
            return dtMailList;
        }
        //fetch mail attachment  based on mail id
        public DataTable ReadMailAttch_ById(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtMailById = objDataLayerLeadIndividual.ReadMailAttch_ById(objEntityLead);
            return dtMailById;
        }
        //Method of passing the count of customer name that exist in the table
        public string CheckCustomerName(clsEntityCustomer ObjEntityCustomer)
        {
            string strUpdateCount = objDataLayerLeadIndividual.CheckCustomerName(ObjEntityCustomer);
            return strUpdateCount;
        }
        //Method of passing the count of Project name that exist in the table
        public string CheckProjectName(clsEntityProject ObjEntityProject)
        {
            string strUpdateCount = objDataLayerLeadIndividual.CheckProjectName(ObjEntityProject);
            return strUpdateCount;
        }
        //for reject mail from lead
        public void RejectMail(clsEntityLeadCreation obJEntityLead)
        {
            objDataLayerLeadIndividual.RejectMail(obJEntityLead);
        }
        //005 start
        public void InsertQtnAttchmnt(List<clsEntityLayerQuotationAttchmntDtl> objEntityQtnAttchmntDeatilsList)
        {
            objDataLayerLeadIndividual.InsertQtnAttchmnt(objEntityQtnAttchmntDeatilsList);
        }
        public DataTable ReadQuotationAttchmnt(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtQtnAtchDtl = objDataLayerLeadIndividual.ReadQuotationAttchmnt(obJEntityLead);
            return dtQtnAtchDtl;
        }
        public void DeleteQuotationAttachment(clsEntityLeadCreation objEntityLead, string[] strarrCanclAttchIds)
        {
            objDataLayerLeadIndividual.DeleteQuotationAttachment(objEntityLead, strarrCanclAttchIds);

        }
        //FOR FECHING CC mail DETAILS BASED ON CCTEXTBOX CONTENT
        public DataTable ReadMailCcDetail(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtCCDetail = objDataLayerLeadIndividual.ReadMailCcDetail(obJEntityLead);
            return dtCCDetail;
        }
        //FOR FECHING CC mail DETAILS BASED ON PREVIOUS ADDRS
        public DataTable ReadMailCcPreviousAddrs(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtCCDetail = objDataLayerLeadIndividual.ReadMailCcPreviousAddrs(obJEntityLead);
            return dtCCDetail;
        }

        //FOR FECHING CC mail DETAILS BASED ON BCCTEXTBOX CONTENT
        public DataTable ReadMailBCcDetail(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtBCCDetail = objDataLayerLeadIndividual.ReadMailBCcDetail(obJEntityLead);
            return dtBCCDetail;
        }
        //FOR FECHING BCC mail DETAILS BASED ON PREVIOUS ADDRS
        public DataTable ReadMailBCcPreviousAddrs(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtBCCDetail = objDataLayerLeadIndividual.ReadMailBCcPreviousAddrs(obJEntityLead);
            return dtBCCDetail;
        }
        //for fetching SUBJECT FROM LEAD MAIL
        public DataTable ReadMailSubject(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtBCCDetail = objDataLayerLeadIndividual.ReadMailSubject(obJEntityLead);
            return dtBCCDetail;
        }
        //for fetching mail multy to
        public DataTable ReadMailMultyTo(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtBCCDetail = objDataLayerLeadIndividual.ReadMailMultyTo(obJEntityLead);
            return dtBCCDetail;
        }
        //0013 
        public DataTable ProjectLead(clsEntityLeadCreation obJEntityLead)
        {
            DataTable dtProject = objDataLayerLeadIndividual.ProjectLead(obJEntityLead);
            return dtProject;
        }
        //cHANGE Quatation Attachments Status to 1 to  table
        public void ChangeFileMailAtchSts(clsEntityLeadCreation objEntityLead, string[] strarrCanclAttchIds)
        {
            objDataLayerLeadIndividual.ChangeFileMailAtchSts(objEntityLead, strarrCanclAttchIds);
        }
        //EVM0012
        public DataTable Read_ResendMailList(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtMailList = objDataLayerLeadIndividual.Read_ResendMailList(objEntityLead);
            return dtMailList;
        }
        public DataTable ReadExistingEmployee(clsEntityLeadCreation objEntityLead)
        {
            DataTable dteMP = objDataLayerLeadIndividual.ReadExistingEmployee(objEntityLead);
            return dteMP;
        }
        // ToLoad Quotation Status
        public DataTable QuotationStsLead(clsEntityLeadCreation objEntityLead)
        {
            DataTable dteMP = objDataLayerLeadIndividual.QuotationStsLead(objEntityLead);
            return dteMP;
        }
        // To insert Quotation Status
        public void InsertQuotationSts(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.InsertQuotationSts(objEntityLead);

        }
        //QCLD4 EVM0012
        //FOR FECHING QTN ATTACHMENT BACKUP DETAILS BASED ON QTN TYPE AND ID

        public DataTable ReadQuotationAttchmntBackup(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerLeadIndividual.ReadQuotationAttchmntBackup(objEntityLead);
            return dtReadQtnAttchmnt;
        }

        public void InsertPartialWinSts(clsEntityLayerQuotation objEntityQuotation)
        {
            objDataLayerLeadIndividual.InsertPartialWinSts(objEntityQuotation);
        }
        public void InsertLossStsToAllPrdct(clsEntityLeadCreation objEntityLead)
        {
            objDataLayerLeadIndividual.InsertLossStsToAllPrdct(objEntityLead);
        }
    }
}
