using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;

namespace DL_Compzit
{
  public  class clsDataLayerDependent
    {
      public DataTable ReadRelationship()
      {
          string strQueryReadCountry = "EMPLOYEE_DEPENDENT.SP_READ_RELATIONSHIP";
          using (OracleCommand cmdReadCountry = new OracleCommand())
          {
              cmdReadCountry.CommandText = strQueryReadCountry;
              cmdReadCountry.CommandType = CommandType.StoredProcedure;
              cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtCountry = new DataTable();
              dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
              return dtCountry;
          }
      }
      public void insertDependent(clsEntityLayerDependent objEntityDependent)
      {
          string strQueryAddPersnlDtls = "EMPLOYEE_DEPENDENT.SP_INS_DEPNT_DETAILS";
          using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
          {
              cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
              cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
              cmdAddPersnlDtls.Parameters.Add("D_EMPUSRID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;
              cmdAddPersnlDtls.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDependent.DepntName;
              cmdAddPersnlDtls.Parameters.Add("D_RELTNID", OracleDbType.Int32).Value = objEntityDependent.RelatnshpId;
              cmdAddPersnlDtls.Parameters.Add("D_PASPRTNUM", OracleDbType.Varchar2).Value = objEntityDependent.DepntPasprtNum;
              if (objEntityDependent.PasprtExpDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_PASEXPDATE", OracleDbType.Date).Value = objEntityDependent.PasprtExpDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_PASEXPDATE", OracleDbType.Date).Value = null;
              }
              cmdAddPersnlDtls.Parameters.Add("D_RPNUM", OracleDbType.Varchar2).Value = objEntityDependent.RPNum;
              if (objEntityDependent.RPIssDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPISSDATE", OracleDbType.Date).Value = objEntityDependent.RPIssDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPISSDATE", OracleDbType.Date).Value = null;
              }
              if (objEntityDependent.RPExpDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPEXPDATE", OracleDbType.Date).Value = objEntityDependent.RPExpDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPEXPDATE", OracleDbType.Date).Value = null;
              }
              cmdAddPersnlDtls.Parameters.Add("D_INSUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
              cmdAddPersnlDtls.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityDependent.Date;
              cmdAddPersnlDtls.Parameters.Add("D_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
              cmdAddPersnlDtls.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;
              clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
          }
      }
      public DataTable readDependentList(string id)
      {
          string strQueryReadCountry = "EMPLOYEE_DEPENDENT.SP_READ_DEPNT_LIST";
          using (OracleCommand cmdReadCountry = new OracleCommand())
          {
              cmdReadCountry.CommandText = strQueryReadCountry;
              cmdReadCountry.CommandType = CommandType.StoredProcedure;
              cmdReadCountry.Parameters.Add("D_ID", OracleDbType.Int32).Value = Convert.ToInt32(id);
              cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtCountry = new DataTable();
              dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
              return dtCountry;
          }
      }
      public DataTable ReadDepntById(clsEntityLayerDependent objEntityDependent)
      {
          string strQueryReadCountry = "EMPLOYEE_DEPENDENT.SP_READ_DEPNT_BYID";
          using (OracleCommand cmdReadCountry = new OracleCommand())
          {
              cmdReadCountry.CommandText = strQueryReadCountry;
              cmdReadCountry.CommandType = CommandType.StoredProcedure;
              cmdReadCountry.Parameters.Add("D_DEPNTID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
              cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtCountry = new DataTable();
              dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
              return dtCountry;
          }
      }
      public void updateDependent(clsEntityLayerDependent objEntityDependent)
      {
          string strQueryAddPersnlDtls = "EMPLOYEE_DEPENDENT.SP_UPD_DEPNT_DETAILS";
          using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
          {
              cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
              cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
              cmdAddPersnlDtls.Parameters.Add("D_DEPNTID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
              cmdAddPersnlDtls.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDependent.DepntName;
              cmdAddPersnlDtls.Parameters.Add("D_RELTNID", OracleDbType.Int32).Value = objEntityDependent.RelatnshpId;
              cmdAddPersnlDtls.Parameters.Add("D_PASPRTNUM", OracleDbType.Varchar2).Value = objEntityDependent.DepntPasprtNum;
              if (objEntityDependent.PasprtExpDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_PASEXPDATE", OracleDbType.Date).Value = objEntityDependent.PasprtExpDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_PASEXPDATE", OracleDbType.Date).Value = null;
              }
              cmdAddPersnlDtls.Parameters.Add("D_RPNUM", OracleDbType.Varchar2).Value = objEntityDependent.RPNum;
              if (objEntityDependent.RPIssDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPISSDATE", OracleDbType.Date).Value = objEntityDependent.RPIssDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPISSDATE", OracleDbType.Date).Value = null;
              }
              if (objEntityDependent.RPExpDate != DateTime.MinValue)
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPEXPDATE", OracleDbType.Date).Value = objEntityDependent.RPExpDate;
              }
              else
              {
                  cmdAddPersnlDtls.Parameters.Add("D_RPEXPDATE", OracleDbType.Date).Value = null;
              }
              cmdAddPersnlDtls.Parameters.Add("D_UPDUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
              cmdAddPersnlDtls.Parameters.Add("D_UPDDATE", OracleDbType.Date).Value = objEntityDependent.Date;
              clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
          }
      }
      public void DeleteDependent(clsEntityLayerDependent objEntityDependent)
      {
          string strQueryAddPersnlDtls = "EMPLOYEE_DEPENDENT.SP_DELE_DEPENDENT";
          using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
          {
              cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
              cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
              cmdAddPersnlDtls.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
              cmdAddPersnlDtls.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
              cmdAddPersnlDtls.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDependent.Date;
              clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
          }
      }
    }
}
