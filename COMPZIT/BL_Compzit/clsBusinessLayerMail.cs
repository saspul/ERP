using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using EL_Compzit;


// CREATED BY:EVM-0001
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Business Layer for Mail Sending it select the details of Sender .

namespace BL_Compzit
{
    public class clsBusinessLayerMail
    {
        clsDataLayerMail objDataLayerMail = new clsDataLayerMail();
        //This Method is for selecting the Details of Company
        public DataTable SelectCompanyDetails()
        {
            DataTable dtSelectCmpny = new DataTable();
            dtSelectCmpny = objDataLayerMail.ReadCompanyDetails();
            return dtSelectCmpny;
        }
        //This Method is for Storing the Details to Store Table
        public void InstantMailInsert(string strTempalteId, string strToAddr, string strTransId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
            objDataLayerMail.InsertToStoreDetail(strTempalteId, strToAddr, strTransId, dtCompanyDetails, dtTemplateDetail);
        }

        //methode for fetch the mail details, thay have mails on server
        public DataTable Read_Receive_Mail(int intGetUserId,int intGetOrgId)
        {
            DataTable dtReceiveMail = objDataLayerMail.ReadReceiveMailDetails(intGetUserId, intGetOrgId);
            return dtReceiveMail;
        }
        //add mails from server to the databsse
        public void AddMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttList)
        {
            objDataLayerMail.AddMail(objEntityMail, objEntityMailAttList);
        }
        //fetch the count from mail box for checking mail unique id is there is mail box
        public DataTable SelectUniqueIdCount(clsEntityMailConsole objEntityMail)
        {
            DataTable dtReturn = objDataLayerMail.SelectUniqueIdCount(objEntityMail);
            return dtReturn;
        }
        //fetch configuration details
        public DataTable Read_Configuration()
        {
            DataTable dtConfiguration = objDataLayerMail.ReadConfigurations();
            return dtConfiguration;
        }
        //fetch mail storage from mail storage table
        public DataTable Read_Mail_Storage()
        {
            DataTable dtMailStorage = objDataLayerMail.ReadMailStorage();
            return dtMailStorage;
        }
        //fetch mails from mail box based on mail storage
        public DataTable Read_Mail_Box(clsEntityMailConsole objEntityMail)
        {
            DataTable dtMailBox = objDataLayerMail.Read_Mail_Box(objEntityMail);
            return dtMailBox;
        }
        //fetch mail deatils based on mail id
        public DataTable Read_MailDetails_ById(clsEntityMailConsole objEntityMail)
        {
            DataTable dtMailDtls = objDataLayerMail.Read_Mail_ById(objEntityMail);
            return dtMailDtls;
        }
        //fetch mail attachments based on mail id
        public DataTable Read_Attachments_By_Id(clsEntityMailConsole objEntityMail)
        {
            DataTable dtAttachments = objDataLayerMail.Read_Mail_Attachments(objEntityMail);
            return dtAttachments;
        }
        //allocate mail from inbox to trash
        public void PushToTrash(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.PushToTrash(objEntityMail);
        }
        //change the status of the mail from unread to read
        public void ChangeToRead(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.ChangeToRead(objEntityMail);
        }
        //load divisions as based on the corporate office and organisation id
        public DataTable LoadDivisions(clsEntityMailConsole objEntityMail)
        {
            DataTable dtDivisions = objDataLayerMail.LoadDivisions(objEntityMail);
            return dtDivisions;
        }
        //forward one mail from one division to other division
        public void ForwardMail(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.ForwardMail(objEntityMail);
        }
        //load employees on the basis of user's division
        public DataTable LoadAllocateUser(clsEntityMailConsole objEntityMail)
        {
            DataTable dtUsers = objDataLayerMail.Load_Allocate_User(objEntityMail);
            return dtUsers;
        }
        //allocate a mail to a user
        public void AllocateMail(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.AllocateMail(objEntityMail);
        }
        //reject a mail to its previous position
        public void RejectMail(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.RejectMail(objEntityMail);
        }
        //read customers for load customer drop down list based on organisation and corporate office id
        public DataTable ReadCustomers(clsEntityMailConsole objEntityMail)
        {
            DataTable dtCustomers = objDataLayerMail.ReadCustomers(objEntityMail);
            return dtCustomers;
        }
        //fetch the leads detailos based on date period and user and customer details
        public DataTable Search_Leads(clsEntityMailConsole objEntityMail)
        {
            DataTable dtLeads = objDataLayerMail.SearchLeads(objEntityMail);
            return dtLeads;
        }
        //attach a mail to a lead
        public void MailLeadAttach(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.MailLeadAttach(objEntityMail);
        }
        //read current status of a mail based on mail id
        public DataTable ReadMailSts(clsEntityMailConsole objEntityMail)
        {
            DataTable dtMailSts = objDataLayerMail.Read_Mail_Sts(objEntityMail);
            return dtMailSts;
        }
        //read lead details based on referenc number
        public DataTable ReadLeadByRef(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLead = objDataLayerMail.Read_Lead_By_Ref(objEntityLead);
            return dtLead;
        }
        //TO UPDATE LIMIT EMAIL DATE  TO PREVIOUS DATE IF READED
        public void Update_EmailLimitDate(clsEntityMailConsole objEntityMail)
        {
            objDataLayerMail.Update_EmailLimitDate(objEntityMail);
        }
        //read all valid emails based on division and employees
        public DataTable ReadAllEmails(int intUserId)
        {
            DataTable dtEmails = objDataLayerMail.ReadAllEmails(intUserId);
            return dtEmails;
        }

        //Start:-EMP-0009
        public DataTable ReadPushReason()
        {
            DataTable dtDivisions = objDataLayerMail.ReadPushReason();
            return dtDivisions;
        }
        //End:-EMP-0009
    }

}
