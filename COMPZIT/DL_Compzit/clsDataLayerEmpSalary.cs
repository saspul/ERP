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
using CL_Compzit;
using EL_Compzit.HCM;

namespace DL_Compzit
{
   public class clsDataLayerEmpSalary
    {

       public DataTable ReadDedctnLoad(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_READ_DEDCTION";
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

       public DataTable ReadAddnLoad(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_READ_ALLOWNCE";
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

       public DataTable ReadPayGrade(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_READ_PAYGARDE_BY_TYPE";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtEmpSlry = new DataTable();
           dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtEmpSlry;
       }

       public string DuplCheckNamePayGrade(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_PAY_GRADE_DUPNAME_CHK";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
           string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
           cmdReadPayGrd.Dispose();
           return strReturn;


       }

       public void AddPayGrade(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_INS_PAYGRD_DTLS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("SALRYID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
               if (objEntityEmpSlry.EmplyUserId != 0)
               {
                   cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
               }
               else
               {
                   cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = null;
               }
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
           //string strCommandText = "USER_REGISTERATION.SP_RD_LV_TYPE_PAYGRADE";
           //using (OracleCommand cmdLeaveType = new OracleCommand())
           //{
           //    cmdLeaveType.CommandText = strCommandText;
           //    cmdLeaveType.CommandType = CommandType.StoredProcedure;
           //    cmdLeaveType.Parameters.Add("D_PAY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           //    cmdLeaveType.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           //    cmdLeaveType.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           //    cmdLeaveType.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           //    clsDataLayer.ExecuteNonQuery(cmdLeaveType);
           //}
       }


       public DataTable RestrictionChk(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_CHK_RESTRCTN";
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

       //public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
       //{
       //    string strQueryReadPayGrd = "EMP_SALARY.SP_SALRY_ALLWNC_DUPNAME_CHK";
       //    OracleCommand cmdReadPayGrd = new OracleCommand();
       //    cmdReadPayGrd.CommandText = strQueryReadPayGrd;
       //    cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
       //    cmdReadPayGrd.Parameters.Add("ALWNC_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AlownceId;
       //    cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
       //    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
       //    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
       //    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
       //    cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
       //    clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
       //    string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
       //    cmdReadPayGrd.Dispose();
       //    return strReturn;


       //}

       public void AddSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_INS_SALRY_ALLWNC_DTLS";
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
               cmdReadPayGrd.Parameters.Add("EPLYSALRY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
               cmdReadPayGrd.Parameters.Add("P_PERC", OracleDbType.Decimal).Value = objEntityEmpSlry.Percentge;
               cmdReadPayGrd.Parameters.Add("P_AMNT_PERCHK", OracleDbType.Int32).Value = objEntityEmpSlry.PercOrAmountChk;


            
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }

       public DataTable ReadAllounceList(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "EMP_SALARY.SP_READ_ALLONCE_LIST";
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
       public void ChangeAllowStatus(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_ALLOW_STS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityEmpSlry.PayGrdStatus;
              // cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }

       }
       public void ChangeDedctnStatus(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_DEDCTN_STS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityEmpSlry.PayGrdStatus;
              // cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }

       }
       
       public DataTable ReadAllounceById(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_ALLWCE_BYID";
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
           string strQueryReadPayGrd = "EMP_SALARY.SP_CANCEL_ALLWNCE";
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
           string strQueryReadPayGrd = "EMP_SALARY.SP_CANCEL_DEDCTN";
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
       public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_DUPSALRY_ADDTN_CHK";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("SALARYADDTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryAllwnceId;
           cmdReadPayGrd.Parameters.Add("EMLY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
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

       public void UpdSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_ALLOWNCE";
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
               cmdReadPayGrd.Parameters.Add("P_PERC", OracleDbType.Decimal).Value = objEntityEmpSlry.Percentge;
               cmdReadPayGrd.Parameters.Add("P_AMNT_PERCHK", OracleDbType.Int32).Value = objEntityEmpSlry.PercOrAmountChk;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }

       public DataTable ReadDedctnById(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_DEDCTN_BYID";
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


       public string DuplCheckSalaryDedctn(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_DUPSALRY_DEDCTN_CHK";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("SALARYDEDTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SlaryDedctnId;
           cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
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


       public DataTable AllowncRestrictionChk(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_CHK_RESTRCTN_ALLWNC";
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


       public DataTable DedctnRestrictionChk(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "EMP_SALARY.SP_CHK_RESTRCTN_DEDCTN";
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

       public void AddSalaryDedction(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_INS_SALRY_DEDCTN_DTLS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("DEDCTN_ID", OracleDbType.Int32).Value = objEntityEmpSlry.DedctnId;
               if (objEntityEmpSlry.EmplyUserId != 0)
               {
                   cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
               }
               else {
                   cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = null;
               }
               cmdReadPayGrd.Parameters.Add("EPLYSALRY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
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

       public DataTable ReadDedctnList(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "EMP_SALARY.SP_READ_DEDCT_LIST";
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


       public void UpdateSalaryDedction(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_DEDCTN";
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


       public string EpmlyCheckPayGrade(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_EMP_SALRY_CHK";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
             cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
           string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
           cmdReadPayGrd.Dispose();
           return strReturn;
       
       }


       public DataTable ReadSalaryByEmpId(clsEntityLayerEmpSalary objEntityEmpSlry)
        {
            string strQueryReadPayGrd = "EMP_SALARY.SP_READ_SALARY_LIST_EMPID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("SALARY_ID", OracleDbType.Long).Value = objEntityEmpSlry.EmpSalaryId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

       public void UpdatePayGrade(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_SALARY_DTLS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
               cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
               cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;
             
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }
       public void UpdatePayGradeBasicPay(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_UPDATE_SALARY_DTLS_BASIC";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
               cmdReadPayGrd.Parameters.Add("EPLYID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
               cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityEmpSlry.D_Date;
               cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityEmpSlry.AmountRangeFrm;

               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }
       public DataTable ReadAllounceByAddId(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_ALLWCE_BY_ADDID";
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
       public DataTable ReadDedctnByDedId(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_DEDCTN_BY_DEDID";
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
       public DataTable ReadSalaryAddnTableId(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_ADD_TAB_ID";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AlownceId;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable ReadSalaryDeductnTableId(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_DED_TAB_ID";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.DedctnId;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.EmplyUserId;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable ReadRangeInfo(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_RANGE_INFO";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryMode;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           cmdReadPayGrd.Parameters.Add("P_AMNT_PERCHK", OracleDbType.Int32).Value = objEntityEmpSlry.PercOrAmountChk;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable ReadPayGradeCrncy(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_READ_CRNCY";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }

       public DataTable ReadAmtPercSts(clsEntityLayerEmpSalary objEntityEmpSlry)
       {
           string strQueryReadPayGrd = "EMP_SALARY.SP_CHECK_AMT_PERC";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEmpSlry.NextIdForPayGrade;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpOffice_Id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           cmdReadPayGrd.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.SalaryMode;

           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }

    }
}
