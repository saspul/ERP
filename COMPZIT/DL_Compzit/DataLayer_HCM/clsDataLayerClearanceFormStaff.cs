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
    public class clsDataLayerClearanceFormStaff
    {
        //Read employee list
        public DataTable ReadEmployee(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {

                cmdReadEmployee.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_EMPLOYEE";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                cmdReadEmployee.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadEmployee.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                if (objEntityClearanceFormStaff.RequstDate != DateTime.MinValue)
                {
                    cmdReadEmployee.Parameters.Add("RQST_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.RequstDate;
                }
                else
                {
                    cmdReadEmployee.Parameters.Add("RQST_DATE", OracleDbType.Date).Value = null;
                }
                if (objEntityClearanceFormStaff.AllocationDate != DateTime.MinValue)
                {
                    cmdReadEmployee.Parameters.Add("ALLOC_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.AllocationDate;
                }
                else
                {
                    cmdReadEmployee.Parameters.Add("ALLOC_DATE", OracleDbType.Date).Value = null;
                }
       
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormStaffList;
        }

        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objClearanceFormStaffDtls, List<clsEntityClearanceFormStaffSub> objClearanceFormStaffSub)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "CLEARANCE_FORM_STAFF.SP_INSERT_LEAVE_CLR_STAFF";
                    using (OracleCommand cmdInsertClearanceFormStaff = new OracleCommand())
                    {
                        cmdInsertClearanceFormStaff.Transaction = tran;
                        cmdInsertClearanceFormStaff.Connection = con;
                        cmdInsertClearanceFormStaff.CommandText = strQueryInsertDsgn;
                        cmdInsertClearanceFormStaff.CommandType = CommandType.StoredProcedure;

                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Empid;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_TAKE_OVR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.TakeOverEmpID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.FileName;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.ActualFileName;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.Comments;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_INS_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_INS_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_MODE", OracleDbType.Int32).Value = objEntityClearanceFormStaff.ClrnceStaffMode;
                        cmdInsertClearanceFormStaff.ExecuteNonQuery();
                    }

                    string strQueryInsertClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_INSERT_LEAVE_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objClearanceFormStaffDtls)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffDtl.Transaction = tran;
                            cmdInsertClearanceFormStaffDtl.Connection = con;
                            cmdInsertClearanceFormStaffDtl.CommandText = strQueryInsertClearanceFormStaffDtl;
                            cmdInsertClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    string strQueryInsertClearanceFormStaffsSub = "CLEARANCE_FORM_STAFF.SP_INSERT_LEAVE_CLR_STAFF_SUB";
                    foreach (clsEntityClearanceFormStaffSub objIntCatDtl in objClearanceFormStaffSub)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffSub = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffSub.Transaction = tran;
                            cmdInsertClearanceFormStaffSub.Connection = con;
                            cmdInsertClearanceFormStaffSub.CommandText = strQueryInsertClearanceFormStaffsSub;
                            cmdInsertClearanceFormStaffSub.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_SUBJECT_ID", OracleDbType.Int32).Value = objIntCatDtl.SubjectID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_AVAIL_STS", OracleDbType.Int32).Value = objIntCatDtl.AvailabilitySts;
                            cmdInsertClearanceFormStaffSub.ExecuteNonQuery();
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
        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormStaff, objEntityStaffDtlINSERTList, objEntityStaffDtlUPDATEList, objEntityStaffDtlDELETEList)
        public void UpdateClearanceFormStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlINSERTList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlUPDATEList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlDELETEList, List<clsEntityClearanceFormStaffSub> objEntityStaffSubUPDATEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "CLEARANCE_FORM_STAFF.SP_UPDATE_LEAVE_CLR_STAFF";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdUpdateClearanceFormStaff = new OracleCommand())
                    {
                        cmdUpdateClearanceFormStaff.Transaction = tran;
                        cmdUpdateClearanceFormStaff.Connection = con;
                        cmdUpdateClearanceFormStaff.CommandText = strQueryUpdateDsgn;
                        cmdUpdateClearanceFormStaff.CommandType = CommandType.StoredProcedure;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Empid;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_TAKE_OVR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.TakeOverEmpID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.FileName;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.ActualFileName;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.Comments;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_UPD_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_UPD_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                        cmdUpdateClearanceFormStaff.ExecuteNonQuery();
                    }
                    //update Sub

                    string strQueryUpdateClearanceFormStaffSub = "CLEARANCE_FORM_STAFF.SP_UPDATE_LEAVE_CLR_STAFF_SUB";
                    foreach (clsEntityClearanceFormStaffSub objIntCatDtl in objEntityStaffSubUPDATEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffSub = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffSub.Transaction = tran;
                            cmdUpdateClearanceFormStaffSub.Connection = con;
                            cmdUpdateClearanceFormStaffSub.CommandText = strQueryUpdateClearanceFormStaffSub;
                            cmdUpdateClearanceFormStaffSub.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_SUBJECT_ID", OracleDbType.Int32).Value = objIntCatDtl.SubjectID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_AVAIL_STS", OracleDbType.Int32).Value = objIntCatDtl.AvailabilitySts;
                            cmdUpdateClearanceFormStaffSub.ExecuteNonQuery();
                        }
                    }

                    //INSERT DTL
                    string strQueryInsertClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_INSERT_LEAVE_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlINSERTList)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffDtl.Transaction = tran;
                            cmdInsertClearanceFormStaffDtl.Connection = con;
                            cmdInsertClearanceFormStaffDtl.CommandText = strQueryInsertClearanceFormStaffDtl;
                            cmdInsertClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryUpdateClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_UPDATE_LEAVE_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlUPDATEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffDtl.Transaction = tran;
                            cmdUpdateClearanceFormStaffDtl.Connection = con;
                            cmdUpdateClearanceFormStaffDtl.CommandText = strQueryUpdateClearanceFormStaffDtl;
                            cmdUpdateClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRWKR_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdUpdateClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE
                    string strQueryDeleteClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_DELETE_LV_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlDELETEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffDtl.Transaction = tran;
                            cmdUpdateClearanceFormStaffDtl.Connection = con;
                            cmdUpdateClearanceFormStaffDtl.CommandText = strQueryDeleteClearanceFormStaffDtl;
                            cmdUpdateClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffDtl.ExecuteNonQuery();
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
        //Read leave details   
        public DataTable ReadLeaveDtls(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_LEAVE_DTL";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                cmdReadEmployee.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadEmployee.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormStaffList;
        }

        //Read employee details
        public DataTable ReadEmployeeDtls(clsEntityLayerClearanceFormStaff objEntityClearanceFormWorker)
        {
            DataTable dtClearanceFormWorkerList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_EMPLOYEE_DTL";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormWorker.Empid;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormWorkerList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormWorkerList;
        }


        //Read ClearanceFormStaff  
        public DataTable ReadClearanceFormStaffByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_STAFF_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityClearanceFormStaff.ApprvStatus;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.ExecuteReader(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }
        //Read ClearanceFormStaff  Sub
        public DataTable ReadClrFormStaffSubByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_STAFF_SUB_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }
        //Read ClearanceFormStaff  Details
        public DataTable ReadClrFormStaffDetailByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_STAFF_DTL_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }


        //Start:-EMP-0009
        //For approving clearance form staff details
        public void ApproveClrncStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_APRVE_CLRNCE_STAFF_DTL_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                clsDataLayer.ExecuteNonQuery(cmdReadClearanceFormStaffList);
            }
          
        }
        //For rejecting clearance form staff details
        public void RejectClrncStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_REJCT_CLRNCE_STAFF_DTL_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                cmdReadClearanceFormStaffList.Parameters.Add("L_REASN", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdReadClearanceFormStaffList);
            }

        }

        public DataTable ReadDivisionOfEmp(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            string strQueryReadCntrctCatgry = "CLEARANCE_FORM_STAFF.SP_READ_DIVISIONS_EMP";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Empid;
            cmdReadCntrctCatgry.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }
   //For resignation form
        //Read resignation details   
        public DataTable ReadLeaveDtlsResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_RESG_DTL";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                cmdReadEmployee.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadEmployee.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadEmployee.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormStaffList;
        }
        //Read ClearanceFormStaff  
        public DataTable ReadClearanceFormStaffByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_RESG_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityClearanceFormStaff.ApprvStatus;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.ExecuteReader(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }
        //Read ClearanceFormStaff  Sub
        public DataTable ReadClrFormStaffSubByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_RESG_SUB_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }
        //Read ClearanceFormStaff  Details
        public DataTable ReadClrFormStaffDetailByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_READ_CLRNCE_RESG_DTL_BYID";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                cmdReadClearanceFormStaffList.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }

        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormStaffResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objClearanceFormStaffDtls, List<clsEntityClearanceFormStaffSub> objClearanceFormStaffSub)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "CLEARANCE_FORM_STAFF.SP_INSERT_RESG_CLR_STAFF";
                    using (OracleCommand cmdInsertClearanceFormStaff = new OracleCommand())
                    {
                        cmdInsertClearanceFormStaff.Transaction = tran;
                        cmdInsertClearanceFormStaff.Connection = con;
                        cmdInsertClearanceFormStaff.CommandText = strQueryInsertDsgn;
                        cmdInsertClearanceFormStaff.CommandType = CommandType.StoredProcedure;

                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Empid;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_TAKE_OVR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.TakeOverEmpID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.FileName;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.ActualFileName;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.Comments;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_INS_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                        cmdInsertClearanceFormStaff.Parameters.Add("L_LVECLRSTF_INS_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                        cmdInsertClearanceFormStaff.ExecuteNonQuery();
                    }

                    string strQueryInsertClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_INSERT_RESG_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objClearanceFormStaffDtls)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffDtl.Transaction = tran;
                            cmdInsertClearanceFormStaffDtl.Connection = con;
                            cmdInsertClearanceFormStaffDtl.CommandText = strQueryInsertClearanceFormStaffDtl;
                            cmdInsertClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    string strQueryInsertClearanceFormStaffsSub = "CLEARANCE_FORM_STAFF.SP_INSERT_RESG_CLR_STAFF_SUB";
                    foreach (clsEntityClearanceFormStaffSub objIntCatDtl in objClearanceFormStaffSub)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffSub = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffSub.Transaction = tran;
                            cmdInsertClearanceFormStaffSub.Connection = con;
                            cmdInsertClearanceFormStaffSub.CommandText = strQueryInsertClearanceFormStaffsSub;
                            cmdInsertClearanceFormStaffSub.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_SUBJECT_ID", OracleDbType.Int32).Value = objIntCatDtl.SubjectID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffSub.Parameters.Add("L_AVAIL_STS", OracleDbType.Int32).Value = objIntCatDtl.AvailabilitySts;
                            cmdInsertClearanceFormStaffSub.ExecuteNonQuery();
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
        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormStaff, objEntityStaffDtlINSERTList, objEntityStaffDtlUPDATEList, objEntityStaffDtlDELETEList)
        public void UpdateClearanceFormStaffResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlINSERTList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlUPDATEList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlDELETEList, List<clsEntityClearanceFormStaffSub> objEntityStaffSubUPDATEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "CLEARANCE_FORM_STAFF.SP_UPDATE_RESG_CLR_STAFF";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdUpdateClearanceFormStaff = new OracleCommand())
                    {
                        cmdUpdateClearanceFormStaff.Transaction = tran;
                        cmdUpdateClearanceFormStaff.Connection = con;
                        cmdUpdateClearanceFormStaff.CommandText = strQueryUpdateDsgn;
                        cmdUpdateClearanceFormStaff.CommandType = CommandType.StoredProcedure;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Empid;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_TAKE_OVR_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.TakeOverEmpID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LEAVE_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveID;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.FileName;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.ActualFileName;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_COMMENTS", OracleDbType.Varchar2).Value = objEntityClearanceFormStaff.Comments;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.Organisation_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_UPD_USR_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                        cmdUpdateClearanceFormStaff.Parameters.Add("L_LVECLRSTF_UPD_DATE", OracleDbType.Date).Value = objEntityClearanceFormStaff.Date;
                        cmdUpdateClearanceFormStaff.ExecuteNonQuery();
                    }
                    //update Sub

                    string strQueryUpdateClearanceFormStaffSub = "CLEARANCE_FORM_STAFF.SP_UPDATE_RESG_CLR_STAFF_SUB";
                    foreach (clsEntityClearanceFormStaffSub objIntCatDtl in objEntityStaffSubUPDATEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffSub = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffSub.Transaction = tran;
                            cmdUpdateClearanceFormStaffSub.Connection = con;
                            cmdUpdateClearanceFormStaffSub.CommandText = strQueryUpdateClearanceFormStaffSub;
                            cmdUpdateClearanceFormStaffSub.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_SUBJECT_ID", OracleDbType.Int32).Value = objIntCatDtl.SubjectID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_LVECLRSTF_SUB_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdUpdateClearanceFormStaffSub.Parameters.Add("L_AVAIL_STS", OracleDbType.Int32).Value = objIntCatDtl.AvailabilitySts;
                            cmdUpdateClearanceFormStaffSub.ExecuteNonQuery();
                        }
                    }

                    //INSERT DTL
                    string strQueryInsertClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_INSERT_RESG_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlINSERTList)
                    {
                        using (OracleCommand cmdInsertClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdInsertClearanceFormStaffDtl.Transaction = tran;
                            cmdInsertClearanceFormStaffDtl.Connection = con;
                            cmdInsertClearanceFormStaffDtl.CommandText = strQueryInsertClearanceFormStaffDtl;
                            cmdInsertClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdInsertClearanceFormStaffDtl.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.CorpOffice_Id;
                            cmdInsertClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryUpdateClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_UPDATE_RESG_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlUPDATEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffDtl.Transaction = tran;
                            cmdUpdateClearanceFormStaffDtl.Connection = con;
                            cmdUpdateClearanceFormStaffDtl.CommandText = strQueryUpdateClearanceFormStaffDtl;
                            cmdUpdateClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRWKR_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_SUBJECT", OracleDbType.Varchar2).Value = objIntCatDtl.Subject;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_HNDED_USR_ID", OracleDbType.Int32).Value = objIntCatDtl.HandedOverEmpID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_DECISION", OracleDbType.Int32).Value = objIntCatDtl.Decision;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_COMMENTS", OracleDbType.Varchar2).Value = objIntCatDtl.Comments;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_REMARKS", OracleDbType.Varchar2).Value = objIntCatDtl.SubjectRemarks;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_TYPE", OracleDbType.Int32).Value = objIntCatDtl.Subject_Type;
                            cmdUpdateClearanceFormStaffDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE
                    string strQueryDeleteClearanceFormStaffDtl = "CLEARANCE_FORM_STAFF.SP_DELETE_RESG_CLR_STAFF_DTL";
                    foreach (clsEntityClearanceFormStaffDetail objIntCatDtl in objEntityStaffDtlDELETEList)
                    {
                        using (OracleCommand cmdUpdateClearanceFormStaffDtl = new OracleCommand())
                        {
                            cmdUpdateClearanceFormStaffDtl.Transaction = tran;
                            cmdUpdateClearanceFormStaffDtl.Connection = con;
                            cmdUpdateClearanceFormStaffDtl.CommandText = strQueryDeleteClearanceFormStaffDtl;
                            cmdUpdateClearanceFormStaffDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.LeaveClrStaffDtlID;
                            cmdUpdateClearanceFormStaffDtl.Parameters.Add("L_LVECLRSTF_ID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.LeaveClrStaffID;
                            cmdUpdateClearanceFormStaffDtl.ExecuteNonQuery();
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
        //End:-EMP-0009
        public DataTable ReadFromDate(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadClearanceFormStaffList = new OracleCommand())
            {
                cmdReadClearanceFormStaffList.CommandText = "CLEARANCE_FORM_STAFF.SP_RAED_FROMDATE";
                cmdReadClearanceFormStaffList.CommandType = CommandType.StoredProcedure;
                cmdReadClearanceFormStaffList.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityClearanceFormStaff.User_Id;
                cmdReadClearanceFormStaffList.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadClearanceFormStaffList);
            }
            return dtClearanceFormStaffList;
        }
    }
}
