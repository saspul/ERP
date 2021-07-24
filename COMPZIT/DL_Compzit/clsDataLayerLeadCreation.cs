using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using CL_Compzit;
using Oracle.DataAccess.Client;

namespace DL_Compzit
{
    public class clsDataLayerLeadCreation
    {
        //METHOD TO FETCH LEAD SOURCE RORM THE TABLE
        public DataTable ReadLeadSource(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadLeadSource = "LEAD.SP_READ_LEAD_SOURCE";
            using (OracleCommand cmdReadLeadSource = new OracleCommand())
            {
                cmdReadLeadSource.CommandText = strQueryReadLeadSource;
                cmdReadLeadSource.CommandType = CommandType.StoredProcedure;
                cmdReadLeadSource.Parameters.Add("L_SOURCE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSource = new DataTable();
                dtLeadSource = clsDataLayer.SelectDataTable(cmdReadLeadSource);
                return dtLeadSource;
            }
        }
        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "LEAD.SP_READ_COUNTRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Methode for fetch state master details of selected country from database.
        public DataTable ReadState(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadState = "LEAD.SP_READ_STATE";
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryReadState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityLead.CountryId;
                cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadState = new DataTable();
                dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                return dtReadState;
            }
        }
        //Method for fetch city master details of selected state from datatbase.
        public DataTable ReadCity(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadState = "LEAD.SP_READ_CITY";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityLead.StateId;
                cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }
        // method to fetch name prefix
        public DataTable ReadNamePrefix(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadNamePrefix = "LEAD.SP_READ_NAME_PREFIX";
            using (OracleCommand cmdReadNamePrefix = new OracleCommand())
            {
                cmdReadNamePrefix.CommandText = strQueryReadNamePrefix;
                cmdReadNamePrefix.CommandType = CommandType.StoredProcedure;
                cmdReadNamePrefix.Parameters.Add("L_PREFIX", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtNamePrefix = new DataTable();
                dtNamePrefix = clsDataLayer.SelectDataTable(cmdReadNamePrefix);
                return dtNamePrefix;
            }
        }
        // method to fetch Lead ratings from table
        public DataTable ReadLeadRating(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadLeadRating = "LEAD.SP_READ_LEAD_RATING";
            using (OracleCommand cmdReadLeadRating = new OracleCommand())
            {
                cmdReadLeadRating.CommandText = strQueryReadLeadRating;
                cmdReadLeadRating.CommandType = CommandType.StoredProcedure;
                cmdReadLeadRating.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadLeadRating.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadLeadRating.Parameters.Add("L_LEADRATING", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadRating = new DataTable();
                dtLeadRating = clsDataLayer.SelectDataTable(cmdReadLeadRating);
                return dtLeadRating;
            }
        }
        // method to fetch Teams from table
        public DataTable ReadTeamSelect(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadTeam = "LEAD.SP_READ_TEAM_OF_USER";
            using (OracleCommand cmdReadTeam = new OracleCommand())
            {
                cmdReadTeam.CommandText = strQueryReadTeam;
                cmdReadTeam.CommandType = CommandType.StoredProcedure;
                cmdReadTeam.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadTeam.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadTeam.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                cmdReadTeam.Parameters.Add("L_TEAM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadTeam = new DataTable();
                dtReadTeam = clsDataLayer.SelectDataTable(cmdReadTeam);
                return dtReadTeam;
            }
        }
        // method to fetch cORP dIVISONS from table
        public DataTable ReadCorpDivision(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadDivision = "LEAD.SP_READ_CORP_DIVISION_OF_USER";
            using (OracleCommand cmdReadDivision = new OracleCommand())
            {
                cmdReadDivision.CommandText = strQueryReadDivision;
                cmdReadDivision.CommandType = CommandType.StoredProcedure;
                cmdReadDivision.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadDivision.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadDivision.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                cmdReadDivision.Parameters.Add("L_DIVSN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadDiv = new DataTable();
                dtReadDiv = clsDataLayer.SelectDataTable(cmdReadDivision);
                return dtReadDiv;
            }
        }
        //Method of adding lead details to the tables : leads, media, contact
        public void AddLead(clsEntityLeadCreation ObjEntityLead, List<clsEntityLeadCreation> objEntityContact, List<clsEntityLeadCreation> objEntityMedia, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDetails)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddLead = "LEAD.SP_INSERT_LEAD";
                    using (OracleCommand cmdAddLead = new OracleCommand(strQueryAddLead, con))
                    {

                        cmdAddLead.CommandType = CommandType.StoredProcedure;
                        ////generate next value
                        //clsDataLayer objDataLayer = new clsDataLayer();
                        //clsEntityCommon objCommon = new clsEntityCommon();
                        //objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAD);
                        //objCommon.CorporateID = ObjEntityLead.Corp_Id;
                        //objCommon.WrkAreaId = ObjEntityLead.WorkAreaId;
                        //string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);



                        //ObjEntityLead.LeadId = Convert.ToInt32(strNextValue);
                        ObjEntityLead.Ref_Id = ObjEntityLead.LeadId;
                        cmdAddLead.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;

                        cmdAddLead.Parameters.Add("L_LEADREFNO", OracleDbType.Int32).Value = ObjEntityLead.Ref_Id;

                        cmdAddLead.Parameters.Add("L_LDSRCEID", OracleDbType.Int32).Value = ObjEntityLead.LeadSourceId;
                        cmdAddLead.Parameters.Add("L_LEADDATE", OracleDbType.Date).Value = ObjEntityLead.LeadDate;
                        cmdAddLead.Parameters.Add("L_DECPTN", OracleDbType.Clob).Value = ObjEntityLead.Description;
                        if (ObjEntityLead.NamePrefix_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_NAMPRFXID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_NAMPRFXID", OracleDbType.Int32).Value = ObjEntityLead.NamePrefix_Id;
                        }
                        cmdAddLead.Parameters.Add("L_CUSTNAME", OracleDbType.Varchar2).Value = ObjEntityLead.Customer_Name;
                        cmdAddLead.Parameters.Add("L_DIVID", OracleDbType.Int32).Value = ObjEntityLead.DivisionId;
                        cmdAddLead.Parameters.Add("L_TITLE", OracleDbType.Varchar2).Value = ObjEntityLead.Title;
                        cmdAddLead.Parameters.Add("L_TEAMID", OracleDbType.Varchar2).Value = ObjEntityLead.Team;
                        cmdAddLead.Parameters.Add("L_COMMENTS", OracleDbType.Varchar2).Value = ObjEntityLead.Comments;
                        if (ObjEntityLead.Project != "")
                        {
                            cmdAddLead.Parameters.Add("L_PROJECT", OracleDbType.Varchar2).Value = ObjEntityLead.Project;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_PROJECT", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityLead.Client != "")
                        {
                            cmdAddLead.Parameters.Add("L_CLIENT", OracleDbType.Varchar2).Value = ObjEntityLead.Client;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CLIENT", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityLead.Contractor != "")
                        {
                            cmdAddLead.Parameters.Add("L_CONTRACTOR", OracleDbType.Varchar2).Value = ObjEntityLead.Contractor;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CONTRACTOR", OracleDbType.Varchar2).Value = null;
                        }

                        if (ObjEntityLead.Consultant != "")
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTANT", OracleDbType.Varchar2).Value = ObjEntityLead.Consultant;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CONSULTANT", OracleDbType.Varchar2).Value = null;
                        }


                        cmdAddLead.Parameters.Add("L_ADD1", OracleDbType.Varchar2).Value = ObjEntityLead.Address1;
                        cmdAddLead.Parameters.Add("L_ADD2", OracleDbType.Varchar2).Value = ObjEntityLead.Address2;
                        cmdAddLead.Parameters.Add("L_ADD3", OracleDbType.Varchar2).Value = ObjEntityLead.Address3;
                        if (ObjEntityLead.CountryId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CNTRYID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CNTRYID", OracleDbType.Int32).Value = ObjEntityLead.CountryId;
                        }
                        if (ObjEntityLead.StateId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_STATEID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_STATEID", OracleDbType.Int32).Value = ObjEntityLead.StateId;
                        }
                        if (ObjEntityLead.CityId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CITYID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CITYID", OracleDbType.Int32).Value = ObjEntityLead.CityId;
                        }
                        cmdAddLead.Parameters.Add("L_ZIPCODE", OracleDbType.Varchar2).Value = ObjEntityLead.ZipCode;
                        cmdAddLead.Parameters.Add("L_TINNO", OracleDbType.Varchar2).Value = ObjEntityLead.TinNumber;
                        cmdAddLead.Parameters.Add("L_MOBNO", OracleDbType.Varchar2).Value = ObjEntityLead.Mobile;
                        cmdAddLead.Parameters.Add("L_PHONENUM", OracleDbType.Varchar2).Value = ObjEntityLead.Phone;
                        cmdAddLead.Parameters.Add("L_EMAIL", OracleDbType.Varchar2).Value = ObjEntityLead.Email;
                        cmdAddLead.Parameters.Add("L_WEB", OracleDbType.Varchar2).Value = ObjEntityLead.Web;
                        cmdAddLead.Parameters.Add("L_LEADRATEID", OracleDbType.Int32).Value = ObjEntityLead.LeadRating;
                        cmdAddLead.Parameters.Add("L_LEADSTSID", OracleDbType.Int32).Value = ObjEntityLead.Status;
                        cmdAddLead.Parameters.Add("L_LDACTUSRID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                        cmdAddLead.Parameters.Add("L_INSUSRID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                     
                        cmdAddLead.Parameters.Add("L_LDMLBOXID", OracleDbType.Int64).Value = ObjEntityLead.MailBoxId;
                        cmdAddLead.Parameters.Add("L_FINCYR_ID", OracleDbType.Int32).Value = ObjEntityLead.FinYearId;
                        cmdAddLead.Parameters.Add("L_LDSDIVCOD", OracleDbType.Varchar2).Value = ObjEntityLead.DivisionCode;
                        cmdAddLead.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                        cmdAddLead.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLead.Org_Id;
                        if (ObjEntityLead.Customer_Id == 0)
                            cmdAddLead.Parameters.Add("L_CSTMRID", OracleDbType.Int32).Value = null;
                        else
                            cmdAddLead.Parameters.Add("L_CSTMRID", OracleDbType.Int32).Value = ObjEntityLead.Customer_Id;

                        if (ObjEntityLead.Project_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = ObjEntityLead.Project_Id;
                        }
                        if (ObjEntityLead.Client_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CLIENTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CLIENTID", OracleDbType.Int32).Value = ObjEntityLead.Client_Id;
                        }
                        if (ObjEntityLead.Contractor_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CONTRCTRID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CONTRCTRID", OracleDbType.Int32).Value = ObjEntityLead.Contractor_Id;
                        }
                        if (ObjEntityLead.Consultant_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTNTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTNTID", OracleDbType.Int32).Value = ObjEntityLead.Consultant_Id;
                        }
                        if (ObjEntityLead.ProjectStatus == 0)
                        {
                            cmdAddLead.Parameters.Add("L_GUARNTMODE_ID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_GUARNTMODE_ID", OracleDbType.Int32).Value = ObjEntityLead.ProjectStatus;
                        }
                        //L_GUARNTMODE_ID

                        cmdAddLead.ExecuteNonQuery();
                    }
                    //insert lead extra contact details to the table
                    foreach (clsEntityLeadCreation objContact in objEntityContact)
                    {
                        string strQueryInsertContactDetail = "LEAD.SP_INSERT_NEW_CONTACT";
                        using (OracleCommand cmdAddInsertContactDetail = new OracleCommand(strQueryInsertContactDetail, con))
                        {
                            cmdAddInsertContactDetail.Transaction = tran;

                            cmdAddInsertContactDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertContactDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDSID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTNAME", OracleDbType.Varchar2).Value = objContact.Customer_Name;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTADRS", OracleDbType.Varchar2).Value = objContact.Address1;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTMOB", OracleDbType.Varchar2).Value = objContact.Mobile;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTPHONE", OracleDbType.Varchar2).Value = objContact.Phone;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTEMAIL", OracleDbType.Varchar2).Value = objContact.Email;
                            cmdAddInsertContactDetail.Parameters.Add("L_EMAILAlWD", OracleDbType.Int32).Value = objContact.MailSendAllwd;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTWEB", OracleDbType.Varchar2).Value = objContact.Web;

                            cmdAddInsertContactDetail.ExecuteNonQuery();
                        }
                    }
                    //insert customer media details to the table
                    foreach (clsEntityLeadCreation objMedia in objEntityMedia)
                    {
                        if (objMedia.Media_Description != "" && objMedia.Media_Description != null)
                        {
                            string strQueryInsertMediaDetail = "LEAD.SP_INSERT_MEDIA_DETAILS";
                            using (OracleCommand cmdAddInsertMediaDetail = new OracleCommand(strQueryInsertMediaDetail, con))
                            {
                                cmdAddInsertMediaDetail.Transaction = tran;

                                cmdAddInsertMediaDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertMediaDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                                cmdAddInsertMediaDetail.Parameters.Add("L_MEDIAID", OracleDbType.Int32).Value = objMedia.Media_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("L_DESCRIPTION", OracleDbType.Varchar2).Value = objMedia.Media_Description;
                                cmdAddInsertMediaDetail.ExecuteNonQuery();
                            }
                        }
                    }



                    //insert to  Lead attachment table
                    foreach (clsEntityLayerLeadAttchmntDtl objAttchDetail in objEntityLeadAttchmntDetails)
                    {

                        string strQueryInsertAttchmntDetail = "LEAD.SP_INSERT_LEAD_ATTACHMENT";
                        using (OracleCommand cmdAddInsertAttchmntDetail = new OracleCommand(strQueryInsertAttchmntDetail, con))
                        {
                            cmdAddInsertAttchmntDetail.Transaction = tran;

                            cmdAddInsertAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_ACTUALFNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.LeadAttchmntSlNumber;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_DATE", OracleDbType.Date).Value = ObjEntityLead.InsertDate;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                            cmdAddInsertAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //insert a row in the status tracking table as new status
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.New);
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = ObjEntityLead.InsertDate;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }
                    if (ObjEntityLead.MailBoxId != 0)
                    {
                        //insert a row in the status tracking table as new status
                        string strQueryUpdateMailActionSts = "MAIL.SP_UPD_MAIL_ACTIONSTS";
                        using (OracleCommand cmdUpdMailBoxActnSts = new OracleCommand(strQueryUpdateMailActionSts, con))
                        {
                            cmdUpdMailBoxActnSts.Transaction = tran;

                            cmdUpdMailBoxActnSts.CommandType = CommandType.StoredProcedure;
                            cmdUpdMailBoxActnSts.Parameters.Add("M_ID", OracleDbType.Int64).Value = ObjEntityLead.MailBoxId;
                            cmdUpdMailBoxActnSts.Parameters.Add("M_USERID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                            cmdUpdMailBoxActnSts.Parameters.Add("M_ACTNID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Mail_Actions.Lead);
                            cmdUpdMailBoxActnSts.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }
        //fetch media master  

        public DataTable Read_Media_Master()
        {
            string strQueryMediaMaster = "LEAD.SP_READ_MEDIA_MASTER";
            OracleCommand cmdReadMediaMaster = new OracleCommand();
            cmdReadMediaMaster.CommandText = strQueryMediaMaster;
            cmdReadMediaMaster.CommandType = CommandType.StoredProcedure;
            cmdReadMediaMaster.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMedia = new DataTable();
            dtMedia = clsDataLayer.ExecuteReader(cmdReadMediaMaster);
            return dtMedia;
        }
        public DataTable LeadList(clsEntityLeadCreation objEntityLead)
        {

            string strQueryLeadList = "LEAD.SP_READ_LEAD_LIST";
            DataTable dtLeadTable = new DataTable();
            using (OracleCommand cmdReadLead = new OracleCommand())
            {
                cmdReadLead.CommandText = strQueryLeadList;
                cmdReadLead.CommandType = CommandType.StoredProcedure;
                cmdReadLead.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                cmdReadLead.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadLead.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadLead.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLeadTable = clsDataLayer.ExecuteReader(cmdReadLead);
            }
            return dtLeadTable;
        }
        public DataTable Read_Lead_ById(clsEntityLeadCreation objEntityLead)
        {

            string strQueryLeadList = "LEAD.SP_READ_LEAD_BYID";
            DataTable dtLeadTable = new DataTable();
            using (OracleCommand cmdReadLead = new OracleCommand())
            {
                cmdReadLead.CommandText = strQueryLeadList;
                cmdReadLead.CommandType = CommandType.StoredProcedure;
                cmdReadLead.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                cmdReadLead.Parameters.Add("L_LEAD", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLeadTable = clsDataLayer.ExecuteReader(cmdReadLead);
            }
            return dtLeadTable;
        }
        public DataTable Read_Contact_ById(clsEntityLeadCreation objEntityLead)
        {

            string strQueryLeadList = "LEAD.SP_READ_LEAD_CONTACT_BYID";
            DataTable dtLeadTable = new DataTable();
            using (OracleCommand cmdReadLead = new OracleCommand())
            {
                cmdReadLead.CommandText = strQueryLeadList;
                cmdReadLead.CommandType = CommandType.StoredProcedure;
                cmdReadLead.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                cmdReadLead.Parameters.Add("L_LEAD", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLeadTable = clsDataLayer.ExecuteReader(cmdReadLead);
            }
            return dtLeadTable;
        }
        public DataTable Read_Media_ById(clsEntityLeadCreation objEntityLead)
        {
            string strQueryLeadList = "LEAD.SP_READ_MEDIA_BYID";
            DataTable dtLeadTable = new DataTable();
            using (OracleCommand cmdReadLead = new OracleCommand())
            {
                cmdReadLead.CommandText = strQueryLeadList;
                cmdReadLead.CommandType = CommandType.StoredProcedure;
                cmdReadLead.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                cmdReadLead.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLeadTable = clsDataLayer.ExecuteReader(cmdReadLead);
            }
            return dtLeadTable;
        }
        public void UpdateLead(clsEntityLeadCreation ObjEntityLead, List<clsEntityLeadCreation> objEntityContact, List<clsEntityLeadCreation> objEntityMedia, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntINSERTDetails, List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDELETEDetails)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddLead = "LEAD.SP_UPDATE_LEAD";
                    using (OracleCommand cmdAddLead = new OracleCommand(strQueryAddLead, con))
                    {

                        cmdAddLead.CommandType = CommandType.StoredProcedure;
                        ObjEntityLead.Ref_Id = ObjEntityLead.LeadId;
                        cmdAddLead.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;

                        cmdAddLead.Parameters.Add("L_LEADREFNO", OracleDbType.Int32).Value = ObjEntityLead.Ref_Id;

                        cmdAddLead.Parameters.Add("L_LDSRCEID", OracleDbType.Int32).Value = ObjEntityLead.LeadSourceId;
                        cmdAddLead.Parameters.Add("L_LEADDATE", OracleDbType.Date).Value = ObjEntityLead.LeadDate;
                        cmdAddLead.Parameters.Add("L_DECPTN", OracleDbType.Clob).Value = ObjEntityLead.Description;
                        if (ObjEntityLead.NamePrefix_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_NAMPRFXID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_NAMPRFXID", OracleDbType.Int32).Value = ObjEntityLead.NamePrefix_Id;
                        }

                        cmdAddLead.Parameters.Add("L_CUSTNAME", OracleDbType.Varchar2).Value = ObjEntityLead.Customer_Name;
                        cmdAddLead.Parameters.Add("L_DIVID", OracleDbType.Int32).Value = ObjEntityLead.DivisionId;
                        cmdAddLead.Parameters.Add("L_TITLE", OracleDbType.Varchar2).Value = ObjEntityLead.Title;
                        cmdAddLead.Parameters.Add("L_TEAMID", OracleDbType.Varchar2).Value = ObjEntityLead.Team;
                        cmdAddLead.Parameters.Add("L_COMMENTS", OracleDbType.Varchar2).Value = ObjEntityLead.Comments;

                        if (ObjEntityLead.Project != "")
                        {
                            cmdAddLead.Parameters.Add("L_PROJECT", OracleDbType.Varchar2).Value = ObjEntityLead.Project;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_PROJECT", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityLead.Client != "")
                        {
                            cmdAddLead.Parameters.Add("L_CLIENT", OracleDbType.Varchar2).Value = ObjEntityLead.Client;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CLIENT", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityLead.Contractor != "")
                        {
                            cmdAddLead.Parameters.Add("L_CONTRACTOR", OracleDbType.Varchar2).Value = ObjEntityLead.Contractor;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CONTRACTOR", OracleDbType.Varchar2).Value = null;
                        }

                        if (ObjEntityLead.Consultant != "")
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTANT", OracleDbType.Varchar2).Value = ObjEntityLead.Consultant;
                        }
                        else
                        {

                            cmdAddLead.Parameters.Add("L_CONSULTANT", OracleDbType.Varchar2).Value = null;
                        }

                        cmdAddLead.Parameters.Add("L_ADD1", OracleDbType.Varchar2).Value = ObjEntityLead.Address1;
                        cmdAddLead.Parameters.Add("L_ADD2", OracleDbType.Varchar2).Value = ObjEntityLead.Address2;
                        cmdAddLead.Parameters.Add("L_ADD3", OracleDbType.Varchar2).Value = ObjEntityLead.Address3;
                        if (ObjEntityLead.CountryId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CNTRYID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CNTRYID", OracleDbType.Int32).Value = ObjEntityLead.CountryId;
                        }
                        if (ObjEntityLead.StateId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_STATEID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_STATEID", OracleDbType.Int32).Value = ObjEntityLead.StateId;
                        }
                        if (ObjEntityLead.CityId == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CITYID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CITYID", OracleDbType.Int32).Value = ObjEntityLead.CityId;
                        }
                        cmdAddLead.Parameters.Add("L_ZIPCODE", OracleDbType.Varchar2).Value = ObjEntityLead.ZipCode;
                        cmdAddLead.Parameters.Add("L_TINNO", OracleDbType.Varchar2).Value = ObjEntityLead.TinNumber;
                        cmdAddLead.Parameters.Add("L_MOBNO", OracleDbType.Varchar2).Value = ObjEntityLead.Mobile;
                        cmdAddLead.Parameters.Add("L_PHONENUM", OracleDbType.Varchar2).Value = ObjEntityLead.Phone;
                        cmdAddLead.Parameters.Add("L_EMAIL", OracleDbType.Varchar2).Value = ObjEntityLead.Email;
                        cmdAddLead.Parameters.Add("L_WEB", OracleDbType.Varchar2).Value = ObjEntityLead.Web;
                        cmdAddLead.Parameters.Add("L_LEADRATEID", OracleDbType.Int32).Value = ObjEntityLead.LeadRating;
                        cmdAddLead.Parameters.Add("L_LEADSTSID", OracleDbType.Int32).Value = ObjEntityLead.Status;
                        cmdAddLead.Parameters.Add("L_LDACTUSRID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                        cmdAddLead.Parameters.Add("L_INSUSRID", OracleDbType.Int32).Value = ObjEntityLead.User_Id;
                        cmdAddLead.Parameters.Add("L_INSDATE", OracleDbType.Date).Value = ObjEntityLead.InsertDate;

                        cmdAddLead.Parameters.Add("L_FINCYR_ID", OracleDbType.Int32).Value = ObjEntityLead.FinYearId;
                        cmdAddLead.Parameters.Add("L_LDSDIVCOD", OracleDbType.Varchar2).Value = ObjEntityLead.DivisionCode;
                        cmdAddLead.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                        cmdAddLead.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLead.Org_Id;
                        if (ObjEntityLead.Customer_Id == 0)
                            cmdAddLead.Parameters.Add("L_CSTMRID", OracleDbType.Int32).Value = null;
                        else
                            cmdAddLead.Parameters.Add("L_CSTMRID", OracleDbType.Int32).Value = ObjEntityLead.Customer_Id;


                        if (ObjEntityLead.Project_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = ObjEntityLead.Project_Id;
                        }
                        if (ObjEntityLead.Client_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CLIENTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CLIENTID", OracleDbType.Int32).Value = ObjEntityLead.Client_Id;
                        }
                        if (ObjEntityLead.Contractor_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CONTRCTRID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CONTRCTRID", OracleDbType.Int32).Value = ObjEntityLead.Contractor_Id;
                        }
                        if (ObjEntityLead.Consultant_Id == 0)
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTNTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_CONSULTNTID", OracleDbType.Int32).Value = ObjEntityLead.Consultant_Id;
                        }
                        if (ObjEntityLead.ProjectStatus == 0)
                        {
                            cmdAddLead.Parameters.Add("L_GUARNTMODE_ID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddLead.Parameters.Add("L_GUARNTMODE_ID", OracleDbType.Int32).Value = ObjEntityLead.ProjectStatus;
                        }
                        cmdAddLead.ExecuteNonQuery();
                    }

                    //delete customer extra contact details based on customer id
                    string strQueryDeleteConatct = "LEAD.SP_DELETE_CUSTOMER_CONTACT";
                    using (OracleCommand cmdDeleteContact = new OracleCommand(strQueryDeleteConatct, con))
                    {
                        cmdDeleteContact.Transaction = tran;

                        cmdDeleteContact.CommandType = CommandType.StoredProcedure;
                        cmdDeleteContact.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;

                        cmdDeleteContact.ExecuteNonQuery();
                    }
                    //insert lead extra contact details to the table
                    foreach (clsEntityLeadCreation objContact in objEntityContact)
                    {
                        string strQueryInsertContactDetail = "LEAD.SP_INSERT_NEW_CONTACT";
                        using (OracleCommand cmdAddInsertContactDetail = new OracleCommand(strQueryInsertContactDetail, con))
                        {
                            cmdAddInsertContactDetail.Transaction = tran;

                            cmdAddInsertContactDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertContactDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDSID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTNAME", OracleDbType.Varchar2).Value = objContact.Customer_Name;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTADRS", OracleDbType.Varchar2).Value = objContact.Address1;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTMOB", OracleDbType.Varchar2).Value = objContact.Mobile;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTPHONE", OracleDbType.Varchar2).Value = objContact.Phone;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTEMAIL", OracleDbType.Varchar2).Value = objContact.Email;
                            cmdAddInsertContactDetail.Parameters.Add("L_EMAILAlWD", OracleDbType.Int32).Value = objContact.MailSendAllwd;
                            cmdAddInsertContactDetail.Parameters.Add("L_LDCNTWEB", OracleDbType.Varchar2).Value = objContact.Web;

                            cmdAddInsertContactDetail.ExecuteNonQuery();
                        }
                    }

                    //delete media details based on current customer id
                    string strQueryDeleteMedia = "LEAD.SP_DELETE_MEDIA_DTLS";
                    using (OracleCommand cmdDeleteMedia = new OracleCommand(strQueryDeleteMedia, con))
                    {
                        cmdDeleteMedia.Transaction = tran;

                        cmdDeleteMedia.CommandType = CommandType.StoredProcedure;
                        cmdDeleteMedia.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;

                        cmdDeleteMedia.ExecuteNonQuery();
                    }

                    //insert customer media details to the table
                    foreach (clsEntityLeadCreation objMedia in objEntityMedia)
                    {
                        if (objMedia.Media_Description != "" && objMedia.Media_Description != null)
                        {
                            string strQueryInsertMediaDetail = "LEAD.SP_INSERT_MEDIA_DETAILS";
                            using (OracleCommand cmdAddInsertMediaDetail = new OracleCommand(strQueryInsertMediaDetail, con))
                            {
                                cmdAddInsertMediaDetail.Transaction = tran;

                                cmdAddInsertMediaDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertMediaDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                                cmdAddInsertMediaDetail.Parameters.Add("L_MEDIAID", OracleDbType.Int32).Value = objMedia.Media_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("L_DESCRIPTION", OracleDbType.Varchar2).Value = objMedia.Media_Description;
                                cmdAddInsertMediaDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    //Delete from Lead attachment table
                    foreach (clsEntityLayerLeadAttchmntDtl objAttchDetail in objEntityLeadAttchmntDELETEDetails)
                    {

                        string strQueryDeleteAttchmntDetail = "LEAD.SP_DELETE_LEAD_ATTACHMNT";
                        using (OracleCommand cmdDeleteAttchmntDetail = new OracleCommand(strQueryDeleteAttchmntDetail, con))
                        {
                            cmdDeleteAttchmntDetail.Transaction = tran;

                            cmdDeleteAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdDeleteAttchmntDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                            cmdDeleteAttchmntDetail.Parameters.Add("L_ATTCHMNTDTL_ID", OracleDbType.Varchar2).Value = objAttchDetail.LeadAttchmntDtlId;

                            cmdDeleteAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerLeadAttchmntDtl objAttchDetail in objEntityLeadAttchmntINSERTDetails)
                    {

                        string strQueryInsertAttchmntDetail = "LEAD.SP_INSERT_LEAD_ATTACHMENT";
                        using (OracleCommand cmdAddInsertAttchmntDetail = new OracleCommand(strQueryInsertAttchmntDetail, con))
                        {
                            cmdAddInsertAttchmntDetail.Transaction = tran;

                            cmdAddInsertAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_ACTUALFNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.LeadAttchmntSlNumber;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_ATCH_DATE", OracleDbType.Date).Value = ObjEntityLead.InsertDate;
                            cmdAddInsertAttchmntDetail.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLead.Corp_Id;
                            cmdAddInsertAttchmntDetail.ExecuteNonQuery();
                        }
                    }


                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }
        public DataTable Read_Customer_List_BySearch(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCustomerList = "LEAD.SP_READ_SEARCH_LIST";
            OracleCommand cmdReadCustomerList = new OracleCommand();
            cmdReadCustomerList.CommandText = strQueryReadCustomerList;
            cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            if (objEntityLead.Customer_Name == "")
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLead.Customer_Name;

            }
            cmdReadCustomerList.Parameters.Add("L_STSID", OracleDbType.Int32).Value = objEntityLead.Status;
            cmdReadCustomerList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCustomerList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;



            if (objEntityLead.LeadDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityLead.LeadDate;

            }
            if (objEntityLead.InsertDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLead.InsertDate;

            }
            cmdReadCustomerList.Parameters.Add("L_CONDITION", OracleDbType.Int32).Value = objEntityLead.LeadSourceId;
            cmdReadCustomerList.Parameters.Add("L_AGEING1", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadCustomerList.Parameters.Add("L_AGEING2", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCustomerList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLead.CommonSearchTerm;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityLead.SearchDate;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityLead.SearchCust;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_OWNER", OracleDbType.Varchar2).Value = objEntityLead.SearchOwner;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityLead.SearchRef;
            cmdReadCustomerList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLead.OrderColumn;
            cmdReadCustomerList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLead.OrderMethod;
            cmdReadCustomerList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLead.PageMaxSize;
            cmdReadCustomerList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLead.PageNumber;




            cmdReadCustomerList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerList = new DataTable();
            dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
            return dtCustomerList;
        }

        public DataTable Read_Customer_List_Indvl_BySearch(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCustomerList = "LEAD.SP_READ_INDVL_SEARCH_LIST";
            OracleCommand cmdReadCustomerList = new OracleCommand();
            cmdReadCustomerList.CommandText = strQueryReadCustomerList;
            cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            if (objEntityLead.Customer_Name == "")
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLead.Customer_Name;

            }
            cmdReadCustomerList.Parameters.Add("L_STSID", OracleDbType.Int32).Value = objEntityLead.Status;
            cmdReadCustomerList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCustomerList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;



            if (objEntityLead.LeadDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityLead.LeadDate;

            }
            if (objEntityLead.InsertDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLead.InsertDate;

            }
            cmdReadCustomerList.Parameters.Add("L_CONDITION", OracleDbType.Int32).Value = objEntityLead.LeadSourceId;
            cmdReadCustomerList.Parameters.Add("L_AGEING1", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadCustomerList.Parameters.Add("L_AGEING2", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCustomerList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLead.CommonSearchTerm;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityLead.SearchDate;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityLead.SearchCust;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_OWNER", OracleDbType.Varchar2).Value = objEntityLead.SearchOwner;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityLead.SearchRef;
            cmdReadCustomerList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLead.OrderColumn;
            cmdReadCustomerList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLead.OrderMethod;
            cmdReadCustomerList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLead.PageMaxSize;
            cmdReadCustomerList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLead.PageNumber;






            cmdReadCustomerList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerList = new DataTable();
            dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
            return dtCustomerList;
        }
        // for dash bord wise listing monthly sucess,lostlead
        public DataTable Read_Customer_List_Indvl_Mnthly_BySearch(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCustomerList = "LEAD.SP_READ_INDVL_MNTHLY_SRCH_LIST";
            OracleCommand cmdReadCustomerList = new OracleCommand();
            cmdReadCustomerList.CommandText = strQueryReadCustomerList;
            cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            if (objEntityLead.Customer_Name == "")
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLead.Customer_Name;

            }
            cmdReadCustomerList.Parameters.Add("L_STSID", OracleDbType.Int32).Value = objEntityLead.Status;
            cmdReadCustomerList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCustomerList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;




            if (objEntityLead.LeadDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityLead.LeadDate;

            }
            if (objEntityLead.InsertDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLead.InsertDate;

            }
            cmdReadCustomerList.Parameters.Add("L_CONDITION", OracleDbType.Int32).Value = objEntityLead.LeadSourceId;
            cmdReadCustomerList.Parameters.Add("L_AGEING1", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadCustomerList.Parameters.Add("L_AGEING2", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCustomerList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLead.CommonSearchTerm;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityLead.SearchDate;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityLead.SearchCust;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_OWNER", OracleDbType.Varchar2).Value = objEntityLead.SearchOwner;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityLead.SearchRef;
            cmdReadCustomerList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLead.OrderColumn;
            cmdReadCustomerList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLead.OrderMethod;
            cmdReadCustomerList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLead.PageMaxSize;
            cmdReadCustomerList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLead.PageNumber;





            cmdReadCustomerList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerList = new DataTable();
            dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
            return dtCustomerList;
        }
        //Method for fetch mail details based on mail id
        public DataTable ReadMailDetails(clsEntityLeadCreation objEntityLead)
        {
            string strQueryMailDetails = "LEAD.SP_READ_MAIL_DETAILS";
            using (OracleCommand cmdReadMailDetails = new OracleCommand())
            {
                cmdReadMailDetails.CommandText = strQueryMailDetails;
                cmdReadMailDetails.CommandType = CommandType.StoredProcedure;
                cmdReadMailDetails.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = objEntityLead.MailBoxId;
                cmdReadMailDetails.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMail = new DataTable();
                dtMail = clsDataLayer.SelectDataTable(cmdReadMailDetails);
                return dtMail;
            }
        }

        // This Method FETCHES LEAD ATTACHMENTS BASED ON LEAD ID FROM GN_LEADS_ATTACHMENTS
        public DataTable ReadLeadAttchmnt(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAttchmnt = "LEAD.SP_READ_LEAD_ATTACHMNT";
            OracleCommand cmdReadAttchmnt = new OracleCommand();
            cmdReadAttchmnt.CommandText = strQueryReadAttchmnt;
            cmdReadAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadAttchmnt.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAttchmnt.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadAttchmnt);
            return dtDtl;
        }
        // method FOR READING CUSTOMERS FOR LISTING FOR EXISTING CUSTOMERS.
        public DataTable ReadExistingCustomers(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCust = "LEAD.SP_READ_CUSTOMERS";
            using (OracleCommand cmdReadCustomer = new OracleCommand())
            {
                cmdReadCustomer.CommandText = strQueryReadCust;
                cmdReadCustomer.CommandType = CommandType.StoredProcedure;
                cmdReadCustomer.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadCustomer.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadCustomer.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadCustomer);
                return dtReadCust;
            }
        }

        // This Method will fetch customer table by ID
        public DataTable ReadCustomerById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadCustomerById = "LEAD.SP_READ_CUSTOMER_BYID";
            OracleCommand cmdReadCustomerById = new OracleCommand();
            cmdReadCustomerById.CommandText = strQueryReadCustomerById;
            cmdReadCustomerById.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadCustomerById.Parameters.Add("C_CUSTOMER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadCustomerById);
            return dtCustomer;
        }

        //fetch customer contact details based on customer id
        public DataTable Read_Contact_DetailsById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadContact = "LEAD.SP_READ_CONTACT_BYID";
            OracleCommand cmdReadContact = new OracleCommand();
            cmdReadContact.CommandText = strQueryReadContact;
            cmdReadContact.CommandType = CommandType.StoredProcedure;
            cmdReadContact.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadContact.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtContact = new DataTable();
            dtContact = clsDataLayer.ExecuteReader(cmdReadContact);
            return dtContact;
        }

        //fetch customer media details based on customer id
        public DataTable Read_Media_DetailsById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadMedia = "LEAD.SP_READ_MEDIA_BYID";
            OracleCommand cmdReadMedia = new OracleCommand();
            cmdReadMedia.CommandText = strQueryReadMedia;
            cmdReadMedia.CommandType = CommandType.StoredProcedure;
            cmdReadMedia.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadMedia.Parameters.Add("C_SECTIONID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
            cmdReadMedia.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMedia = new DataTable();
            dtMedia = clsDataLayer.ExecuteReader(cmdReadMedia);
            return dtMedia;
        }

        //METHOD TO FETCH LEAD STATUS'S FROM THE TABLE
        public DataTable ReadLeadStatus(string strSts)
        {
            string strQueryReadLeadSts = "LEAD.SP_READ_LEAD_STATUS";
            using (OracleCommand cmdReadLeadSts = new OracleCommand())
            {
                cmdReadLeadSts.CommandText = strQueryReadLeadSts;
                cmdReadLeadSts.CommandType = CommandType.StoredProcedure;
                cmdReadLeadSts.Parameters.Add("L_STS", OracleDbType.Varchar2).Value = strSts;
                cmdReadLeadSts.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSts = new DataTable();
                dtLeadSts = clsDataLayer.SelectDataTable(cmdReadLeadSts);
                return dtLeadSts;
            }
        }

        // method READING CLIENT FOR LISTING FOR EXISTING CLIENTS.
        public DataTable ReadExistingClients(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadClient = "LEAD.SP_READ_CLIENT";
            using (OracleCommand cmdReadClient = new OracleCommand())
            {
                cmdReadClient.CommandText = strQueryReadClient;
                cmdReadClient.CommandType = CommandType.StoredProcedure;
                cmdReadClient.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadClient.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadClient.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadClient);
                return dtReadCust;
            }
        }
        // method READING CONTRACTOR FOR LISTING FOR EXISTING CONTRACTOR.
        public DataTable ReadExistingContractors(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadContractor = "LEAD.SP_READ_CONTRACTOR";
            using (OracleCommand cmdReadContractor = new OracleCommand())
            {
                cmdReadContractor.CommandText = strQueryReadContractor;
                cmdReadContractor.CommandType = CommandType.StoredProcedure;
                cmdReadContractor.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadContractor.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadContractor.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadContractor);
                return dtReadCust;
            }
        }
        // method  READING CONSULTANT FOR LISTING FOR EXISTING CONSULTANTS.
        public DataTable ReadExistingConsultants(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadConsultant = "LEAD.SP_READ_CONSULTANT";
            using (OracleCommand cmdReadConsultant = new OracleCommand())
            {
                cmdReadConsultant.CommandText = strQueryReadConsultant;
                cmdReadConsultant.CommandType = CommandType.StoredProcedure;
                cmdReadConsultant.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadConsultant.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadConsultant.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadConsultant);
                return dtReadCust;
            }
        }

        // method   READING PROJECT FOR LISTING FOR EXISTING PROJECTS.
        public DataTable ReadExistingProjects(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadProject = "LEAD.SP_READ_PROJECT";
            using (OracleCommand cmdReadProject = new OracleCommand())
            {
                cmdReadProject.CommandText = strQueryReadProject;
                cmdReadProject.CommandType = CommandType.StoredProcedure;
                cmdReadProject.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                cmdReadProject.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadProject.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadProject.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadProject);
                return dtReadCust;
            }
        }

        //reading pending lead details by team
        public DataTable Read_Pending_Lead_Detail_ByTeam(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCustomerList = "LEAD.SP_RD_APRVLPNDG_FOR_THEAD";
            OracleCommand cmdReadCustomerList = new OracleCommand();
            cmdReadCustomerList.CommandText = strQueryReadCustomerList;
            cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerList.Parameters.Add("L_TEAMID", OracleDbType.Int32).Value = objEntityLead.Team;
            cmdReadCustomerList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            if (objEntityLead.Customer_Name == "")
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLead.Customer_Name;

            }
            cmdReadCustomerList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCustomerList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;



            if (objEntityLead.LeadDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityLead.LeadDate;

            }
            if (objEntityLead.InsertDate == DateTime.MinValue)
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadCustomerList.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLead.InsertDate;

            }
            cmdReadCustomerList.Parameters.Add("L_CONDITION", OracleDbType.Int32).Value = objEntityLead.LeadSourceId;
            cmdReadCustomerList.Parameters.Add("L_AGEING1", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadCustomerList.Parameters.Add("L_AGEING2", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCustomerList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLead.CommonSearchTerm;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityLead.SearchDate;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityLead.SearchCust;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_OWNER", OracleDbType.Varchar2).Value = objEntityLead.SearchOwner;
            cmdReadCustomerList.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityLead.SearchRef;
            cmdReadCustomerList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLead.OrderColumn;
            cmdReadCustomerList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLead.OrderMethod;
            cmdReadCustomerList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLead.PageMaxSize;
            cmdReadCustomerList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLead.PageNumber;






            cmdReadCustomerList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerList = new DataTable();
            dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
            return dtCustomerList;
        }


        // method for read mail attachment based on mail id
        public DataTable ReadMailAttachment(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAttch = "LEAD.SP_READ_MAIL_ATTACHMENT";
            using (OracleCommand cmdReadAttch = new OracleCommand())
            {
                cmdReadAttch.CommandText = strQueryReadAttch;
                cmdReadAttch.CommandType = CommandType.StoredProcedure;
                cmdReadAttch.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = objEntityLead.MailBoxId;
                cmdReadAttch.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadAttch = new DataTable();
                dtReadAttch = clsDataLayer.SelectDataTable(cmdReadAttch);
                return dtReadAttch;
            }
        }
        //evm0012
        // method reading project detail
        public DataTable ReadProjectDetails(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadProject = "LEAD.SP_READ_PROJECT_DTL_BYID";
            using (OracleCommand cmdReadProject = new OracleCommand())
            {
                cmdReadProject.CommandText = strQueryReadProject;
                cmdReadProject.CommandType = CommandType.StoredProcedure;
                cmdReadProject.Parameters.Add("L_PROJECT_ID", OracleDbType.Int32).Value = objEntityLead.Project_Id;
                cmdReadProject.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadProject);
                return dtReadCust;
            }
        }
        public DataTable ReadProjectStatus(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadProject = "LEAD.SP_READ_PROJECT_STS_BYID";
            using (OracleCommand cmdReadProject = new OracleCommand())
            {
                cmdReadProject.CommandText = strQueryReadProject;
                cmdReadProject.CommandType = CommandType.StoredProcedure;
                cmdReadProject.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                cmdReadProject.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadProject);
                return dtReadCust;
            }
        }
      
    }

}