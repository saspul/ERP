using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerClearanceFormWorker
    {
        //Read employee list
        public DataTable ReadEmployee(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {

                cmdReadEmployee.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_EMPLOYEE";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                cmdReadEmployee.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                cmdReadEmployee.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormWorkerList;
        }
      
        //Read Leave list
        public DataTable ReadLeave(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadLeave = new OracleCommand())
            {
                cmdReadLeave.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_LEAVE";
                cmdReadLeave.CommandType = CommandType.StoredProcedure;
                cmdReadLeave.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadLeave.Parameters.Add("D_STSID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.ApprvStatus;
                cmdReadLeave.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadLeave);
            }
            return dtClearanceFormWorkerList;
        }
        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker, List<clsEntityClearanceFormWorkerDetail> objClearanceFormWorkerDtls)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "CLEARANCE_FORM_WORKER.SP_INSERT_LEAVE_CLR_FORM_WKR";
                    using (OracleCommand cmdInsertClearanceFormWorker = new OracleCommand())
                    {
                        cmdInsertClearanceFormWorker.Transaction = tran;
                        cmdInsertClearanceFormWorker.Connection = con;
                        cmdInsertClearanceFormWorker.CommandText = strQueryInsertDsgn;
                        cmdInsertClearanceFormWorker.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CLEARANCE_FORM_WORKER);
                        objEntCommon.CorporateID = objEntityClearanceFormWorker.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strNextNum);
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveID;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_QP_PASS_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.QpPass_Sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_SIM_CARD_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.SimCard_sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_DRIVING_LIC_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.DrivingLic_sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_TOOLS_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Tools_sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_CLR_TRAFFIC_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CLrTraffic_sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_MESS_AMT_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.MessAmount_sts;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.Comments;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_QP_PASS_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.QpPass;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_SIM_CARD_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.SimCard;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_DRIVING_LIC_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.DrivingLic;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_TOOLS_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.Tools;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_CLR_TRAFFIC_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.CLrTraffic;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_MESS_AMT_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.MessAmount;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_INS_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                        cmdInsertClearanceFormWorker.Parameters.Add("L_LVECLRWKR_INS_DATE", OracleDbType.Date).Value = objEntityClearanceFormWorker.Date;
                        cmdInsertClearanceFormWorker.ExecuteNonQuery();
                    }

                    string strQueryInsertClearanceFormWorkerDtl = "CLEARANCE_FORM_WORKER.SP_INSERT_LV_CLR_FORM_WKR_DTL";
                    foreach (clsEntityClearanceFormWorkerDetail objIntCatDtl in objClearanceFormWorkerDtls)
                    {
                        using (OracleCommand cmdInsertClearanceFormWorkerDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormWorkerDtl.Transaction = tran;
                            cmdInsertClearanceFormWorkerDtl.Connection = con;
                            cmdInsertClearanceFormWorkerDtl.CommandText = strQueryInsertClearanceFormWorkerDtl;
                            cmdInsertClearanceFormWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_PARTICULAR", OracleDbType.Varchar2).Value = objIntCatDtl.Particular;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_STS", OracleDbType.Int32).Value = objIntCatDtl.Particular_sts;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.ParticularRemarks;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Particular_Type;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                            cmdInsertClearanceFormWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormWorker, objEntityIntwCatDtlINSERTList, objEntityIntwCatDtlUPDATEList, objEntityIntwCatDtlDELETEList)
        public void UpdateClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker, List<clsEntityClearanceFormWorkerDetail> objEntityIntwCatDtlINSERTList, List<clsEntityClearanceFormWorkerDetail> objEntityIntwCatDtlUPDATEList, List<clsEntityClearanceFormWorkerDetail> objEntityIntwCatDtlDELETEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "CLEARANCE_FORM_WORKER.SP_UPDATE_LEAVE_CLR_FORM_WKR";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdUpdateClearanceFormWorker = new OracleCommand())
                    {
                        cmdUpdateClearanceFormWorker.Transaction = tran;
                        cmdUpdateClearanceFormWorker.Connection = con;
                        cmdUpdateClearanceFormWorker.CommandText = strQueryUpdateDsgn;
                        cmdUpdateClearanceFormWorker.CommandType = CommandType.StoredProcedure;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveID;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_QP_PASS_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.QpPass_Sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_SIM_CARD_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.SimCard_sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_DRIVING_LIC_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.DrivingLic_sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_TOOLS_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Tools_sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_CLR_TRAFFIC_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CLrTraffic_sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_MESS_AMT_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.MessAmount_sts;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.Comments;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_QP_PASS_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.QpPass;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_SIM_CARD_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.SimCard;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_DRIVING_LIC_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.DrivingLic;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_TOOLS_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.Tools;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_CLR_TRAFFIC_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.CLrTraffic;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_MESS_AMT_RMKS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.MessAmount;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_UPD_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                        cmdUpdateClearanceFormWorker.Parameters.Add("L_LVECLRWKR_UPD_DATE", OracleDbType.Date).Value = objEntityClearanceFormWorker.Date;
                        cmdUpdateClearanceFormWorker.ExecuteNonQuery();
                    }
                    //INSERT DTL
                    string strQueryInsertClearanceFormWorkerDtl = "CLEARANCE_FORM_WORKER.SP_INSERT_LV_CLR_FORM_WKR_DTL";
                    foreach (clsEntityClearanceFormWorkerDetail objIntCatDtl in objEntityIntwCatDtlINSERTList)
                    {
                        using (OracleCommand cmdInsertClearanceFormWorkerDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormWorkerDtl.Transaction = tran;
                            cmdInsertClearanceFormWorkerDtl.Connection = con;
                            cmdInsertClearanceFormWorkerDtl.CommandText = strQueryInsertClearanceFormWorkerDtl;
                            cmdInsertClearanceFormWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_PARTICULAR", OracleDbType.Varchar2).Value = objIntCatDtl.Particular;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_STS", OracleDbType.Int32).Value = objIntCatDtl.Particular_sts;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.ParticularRemarks;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Particular_Type;
                            cmdInsertClearanceFormWorkerDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                            cmdInsertClearanceFormWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryUpdateClearanceFormWorkerDtl = "CLEARANCE_FORM_WORKER.SP_UPDATE_LV_CLR_FORM_WKR_DTL";
                    foreach (clsEntityClearanceFormWorkerDetail objIntCatDtl in objEntityIntwCatDtlUPDATEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormWorkerDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormWorkerDtl.Transaction = tran;
                            cmdUpdateClearanceFormWorkerDtl.Connection = con;
                            cmdUpdateClearanceFormWorkerDtl.CommandText = strQueryUpdateClearanceFormWorkerDtl;
                            cmdUpdateClearanceFormWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrWkrDtlID;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_PARTICULAR", OracleDbType.Varchar2).Value = objIntCatDtl.Particular;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_STS", OracleDbType.Int32).Value = objIntCatDtl.Particular_sts;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.ParticularRemarks;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Particular_Type;
                            cmdUpdateClearanceFormWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE
                    string strQueryDeleteClearanceFormWorkerDtl = "CLEARANCE_FORM_WORKER.SP_DELETE_LV_CLR_FORM_WKR_DTL";
                    foreach (clsEntityClearanceFormWorkerDetail objIntCatDtl in objEntityIntwCatDtlDELETEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormWorkerDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormWorkerDtl.Transaction = tran;
                            cmdUpdateClearanceFormWorkerDtl.Connection = con;
                            cmdUpdateClearanceFormWorkerDtl.CommandText = strQueryDeleteClearanceFormWorkerDtl;
                            cmdUpdateClearanceFormWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrWkrDtlID;
                            cmdUpdateClearanceFormWorkerDtl.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                            cmdUpdateClearanceFormWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        //Read ClearanceFormWorker list 
        public DataTable ReadClearanceFormWorkerList(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadClearanceFormWorkerList = new OracleCommand())
            {
                cmdReadClearanceFormWorkerList.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_CLRNCE_FORM_WKR_LIST";
                cmdReadClearanceFormWorkerList.CommandType = CommandType.StoredProcedure;
                if (objEntityClearanceFormWorker.Empid != 0)
                {
                    cmdReadClearanceFormWorkerList.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                }
                else
                {
                    cmdReadClearanceFormWorkerList.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = null;
                }
                cmdReadClearanceFormWorkerList.Parameters.Add("L_APPRVL_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.ApprvStatus;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_CANCEL", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CancelStatus;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadClearanceFormWorkerList);
            }
            return dtClearanceFormWorkerList;
        }

        //Read worker list
        public DataTable ReadWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_WORKER";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                cmdReadEmployee.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                cmdReadEmployee.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                cmdReadEmployee.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormWorkerList;
        }


        //Read ClearanceFormWorker BY ID 
        public DataTable ReadClearanceFormWorkerByID(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerByID = new DataTable();
            using (OracleCommand cmdReadClearanceFormWorkerByID = new OracleCommand())
            {
                cmdReadClearanceFormWorkerByID.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_CLRNCE_FORM_WKR_BYID";
                cmdReadClearanceFormWorkerByID.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormWorkerByID.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                cmdReadClearanceFormWorkerByID.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                cmdReadClearanceFormWorkerByID.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                cmdReadClearanceFormWorkerByID.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerByID = clsDataLayer.SelectDataTable(cmdReadClearanceFormWorkerByID);
            }
            return dtClearanceFormWorkerByID;
        }
        //Read ClearanceFormWorker Detail BY ID 
        public DataTable ReadClearanceFormWkrDetailByID(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerByID = new DataTable();
            using (OracleCommand cmdReadClearanceFormWorkerByID = new OracleCommand())
            {
                cmdReadClearanceFormWorkerByID.CommandText = "CLEARANCE_FORM_WORKER.SP_RD_CLRNCE_FORM_WKR_DTL_BYID";
                cmdReadClearanceFormWorkerByID.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormWorkerByID.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                cmdReadClearanceFormWorkerByID.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerByID = clsDataLayer.SelectDataTable(cmdReadClearanceFormWorkerByID);
            }
            return dtClearanceFormWorkerByID;
        }
        // This Method delete Consultancy details 
        public void CancelClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            string strQueryCancelClearanceFormWorker = "CLEARANCE_FORM_WORKER.SP_CANCEL_CLRNCE_FORM_WKR";
            using (OracleCommand cmdCancelClearanceFormWorker = new OracleCommand())
            {
                cmdCancelClearanceFormWorker.CommandText = strQueryCancelClearanceFormWorker;
                cmdCancelClearanceFormWorker.CommandType = CommandType.StoredProcedure;
                cmdCancelClearanceFormWorker.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                cmdCancelClearanceFormWorker.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                cmdCancelClearanceFormWorker.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityClearanceFormWorker.Date;
                cmdCancelClearanceFormWorker.Parameters.Add("L_REASON", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelClearanceFormWorker);
            }
        }
        public void RejectClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            string strQueryCancelClearanceFormWorker = "CLEARANCE_FORM_WORKER.SP_RJCT_CLRNCE_FORM_WKR";
            using (OracleCommand cmdCancelClearanceFormWorker = new OracleCommand())
            {
                cmdCancelClearanceFormWorker.CommandText = strQueryCancelClearanceFormWorker;
                cmdCancelClearanceFormWorker.CommandType = CommandType.StoredProcedure;
                cmdCancelClearanceFormWorker.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                cmdCancelClearanceFormWorker.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                cmdCancelClearanceFormWorker.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityClearanceFormWorker.Date;
                cmdCancelClearanceFormWorker.Parameters.Add("L_REASON", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelClearanceFormWorker);
            }
        }
        //Read employee details
        public DataTable ReadEmployeeDtls(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_EMPLOYEE_DTL";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormWorkerList;
        }

        public void ApproveClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            string strQueryCancelClearanceFormWorker = "CLEARANCE_FORM_WORKER.SP_APPROVE_CLRNCE_FORM_WKR";
            using (OracleCommand cmdCancelClearanceFormWorker = new OracleCommand())
            {
                cmdCancelClearanceFormWorker.CommandText = strQueryCancelClearanceFormWorker;
                cmdCancelClearanceFormWorker.CommandType = CommandType.StoredProcedure;
                cmdCancelClearanceFormWorker.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveClrWkrID;
                cmdCancelClearanceFormWorker.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.User_Id;
                cmdCancelClearanceFormWorker.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityClearanceFormWorker.Date;
                cmdCancelClearanceFormWorker.Parameters.Add("L_STATS", OracleDbType.Varchar2).Value = objEntityClearanceFormWorker.ApprvStatus;
                clsDataLayer.ExecuteNonQuery(cmdCancelClearanceFormWorker);
            }
        } //procedure for handover
        public DataTable ReadHadover(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_WORKER.SP_READ_HANDOVER_PROCESS";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("L_LVECLRWKR_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormWorkerList;
        }
        public void UpdateHadover(List<clsEntityLayerClearanceFormWorker> objEntityClearanceFormWorker)
        {
            foreach (clsEntityLayerClearanceFormWorker objEntityClearanceForm in objEntityClearanceFormWorker)
            {
                string strQueryCancelClearanceFormWorker = "CLEARANCE_FORM_WORKER.SP_UPDATE_HANDOVER_PROCESS";
                using (OracleCommand cmdCancelClearanceFormWorker = new OracleCommand())
                {
                    cmdCancelClearanceFormWorker.CommandText = strQueryCancelClearanceFormWorker;
                    cmdCancelClearanceFormWorker.CommandType = CommandType.StoredProcedure;
                    cmdCancelClearanceFormWorker.Parameters.Add("L_SUB_ID", OracleDbType.Int32).Value = objEntityClearanceForm.Subtableid;
                    cmdCancelClearanceFormWorker.Parameters.Add("L_DECSN_ID", OracleDbType.Int32).Value = objEntityClearanceForm.Decision;
                    cmdCancelClearanceFormWorker.Parameters.Add("L_COMMENT", OracleDbType.Varchar2).Value = objEntityClearanceForm.Comments;
                    clsDataLayer.ExecuteNonQuery(cmdCancelClearanceFormWorker);
                }
            }
        }

        public DataTable ReadTrvlDtls(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerByID = new DataTable();
            using (OracleCommand cmdReadClearanceFormWorkerByID = new OracleCommand())
            {
                cmdReadClearanceFormWorkerByID.CommandText = "CLEARANCE_FORM_WORKER.SP_RD_TRVL_DTLS";
                cmdReadClearanceFormWorkerByID.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormWorkerByID.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.LeaveID;
                cmdReadClearanceFormWorkerByID.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerByID = clsDataLayer.SelectDataTable(cmdReadClearanceFormWorkerByID);
            }
            return dtClearanceFormWorkerByID;
        }
        //Read ClearanceFormWorker list 
        public DataTable ReadClearanceFormList(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadClearanceFormWorkerList = new OracleCommand())
            {
                cmdReadClearanceFormWorkerList.CommandText = "LEAVE_APPROVAL.SP_READ_CLRNCE_FORM_APPROVAL";
                cmdReadClearanceFormWorkerList.CommandType = CommandType.StoredProcedure;
                //cmdReadClearanceFormWorkerList.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_APPRVL_STS", OracleDbType.Int32).Value = objEntityClearanceFormWorker.ApprvStatus;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_CANCEL", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CancelStatus;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Organisation_Id;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.CorpOffice_Id;
                cmdReadClearanceFormWorkerList.Parameters.Add("L_LVECLRSTF_MODE", OracleDbType.Int32).Value = objEntityClearanceFormWorker.ClearanceStaffMode;
                 cmdReadClearanceFormWorkerList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadClearanceFormWorkerList);
            }
            return dtClearanceFormWorkerList;
        }
    }
}
