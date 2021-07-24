using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDatalayerEmployeeDeduction
    {

        // This Method add the Payroll details to the table
        public void Add_Deduction_Master(ClsEntityEmployeeDeduction objEntityEmployeeDeduction, List<ClsEntityEmployeeDeduction> objEntityEmployeeDeductionlist)
        {
            string strQueryPayrol = "EMPLOYEE_DEDUCTION.SP_ADD_DEDUCTN_MSTR";
            using (OracleCommand cmdReadPayroll = new OracleCommand())
            {
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int64).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_DOC_NO", OracleDbType.Int64).Value = objEntityEmployeeDeduction.Documentno;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_REF_NO", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Reference_Number;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_EMPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeId;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_DEDCTNID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.DeductionId;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_AMOUNT", OracleDbType.Double).Value = objEntityEmployeeDeduction.Amount;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_EFFECTIVE_DATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.EffectiveDate;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_INSTLMNTNO", OracleDbType.Int32).Value = objEntityEmployeeDeduction.InstallementNo;

                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_INSTLMNTPLAN", OracleDbType.Int32).Value = objEntityEmployeeDeduction.InstallementPlan;
                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_REMARKS", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Remarks;

                cmdReadPayroll.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
                cmdReadPayroll.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;

                cmdReadPayroll.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = DateTime.Today;
                cmdReadPayroll.Parameters.Add("P_INSUSRID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.UserId;
                // cmdReadPayroll.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdReadPayroll);
            } Delete_Deduction_Details(objEntityEmployeeDeduction);
            foreach (ClsEntityEmployeeDeduction objInstalmntDtl in objEntityEmployeeDeductionlist)
            {
                Add_Deduction_Details(objInstalmntDtl);
            }
         
        }
        public void Update_Deduction_Master(ClsEntityEmployeeDeduction objEntityEmployeeDeduction, List<ClsEntityEmployeeDeduction> objEntityEmployeeDeductionlist,string instmtStatus)
        {
            
            Delete_Deduction_Details(objEntityEmployeeDeduction);
            if (instmtStatus=="1")
            {
                string strQueryPayrol = "EMPLOYEE_DEDUCTION.SP_UPDATE_INSTALMENT";
                using (OracleCommand cmdReadPayroll = new OracleCommand())
                {
                  
                    cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                    cmdReadPayroll.CommandText = strQueryPayrol;
                    cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int64).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_DOC_NO", OracleDbType.Int64).Value = objEntityEmployeeDeduction.Documentno;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_REF_NO", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Reference_Number;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_EMPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeId;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_DEDCTNID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.DeductionId;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_AMOUNT", OracleDbType.Double).Value = objEntityEmployeeDeduction.Amount;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_EFFECTIVE_DATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.EffectiveDate;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_INSTLMNTNO", OracleDbType.Int32).Value = objEntityEmployeeDeduction.InstallementNo;

                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_INSTLMNTPLAN", OracleDbType.Int32).Value = objEntityEmployeeDeduction.InstallementPlan;
                    cmdReadPayroll.Parameters.Add("P_EMPDEDTN_REMARKS", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Remarks;

                    cmdReadPayroll.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
                    cmdReadPayroll.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;

                    cmdReadPayroll.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = DateTime.Today;
                    cmdReadPayroll.Parameters.Add("P_UPDUSRID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.UserId;
                    // cmdReadPayroll.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    clsDataLayer.ExecuteNonQuery(cmdReadPayroll);






                    
                }
            }
            foreach (ClsEntityEmployeeDeduction objInstalmntDtl in objEntityEmployeeDeductionlist)
            {
                Add_Deduction_Details(objInstalmntDtl);
            }

        }//Method for cancel Payroll
        public void Cancel_Payroll(clsEntityLayerPayroll objEntityEmployeeDeduction)
        {
            string strQueryCancelJobCat = "PAYROLL_MASTER.SP_CANCEL_PAYRL";
            using (OracleCommand cmdCancelJobCat = new OracleCommand())
            {
                cmdCancelJobCat.CommandText = strQueryCancelJobCat;
                cmdCancelJobCat.CommandType = CommandType.StoredProcedure;
                cmdCancelJobCat.Parameters.Add("P_PAYRLID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.Payrl_ID;
                cmdCancelJobCat.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CnclUser_Id;
                cmdCancelJobCat.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.CnclDateTime;
                cmdCancelJobCat.Parameters.Add("P_REASON", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelJobCat);
            }
        }
        public void Add_Deduction_Details(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            string strQueryPayrol = "EMPLOYEE_DEDUCTION.SP_ADD_INSTALLMENT";
            using (OracleCommand cmdReadPayroll = new OracleCommand())
            {
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                cmdReadPayroll.Parameters.Add("P_DEDTN_INSTL_DATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.InstallmentDate;
                cmdReadPayroll.Parameters.Add("P_DEDTN_INSTL_AMOUNT", OracleDbType.Double).Value = objEntityEmployeeDeduction.InstallmentAmount;
                if (objEntityEmployeeDeduction.PaidDate != DateTime.MinValue)
                    cmdReadPayroll.Parameters.Add("P_DEDTN_INSTL_PAIDDATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.PaidDate;
                else
                    cmdReadPayroll.Parameters.Add("P_DEDTN_INSTL_PAIDDATE", OracleDbType.Date).Value = DBNull.Value;
                if (objEntityEmployeeDeduction.TotLPaid != 0)
                    cmdReadPayroll.Parameters.Add("P_DEDTN_PAID_AMOUNT", OracleDbType.Double).Value = objEntityEmployeeDeduction.TotLPaid;
                else
                    cmdReadPayroll.Parameters.Add("P_DEDTN_PAID_AMOUNT", OracleDbType.Int32).Value = DBNull.Value;

                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;

                clsDataLayer.ExecuteNonQuery(cmdReadPayroll);
            }
        }

        public void Delete_Deduction_Details(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
            string strQueryPayrol = "EMPLOYEE_DEDUCTION.SP_DELTE_INSTALLMENT";
            using (OracleCommand cmdReadPayroll = new OracleCommand(strQueryPayrol, con))
            {
                con.Open();
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;


                cmdReadPayroll.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
                cmdReadPayroll.ExecuteNonQuery();
             
            }
        }


        public DataTable ReadDeductionList(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            string strQueryReadPayGrd = "EMPLOYEE_DEDUCTION.SP_READ_DEDUCTN_MSTR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
            cmdReadPayGrd.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityEmployeeDeduction.Mode;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            string strQueryReadPayGrd = "EMPLOYEE_DEDUCTION.SP_READ_DEDUCTN_MSTRBY_ID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadInstallmentDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            string strQueryReadPayGrd = "EMPLOYEE_DEDUCTION.SP_READ_DEDUCTN_INSTALLMNT_ID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public string CheckDocNum(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {

            string strQueryLeaveTyp = "EMPLOYEE_DEDUCTION.SP_CHECK_DOC_NUM";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
            cmdReadLeav.Parameters.Add("P_EMPDEDTN_DOC_NO", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Documentno;
            cmdReadLeav.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadLeav.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
            cmdReadLeav.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadLeav);
            string strReturn = cmdReadLeav.Parameters["P_COUNT"].Value.ToString();
            cmdReadLeav.Dispose();
            return strReturn;
        }

        public void ConfirmDedcution(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {

            string strQueryLeaveTyp = "EMPLOYEE_DEDUCTION.SP_CONFIRM_DEDUCTION";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
            cmdReadLeav.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadLeav.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
           // cmdReadLeav.ExecuteNonQuery();

            clsDataLayer.ExecuteNonQuery(cmdReadLeav);
        }


        public void DeleDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {

            string strQueryLeaveTyp = "EMPLOYEE_DEDUCTION.SP_DELE_DEDUCTION_BYID";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.DeductionId;
            cmdReadLeav.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.UserId;
            cmdReadLeav.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmployeeDeduction.EffectiveDate;
            cmdReadLeav.Parameters.Add("P_REASN", OracleDbType.Varchar2).Value = objEntityEmployeeDeduction.Remarks;
            clsDataLayer.ExecuteNonQuery(cmdReadLeav);
        }
        public DataTable CheckEffctveDate(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            string strQueryReadPayGrd = "EMPLOYEE_DEDUCTION.SP_CHECK_EFFCTV_DATE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_CORPT_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
            cmdReadPayGrd.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadPayGrd.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public void ReopenDedcution(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {

            string strQueryLeaveTyp = "EMPLOYEE_DEDUCTION.SP_REOPEN_DEDUCTION";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.EmployeeDeductionID;
            cmdReadLeav.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
            cmdReadLeav.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
            // cmdReadLeav.ExecuteNonQuery();

            clsDataLayer.ExecuteNonQuery(cmdReadLeav);
        }


     
       
    }
}
