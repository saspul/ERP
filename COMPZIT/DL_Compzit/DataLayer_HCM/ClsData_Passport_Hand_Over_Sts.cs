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
  public  class ClsData_Passport_Hand_Over_Sts
    {
      public DataTable ReadDivision(ClsEntity_Passport_Handover_Sts objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_PASSPORT_HNDOVR.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
      public DataTable ReadDepartment(ClsEntity_Passport_Handover_Sts objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_PASSPORT_HNDOVR.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
      public DataTable ReadDesignation(ClsEntity_Passport_Handover_Sts objentityPassport)
      {
          string strQueryReadPayGrd = "HCM_PASSPORT_HNDOVR.SP_READ_DESGNTN";
          OracleCommand cmdReadJob = new OracleCommand();
          cmdReadJob.CommandText = strQueryReadPayGrd;
          cmdReadJob.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
          cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
          cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
          return dtCategory;
      }
      public DataTable ReadEmployee(ClsEntity_Passport_Handover_Sts objentityPassport)
      {
          string strQueryReadPayGrd = "HCM_PASSPORT_HNDOVR.SP_READ_EMPLOYEE";
          OracleCommand cmdReadJob = new OracleCommand();
          cmdReadJob.CommandText = strQueryReadPayGrd;
          cmdReadJob.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
          cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
          cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
          cmdReadJob.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objentityPassport.division;
          cmdReadJob.Parameters.Add("P_DSGNTN", OracleDbType.Int32).Value = objentityPassport.designation;
          cmdReadJob.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objentityPassport.department;
          cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
          return dtCategory;
      }
      public DataTable ReadEmployeepassportList(ClsEntity_Passport_Handover_Sts objentityPassport)
      {
          string strQueryReadEmpCand = "HCM_PASSPORT_HNDOVR.SP_READ_PASPRTHNDVR_LIST";
          OracleCommand cmdReadCand = new OracleCommand();
          cmdReadCand.CommandText = strQueryReadEmpCand;
          cmdReadCand.CommandType = CommandType.StoredProcedure;
          cmdReadCand.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
          cmdReadCand.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
          cmdReadCand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objentityPassport.employee;
          cmdReadCand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Int32).Value = objentityPassport.designation;
          cmdReadCand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Int32).Value = objentityPassport.department;
          cmdReadCand.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objentityPassport.division;
          cmdReadCand.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objentityPassport.HandStatus;
          cmdReadCand.Parameters.Add("P_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadCand);
          return dtCategory;
      }
      public DataTable ReadDivisionOfEmp(ClsEntity_Passport_Handover_Sts objentityPassport)
      {
          string strQueryReadRound = "HCM_PASSPORT_HNDOVR.SP_READ_DIV_BY_EMP";
          OracleCommand cmdReadRound = new OracleCommand();
          cmdReadRound.CommandText = strQueryReadRound;
          cmdReadRound.CommandType = CommandType.StoredProcedure;
          cmdReadRound.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objentityPassport.employee;
          cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
          return dtCategory;
      }



      public void AddPassportdate(ClsEntity_Passport_Handover_Sts objentityPassport, List<clsEntity_Passport_Handover_Stslist> objEntityuseridlist)
      {
          string strQueryReadPayGrd = "HCM_PASSPORT_HNDOVR.SP_INS_PASSPORTDATE";
          foreach (clsEntity_Passport_Handover_Stslist objIntUseridDtl in objEntityuseridlist)
          {
              using (OracleCommand cmdReadPayGrd = new OracleCommand())
              {
                  cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                  cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                  cmdReadPayGrd.Parameters.Add("P_PSPRTHND_ID", OracleDbType.Int32).Value = objentityPassport.passporthand_Id;
                  cmdReadPayGrd.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objIntUseridDtl.Employeeid;
                  cmdReadPayGrd.Parameters.Add("P_HAND_STAT", OracleDbType.Int32).Value = objentityPassport.HandStatus;
                  cmdReadPayGrd.Parameters.Add("P_HANDOVRDATE", OracleDbType.Date).Value = objentityPassport.HandoverDate;
                  cmdReadPayGrd.Parameters.Add("P_INS_USR_ID", OracleDbType.Int32).Value = objentityPassport.UserId;
                  cmdReadPayGrd.Parameters.Add("P_INS_DATE", OracleDbType.Date).Value = objentityPassport.Date;

                  clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
              }
          }
      }


      public DataTable ReadCorporateAddress(ClsEntity_Passport_Handover_Sts objentityPassport)
      {
          {
              string strQueryReadCorp = "HCM_PASSPORT_HNDOVR.SP_READ_CORP_ADDRSS_PRINT";
              OracleCommand cmdReadCorp = new OracleCommand();
              cmdReadCorp.CommandText = strQueryReadCorp;
              cmdReadCorp.CommandType = CommandType.StoredProcedure;
              cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
              cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
              cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtCorp = new DataTable();
              dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
              return dtCorp;
          }

      }
    }
}
