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
    public class clsData_LeaveFacltyAssmntList
    {

        public DataTable ReadEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_READ_EMPLOYEE";
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

        public DataTable ReadLevEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_READLEAV_EMPLOYEE";
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
        public DataTable ReademplydtlsNotAssgnd(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_EMP_DTLNOTASSGND";
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
        public DataTable ReadDivisionOfEmp(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_DIVISIONREAD";
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

        public DataTable ReadEmployeesList(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_READEMP_LIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoarding.StatusId;
            if (objEntityOnBoarding.FromDate == DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntityOnBoarding.FromDate;
            }
            if (objEntityOnBoarding.ToDate == DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntityOnBoarding.ToDate;
            }
            cmdReadEmp.Parameters.Add("P_STFFORWRK", OracleDbType.Int32).Value = objEntityOnBoarding.RadioStaffChk;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                     cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public int Insert_LeaveFacltyAssmnt(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
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
                    string strQueryAddPanel = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEAVFACLTY";
                    using (OracleCommand cmdInsertOnBoard = new OracleCommand(strQueryAddPanel, con))
                    {
                        cmdInsertOnBoard.Transaction = tran;

                        cmdInsertOnBoard.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_FACILITY_ASSEMENT);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoarding.LevFacltyAssmntId = Convert.ToInt32(strNextNum);

                        cmdInsertOnBoard.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntId;
                       // cmdInsertOnBoard.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityOnBoarding.ReqstID;
                        cmdInsertOnBoard.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                        cmdInsertOnBoard.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
                        cmdInsertOnBoard.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityOnBoarding.UserId;
                        cmdInsertOnBoard.ExecuteNonQuery();

                    }


                    tran.Commit();
                    return objEntityOnBoarding.LevFacltyAssmntId;
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }

        public void Insert_Process_Detail(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingFlight, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingRoom, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingAir, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList2, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList3, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList4,string FlihtChk)
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


                    if (FlihtChk == "1")
                    {

                        string strQueryAddFlight = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEVFACILITY_ASSMENT";
                        using (OracleCommand cmdInsertFlght = new OracleCommand(strQueryAddFlight, con))
                        {
                            cmdInsertFlght.Transaction = tran;

                            cmdInsertFlght.CommandType = CommandType.StoredProcedure;

                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_FACILITY_ASSEMENT);
                            objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                            string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            objEntityOnBoardingFlight.LevFacltyAssmntDtlId = Convert.ToInt32(strNextNum);
                            cmdInsertFlght.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LevFacltyAssmntDtlId;
                            cmdInsertFlght.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LevFacltyAssmntId;
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
                            if (objEntityOnBoardingFlight.LeavId != 0)
                            {
                                cmdInsertFlght.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LeavId;
                            }
                            else
                            {
                                cmdInsertFlght.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = null;
                            }
                            cmdInsertFlght.ExecuteNonQuery();

                            foreach (clsEntity_LeaveFacltyAssmntList objEntityOnBoardEmp in objEntityOnBoardVisaEmpList2)
                            {
                                string strQueryAddEmp = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEAVFACLTYEMP_EMP";
                                using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                                {
                                    cmdInsertEmp.Transaction = tran;

                                    cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                    cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LevFacltyAssmntDtlId;
                                    cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                                    cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                                    cmdInsertEmp.ExecuteNonQuery();

                                }
                            }
                        }
                    }


                    string strQueryAddRoom = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEVFLTY_SETTLMENT";
                    using (OracleCommand cmdInsertRoom = new OracleCommand(strQueryAddRoom, con))
                    {
                        cmdInsertRoom.Transaction = tran;

                        cmdInsertRoom.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_FACILITY_ASSEMENT);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoardingRoom.LevFacltyAssmntDtlId = Convert.ToInt32(strNextNum);
                        cmdInsertRoom.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.LevFacltyAssmntDtlId;
                        cmdInsertRoom.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.LevFacltyAssmntId;
                        cmdInsertRoom.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.ParticularId;
                        cmdInsertRoom.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.StatusId;
                      //  cmdInsertRoom.Parameters.Add("P_ROOMTYP", OracleDbType.Int32).Value = objEntityOnBoardingRoom.RoomTypeId;
                        cmdInsertRoom.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingRoom.UsrDate;
                        cmdInsertRoom.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.Finishstatus;
                        cmdInsertRoom.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CloseStatusId;
                        cmdInsertRoom.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.CandId;
                        cmdInsertRoom.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LeavId;
                        cmdInsertRoom.ExecuteNonQuery();

                        foreach (clsEntity_LeaveFacltyAssmntList objEntityOnBoardEmp in objEntityOnBoardVisaEmpList3)
                        {
                            string strQueryAddEmp = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEAVFACLTYEMP_EMP";
                            using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                            {
                                cmdInsertEmp.Transaction = tran;

                                cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingRoom.LevFacltyAssmntDtlId;
                                cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoardEmp.EmployeeId;
                                cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                                cmdInsertEmp.ExecuteNonQuery();

                            }
                        }
                    }

                    string strQueryAddAir = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEVFLTY_EXITPROSS";
                    using (OracleCommand cmdInsertAir = new OracleCommand(strQueryAddAir, con))
                    {
                        cmdInsertAir.Transaction = tran;

                        cmdInsertAir.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_FACILITY_ASSEMENT);
                        objEntCommon.CorporateID = objEntityOnBoarding.CorpOffice;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityOnBoardingAir.LevFacltyAssmntDtlId = Convert.ToInt32(strNextNum);
                        cmdInsertAir.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.LevFacltyAssmntDtlId;
                        cmdInsertAir.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityOnBoardingAir.LevFacltyAssmntId;
                        cmdInsertAir.Parameters.Add("P_PRTCLRID", OracleDbType.Int32).Value = objEntityOnBoardingAir.ParticularId;
                        cmdInsertAir.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityOnBoardingAir.StatusId;
                        //cmdInsertAir.Parameters.Add("P_VEHID", OracleDbType.Int32).Value = objEntityOnBoardingAir.VehicleId;
                        cmdInsertAir.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityOnBoardingAir.UsrDate;
                        cmdInsertAir.Parameters.Add("P_FNSHSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.Finishstatus;
                        cmdInsertAir.Parameters.Add("P_CLSSTS", OracleDbType.Int32).Value = objEntityOnBoardingAir.CloseStatusId;
                        cmdInsertAir.Parameters.Add("P_CNDID", OracleDbType.Int32).Value = objEntityOnBoardingAir.CandId;
                        cmdInsertAir.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoardingFlight.LeavId;

                        cmdInsertAir.ExecuteNonQuery();

                        foreach (clsEntity_LeaveFacltyAssmntList objEntityOnBoardEmp in objEntityOnBoardVisaEmpList4)
                        {
                            string strQueryAddEmp = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEAVFACLTYEMP_EMP";
                            using (OracleCommand cmdInsertEmp = new OracleCommand(strQueryAddEmp, con))
                            {
                                cmdInsertEmp.Transaction = tran;

                                cmdInsertEmp.CommandType = CommandType.StoredProcedure;

                                cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoardingAir.LevFacltyAssmntDtlId;
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



        public DataTable ReadLevEmplyById(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_EMPLYBYID";
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

        public DataTable ReadFlightDetailByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_FLIGHTDTLSBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadEmpByLeavAssmntDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_EMPBYASSMNT_DTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
       
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadSettlmentByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_SETTLMNTBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable ReadExitProcssByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_LEAV_EXTPRSSBY_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }


        public void UpdateFlightDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryuUpdOn = "LEAVEFACILITYASSIGNMENT.SP_UPD_FLIGHT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
                cmdUpdOnBrd.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
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
        public void UpdateSettlmentDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryuUpdOn = "LEAVEFACILITYASSIGNMENT.SP_UPD_SETTLMENT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
                cmdUpdOnBrd.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
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
        public void UpdateExitProcssDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryuUpdOn = "LEAVEFACILITYASSIGNMENT.SP_UPD_EXIT_DTL";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                cmdUpdOnBrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
                cmdUpdOnBrd.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
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

        public void DeleteEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryuUpdOn = "LEAVEFACILITYASSIGNMENT.SP_DELETE_EMPLOYEE";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
            }

        }

        public void InsertEmployee(List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardingList)
        {
            foreach (clsEntity_LeaveFacltyAssmntList objEntityOnBoarding in objEntityOnBoardingList)
            {
                string strQueryAddEmp = "LEAVEFACILITYASSIGNMENT.SP_INSERT_LEAVFACLTYEMP_EMP";
                using (OracleCommand cmdInsertEmp = new OracleCommand())
                {
                    cmdInsertEmp.CommandText = strQueryAddEmp;
                    cmdInsertEmp.CommandType = CommandType.StoredProcedure;
                    cmdInsertEmp.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                    cmdInsertEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
                    cmdInsertEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
                    clsDataLayer.ExecuteNonQuery(cmdInsertEmp);
                }

            }
        }

        public void RecallProcess(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryuUpdOn = "LEAVEFACILITYASSIGNMENT.SP_RECALL_PROCESS";
            using (OracleCommand cmdUpdOnBrd = new OracleCommand())
            {
                cmdUpdOnBrd.CommandText = strQueryuUpdOn;
                cmdUpdOnBrd.CommandType = CommandType.StoredProcedure;
                cmdUpdOnBrd.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityOnBoarding.LevFacltyAssmntDtlId;
                clsDataLayer.ExecuteNonQuery(cmdUpdOnBrd);
            }

        }

        public DataTable ReadStaffdtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_READ_STAFFDTL";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
           // cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
        public DataTable ReadWorkerDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_RAED_WORKERDTL";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
           // cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public DataTable CheckStatusBefrEdit1(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            string strQueryReadEmp = "LEAVEFACILITYASSIGNMENT.SP_READ_EDITCHK";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            // cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityOnBoarding.EmployeeId;
            cmdReadEmp.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityOnBoarding.CandId;
            cmdReadEmp.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityOnBoarding.LeavId;
            cmdReadEmp.Parameters.Add("P_PARTICULAR", OracleDbType.Int32).Value = objEntityOnBoarding.ParticularId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityOnBoarding.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityOnBoarding.CorpOffice;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }
    }
}
