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
   public class clsDataLayer_OnBoardingProcess
    {
       public DataTable ReadAprvdManPwrReqstList(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           
           string strQueryReadManpwr = "ONBOARDINGPROCESS.SP_READ_MAN_PWRRQST_LIST";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadManpwr;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
           cmdReadMnPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadMnPwr.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
           cmdReadMnPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }

       public DataTable ReadCandidates(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadPayGrd = "ONBOARDINGPROCESS.SP_READ_CANDIDATE";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityOnBoarding.ReqstID;
           cmdReadJob.Parameters.Add("C_STATUS_ID", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
           cmdReadJob.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadVisaType(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVisa = "ONBOARDINGPROCESS.SP_READ_VISATYPE";
           OracleCommand cmdReadVisa = new OracleCommand();
           cmdReadVisa.CommandText = strQueryReadVisa;
           cmdReadVisa.CommandType = CommandType.StoredProcedure;
           cmdReadVisa.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
           cmdReadVisa.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadVisa.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVisa);
           return dtCategory;
       }
       public DataTable ReadEmployee(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadEmp = "ONBOARDINGPROCESS.SP_READ_EMPLOYEE";
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
       public DataTable ReadVehicle(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_VEHICLE";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
           cmdReadVeh.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }

       public DataTable ReadCandidateById(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_CANDIDATE_DTL";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }
       public int Insert_OnBoardProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
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
                   string strQueryAddPanel = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING";
                   using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddPanel, con))
                   {
                       cmdInsertOnBoard.Transaction = tran;

                       cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_PROCESS);
                       objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityOnBoarding.OnboardingId = Convert.ToInt32(strNextNum);

                       cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingId;
                       cmdInsertOnBoard.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityOnBoarding.ReqstID;
                       cmdInsertOnBoard.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                       cmdInsertOnBoard.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
                       cmdInsertOnBoard.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
                       cmdInsertOnBoard.ExecuteNonQuery();

                   }
                  

                   tran.Commit();
                   return objEntityOnBoarding.OnboardingId;
               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }

       public void Insert_Process_Detail(ClsEntityOnBoardingProcess objEntityOnBoarding,ClsEntityOnBoardingProcess objEntityOnBoardingVisa, ClsEntityOnBoardingProcess objEntityOnBoardingFlight, ClsEntityOnBoardingProcess objEntityOnBoardingRoom, ClsEntityOnBoardingProcess objEntityOnBoardingAir, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList1, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList2, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList3, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList4)
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
                   string strQueryAddVisa = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_VISADTL";
                   using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddVisa, con))
                   {
                       cmdInsertOnBoard.Transaction = tran;

                       cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_PROCESS_DETAIL);
                       objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityOnBoardingVisa.OnboardingDetailId = Convert.ToInt32(strNextNum);

                       cmdInsertOnBoard.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingVisa.OnboardingDetailId;
                       cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingVisa.OnboardingId;
                       cmdInsertOnBoard.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingVisa.ParticularId;
                       cmdInsertOnBoard.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingVisa.StatusId;
                       if (objEntityOnBoardingVisa.VisatypeId != 0)
                       {
                           cmdInsertOnBoard.Parameters.Add("P_VISATYP", OracleDbType.Int32).Value = objEntityOnBoardingVisa.VisatypeId;
                       }
                       else
                       {
                           cmdInsertOnBoard.Parameters.Add("P_VISATYP", OracleDbType.Int32).Value = null;
                       }

                       if (objEntityOnBoardingVisa.VisaBundleId != 0)
                       {
                           cmdInsertOnBoard.Parameters.Add("P_VISABUNDLE", OracleDbType.Int32).Value = objEntityOnBoardingVisa.VisaBundleId;
                       }
                       else
                       {
                           cmdInsertOnBoard.Parameters.Add("P_VISABUNDLE", OracleDbType.Int32).Value = null;
                       }


                       if (objEntityOnBoardingVisa.UsrDate!=DateTime.MinValue)
                       {
                         cmdInsertOnBoard.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingVisa.UsrDate;  
                       }
                       else
                       {
                           cmdInsertOnBoard.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                       }
                       
                       cmdInsertOnBoard.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingVisa.Finishstatus;
                       cmdInsertOnBoard.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingVisa.CloseStatusId;
                       cmdInsertOnBoard.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingVisa.CandId;
                       cmdInsertOnBoard.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoardingVisa.ActFileName;
                       cmdInsertOnBoard.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoardingVisa.FileName;
                       cmdInsertOnBoard.ExecuteNonQuery();


                       foreach (ClsEntityOnBoardingProcess objEntityOnBoardEmp in objEntityOnBoardVisaEmpList1)
                       {
                           string strQueryAddEmp = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingVisa.OnboardingDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                               cmdInsertEmp.ExecuteNonQuery();

                           }
                       }

                   }
                   



                   string strQueryAddFlight = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_FLGHT";
                   using (OracleCommand cmdInsertFlght = new OracleCommand(strQueryAddFlight, con))
                   {
                       cmdInsertFlght.Transaction = tran;

                       cmdInsertFlght.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_PROCESS_DETAIL);
                       objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityOnBoardingFlight.OnboardingDetailId = Convert.ToInt32(strNextNum);
                       cmdInsertFlght.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.OnboardingDetailId;
                       cmdInsertFlght.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.OnboardingId;
                       cmdInsertFlght.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.ParticularId;
                       cmdInsertFlght.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.StatusId;
                       if (objEntityOnBoardingFlight.FlightTypeId!=0)
                       {
                           cmdInsertFlght.Parameters.Add("P_FLGHTYP", OracleDbType.Int32).Value = objEntityOnBoardingFlight.FlightTypeId;
                       }
                       else
                       {
                           cmdInsertFlght.Parameters.Add("P_FLGHTYP", OracleDbType.Int32).Value =null;
                       }
                       if (objEntityOnBoardingFlight.UsrDate != DateTime.MinValue)
                       {
                           cmdInsertFlght.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingFlight.UsrDate;
                       }
                       else
                       {
                           cmdInsertFlght.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                       }
                       cmdInsertFlght.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.Finishstatus;
                       cmdInsertFlght.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.CloseStatusId;
                       cmdInsertFlght.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.CandId;
                       cmdInsertFlght.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoardingFlight.ActFileName;
                       cmdInsertFlght.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoardingFlight.FileName;
                       cmdInsertFlght.ExecuteNonQuery();

                       foreach (ClsEntityOnBoardingProcess objEntityOnBoardEmp in objEntityOnBoardVisaEmpList2)
                       {
                           string strQueryAddEmp = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.OnboardingDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                               cmdInsertEmp.ExecuteNonQuery();

                           }
                       }
                   }


                   string strQueryAddRoom = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_ROOM";
                   using (OracleCommand cmdInsertRoom = new OracleCommand(strQueryAddRoom, con))
                   {
                       cmdInsertRoom.Transaction = tran;

                       cmdInsertRoom.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_PROCESS_DETAIL);
                       objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityOnBoardingRoom.OnboardingDetailId = Convert.ToInt32(strNextNum);
                       cmdInsertRoom.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.OnboardingDetailId;
                       cmdInsertRoom.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.OnboardingId;
                       cmdInsertRoom.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ParticularId;
                       cmdInsertRoom.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.StatusId;
                       if (objEntityOnBoardingRoom.RoomTypeId!=0)
                       {
                            cmdInsertRoom.Parameters.Add("P_ROOMTYP", OracleDbType.Int32).Value = objEntityOnBoardingRoom.RoomTypeId;
                       }
                       else
                       {
                           cmdInsertRoom.Parameters.Add("P_ROOMTYP", OracleDbType.Int32).Value = null;

                       }
                       if (objEntityOnBoardingRoom.UsrDate != DateTime.MinValue)
                       {
                           cmdInsertRoom.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingRoom.UsrDate;
                       }
                       else
                       {
                           cmdInsertRoom.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                       }
                       cmdInsertRoom.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.Finishstatus;
                       cmdInsertRoom.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CloseStatusId;
                       cmdInsertRoom.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CandId;
                       cmdInsertRoom.ExecuteNonQuery();

                       foreach (ClsEntityOnBoardingProcess objEntityOnBoardEmp in objEntityOnBoardVisaEmpList3)
                       {
                           string strQueryAddEmp = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.OnboardingDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                               cmdInsertEmp.ExecuteNonQuery();

                           }
                       }
                   }

                   string strQueryAddAir = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_AIR";
                   using (OracleCommand cmdInsertAir = new OracleCommand(strQueryAddAir, con))
                   {
                       cmdInsertAir.Transaction = tran;

                       cmdInsertAir.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_PROCESS_DETAIL);
                       objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityOnBoardingAir.OnboardingDetailId = Convert.ToInt32(strNextNum);
                       cmdInsertAir.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.OnboardingDetailId;
                       cmdInsertAir.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingAir.OnboardingId;
                       cmdInsertAir.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ParticularId;
                       cmdInsertAir.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingAir.StatusId;
                       if (objEntityOnBoardingAir.VehicleId != 0)
                       {
                           cmdInsertAir.Parameters.Add("P_VEHID", OracleDbType.Int32).Value = objEntityOnBoardingAir.VehicleId;
                       }
                       else
                       {
                           cmdInsertAir.Parameters.Add("P_VEHID", OracleDbType.Int32).Value = null;

                       }
                       if (objEntityOnBoardingAir.UsrDate != DateTime.MinValue)
                       {
                           cmdInsertAir.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingAir.UsrDate;
                       }
                       else
                       {
                           cmdInsertAir.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                       }
                       cmdInsertAir.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.Finishstatus;
                       cmdInsertAir.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.CloseStatusId;
                       cmdInsertAir.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingAir.CandId;

                       cmdInsertAir.ExecuteNonQuery();

                       foreach (ClsEntityOnBoardingProcess objEntityOnBoardEmp in objEntityOnBoardVisaEmpList4)
                       {
                           string strQueryAddEmp = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_EMP";
                           using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                           {
                               cmdInsertEmp.Transaction = tran;

                               cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.OnboardingDetailId;
                               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
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


       public DataTable ReadVisaDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_VISADTL_BY_CAND";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }
       public DataTable ReadFlightDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_FLIGHTDTL_BY_CAND";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }
       public DataTable ReadRoomDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_ROOMDTL_BY_CAND";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }
       public DataTable ReadAirDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_AIRDTL_BY_CAND";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }
       public DataTable ReadEmpByBoardDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryReadVeh = "ONBOARDINGPROCESS.SP_READ_EMP_ONBRD_DTL";
           OracleCommand cmdReadVeh = new OracleCommand();
           cmdReadVeh.CommandText = strQueryReadVeh;
           cmdReadVeh.CommandType = CommandType.StoredProcedure;
           cmdReadVeh.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
           cmdReadVeh.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadVeh);
           return dtCategory;
       }

       public void UpdateVisaDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_UPD_VISA_DTL";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
               cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
               if (objEntityOnBoarding.VisatypeId != 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityOnBoarding.VisatypeId;

               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = null;
               
               }

               if (objEntityOnBoarding.VisaBundleId != 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_BUNDLE_ID", OracleDbType.Int32).Value = objEntityOnBoarding.VisaBundleId;

               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_BUNDLE_ID", OracleDbType.Int32).Value = null;
               }
               cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;

               if (objEntityOnBoarding.UsrDate != DateTime.MinValue)
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
               if (objEntityOnBoarding.Finishstatus == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = objEntityOnBoarding.FinishDate;
               }
               if (objEntityOnBoarding.CloseStatusId == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = objEntityOnBoarding.CloseDate;
               }
               cmdUpdOnBrd.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoarding.ActFileName;
               cmdUpdOnBrd.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoarding.FileName;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void UpdateFlightDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_UPD_FLIGHT_DTL";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
               cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
               if (objEntityOnBoarding.FlightTypeId != 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityOnBoarding.FlightTypeId;

               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = null;

               }
               cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
               if (objEntityOnBoarding.UsrDate != DateTime.MinValue)
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
           
               if (objEntityOnBoarding.Finishstatus == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = objEntityOnBoarding.FinishDate;
               }
               if (objEntityOnBoarding.CloseStatusId == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = objEntityOnBoarding.CloseDate;
               }
               cmdUpdOnBrd.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoarding.ActFileName;
               cmdUpdOnBrd.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityOnBoarding.FileName;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void UpdateRoomDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_UPD_ROOM_DTL";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
               cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
               if (objEntityOnBoarding.RoomTypeId!=0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityOnBoarding.RoomTypeId;

               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = null;
               }
               cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
               if (objEntityOnBoarding.UsrDate != DateTime.MinValue)
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
              
               if (objEntityOnBoarding.Finishstatus == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = objEntityOnBoarding.FinishDate;
               }
               if (objEntityOnBoarding.CloseStatusId == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = objEntityOnBoarding.CloseDate;
               }
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void UpdateAirDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_UPD_AIR_DTL";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
               cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
               if (objEntityOnBoarding.VehicleId!=0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityOnBoarding.VehicleId;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = null;
               }
               cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
               if (objEntityOnBoarding.UsrDate != DateTime.MinValue)
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
            
               if (objEntityOnBoarding.Finishstatus == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoarding.Finishstatus;
                   cmdUpdOnBrd.Parameters.Add("P_FNSHDATE", OracleDbType.Date).Value = objEntityOnBoarding.FinishDate;
               }
               if (objEntityOnBoarding.CloseStatusId == 0)
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdUpdOnBrd.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoarding.CloseStatusId;
                   cmdUpdOnBrd.Parameters.Add("P_CLSDATE", OracleDbType.Date).Value = objEntityOnBoarding.CloseDate;
               }
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void DeleteEmployee(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_DELETE_EMPLOYEE";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }

       public void RecallProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_RECALL_PROCESS";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void CloseProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           string strQueryuUpdOn = "ONBOARDINGPROCESS.SP_CLOSE_PROCESS";
           using (OracleCommand cmdUpdOnBrd = new OracleCommand())
           {
               cmdUpdOnBrd.CommandText = strQueryuUpdOn;
               cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
               cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
           }

       }
       public void InsertEmployee(List<ClsEntityOnBoardingProcess> objEntityOnBoardingList)
       {
           foreach ( ClsEntityOnBoardingProcess objEntityOnBoarding in objEntityOnBoardingList)
           {
           string strQueryAddEmp = "ONBOARDINGPROCESS.SP_INSERT_ONBOARDING_EMP";
           using (OracleCommand cmdInsertEmp = new OracleCommand())
           {
               cmdInsertEmp.CommandText = strQueryAddEmp;
               cmdInsertEmp.CommandType = CommandType.StoredProcedure;
               cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.OnboardingDetailId;
               cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
               cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
               clsDataLayer.ExecuteNonQuery(cmdInsertEmp);
           }

           }
       }

       public DataTable ReadVisaBundle(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {

           string strQueryReadManpwr = "ONBOARDINGPROCESS.SP_READ_VISA_QUOTA_BUNDLE";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadManpwr;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;

           cmdReadMnPwr.Parameters.Add("P_COOUNTRYID", OracleDbType.Int32).Value = objEntityOnBoarding.CountryId;
           cmdReadMnPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
           cmdReadMnPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadMnPwr.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
           cmdReadMnPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }

       public DataTable ReadVisaBundleType(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {

           string strQueryReadManpwr = "ONBOARDINGPROCESS.SP_READ_VISA_QUOTA_BUNDLE_TYPE";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadManpwr;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("COUNTRY_ID", OracleDbType.Int32).Value = objEntityOnBoarding.CountryId;
           cmdReadMnPwr.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.VisaBundleId;
           cmdReadMnPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
           cmdReadMnPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadMnPwr.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
           cmdReadMnPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }
       public DataTable ReadVisaTypeCount(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {

           string strQueryReadManpwr = "ONBOARDINGPROCESS.SP_CHECK_VISATYP_COUNT";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadManpwr;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.VisaBundleId;
           cmdReadMnPwr.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objEntityOnBoarding.VisatypeId;
           cmdReadMnPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadMnPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
        
         
           cmdReadMnPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }

       public DataTable ReadVisaDetailbyid(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {

           string strQueryReadManpwr = "ONBOARDINGPROCESS.SP_READ_VISADTL_BYID";
           OracleCommand cmdReadMnPwr = new OracleCommand();
           cmdReadMnPwr.CommandText = strQueryReadManpwr;
           cmdReadMnPwr.CommandType = CommandType.StoredProcedure;
           cmdReadMnPwr.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.VisaBundleId;
           cmdReadMnPwr.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objEntityOnBoarding.VisatypeId;
           cmdReadMnPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
           cmdReadMnPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;


           cmdReadMnPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtMnPwr = new DataTable();
           dtMnPwr = clsDataLayer.ExecuteReader(cmdReadMnPwr);
           return dtMnPwr;
       }
       
    }
}
