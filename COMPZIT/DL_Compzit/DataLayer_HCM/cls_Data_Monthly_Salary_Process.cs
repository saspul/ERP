using CL_Compzit;
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
   public class cls_Data_Monthly_Salary_Process
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        public DataTable LoadBissnusUnit(cls_Entity_Monthly_Salary_Process objEntitySalary, int AllBussChk)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_BUSINESSUNIT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = AllBussChk;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDivision(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DIVISION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntitySalary.Dep;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDep(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEPARTMENT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadDesg(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DESIGNATION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable LoadSalaryPrssList(cls_Entity_Monthly_Salary_Process objEntitySalary,List<cls_Entity_Monthly_Salary_Process> objEmp)
        {
            DataTable dt = new DataTable();
            if (objEmp.Count > 0)
            {
                foreach (cls_Entity_Monthly_Salary_Process objEntityEmp in objEmp)
                {
                    DataTable dtCategory = new DataTable();
                    string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_SALPROSS_LIST";
                    OracleCommand cmdReadPayGrd = new OracleCommand();
                    cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                    cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                    cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                    cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                    cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                    cmdReadPayGrd.Parameters.Add("P_STFFWORKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
                    cmdReadPayGrd.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntitySalary.Division;
                    cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.Dep;
                    cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityEmp.Employee;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                    cmdReadPayGrd.Parameters.Add("P_DESG", OracleDbType.Int32).Value = objEntitySalary.Desg;
                    //DateTime pdate = objEntitySalary.date;
                    string pmonth = objEntitySalary.Month.ToString("00");
                        //pdate.Month.ToString();
                    string pyear = objEntitySalary.Year.ToString();
                        //pdate.Year.ToString();
                    string combmonthyear = pmonth + "-" + pyear;
                    cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;

                    if (objEntitySalary.Month != 0 && objEntitySalary.Year != 0)
                    {
                        DateTime firstOfNextMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1).AddMonths(1);
                        DateTime DStartThisMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1);
                        string lastOfThisMonth = firstOfNextMonth.AddDays(-1).ToString("dd-MM-yyyy");
                        string strDStartThisMonth = DStartThisMonth.ToString("dd-MM-yyyy");
                        DateTime lastOfThisMonth1 = objCommon.textToDateTime(lastOfThisMonth);
                        DateTime DStartThisMonth1 = objCommon.textToDateTime(strDStartThisMonth);
                        cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = DStartThisMonth1;
                        cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = lastOfThisMonth1;
                    }
                    else
                    {
                        cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntitySalary.date;
                        cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntitySalary.date;
                    }
                    if (objEntitySalary.Month == 1)
                    {
                        cmdReadPayGrd.Parameters.Add("P_MONTH_PRE", OracleDbType.Int32).Value =12;
                        cmdReadPayGrd.Parameters.Add("P_YEAR_PRE", OracleDbType.Int32).Value = objEntitySalary.Year-1;                      
                    }
                    else
                    {
                        cmdReadPayGrd.Parameters.Add("P_MONTH_PRE", OracleDbType.Int32).Value = objEntitySalary.Month-1;
                        cmdReadPayGrd.Parameters.Add("P_YEAR_PRE", OracleDbType.Int32).Value = objEntitySalary.Year;
                    }
                    cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
                    dt.Merge(dtCategory);
                    dt.AcceptChanges();
                }
            }
            else
            {
                DataTable dtCategory = new DataTable();
                string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_SALPROSS_LIST";
                OracleCommand cmdReadPayGrd = new OracleCommand();
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                cmdReadPayGrd.Parameters.Add("P_STFFWORKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
                cmdReadPayGrd.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntitySalary.Division;
                cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.Dep;
                cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                cmdReadPayGrd.Parameters.Add("P_DESG", OracleDbType.Int32).Value = objEntitySalary.Desg;
               // DateTime pdate = objEntitySalary.date;
                string pmonth = objEntitySalary.Month.ToString("00");
                string pyear = objEntitySalary.Year.ToString();
                string combmonthyear = pmonth + "-" + pyear;
                cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
                if (objEntitySalary.Month != 0 && objEntitySalary.Year != 0)
                {
                    DateTime firstOfNextMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1).AddMonths(1);
                    DateTime DStartThisMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1);
                    string lastOfThisMonth = firstOfNextMonth.AddDays(-1).ToString("dd-MM-yyyy");
                    string strDStartThisMonth = DStartThisMonth.ToString("dd-MM-yyyy");
                    DateTime lastOfThisMonth1 = objCommon.textToDateTime(lastOfThisMonth);
                    DateTime DStartThisMonth1 = objCommon.textToDateTime(strDStartThisMonth);
                    cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = DStartThisMonth1;
                    cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = lastOfThisMonth1;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntitySalary.date;
                    cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntitySalary.date;
                }
                if (objEntitySalary.Month == 1)
                {
                    cmdReadPayGrd.Parameters.Add("P_MONTH_PRE", OracleDbType.Int32).Value = 12;
                    cmdReadPayGrd.Parameters.Add("P_YEAR_PRE", OracleDbType.Int32).Value = objEntitySalary.Year - 1;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_MONTH_PRE", OracleDbType.Int32).Value = objEntitySalary.Month - 1;
                    cmdReadPayGrd.Parameters.Add("P_YEAR_PRE", OracleDbType.Int32).Value = objEntitySalary.Year;
                }
                cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
               
            }
            return dt;
        }

        public DataTable ReadAllounceListEdit(clsEntityLayerEmpSalary objEntitySalary, string SalProssId)
        {
            int ID = Convert.ToInt32(SalProssId);
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLOWSALARY_PRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_SALPRSSID", OracleDbType.Int32).Value = ID;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadAllounceList(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
          
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLOWSALARY";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadDeductionListEdit(clsEntityLayerEmpSalary objEntitySalary, string SalProssId)
        {
             int ID = Convert.ToInt32(SalProssId);
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCTNSALARY_PRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice_Id;
                cmdReadPayGrd.Parameters.Add("P_SALPRSSID", OracleDbType.Int32).Value = ID;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadDeductionList(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCTNSALARY";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadPaymenDeductionList(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_PAYMENT_DEDCTN";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            string pmonth = objEntitySalary.Month.ToString("00");
            string pyear = objEntitySalary.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadAllounceDailyhrList(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLOW_DAILYHR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            string pmonth = objEntitySalary.Month.ToString("00");
            string pyear = objEntitySalary.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            int days = DateTime.DaysInMonth(objEntitySalary.Year, objEntitySalary.Month);
            string EmDate = new DateTime(objEntitySalary.Year, objEntitySalary.Month, days).ToString("dd-MM-yyyy");
            DateTime ddate = objCommon.textToDateTime(EmDate);
            cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_END_DATE", OracleDbType.Date).Value = ddate;
            cmdReadPayGrd.Parameters.Add("P_LVID", OracleDbType.Int32).Value = objEntitySalary.LeaveId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void InsertProssDtls(cls_Entity_Monthly_Salary_Process objEntitySalary, List<cls_Entity_Monthly_Salary_Process> objEmp, List<cls_Entity_Monthly_Salary_Process> ObjAllwance, List<cls_Entity_Monthly_Salary_Process> ObjDeductn)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEmp.Count > 0)
                    {
                        foreach (cls_Entity_Monthly_Salary_Process objEntityEmp in objEmp)
                        {

                            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_INSERT_SALARYPROCESS";
                            using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadPayGrd, con))
                            {

                                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
                                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                                cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                                cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                                cmdReadPayGrd.Parameters.Add("P_STFFWORKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
                                cmdReadPayGrd.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntitySalary.Division;
                                cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.Dep;
                                cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityEmp.Employee;
                                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                                cmdReadPayGrd.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
                                cmdReadPayGrd.Parameters.Add("P_BASICPAY", OracleDbType.Decimal).Value = objEntityEmp.BasicPay;




                                DateTime firstOfNextMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1).AddMonths(1);
                                string lastOfThisMonth = firstOfNextMonth.AddDays(-1).ToString("dd-MM-yyyy");

                                DateTime lastOfThisMonth1 = objCommon.textToDateTime(lastOfThisMonth);



                                DateTime DStartThisMonth = new DateTime(objEntitySalary.Year, objEntitySalary.Month, 1);

                                string strDStartThisMonth = DStartThisMonth.ToString("dd-MM-yyyy");

                                DateTime DStartThisMonth1 = objCommon.textToDateTime(strDStartThisMonth);

                                cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = DStartThisMonth1;



                                cmdReadPayGrd.Parameters.Add("P_DATE_MESS", OracleDbType.Date).Value = lastOfThisMonth1;
                                cmdReadPayGrd.Parameters.Add("P_MESSDEDCTN_AMNT", OracleDbType.Decimal).Value = objEntityEmp.MessAmnt;
                                cmdReadPayGrd.Parameters.Add("P_LV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityEmp.LvArrearAmnt;
                                cmdReadPayGrd.Parameters.Add("P_TOTAL_AMT", OracleDbType.Decimal).Value = objEntityEmp.TotMount;
                                cmdReadPayGrd.Parameters.Add("P_OVERTIME_AMT", OracleDbType.Decimal).Value = objEntityEmp.AllowOverTmAmnt;
                                cmdReadPayGrd.Parameters.Add("P_ALLOW_AMNT", OracleDbType.Decimal).Value = objEntityEmp.SpecialAllAmnt;
                                cmdReadPayGrd.Parameters.Add("P_DED_AMNT", OracleDbType.Decimal).Value = objEntityEmp.SpecialDedAmnt;
                                cmdReadPayGrd.Parameters.Add("P_DDCTN_INSTL_AMNT", OracleDbType.Decimal).Value = objEntityEmp.InstalAmount;
                                cmdReadPayGrd.Parameters.Add("P_LEVNUM", OracleDbType.Decimal).Value = objEntityEmp.NumLeav;
                                cmdReadPayGrd.Parameters.Add("P_OTHR_ADD_AMNT", OracleDbType.Decimal).Value = objEntityEmp.OtherAdditionAmt;
                                cmdReadPayGrd.Parameters.Add("P_OTHR_DEDCT_AMNT", OracleDbType.Decimal).Value = objEntityEmp.OtherDeductionAmt;
                                cmdReadPayGrd.Parameters.Add("P_PREV_ARRE_AMNT", OracleDbType.Decimal).Value = objEntityEmp.PrevMnthArreAmt;
                                //emp-0043 start
                                cmdReadPayGrd.Parameters.Add("P_PAYMENT_TYPE", OracleDbType.Decimal).Value = objEntityEmp.PaymentType;
                                //end
                                cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdReadPayGrd.ExecuteNonQuery();


                                //EVM-0027 FEB 27

                                string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
                                cmdReadPayGrd.Dispose();
                                //Allwanc

                                foreach (cls_Entity_Monthly_Salary_Process objEntityAllwance in ObjAllwance)
                                {
                                    //var checkedItems = ObjAllwance.Where(objEntityEmp.Employee => objEntityAllwance.Employee);
                                    //if (objEntityEmp.Employee == objEntityAllwance.Employee)
                                    //{
                                    var checkedItems = ObjAllwance.Where(i => i.Employee == objEntityEmp.Employee);
                                    foreach (cls_Entity_Monthly_Salary_Process item in checkedItems)
                                    {
                                        // file operations

                                        string strQueryAllowance = "MONTHLY_SALARY_PEOSESS.SP_UPDATE_PROCCESD_ALLOWNCE";
                                        using (OracleCommand cmdReadAllwance = new OracleCommand(strQueryAllowance, con))
                                        {

                                            cmdReadAllwance.CommandText = strQueryAllowance;
                                            cmdReadAllwance.CommandType = CommandType.StoredProcedure;
                                            cmdReadAllwance.Parameters.Add("P_SLRYPRCSID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                            cmdReadAllwance.Parameters.Add("P_ALLWNCID", OracleDbType.Int32).Value = objEntityAllwance.ProcessAllwnceID;
                                            cmdReadAllwance.Parameters.Add("P_PAYGRADEID", OracleDbType.Int32).Value = objEntityAllwance.PayGradeID;
                                            cmdReadAllwance.Parameters.Add("P_ALLWN_AMT", OracleDbType.Decimal).Value = objEntityAllwance.ProcessedAllwncAmt;
                                            cmdReadAllwance.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityAllwance.Employee;

                                            cmdReadAllwance.ExecuteNonQuery();
                                        }
                                    }
                                }


                                //Deductn


                                foreach (cls_Entity_Monthly_Salary_Process objEntityDedtn in ObjDeductn)
                                {

                                    var checkedItems = ObjDeductn.Where(i => i.Employee == objEntityEmp.Employee);
                                    foreach (cls_Entity_Monthly_Salary_Process item in checkedItems)
                                    {
                                        // file operations

                                        string strQueryAllowance = "MONTHLY_SALARY_PEOSESS.SP_UPDATE_PROCCESD_DEDUCTION";
                                        using (OracleCommand cmdReadAllwance = new OracleCommand(strQueryAllowance, con))
                                        {

                                            cmdReadAllwance.CommandText = strQueryAllowance;
                                            cmdReadAllwance.CommandType = CommandType.StoredProcedure;
                                            cmdReadAllwance.Parameters.Add("P_SLRYPRCSID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                            cmdReadAllwance.Parameters.Add("P_ALLWNCID", OracleDbType.Int32).Value = objEntityDedtn.ProcessDeductneID;
                                            cmdReadAllwance.Parameters.Add("P_PAYGRADEID", OracleDbType.Int32).Value = objEntityDedtn.PayGradeID;
                                            cmdReadAllwance.Parameters.Add("P_ALLWN_AMT", OracleDbType.Decimal).Value = objEntityDedtn.ProcessedDedtnAmt;
                                            cmdReadAllwance.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityDedtn.Employee;

                                            cmdReadAllwance.ExecuteNonQuery();
                                        }
                                    }


                                }

                                //END
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

        public DataTable LoadMonthlySalList(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_MONTHLYSAL_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_SAVCONF", OracleDbType.Int32).Value = objEntitySalary.SavConf;
            cmdReadPayGrd.Parameters.Add("P_PENDFINSH", OracleDbType.Int32).Value = objEntitySalary.PendFinshId;

            //cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            //cmdReadPayGrd.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntitySalary.Mode;
            //if (objEntitySalary.Months != "")
            //    cmdReadPayGrd.Parameters.Add("P_MONTHS", OracleDbType.Varchar2).Value = objEntitySalary.Months;
            //else
            //    cmdReadPayGrd.Parameters.Add("P_MONTHS", OracleDbType.Varchar2).Value = DBNull.Value;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public DataTable LoadSalaryPrssListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_LIST_FRMPRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_SAVECON", OracleDbType.Int32).Value = objEntitySalary.SavConf;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadAllounceListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLOWSALARY_PRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_SALPRSID", OracleDbType.Int32).Value = objEntitySalary.SalaryPrssId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadDeductionListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCTNSALARY_PRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_SALPRSID", OracleDbType.Int32).Value = objEntitySalary.SalaryPrssId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public void ConfrmProssDtls(cls_Entity_Monthly_Salary_Process objEntitySalary, List<cls_Entity_Monthly_Salary_Process> objEmp, List<cls_Entity_Monthly_Salary_Process> objEmpDailyHrList, List<cls_Entity_Monthly_Salary_Process> objDistinctPrjctList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    if (objEmp.Count > 0)
                    {
                        foreach (cls_Entity_Monthly_Salary_Process objEntityEmp in objEmp)
                        {

                            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_INSERT_SALARYPROCESSCONFRM";
                            using (OracleCommand cmdReadPayGrd = new OracleCommand())
                            {

                                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
                                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                                cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                                cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                                cmdReadPayGrd.Parameters.Add("P_STFFWORKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
                                cmdReadPayGrd.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntitySalary.Division;
                                cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.Dep;
                                cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityEmp.Employee;
                                cmdReadPayGrd.Parameters.Add("P_EMPAMT", OracleDbType.Decimal).Value = objEntityEmp.TotMount;
                                cmdReadPayGrd.Parameters.Add("P_SALPRSSID", OracleDbType.Int32).Value = objEntityEmp.SalaryPrssId;
                                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                                cmdReadPayGrd.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntitySalary.UserId;


                                //cmdReadPayGrd.Parameters.Add("P_OVERTIME_AMT", OracleDbType.Decimal).Value = objEntityEmp.AllowOverTmAmnt;
                                cmdReadPayGrd.Parameters.Add("P_ALLOW_AMNT", OracleDbType.Decimal).Value = objEntityEmp.SpecialAllAmnt;
                                cmdReadPayGrd.Parameters.Add("P_DED_AMNT", OracleDbType.Decimal).Value = objEntityEmp.SpecialDedAmnt;
                                cmdReadPayGrd.Parameters.Add("P_DDCTN_INSTL_AMNT", OracleDbType.Decimal).Value = objEntityEmp.InstalAmount;
                                cmdReadPayGrd.Parameters.Add("P_LEVNUM", OracleDbType.Decimal).Value = objEntityEmp.NumLeav;
                                cmdReadPayGrd.Parameters.Add("P_BASIC_AMNT", OracleDbType.Decimal).Value = objEntityEmp.BasicPay;

                                cmdReadPayGrd.Parameters.Add("P_PREV_ARR_AMNT", OracleDbType.Decimal).Value = objEntityEmp.PrevMnthArreAmt;
                                if (objEntityEmp.CurrentDate != DateTime.MinValue)
                                {
                                    cmdReadPayGrd.Parameters.Add("P_PREV_REJOIN_DATE", OracleDbType.Date).Value = objEntityEmp.CurrentDate;
                                }
                                else
                                {
                                    cmdReadPayGrd.Parameters.Add("P_PREV_REJOIN_DATE", OracleDbType.Date).Value = DBNull.Value;
                                }
                                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                            }

                        }


                        foreach (cls_Entity_Monthly_Salary_Process objEntityEmpDailyHr in objEmpDailyHrList)
                        {
                            string strQueryRead = "MONTHLY_SALARY_PEOSESS.SP_INS_PROJECT_COST_DTL";
                            using (OracleCommand cmdReadPayGrd = new OracleCommand())
                            {
                                cmdReadPayGrd.CommandText = strQueryRead;
                                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyHr.CorpOffice;
                                cmdReadPayGrd.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = objEntityEmpDailyHr.ProjectId;
                                cmdReadPayGrd.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityEmpDailyHr.UserId;
                                cmdReadPayGrd.Parameters.Add("P_TOT_COST", OracleDbType.Decimal).Value = objEntityEmpDailyHr.TotalCost;
                                cmdReadPayGrd.Parameters.Add("P_NOF_DAYS", OracleDbType.Decimal).Value = objEntityEmpDailyHr.NumOfDays;
                                cmdReadPayGrd.Parameters.Add("P_OT_HOUR", OracleDbType.Decimal).Value = objEntityEmpDailyHr.OT_Hour;
                                cmdReadPayGrd.Parameters.Add("P_MNTH_YEAR", OracleDbType.Date).Value = objEntityEmpDailyHr.MonthYearDate;
                                cmdReadPayGrd.Parameters.Add("P_TOT_OT_AMT", OracleDbType.Decimal).Value = objEntityEmpDailyHr.TotalOTamt;
                                cmdReadPayGrd.Parameters.Add("P_TOT_BASIC_ALLWC_AMT", OracleDbType.Decimal).Value = objEntityEmpDailyHr.Basic_Allwnc_Amt;

                                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                            }

                        }

                        foreach (cls_Entity_Monthly_Salary_Process objDistinctPrjct in objDistinctPrjctList)
                        {
                            string strQueryRead = "MONTHLY_SALARY_PEOSESS.SP_INS_PROJECT_MSTR_COST_DTL";
                            using (OracleCommand cmdReadPayGrd = new OracleCommand())
                            {
                                cmdReadPayGrd.CommandText = strQueryRead;
                                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                                cmdReadPayGrd.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = objDistinctPrjct.ProjectId;
                                cmdReadPayGrd.Parameters.Add("P_MNTH_YEAR", OracleDbType.Date).Value = objEntitySalary.MonthYearDate;

                                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
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


        //Below Section For Monthly Salary List Page


        public DataTable AllowncRestrictionChk(clsEntityLayerEmpSalary objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_CHK_RESTRCTN_ALLWNC";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntitySalary.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable DedctnRestrictionChk(clsEntityLayerEmpSalary objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_CHK_RESTRCTN_DEDCTN";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntitySalary.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadAddnLoad(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLOWNCE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadDedctnLoad(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCTION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadAllounceList(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLONCE_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            // cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadDedctnList(clsEntityLayerEmpSalary objEntityEmpSlry, string salProssId)
        {
            int ID = Convert.ToInt32(salProssId);
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCT_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            // cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_SALPRSSID", OracleDbType.Int32).Value = ID;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadAllounceById(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ALLWCE_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            //cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void CancelAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_CANCEL_ALLWNCE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_reason;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }
        public void CancelDedctn(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_CANCEL_DEDCTN";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_reason;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }

        public DataTable ReadDedctnById(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DEDCTN_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_DUPSALRY_ADDTN_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("SALARYADDTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryAllwnceId;
            cmdReadPayGrd.Parameters.Add("EMLY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
            cmdReadPayGrd.Parameters.Add("ALLW_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AlownceId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

        }


        public string DuplCheckSalaryDedctn(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_DUPSALRY_DEDCTN_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("SALARYDEDTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SlaryDedctnId;
            cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
            cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
            cmdReadPayGrd.Parameters.Add("DED_ID", OracleDbType.Int32).Value = objEntityEmpSlry.DedctnId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

        }

        public void AddSalaryDedction(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_INS_SALRY_DEDCTN_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("DEDCTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.DedctnId;
                if (objEntityEmpSlry.EmplyUserId != 0)
                {
                    cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = null;
                }
                cmdReadPayGrd.Parameters.Add("EPLYSALRY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("P_PERC", OracleDbType.Decimal).Value = objEntityEmpSlry.Percentge;
                cmdReadPayGrd.Parameters.Add("P_AMNT_PERCHK", OracleDbType.Int32).Value = objEntityEmpSlry.PercOrAmountChk;
                cmdReadPayGrd.Parameters.Add("P_BSCK_TOTLCHK", OracleDbType.Int32).Value = objEntityEmpSlry.BasicOrTotalAmtChk;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public void UpdateSalaryDedction(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_UPDATE_DEDCTN";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("SALARYDEDCTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SlaryDedctnId;

                // cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
                cmdReadPayGrd.Parameters.Add("DEDCTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.DedctnId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
                cmdReadPayGrd.Parameters.Add("P_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("P_PERC", OracleDbType.Decimal).Value = objEntityEmpSlry.Percentge;
                cmdReadPayGrd.Parameters.Add("P_AMNT_PERCHK", OracleDbType.Int32).Value = objEntityEmpSlry.PercOrAmountChk;
                cmdReadPayGrd.Parameters.Add("P_BSCK_TOTLCHK", OracleDbType.Int32).Value = objEntityEmpSlry.BasicOrTotalAmtChk;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public void AddSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_INS_SALRY_ALLWNC_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("ALWNC_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AlownceId;
                if (objEntityEmpSlry.EmplyUserId != 0)
                {
                    cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = null;
                }
                cmdReadPayGrd.Parameters.Add("EPLYSALRY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public void UpdSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_UPDATE_ALLOWNCE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("SALARYADDTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryAllwnceId;

                // cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmpSalaryId;
                cmdReadPayGrd.Parameters.Add("ALLW_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AlownceId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
                cmdReadPayGrd.Parameters.Add("P_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;

                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        //BELOW SECTION FOR MONTHLY SALARY PAYMENT
        public DataTable LoadSalaryPrssPaymentTable(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_PAYMENT_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //EVM-0027
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.Employee;
            //ENd
            cmdReadPayGrd.Parameters.Add("P_PAIDFINSH", OracleDbType.Int32).Value = objEntityEmpSlry.PaidFinish;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntityEmpSlry.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntityEmpSlry.Dep;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.date;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            string pmonth = objEntityEmpSlry.Month.ToString("00");
            //pdate.Month.ToString();
            string pyear = objEntityEmpSlry.Year.ToString();
            //pdate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

       ////EVM-0027
        public DataTable LoadSalaryPrssPaymentTableByEID(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_PAYMENT_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //EVM-0027
            // cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.Employee;
            //ENd
            cmdReadPayGrd.Parameters.Add("P_PAIDFINSH", OracleDbType.Int32).Value = objEntityEmpSlry.PaidFinish;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntityEmpSlry.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntityEmpSlry.Dep;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.date;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            string pmonth = objEntityEmpSlry.Month.ToString("00");
            //pdate.Month.ToString();
            string pyear = objEntityEmpSlry.Year.ToString();
            //pdate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        //End


        public DataTable GetArrearAmount(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_ARREAR_AMOUNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityEmpSlry.Employee;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
          

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void SaveSinglePayment(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_SINGLE_PAYMENT";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmpSlry.Employee;
                cmdReadPayGrd.Parameters.Add("P_SALPRSS_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryPrssId;
              
                cmdReadPayGrd.Parameters.Add("P_ARRAMT", OracleDbType.Decimal).Value = objEntityEmpSlry.ArrerMount;
                cmdReadPayGrd.Parameters.Add("P_PAIDAMNT", OracleDbType.Decimal).Value = objEntityEmpSlry.PaidMount;
                cmdReadPayGrd.Parameters.Add("P_MNTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
                cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
                string combmonthyear = objEntityEmpSlry.Month.ToString("00") + "-" + objEntityEmpSlry.Year;
                cmdReadPayGrd.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public void SaveAllPayment(List<cls_Entity_Monthly_Salary_Process> objEntityEmpSlry)
        {
            if (objEntityEmpSlry.Count > 0)
            {
                foreach (cls_Entity_Monthly_Salary_Process objEntityEmp in objEntityEmpSlry)
                {
                    string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_SINGLE_PAYMENT";
                    using (OracleCommand cmdReadPayGrd = new OracleCommand())
                    {
                        cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                        cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                        cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.Employee;
                        cmdReadPayGrd.Parameters.Add("P_SALPRSS_ID", OracleDbType.Int32).Value = objEntityEmp.SalaryPrssId;

                        cmdReadPayGrd.Parameters.Add("P_ARRAMT", OracleDbType.Decimal).Value = objEntityEmp.ArrerMount;
                        cmdReadPayGrd.Parameters.Add("P_PAIDAMNT", OracleDbType.Decimal).Value = objEntityEmp.PaidMount;

                        cmdReadPayGrd.Parameters.Add("P_MNTH", OracleDbType.Int32).Value = objEntityEmp.Month;
                        cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmp.Year;
                        string combmonthyear = objEntityEmp.Month.ToString("00") + "-" + objEntityEmp.Year;
                        cmdReadPayGrd.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;

                        clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                    }
                }
            }
        }

        public DataTable ReadEmp_List_For_Print(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmp_List = "MONTHLY_SALARY_PEOSESS.SP_READ_FOR_PRINT";
            OracleCommand cmdReadEmp_List = new OracleCommand();
            cmdReadEmp_List.CommandText = strQueryReadEmp_List;
            cmdReadEmp_List.CommandType = CommandType.StoredProcedure;
            cmdReadEmp_List.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadEmp_List.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadEmp_List.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadEmp_List.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            cmdReadEmp_List.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = clsDataLayer.ExecuteReader(cmdReadEmp_List);
            return dtEmp_List;
        }
        public DataTable ReadSalaryProssDtlsById(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmp_List = "MONTHLY_SALARY_PEOSESS.SP_READ_SALPROSS_DTLSBYID";
            OracleCommand cmdReadEmp_List = new OracleCommand();
            cmdReadEmp_List.CommandText = strQueryReadEmp_List;
            cmdReadEmp_List.CommandType = CommandType.StoredProcedure;
            cmdReadEmp_List.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadEmp_List.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadEmp_List.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
        
            cmdReadEmp_List.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = clsDataLayer.ExecuteReader(cmdReadEmp_List);
            return dtEmp_List;
        }

        public DataTable ReadEmp_List_Holyday(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmp_List = "MONTHLY_SALARY_PEOSESS.SP_READ_DATE_FROM_HOLYDAY";
            OracleCommand cmdReadEmp_List = new OracleCommand();
            cmdReadEmp_List.CommandText = strQueryReadEmp_List;
            cmdReadEmp_List.CommandType = CommandType.StoredProcedure;
            cmdReadEmp_List.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadEmp_List.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;

            cmdReadEmp_List.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = clsDataLayer.ExecuteReader(cmdReadEmp_List);
            return dtEmp_List;
        }

        public DataTable ReadCorporateAddress(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.Orgid;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpOffice;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadLeavListList(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_LEAV_LIST";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.Employee;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.Orgid;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpOffice;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLayerManpwr.Year;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadPrevLeav(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_PREV_LEAVE";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.Employee;
                       cmdReadCorp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityLayerManpwr.Month;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLayerManpwr.Year;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadLeavSettlmentChk(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_LEAV_SETTLMENT ";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.Employee;
                       cmdReadCorp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityLayerManpwr.Month;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLayerManpwr.Year;
            string combmonthyear = objEntityLayerManpwr.Month.ToString("00") + "-" + objEntityLayerManpwr.Year;
            cmdReadCorp.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadLeavSettlmentDat(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_LEAV_SETTLMENT_DATE ";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.Employee;
            cmdReadCorp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityLayerManpwr.Month;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLayerManpwr.Year;
            string combmonthyear = objEntityLayerManpwr.Month.ToString("00") + "-" + objEntityLayerManpwr.Year;
            cmdReadCorp.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
       //Mess deduction
        public DataTable ReadMessSettlement(cls_Entity_Monthly_Salary_Process objEntityLayerManpwr)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_MESS_DEDCTN";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;

            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.Employee;
            cmdReadCorp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityLayerManpwr.Month;
            cmdReadCorp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLayerManpwr.Year;



            DateTime firstOfNextMonth = new DateTime(objEntityLayerManpwr.Year, objEntityLayerManpwr.Month, 1).AddMonths(1);
            DateTime DStartThisMonth = new DateTime(objEntityLayerManpwr.Year, objEntityLayerManpwr.Month, 1);
            string lastOfThisMonth = firstOfNextMonth.AddDays(-1).ToString("dd-MM-yyyy");
            string strDStartThisMonth = DStartThisMonth.ToString("dd-MM-yyyy");
            DateTime lastOfThisMonth1 = objCommon.textToDateTime(lastOfThisMonth);
            DateTime DStartThisMonth1 = objCommon.textToDateTime(strDStartThisMonth);

            cmdReadCorp.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = DStartThisMonth1;
            cmdReadCorp.Parameters.Add("P_DATE", OracleDbType.Date).Value = lastOfThisMonth1;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadEmp_List_For_PaySlip_Print(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmp_List = "MONTHLY_SALARY_PEOSESS.SP_READ_FOR_PRINT_PAYSLIP";
            OracleCommand cmdReadEmp_List = new OracleCommand();
            cmdReadEmp_List.CommandText = strQueryReadEmp_List;
            cmdReadEmp_List.CommandType = CommandType.StoredProcedure;
            cmdReadEmp_List.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadEmp_List.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadEmp_List.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadEmp_List.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            cmdReadEmp_List.Parameters.Add("P_MNTH_END_DATE", OracleDbType.Date).Value = objEntitySalary.CurrentDate;

            cmdReadEmp_List.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = clsDataLayer.ExecuteReader(cmdReadEmp_List);
            return dtEmp_List;
        }
        public DataTable ReadLeaveDate(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "MONTHLY_SALARY_PEOSESS.SP_READ_LEAVE_DATES";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadCorp.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadCorp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        //read employee rejoin date
        public DataTable ReadRejoinDate(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_REJOIN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpOffice;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Orgid;
            cmdReadEmp.Parameters.Add("E_LV", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadRejoinLeave(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_REJOIN_LEAVE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_LID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpOffice;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Orgid;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadPrevLeaveDetails(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_LVAFTERSETTLE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("L_LDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.date;
            cmdReadEmp.Parameters.Add("L_LDATEND", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadMonthlyLastDate(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "MONTHLY_SALARY_PEOSESS.SP_READ_MONTHLY_DATE";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadLastLeaveStlDate(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "MONTHLY_SALARY_PEOSESS.SP_RD_LEAV_SETTLMENT_DATE_EMP";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadMonthlyLeaveForMultipleYrs(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_MONTHLY_LV_MULTIPL_YRS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadEmp.Parameters.Add("L_SDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadJoinDt(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_JOINDT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadCorpSal(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_CORPRT_SALDATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpOffice;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public void DeleteMonthlySalaryProces(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_DELETE_MONTHLY_PRCSS";
                    using (OracleCommand cmdReadPayGrd = new OracleCommand())
                    {
                        cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                        cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                        cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryPrssId;
                        clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
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

        public void DeleteMonthlySalaryProcesList(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_DELETE_MONTHLY_PRCSS_LIST";
                    using (OracleCommand cmdReadPayGrd = new OracleCommand())
                    {
                        cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                        cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                        cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.date;
                        cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice;
                        cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
                        cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
                        cmdReadPayGrd.Parameters.Add("P_STFFWORKR", OracleDbType.Int32).Value = objEntityEmpSlry.StffWrkr;
                      
                        clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
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

        //BELOW SECTION FOR MONTHLY SALARY PAYMENT
        public DataTable ReadDialyHourDtl(cls_Entity_Monthly_Salary_Process objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_DIALY_HOUR_DTL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityEmpSlry.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }


        public DataTable ReadLastDatePrint(cls_Entity_Monthly_Salary_Process objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_LASTDATE_PRINT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("L_LDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.date;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


        public DataTable ReadEmpManualy_AdditionDetails(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_MANUAL_ADD_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmploy;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_CONF", OracleDbType.Int32).Value = objEntitySalary.SavConf;
            cmdReadPayGrd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmp;
        }

        public DataTable ReadEmpManualy_DeductionsDetails(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_MANUAL_DED_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmploy;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_CONF", OracleDbType.Int32).Value = objEntitySalary.SavConf;
            cmdReadPayGrd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmp;
        }



        public DataTable ReadEmpManualy_Add_Dedn_Details(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_MANUAL_ADD_DED_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmploy;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_PAYINF_ID", OracleDbType.Int32).Value = objEntitySalary.ManualAddDedId;
            cmdReadPayGrd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_PAYRL_MODE", OracleDbType.Int32).Value = objEntitySalary.PayrlMode;
            cmdReadPayGrd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmp;
        }

        public DataTable ReadEmpManualy_Add_Dedn_Dtls(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryUpdateStatus = "MONTHLY_SALARY_PEOSESS.SP_READ_MANL_ADD_DED";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                cmd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                cmd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
                cmd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                cmd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                cmd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmd);
                return dtEmp;
            }
        }

        public DataTable ReadEmpManualy_Add_Dedn(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryUpdateStatus = "MONTHLY_SALARY_PEOSESS.SP_READ_MANL_OTHR_ADD_DED";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                cmd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                cmd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
                cmd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                cmd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                cmd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmd);
                return dtEmp;
            }
        }
        public DataTable ReadArrearFromAtt(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
            string strQueryUpdateStatus = "MONTHLY_SALARY_PEOSESS.SP_READ_ARREAR_ATTENDANCE";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
                cmd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmd);
                return dtEmp;
            }
        }

        public DataTable ReadLeaveCasualRejoin(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {
           
            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_REJOIN_CASUAL_LEAVE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            string combmonthyear = objEntitySalary.Month.ToString("00") + "-" + objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadLeaveCasualRejoinDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
        {

            string strQueryReadPayGrd = "MONTHLY_SALARY_PEOSESS.SP_READ_REJOIN_CASUAL_LEAVE_D";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntitySalary.Employee;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            string combmonthyear = objEntitySalary.Month.ToString("00") + "-" + objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



    }
}
