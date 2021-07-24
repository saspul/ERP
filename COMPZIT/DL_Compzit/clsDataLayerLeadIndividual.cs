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
    public class clsDataLayerLeadIndividual
    {

        // HERE ONWARDs iNDIVIDUAL LIST
        public DataTable Read_Indvidual_Lead_List(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadList = "LEAD_INDIVIDUAL.SP_READ_INDIVIDUAL_LIST";
            OracleCommand cmdReadList = new OracleCommand();
            cmdReadList.CommandText = strQueryReadList;
            cmdReadList.CommandType = CommandType.StoredProcedure;
            cmdReadList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadIndList = new DataTable();
            dtLeadIndList = clsDataLayer.ExecuteReader(cmdReadList);
            return dtLeadIndList;
        }
        public DataTable Read_Indvidual_Lead_Atch(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_INVL_LIST_ATCH";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAtchList = new DataTable();
            dtAtchList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtAtchList;
        }
        public DataTable Read_Indvidual_Lead_Qtan(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_INVL_LIST_QTAN";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAtchList = new DataTable();
            dtAtchList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtAtchList;
        }
        public DataTable Read_Indvidual_Lead_Mail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_INVL_LIST_MAIL";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAtchList = new DataTable();
            dtAtchList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtAtchList;
        }
        public DataTable Read_Indvidual_Lead_Task(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_INVL_LIST_TASK";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaskList = new DataTable();
            dtTaskList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtTaskList;
        }
        // FOR STATUS TRACKING
        public DataTable Read_Lead_Sts_Track(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_LEAD_STS_TRACK";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaskList = new DataTable();
            dtTaskList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtTaskList;
        }
        public DataTable Read_Indvidual_Lead_Followup(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_INVL_LIST_FOLUP";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtFlpList = new DataTable();
            dtFlpList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtFlpList;
        }
        // for reading all active LeadSource to show in ddl of FollowUp
        public DataTable Read_LeadSource()
        {
            string strQueryReadSource = "LEAD_INDIVIDUAL.SP_READ_LEAD_SOURCE";
            OracleCommand cmdReadSource = new OracleCommand();
            cmdReadSource.CommandText = strQueryReadSource;
            cmdReadSource.CommandType = CommandType.StoredProcedure;
            cmdReadSource.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSrceList = new DataTable();
            dtSrceList = clsDataLayer.ExecuteReader(cmdReadSource);
            return dtSrceList;
        }

        //insert into followup
        public void InsertFollowUp(clsEntityFollowUp objEntityFollowUp)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_INSERT_FOLLOW_UP";
            OracleCommand cmdReadFolop = new OracleCommand();
            cmdReadFolop.CommandText = strQueryReadAtchList;
            cmdReadFolop.CommandType = CommandType.StoredProcedure;
            cmdReadFolop.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityFollowUp.Corp_Id;
            cmdReadFolop.Parameters.Add("F_LEADS_ID", OracleDbType.Int32).Value = objEntityFollowUp.Lead_Id;
            cmdReadFolop.Parameters.Add("F_LDSRCE_ID", OracleDbType.Int32).Value = objEntityFollowUp.LeadSourceId;
            cmdReadFolop.Parameters.Add("F_LDFLUP_DATE", OracleDbType.Date).Value = objEntityFollowUp.FollowUpDate;
            cmdReadFolop.Parameters.Add("F_LDFLUP_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityFollowUp.Description;
            cmdReadFolop.Parameters.Add("F_LDFLUP_INS_USR_ID", OracleDbType.Int32).Value = objEntityFollowUp.User_Id;
            cmdReadFolop.Parameters.Add("F_LDFLUP_INS_DATE", OracleDbType.Date).Value = objEntityFollowUp.Date;
            cmdReadFolop.Parameters.Add("F_LDFLUP_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityFollowUp.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadFolop);
        }
        //insert into Task
        public void InsertTask(clsEntityTask objEntityTask)
        {
            string strQueryRead = "LEAD_INDIVIDUAL.SP_INSERT_TASK";
            OracleCommand cmdReadTask = new OracleCommand();
            cmdReadTask.CommandText = strQueryRead;
            cmdReadTask.CommandType = CommandType.StoredProcedure;
            cmdReadTask.Parameters.Add("T_LEADS_ID", OracleDbType.Int32).Value = objEntityTask.Lead_Id;
            cmdReadTask.Parameters.Add("T_TASKSUBJCT_ID", OracleDbType.Int32).Value = objEntityTask.TaskSubjectId;
            cmdReadTask.Parameters.Add("T_TASK_DUE_DATE", OracleDbType.Date).Value = objEntityTask.DueDate;
            cmdReadTask.Parameters.Add("T_TASK_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityTask.Description;
            cmdReadTask.Parameters.Add("T_TASK_STATUS", OracleDbType.Int32).Value = objEntityTask.TaskStatus;
            cmdReadTask.Parameters.Add("T_TASK_INS_USR_ID", OracleDbType.Int32).Value = objEntityTask.User_Id;
            cmdReadTask.Parameters.Add("T_TASK_INS_DATE", OracleDbType.Date).Value = objEntityTask.Date;
            cmdReadTask.Parameters.Add("T_CLOSE_STATUS", OracleDbType.Int32).Value = objEntityTask.CloseStatus;
            cmdReadTask.Parameters.Add("T_TASK_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityTask.User_Id;
            cmdReadTask.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTask.Org_Id;
            cmdReadTask.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTask.Corp_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadTask);
        }
        //update Task
        public void UpdateTask(clsEntityTask objEntityTask)
        {
            string strQueryRead = "LEAD_INDIVIDUAL.SP_UPDATE_TASK";
            OracleCommand cmdReadTask = new OracleCommand();
            cmdReadTask.CommandText = strQueryRead;
            cmdReadTask.CommandType = CommandType.StoredProcedure;
            cmdReadTask.Parameters.Add("T_TASK_ID", OracleDbType.Int32).Value = objEntityTask.TaskId;
            cmdReadTask.Parameters.Add("T_TASKSUBJCT_ID", OracleDbType.Int32).Value = objEntityTask.TaskSubjectId;
            cmdReadTask.Parameters.Add("T_TASK_DUE_DATE", OracleDbType.Date).Value = objEntityTask.DueDate;
            cmdReadTask.Parameters.Add("T_TASK_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityTask.Description;
            cmdReadTask.Parameters.Add("T_TASK_STATUS", OracleDbType.Int32).Value = objEntityTask.TaskStatus;
            cmdReadTask.Parameters.Add("T_TASK_UPD_USR_ID", OracleDbType.Int32).Value = objEntityTask.User_Id;
            cmdReadTask.Parameters.Add("T_TASK_UPD_DATE", OracleDbType.Date).Value = objEntityTask.Date;
            cmdReadTask.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTask.Org_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadTask);
        }
        //cancel/delete Task
        public void DeleteTask(clsEntityTask objEntityTask)
        {
            string strQueryRead = "LEAD_INDIVIDUAL.SP_UPDATE_CANCEL_TASK";
            OracleCommand cmdReadTask = new OracleCommand();
            cmdReadTask.CommandText = strQueryRead;
            cmdReadTask.CommandType = CommandType.StoredProcedure;
            cmdReadTask.Parameters.Add("T_ID ", OracleDbType.Int32).Value = objEntityTask.TaskId;
            cmdReadTask.Parameters.Add("T_TASK_CLOSE_STATUS ", OracleDbType.Int32).Value = 0;
            cmdReadTask.Parameters.Add("TASK_CLOSE_USR_ID ", OracleDbType.Int32).Value = objEntityTask.User_Id;
            cmdReadTask.Parameters.Add("TASK_CLOSED_DATE", OracleDbType.Date).Value = objEntityTask.Date;
            clsDataLayer.ExecuteNonQuery(cmdReadTask);
        }
        // for reading READING LEAD STATUS BY TASK ID     
        public DataTable Read_LeadStatus_By_TaskId(clsEntityTask objEntityTask)
        {
            string strQueryReadStatus = "LEAD_INDIVIDUAL.SP_READ_LEAD_STATUS_BY_TASKID";
            OracleCommand cmdReadSts = new OracleCommand();
            cmdReadSts.CommandText = strQueryReadStatus;
            cmdReadSts.CommandType = CommandType.StoredProcedure;
            cmdReadSts.Parameters.Add("T_TASK_ID ", OracleDbType.Int32).Value = objEntityTask.TaskId;
            cmdReadSts.Parameters.Add("T_ORG_ID ", OracleDbType.Int32).Value = objEntityTask.Org_Id;
            cmdReadSts.Parameters.Add("T_CORPRT_ID ", OracleDbType.Int32).Value = objEntityTask.Corp_Id;
            cmdReadSts.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLdSts = new DataTable();
            dtLdSts = clsDataLayer.ExecuteReader(cmdReadSts);
            return dtLdSts;
        }
        // for reading all active Task subject to show in ddl of Task
        public DataTable Read_TaskSubject()
        {
            string strQueryReadSbjct = "LEAD_INDIVIDUAL.SP_READ_TASK_SUBJECT";
            OracleCommand cmdReadSbjct = new OracleCommand();
            cmdReadSbjct.CommandText = strQueryReadSbjct;
            cmdReadSbjct.CommandType = CommandType.StoredProcedure;
            cmdReadSbjct.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSbjctList = new DataTable();
            dtSbjctList = clsDataLayer.ExecuteReader(cmdReadSbjct);
            return dtSbjctList;
        }
        // for reading all active Reason to show in ddl of Lose Reason
        public DataTable Read_LoseRsn()
        {
            string strQueryReadRsn = "LEAD_INDIVIDUAL.SP_READ_LOSE_REASON";
            OracleCommand cmdReadRsn = new OracleCommand();
            cmdReadRsn.CommandText = strQueryReadRsn;
            cmdReadRsn.CommandType = CommandType.StoredProcedure;
            cmdReadRsn.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRsnList = new DataTable();
            dtRsnList = clsDataLayer.ExecuteReader(cmdReadRsn);
            return dtRsnList;
        }
        // This Method change Lead status to Loss and insert to status tracking table
        public void LossLead(clsEntityLeadCreation objEntityLead)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss); //Lost
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQuerylOSSAllPrdct = "LEAD.SP_LOSS_ALL_PRDCT";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQuerylOSSAllPrdct, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss); //Lost
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityLead.InsertDate;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = objEntityLead.LossReasonId;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = objEntityLead.Description;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
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
        // This Method change Lead status to Win and insert to status tracking table
        public void WinLead(clsEntityLeadCreation objEntityLead)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            int CustId = 0;//0013
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityLead.LeadStatus;//Success
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = objEntityLead.WinAmount;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryWinAllPrdct = "LEAD.SP_WIN_ALL_PRDCT";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryWinAllPrdct, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Success); //Success
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityLead.InsertDate;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }
                    tran.Commit();


                    //after a lead sucess we need to make the lead customer,project,client... company's own customers
                    clsDataLayerLeadCreation objDataLayerLead = new clsDataLayerLeadCreation();
                    DataTable dtLead = objDataLayerLead.Read_Lead_ById(objEntityLead);
                    DataTable dtLeadContact = objDataLayerLead.Read_Contact_ById(objEntityLead);
                    DataTable dtLeadMedia = objDataLayerLead.Read_Media_ById(objEntityLead);

                    if (dtLead.Rows[0]["CSTMR_ID"] == DBNull.Value)
                    {
                        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
                        clsDataLayerCustomer objDataLayerCustomer = new clsDataLayerCustomer();

                        objEntityCustomer.UserId = objEntityLead.User_Id;
                        objEntityCustomer.CorpId = objEntityLead.Corp_Id;
                        objEntityCustomer.Organisation_Id = objEntityLead.Org_Id;
                        objEntityCustomer.Date = objEntityLead.InsertDate;
                        objEntityCustomer.Customer_Name = dtLead.Rows[0]["LEADS_CSTMR_NAME"].ToString();
                        objEntityCustomer.Customer_Group_Id = Convert.ToInt32(objEntityLead.Corp_Id.ToString() + "0");
                        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(clsCommonLibrary.CustomerType.CUSTOMER);
                        objEntityCustomer.Address1 = dtLead.Rows[0]["LEADS_ADDRESS1"].ToString();
                        objEntityCustomer.Address2 = dtLead.Rows[0]["LEADS_ADDRESS2"].ToString();
                        objEntityCustomer.Address3 = dtLead.Rows[0]["LEADS_ADDRESS3"].ToString();
                        //code by 005
                        objEntityCustomer.Customer_Status = 1;
                        //005 end
                        if (dtLead.Rows[0]["CNTRY_ID"] != DBNull.Value)
                        {
                            objEntityCustomer.CountryId = Convert.ToInt32(dtLead.Rows[0]["CNTRY_ID"]);
                        }
                        else
                        {
                            objEntityCustomer.CountryId = Convert.ToInt32(dtLead.Rows[0]["CORP_COUNTRY"]);
                        }
                        if (dtLead.Rows[0]["STATE_ID"] != DBNull.Value)
                        {
                            objEntityCustomer.StateId = Convert.ToInt32(dtLead.Rows[0]["STATE_ID"]);
                        }
                        if (dtLead.Rows[0]["CITY_ID"] != DBNull.Value)
                        {
                            objEntityCustomer.CityId = Convert.ToInt32(dtLead.Rows[0]["CITY_ID"]);
                        }

                        objEntityCustomer.ZipCode = dtLead.Rows[0]["LEADS_ZIP_CODE"].ToString();
                        objEntityCustomer.Phone_Number = dtLead.Rows[0]["LEADS_PHONE"].ToString();
                        objEntityCustomer.Mobile_Number = dtLead.Rows[0]["LEADS_MOBILE"].ToString();
                        objEntityCustomer.Web_Address = dtLead.Rows[0]["LEADS_WEBSITE"].ToString();
                        objEntityCustomer.Email_Address = dtLead.Rows[0]["LEADS_EMAIL"].ToString();
                        objEntityCustomer.TIN_Number = dtLead.Rows[0]["LEADS_TIN_NUMBER"].ToString();

                        List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
                        //next insert media details
                        if (dtLeadMedia.Rows.Count > 0)
                        {
                            for (int intMediaRow = 0; intMediaRow < dtLeadMedia.Rows.Count; intMediaRow++)
                            {
                                clsEntityCustomer objEntityMedia = new clsEntityCustomer();
                                objEntityMedia.Media_Id = Convert.ToInt32(dtLeadMedia.Rows[intMediaRow]["MEDIA_ID"]);
                                objEntityMedia.Media_Description = dtLeadMedia.Rows[intMediaRow]["MEDIA_DESCRIPTION"].ToString();
                                objEntityMediaList.Add(objEntityMedia);

                            }


                        }
                        List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();
                        //next insert contact details
                        if (dtLeadContact.Rows.Count > 0)
                        {
                            for (int intContactRow = 0; intContactRow < dtLeadContact.Rows.Count; intContactRow++)
                            {
                                clsEntityCustomer objEntityContact = new clsEntityCustomer();
                                objEntityContact.Customer_Name = dtLeadContact.Rows[intContactRow]["LDCNT_CNTCT_NAME"].ToString();
                                objEntityContact.Address1 = dtLeadContact.Rows[intContactRow]["LDCNT_ADDRESS"].ToString();
                                objEntityContact.Mobile_Number = dtLeadContact.Rows[intContactRow]["LDCNT_MOBILE"].ToString();
                                objEntityContact.Phone_Number = dtLeadContact.Rows[intContactRow]["LDCNT_PHONE"].ToString();
                                objEntityContact.Web_Address = dtLeadContact.Rows[intContactRow]["LDCNT_WEBSITE"].ToString();
                                objEntityContact.Email_Address = dtLeadContact.Rows[intContactRow]["LDCNT_EMAIL"].ToString();
                                objEntityContactList.Add(objEntityContact);
                            }
                        }

                        objEntityCustomer.Update_Decide = Convert.ToInt32(clsCommonLibrary.CustomerType.CUSTOMER);
                        objEntityCustomer.Lead_Id = objEntityLead.LeadId;

                        //insert into customer master
                        try
                        {
                            //generate next value
                            clsDataLayer objDataLayer = new clsDataLayer();
                            clsEntityCommon objCommon = new clsEntityCommon();
                            objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
                            objCommon.CorporateID = objEntityLead.Corp_Id;
                            string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                            objEntityCustomer.Customer_Id = Convert.ToInt32(strNextValue);
                            CustId = objDataLayerCustomer.AddCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;

                        }
                    }
                    //if the project is new then insert the entry to project master
                    if (dtLead.Rows[0]["PROJECT_ID"] == DBNull.Value && dtLead.Rows[0]["LEADS_PROJECT_NAME"] != DBNull.Value)
                    {



                        clsEntityProject objEntityProject = new clsEntityProject();
                        clsDataLayerProject objDataLayerProject = new clsDataLayerProject();
                        objEntityProject.ProjectName = dtLead.Rows[0]["LEADS_PROJECT_NAME"].ToString();
                        if (dtLead.Rows[0]["CSTMR_ID"] == DBNull.Value || dtLead.Rows[0]["CSTMR_ID"].ToString()=="")
                        {
                            objEntityProject.Customer_Id = CustId;
                        }
                        else
                        {
                            objEntityProject.Customer_Id = Convert.ToInt32(dtLead.Rows[0]["CSTMR_ID"].ToString());
                        }
                        objEntityProject.Corp_Div_id = Convert.ToInt32(dtLead.Rows[0]["CPRDIV_ID"].ToString());
                        objEntityProject.GuaranteMOde_Id = 102;
                        if (objEntityLead.Project_Tender_Id != "" && objEntityLead.Project_Tender_Id != null)
                        {
                            objEntityProject.Tender_Ref = objEntityLead.Project_Tender_Id.ToString();
                        }
                        if (objEntityLead.InternalRefNum != "" && objEntityLead.InternalRefNum != null)
                        {
                            objEntityProject.GuaranteMOde_Id = 101;
                            objEntityProject.Inter_Ref = objEntityLead.InternalRefNum;
                        }
                        objEntityProject.Manager_Id = objEntityLead.ProjectManagerID;
                        objEntityProject.Proj_Ref_Num = objEntityLead.ProjectRefNum;
                        objEntityProject.Organisation_Id = objEntityLead.Org_Id;
                        objEntityProject.CorpOffice_Id = objEntityLead.Corp_Id;
                        objEntityProject.User_Id = objEntityLead.User_Id;
                        objEntityProject.D_Date = objEntityLead.InsertDate;
                        
                        objEntityProject.Project_Status = 1;

                        objEntityProject.Update_Decide = 1;
                        objEntityProject.Lead_Id = objEntityLead.LeadId;

                        try
                        {
                            objDataLayerProject.Insert_Project(objEntityProject);
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;

                        }

                    }
                    //if the contractor is new then insert the entry to customer master
                    if (dtLead.Rows[0]["LEADS_CONTRACTOR_ID"] == DBNull.Value && dtLead.Rows[0]["LEADS_CONTRACTOR"] != DBNull.Value)
                    {
                        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
                        clsDataLayerCustomer objDataLayerCustomer = new clsDataLayerCustomer();
                        List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
                        List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();

                        objEntityCustomer.UserId = objEntityLead.User_Id;
                        objEntityCustomer.CorpId = objEntityLead.Corp_Id;
                        objEntityCustomer.Organisation_Id = objEntityLead.Org_Id;
                        objEntityCustomer.Date = objEntityLead.InsertDate;
                        objEntityCustomer.Customer_Name = dtLead.Rows[0]["LEADS_CONTRACTOR"].ToString();
                        objEntityCustomer.Customer_Group_Id = Convert.ToInt32(objEntityLead.Corp_Id.ToString() + "0");
                        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(clsCommonLibrary.CustomerType.CONTRACTOR);
                        objEntityCustomer.CountryId = Convert.ToInt32(dtLead.Rows[0]["CORP_COUNTRY"]);
                        objEntityCustomer.Address1 = "PLEASE PROVIDE CORRECT ADDRESS HERE";
                        objEntityCustomer.Mobile_Number = "0123456789";

                        objEntityCustomer.Customer_Status = 1;

                        objEntityCustomer.Update_Decide = Convert.ToInt32(clsCommonLibrary.CustomerType.CONTRACTOR);
                        objEntityCustomer.Lead_Id = objEntityLead.LeadId;

                        //insert into customer master
                        try
                        {
                            //generate next value
                            clsDataLayer objDataLayer = new clsDataLayer();
                            clsEntityCommon objCommon = new clsEntityCommon();
                            objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
                            objCommon.CorporateID = objEntityLead.Corp_Id;
                            string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                            objEntityCustomer.Customer_Id = Convert.ToInt32(strNextValue);
                            objDataLayerCustomer.AddCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;

                        }
                    }

                    //if the client is new then insert the entry to customer master
                    if (dtLead.Rows[0]["LEADS_CLIENT_ID"] == DBNull.Value && dtLead.Rows[0]["LEADS_CLIENT"] != DBNull.Value)
                    {
                        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
                        clsDataLayerCustomer objDataLayerCustomer = new clsDataLayerCustomer();
                        List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
                        List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();

                        objEntityCustomer.UserId = objEntityLead.User_Id;
                        objEntityCustomer.CorpId = objEntityLead.Corp_Id;
                        objEntityCustomer.Organisation_Id = objEntityLead.Org_Id;
                        objEntityCustomer.Date = objEntityLead.InsertDate;
                        objEntityCustomer.Customer_Name = dtLead.Rows[0]["LEADS_CLIENT"].ToString();
                        objEntityCustomer.Customer_Group_Id = Convert.ToInt32(objEntityLead.Corp_Id.ToString() + "0");
                        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(clsCommonLibrary.CustomerType.CLIENT);
                        objEntityCustomer.CountryId = Convert.ToInt32(dtLead.Rows[0]["CORP_COUNTRY"]);
                        objEntityCustomer.Address1 = "PLEASE PROVIDE CORRECT ADDRESS HERE";
                        objEntityCustomer.Mobile_Number = "0123456789";

                        objEntityCustomer.Customer_Status = 1;

                        objEntityCustomer.Update_Decide = Convert.ToInt32(clsCommonLibrary.CustomerType.CLIENT);
                        objEntityCustomer.Lead_Id = objEntityLead.LeadId;

                        //insert into customer master
                        try
                        {
                            objDataLayerCustomer.AddCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;

                        }
                    }

                    //if the consultant is new then insert the entry to customer master
                    if (dtLead.Rows[0]["LEADS_CONSULTANT_ID"] == DBNull.Value && dtLead.Rows[0]["LEADS_CONSULTANT"] != DBNull.Value)
                    {
                        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
                        clsDataLayerCustomer objDataLayerCustomer = new clsDataLayerCustomer();
                        List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
                        List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();

                        objEntityCustomer.UserId = objEntityLead.User_Id;
                        objEntityCustomer.CorpId = objEntityLead.Corp_Id;
                        objEntityCustomer.Organisation_Id = objEntityLead.Org_Id;
                        objEntityCustomer.Date = objEntityLead.InsertDate;
                        objEntityCustomer.Customer_Name = dtLead.Rows[0]["LEADS_CONSULTANT"].ToString();
                        objEntityCustomer.Customer_Group_Id = Convert.ToInt32(objEntityLead.Corp_Id.ToString() + "0");
                        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(clsCommonLibrary.CustomerType.CONSULTANT);
                        objEntityCustomer.CountryId = Convert.ToInt32(dtLead.Rows[0]["CORP_COUNTRY"]);
                        objEntityCustomer.Address1 = "PLEASE PROVIDE CORRECT ADDRESS HERE";
                        objEntityCustomer.Mobile_Number = "0123456789";


                        objEntityCustomer.Customer_Status = 1;

                        objEntityCustomer.Update_Decide = Convert.ToInt32(clsCommonLibrary.CustomerType.CONSULTANT);
                        objEntityCustomer.Lead_Id = objEntityLead.LeadId;

                        //insert into customer master
                        try
                        {
                            objDataLayerCustomer.AddCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;

                        }
                    }

                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }





            }
        }

        //0013
        public DataTable ProjectLead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadProject = "LEAD.SP_READ_PROJECT_BY_LEAD_ID";
            OracleCommand cmdReadProject = new OracleCommand();
            cmdReadProject.CommandText = strQueryReadProject;
            cmdReadProject.CommandType = CommandType.StoredProcedure;
            cmdReadProject.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadProject.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadIndProject = new DataTable();
            dtLeadIndProject = clsDataLayer.ExecuteReader(cmdReadProject);
            return dtLeadIndProject;


        }

        // This Method change Lead status to Previous status of lead before close and insert to status tracking table
        public void ReOpenLead(clsEntityLeadCreation objEntityLead)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityLead.Status;
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQuerylOSSAllPrdct = "LEAD.SP_LOSS_ALL_PRDCT";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQuerylOSSAllPrdct, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = objEntityLead.Status;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityLead.InsertDate;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
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


        // METHORD FOR READING ALL USER BASED ON TEAM THE USER IS IN AND THAT HE LEADS 
        public DataTable Read_UserForAllocate(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadUserList = "LEAD_INDIVIDUAL.SP_READ_TO_ALLOCATE_USERS";
            OracleCommand cmdReadUserList = new OracleCommand();
            cmdReadUserList.CommandText = strQueryReadUserList;
            cmdReadUserList.CommandType = CommandType.StoredProcedure;
            cmdReadUserList.Parameters.Add("T_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadUserList.Parameters.Add("T_USR_ID", OracleDbType.Varchar2).Value = objEntityLead.User_Id;
            cmdReadUserList.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadUserList.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadUserList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtUserList = new DataTable();
            dtUserList = clsDataLayer.ExecuteReader(cmdReadUserList);
            return dtUserList;
        }


        // This Method change  Active user of lead  and also insert to allocation tracking table,AND ALSO CHANGE ACTVE USER ID OF TASK ,FOLLOW UP RELATED TO LEAD
        public void AllocateLead(clsEntityLeadCreation objEntityLead)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateActiveUser = "LEAD_INDIVIDUAL.SP_UPDATE_ACTIVE_LEAD_USER";
                    using (OracleCommand cmdUpdateActiveUser = new OracleCommand(strQueryUpdateActiveUser, con))
                    {
                        cmdUpdateActiveUser.Transaction = tran;

                        cmdUpdateActiveUser.CommandType = CommandType.StoredProcedure;
                        cmdUpdateActiveUser.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdUpdateActiveUser.Parameters.Add("L_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.NewActive_UserId;
                        cmdUpdateActiveUser.Parameters.Add("L_UPD_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                        cmdUpdateActiveUser.Parameters.Add("L_UPD_DATE", OracleDbType.Date).Value = objEntityLead.InsertDate;
                        cmdUpdateActiveUser.ExecuteNonQuery();
                    }
                    string strQueryInsertAllocationTracking = "LEAD_INDIVIDUAL.SP_INSERT_ALLOCATION_TRACKING";
                    using (OracleCommand cmdInsLeadAlctnTracking = new OracleCommand(strQueryInsertAllocationTracking, con))
                    {
                        cmdInsLeadAlctnTracking.Transaction = tran;

                        cmdInsLeadAlctnTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_LEADS_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_LDALLN_OLD_USR_ID", OracleDbType.Int32).Value = objEntityLead.OldActive_UserId;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_LDALLN_NEW_USR_ID", OracleDbType.Int32).Value = objEntityLead.NewActive_UserId;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_LDALLN_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
                        cmdInsLeadAlctnTracking.Parameters.Add("A_LDALLN_DATE", OracleDbType.Date).Value = objEntityLead.InsertDate;

                        cmdInsLeadAlctnTracking.ExecuteNonQuery();
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

        //fetch send mail details 
        public DataTable ReadFromMailDetails(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadFromMail = "LEAD_INDIVIDUAL.SP_FETCH_FROM_MAIL";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadFromMail.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            cmdReadFromMail.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }

        //fetch customer email address based on leads id
        public DataTable ReadToMail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadToMail = "LEAD_INDIVIDUAL.SP_FETCH_TO_MAIL";
            OracleCommand cmdReadtoMail = new OracleCommand();
            cmdReadtoMail.CommandText = strQueryReadToMail;
            cmdReadtoMail.CommandType = CommandType.StoredProcedure;
            cmdReadtoMail.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadtoMail.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadtoMail);
            return dtReadFromMail;
        }

        //fetch customer email address based on leads id
        public DataTable ReadOtherToMail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadToMail = "LEAD_INDIVIDUAL.SP_FETCH_OTHER_TO_MAIL";
            OracleCommand cmdReadtoMail = new OracleCommand();
            cmdReadtoMail.CommandText = strQueryReadToMail;
            cmdReadtoMail.CommandType = CommandType.StoredProcedure;
            cmdReadtoMail.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadtoMail.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadtoMail);
            return dtReadFromMail;
        }
        // This Method insert mail and mail attchment details based on lead id
        public void InsertLeadMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachmentList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList, Int32 intSucessSts = 1, int intMailStatus = 2)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryInsertMail = "LEAD_INDIVIDUAL.SP_INSERT_LEAD_MAIL";
                    using (OracleCommand cmdInsertMail = new OracleCommand(strQueryInsertMail, con))
                    {
                        cmdInsertMail.Transaction = tran;




                        cmdInsertMail.CommandType = CommandType.StoredProcedure;
                        cmdInsertMail.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;
                        cmdInsertMail.Parameters.Add("L_LEADSID", OracleDbType.Int64).Value = objEntityMail.Lead_Id; ;
                        cmdInsertMail.Parameters.Add("L_FROMADD", OracleDbType.Varchar2).Value = objEntityMail.From_Email_Address;
                        cmdInsertMail.Parameters.Add("L_TOADD", OracleDbType.Varchar2).Value = objEntityMail.To_Email_Address;
                        cmdInsertMail.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                        cmdInsertMail.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityMail.D_Date;
                        //status 2 means it is a send mail , 1 means it is a received mail
                        cmdInsertMail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = intMailStatus;
                        cmdInsertMail.Parameters.Add("L_SUCESSTS", OracleDbType.Int32).Value = intSucessSts;
                        cmdInsertMail.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                        cmdInsertMail.Parameters.Add("L_CONTENT", OracleDbType.Clob).Value = objEntityMail.Email_Content;

                        if (objEntityMail.Mail_Box_Id == 0)
                        {
                            cmdInsertMail.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = null;
                        }
                        else
                        {
                            cmdInsertMail.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                        }
                        cmdInsertMail.Parameters.Add("L_SUBJECT", OracleDbType.Varchar2).Value = objEntityMail.Email_Subject;
                        cmdInsertMail.ExecuteNonQuery();
                    }

                    //005 start
                    foreach (classEntityToMailAddress objEntityMailTo in objEntityToMailAddressList)
                    {
                        if (objEntityMailTo.ToAddress != "" && objEntityMailTo.ToAddress != null)
                        {
                            string strQueryInsertTo = "LEAD_INDIVIDUAL.SP_INSERT_LEAD_MAIL_MULTY_TO";
                            using (OracleCommand cmdInsertTo = new OracleCommand(strQueryInsertTo, con))
                            {
                                cmdInsertTo.Transaction = tran;

                                cmdInsertTo.CommandType = CommandType.StoredProcedure;
                                cmdInsertTo.Parameters.Add("L_LEADMAILID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;
                                cmdInsertTo.Parameters.Add("L_MAIL_MULT_TO", OracleDbType.Varchar2).Value = objEntityMailTo.ToAddress;
                                cmdInsertTo.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;

                                cmdInsertTo.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (clsEntityMailCcBCc objEntityMailCcBcc in objEntityMailCcBCcList)
                    {
                        if (objEntityMailCcBcc.CcMail != "" && objEntityMailCcBcc.CcMail != null)
                        {
                            string strQueryInsertCc = "LEAD_INDIVIDUAL.SP_INSERT_LEAD_MAIL_CC";
                            using (OracleCommand cmdInsertCc = new OracleCommand(strQueryInsertCc, con))
                            {
                                cmdInsertCc.Transaction = tran;

                                cmdInsertCc.CommandType = CommandType.StoredProcedure;
                                cmdInsertCc.Parameters.Add("L_LEADMAILID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;
                                cmdInsertCc.Parameters.Add("L_MAIL_CC", OracleDbType.Varchar2).Value = objEntityMailCcBcc.CcMail;
                                cmdInsertCc.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;

                                cmdInsertCc.ExecuteNonQuery();
                            }
                        }


                        if (objEntityMailCcBcc.BCcMail != "" && objEntityMailCcBcc.BCcMail != null)
                        {
                            string strQueryInsertBCc = "LEAD_INDIVIDUAL.SP_INSERT_LEAD_MAIL_BCC";
                            using (OracleCommand cmdInsertBCc = new OracleCommand(strQueryInsertBCc, con))
                            {
                                cmdInsertBCc.Transaction = tran;

                                cmdInsertBCc.CommandType = CommandType.StoredProcedure;
                                cmdInsertBCc.Parameters.Add("L_LEADMAILID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;
                                cmdInsertBCc.Parameters.Add("L_MAIL_BCC", OracleDbType.Varchar2).Value = objEntityMailCcBcc.BCcMail;
                                cmdInsertBCc.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;

                                cmdInsertBCc.ExecuteNonQuery();
                            }
                        }
                    }
                    foreach (clsEntityMailAttachment objEntAtt in objEntityMailAttachmentList)
                    {

                        string strQueryInsertAttachment = "LEAD_INDIVIDUAL.SP_INSERT_LEAD_MAIL_ATT";
                        using (OracleCommand cmdInsertAttachment = new OracleCommand(strQueryInsertAttachment, con))
                        {
                            cmdInsertAttachment.Transaction = tran;

                            cmdInsertAttachment.CommandType = CommandType.StoredProcedure;
                            cmdInsertAttachment.Parameters.Add("L_LEADMAILID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;
                            cmdInsertAttachment.Parameters.Add("L_ATT_FILENAME", OracleDbType.Varchar2).Value = objEntAtt.Email_File_Name;
                            cmdInsertAttachment.Parameters.Add("L_ATT_REALNAME", OracleDbType.Varchar2).Value = objEntAtt.Email_Real_Name;
                            cmdInsertAttachment.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;

                            cmdInsertAttachment.ExecuteNonQuery();
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

        // This Method insert mail and mail attchment details based on lead id
        public void UpdateLeadMail(clsEntityMailConsole objEntityMail, Int32 intSucessSts = 1)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateMail = "LEAD_INDIVIDUAL.SP_UPDATE_LEAD_MAIL";
                    using (OracleCommand cmdUpdMail = new OracleCommand(strQueryUpdateMail, con))
                    {
                        cmdUpdMail.Transaction = tran;




                        cmdUpdMail.CommandType = CommandType.StoredProcedure;
                        cmdUpdMail.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityMail.LeadMailId;

                        cmdUpdMail.Parameters.Add("L_FROMADD", OracleDbType.Varchar2).Value = objEntityMail.From_Email_Address;
                        cmdUpdMail.Parameters.Add("L_TOADD", OracleDbType.Varchar2).Value = objEntityMail.To_Email_Address;
                        cmdUpdMail.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                        cmdUpdMail.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityMail.D_Date;


                        cmdUpdMail.Parameters.Add("L_SUCESSTS", OracleDbType.Int32).Value = intSucessSts;
                        cmdUpdMail.Parameters.Add("L_CONTENT", OracleDbType.Clob).Value = objEntityMail.Email_Content;

                        if (objEntityMail.Mail_Box_Id == 0)
                        {
                            cmdUpdMail.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = null;
                        }
                        else
                        {
                            cmdUpdMail.Parameters.Add("L_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                        }
                        cmdUpdMail.Parameters.Add("L_SUBJECT", OracleDbType.Varchar2).Value = objEntityMail.Email_Subject;
                        cmdUpdMail.ExecuteNonQuery();
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



        //fetch send mail list based on lead id
        public DataTable ReadMailList(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadMailList = "LEAD_INDIVIDUAL.SP_READ_LEAD_MAIL_LIST";
            OracleCommand cmdReadMailList = new OracleCommand();
            cmdReadMailList.CommandText = strQueryReadMailList;
            cmdReadMailList.CommandType = CommandType.StoredProcedure;
            cmdReadMailList.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadMailList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadMaillList = new DataTable();
            dtReadMaillList = clsDataLayer.ExecuteReader(cmdReadMailList);
            return dtReadMaillList;
        }

        //fetch mail attachment  based on mail id
        public DataTable ReadMailAttch_ById(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadMailById = "LEAD_INDIVIDUAL.SP_READ_LEAD_MAIL_ATT_BYID";
            OracleCommand cmdReadMailAttById = new OracleCommand();
            cmdReadMailAttById.CommandText = strQueryReadMailById;
            cmdReadMailAttById.CommandType = CommandType.StoredProcedure;
            cmdReadMailAttById.Parameters.Add("L_LEADMAILID", OracleDbType.Int64).Value = objEntityLead.MailBoxId;
            cmdReadMailAttById.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadMailAtt = new DataTable();
            dtReadMailAtt = clsDataLayer.ExecuteReader(cmdReadMailAttById);
            return dtReadMailAtt;
        }

        // This Method checks customer name in the database for duplication.
        public string CheckCustomerName(clsEntityCustomer objEntityCustomer)
        {
            string strQueryCheckCustomerName = "LEAD_INDIVIDUAL.SP_CHECK_CUSTOMER_NAME";
            OracleCommand cmdCheckCustomerName = new OracleCommand();
            cmdCheckCustomerName.CommandText = strQueryCheckCustomerName;
            cmdCheckCustomerName.CommandType = CommandType.StoredProcedure;
            cmdCheckCustomerName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Name;
            cmdCheckCustomerName.Parameters.Add("C_TYPID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Type_Id;
            cmdCheckCustomerName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdCheckCustomerName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdCheckCustomerName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCustomerName);
            string strReturn = cmdCheckCustomerName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCustomerName.Dispose();
            return strReturn;
        }

        // This Method checks Project name in the database for duplication.
        public string CheckProjectName(clsEntityProject objEntityProject)
        {
            string strQueryCheckProjectName = "PROJECT_MASTER.SP_CHECK_PROJECT_NAME";
            OracleCommand cmdCheckProjectName = new OracleCommand();
            cmdCheckProjectName.CommandText = strQueryCheckProjectName;
            cmdCheckProjectName.CommandType = CommandType.StoredProcedure;
            cmdCheckProjectName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
            cmdCheckProjectName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
            cmdCheckProjectName.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
            cmdCheckProjectName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProjectName);
            string strReturn = cmdCheckProjectName.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProjectName.Dispose();
            return strReturn;
        }

        //for reject mail from lead
        public void RejectMail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryRejectMail = "LEAD_INDIVIDUAL.SP_REJECT_MAIL";
            OracleCommand cmdRejectMail = new OracleCommand();
            cmdRejectMail.CommandText = strQueryRejectMail;
            cmdRejectMail.CommandType = CommandType.StoredProcedure;
            cmdRejectMail.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityLead.MailBoxId;
            clsDataLayer.ExecuteNonQuery(cmdRejectMail);
        }
        //for inserting qtn attachment
        public void InsertQtnAttchmnt(List<clsEntityLayerQuotationAttchmntDtl> objEntityQtnAttchmntDeatilsList)
        {
            foreach (clsEntityLayerQuotationAttchmntDtl objQtnAttchDetail in objEntityQtnAttchmntDeatilsList)
            {

                string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INS_QTN_ATCHMNT_BY_TYP";
                using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand())
                {

                    cmdAddInsertQtnAttchmntDetail.CommandText = strQueryInsertQtnAttchmntDetail;
                    cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objQtnAttchDetail.QuotationId;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objQtnAttchDetail.FileName;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objQtnAttchDetail.ActualFileName;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objQtnAttchDetail.QtnAttchmntSlNumber;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_TYPE", OracleDbType.Int32).Value = objQtnAttchDetail.QtnFileType;
                    cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objQtnAttchDetail.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnAttchmntDetail);
                }
            }
        }

        //FOR FECHING QTN ATTACHMENT DETAILS BASED ON QTN TYPE AND ID

        public DataTable ReadQuotationAttchmnt(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadQtnAttchmnt = "QUOTATION.SP_RD_QTN_ATCHMNT_BY_TYP";
            OracleCommand cmdReadQtnAttchmnt = new OracleCommand();
            cmdReadQtnAttchmnt.CommandText = strQueryReadQtnAttchmnt;
            cmdReadQtnAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadQtnAttchmnt.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
            cmdReadQtnAttchmnt.Parameters.Add("Q_QTN_TYPE", OracleDbType.Int32).Value = objEntityLead.QtnFile_Type;
            cmdReadQtnAttchmnt.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnAttchmnt);
            return dtDtl;
        }


        //Delete Quatation Attachments to  table
        public void DeleteQuotationAttachment(clsEntityLeadCreation objEntityLead, string[] strarrCanclAttchIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();

            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    //Delete from quotation attachment table                 
                    foreach (string strDtlId in strarrCanclAttchIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryDeleteQtnAttchmntDetail = "QUOTATION.SP_DELETE_QUOTATION_ATTACHMNT";
                            using (OracleCommand cmdDeleteQtnAttchmntDetail = new OracleCommand(strQueryDeleteQtnAttchmntDetail, con))
                            {
                                cmdDeleteQtnAttchmntDetail.Transaction = tran;

                                cmdDeleteQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                                cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                                cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Int32).Value = intDtlId;

                                cmdDeleteQtnAttchmntDetail.ExecuteNonQuery();
                            }


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

        //FOR FECHING CC MAIL DETAILS BASED ON CCTEXTBOX CONTENT

        public DataTable ReadMailCcDetail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCcdetail = "LEAD_INDIVIDUAL.SP_READ_CC_LDMAILID";
            OracleCommand cmdReadLeadCcDeatil = new OracleCommand();
            cmdReadLeadCcDeatil.CommandText = strQueryReadCcdetail;
            cmdReadLeadCcDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadCcDeatil.Parameters.Add("L_CC_MAILID", OracleDbType.Varchar2).Value = objEntityLead.CcTextboxContent;
            cmdReadLeadCcDeatil.Parameters.Add("L_OUTMAILID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadCcDeatil);

            return dtDtl;

        }

        //for fetching cc mail details based on prvs ccmailaddress
        public DataTable ReadMailCcPreviousAddrs(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCcdetail = "LEAD_INDIVIDUAL.SP_READ_CC_PRVS_ADDRS";
            OracleCommand cmdReadLeadCcDeatil = new OracleCommand();
            cmdReadLeadCcDeatil.CommandText = strQueryReadCcdetail;
            cmdReadLeadCcDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadCcDeatil.Parameters.Add("L_CC_PRVS_MAILID", OracleDbType.Int64).Value = objEntityLead.PrvsCcMailid;
            cmdReadLeadCcDeatil.Parameters.Add("L_OUTMAILID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadCcDeatil);

            return dtDtl;

        }

        //FOR FECHING CC MAIL DETAILS BASED ON BCCTEXTBOX CONTENT

        public DataTable ReadMailBCcDetail(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadBCcdetail = "LEAD_INDIVIDUAL.SP_READ_BCC_LDMAILID";
            OracleCommand cmdReadLeadBCcDeatil = new OracleCommand();
            cmdReadLeadBCcDeatil.CommandText = strQueryReadBCcdetail;
            cmdReadLeadBCcDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadBCcDeatil.Parameters.Add("L_BCC_MAILID", OracleDbType.Varchar2).Value = objEntityLead.BCcTextboxContent;
            cmdReadLeadBCcDeatil.Parameters.Add("L_OUTMAILID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadBCcDeatil);

            return dtDtl;

        }

        //for fetching cc mail details based on prvs Bccmailaddress
        public DataTable ReadMailBCcPreviousAddrs(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadBCcdetail = "LEAD_INDIVIDUAL.SP_READ_BCC_PRVS_ADDRS";
            OracleCommand cmdReadLeadBCcDeatil = new OracleCommand();
            cmdReadLeadBCcDeatil.CommandText = strQueryReadBCcdetail;
            cmdReadLeadBCcDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadBCcDeatil.Parameters.Add("L_BCC_PRVS_MAILID", OracleDbType.Int64).Value = objEntityLead.PrvsBCcMailid;
            cmdReadLeadBCcDeatil.Parameters.Add("L_OUTMAILID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadBCcDeatil);

            return dtDtl;

        }

        //for fetching TO ADDRESSS CC BCC AND SUBJECT FROM LEAD MAIL
        public DataTable ReadMailSubject(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadBCcdetail = "LEAD_INDIVIDUAL.SP_READ_SUBJECT";
            OracleCommand cmdReadLeadBCcDeatil = new OracleCommand();
            cmdReadLeadBCcDeatil.CommandText = strQueryReadBCcdetail;
            cmdReadLeadBCcDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadBCcDeatil.Parameters.Add("L_LDMAILID", OracleDbType.Int64).Value = objEntityLead.PrvsBCcMailid;
            cmdReadLeadBCcDeatil.Parameters.Add("L_OUTMAILIDS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadBCcDeatil);

            return dtDtl;

        }
        public DataTable ReadMailMultyTo(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadTodetail = "LEAD_INDIVIDUAL.SP_READ_MULTYTO";
            OracleCommand cmdReadLeadToDeatil = new OracleCommand();
            cmdReadLeadToDeatil.CommandText = strQueryReadTodetail;
            cmdReadLeadToDeatil.CommandType = CommandType.StoredProcedure;
            cmdReadLeadToDeatil.Parameters.Add("L_LDMAILID", OracleDbType.Int64).Value = objEntityLead.PrvsBCcMailid;
            cmdReadLeadToDeatil.Parameters.Add("L_OUTMAILIDS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadToDeatil);

            return dtDtl;

        }

        //cHANGE Quatation Attachments Status to 1 to  table
        public void ChangeFileMailAtchSts(clsEntityLeadCreation objEntityLead, string[] strarrCanclAttchIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();

            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryInitialiQtnAttchmntDetailsts = "QUOTATION.SP_INTLS_QUOT_ATCHMNT_MAIL_STS";
                    using (OracleCommand cmdIntilizeQtnAttchmntDetail = new OracleCommand(strQueryInitialiQtnAttchmntDetailsts, con))
                    {
                        cmdIntilizeQtnAttchmntDetail.Transaction = tran;
                        cmdIntilizeQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                        cmdIntilizeQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                        cmdIntilizeQtnAttchmntDetail.ExecuteNonQuery();
                    }



                    //Delete from quotation attachment table                 
                    foreach (string strDtlId in strarrCanclAttchIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryStsChngeQtnAttchmntDetail = "QUOTATION.SP_CHNGE_QUOT_ATCHMNT_MAIL_STS";
                            using (OracleCommand cmdStsChngeQtnAttchmntDetail = new OracleCommand(strQueryStsChngeQtnAttchmntDetail, con))
                            {
                                cmdStsChngeQtnAttchmntDetail.Transaction = tran;

                                cmdStsChngeQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                                cmdStsChngeQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                                cmdStsChngeQtnAttchmntDetail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Int32).Value = intDtlId;
                                cmdStsChngeQtnAttchmntDetail.Parameters.Add("Q_STS_ID", OracleDbType.Int32).Value = 1;
                                cmdStsChngeQtnAttchmntDetail.ExecuteNonQuery();
                            }


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
        //EVM0012
        public DataTable Read_ResendMailList(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAtchList = "LEAD_INDIVIDUAL.SP_READ_RESEND_MAIL_LIST";
            OracleCommand cmdReadAtcList = new OracleCommand();
            cmdReadAtcList.CommandText = strQueryReadAtchList;
            cmdReadAtcList.CommandType = CommandType.StoredProcedure;
            cmdReadAtcList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
            cmdReadAtcList.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAtchList = new DataTable();
            dtAtchList = clsDataLayer.ExecuteReader(cmdReadAtcList);
            return dtAtchList;
        }
        //Method for READ EXISTING CUSTOMERS
        public DataTable ReadExistingEmployee(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadEmployee = "LEAD.SP_READ_EXST_EMPLOYEE";
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = strQueryReadEmployee;
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
                cmdReadEmployee.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
                cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
                return dtCorpDept;
            }
        }
        // ToLoad Quotation Status
        public DataTable QuotationStsLead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadEmployee = "LEAD.SP_READ_QUOTN_STS";
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = strQueryReadEmployee;
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;

                cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
                return dtCorpDept;
            }
        }



        // To Insert Quotation Status



        public void InsertQuotationSts(clsEntityLeadCreation objEntityLead)
        {


            string strQueryInsertQtnAttchmntDetail = "LEAD.SP_INS_QUOTN_STS";
            using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand())
            {

                cmdAddInsertQtnAttchmntDetail.CommandText = strQueryInsertQtnAttchmntDetail;
                cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                cmdAddInsertQtnAttchmntDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityLead.LeadId;
                cmdAddInsertQtnAttchmntDetail.Parameters.Add("P_STS_ID", OracleDbType.Int32).Value = objEntityLead.Status;
                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnAttchmntDetail);
            }

        }

        //FOR FECHING QTN ATTACHMENT backup DETAILS BASED ON QTN TYPE AND ID

        public DataTable ReadQuotationAttchmntBackup(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadQtnAttchmnt = "QUOTATION.SP_RD_QTN_ATCHMNT_BKP_BY_TYP";
            OracleCommand cmdReadQtnAttchmnt = new OracleCommand();
            cmdReadQtnAttchmnt.CommandText = strQueryReadQtnAttchmnt;
            cmdReadQtnAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadQtnAttchmnt.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
            cmdReadQtnAttchmnt.Parameters.Add("Q_QTN_TYPE", OracleDbType.Int32).Value = objEntityLead.QtnFile_Type;
            cmdReadQtnAttchmnt.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnAttchmnt);
            return dtDtl;
        }


        public void InsertPartialWinSts(clsEntityLayerQuotation objEntityQuotation)
        {

            string strQueryInsertQtnAttchmntDetail = "LEAD.SP_INS_QUOTN_PRTLWIN_STS";
            using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand())
            {

                cmdAddInsertQtnAttchmntDetail.CommandText = strQueryInsertQtnAttchmntDetail;
                cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                cmdAddInsertQtnAttchmntDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityQuotation.Product_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnAttchmntDetail);
            }

        }

        public void InsertLossStsToAllPrdct(clsEntityLeadCreation objEntityLead)
        {

            string strQuerylOSSAllPrdct = "LEAD.SP_LOSS_ALL_PRDCT";
            using (OracleCommand cmdUpdateLeadStatus = new OracleCommand())
            {

                cmdUpdateLeadStatus.CommandText = strQuerylOSSAllPrdct;
                cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateLeadStatus);
            }
            string strQuerylOSSAllPrdctTrck = "LEAD.SP_LOSS_ALL_PRDCT_TRCK";
            using (OracleCommand cmdUpdateLeadStatus = new OracleCommand())
            {

                cmdUpdateLeadStatus.CommandText = strQuerylOSSAllPrdctTrck;
                cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityLead.Quotation_Id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateLeadStatus);
            }
        }
    }
}
