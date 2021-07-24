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
    public class clsDataLayerManpowerRecruitment
    {
        // This Method adds customer details to the customer master table
        public void AddManpowerRecruitment(CllsEntityManpowerRecruitment objEntityManpowerRqrmnt)
        {
            //fetching next value
            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                  

                    string strQueryAddManpowerRqrmnt = "MANPOWER_REQUIREMENT.SP_INSERT_MANPOWER_REQUIREMENT";
                    using (OracleCommand cmdAddManpowerRqrmnt = new OracleCommand(strQueryAddManpowerRqrmnt, con))
                    {

                        cmdAddManpowerRqrmnt.CommandType = CommandType.StoredProcedure;
                        //generate next value
                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                        //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ManpowerRqrmnt);
                        objCommon.CorporateID = objEntityManpowerRqrmnt.CorpId;



                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.RequestId;


                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate;

                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQRD_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate1;
                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RESOURCENUM", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.No_Resources;



                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_REFNUM", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Reference_Number;











                        if (objEntityManpowerRqrmnt.DesignationId == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DesignationId;


                        }

                        if (objEntityManpowerRqrmnt.DivisionId == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DivisionId;


                        }
                        if (objEntityManpowerRqrmnt.Derpartment == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Derpartment;


                        }
                        if (objEntityManpowerRqrmnt.Project == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Project;


                        }
                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_EXPERIENCE", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.ExperienceRqrd;
                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RECRUTRSN", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.RecruitReason;

                        if (objEntityManpowerRqrmnt.PaygradeId == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PaygradeId;


                        }
                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_OTHRBENEFITS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.OtherBenefits;
                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_COMMENTS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Comments;
                        if (objEntityManpowerRqrmnt.Identer == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Identer;


                        }
                        cmdAddManpowerRqrmnt.Parameters.Add("M_CORPRT_ID", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.CorpId;
                        cmdAddManpowerRqrmnt.Parameters.Add("M_ORG_ID", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.orgid;



                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_INS_USR_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.UserId;



                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_INS_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate3;



                        cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROCESS_STATUS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Application_Status;

                        cmdAddManpowerRqrmnt.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Cancel_Status;

                        cmdAddManpowerRqrmnt.ExecuteNonQuery();
                    }

                    for (int i = 0; i < objEntityManpowerRqrmnt.PrefCountry_id.Count(); i++)
                    {
                        if( objEntityManpowerRqrmnt.PrefCountry_id[i]!=0)
                        {
                        string strQueryInsertDetail = "MANPOWER_REQUIREMENT.SP_INSERT_PREF_NTNLTY";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("M_PREF_CNTRY_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PrefCountry_id[i];
                            cmdAddInsertDetail.Parameters.Add("M_MNPRQST_ID", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.PrefferedMastrID;

                            cmdAddInsertDetail.ExecuteNonQuery();
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
        //Method for Updating ManpowerRqrmnt Details
        public void UpdateManpowerRecruitment(CllsEntityManpowerRecruitment objEntityManpowerRqrmnt)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
        
                //generate next value
                     tran = con.BeginTransaction();

                     try
                     {

                         string strQueryAddManpowerRqrmnt = "MANPOWER_REQUIREMENT.SP_UPDATE_MANPOWER_REQUIREMENT";
                         using (OracleCommand cmdAddManpowerRqrmnt = new OracleCommand(strQueryAddManpowerRqrmnt, con))
                         {

                             cmdAddManpowerRqrmnt.CommandType = CommandType.StoredProcedure;
                             //generate next value
                             clsDataLayer objDataLayer = new clsDataLayer();
                             clsEntityCommon objCommon = new clsEntityCommon();
                             //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ManpowerRqrmnt);
                             objCommon.CorporateID = objEntityManpowerRqrmnt.CorpId;

                             cmdAddManpowerRqrmnt.Transaction = tran;

                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.RequestId;


                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate;
                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQRD_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate1;

                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RESOURCENUM", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.No_Resources;



                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_REFNUM", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Reference_Number;


                             if (objEntityManpowerRqrmnt.DesignationId == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DesignationId;


                             }

                             if (objEntityManpowerRqrmnt.DivisionId == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DivisionId;


                             }
                             if (objEntityManpowerRqrmnt.Derpartment == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Derpartment;


                             }
                             if (objEntityManpowerRqrmnt.Project == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Project;


                             }
                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_EXPERIENCE", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.ExperienceRqrd;
                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RECRUTRSN", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.RecruitReason;

                             if (objEntityManpowerRqrmnt.PaygradeId == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PaygradeId;


                             }
                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_OTHRBENEFITS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.OtherBenefits;
                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_COMMENTS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Comments;
                             if (objEntityManpowerRqrmnt.Identer == 0)
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = null;
                             }
                             else
                             {

                                 cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Identer;


                             }



                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_UPD_USR_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.UserId;



                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_UPD_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate3;



                             cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROCESS_STATUS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Application_Status;

                             cmdAddManpowerRqrmnt.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Cancel_Status;

                             cmdAddManpowerRqrmnt.ExecuteNonQuery();
                         }
                         string strQuerydELETEDetail = "MANPOWER_REQUIREMENT.SP_DELETE_PREFNTNLTY";
                         using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQuerydELETEDetail, con))
                         {
                             cmdAddInsertDetail.Transaction = tran;
                             cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                             cmdAddInsertDetail.Parameters.Add("M_MNPRQST_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PrefferedMastrID;

                             cmdAddInsertDetail.ExecuteNonQuery();
                         }

                         for (int i = 0; i < objEntityManpowerRqrmnt.PrefCountry_id.Count(); i++)
                         {
                             if (objEntityManpowerRqrmnt.PrefCountry_id[i] != 0)
                             {
                                 string strQueryInsertDetail = "MANPOWER_REQUIREMENT.SP_INSERT_PREF_NTNLTY";
                                 using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                                 {
                                     cmdAddInsertDetail.Transaction = tran;
                                     cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                     cmdAddInsertDetail.Parameters.Add("M_PREF_CNTRY_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PrefCountry_id[i];
                                     cmdAddInsertDetail.Parameters.Add("M_MNPRQST_ID", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.PrefferedMastrID;

                                     cmdAddInsertDetail.ExecuteNonQuery();
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
        //This Method will fetch customer table by ID
       // public DataTable ManpowerRecruitmentById(CllsEntityManpowerRecruitment objEntityManpowerRqrmnt)
       //{
       //    string strQueryReadManpowerRqrmntById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_BY_ID";
       //    OracleCommand cmdReadManpowerRqrmntById = new OracleCommand();
       //    cmdReadManpowerRqrmntById.CommandText = strQueryReadManpowerRqrmntById;
       //    cmdReadManpowerRqrmntById.CommandType = CommandType.StoredProcedure;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.orgid;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.CorpId;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Imig_Id;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
       //    DataTable dtCustomer = new DataTable();
       //    dtCustomer = clsDataLayer.ExecuteReader(cmdReadManpowerRqrmntById);
       //    return dtCustomer;
       //}
       ////This Method will fetch customer table
       // public DataTable ManpowerRecruitmentList(CllsEntityManpowerRecruitment objEntityManpowerRqrmnt)
       //{
       //    string strQueryReadManpowerRqrmntById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_IMIG_LIST";
       //    OracleCommand cmdReadManpowerRqrmntById = new OracleCommand();
       //    cmdReadManpowerRqrmntById.CommandText = strQueryReadManpowerRqrmntById;
       //    cmdReadManpowerRqrmntById.CommandType = CommandType.StoredProcedure;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.OrgId;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.CorpId;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Imig_Emp_id;
       //    cmdReadManpowerRqrmntById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
       //    DataTable dtCustomer = new DataTable();
       //    dtCustomer = clsDataLayer.ExecuteReader(cmdReadManpowerRqrmntById);
       //    return dtCustomer;
       //}
        public void CancelManpowerRecruitmentById(CllsEntityManpowerRecruitment objEntityManpowerRqrmnt)
        {
            string strQueryReadManpowerRqrmntById = "MANPOWER_REQUIREMENT.SP_DELETE_MANPOWER";
            using (OracleCommand cmdReadManpowerRqrmntById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadManpowerRqrmntById.Connection = con;


                cmdReadManpowerRqrmntById.CommandText = strQueryReadManpowerRqrmntById;
                cmdReadManpowerRqrmntById.CommandType = CommandType.StoredProcedure;
                cmdReadManpowerRqrmntById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.orgid;
                cmdReadManpowerRqrmntById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.CorpId;
                cmdReadManpowerRqrmntById.Parameters.Add("C_RQST_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.RequestId;
                cmdReadManpowerRqrmntById.Parameters.Add("C_CANDATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate1;
                cmdReadManpowerRqrmntById.Parameters.Add("C_CANUSR_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.UserId;

                cmdReadManpowerRqrmntById.Parameters.Add("C_RSN", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Cancel_Reason;

                cmdReadManpowerRqrmntById.ExecuteNonQuery();
            }
        }
        public DataTable ReadManpowerRecruitment(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
        {
            string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
            using (OracleCommand cmdReadManpower = new OracleCommand())
            {
                cmdReadManpower.CommandText = strQueryReadUsers;
                cmdReadManpower.CommandType = CommandType.StoredProcedure;
                cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadManpower.Parameters.Add("P_ROLEID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Role_id;
                cmdReadManpower.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
                return dtCust;
            }
        }
        public DataTable ReadManpowerRecruitmentId(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
        {
            string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_BYID";
            using (OracleCommand cmdReadManpower = new OracleCommand())
            {
                cmdReadManpower.CommandText = strQueryReadUsers;
                cmdReadManpower.CommandType = CommandType.StoredProcedure;
                cmdReadManpower.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
           
                cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadManpower.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
                return dtCust;
            }
        }
        public void ChangeEntryStatus(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
        {
           // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
            string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_STATUS";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails. Cancel_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }


        public DataTable ReadProject(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_PROJECT";
               using (OracleCommand cmdReadProj = new OracleCommand())
               {
                   cmdReadProj.CommandText = strQueryReadProj;
                   cmdReadProj.CommandType = CommandType.StoredProcedure;
                   cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                   cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                   cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                   cmdReadProj.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.DivisionId;
                   cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtCust = new DataTable();
                   dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                   return dtCust;
               }
           }
        public DataTable ReadDivision(CllsEntityManpowerRecruitment objEntityEntitymanPwrRqmnt)  //emp25
           {
               string strQueryReadProj = "MANPOWER_REQUIREMENT.SP_READ_DIVISION";
               using (OracleCommand cmdReadProj = new OracleCommand())
               {
                   cmdReadProj.CommandText = strQueryReadProj;
                   cmdReadProj.CommandType = CommandType.StoredProcedure;
                   cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntitymanPwrRqmnt.UserId;
                   cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntitymanPwrRqmnt.orgid;
                   cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntitymanPwrRqmnt.CorpId;
                   cmdReadProj.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityEntitymanPwrRqmnt.Derpartment;
                   cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtCust = new DataTable();
                   dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                   return dtCust;
               }
           }
           public DataTable ReadDepartments(clsEntityJobDetails objEntityEntityJobDetails)
           {
               string strQueryReadProj = "MANPOWER_REQUIREMENT.SP_READ_DEPARTMENTS";
               using (OracleCommand cmdReadProj = new OracleCommand())
               {
                   cmdReadProj.CommandText = strQueryReadProj;
                   cmdReadProj.CommandType = CommandType.StoredProcedure;
                   cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                   cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                   cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                   cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtCust = new DataTable();
                   dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                   return dtCust;
               }
           }
           public DataTable ReadIndenter(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_USERS";
               using (OracleCommand cmdReadManpower = new OracleCommand())
               {
                   cmdReadManpower.CommandText = strQueryReadUsers;
                   cmdReadManpower.CommandType = CommandType.StoredProcedure;
                   cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                   cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                   cmdReadManpower.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtCust = new DataTable();
                   dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
                   return dtCust;
               }
           }
           public DataTable ReadPaygrade(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_PAYGARDE";
               using (OracleCommand cmdReadManpower = new OracleCommand())
               {
                   cmdReadManpower.CommandText = strQueryReadUsers;
                   cmdReadManpower.CommandType = CommandType.StoredProcedure;
                   cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                   cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                   cmdReadManpower.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtCust = new DataTable();
                   dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
                   return dtCust;
               }
           }
           public DataTable ReadManpower_search(CllsEntityManpowerRecruitment objEntityMnpwrrMstr)
           {
               string strQueryReadCntrctCatgry = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_SEARCH";
               OracleCommand cmdReadManpower = new OracleCommand();    
               cmdReadManpower.CommandText = strQueryReadCntrctCatgry;
               cmdReadManpower.CommandType = CommandType.StoredProcedure;
               cmdReadManpower.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityMnpwrrMstr.UserId;
                
               cmdReadManpower.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityMnpwrrMstr.orgid;
               cmdReadManpower.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityMnpwrrMstr.CorpId;
               cmdReadManpower.Parameters.Add("C_DIV", OracleDbType.Int32).Value = objEntityMnpwrrMstr.DivisionId;
               cmdReadManpower.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = objEntityMnpwrrMstr.Derpartment;
               cmdReadManpower.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityMnpwrrMstr.Application_Status;
               cmdReadManpower.Parameters.Add("C_ROLE", OracleDbType.Int32).Value = objEntityMnpwrrMstr.Role_id;
               cmdReadManpower.Parameters.Add("C_CAN_STATUS", OracleDbType.Int32).Value = objEntityMnpwrrMstr.Cancel_Status;
               cmdReadManpower.Parameters.Add("C_ROLE_SRCH", OracleDbType.Int32).Value = objEntityMnpwrrMstr.RoleSrch;
               cmdReadManpower.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCategory = new DataTable();
               dtCategory = clsDataLayer.ExecuteReader(cmdReadManpower);
               return dtCategory;
           }
           public void ChangeApplicationStatus(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
               string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_STATUS";
               using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
               {
                   cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                   cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                   cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                   cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Cancel_Status;
                   clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
               }
           }
           public void Approve(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
               string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_GM_APPROVAL";
               using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
               {
                   cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                   cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                   cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;

                   cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityEntityJobDetails.ApprovalStats2;
                   cmdUpdateCntrctCat.Parameters.Add("C_APPSTATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Application_Status;
                   cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.RequestDate3;
                   cmdUpdateCntrctCat.Parameters.Add("C_HRNOTE", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.HrNotes;
                   cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.ApprovalUsrId2;
                   cmdUpdateCntrctCat.Parameters.Add("C_REJECT", OracleDbType.Int32).Value = objEntityEntityJobDetails.RejectStatus;
                   clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
               }
           }
            public void Verify(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
           {
               // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
               string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_HR_APPROVAL";
               using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
               {
                   cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                   cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
    
                      cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                      cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityEntityJobDetails.ApprovalStats1;
                   cmdUpdateCntrctCat.Parameters.Add("C_APPSTATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Application_Status;
                   cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.RequestDate3;
                   cmdUpdateCntrctCat.Parameters.Add("C_VERIFDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.RequestDate2;

                   cmdUpdateCntrctCat.Parameters.Add("C_HRNOTE", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.HrNotes;
                   cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.ApprovalUsrId1;
                   cmdUpdateCntrctCat.Parameters.Add("C_REJECT", OracleDbType.Int32).Value = objEntityEntityJobDetails.RejectStatus;
                   clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
               }
           }
            public void Confirm(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
            {
                // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
                string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_CONFRMSTATUS";
                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityEntityJobDetails.Confirm_Status;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPSTATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Application_Status;



                          clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }
            }
            public string GetEmployeeCount(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
            {

                string strQueryCheckCatName = "MANPOWER_REQUIREMENT.SP_EMPLOYEE_COUNT";
                OracleCommand cmdCheckCntrctName = new OracleCommand();
                cmdCheckCntrctName.CommandText = strQueryCheckCatName;
                cmdCheckCntrctName.CommandType = CommandType.StoredProcedure;
                cmdCheckCntrctName.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.DesignationId;
                cmdCheckCntrctName.Parameters.Add("P_CPRDEPT_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Derpartment;

                cmdCheckCntrctName.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.DivisionId;

                cmdCheckCntrctName.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckCntrctName);
                string strReturn = cmdCheckCntrctName.Parameters["P_OUT"].Value.ToString();
                cmdCheckCntrctName.Dispose();
                return strReturn;
            }
            public DataTable ReadDesignation(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
            {
                string strQueryReadProj = "MANPOWER_REQUIREMENT.SP_READ_DSGN_BY_USRID";
                using (OracleCommand cmdReadProj = new OracleCommand())
                {
                    cmdReadProj.CommandText = strQueryReadProj;
                    cmdReadProj.CommandType = CommandType.StoredProcedure;
                    cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                   cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.orgid;
                   cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                   cmdReadProj.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.DivisionId;
                    cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCust = new DataTable();
                    dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                    return dtCust;
                }
            }
            public void ChangeProcessStatus(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
            {
                // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
                string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_UPD_MANPOWER_STATUS";
                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                    cmdUpdateCntrctCat.Parameters.Add("C_MNP_PROCESS_STATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Application_Status;
                    clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }

            }
            public void Close(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
            {
                // string strQueryReadUsers = "MANPOWER_REQUIREMENT.SP_READ_MANPOWER_RECRUITMENT";
                string strQueryUpdateCntrctCat = "MANPOWER_REQUIREMENT.SP_CLOSE_MANPOWER";
                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.RequestId;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityEntityJobDetails.Confirm_Status;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPSTATUS", OracleDbType.Int32).Value = objEntityEntityJobDetails.Application_Status;
                    cmdUpdateCntrctCat.Parameters.Add("C_CLOSEDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.RequestDate1;
                    cmdUpdateCntrctCat.Parameters.Add("C_CLOSEUSR_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;



                    clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }
            }
    }
}
