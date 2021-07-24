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
   public class classDatalayerGuaranteType
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
       // This Method adds Guarantee Type details to the table
       public string AddGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryAddGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_INS_GURNTE_TYP_DETAILS";

           OracleCommand cmdAddGuaranteTyp = new OracleCommand();
               cmdAddGuaranteTyp.CommandText = strQueryAddGuaranteTyp;
               cmdAddGuaranteTyp.CommandType = CommandType.StoredProcedure;
               cmdAddGuaranteTyp.Parameters.Add("G_NAME", OracleDbType.Varchar2).Value = objEntityGuaranteType.GuaranteTypename;
               cmdAddGuaranteTyp.Parameters.Add("G_MODE", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeMode;
               cmdAddGuaranteTyp.Parameters.Add("G_STATUS", OracleDbType.Int32).Value = objEntityGuaranteType.Guar_Typ_Status;
               cmdAddGuaranteTyp.Parameters.Add("G_ORGID", OracleDbType.Int32).Value = objEntityGuaranteType.Organisation_Id;
               cmdAddGuaranteTyp.Parameters.Add("G_CORPID", OracleDbType.Int32).Value = objEntityGuaranteType.CorpOffice_Id;
               cmdAddGuaranteTyp.Parameters.Add("G_INSUSERID", OracleDbType.Int32).Value = objEntityGuaranteType.User_Id;
               cmdAddGuaranteTyp.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
               clsDataLayer.ExecuteScalar(ref cmdAddGuaranteTyp);
               string strReturn = cmdAddGuaranteTyp.Parameters["P_OUT"].Value.ToString();
               cmdAddGuaranteTyp.Dispose();
               return strReturn;
           
       }
       // This Method Update Guarantee Type details to the table
       public void UpdateGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryUpdateGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_UPD_GURNTE_TYP_DETAILS";
           using (OracleCommand cmdUpdateGuaranteTyp = new OracleCommand())
           {
               cmdUpdateGuaranteTyp.CommandText = strQueryUpdateGuaranteTyp;
               cmdUpdateGuaranteTyp.CommandType = CommandType.StoredProcedure;
               cmdUpdateGuaranteTyp.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
               cmdUpdateGuaranteTyp.Parameters.Add("G_NAME", OracleDbType.Varchar2).Value = objEntityGuaranteType.GuaranteTypename;
               cmdUpdateGuaranteTyp.Parameters.Add("G_MODE", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeMode;
               cmdUpdateGuaranteTyp.Parameters.Add("G_STATUS", OracleDbType.Int32).Value = objEntityGuaranteType.Guar_Typ_Status;
               cmdUpdateGuaranteTyp.Parameters.Add("G_ORGID", OracleDbType.Int32).Value = objEntityGuaranteType.Organisation_Id;
               cmdUpdateGuaranteTyp.Parameters.Add("G_CORPID", OracleDbType.Int32).Value = objEntityGuaranteType.CorpOffice_Id;
               cmdUpdateGuaranteTyp.Parameters.Add("G_UPDUSERID", OracleDbType.Int32).Value = objEntityGuaranteType.User_Id;
               cmdUpdateGuaranteTyp.Parameters.Add("G_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdUpdateGuaranteTyp);
           }
       }
       // This Method Update Guarantee Type details to the table
       public void ChangeGuaranteStatus(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryUpdateGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_UPD_GURNTE_STATUS";
           using (OracleCommand cmdUpdateGuaranteTyp = new OracleCommand())
           {
               cmdUpdateGuaranteTyp.CommandText = strQueryUpdateGuaranteTyp;
               cmdUpdateGuaranteTyp.CommandType = CommandType.StoredProcedure;
               cmdUpdateGuaranteTyp.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
               cmdUpdateGuaranteTyp.Parameters.Add("G_STATUS", OracleDbType.Int32).Value = objEntityGuaranteType.Guar_Typ_Status;
               clsDataLayer.ExecuteNonQuery(cmdUpdateGuaranteTyp);
           }
       }
       // This Method checks Guarantee Type name in the database for duplication.
       public string CheckGuaranteTypeName(classEntityLayerGuaranteType objEntityGuaranteType)
       {

           string strQueryCheckGuaranteTypName = "GUARANTEE_TYPE_MASTER.SP_CHECK_GURNTE_TYP_NAME";
           OracleCommand cmdCheckGuaranteName = new OracleCommand();
           cmdCheckGuaranteName.CommandText = strQueryCheckGuaranteTypName;
           cmdCheckGuaranteName.CommandType = CommandType.StoredProcedure;
           cmdCheckGuaranteName.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
           cmdCheckGuaranteName.Parameters.Add("G_NAME", OracleDbType.Varchar2).Value = objEntityGuaranteType.GuaranteTypename;
           cmdCheckGuaranteName.Parameters.Add("G_CORPID", OracleDbType.Int32).Value = objEntityGuaranteType.CorpOffice_Id;
           cmdCheckGuaranteName.Parameters.Add("G_ORGID", OracleDbType.Int32).Value = objEntityGuaranteType.Organisation_Id;
           cmdCheckGuaranteName.Parameters.Add("G_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckGuaranteName);
           string strReturn = cmdCheckGuaranteName.Parameters["G_COUNT"].Value.ToString();
           cmdCheckGuaranteName.Dispose();
           return strReturn;
       }

       //Method for cancel Guarantee Type
       public void CancelGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryCancelGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_CANCEL_GURNTE_TYP";
           using (OracleCommand cmdCancelGuaranteTyp = new OracleCommand())
           {
               cmdCancelGuaranteTyp.CommandText = strQueryCancelGuaranteTyp;
               cmdCancelGuaranteTyp.CommandType = CommandType.StoredProcedure;
               cmdCancelGuaranteTyp.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
               cmdCancelGuaranteTyp.Parameters.Add("G_USERID", OracleDbType.Int32).Value = objEntityGuaranteType.User_Id;
               cmdCancelGuaranteTyp.Parameters.Add("G_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdCancelGuaranteTyp.Parameters.Add("G_REASON", OracleDbType.Varchar2).Value = objEntityGuaranteType.Cancel_reason;
               clsDataLayer.ExecuteNonQuery(cmdCancelGuaranteTyp);
           }
       }
       //Method for Recall Cancelled Complaint from Guarantee Type master table so update cancel related fields
       public void ReCallGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_RECALL_GURNTE_TYP";
           OracleCommand cmdRecallGuaranteTyp = new OracleCommand();
           cmdRecallGuaranteTyp.CommandText = strQueryGuaranteTyp;
           cmdRecallGuaranteTyp.CommandType = CommandType.StoredProcedure;
           cmdRecallGuaranteTyp.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
           cmdRecallGuaranteTyp.Parameters.Add("G_USERID", OracleDbType.Int32).Value = objEntityGuaranteType.User_Id;
           cmdRecallGuaranteTyp.Parameters.Add("G_DATE", OracleDbType.Date).Value = objEntityGuaranteType.D_Date;
           clsDataLayer.ExecuteNonQuery(cmdRecallGuaranteTyp);
       }
       // This Method will fetCH Guarantee Type DEATILS BY ID
       public DataTable ReadGuaranteTypeById(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryReadGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_READ_GURNTE_TYP_BY_ID";
           OracleCommand cmdReadGuaranteTyp = new OracleCommand();
           cmdReadGuaranteTyp.CommandText = strQueryReadGuaranteTyp;
           cmdReadGuaranteTyp.CommandType = CommandType.StoredProcedure;
           cmdReadGuaranteTyp.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
           cmdReadGuaranteTyp.Parameters.Add("G_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadGuaranteTyp);
           return dtCategory;
       }
       // This Method will fetCH Guarantee MODE
       public DataTable ReadGuaranteMode()
       {
           string strQueryReadGuaranteTyp = "GUARANTEE_TYPE_MASTER.SP_READ_GURNTE_MODE";
           OracleCommand cmdReadGuaranteTyp = new OracleCommand();
           cmdReadGuaranteTyp.CommandText = strQueryReadGuaranteTyp;
           cmdReadGuaranteTyp.CommandType = CommandType.StoredProcedure;
           cmdReadGuaranteTyp.Parameters.Add("G_GUARMODE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadGuaranteTyp);
           return dtCategory;
       }
       // This Method will fetch Guarantee Type list
       public DataTable ReadGuaranteTypeList(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           string strQueryReadGuaranteTypList = "GUARANTEE_TYPE_MASTER.SP_READ_GURNTE_TYP_LIST";
           OracleCommand cmdReadGuaranteTypList = new OracleCommand();
           cmdReadGuaranteTypList.CommandText = strQueryReadGuaranteTypList;
           cmdReadGuaranteTypList.CommandType = CommandType.StoredProcedure;
           cmdReadGuaranteTypList.Parameters.Add("G_ORGID", OracleDbType.Int32).Value = objEntityGuaranteType.Organisation_Id;
           cmdReadGuaranteTypList.Parameters.Add("G_CORPID", OracleDbType.Int32).Value = objEntityGuaranteType.CorpOffice_Id;
           cmdReadGuaranteTypList.Parameters.Add("G_OPTION", OracleDbType.Int32).Value = objEntityGuaranteType.Guar_Typ_Status;
           cmdReadGuaranteTypList.Parameters.Add("G_CANCEL", OracleDbType.Int32).Value = objEntityGuaranteType.Cancel_Status;
           cmdReadGuaranteTypList.Parameters.Add("G_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategoryList = new DataTable();
           dtCategoryList = clsDataLayer.ExecuteReader(cmdReadGuaranteTypList);
           return dtCategoryList;
       }
       public string CatagrychkBankGrnte(classEntityLayerGuaranteType objEntityGuaranteType)
       {

           string strQueryCheckGuaranteTypName = "GUARANTEE_TYPE_MASTER.SP_CHECK_BANKGRNT";
           OracleCommand cmdCheckGuaranteName = new OracleCommand();
           cmdCheckGuaranteName.CommandText = strQueryCheckGuaranteTypName;
           cmdCheckGuaranteName.CommandType = CommandType.StoredProcedure;
           cmdCheckGuaranteName.Parameters.Add("G_ID", OracleDbType.Int32).Value = objEntityGuaranteType.GuaranteeTypeId;
          // cmdCheckGuaranteName.Parameters.Add("G_CORPID", OracleDbType.Int32).Value = objEntityGuaranteType.CorpOffice_Id;
         //  cmdCheckGuaranteName.Parameters.Add("G_ORGID", OracleDbType.Int32).Value = objEntityGuaranteType.Organisation_Id;
           cmdCheckGuaranteName.Parameters.Add("G_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckGuaranteName);
           string strReturn = cmdCheckGuaranteName.Parameters["G_COUNT"].Value.ToString();
           cmdCheckGuaranteName.Dispose();
           return strReturn;
       }
    }
}
