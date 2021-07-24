using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayer_Imgrtn_Asgnmnt
    {

       public DataTable ReadEmployee(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {

           string strQueryReadEmp = "IMMIGRTN_ASIGNMNT.SP_READ_EMPLOYEE";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadEmp;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImmgrtn.Orgid;
           cmdReadMnPwr.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
           cmdReadMnPwr.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }

       public DataTable ReadEmployeeCandidate(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {

           string strQueryReadEmp = "IMMIGRTN_ASIGNMNT.SP_READ_EMPLOYEE_CANDIDT";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadEmp;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImmgrtn.Orgid;
           cmdReadMnPwr.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
           cmdReadMnPwr.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }

       public DataTable ReadEmployeeCndDtById(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {

           string strQueryReadEmp = "IMMIGRTN_ASIGNMNT.SP_READ_EMPLOYE_CAND_BY_ID";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadEmp;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("I_EMPID", OracleDbType.Int32).Value = objEntityImmgrtn.EmployeeId;
           cmdReadMnPwr.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }
       public DataTable ReadEmployeeCandidatesList(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadEmpCand = "IMMIGRTN_ASIGNMNT.SP_READ_CANDIDATE_LIST";
           OracleCommand cmdReadCand = new OracleCommand();
           cmdReadCand.CommandText = strQueryReadEmpCand;
           cmdReadCand.CommandType = CommandType.StoredProcedure;
           cmdReadCand.Parameters.Add("I_EMP_ID", OracleDbType.Int32).Value = objEntityImmgrtn.EmployeeId;
           cmdReadCand.Parameters.Add("I_STATUS_ID", OracleDbType.Int32).Value = objEntityImmgrtn.SearchStatus;
           cmdReadCand.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImmgrtn.Orgid;
           cmdReadCand.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
           cmdReadCand.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadCand);
           return dtCategory;
       }

       public DataTable ReadImmgrtnRounds(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadRound = "IMMIGRTN_ASIGNMNT.SP_READ_ROUNDS";
           OracleCommand cmdReadRound = new OracleCommand();
           cmdReadRound.CommandText = strQueryReadRound;
           cmdReadRound.CommandType = CommandType.StoredProcedure;
           cmdReadRound.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImmgrtn.Orgid;
           cmdReadRound.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
           cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
           return dtCategory;
       }
       public DataTable ReadImmgrtnRoundsDetails(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       
       {
           string strQueryReadRound = "IMMIGRTN_ASIGNMNT.SP_READ_ROUNDS_BY_ID";
           OracleCommand cmdReadRound = new OracleCommand();
           cmdReadRound.CommandText = strQueryReadRound;
           cmdReadRound.CommandType = CommandType.StoredProcedure;
           cmdReadRound.Parameters.Add("I_ROUND", OracleDbType.Int32).Value = objEntityImmgrtn.RoundId;
           cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
           return dtCategory;
       }

       public DataTable ReadDivisionOfEmp(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadRound = "IMMIGRTN_ASIGNMNT.SP_READ_DIV_BY_EMP";
           OracleCommand cmdReadRound = new OracleCommand();
           cmdReadRound.CommandText = strQueryReadRound;
           cmdReadRound.CommandType = CommandType.StoredProcedure;
           cmdReadRound.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objEntityImmgrtn.EmployeeId;
           cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
           return dtCategory;
       }


       public int Insert_ImmiAsignmnt(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();

           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   string strQueryAddPanel = "IMMIGRTN_ASIGNMNT.SP_INSERT_IMMIGRTN";
                   using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddPanel, con))
                   {
                       cmdInsertOnBoard.Transaction = tran;
                       cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.IMMIGRATION_ASGNMNT);
                       objEntCommon.CorporateID = objEntityImmgrtn.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityImmgrtn.ImmgrtnAsgnId = Convert.ToInt32(strNextNum);

                       cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnId;
                       cmdInsertOnBoard.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
                       cmdInsertOnBoard.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityImmgrtn.Orgid;
                       cmdInsertOnBoard.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityImmgrtn.UserId;
                       cmdInsertOnBoard.ExecuteNonQuery();

                   }


                   tran.Commit();
                   return objEntityImmgrtn.ImmgrtnAsgnId;
               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }


       public void Insert_Process_Detail(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn,List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   string strQueryAddVisa = "IMMIGRTN_ASIGNMNT.SP_INSERT_IMMIGRTN_DTL";
                   using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddVisa, con))
                   {
                       cmdInsertOnBoard.Transaction = tran;

                       cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.IMMIGRATION_ASGNMNT_DTL);
                       objEntCommon.CorporateID = objEntityImmgrtn.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityImmgrtn.ImmgrtnAsgnDetailId = Convert.ToInt32(strNextNum);

                       cmdInsertOnBoard.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
                       cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnId;
                       cmdInsertOnBoard.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityImmgrtn.RoundId;
                       cmdInsertOnBoard.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityImmgrtn.RoundStatusId;
                       cmdInsertOnBoard.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityImmgrtn.UsrDate;
                       cmdInsertOnBoard.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityImmgrtn.Finishstatus;
                       cmdInsertOnBoard.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityImmgrtn.CloseSts;
                       cmdInsertOnBoard.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityImmgrtn.CandId;
                       cmdInsertOnBoard.ExecuteNonQuery();


                       foreach (clsEntityLayerImgrtnAsgnmntEmpLoy objEntityEmp in ObjEmpList)
                       {
                           string strQueryAddEmp = "IMMIGRTN_ASIGNMNT.SP_INSERT_IMMI_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;
                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
                               cmdInsertEmp.ExecuteNonQuery();

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

       public void Update_Process_Detail(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn, List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   string strQueryAddVisa = "IMMIGRTN_ASIGNMNT.SP_UPDATE_IMMIGRTN_DTL";
                   using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddVisa, con))
                   {
                       cmdInsertOnBoard.Transaction = tran;

                       cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                       cmdInsertOnBoard.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
                       cmdInsertOnBoard.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityImmgrtn.RoundId;
                       cmdInsertOnBoard.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityImmgrtn.RoundStatusId;
                       cmdInsertOnBoard.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityImmgrtn.UsrDate;
                       cmdInsertOnBoard.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityImmgrtn.Finishstatus;
                       cmdInsertOnBoard.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityImmgrtn.CloseSts;
                       if (objEntityImmgrtn.Finishstatus == 1)
                       {
                           cmdInsertOnBoard.Parameters.Add("P_FNSHSRID", OracleDbType.Int32).Value = objEntityImmgrtn.UserId;
                           cmdInsertOnBoard.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = DateTime.Today;
                       }
                       else
                       {
                           cmdInsertOnBoard.Parameters.Add("P_FNSHSRID", OracleDbType.Int32).Value = null;
                           cmdInsertOnBoard.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = null;
                       }

                       if (objEntityImmgrtn.CloseSts == 1)
                       {
                           cmdInsertOnBoard.Parameters.Add("P_CLSSRID", OracleDbType.Int32).Value = objEntityImmgrtn.UserId;
                           cmdInsertOnBoard.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = DateTime.Today;
                       }
                       else
                       {
                           cmdInsertOnBoard.Parameters.Add("P_CLSSRID", OracleDbType.Int32).Value = null;
                           cmdInsertOnBoard.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = null;
                       }

                       cmdInsertOnBoard.Parameters.Add("P_UPDUSRID", OracleDbType.Int32).Value = objEntityImmgrtn.UserId;
                       cmdInsertOnBoard.Parameters.Add("P_UPDATE", OracleDbType.Date).Value = DateTime.Today;

                       cmdInsertOnBoard.ExecuteNonQuery();


                       string strQueryDelEmp = "IMMIGRTN_ASIGNMNT.SP_DELETE_IMMI_EMP";
                       using (OracleCommand cmdDelEmp = new OracleCommand(strQueryDelEmp, con))
                       {
                           cmdDelEmp.Transaction = tran;

                           cmdDelEmp.CommandType = CommandType.StoredProcedure;
                           cmdDelEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
                           cmdDelEmp.ExecuteNonQuery();

                       }

                       foreach (clsEntityLayerImgrtnAsgnmntEmpLoy objEntityEmp in ObjEmpList)
                       {
                           string strQueryAddEmp = "IMMIGRTN_ASIGNMNT.SP_INSERT_IMMI_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;
                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityImmgrtn.CorpOffice;
                               cmdInsertEmp.ExecuteNonQuery();

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
       public DataTable ReadImmgrtnAsignDetailsByCand(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadImmi = "IMMIGRTN_ASIGNMNT.SP_READ_IMMGRTNDTL_BY_CANDID";
           OracleCommand cmdReadImmi = new OracleCommand();
           cmdReadImmi.CommandText = strQueryReadImmi;
           cmdReadImmi.CommandType = CommandType.StoredProcedure;
           cmdReadImmi.Parameters.Add("I_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.CandId;
           cmdReadImmi.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadImmi);
           return dtCategory;
       }
       public DataTable ReadAsignedEployees(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadImmi = "IMMIGRTN_ASIGNMNT.SP_READ_ASIGN_EMPLOYEE";
           OracleCommand cmdReadImmi = new OracleCommand();
           cmdReadImmi.CommandText = strQueryReadImmi;
           cmdReadImmi.CommandType = CommandType.StoredProcedure;
           cmdReadImmi.Parameters.Add("I_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
           cmdReadImmi.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadImmi);
           return dtCategory;
       }

       public DataTable ReadCurrentStsByDtlId(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryReadImmi = "IMMIGRTN_ASIGNMNT.SP_READ_STS_BY_DTLID";
           OracleCommand cmdReadImmi = new OracleCommand();
           cmdReadImmi.CommandText = strQueryReadImmi;
           cmdReadImmi.CommandType = CommandType.StoredProcedure;
           cmdReadImmi.Parameters.Add("I_DTLID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
           cmdReadImmi.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtsTS = new DataTable();
           dtsTS = clsDataLayer.ExecuteReader(cmdReadImmi);
           return dtsTS;
       }
       public void RecallAssignment(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
       {
           string strQueryuUpdOn = "IMMIGRTN_ASIGNMNT.SP_RECALL_CLOSED";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityImmgrtn.ImmgrtnAsgnDetailId;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
    }
}
