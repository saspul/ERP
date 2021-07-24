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
    public class clsDataLayer_Exit_Procedure_List
    {

        public DataTable ReadEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_READ_EMPLOYEE";
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

        public DataTable ReadLevEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_READEXIT_EMPLOYEE";
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
        public DataTable ReademplydtlsNotAssgnd(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXIT_EMP_DTLNOTASSGND";
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
        public DataTable ReadDivisionOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXIT_DIVISIONREAD";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadEmployeesList(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXIT_READEMP_LIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
          
           
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public int Insert_LeaveFacltyAssmnt(clsEntity_Exit_Procedure_List objEntityOnBoarding)
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
                    string strQueryAddPanel = "EXIT_PROCEDURE.SP_INSERT_EXITPROCEDURE";
                    using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddPanel, con))
                    {
                        cmdInsertOnBoard.Transaction = tran;

                        cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_PROCEDURE);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoarding.ExitProcedure = Convert.ToInt32(strNextNum);

                        cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedure;
                        // cmdInsertOnBoard.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityOnBoarding.ReqstID;
                        cmdInsertOnBoard.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                        cmdInsertOnBoard.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
                        cmdInsertOnBoard.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
                        cmdInsertOnBoard.ExecuteNonQuery();

                    }


                    tran.Commit();
                    return objEntityOnBoarding.ExitProcedure;
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }

        public void Insert_Process_Detail(clsEntity_Exit_Procedure_List objEntityOnBoarding, clsEntity_Exit_Procedure_List objEntityOnBoardingFlight, clsEntity_Exit_Procedure_List objEntityOnBoardingRoom, clsEntity_Exit_Procedure_List objEntityOnBoardingAir, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList2, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList3, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList4)
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


                   

                        string strQueryAddFlight = "EXIT_PROCEDURE.SP_INSERT_EXITPROCDTLS";
                        using (OracleCommand cmdInsertFlght = new OracleCommand(strQueryAddFlight, con))
                        {
                            cmdInsertFlght.Transaction = tran;

                            cmdInsertFlght.CommandType = CommandType.StoredProcedure;

                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_PROCEDURE);
                            objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                            string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            objEntityOnBoardingFlight.ExitProcedureDtlId = Convert.ToInt32(strNextNum);
                            cmdInsertFlght.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.ExitProcedureDtlId;
                            cmdInsertFlght.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.ExitProcedure;
                            cmdInsertFlght.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.ParticularId;
                            cmdInsertFlght.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.StatusId;
                            //cmdInsertFlght.Parameters.Add("P_FLGHTYP", OracleDbType.Int32).Value = objEntityOnBoardingFlight.FlightTypeId;
                            cmdInsertFlght.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingFlight.UsrDate;
                            cmdInsertFlght.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.Finishstatus;
                            cmdInsertFlght.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingFlight.CloseStatusId;
                            if (objEntityOnBoardingFlight.CandId != 0)
                            {
                                cmdInsertFlght.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.CandId;
                            }
                            else
                            {
                                cmdInsertFlght.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = null;
                            }
                        
                            cmdInsertFlght.ExecuteNonQuery();

                            foreach (clsEntity_Exit_Procedure_List objEntityOnBoardEmp in objEntityOnBoardVisaEmpList2)
                            {
                                string strQueryAddEmp = "EXIT_PROCEDURE.SP_INSERT_EXITPROCDREMP_EMP";
                                using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                                {
                                    cmdInsertEmp.Transaction = tran;

                                    cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                    cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.ExitProcedureDtlId;
                                    cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                                    cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                                    cmdInsertEmp.ExecuteNonQuery();

                                }
                            }
                        }



                        string strQueryAddRoom = "EXIT_PROCEDURE.SP_INSERT_EXITPROCD_VISANOC";
                    using (OracleCommand cmdInsertRoom = new OracleCommand(strQueryAddRoom, con))
                    {
                        cmdInsertRoom.Transaction = tran;

                        cmdInsertRoom.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_PROCEDURE);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoardingRoom.ExitProcedureDtlId = Convert.ToInt32(strNextNum);
                        cmdInsertRoom.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ExitProcedureDtlId;
                        cmdInsertRoom.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ExitProcedure;
                        cmdInsertRoom.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ParticularId;
                        cmdInsertRoom.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.StatusId;
                        //  cmdInsertRoom.Parameters.Add("P_ROOMTYP", OracleDbType.Int32).Value = objEntityOnBoardingRoom.RoomTypeId;
                        cmdInsertRoom.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingRoom.UsrDate;
                        cmdInsertRoom.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.Finishstatus;
                        cmdInsertRoom.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CloseStatusId;
                        cmdInsertRoom.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CandId;
                     
                        cmdInsertRoom.ExecuteNonQuery();

                        foreach (clsEntity_Exit_Procedure_List objEntityOnBoardEmp in objEntityOnBoardVisaEmpList3)
                        {
                            string strQueryAddEmp = "EXIT_PROCEDURE.SP_INSERT_EXITPROCDREMP_EMP";
                            using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                            {
                                cmdInsertEmp.Transaction = tran;

                                cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ExitProcedureDtlId;
                                cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                                cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                                cmdInsertEmp.ExecuteNonQuery();

                            }
                        }
                    }

                    string strQueryAddAir = "EXIT_PROCEDURE.SP_INSERT_EXTPROCDR_EXITPROSS";
                    using (OracleCommand cmdInsertAir = new OracleCommand(strQueryAddAir, con))
                    {
                        cmdInsertAir.Transaction = tran;

                        cmdInsertAir.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_PROCEDURE);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoardingAir.ExitProcedureDtlId = Convert.ToInt32(strNextNum);
                        cmdInsertAir.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ExitProcedureDtlId;
                        cmdInsertAir.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ExitProcedure;
                        cmdInsertAir.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ParticularId;
                        cmdInsertAir.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingAir.StatusId;
                        //cmdInsertAir.Parameters.Add("P_VEHID", OracleDbType.Int32).Value = objEntityOnBoardingAir.VehicleId;
                        cmdInsertAir.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingAir.UsrDate;
                        cmdInsertAir.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.Finishstatus;
                        cmdInsertAir.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.CloseStatusId;
                        cmdInsertAir.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingAir.CandId;
                       
                        cmdInsertAir.ExecuteNonQuery();

                        foreach (clsEntity_Exit_Procedure_List objEntityOnBoardEmp in objEntityOnBoardVisaEmpList4)
                        {
                            string strQueryAddEmp = "EXIT_PROCEDURE.SP_INSERT_EXITPROCDREMP_EMP";
                            using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                            {
                                cmdInsertEmp.Transaction = tran;

                                cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ExitProcedureDtlId;
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



        public DataTable ReadLevEmplyById(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXTPROCDR_EMPLYBYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadFlightDetailByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXTPROCDR_FLIGHTDTLSBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
        
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadEmpByLeavAssmntDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXTPROCDR_EMPBYASSMNT_DTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;

            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadSettlmentByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXTPROCDR_SETTLMNTBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
           
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadExitProcssByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_EXTPROCDR_EXTPRSSBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
           
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }


        public void UpdateFlightDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryuUpdOn = "EXIT_PROCEDURE.SP_UPD_FLIGHT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
      
                cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;

                cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
                cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
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
        public void UpdateSettlmentDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryuUpdOn = "EXIT_PROCEDURE.SP_UPD_SETTLMENT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
           
                cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;

                cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
                cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
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
        public void UpdateExitProcssDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryuUpdOn = "EXIT_PROCEDURE.SP_UPD_EXIT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
               
                cmdUpdOnBrd.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;

                cmdUpdOnBrd.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
                cmdUpdOnBrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoarding.UsrDate;
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

        public void DeleteEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryuUpdOn = "EXIT_PROCEDURE.SP_DELETE_EMPLOYEE";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
            }

        }

        public void InsertEmployee(List<clsEntity_Exit_Procedure_List> objEntityOnBoardingList)
        {
            foreach (clsEntity_Exit_Procedure_List objEntityOnBoarding in objEntityOnBoardingList)
            {
                string strQueryAddEmp = "EXIT_PROCEDURE.SP_INSERT_EXITPROCDREMP_EMP";
                using (OracleCommand cmdInsertEmp = new OracleCommand())
                {
                    cmdInsertEmp.CommandText = strQueryAddEmp;
                    cmdInsertEmp.CommandType = CommandType.StoredProcedure;
                    cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                    cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
                    cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                    clsDataLayer.ExecuteNonQuery(cmdInsertEmp);
                }

            }
        }

        public void RecallProcess(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryuUpdOn = "EXIT_PROCEDURE.SP_RECALL_PROCESS";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.ExitProcedureDtlId;
                clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
            }

        }

        public DataTable CheckStatusBefrEdit1(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_READ_EDITCHK";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            // cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
        
            cmdReadEmp.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadClearanceOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_READ_CLEARSTS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
        

          
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadSettlementOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            string strQueryReadEmp = "EXIT_PROCEDURE.SP_READ_SETTLEMENT_STS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

       
    }
}
