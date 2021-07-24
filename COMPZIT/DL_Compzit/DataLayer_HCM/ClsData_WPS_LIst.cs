using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class ClsData_WPS_LIst
    {
        public DataTable LoadBissnusUnit(ClsEntityLayerWps_List objEntitySalary, int AllBussChk)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_BUSINESSUNIT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
            cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = AllBussChk;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDivision(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_DIVISION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
            cmdReadPayGrd.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntitySalary.Department;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDep(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_DEPARTMENT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDesg(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_DESIGNATION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadBank(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_BANK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadPayerBank(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_LOAD_PAYER_BANK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadMonthlySal_PaidList(ClsEntityLayerWps_List objEntityPaymtCls)
        {
            string strQueryReadSalaryPaidList = "HCM_MONTHLY_SALARY_WPS_LIST.SP_SALARY_PAID_LIST";
            OracleCommand cmdReadSalaryPaidList = new OracleCommand();
            cmdReadSalaryPaidList.CommandText = strQueryReadSalaryPaidList;
            cmdReadSalaryPaidList.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryPaidList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
            cmdReadSalaryPaidList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryPaidList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPaymtCls.CorprtId;
            cmdReadSalaryPaidList.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
            cmdReadSalaryPaidList.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityPaymtCls.Month;
            cmdReadSalaryPaidList.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPaymtCls.Year;
            cmdReadSalaryPaidList.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityPaymtCls.Staff_Worker;
            cmdReadSalaryPaidList.Parameters.Add("P_BSNS_UNT", OracleDbType.Int32).Value = objEntityPaymtCls.BusnsUnitId;
            cmdReadSalaryPaidList.Parameters.Add("P_DESIG", OracleDbType.Int32).Value = objEntityPaymtCls.Designation;
            cmdReadSalaryPaidList.Parameters.Add("P_DIVSN", OracleDbType.Int32).Value = objEntityPaymtCls.Division;
            cmdReadSalaryPaidList.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objEntityPaymtCls.Department;
            cmdReadSalaryPaidList.Parameters.Add("P_BANK", OracleDbType.Int32).Value = objEntityPaymtCls.BankId;

            if (objEntityPaymtCls.date != DateTime.MinValue)
            {
                cmdReadSalaryPaidList.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPaymtCls.date;
            }
            else
            {
                cmdReadSalaryPaidList.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadSalaryPaidList.Parameters.Add("P_SPONSOR_ID", OracleDbType.Int32).Value = objEntityPaymtCls.SponsorId;
            cmdReadSalaryPaidList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryPaidList);
            return dtSalList;
        }

        public DataTable LoadSIFHeaderDetails(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_SIF_HEAD_DTLS";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadSIFHeader.Parameters.Add("C_BANK_ID", OracleDbType.Int32).Value = objEntitySalary.BankId;
            cmdReadSIFHeader.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
     
        }
        public DataTable ReadBankName(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_BANK_WITHID";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("BKID", OracleDbType.Int32).Value = objEntitySalary.BankId;
            cmdReadSIFHeader.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
        }
        public DataTable ReadPayerBank(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_PAYER_BANK_WITHID";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("BKID", OracleDbType.Int32).Value = objEntitySalary.PayerBankId;
            cmdReadSIFHeader.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
        }
        public DataTable ReadSIFRecordDetails(ClsEntityLayerWps_List objEntitySalary, string[] EmpList)
        {
            DataTable dtGridDisp = new DataTable();
            for (int i = 0; i < EmpList.Length; i++)
            {
                if (EmpList[i].ToString() != "")
                {
                    string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_SIF_EMPLOYEE_DTLS";
                    OracleCommand cmdReadSIFHeader = new OracleCommand();
                    cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
                    cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
                    cmdReadSIFHeader.Parameters.Add("C_EMP_ID", OracleDbType.Int32).Value = EmpList[i];
                    cmdReadSIFHeader.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntitySalary.Mode;
                    cmdReadSIFHeader.Parameters.Add("C_BANK_ID", OracleDbType.Int32).Value = objEntitySalary.BankId;
                    cmdReadSIFHeader.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                    cmdReadSIFHeader.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                    cmdReadSIFHeader.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
                    cmdReadSIFHeader.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;

                    cmdReadSIFHeader.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtSIFHeader = new DataTable();
                    dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
                    dtGridDisp.Merge(dtSIFHeader);
                    dtGridDisp.AcceptChanges();
                }
            }
       
            return dtGridDisp;
        }


        //0041
        public DataTable ReadSIFRecordDetailsESPandLSP(ClsEntityLayerWps_List objEntitySalary)
        {
            DataTable dtGridDisp = new DataTable();
            
                    string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_SIF_EMPLOYEE_DTLS";
                    OracleCommand cmdReadSIFHeader = new OracleCommand();
                    cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
                    cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
                    cmdReadSIFHeader.Parameters.Add("C_EMP_ID", OracleDbType.Int32).Value =objEntitySalary.EmpEID;
                    cmdReadSIFHeader.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntitySalary.Mode;
                    cmdReadSIFHeader.Parameters.Add("C_BANK_ID", OracleDbType.Int32).Value = objEntitySalary.BankId;
                    cmdReadSIFHeader.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                    cmdReadSIFHeader.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                    cmdReadSIFHeader.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
                    cmdReadSIFHeader.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;

                    cmdReadSIFHeader.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtSIFHeader = new DataTable();
                    dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
                    return dtSIFHeader;
            }

        //end
           

        
        public DataTable ReadDocumentName(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_EMP_DOC_DTLS";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("C_EMP_ID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadSIFHeader.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
        }

        public DataTable LoadMonthlySalList(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_MONTHLYSAL_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
            cmdReadPayGrd.Parameters.Add("P_SAVCONF", OracleDbType.Int32).Value = objEntitySalary.ExportStatus;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadEmpBank(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_BANKACCOUNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_BKID", OracleDbType.Int32).Value = objEntitySalary.BankId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void InsertToWPSList(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryInsertWPSList = "HCM_MONTHLY_SALARY_WPS_LIST.SP_INS_WPS_LIST_DETAILS";
            OracleCommand cmdInsertWPSList = new OracleCommand();
            cmdInsertWPSList.CommandText = strQueryInsertWPSList;
            cmdInsertWPSList.CommandType = CommandType.StoredProcedure;
            cmdInsertWPSList.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdInsertWPSList.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
            cmdInsertWPSList.Parameters.Add("W_MODE", OracleDbType.Int32).Value = objEntitySalary.Mode;
            cmdInsertWPSList.Parameters.Add("W_MONTH", OracleDbType.Int32).Value =objEntitySalary.Month;
            cmdInsertWPSList.Parameters.Add("W_YEAR", OracleDbType.Int32).Value =objEntitySalary.Year;
            cmdInsertWPSList.Parameters.Add("W_BANK", OracleDbType.Int32).Value =objEntitySalary.BankId;
            cmdInsertWPSList.Parameters.Add("W_TYPE", OracleDbType.Int32).Value =objEntitySalary.Staff_Worker;
            if (objEntitySalary.Designation==0)
            {
                cmdInsertWPSList.Parameters.Add("W_DEGNTN", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdInsertWPSList.Parameters.Add("W_DEGNTN", OracleDbType.Int32).Value = objEntitySalary.Designation;
            }
            if (objEntitySalary.Department == 0)
            {
                cmdInsertWPSList.Parameters.Add("W_DEPT", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdInsertWPSList.Parameters.Add("W_DEPT", OracleDbType.Int32).Value = objEntitySalary.Department;
            }
            if (objEntitySalary.Division == 0)
            {
                cmdInsertWPSList.Parameters.Add("W_DIVISION", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdInsertWPSList.Parameters.Add("W_DIVISION", OracleDbType.Int32).Value = objEntitySalary.Division;
            }
            cmdInsertWPSList.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            cmdInsertWPSList.Parameters.Add("W_EMP_COUNT", OracleDbType.Int32).Value = objEntitySalary.ExportEmpCount;
            cmdInsertWPSList.Parameters.Add("WPS_EXPORT_DATE", OracleDbType.Date).Value = objEntitySalary.WPS_date;
            cmdInsertWPSList.Parameters.Add("EMPR_EID", OracleDbType.Varchar2).Value = objEntitySalary.EmpEID;
            cmdInsertWPSList.Parameters.Add("FILE_DATE", OracleDbType.Date).Value = objEntitySalary.FileDate;
            cmdInsertWPSList.Parameters.Add("FILE_TIME", OracleDbType.Date).Value = objEntitySalary.Filetime;
            cmdInsertWPSList.Parameters.Add("P_QID", OracleDbType.Int32).Value = objEntitySalary.PayerQID;
            cmdInsertWPSList.Parameters.Add("P_BANK_IN", OracleDbType.Varchar2).Value = objEntitySalary.PayerBankId;
            cmdInsertWPSList.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = objEntitySalary.IBAN;
            cmdInsertWPSList.Parameters.Add("T_SAL", OracleDbType.Decimal).Value = objEntitySalary.TotalSalary;
            cmdInsertWPSList.Parameters.Add("T_RECORD", OracleDbType.Int32).Value = objEntitySalary.TotalRecord;
            cmdInsertWPSList.Parameters.Add("EM_QID", OracleDbType.Varchar2).Value = objEntitySalary.EmpQid;
            cmdInsertWPSList.Parameters.Add("EM_VISA", OracleDbType.Varchar2).Value = objEntitySalary.EmpVisa;
            cmdInsertWPSList.Parameters.Add("E_NAME", OracleDbType.Varchar2).Value = objEntitySalary.EmpName;
            cmdInsertWPSList.Parameters.Add("EM_ACC", OracleDbType.Varchar2).Value = objEntitySalary.BankAccountno;
            cmdInsertWPSList.Parameters.Add("SAL_FRE", OracleDbType.Varchar2).Value = objEntitySalary.SalFreqncy;
            cmdInsertWPSList.Parameters.Add("DAYS", OracleDbType.Decimal).Value = objEntitySalary.WorkingDays;
            cmdInsertWPSList.Parameters.Add("NET_SAL", OracleDbType.Decimal).Value = objEntitySalary.NetSalary;
            cmdInsertWPSList.Parameters.Add("BASIC_SAL", OracleDbType.Decimal).Value = objEntitySalary.BasicSalary;
            cmdInsertWPSList.Parameters.Add("EXTRA_HR", OracleDbType.Decimal).Value = objEntitySalary.ExtraHr;
            cmdInsertWPSList.Parameters.Add("EXTRA_IN", OracleDbType.Decimal).Value = objEntitySalary.ExtraIncome;
            cmdInsertWPSList.Parameters.Add("DEDUCTN", OracleDbType.Decimal).Value = objEntitySalary.Deduction;
            cmdInsertWPSList.Parameters.Add("COMMENTS", OracleDbType.Varchar2).Value = objEntitySalary.Commentss;
            cmdInsertWPSList.Parameters.Add("IDENT", OracleDbType.Int32).Value = objEntitySalary.NxtID;
            cmdInsertWPSList.Parameters.Add("PRCSSD_BASIC_SAL", OracleDbType.Decimal).Value = objEntitySalary.SalaryPrcssdBasicSalary;
            clsDataLayer.ExecuteNonQuery(cmdInsertWPSList);
        }
        public DataTable ReadFor_PreView_Header(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_FOR_PREVIEW_HEADER";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("WPS_ID", OracleDbType.Int32).Value = objEntitySalary.RowId;
            cmdReadSIFHeader.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
        }
        public DataTable ReadFor_PreView_Record(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadSIFHeader = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_FOR_PREVIEW_RECORD";
            OracleCommand cmdReadSIFHeader = new OracleCommand();
            cmdReadSIFHeader.CommandText = strQueryReadSIFHeader;
            cmdReadSIFHeader.CommandType = CommandType.StoredProcedure;
            cmdReadSIFHeader.Parameters.Add("WPS_ID", OracleDbType.Int32).Value = objEntitySalary.RowId;
            cmdReadSIFHeader.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSIFHeader = new DataTable();
            dtSIFHeader = clsDataLayer.ExecuteReader(cmdReadSIFHeader);
            return dtSIFHeader;
        }
        public void UpdateSettledStatus(ClsEntityLayerWps_List objEntityWPS, List<ClsEntityLayerWps_List> objEntityLayerWps_List)
        {  
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateStatus = "HCM_MONTHLY_SALARY_WPS_LIST.SP_UPDATE_STLMNT_STATUS";
                    foreach (ClsEntityLayerWps_List objWps_List in objEntityLayerWps_List)
                    {
                        using (OracleCommand cmdrWps_List = new OracleCommand())
                        {
                            cmdrWps_List.Transaction = tran;
                            cmdrWps_List.Connection = con;
                            cmdrWps_List.CommandText = strQueryUpdateStatus;
                            cmdrWps_List.CommandType = CommandType.StoredProcedure;
                            cmdrWps_List.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityWPS.Mode;
                            cmdrWps_List.Parameters.Add("P_STL_ID", OracleDbType.Varchar2).Value = objWps_List.SettledId;
                            cmdrWps_List.ExecuteNonQuery();
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
        public DataTable ReadEmpWorkingDays(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadWorkingDays = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_WORKINGDAYS";
            OracleCommand cmdReadWorkingDays = new OracleCommand();
            cmdReadWorkingDays.CommandText = strQueryReadWorkingDays;
            cmdReadWorkingDays.CommandType = CommandType.StoredProcedure;
            cmdReadWorkingDays.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadWorkingDays.Parameters.Add("FROMDATE", OracleDbType.Date).Value = objEntitySalary.LvFromDate;
            cmdReadWorkingDays.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntitySalary.LvToDate;
            cmdReadWorkingDays.Parameters.Add("D_TO_DT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtWorkingDays = new DataTable();
            dtWorkingDays = clsDataLayer.ExecuteReader(cmdReadWorkingDays);
            return dtWorkingDays;
        }
        public DataTable ReadLeavSettlmentChk(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadCorp = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_LEAV_SETTLMENT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadCorp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            string combmonthyear = objEntitySalary.Month.ToString("00") + "-" + objEntitySalary.Year;
            cmdReadCorp.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable LoadSponsor(ClsEntityLayerWps_List objEntitySalary)
        {
            string strQueryReadPayGrd = "HCM_MONTHLY_SALARY_WPS_LIST.SP_READ_SPONSOR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorprtId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
    }
}
