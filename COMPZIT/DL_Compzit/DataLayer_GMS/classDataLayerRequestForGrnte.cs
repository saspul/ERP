using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;

namespace DL_Compzit.DataLayer_GMS
{
    public class classDataLayerRequestForGrnte
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetCH projects
        public DataTable ReadProjects(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadProject = "REQUEST_FOR_GRNTE.SP_READ_PROJECTS";
            OracleCommand cmdReadProject = new OracleCommand();
            cmdReadProject.CommandText = strQueryReadProject;
            cmdReadProject.CommandType = CommandType.StoredProcedure;
            cmdReadProject.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
            cmdReadProject.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadProject.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadProject.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadProject);
            return dtCategory;
        }

        // This Method will fetCH guarantee cat
        public DataTable ReadGuaranteeCat(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadGrntCat = "REQUEST_FOR_GRNTE.SP_READ_GURANT_CAT";
            OracleCommand cmdReadGrntCat = new OracleCommand();
            cmdReadGrntCat.CommandText = strQueryReadGrntCat;
            cmdReadGrntCat.CommandType = CommandType.StoredProcedure;
            cmdReadGrntCat.Parameters.Add("C_PROJID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;
            cmdReadGrntCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadGrntCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadGrntCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadGrntCat);
            return dtCategory;
        }

        // This Method will fetch customer
        public DataTable ReadCustomer(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadCust = "REQUEST_FOR_GRNTE.SP_READ_CUSTOMER";
            OracleCommand cmdReadCustmr = new OracleCommand();
            cmdReadCustmr.CommandText = strQueryReadCust;
            cmdReadCustmr.CommandType = CommandType.StoredProcedure;
            cmdReadCustmr.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
            cmdReadCustmr.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadCustmr.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadCustmr.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadCustmr);
            return dtCustomer;
        }
        // This Method will fetCH employee
        public DataTable ReadEmployee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadEmp = "REQUEST_FOR_GRNTE.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadEmp.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCustomer;
        }
        // This Method will fetCH currency
        public DataTable ReadCurrency(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadCrncy = "REQUEST_FOR_GRNTE.SP_READ_CURRENCY";
            OracleCommand cmdReadCrncy = new OracleCommand();
            cmdReadCrncy.CommandText = strQueryReadCrncy;
            cmdReadCrncy.CommandType = CommandType.StoredProcedure;
            cmdReadCrncy.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadCrncy.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadCrncy.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadCrncy);
            return dtCustomer;
        }
        // This Method will fetCH job category
        public DataTable ReadJobCategory(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadJobCat = "REQUEST_FOR_GRNTE.SP_READ_JOB_CAT";
            OracleCommand cmdReadJobCat = new OracleCommand();
            cmdReadJobCat.CommandText = strQueryReadJobCat;
            cmdReadJobCat.CommandType = CommandType.StoredProcedure;
            cmdReadJobCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadJobCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadJobCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadJobCat);
            return dtCustomer;
        }
        // This Method adds request for Guarantee details to the table
        public void AddRqstForGuarantee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryAddRequest = "REQUEST_FOR_GRNTE.SP_INS_RQSTFRGRNTY_DETAILS";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryAddRequest;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("C_ID", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.NextIdForRqst;
                cmdAddRequest.Parameters.Add("C_REFNUM", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.RefNumber;
                cmdAddRequest.Parameters.Add("C_PRJCT_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;
                cmdAddRequest.Parameters.Add("C_GRNTYTYP", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarTypeId;
                cmdAddRequest.Parameters.Add("C_GRNTYCATID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarCatId;
                cmdAddRequest.Parameters.Add("C_CUSTID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CustomerId;
                cmdAddRequest.Parameters.Add("C_INFVR", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.InFavrOf;

                if (objEntityRqstFrGrnty.Validity != 0)
                {
                    cmdAddRequest.Parameters.Add("C_VALDTY", OracleDbType.Int64).Value = objEntityRqstFrGrnty.Validity;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("C_VALDTY", OracleDbType.Int64).Value = null;
                }

                cmdAddRequest.Parameters.Add("C_PRCLDATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.ProjCloseDate;
                cmdAddRequest.Parameters.Add("C_AMOUNT", OracleDbType.Decimal).Value = objEntityRqstFrGrnty.Amount;
                cmdAddRequest.Parameters.Add("C_CURRID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CurrencyId;
                if (objEntityRqstFrGrnty.ContactName!="")
                {
                    cmdAddRequest.Parameters.Add("C_CNTCTNAME", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.ContactName;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("C_CNTCTNAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.EmployeId != 0)
                {
                cmdAddRequest.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.EmployeId;
                }
                else
                {
                cmdAddRequest.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = null;
                }
                if (objEntityRqstFrGrnty.ContactMail!="")
                {
                cmdAddRequest.Parameters.Add("C_CNTCTMAIL", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.ContactMail;
                }
                else
                {
                cmdAddRequest.Parameters.Add("C_CNTCTMAIL", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.Remarks!="")
                {
                cmdAddRequest.Parameters.Add("C_REMARKS", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.Remarks;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("C_REMARKS", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.JobCat_Id != 0)
                {
                 cmdAddRequest.Parameters.Add("C_JOBCAT", OracleDbType.Int32).Value = objEntityRqstFrGrnty.JobCat_Id;
                }
                else
                {
                  cmdAddRequest.Parameters.Add("C_JOBCAT", OracleDbType.Int32).Value = null;
                }
                cmdAddRequest.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
                cmdAddRequest.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
                cmdAddRequest.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
                cmdAddRequest.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                //EVM-0016
                if (objEntityRqstFrGrnty.FileName != "")
                {
                    cmdAddRequest.Parameters.Add("C_RFG_FILENAME", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.FileName;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("C_RFG_FILENAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.FileNameAct != "")
                {
                    cmdAddRequest.Parameters.Add("C_RFG_FILEACT", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.FileNameAct;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("C_RFG_FILEACT", OracleDbType.Varchar2).Value = null;
                }
                //EVM-0016
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        // This Method update request for Guarantee details to the table
        public void UpdateRqstForGuarantee(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateRequest = "REQUEST_FOR_GRNTE.SP_UPD_RQSTFRGRNTY_DETAILS";
            using (OracleCommand cmdUpdRequest = new OracleCommand())
            {
                cmdUpdRequest.CommandText = strQueryUpdateRequest;
                cmdUpdRequest.CommandType = CommandType.StoredProcedure;

                cmdUpdRequest.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdRequest.Parameters.Add("C_PRJCT_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;
                cmdUpdRequest.Parameters.Add("C_GRNTYTYP", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarTypeId;
                cmdUpdRequest.Parameters.Add("C_GRNTYCATID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarCatId;
                cmdUpdRequest.Parameters.Add("C_CUSTID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CustomerId;
                cmdUpdRequest.Parameters.Add("C_INFVR", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.InFavrOf;
                if (objEntityRqstFrGrnty.Validity != 0)
                {
                    cmdUpdRequest.Parameters.Add("C_VALDTY", OracleDbType.Int64).Value = objEntityRqstFrGrnty.Validity;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_VALDTY", OracleDbType.Int64).Value = null;
                }

                cmdUpdRequest.Parameters.Add("C_PRCLSDATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.ProjCloseDate;
                cmdUpdRequest.Parameters.Add("C_AMOUNT", OracleDbType.Decimal).Value = objEntityRqstFrGrnty.Amount;
                cmdUpdRequest.Parameters.Add("C_CURRID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CurrencyId;
                if (objEntityRqstFrGrnty.ContactName != "")
                {
                    cmdUpdRequest.Parameters.Add("C_CNTCTNAME", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.ContactName;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_CNTCTNAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.EmployeId != 0)
                {
                    cmdUpdRequest.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.EmployeId;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = null;
                }
                if (objEntityRqstFrGrnty.ContactMail != "")
                {
                    cmdUpdRequest.Parameters.Add("C_CNTCTMAIL", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.ContactMail;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_CNTCTMAIL", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.Remarks != "")
                {
                    cmdUpdRequest.Parameters.Add("C_REMARKS", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.Remarks;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_REMARKS", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.JobCat_Id != 0)
                {
                    cmdUpdRequest.Parameters.Add("C_JOBCAT", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.JobCat_Id;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_JOBCAT", OracleDbType.Int32).Value = null;
                }
                cmdUpdRequest.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
                cmdUpdRequest.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
                cmdUpdRequest.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
                cmdUpdRequest.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                cmdUpdRequest.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                //EVM-0016
                if (objEntityRqstFrGrnty.FileName != "")
                {
                    cmdUpdRequest.Parameters.Add("C_RFG_FILENAME", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.FileName;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_RFG_FILENAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityRqstFrGrnty.FileNameAct != "")
                {
                    cmdUpdRequest.Parameters.Add("C_RFG_FILEACT", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.FileNameAct;
                }
                else
                {
                    cmdUpdRequest.Parameters.Add("C_RFG_FILEACT", OracleDbType.Varchar2).Value = null;
                }
                //EVM-0016
                clsDataLayer.ExecuteNonQuery(cmdUpdRequest);
            }
        }


        //Method for cancel job category
        public void CancelRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryCancelRequest = "REQUEST_FOR_GRNTE.SP_CANCEL_RQSTFRGRNTY";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryCancelRequest;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdCancelRequest.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                cmdCancelRequest.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelRequest.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }
        //Method for CLOSE job category
        public void CloseRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryCancelRequest = "REQUEST_FOR_GRNTE.SP_CLOSE_RQSTFRGRNTY";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryCancelRequest;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdCancelRequest.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                cmdCancelRequest.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelRequest.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }
        //method for recall request whx=ich is cancelled
        public void ReCallRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReCallRequest = "REQUEST_FOR_GRNTE.SP_RECALL_RQSTFRGRNTY";
            OracleCommand cmdReCallRequest = new OracleCommand();
            cmdReCallRequest.CommandText = strQueryReCallRequest;
            cmdReCallRequest.CommandType = CommandType.StoredProcedure;
            cmdReCallRequest.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
            cmdReCallRequest.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
            cmdReCallRequest.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdReCallRequest);
        }
        // This Method will request for guarantee DEATILS BY ID
        public DataTable ReadRqstFrGrntyById(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_READ_RQSTFRGRNTY_BY_ID";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }

        // This Method will request for guarantee DEATILS BY ID
        public DataTable ReadpRrojectById(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_READ_PROJECT_BY_ID";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }
         // This Method will fetch job category list
        public DataTable ReadRequestFrGrntyList(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadCntrctList = "REQUEST_FOR_GRNTE.SP_READ_RQST_FR_GRNTY_LIST";
            OracleCommand cmdReadCntrctList = new OracleCommand();
            cmdReadCntrctList.CommandText = strQueryReadCntrctList;
            cmdReadCntrctList.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctList.Parameters.Add("C_CUSTID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CustomerId;
            cmdReadCntrctList.Parameters.Add("C_GUACATID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarCatId;
            cmdReadCntrctList.Parameters.Add("C_CNFRMSTS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Confirm_Status;
            cmdReadCntrctList.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
            cmdReadCntrctList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadCntrctList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadCntrctList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
            cmdReadCntrctList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Cancel_Status;
            cmdReadCntrctList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCntrctList);
            return dtCategoryList;
        }

        // This Method WILL READ EMPLOYEE BY ID
        public DataTable ReadEmployeeData(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_READ_EMPLOYEE_BY_ID";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.EmployeId;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }


        public void ChangeRequestStatus(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateSts = "REQUEST_FOR_GRNTE.SP_UPD_CNTRCT_STATUS";
            using (OracleCommand cmdUpdateSts = new OracleCommand())
            {
                cmdUpdateSts.CommandText = strQueryUpdateSts;
                cmdUpdateSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateSts.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdateSts.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateSts);
            }
        }
        public void ConfirmRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateSts = "REQUEST_FOR_GRNTE.SP_CNFRM_REQUEST";
            using (OracleCommand cmdUpdateSts = new OracleCommand())
            {
                cmdUpdateSts.CommandText = strQueryUpdateSts;
                cmdUpdateSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateSts.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdateSts.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                cmdUpdateSts.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateSts);
            }
        }
        public void ReOpenRequest(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateSts = "REQUEST_FOR_GRNTE.SP_REOPEN_REQUEST";
            using (OracleCommand cmdUpdateSts = new OracleCommand())
            {
                cmdUpdateSts.CommandText = strQueryUpdateSts;
                cmdUpdateSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateSts.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdateSts.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                cmdUpdateSts.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateSts);
            }
        }

        // for print by id;;
        public DataTable ReqgurnteePrint(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            //LOGIC FOR BUSINESS LAYER

            //
            //
            string strQueryReqGrn = "REQUEST_FOR_GRNTE.SP_GUARANTEE_PRINT";
            OracleCommand cmdgrreq = new OracleCommand();
            cmdgrreq.CommandText = strQueryReqGrn;
            cmdgrreq.CommandType = CommandType.StoredProcedure;
            cmdgrreq.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdgrreq.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdgrreq.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
            cmdgrreq.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtret = new DataTable();
            dtret = clsDataLayer.ExecuteReader(cmdgrreq);
            return dtret;


            //
            //
        }

        public string ReadBankGuranteeById(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadBankGuarnt = "REQUEST_FOR_GRNTE.SP_READ_GURNTNO_CHK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
           
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }
        public string ChkAwardedBiding(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadAwrd = "REQUEST_FOR_GRNTE.SP_CHK_AWRDBIDING";
            OracleCommand cmdReadAwrd = new OracleCommand();
            cmdReadAwrd.CommandText = strQueryReadAwrd;
            cmdReadAwrd.CommandType = CommandType.StoredProcedure;

            cmdReadAwrd.Parameters.Add("C_PRJCT_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;

            cmdReadAwrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadAwrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadAwrd.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadAwrd);
            string strReturn = cmdReadAwrd.Parameters["B_OUT"].Value.ToString();
            cmdReadAwrd.Dispose();
            return strReturn;
        }
        public string ChkCatagory(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryReadBankGuarnt = "REQUEST_FOR_GRNTE.SP_CHK_CATAGRY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("B_CATGRY_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.GuarCatId;

            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }
        //EVM-0016
        public DataTable BindCorptShortName(classEntityLayerRequestForGrnte objEntityRequestForGrnte)
        {
            string strQueryReqGrn = "REQUEST_FOR_GRNTE.SP_GET_CORPOFFICE";
            OracleCommand cmdgrreq = new OracleCommand();
            cmdgrreq.CommandText = strQueryReqGrn;
            cmdgrreq.CommandType = CommandType.StoredProcedure;
            cmdgrreq.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityRequestForGrnte.CorpOffice_Id;
            cmdgrreq.Parameters.Add("C_CORP_SHORTNAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtret = new DataTable();
            dtret = clsDataLayer.ExecuteReader(cmdgrreq);
            return dtret;
        }
        //EVM-0016
        //to check projct is awarded or bidding
        public DataTable ChekAwardOrBiddg(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_PRJC_AWRD_BIDG_CHK";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("PRJCT_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ProjectId;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }


        public void ChangeReqToProcd(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateSts = "REQUEST_FOR_GRNTE.SP_PROCEED_STATUS";
            using (OracleCommand cmdUpdateSts = new OracleCommand())
            {
                cmdUpdateSts.CommandText = strQueryUpdateSts;
                cmdUpdateSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateSts.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdateSts.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
                cmdUpdateSts.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdUpdateSts.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateSts);
            }
        }

        public void ChangeToReissue(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateSts = "REQUEST_FOR_GRNTE.SP_REISSUE_STATUS";
            using (OracleCommand cmdUpdateSts = new OracleCommand())
            {
                cmdUpdateSts.CommandText = strQueryUpdateSts;
                cmdUpdateSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateSts.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
                cmdUpdateSts.Parameters.Add("REASON", OracleDbType.Varchar2).Value = objEntityRqstFrGrnty.Cancel_reason;
                cmdUpdateSts.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
                cmdUpdateSts.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdUpdateSts.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateSts);
            }
        }


        public DataTable ReadRFGStatusdtails(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_READ_DTLS_STATUS";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
            cmdReadRqstFrGrnty.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Guarantee_Status;
            cmdReadRqstFrGrnty.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadRqstFrGrnty.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }


        public DataTable HistoryList(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryRqstFrGrnty = "REQUEST_FOR_GRNTE.SP_READ_HISTORY_LST";
            OracleCommand cmdReadRqstFrGrnty = new OracleCommand();
            cmdReadRqstFrGrnty.CommandText = strQueryRqstFrGrnty;
            cmdReadRqstFrGrnty.CommandType = CommandType.StoredProcedure;
            cmdReadRqstFrGrnty.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;

            cmdReadRqstFrGrnty.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
            cmdReadRqstFrGrnty.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
            cmdReadRqstFrGrnty.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.User_Id;
            cmdReadRqstFrGrnty.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRqstFrGrnty);
            return dtCategory;
        }

        public void UpdateRqstForGuaranteeReissue(classEntityLayerRequestForGrnte objEntityRqstFrGrnty)
        {
            string strQueryUpdateRequest = "REQUEST_FOR_GRNTE.SP_UPD_RFQ_REISSUE_DETAILS";
            using (OracleCommand cmdUpdRequest = new OracleCommand())
            {
                cmdUpdRequest.CommandText = strQueryUpdateRequest;
                cmdUpdRequest.CommandType = CommandType.StoredProcedure;

                cmdUpdRequest.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.ReqForGuarId;
             
              

                cmdUpdRequest.Parameters.Add("C_PRCLSDATE", OracleDbType.Date).Value = objEntityRqstFrGrnty.ProjCloseDate;
                cmdUpdRequest.Parameters.Add("C_AMOUNT", OracleDbType.Decimal).Value = objEntityRqstFrGrnty.Amount;
              
                cmdUpdRequest.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.Organisation_Id;
                cmdUpdRequest.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityRqstFrGrnty.CorpOffice_Id;
                
                clsDataLayer.ExecuteNonQuery(cmdUpdRequest);
            }
        }

    }
     
}
