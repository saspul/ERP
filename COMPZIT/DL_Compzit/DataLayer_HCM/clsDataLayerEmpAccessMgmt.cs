using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerEmpAccessMgmt
    {
        //This Method for checking employee name
        public DataTable checkEmpcode(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
            DataTable dtEmpcode = new DataTable();
            using (OracleCommand cmdReadEmpcode = new OracleCommand())
            {
                cmdReadEmpcode.CommandText = "HCM_EMP_ACESS_MGMT.SP_CHECK_EMPCODE";
                cmdReadEmpcode.CommandType = CommandType.StoredProcedure;
                cmdReadEmpcode.Parameters.Add("E_CODE", OracleDbType.Varchar2).Value = objEntEmpAcesMgmt.EmpId;
                cmdReadEmpcode.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
                cmdReadEmpcode.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
                cmdReadEmpcode.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtEmpcode = clsDataLayer.SelectDataTable(cmdReadEmpcode);
            }
            return dtEmpcode;
        }
        //Insert into the tables
        public void InsertAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt,List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertEmpAcsMgmt = "HCM_EMP_ACESS_MGMT.SP_INSERT_EMPDTLS";

                    foreach (clsEntityEmplyeeAccessMgmt objEmpAcsMgmt in objEntityEmpAccessMgmtList)
                    {
                        using (OracleCommand cmdinsEmpAcsMgmt = new OracleCommand())
                        {
                            cmdinsEmpAcsMgmt.Transaction = tran;
                            cmdinsEmpAcsMgmt.Connection = con;

                            cmdinsEmpAcsMgmt.CommandText = strinsertEmpAcsMgmt;
                            cmdinsEmpAcsMgmt.CommandType = CommandType.StoredProcedure;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_INSUSRID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.UsrId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_CRPRTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_INSDATE", OracleDbType.Date).Value = objEntEmpAcesMgmt.InsertDate;

                            cmdinsEmpAcsMgmt.Parameters.Add("E_EMPID", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_EMPFNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpFirstName;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_EMPLNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpLastName;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = objEmpAcsMgmt.AttendenceDate;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_CHKIN", OracleDbType.Date).Value = objEmpAcsMgmt.FirstCheckIn;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_CHKOUT", OracleDbType.Date).Value = objEmpAcsMgmt.LastCheckOut;
                            cmdinsEmpAcsMgmt.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }
        //Read check-in and check-out time of business unit
        public DataTable ReadChkinAndChkOut(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
                string strChkinAndChkOut = "HCM_EMP_ACESS_MGMT.SP_READ_CHKIN_CHKOUT";
                OracleCommand cmdReadChkinAndChkOut = new OracleCommand();
                cmdReadChkinAndChkOut.CommandText = strChkinAndChkOut;
                cmdReadChkinAndChkOut.CommandType = CommandType.StoredProcedure;
                cmdReadChkinAndChkOut.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
                cmdReadChkinAndChkOut.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
                cmdReadChkinAndChkOut.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtChkinAndChkOut = clsDataLayer.ExecuteReader(cmdReadChkinAndChkOut);
                return dtChkinAndChkOut;
        }
        public void InsertIncorrectAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt, List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertEmpAcsMgmt = "HCM_EMP_ACESS_MGMT.SP_INCORRECT_INSERT_EMPDTLS";

                    foreach (clsEntityEmplyeeAccessMgmt objEmpAcsMgmt in objEntityEmpAccessMgmtList)
                    {
                        using (OracleCommand cmdinsEmpAcsMgmt = new OracleCommand())
                        {
                            cmdinsEmpAcsMgmt.Transaction = tran;
                            cmdinsEmpAcsMgmt.Connection = con;

                            cmdinsEmpAcsMgmt.CommandText = strinsertEmpAcsMgmt;
                            cmdinsEmpAcsMgmt.CommandType = CommandType.StoredProcedure;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_EMPID", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_CRPRTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_INSDATE", OracleDbType.Date).Value = objEntEmpAcesMgmt.InsertDate;
                            if (objEmpAcsMgmt.EmpFirstName != "")
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPFNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpFirstName;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPFNM", OracleDbType.Varchar2).Value = null;
                            }
                            if (objEmpAcsMgmt.EmpLastName != "")
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPLNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpLastName;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPLNM", OracleDbType.Varchar2).Value = null;
                            }
                            if (objEmpAcsMgmt.AttendenceDate == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = objEmpAcsMgmt.AttendenceDate;
                            }
                            if (objEmpAcsMgmt.FirstCheckIn == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKIN", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKIN", OracleDbType.Date).Value = objEmpAcsMgmt.FirstCheckIn;
                            }
                            if (objEmpAcsMgmt.LastCheckOut == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKOUT", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKOUT", OracleDbType.Date).Value = objEmpAcsMgmt.LastCheckOut;
                            }
                            cmdinsEmpAcsMgmt.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEmpAcsMgmt.Status;
                            cmdinsEmpAcsMgmt.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }

        public void UpdateDuplicateAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt, List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertEmpAcsMgmt = "HCM_EMP_ACESS_MGMT.SP_UPDATE_DUPLICATED";

                    foreach (clsEntityEmplyeeAccessMgmt objEmpAcsMgmt in objEntityEmpAccessMgmtList)
                    {
                        using (OracleCommand cmdinsEmpAcsMgmt = new OracleCommand())
                        {
                            cmdinsEmpAcsMgmt.Transaction = tran;
                            cmdinsEmpAcsMgmt.Connection = con;

                            cmdinsEmpAcsMgmt.CommandText = strinsertEmpAcsMgmt;
                            cmdinsEmpAcsMgmt.CommandType = CommandType.StoredProcedure;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_EMPID", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_CRPRTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
                            cmdinsEmpAcsMgmt.Parameters.Add("E_INSDATE", OracleDbType.Date).Value = objEntEmpAcesMgmt.InsertDate;
                            if (objEmpAcsMgmt.EmpFirstName != "")
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPFNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpFirstName;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPFNM", OracleDbType.Varchar2).Value = null;
                            }
                            if (objEmpAcsMgmt.EmpLastName != "")
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPLNM", OracleDbType.Varchar2).Value = objEmpAcsMgmt.EmpLastName;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_EMPLNM", OracleDbType.Varchar2).Value = null;
                            }
                            if (objEmpAcsMgmt.AttendenceDate == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = objEmpAcsMgmt.AttendenceDate;
                            }
                            if (objEmpAcsMgmt.FirstCheckIn == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKIN", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKIN", OracleDbType.Date).Value = objEmpAcsMgmt.FirstCheckIn;
                            }
                            if (objEmpAcsMgmt.LastCheckOut == DateTime.MinValue)
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKOUT", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdinsEmpAcsMgmt.Parameters.Add("E_CHKOUT", OracleDbType.Date).Value = objEmpAcsMgmt.LastCheckOut;
                            }
                            cmdinsEmpAcsMgmt.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEmpAcsMgmt.Status;
                            cmdinsEmpAcsMgmt.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }
        // Checks the empployee is present is marked on the table
        public DataTable ReadAttendence(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
            string strAttendate = "HCM_EMP_ACESS_MGMT.SP_CHECK_ATTENDENCE";
            OracleCommand cmdReadAttendate = new OracleCommand();
            cmdReadAttendate.CommandText = strAttendate;
            cmdReadAttendate.CommandType = CommandType.StoredProcedure;
            cmdReadAttendate.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.OrgId;
            cmdReadAttendate.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntEmpAcesMgmt.CorprtId;
            cmdReadAttendate.Parameters.Add("E_EMPID", OracleDbType.Varchar2).Value = objEntEmpAcesMgmt.EmpId;
            cmdReadAttendate.Parameters.Add("E_ATTENDATE", OracleDbType.Date).Value = objEntEmpAcesMgmt.AttendenceDate;
            cmdReadAttendate.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttendate = clsDataLayer.ExecuteReader(cmdReadAttendate);
            return dtAttendate;
        }
    }
}
