using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerPersonalDtls
    {
        //Method for fetch country master table from database.
        public DataTable readCountry()
        {
            string strQueryReadCountry = "CORPORATE_OFFICE.SP_READ_COUNTRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Method for fetch religion master table from database.
        public DataTable ReadReligion()
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_RELIGION";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_RELIGION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        //Method for fetch blood group master table from database.
        public DataTable ReadBloodgrp()
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_BLDGRP";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_BLDGRP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public void insertPersonalDtls(clsEntityPersonalDtls objEntityPersonalDtls, int SubcatgId, int MessAccmId)
        {
            string strQueryAddPersnlDtls = "PERSONAL_DETAILS.SP_INS_PERSNL_DETAILS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("P_EMPUSRID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdAddPersnlDtls.Parameters.Add("P_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
                cmdAddPersnlDtls.Parameters.Add("P_REFNUM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.RefNum;
                cmdAddPersnlDtls.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = objEntityPersonalDtls.JoinDate;
                cmdAddPersnlDtls.Parameters.Add("P_MRTLSTS", OracleDbType.Int32).Value = objEntityPersonalDtls.MaritalSts;
                cmdAddPersnlDtls.Parameters.Add("P_BIRTHPLC", OracleDbType.Varchar2).Value = objEntityPersonalDtls.BirthPlace;
                if (objEntityPersonalDtls.ReligionId == 0)
                { cmdAddPersnlDtls.Parameters.Add("P_RELGNID", OracleDbType.Int32).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_RELGNID", OracleDbType.Int32).Value = objEntityPersonalDtls.ReligionId; }
                if (objEntityPersonalDtls.DOB == new DateTime())
                { cmdAddPersnlDtls.Parameters.Add("P_DOB", OracleDbType.Date).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_DOB", OracleDbType.Date).Value = objEntityPersonalDtls.DOB; }
                if (objEntityPersonalDtls.BloodGrpId == 0)
                { cmdAddPersnlDtls.Parameters.Add("P_BLDGRPID", OracleDbType.Int32).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_BLDGRPID", OracleDbType.Int32).Value = objEntityPersonalDtls.BloodGrpId; }
                cmdAddPersnlDtls.Parameters.Add("P_NICKNAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.NickName;
                cmdAddPersnlDtls.Parameters.Add("P_PAYMENT_STS", OracleDbType.Int32).Value = objEntityPersonalDtls.PaymentSts;
                //    cmdAddPersnlDtls.Parameters.Add("P_DOB", OracleDbType.Date).Value = objEntityPersonalDtls.DOB;

                //cmdAddPersnlDtls.Parameters.Add("P_RELGNID", OracleDbType.Int32).Value = objEntityPersonalDtls.ReligionId;

                //cmdAddPersnlDtls.Parameters.Add("P_EMPREPORTING", OracleDbType.Int32).Value = objEntityPersonalDtls.BloodGrpId;

                cmdAddPersnlDtls.Parameters.Add("P_SMKER", OracleDbType.Int32).Value = objEntityPersonalDtls.Smoker;
                cmdAddPersnlDtls.Parameters.Add("P_ALCHLC", OracleDbType.Int32).Value = objEntityPersonalDtls.Alcoholic;
                cmdAddPersnlDtls.Parameters.Add("P_HOBBIES", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Hobbies;


                cmdAddPersnlDtls.Parameters.Add("P_INSUSRID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdAddPersnlDtls.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;
                cmdAddPersnlDtls.Parameters.Add("P_CORPRTID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdAddPersnlDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                if (objEntityPersonalDtls.AccomdtnId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCOMDID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCOMDID", OracleDbType.Int32).Value = objEntityPersonalDtls.AccomdtnId;
                }
                if (objEntityPersonalDtls.SubCatagoryId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_CATID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_CATID", OracleDbType.Int32).Value = objEntityPersonalDtls.SubCatagoryId;
                }

                if (SubcatgId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_SUBCATID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_SUBCATID", OracleDbType.Int32).Value = SubcatgId;
                }
                if (MessAccmId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_ACCMID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_ACCMID", OracleDbType.Int32).Value = MessAccmId;
                }

                if (objEntityPersonalDtls.DateMess != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE", OracleDbType.Date).Value = objEntityPersonalDtls.DateMess;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE", OracleDbType.Date).Value = null;
                }
                if (objEntityPersonalDtls.DateAcmdtn != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACMDTN_DATE_TO", OracleDbType.Date).Value = objEntityPersonalDtls.DateAcmdtn;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACMDTN_DATE_TO", OracleDbType.Date).Value = null;
                }
                if (objEntityPersonalDtls.DateMessFrom != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_FROM", OracleDbType.Date).Value = objEntityPersonalDtls.DateMessFrom;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_FROM", OracleDbType.Date).Value = null;
                }
                if (objEntityPersonalDtls.DateMessTo != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_TO", OracleDbType.Date).Value = objEntityPersonalDtls.DateMessTo;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_TO", OracleDbType.Date).Value = null;
                }
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
        public void updatePersonalDtls(clsEntityPersonalDtls objEntityPersonalDtls, int SubcatgId, int MessAccmId)
        {


            string strQueryAddPersnlDtls = "PERSONAL_DETAILS.SP_UPD_PERSNL_DETAILS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("P_EMPUSRID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdAddPersnlDtls.Parameters.Add("P_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
                cmdAddPersnlDtls.Parameters.Add("P_REFNUM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.RefNum;
                cmdAddPersnlDtls.Parameters.Add("P_JOINDATE", OracleDbType.Date).Value = objEntityPersonalDtls.JoinDate;
                cmdAddPersnlDtls.Parameters.Add("P_MRTLSTS", OracleDbType.Int32).Value = objEntityPersonalDtls.MaritalSts;
                cmdAddPersnlDtls.Parameters.Add("P_BIRTHPLC", OracleDbType.Varchar2).Value = objEntityPersonalDtls.BirthPlace;
                if (objEntityPersonalDtls.ReligionId == 0)
                { cmdAddPersnlDtls.Parameters.Add("P_RELGNID", OracleDbType.Int32).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_RELGNID", OracleDbType.Int32).Value = objEntityPersonalDtls.ReligionId; }
                if (objEntityPersonalDtls.DOB == new DateTime())
                { cmdAddPersnlDtls.Parameters.Add("P_DOB", OracleDbType.Date).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_DOB", OracleDbType.Date).Value = objEntityPersonalDtls.DOB; }
                if (objEntityPersonalDtls.BloodGrpId == 0)
                { cmdAddPersnlDtls.Parameters.Add("P_BLDGRPID", OracleDbType.Int32).Value = null; }
                else { cmdAddPersnlDtls.Parameters.Add("P_BLDGRPID", OracleDbType.Int32).Value = objEntityPersonalDtls.BloodGrpId; }
                cmdAddPersnlDtls.Parameters.Add("P_NICKNAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.NickName;
                cmdAddPersnlDtls.Parameters.Add("P_SMKER", OracleDbType.Int32).Value = objEntityPersonalDtls.Smoker;
                cmdAddPersnlDtls.Parameters.Add("P_ALCHLC", OracleDbType.Int32).Value = objEntityPersonalDtls.Alcoholic;
                cmdAddPersnlDtls.Parameters.Add("P_HOBBIES", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Hobbies;
                cmdAddPersnlDtls.Parameters.Add("P_PAYMENT_STS", OracleDbType.Int32).Value = objEntityPersonalDtls.PaymentSts;



                cmdAddPersnlDtls.Parameters.Add("P_UPDUSRID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdAddPersnlDtls.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;
                if (objEntityPersonalDtls.AccomdtnId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCOMDID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCOMDID", OracleDbType.Int32).Value = objEntityPersonalDtls.AccomdtnId;
                }
                if (objEntityPersonalDtls.SubCatagoryId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_CATID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_CATID", OracleDbType.Int32).Value = objEntityPersonalDtls.SubCatagoryId;
                }

                if (SubcatgId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_SUBCATID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACCM_SUBCATID", OracleDbType.Int32).Value = SubcatgId;
                }
                if (MessAccmId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_ACCMID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_ACCMID", OracleDbType.Int32).Value = MessAccmId;
                }
                if (objEntityPersonalDtls.DateMess != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE", OracleDbType.Date).Value = objEntityPersonalDtls.DateMess;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE", OracleDbType.Date).Value = null;
                }

                if (objEntityPersonalDtls.DateAcmdtn != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACMDTN_DATE_TO", OracleDbType.Date).Value = objEntityPersonalDtls.DateAcmdtn;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_ACMDTN_DATE_TO", OracleDbType.Date).Value = null;
                }
                if (objEntityPersonalDtls.DateMessFrom != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_FROM", OracleDbType.Date).Value = objEntityPersonalDtls.DateMessFrom;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_FROM", OracleDbType.Date).Value = null;
                }
                if (objEntityPersonalDtls.DateMessTo != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_TO", OracleDbType.Date).Value = objEntityPersonalDtls.DateMessTo;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_MESS_DATE_TO", OracleDbType.Date).Value = null;
                }
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }

        public DataTable ReadPersnlDtlsById(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadDtls = "PERSONAL_DETAILS.SP_READ_PERSNLDTLS_BYID";
            using (OracleCommand cmdReadDtls = new OracleCommand())
            {
                cmdReadDtls.CommandText = strQueryReadDtls;
                cmdReadDtls.CommandType = CommandType.StoredProcedure;
                cmdReadDtls.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadDtls.Parameters.Add("P_DTLS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadDtls);
                return dt;
            }
        }
        public string CheckPerDtlAddedOrNot(string strId)
        {

            string strQueryChecK = "PERSONAL_DETAILS.SP_CHECK_PER_DTL_COUNT";
            OracleCommand cmdCheck = new OracleCommand();
            cmdCheck.CommandText = strQueryChecK;
            cmdCheck.CommandType = CommandType.StoredProcedure;
            cmdCheck.Parameters.Add("P_ID", OracleDbType.Int32).Value = Convert.ToInt32(strId);
            cmdCheck.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheck);
            string strReturn = cmdCheck.Parameters["P_COUNT"].Value.ToString();
            cmdCheck.Dispose();
            return strReturn;
        }


        public string checkEmpId(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            string strQueryCheckCorp = "PERSONAL_DETAILS.SP_CHECK_EMPID";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
            cmdCheckCorp.Parameters.Add("P_CORPRTID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
            cmdCheckCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
            cmdCheckCorp.Parameters.Add("P_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
            cmdCheckCorp.Parameters.Add("P_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["P_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        public DataTable ReadEmployee(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_EMPLOYEES";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdReadCountry.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadCountry.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public DataTable ReadResignDetails(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_CHCK_EMP_RESIGN";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmployeeId;
                cmdReadCountry.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;

                cmdReadCountry.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public void UpdateResignDetails(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.UPDATE_RESIGNDETAILS";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmployeeId;
                cmdReadCountry.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdReadCountry.Parameters.Add("R_STAT", OracleDbType.Int32).Value = objEntityPersonalDtls.Resignsstats;
                cmdReadCountry.Parameters.Add("R_LVNGDATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;
                cmdReadCountry.Parameters.Add("R_ID", OracleDbType.Int32).Value = Convert.ToInt32(objEntityPersonalDtls.RefNum);

                cmdReadCountry.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdReadCountry);

                //  return dt;
            }
        }

        public DataTable ReadAccnCatagry(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_EMP_ACCMCATGRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_ACCMID", OracleDbType.Int32).Value = objEntityPersonalDtls.AccomdtnId;


                cmdReadCountry.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }

        public DataTable ReadAccnSubCatagry(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_EMP_ACCMSUBCATGRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_ACCMID", OracleDbType.Int32).Value = objEntityPersonalDtls.AccomdtnId;
                cmdReadCountry.Parameters.Add("R_ACCMCATID", OracleDbType.Int32).Value = objEntityPersonalDtls.SubCatagoryId;

                cmdReadCountry.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public DataTable ReadAccomdtionMess(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_EMP_READ_MESS_ACCOMDTION";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadCountry.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdReadCountry.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdReadCountry.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public DataTable ReadAccomdtion(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_ACCOMMODATION";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadCountry.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdReadCountry.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdReadCountry.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }


        public void EmployeeResign()
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.RESIGNEMPLOYEE";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                clsDataLayer.ExecuteNonQuery(cmdReadCountry);

                //  return dt;
            }
        }

        public DataTable ReadBank(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_BANK";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadCountry.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdReadCountry.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdReadCountry.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdReadCountry.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }

        public void InsertBankDtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryAddPersnlDtls = "PERSONAL_DETAILS.SP_INS_BANK_DETAILS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdAddPersnlDtls.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdAddPersnlDtls.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                if (objEntityPersonalDtls.BankId == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_BANK_ID", OracleDbType.Int32).Value = DBNull.Value;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_BANK_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.BankId;
                }
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_BRANCH", OracleDbType.Varchar2).Value = objEntityPersonalDtls.BankBranch;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_ACCOUNT_TYP", OracleDbType.Int32).Value = objEntityPersonalDtls.AccountTyp;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_IBAN", OracleDbType.Varchar2).Value = objEntityPersonalDtls.IbanNo;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_CARDNUM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.CardNo;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_INS_USR_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_INS_DATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;

                ////emp-0043 start
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }

        public DataTable ReadBankDtlsById(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_BANKDTLS_BYID";
            using (OracleCommand cmdReadBankDtls = new OracleCommand())
            {
                cmdReadBankDtls.CommandText = strQueryReadCountry;
                cmdReadBankDtls.CommandType = CommandType.StoredProcedure;
                cmdReadBankDtls.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdReadBankDtls.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadBankDtls);
                return dt;
            }
        }

        public void UpdateBankDtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryAddPersnlDtls = "PERSONAL_DETAILS.SP_UPD_BANK_DETAILS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
                cmdAddPersnlDtls.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
                cmdAddPersnlDtls.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
                cmdAddPersnlDtls.Parameters.Add("P_BANK_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.BankId;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_BRANCH", OracleDbType.Varchar2).Value = objEntityPersonalDtls.BankBranch;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_ACCOUNT_TYP", OracleDbType.Int32).Value = objEntityPersonalDtls.AccountTyp;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_IBAN", OracleDbType.Varchar2).Value = objEntityPersonalDtls.IbanNo;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_CARDNUM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.CardNo;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_UPD_USR_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_UPD_DATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;

                //mp-0043 start

                //cmdAddPersnlDtls.Parameters.Add("P_EMPBANK_DLT_STS ", OracleDbType.Date).Value = objEntityPersonalDtls.DeleteSts;

                //end

                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }

        ////EMP-0043 start

        //public void DeleteBankList(clsEntityPersonalDtls objEntityPersonalDtls)
        //{
        //    string strQueryReadSalaryPaidList = "PERSONAL_DETAILS.SP_DEL_BANK_DETAILS";
        //    OracleCommand cmdReadSalaryPaidList = new OracleCommand();
        //    cmdReadSalaryPaidList.CommandText = strQueryReadSalaryPaidList;
        //    cmdReadSalaryPaidList.CommandType = CommandType.StoredProcedure;
        //    cmdReadSalaryPaidList.Parameters.Add("P_BANKID", OracleDbType.Int32).Value = objEntityPersonalDtls.BankDtlId;
        //    clsDataLayer.ExecuteNonQuery(cmdReadSalaryPaidList);
        //    //cmdReadSalaryPaidList.ExecuteNonQuery();

        //}
        ////END

        //emp-0043 start
        public void CancelBankdtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strQueryCancelBanklist = "PERSONAL_DETAILS.SP_CANCEL_BANK_DTLS";
            using (OracleCommand cmdCancelBankDtls = new OracleCommand())
            {
                cmdCancelBankDtls.CommandText = strQueryCancelBanklist;
                cmdCancelBankDtls.CommandType = CommandType.StoredProcedure;
                cmdCancelBankDtls.Parameters.Add("P_EMPBANK_CNCL_USR_ID ", OracleDbType.Int32).Value = objEntityPersonalDtls.User_Id;
                cmdCancelBankDtls.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.BankDtlId; ;
                cmdCancelBankDtls.Parameters.Add("P_PAYMENT_STS", OracleDbType.Int32).Value = objEntityPersonalDtls.PaymentSts;

                clsDataLayer.ExecuteNonQuery(cmdCancelBankDtls);





            }
            //EMP-0043 END
        }
    }
}
