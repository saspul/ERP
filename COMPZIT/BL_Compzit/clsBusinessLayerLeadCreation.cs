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
    public class clsBusinessLayerLeadCreation
    {
        clsDataLayerLeadCreation objDataLayerLead = new clsDataLayerLeadCreation();

        //Method for passing Lead Source table from datalayer to uilayer.
        public DataTable ReadLeadSource(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadSource = objDataLayerLead.ReadLeadSource(objEntityLead);
            return dtLeadSource;
        }

        //Method for passing country table from datalayer to uilayer.
        public DataTable ReadCountry()
        {
            DataTable dtReadCountry = objDataLayerLead.ReadCountry();
            return dtReadCountry;
        }
        //Method for passing state details in between the datalayer and ui layer.
        public DataTable ReadState(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadState = objDataLayerLead.ReadState(objEntityLead);
            return dtReadState;
        }
        //Method for passing city details in between the datalayer and ui layer.
        public DataTable ReadCity(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadCity = objDataLayerLead.ReadCity(objEntityLead);
            return dtReadCity;
        }

        //Method for passing Name prefix table from datalayer to uilayer.
        public DataTable ReadNamePrefix(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtNamePrefix = objDataLayerLead.ReadNamePrefix(objEntityLead);
            return dtNamePrefix;
        }

        //Method for passing LEad Rating table from datalayer to uilayer.
        public DataTable ReadLeadRating(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadRating = objDataLayerLead.ReadLeadRating(objEntityLead);
            return dtLeadRating;
        }
        //Method for passing Team table from datalayer to uilayer.
        public DataTable ReadTeamSelect(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtTeam = objDataLayerLead.ReadTeamSelect(objEntityLead);
            return dtTeam;
        }

        //Method for passing Corp Division from datalayer to uilayer.
        public DataTable ReadCorpDivision(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtDiv = objDataLayerLead.ReadCorpDivision(objEntityLead);
            return dtDiv;
        }

        //Method of adding lead details to the tables : leads, media, contact
        public void AddLead(clsEntityLeadCreation ObjEntityLead, List<clsEntityLeadCreation> objEntityContact, List<clsEntityLeadCreation> objEntityMedia, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDetails)
        {
            objDataLayerLead.AddLead(ObjEntityLead, objEntityContact, objEntityMedia, objEntityLeadAttchmntDetails);
        }
        //fetch media master from databse
        public DataTable Read_Media_Master()
        {
            DataTable dtMediaMaster = objDataLayerLead.Read_Media_Master();
            return dtMediaMaster;
        }

        public DataTable LeadList(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadList = objDataLayerLead.LeadList(objEntityLead);
            return dtLeadList;
        }
        public DataTable Read_Lead_ById(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadLead = objDataLayerLead.Read_Lead_ById(objEntityLead);
            return dtReadLead;
        }
        public DataTable Read_Contact_ById(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadLead = objDataLayerLead.Read_Contact_ById(objEntityLead);
            return dtReadLead;
        }

        public DataTable Read_Media_ById(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMedia = objDataLayerLead.Read_Media_ById(objEntityLead);
            return dtReadMedia;
        }
        public void UpdateLead(clsEntityLeadCreation ObjEntityLead, List<clsEntityLeadCreation> objEntityContact, List<clsEntityLeadCreation> objEntityMedia, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntINSERTDetails, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDELETEDetails)
        {
            objDataLayerLead.UpdateLead(ObjEntityLead, objEntityContact, objEntityMedia, objEntityLeadAttchmntINSERTDetails, objEntityLeadAttchmntDELETEDetails);
        }
        public DataTable Read_Customer_List_BySearch(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMedia = objDataLayerLead.Read_Customer_List_BySearch(objEntityLead);
            return dtReadMedia;
        }
        // for dash bord wise listing NEW,ACTIVE,APPROVED
        public DataTable Read_Customer_List_Indvl_BySearch(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMedia = objDataLayerLead.Read_Customer_List_Indvl_BySearch(objEntityLead);
            return dtReadMedia;
        }
        // for dash bord wise listing monthly sucess,lostlead
        public DataTable Read_Customer_List_Indvl_Mnthly_BySearch(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMedia = objDataLayerLead.Read_Customer_List_Indvl_Mnthly_BySearch(objEntityLead);
            return dtReadMedia;
        }
       //methode for fetch mail details based on mail id
        public DataTable ReadMailDetails(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtMail = objDataLayerLead.ReadMailDetails(objEntityLead);
            return dtMail;
        }
        // This Method FETCHES LEAD ATTACHMENTS BASED ON LEAD ID FROM GN_LEADS_ATTACHMENTS
        public DataTable ReadLeadAttchmnt(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadAttchmnt = objDataLayerLead.ReadLeadAttchmnt(objEntityLead);
            return dtReadAttchmnt;
        }
        //Method for FOR READING CUSTOMERS FOR LISTING FOR EXISTING CUSTOMERS.
        public DataTable ReadExistingCustomers(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadCust= objDataLayerLead.ReadExistingCustomers(objEntityLead);
            return dtLeadCust;
        }
        //Method of passing customer master table data from datalayer to ui layer
        public DataTable ReadCustomerById(clsEntityCustomer ObjEntityCustomer)
        {
            DataTable dtReadsupplier = objDataLayerLead.ReadCustomerById(ObjEntityCustomer);
            return dtReadsupplier;
        }

        //read customer contact details based on customer id
        public DataTable Read_Contact_ById(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtContact = objDataLayerLead.Read_Contact_DetailsById(objEntityCustomer);
            return dtContact;
        }

        //read customer media details based on customer id 
        public DataTable Read_Media_ById(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtMedia = objDataLayerLead.Read_Media_DetailsById(objEntityCustomer);
            return dtMedia;
        }

        //Method for passing Lead Status table from datalayer to uilayer.
        public DataTable ReadLeadStatus(string strSts)
        {
            DataTable dtLeadSts = objDataLayerLead.ReadLeadStatus( strSts);
            return dtLeadSts;
        }
        //Method for FOR READING CLIENT FOR LISTING FOR EXISTING CLIENTS.
        public DataTable ReadExistingClients(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadCust = objDataLayerLead.ReadExistingClients(objEntityLead);
            return dtLeadCust;
        }
        //Method READING CONTRACTOR FOR LISTING FOR EXISTING CONTRACTOR.
        public DataTable ReadExistingContractors(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadCust = objDataLayerLead.ReadExistingContractors(objEntityLead);
            return dtLeadCust;
        }
        //Method forREADING CONSULTANT FOR LISTING FOR EXISTING CONSULTANTS.
        public DataTable ReadExistingConsultants(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadCust = objDataLayerLead.ReadExistingConsultants(objEntityLead);
            return dtLeadCust;
        }
        //Method for READING PROJECT FOR LISTING FOR EXISTING PROJECTS.
        public DataTable ReadExistingProjects(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtPrjct = objDataLayerLead.ReadExistingProjects(objEntityLead);
            return dtPrjct;
        }


        public DataTable Read_Pending_Lead_Detail_ByTeam(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMedia = objDataLayerLead.Read_Pending_Lead_Detail_ByTeam(objEntityLead);
            return dtReadMedia;
        }


        //read mail attachement based on the mail id
        public DataTable Read_Mail_Attachment(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtAttch = objDataLayerLead.ReadMailAttachment(objEntityLead);
            return dtAttch;
        }

        //evm0012
        // method READING PROJECT detail
        public DataTable ReadProjectDetails(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtProjectDetails = objDataLayerLead.ReadProjectDetails(objEntityLead);
            return dtProjectDetails;
        }
        public DataTable ReadProjectStatus(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtProjectDetails = objDataLayerLead.ReadProjectStatus(objEntityLead);
            return dtProjectDetails;
        }
    }
}

