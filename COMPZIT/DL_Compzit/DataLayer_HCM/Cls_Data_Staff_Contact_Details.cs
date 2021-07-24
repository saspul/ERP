using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
   public class Cls_Data_Staff_Contact_Details
    {



       public void insertContactDetails(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           string strQueryAddPersnlDtls = "STAFF_CONTACT_DETAILS.SP_INS_STAFF_CONTACT_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;

               cmdAddPersnlDtls.Parameters.Add("P_CAND_ID", OracleDbType.Int32).Value = objEntityContactDtls.CandidadteId;
               cmdAddPersnlDtls.Parameters.Add("P_STAFFCD_PER_ADDRESS", OracleDbType.Varchar2).Value = objEntityContactDtls.StaffPermanentAdd;
               cmdAddPersnlDtls.Parameters.Add("P_STAFF_EMG_CNTCT", OracleDbType.Varchar2).Value = objEntityContactDtls.EmergencyContact;
               cmdAddPersnlDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityContactDtls.OrgId;

               cmdAddPersnlDtls.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityContactDtls.corpId;
               cmdAddPersnlDtls.Parameters.Add("P_INSUSRID", OracleDbType.Int32).Value = objEntityContactDtls.UserId;
               cmdAddPersnlDtls.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityContactDtls.Date;
               if (objEntityContactDtls.Accomdation != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("P_ACCMDTN_ID", OracleDbType.Int32).Value = objEntityContactDtls.Accomdation;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("P_ACCMDTN_ID", OracleDbType.Int32).Value = null;

               }
               if (objEntityContactDtls.Recruted != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("P_RECRTD_ID", OracleDbType.Int32).Value = objEntityContactDtls.Recruted;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("P_RECRTD_ID", OracleDbType.Int32).Value = null;

               }
               if (objEntityContactDtls.Sponser != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("P_SPNSR_ID", OracleDbType.Int32).Value = objEntityContactDtls.Sponser;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("P_SPNSR_ID", OracleDbType.Int32).Value = null;

               }
           
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }






       public DataTable ReadContactDetailsId(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           string strQueryReadUsers = "STAFF_CONTACT_DETAILS.SP_READ_CONTACTDTLS_BYID";
           using (OracleCommand cmdReadManpower = new OracleCommand())
           {
               cmdReadManpower.CommandText = strQueryReadUsers;
               cmdReadManpower.CommandType = CommandType.StoredProcedure;
               cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityContactDtls.OrgId;

               cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityContactDtls.corpId;
               cmdReadManpower.Parameters.Add("P_CND_ID", OracleDbType.Int32).Value = objEntityContactDtls.CandidadteId;
               cmdReadManpower.Parameters.Add("P_DSGN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
               return dtCust;
           }
       }
       public DataTable ReadAccomdationn(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           string strQueryReadProj = "STAFF_CONTACT_DETAILS.SP_READ_ACCOMODATION";
           using (OracleCommand cmdReadProj = new OracleCommand())
           {
               cmdReadProj.CommandText = strQueryReadProj;
               cmdReadProj.CommandType = CommandType.StoredProcedure;
               cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityContactDtls.UserId;
               cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityContactDtls.OrgId;
               cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityContactDtls.corpId;


               cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
               return dtCust;
           }
       }





       public void UpdateContactDetails(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();

               //generate next value
               tran = con.BeginTransaction();

               try
               {

                   string strQueryAddManpowerRqrmnt = "STAFF_CONTACT_DETAILS.SP_UPD_STAFF_CONTACT_DETAILS";
                   using (OracleCommand cmdAddPersnlDtls = new OracleCommand(strQueryAddManpowerRqrmnt, con))
                   {

                       cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;



                       cmdAddPersnlDtls.Transaction = tran;

                    //   cmdAddPersnlDtls.Parameters.Add("P_STAFF_PR_ID", OracleDbType.Int32).Value = objEntityContactDtls.StaffContact_id
                   //        ;


                       cmdAddPersnlDtls.Parameters.Add("P_CAND_ID", OracleDbType.Int32).Value = objEntityContactDtls.CandidadteId;
                       cmdAddPersnlDtls.Parameters.Add("P_STAFFCD_PER_ADDRESS", OracleDbType.Varchar2).Value = objEntityContactDtls.StaffPermanentAdd;
                       cmdAddPersnlDtls.Parameters.Add("P_STAFF_EMG_CNTCT", OracleDbType.Varchar2).Value = objEntityContactDtls.EmergencyContact;
                       cmdAddPersnlDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityContactDtls.OrgId;

                       cmdAddPersnlDtls.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityContactDtls.corpId;
                       cmdAddPersnlDtls.Parameters.Add("P_UPDUSRID", OracleDbType.Int32).Value = objEntityContactDtls.UserId;
                       cmdAddPersnlDtls.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = objEntityContactDtls.Date;
                       if (objEntityContactDtls.Accomdation != 0)
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_ACCMDTN_ID", OracleDbType.Int32).Value = objEntityContactDtls.Accomdation;
                       }
                       else
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_ACCMDTN_ID", OracleDbType.Int32).Value = null;

                       }
                       if (objEntityContactDtls.Recruted != 0)
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_RECRTD_ID", OracleDbType.Int32).Value = objEntityContactDtls.Recruted;
                       }
                       else
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_RECRTD_ID", OracleDbType.Int32).Value = null;

                       }
                       if (objEntityContactDtls.Sponser != 0)
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_SPNSR_ID", OracleDbType.Int32).Value = objEntityContactDtls.Sponser;
                       }
                       else
                       {
                           cmdAddPersnlDtls.Parameters.Add("P_SPNSR_ID", OracleDbType.Int32).Value = null;

                       }
                       
                     

                       clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
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

       public DataTable ReadSponser(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           string strQueryReadProj = "STAFF_CONTACT_DETAILS.SP_READ_SPONSOR";
           using (OracleCommand cmdReadProj = new OracleCommand())
           {
               cmdReadProj.CommandText = strQueryReadProj;
               cmdReadProj.CommandType = CommandType.StoredProcedure;
               cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityContactDtls.UserId;
               cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityContactDtls.OrgId;
               cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityContactDtls.corpId;


               cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
               return dtCust;
           }
       }





    }
}
