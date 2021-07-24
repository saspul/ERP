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
    public class ClsDataLayer_Experiance_Certificate
    {
        clsDataLayerDateAndTime OBJDATE = new clsDataLayerDateAndTime();

        public DataTable ReadEmployee(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadEmployeeCrtfct(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadLevEmplyById(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMPLOYEEDTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;

            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadDivisionOfEmp(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMPLOYEE_DIV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;

            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadEmpFather(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMP_FATHRNAME";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;

            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadJoinLevDate(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMP_JOIN_DATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;

            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
  
        public void InsertempCertGerndtls(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadPayGrd = "EXPERIANCE_CERTIFICATE.SP_INSERT_CERTDTLS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadPayGrd;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;

                cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmpId;

                cmdReadEmp.Parameters.Add("P_REMARK", OracleDbType.Varchar2).Value = objEntityOnBoarding.Remarks;

               

                if (objEntityOnBoarding.FromDate == DateTime.MinValue)
                    cmdReadEmp.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = null;
                else
                    cmdReadEmp.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = objEntityOnBoarding.FromDate;
                cmdReadEmp.Parameters.Add("P_LEVDATE", OracleDbType.Date).Value = objEntityOnBoarding.ToDate;

                cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
                cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
                cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;

                //evm-0023
                cmdReadEmp.Parameters.Add("P_Conduct", OracleDbType.Varchar2).Value = objEntityOnBoarding.Conduct;
                cmdReadEmp.Parameters.Add("P_AttdcPrfmnc", OracleDbType.Varchar2).Value = objEntityOnBoarding.AttendancePerfo;
                cmdReadEmp.Parameters.Add("P_TradePrfmnc", OracleDbType.Varchar2).Value = objEntityOnBoarding.TradePerfo;

                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }

        public DataTable ReadEmployList(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXPERIANCE_CERTIFICATE.SP_READEXIT_EMPLOYEELIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmpId;
            if (objEntityOnBoarding.FromDate == DateTime.MinValue)
                cmdReadEmp.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = null;
            else
                cmdReadEmp.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = objEntityOnBoarding.FromDate;
            if (objEntityOnBoarding.ToDate == DateTime.MinValue)
                cmdReadEmp.Parameters.Add("P_LEVDATE", OracleDbType.Date).Value = null;
            else
                 cmdReadEmp.Parameters.Add("P_LEVDATE", OracleDbType.Date).Value = objEntityOnBoarding.ToDate;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public void UpdateempCertGerndtls(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            string strQueryReadPayGrd = "EXPERIANCE_CERTIFICATE.SP_UPDATE_CERTDTLS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadPayGrd;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;


                cmdReadEmp.Parameters.Add("P_EXPCERTID", OracleDbType.Int32).Value = objEntityOnBoarding.EmpId;
                cmdReadEmp.Parameters.Add("P_REMARK", OracleDbType.Varchar2).Value = objEntityOnBoarding.Remarks;
                cmdReadEmp.Parameters.Add("P_DATE", OracleDbType.Date).Value = OBJDATE.DateAndTime(); ;
              
                cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
                cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
                cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;

                //evm-0023
                cmdReadEmp.Parameters.Add("P_Conduct", OracleDbType.Varchar2).Value = objEntityOnBoarding.Conduct;
                cmdReadEmp.Parameters.Add("P_AttdcPrfmnc", OracleDbType.Varchar2).Value = objEntityOnBoarding.AttendancePerfo;
                cmdReadEmp.Parameters.Add("P_TradePrfmnc", OracleDbType.Varchar2).Value = objEntityOnBoarding.TradePerfo;

                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }



    }
}
