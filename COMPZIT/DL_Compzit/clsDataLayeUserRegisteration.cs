using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Configuration;
using HashingUtility;
using CL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayeUserRegisteration
    {
        public DataTable ReadDesignationDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = new DataTable();
            using (OracleCommand cmdReadDsgn = new OracleCommand())
            {
                cmdReadDsgn.CommandText = "USER_REGISTERATION.SP_READ_DSGN_BY_USRID";
                cmdReadDsgn.CommandType = CommandType.StoredProcedure;
                cmdReadDsgn.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityUsrReg.DsgControl.ToString();
                cmdReadDsgn.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdReadDsgn.Parameters.Add("D_DSGN_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtDsgnDetails = clsDataLayer.SelectDataTable(cmdReadDsgn);
            }
            return dtDsgnDetails;
        }
        // This Method reads Designation control in the database by passing dsgn_id
        public string ReadDsgnCntrl(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckDsgnName = "USER_REGISTERATION.SP_READ_DSGN_CNTRL";
            OracleCommand cmdCheckDsgnName = new OracleCommand();

            cmdCheckDsgnName.CommandText = strQueryCheckDsgnName;
            cmdCheckDsgnName.CommandType = CommandType.StoredProcedure;
            cmdCheckDsgnName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
            cmdCheckDsgnName.Parameters.Add("D_CNTRL", OracleDbType.Varchar2, 1).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDsgnName);
            string strReturn = cmdCheckDsgnName.Parameters["D_CNTRL"].Value.ToString();
            cmdCheckDsgnName.Dispose();
            return strReturn;
        }
        // This Method reads Corporate office in the database 
        public DataTable ReadCrptOfficeDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrprtoffcDetails = new DataTable();
            using (OracleCommand cmdReadCrprtoffc = new OracleCommand())
            {
                cmdReadCrprtoffc.CommandText = "USER_REGISTERATION.SP_READ_CORP_OFFICES";
                cmdReadCrprtoffc.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtoffc.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdReadCrprtoffc.Parameters.Add("U_CRPRT_OFFC_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCrprtoffcDetails = clsDataLayer.SelectDataTable(cmdReadCrprtoffc);
            }
            return dtCrprtoffcDetails;
        }
        // This Method reads accesible Corporate office in the database 
        public DataTable ReadAccessibleCorp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrprtoffcDetails = new DataTable();
            using (OracleCommand cmdReadCrprtoffc = new OracleCommand())
            {
                cmdReadCrprtoffc.CommandText = "USER_REGISTERATION.SP_READ_ACSBL_CORP_OFS";
                cmdReadCrprtoffc.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtoffc.Parameters.Add("U_USERID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdReadCrprtoffc.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdReadCrprtoffc.Parameters.Add("U_DESGN", OracleDbType.Varchar2).Value = objEntityUsrReg.DsgControl;
                cmdReadCrprtoffc.Parameters.Add("U_CRPRT_OFFC_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCrprtoffcDetails = clsDataLayer.SelectDataTable(cmdReadCrprtoffc);
            }
            return dtCrprtoffcDetails;
        }
        // This Method reads Corporate Department in the database by passing Corporate Id
        public DataTable ReadCrptDeptDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrprtDeprtDetails = new DataTable();
            using (OracleCommand cmdReadCrprtDeprt = new OracleCommand())
            {
                cmdReadCrprtDeprt.CommandText = "USER_REGISTERATION.SP_READ_CORP_DEPTS";
                cmdReadCrprtDeprt.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtDeprt.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdReadCrprtDeprt.Parameters.Add("U_CORP_DEPTS_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCrprtDeprtDetails = clsDataLayer.SelectDataTable(cmdReadCrprtDeprt);
            }
            return dtCrprtDeprtDetails;
        }
        // This Method checks User Email in the database for duplication
        public string CheckDupUserEmailIns(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckUsrName = "USER_REGISTERATION.SP_CHECK_INS_GN_USR_EMAIL";
            OracleCommand cmdCheckUsrName = new OracleCommand();

            cmdCheckUsrName.CommandText = strQueryCheckUsrName;
            cmdCheckUsrName.CommandType = CommandType.StoredProcedure;
            cmdCheckUsrName.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.UserEmail;
            cmdCheckUsrName.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckUsrName.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUsrName);
            string strReturn = cmdCheckUsrName.Parameters["U_COUNT"].Value.ToString();
            cmdCheckUsrName.Dispose();
            return strReturn;

        }
        // This Method checks User Email in the database for duplication
        public string CheckDupUserEmailUpd(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckUsrName = "USER_REGISTERATION.SP_CHECK_UPD_GN_USR_EMAIL";
            OracleCommand cmdCheckUsrName = new OracleCommand();

            cmdCheckUsrName.CommandText = strQueryCheckUsrName;
            cmdCheckUsrName.CommandType = CommandType.StoredProcedure;
            cmdCheckUsrName.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdCheckUsrName.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.UserEmail;
            cmdCheckUsrName.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckUsrName.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUsrName);
            string strReturn = cmdCheckUsrName.Parameters["U_COUNT"].Value.ToString();
            cmdCheckUsrName.Dispose();
            return strReturn;

        }

        // This Method checks User Login Name in the database for duplication
        public string CheckDupUserLoginName(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckUsrLName = "USER_REGISTERATION.SP_CHECK_USR_LOGINNAME";
            OracleCommand cmdCheckUsrName = new OracleCommand();

            cmdCheckUsrName.CommandText = strQueryCheckUsrLName;
            cmdCheckUsrName.CommandType = CommandType.StoredProcedure;
            cmdCheckUsrName.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdCheckUsrName.Parameters.Add("U_LOGINNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.LoginName;
            cmdCheckUsrName.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckUsrName.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUsrName);
            string strReturn = cmdCheckUsrName.Parameters["U_COUNT"].Value.ToString();
            cmdCheckUsrName.Dispose();
            return strReturn;

        }

        //Method for fetch next value from database of current next id.
        public DataTable ReadNextId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEntityUsrReg.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }

        //Methode of inserting values to Designation and Desgnation Roles table.
        public int InsertUserRegisterationDetail(clsEntityLayerUserRegistration objEntityUsrReg, List<clsEntityLayerUserCorporate> objEntityAccsCorporateList, List<clsEntityLayerUserCorporate> objlisUserCrprtDtls, List<clsEntityLayerUserDivision> objlisUserDivisionDtls, List<clsEntityLayerUserVhclType> objlisUseVhclLicTypDtls, List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls, List<clsEntityLayerEmployeeRole> objlisDsgnRol, List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol) //emp0025
        {
            int intID = 0;
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertUser = "USER_REGISTERATION.SP_INS_USR_MSTR";
                    using (OracleCommand cmdInsertUser = new OracleCommand())
                    {
                        cmdInsertUser.Transaction = tran;
                        cmdInsertUser.Connection = con;
                        cmdInsertUser.CommandText = strQueryInsertUser;
                        cmdInsertUser.CommandType = CommandType.StoredProcedure;
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsDataLayeUserRegisteration objDataLayerUserReg = new clsDataLayeUserRegisteration();
                        objEntityUsrReg.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.UserId);
                        DataTable dtNextId = objDataLayerUserReg.ReadNextId(objEntityUsrReg);
                        objEntityUsrReg.UsrRegistrationId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
                        intID = objEntityUsrReg.UsrRegistrationId;

                        //Start:-Empcode
                        DataTable dtRefFormat = ReadReferenceFormatEmp(objEntityUsrReg);
                        string refFormatByDiv = "";
                        string strRealFormat = "";
                        DataTable dtcrprtSts = ReadCrprtSts(objEntityUsrReg);
                        if (dtcrprtSts.Rows.Count > 0)
                        {

                            if (dtcrprtSts.Rows[0]["EMPID_AUTOFILL_STS"].ToString() == "0")
                            {

                                if (dtRefFormat.Rows.Count != 0)
                                {
                                    refFormatByDiv = dtRefFormat.Rows[0]["EMP_REF_FORMAT"].ToString();
                                    string strReferenceFormat = "";
                                    strReferenceFormat = refFormatByDiv;

                                    int flag = 0;
                                    string[] arrReferenceSplit = strReferenceFormat.Split('*');
                                    int intArrayRowCount = arrReferenceSplit.Length;
                                    for (int intRowCount = 0; intRowCount < intArrayRowCount; intRowCount++)
                                    {
                                        if (arrReferenceSplit[intRowCount] != "" && arrReferenceSplit[intRowCount] != null)
                                        {
                                            if (arrReferenceSplit[intRowCount].Contains("#"))
                                            {
                                                string[] strSplitWithHash = arrReferenceSplit[intRowCount].Split('#');
                                                int intArraySplitHashCount = strSplitWithHash.Length;
                                                for (int intcount = 0; intcount < intArraySplitHashCount; intcount++)
                                                {
                                                    if (strSplitWithHash[intcount] != "" && strSplitWithHash[intcount] != null)
                                                    {
                                                        if (strSplitWithHash[intcount] == "COR" || strSplitWithHash[intcount] == "USR" || strSplitWithHash[intcount] == "YER" || strSplitWithHash[intcount] == "MON")
                                                        {

                                                        }
                                                        else
                                                        {
                                                            flag = 1;
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                    if (flag == 1)
                                    {
                                        refFormatByDiv = "#COR#*/*#USR#";
                                    }
                                    if (refFormatByDiv == "" || refFormatByDiv == null)
                                    {
                                        strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + objEntityUsrReg.UsrRegistrationId.ToString();
                                    }
                                    else
                                    {
                                        strRealFormat = refFormatByDiv.ToString();
                                        if (strRealFormat.Contains("#COR#"))
                                        {
                                            strRealFormat = strRealFormat.Replace("#COR#", dtRefFormat.Rows[0]["CORPRT_CODE"].ToString());
                                        }

                                        if (strRealFormat.Contains("#USR#"))
                                        {
                                            strRealFormat = strRealFormat.Replace("#USR#", objEntityUsrReg.UsrRegistrationId.ToString());
                                        }
                                        if (strRealFormat.Contains("#YER#"))
                                        {
                                            strRealFormat = strRealFormat.Replace("#YER#", DateTime.Today.Year.ToString());
                                        }

                                        if (strRealFormat.Contains("#MON#"))
                                        {
                                            strRealFormat = strRealFormat.Replace("#MON#", DateTime.Today.Month.ToString());

                                        }

                                        if (strRealFormat == "")
                                        {
                                            strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + objEntityUsrReg.UsrRegistrationId.ToString();
                                        }
                                        strRealFormat = strRealFormat.Replace("#", "");
                                        strRealFormat = strRealFormat.Replace("*", "");
                                        strRealFormat = strRealFormat.Replace("%", "");


                                    }
                                    objEntityUsrReg.UserCode = strRealFormat;
                                }

                            }
                            else
                            {
                            }
                        }

                        //string year = DateTime.Today.Year.ToString();
                        //objEntityUsrReg.UserCode = "ALB/" + year + "/" + dtNextId.Rows[0]["MST_NEXT_VALUE"].ToString();

                        //End:-Empcode
                        string strPwd = objEntityUsrReg.UserPsw;
                        clsHash objHashing = new clsHash();
                        string strEncryptedPwd = "";
                        if (objEntityUsrReg.UserPsw != "")
                        {
                            strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
                        }

                        cmdInsertUser.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                        cmdInsertUser.Parameters.Add("U_NAME", OracleDbType.Varchar2).Value = objEntityUsrReg.UserName;
                        if (objEntityUsrReg.UserMobile != "")
                        {
                            cmdInsertUser.Parameters.Add("U_MOBILE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserMobile;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_MOBILE", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityUsrReg.UserEmail != "")
                        {
                            cmdInsertUser.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.UserEmail;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.OffclEmail != "")
                        {
                            cmdInsertUser.Parameters.Add("U_OFFCL_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.OffclEmail;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_OFFCL_EMAIL", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.LoginName != "")
                        {
                            cmdInsertUser.Parameters.Add("U_LOGIN_NAME", OracleDbType.Varchar2).Value = objEntityUsrReg.LoginName;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_LOGIN_NAME", OracleDbType.Varchar2).Value = null;
                        }
                        if (strEncryptedPwd != "")
                        {
                            cmdInsertUser.Parameters.Add("U_PWD", OracleDbType.Varchar2).Value = strEncryptedPwd;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_PWD", OracleDbType.Varchar2).Value = null;
                        }

                        cmdInsertUser.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                        if (objEntityUsrReg.UserCrprtId != 0)
                        {
                            cmdInsertUser.Parameters.Add("U_CORPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_CORPRT_ID", OracleDbType.Int32).Value = null;
                        }
                        if (objEntityUsrReg.UserCrprtDept != 0)
                        {
                            cmdInsertUser.Parameters.Add("U_CPRDEPT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtDept;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_CPRDEPT_ID", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertUser.Parameters.Add("U_DSGN_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
                        cmdInsertUser.Parameters.Add("U_JBROL_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserRoleId;
                        cmdInsertUser.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUsrReg.UserStatus;
                        if (objEntityUsrReg.ImagePath != "")
                        {
                            cmdInsertUser.Parameters.Add("U_IMAGE_PATH", OracleDbType.Varchar2).Value = objEntityUsrReg.ImagePath;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_IMAGE_PATH", OracleDbType.Varchar2).Value = null;

                        }

                        cmdInsertUser.Parameters.Add("U_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                        cmdInsertUser.Parameters.Add("U_MAILSENDSTS", OracleDbType.Int32).Value = objEntityUsrReg.MailSendSts;

                        if (objEntityUsrReg.UserCode != "")
                        {
                            cmdInsertUser.Parameters.Add("U_USER_CODE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCode;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_USER_CODE", OracleDbType.Varchar2).Value = null;
                        }
                        cmdInsertUser.Parameters.Add("U_MAILREADSTS", OracleDbType.Int32).Value = objEntityUsrReg.MailReadSts;

                        cmdInsertUser.Parameters.Add("U_LIMITEDSTS", OracleDbType.Int32).Value = objEntityUsrReg.LimitedUser;
                        // cmdInsertUser.Parameters.Add("U_JOIN_DATE", OracleDbType.Date).Value = objEntityUsrReg.JoiningDate;
                        cmdInsertUser.Parameters.Add("U_USRTYP_ID", OracleDbType.Int32).Value = objEntityUsrReg.EmployeeTypId;
                        if (objEntityUsrReg.NationalIdNumber != "")
                        {
                            cmdInsertUser.Parameters.Add("U_NTNLIDNUMBR", OracleDbType.Varchar2).Value = objEntityUsrReg.NationalIdNumber;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_NTNLIDNUMBR", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.LicenseNumber != "")
                        {
                            cmdInsertUser.Parameters.Add("U_DRVNG_LICNUMBR", OracleDbType.Varchar2).Value = objEntityUsrReg.LicenseNumber;

                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_DRVNG_LICNUMBR", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityUsrReg.LicenseExpiryDate != DateTime.MinValue)
                        {
                            cmdInsertUser.Parameters.Add("U_DRVNG_EXP_DATE", OracleDbType.Date).Value = objEntityUsrReg.LicenseExpiryDate;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_DRVNG_EXP_DATE", OracleDbType.Date).Value = null;
                        }
                        if (objEntityUsrReg.AccommodationId != 0)
                        {
                            cmdInsertUser.Parameters.Add("U_ACCOMMODTN_ID", OracleDbType.Int32).Value = objEntityUsrReg.AccommodationId;

                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_ACCOMMODTN_ID", OracleDbType.Int32).Value = null;

                        }
                        if (objEntityUsrReg.LicenseCopyPath != "")
                        {
                            cmdInsertUser.Parameters.Add("U_LIC_COPYPATH", OracleDbType.Varchar2).Value = objEntityUsrReg.LicenseCopyPath;
                        }
                        else
                        {

                            cmdInsertUser.Parameters.Add("U_LIC_COPYPATH", OracleDbType.Varchar2).Value = null;
                        }
                        cmdInsertUser.Parameters.Add("U_PSWD_EXPIRY", OracleDbType.Int32).Value = objEntityUsrReg.PasswordExpiry;
                        cmdInsertUser.Parameters.Add("U_ALLW_DUTYROSTER", OracleDbType.Int32).Value = objEntityUsrReg.AllowDutyRoster;
                        cmdInsertUser.Parameters.Add("U_FNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Fname;
                        cmdInsertUser.Parameters.Add("U_MNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Mname;
                        cmdInsertUser.Parameters.Add("U_LNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Lname;
                        cmdInsertUser.Parameters.Add("U_CNTRYID", OracleDbType.Int32).Value = objEntityUsrReg.CountryID;
                        cmdInsertUser.Parameters.Add("U_GENDER", OracleDbType.Int32).Value = objEntityUsrReg.Gender;
                        cmdInsertUser.Parameters.Add("U_TYPE", OracleDbType.Int32).Value = objEntityUsrReg.UsrType;

                        if (objEntityUsrReg.EmployeeToReport == 0)  //EMP25
                        {
                            cmdInsertUser.Parameters.Add("P_EMPREPORTING", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("P_EMPREPORTING", OracleDbType.Int32).Value = objEntityUsrReg.EmployeeToReport;
                        }

                        cmdInsertUser.ExecuteNonQuery();

                    }

                    if (objEntityAccsCorporateList != null)
                    {
                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_ACS_CORPORATE";
                        foreach (clsEntityLayerUserCorporate objAccsUserCrprt in objEntityAccsCorporateList)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objAccsUserCrprt.UsrCrprtId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }

                    if (objlisUserCrprtDtls != null)
                    {
                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_CORPORATE";
                        //string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_SUB_CORP";
                        foreach (clsEntityLayerUserCorporate objEYUserCrprt in objlisUserCrprtDtls)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserCrprt.UsrOrgId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEYUserCrprt.UsrCrprtId;
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }
                    //0013
                    if (objlisUserSubBusnessDtls != null)
                    {

                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_SUB_CORP";
                        foreach (clsEntityLayerUserSubBusness objEYUserCrprt in objlisUserSubBusnessDtls)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserCrprt.OrgId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                                //0013
                                cmdInsertUsrCrprt.Parameters.Add("U_SUBCORP", OracleDbType.Int32).Value = objEYUserCrprt.SubBusUntId;
                                //12/02 evm-0024
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }
                    ////////
                    if (objlisUserDivisionDtls != null)
                    {
                        string strQueryInsertUsrDvsn = "USER_REGISTERATION.SP_INS_USER_DIVISION";
                        foreach (clsEntityLayerUserDivision objEYUserDivsn in objlisUserDivisionDtls)
                        {
                            using (OracleCommand cmdInsertUsrDvsn = new OracleCommand())
                            {
                                cmdInsertUsrDvsn.Transaction = tran;
                                cmdInsertUsrDvsn.Connection = con;
                                cmdInsertUsrDvsn.CommandText = strQueryInsertUsrDvsn;
                                cmdInsertUsrDvsn.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrDvsn.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserDivsn.OrgId;
                                cmdInsertUsrDvsn.Parameters.Add("U_DIVISION_ID", OracleDbType.Int32).Value = objEYUserDivsn.Divisn_Id;
                                cmdInsertUsrDvsn.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrDvsn.Parameters.Add("U_DFLT_DIVISION_ID", OracleDbType.Int32).Value = objEYUserDivsn.DfltCrpDivisnId;
                                cmdInsertUsrDvsn.Parameters.Add("U_PRMRY_DIVSN_STS", OracleDbType.Int32).Value = objEYUserDivsn.PrimaryDivsnSts;
                                cmdInsertUsrDvsn.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objlisUseVhclLicTypDtls != null)
                    {
                        string strQueryInsertUsrVhclType = "USER_REGISTERATION.SP_INS_USER_VHCL_LICTYP";
                        foreach (clsEntityLayerUserVhclType objEYUserVhclType in objlisUseVhclLicTypDtls)
                        {
                            using (OracleCommand cmdInsertUsrVhclType = new OracleCommand())
                            {
                                cmdInsertUsrVhclType.Transaction = tran;
                                cmdInsertUsrVhclType.Connection = con;
                                cmdInsertUsrVhclType.CommandText = strQueryInsertUsrVhclType;
                                cmdInsertUsrVhclType.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrVhclType.Parameters.Add("U_VHCL_LICTYP_ID", OracleDbType.Int32).Value = objEYUserVhclType.LicTypeId;
                                cmdInsertUsrVhclType.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrVhclType.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objlisDsgnRol != null)
                    {
                        string strQueryInsertDsgnRole = "USER_REGISTERATION.SP_INS_EMPRL_ROLES";
                        foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRol)
                        {
                            using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                            {
                                cmdInsertDsgRole.Transaction = tran;
                                cmdInsertDsgRole.Connection = con;
                                cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                                cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                                cmdInsertDsgRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertDsgRole.Parameters.Add("E_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                                cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                                cmdInsertDsgRole.ExecuteNonQuery();
                            }
                        }
                    }
                    //NOT OK FROM HERE
                    if (objlisJobRlAppRol != null)
                    {
                        string strQueryInsertDsgnAppRole = "USER_REGISTERATION.SP_INS_EMPRL_APP_ROLES";
                        foreach (clsEntityLayerEmployeeAppRole objDsgnAppRol in objlisJobRlAppRol)
                        {
                            using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                            {
                                cmdInsertDsgAppRole.Transaction = tran;
                                cmdInsertDsgAppRole.Connection = con;
                                cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                                cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                                cmdInsertDsgAppRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertDsgAppRole.Parameters.Add("E_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                                cmdInsertDsgAppRole.ExecuteNonQuery();
                            }
                        }
                    }

                    //string strCommandText = "USER_REGISTERATION.SP_RD_LV_TYPE_DSGN";
                    //using (OracleCommand cmdLeaveType = new OracleCommand())
                    //{
                    //    cmdLeaveType.Transaction = tran;
                    //    cmdLeaveType.Connection = con;
                    //    cmdLeaveType.CommandText = strCommandText;
                    //    cmdLeaveType.CommandType = CommandType.StoredProcedure;
                    //    cmdLeaveType.Parameters.Add("D_DSN_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
                    //    cmdLeaveType.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                    //    cmdLeaveType.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                    //    cmdLeaveType.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                    //    cmdLeaveType.ExecuteNonQuery();
                    //}

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }
            return intID;
        }

        //Methode of Updating values to Users and User_Corporate Roles table.
        public void UpdateUserRegisterationDetail(clsEntityLayerUserRegistration objEntityUsrReg, List<clsEntityLayerUserCorporate> objEntityAccsCorporateList, List<clsEntityLayerUserCorporate> objlisUserCrprtDtls, List<clsEntityLayerUserDivision> objlisUserDivisionDtls, List<clsEntityLayerUserVhclType> objlisUseVhclLicTypDtls, List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls, List<clsEntityLayerEmployeeRole> objlisDsgnRol, List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol) //emp0025
        {


            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateUserBasic = "USER_REGISTERATION.SP_UPD_USR_MSTR_BASIC";
                    using (OracleCommand cmdInsertUser = new OracleCommand())
                    {
                        cmdInsertUser.Transaction = tran;
                        cmdInsertUser.Connection = con;
                        cmdInsertUser.CommandText = strQueryUpdateUserBasic;
                        cmdInsertUser.CommandType = CommandType.StoredProcedure;




                        cmdInsertUser.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                        cmdInsertUser.Parameters.Add("U_NAME", OracleDbType.Varchar2).Value = objEntityUsrReg.UserName;
                        cmdInsertUser.Parameters.Add("U_DSGN_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
                        cmdInsertUser.Parameters.Add("U_STAFF_WORK_TYP", OracleDbType.Int32).Value = objEntityUsrReg.UsrType;
                      //  cmdInsertUser.Parameters.Add("U_JOIN_DATE", OracleDbType.Date).Value = objEntityUsrReg.JoiningDate;
                        cmdInsertUser.Parameters.Add("U_USRTYP_ID", OracleDbType.Int32).Value = objEntityUsrReg.EmployeeTypId;
                        if (objEntityUsrReg.NationalIdNumber != "")
                        {
                            cmdInsertUser.Parameters.Add("U_NTNLIDNUMBR", OracleDbType.Varchar2).Value = objEntityUsrReg.NationalIdNumber;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_NTNLIDNUMBR", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityUsrReg.UserCode != "")
                        {
                            cmdInsertUser.Parameters.Add("U_USER_CODE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCode;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_USER_CODE", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.UserMobile != "")
                        {
                            cmdInsertUser.Parameters.Add("U_MOBILE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserMobile;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_MOBILE", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityUsrReg.UserEmail != "")
                        {
                            cmdInsertUser.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.UserEmail;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_EMAIL", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.OffclEmail != "")
                        {
                            cmdInsertUser.Parameters.Add("U_OFFCL_EMAIL", OracleDbType.Varchar2).Value = objEntityUsrReg.OffclEmail;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_OFFCL_EMAIL", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityUsrReg.ImagePath != "")
                        {
                            cmdInsertUser.Parameters.Add("U_IMAGE_PATH", OracleDbType.Varchar2).Value = objEntityUsrReg.ImagePath;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("U_IMAGE_PATH", OracleDbType.Varchar2).Value = null;
                        }
                        cmdInsertUser.Parameters.Add("U_MAILSENDSTS", OracleDbType.Int32).Value = objEntityUsrReg.MailSendSts;
                        cmdInsertUser.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUsrReg.UserStatus;
                        cmdInsertUser.Parameters.Add("U_MAILREADSTS", OracleDbType.Int32).Value = objEntityUsrReg.MailReadSts;

                        if (objEntityUsrReg.UserCrprtId != 0)
                        {
                            cmdInsertUser.Parameters.Add("U_CORPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                        }
                        else
                        {

                            cmdInsertUser.Parameters.Add("U_CORPRT_ID", OracleDbType.Int32).Value = null;
                        }
                        if (objEntityUsrReg.UserCrprtDept != 0)
                        {
                            cmdInsertUser.Parameters.Add("U_CPRDEPT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtDept;
                        }
                        else
                        {

                            cmdInsertUser.Parameters.Add("U_CPRDEPT_ID", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertUser.Parameters.Add("U_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                        cmdInsertUser.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;
                        cmdInsertUser.Parameters.Add("U_JOBROL_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserRoleId;
                        cmdInsertUser.Parameters.Add("U_FNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Fname;
                        cmdInsertUser.Parameters.Add("U_MNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Mname;
                        cmdInsertUser.Parameters.Add("U_LNAME", OracleDbType.Varchar2).Value = objEntityUsrReg.Lname;
                        cmdInsertUser.Parameters.Add("U_CNTRYID", OracleDbType.Int32).Value = objEntityUsrReg.CountryID;
                        cmdInsertUser.Parameters.Add("U_GENDER", OracleDbType.Int32).Value = objEntityUsrReg.Gender;
                        if (objEntityUsrReg.EmployeeToReport == 0)   //EMP25
                        {
                            cmdInsertUser.Parameters.Add("P_EMPREPORTING", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertUser.Parameters.Add("P_EMPREPORTING", OracleDbType.Int32).Value = objEntityUsrReg.EmployeeToReport;
                        }



                        cmdInsertUser.ExecuteNonQuery();

                    }

                    if (objEntityUsrReg.LoginMust == true)
                    {
                        string strPwd = objEntityUsrReg.UserPsw;
                        clsHash objHashing = new clsHash();
                        string strEncryptedPwd = "";
                        if (objEntityUsrReg.UserPsw != "")
                        {
                            strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
                        }
                        string strQueryUpdateUserLoginSection = "USER_REGISTERATION.SP_UPD_USR_MSTR_LG_SEC";
                        using (OracleCommand cmdInsertUser = new OracleCommand())
                        {
                            cmdInsertUser.Transaction = tran;
                            cmdInsertUser.Connection = con;
                            cmdInsertUser.CommandText = strQueryUpdateUserLoginSection;
                            cmdInsertUser.CommandType = CommandType.StoredProcedure;

                            cmdInsertUser.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                            if (objEntityUsrReg.LoginName != "")
                            {
                                cmdInsertUser.Parameters.Add("U_LOGIN_NAME", OracleDbType.Varchar2).Value = objEntityUsrReg.LoginName;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_LOGIN_NAME", OracleDbType.Varchar2).Value = null;
                            }

                            if (strEncryptedPwd != "")
                            {
                                cmdInsertUser.Parameters.Add("U_PWD", OracleDbType.Varchar2).Value = strEncryptedPwd;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_PWD", OracleDbType.Varchar2).Value = null;
                            }
                            cmdInsertUser.Parameters.Add("U_LIMITEDSTS", OracleDbType.Int32).Value = objEntityUsrReg.LimitedUser;
                            cmdInsertUser.Parameters.Add("U_PSWD_EXPIRY", OracleDbType.Int32).Value = objEntityUsrReg.PasswordExpiry;
                            cmdInsertUser.Parameters.Add("U_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                            cmdInsertUser.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;
                            cmdInsertUser.ExecuteNonQuery();
                        }
                    }
                    if (objEntityUsrReg.AutoWrkShopMust == true)
                    {
                        string strQueryUpdateUserAutoWrkshpSection = "USER_REGISTERATION.SP_UPD_USR_MSTR_AW_SEC";
                        using (OracleCommand cmdInsertUser = new OracleCommand())
                        {
                            cmdInsertUser.Transaction = tran;
                            cmdInsertUser.Connection = con;
                            cmdInsertUser.CommandText = strQueryUpdateUserAutoWrkshpSection;
                            cmdInsertUser.CommandType = CommandType.StoredProcedure;
                            cmdInsertUser.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                            if (objEntityUsrReg.LicenseNumber != "")
                            {
                                cmdInsertUser.Parameters.Add("U_DRVNG_LICNUMBR", OracleDbType.Varchar2).Value = objEntityUsrReg.LicenseNumber;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_DRVNG_LICNUMBR", OracleDbType.Varchar2).Value = null;
                            }
                            if (objEntityUsrReg.LicenseExpiryDate != null)
                            {
                                cmdInsertUser.Parameters.Add("U_DRVNG_EXP_DATE", OracleDbType.Date).Value = objEntityUsrReg.LicenseExpiryDate;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_DRVNG_EXP_DATE", OracleDbType.Date).Value = null;
                            }
                            if (objEntityUsrReg.AccommodationId != 0)
                            {
                                cmdInsertUser.Parameters.Add("U_ACCOMMODTN_ID", OracleDbType.Int32).Value = objEntityUsrReg.AccommodationId;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_ACCOMMODTN_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdInsertUser.Parameters.Add("U_ALLW_DUTYROSTER", OracleDbType.Int32).Value = objEntityUsrReg.AllowDutyRoster;
                            if (objEntityUsrReg.LicenseCopyPath != "")
                            {
                                cmdInsertUser.Parameters.Add("U_LIC_COPYPATH", OracleDbType.Varchar2).Value = objEntityUsrReg.LicenseCopyPath;
                            }
                            else
                            {
                                cmdInsertUser.Parameters.Add("U_LIC_COPYPATH", OracleDbType.Varchar2).Value = null;
                            }
                            cmdInsertUser.Parameters.Add("U_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                            cmdInsertUser.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;
                            cmdInsertUser.ExecuteNonQuery();
                        }
                    }
                    string strQueryDeleteUserCrprtDtls = "USER_REGISTERATION.SP_DEL_USER_CORPORATE";
                    using (OracleCommand cmdDelCrprt = new OracleCommand())
                    {
                        cmdDelCrprt.Transaction = tran;
                        cmdDelCrprt.Connection = con;
                        cmdDelCrprt.CommandText = strQueryDeleteUserCrprtDtls;
                        cmdDelCrprt.CommandType = CommandType.StoredProcedure;
                        cmdDelCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                        cmdDelCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                        cmdDelCrprt.ExecuteNonQuery();
                    }
                    string strQueryDeleteUserDvsnDtls = "USER_REGISTERATION.SP_DEL_USER_DIVISION";
                    using (OracleCommand cmdDelDvsn = new OracleCommand())
                    {
                        cmdDelDvsn.Transaction = tran;
                        cmdDelDvsn.Connection = con;
                        cmdDelDvsn.CommandText = strQueryDeleteUserDvsnDtls;
                        cmdDelDvsn.CommandType = CommandType.StoredProcedure;
                        cmdDelDvsn.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                        cmdDelDvsn.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                        cmdDelDvsn.ExecuteNonQuery();
                    }
                    string strQueryDeleteUserAcsCorp = "USER_REGISTERATION.SP_DEL_USER_ACS_CORPORATE";
                    using (OracleCommand cmdDelDvsn = new OracleCommand())
                    {
                        cmdDelDvsn.Transaction = tran;
                        cmdDelDvsn.Connection = con;
                        cmdDelDvsn.CommandText = strQueryDeleteUserAcsCorp;
                        cmdDelDvsn.CommandType = CommandType.StoredProcedure;
                        cmdDelDvsn.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                        cmdDelDvsn.ExecuteNonQuery();
                    }
                    if (objEntityAccsCorporateList != null)
                    {
                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_ACS_CORPORATE";
                        foreach (clsEntityLayerUserCorporate objAccsUserCrprt in objEntityAccsCorporateList)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objAccsUserCrprt.UsrCrprtId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }

                    if (objlisUserCrprtDtls != null)
                    {               
                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_CORPORATE";
                        foreach (clsEntityLayerUserCorporate objEYUserCrprt in objlisUserCrprtDtls)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserCrprt.UsrOrgId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEYUserCrprt.UsrCrprtId;
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objlisUserDivisionDtls != null)
                    {
                        string strQueryInsertUsrDvsn = "USER_REGISTERATION.SP_INS_USER_DIVISION";
                        foreach (clsEntityLayerUserDivision objEYUserDivsn in objlisUserDivisionDtls)
                        {
                            using (OracleCommand cmdInsertUsrDvsn = new OracleCommand())
                            {
                                cmdInsertUsrDvsn.Transaction = tran;
                                cmdInsertUsrDvsn.Connection = con;
                                cmdInsertUsrDvsn.CommandText = strQueryInsertUsrDvsn;
                                cmdInsertUsrDvsn.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrDvsn.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserDivsn.OrgId;
                                cmdInsertUsrDvsn.Parameters.Add("U_DIVISION_ID", OracleDbType.Int32).Value = objEYUserDivsn.Divisn_Id;
                                cmdInsertUsrDvsn.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrDvsn.Parameters.Add("U_DFLT_DIVISION_ID", OracleDbType.Int32).Value = objEYUserDivsn.DfltCrpDivisnId;
                                cmdInsertUsrDvsn.Parameters.Add("U_PRMRY_DIVSN_STS", OracleDbType.Int32).Value = objEYUserDivsn.PrimaryDivsnSts;
                                cmdInsertUsrDvsn.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objEntityUsrReg.AutoWrkShopMust == true)
                    {


                        string strQueryDeleteUsrVhclType = "USER_REGISTERATION.SP_DEL_USER_VHCL_LICTYP";
                        using (OracleCommand cmdDel = new OracleCommand())
                        {
                            cmdDel.Transaction = tran;
                            cmdDel.Connection = con;
                            cmdDel.CommandText = strQueryDeleteUsrVhclType;
                            cmdDel.CommandType = CommandType.StoredProcedure;
                            cmdDel.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                            cmdDel.ExecuteNonQuery();

                        }

                        if (objlisUseVhclLicTypDtls != null)
                        {
                            string strQueryInsertUsrVhclType = "USER_REGISTERATION.SP_INS_USER_VHCL_LICTYP";
                            foreach (clsEntityLayerUserVhclType objEYUserVhclType in objlisUseVhclLicTypDtls)
                            {
                                using (OracleCommand cmdInsertUsrVhclType = new OracleCommand())
                                {
                                    cmdInsertUsrVhclType.Transaction = tran;
                                    cmdInsertUsrVhclType.Connection = con;
                                    cmdInsertUsrVhclType.CommandText = strQueryInsertUsrVhclType;
                                    cmdInsertUsrVhclType.CommandType = CommandType.StoredProcedure;
                                    cmdInsertUsrVhclType.Parameters.Add("U_VHCL_LICTYP_ID", OracleDbType.Int32).Value = objEYUserVhclType.LicTypeId;
                                    cmdInsertUsrVhclType.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                    cmdInsertUsrVhclType.ExecuteNonQuery();
                                }
                            }
                        }
                     
                    }
                    if (objlisUserSubBusnessDtls != null)
                    {
                        //12/2 evm-0024
                        string strQueryDeleteUserSubCrprtDtls = "USER_REGISTERATION.SP_DEL_USER_SUB_CORP";
                        using (OracleCommand cmdDelCrprt = new OracleCommand())                        {
                            cmdDelCrprt.Transaction = tran;
                            cmdDelCrprt.Connection = con;
                            cmdDelCrprt.CommandText = strQueryDeleteUserSubCrprtDtls;
                            cmdDelCrprt.CommandType = CommandType.StoredProcedure;
                            cmdDelCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                            cmdDelCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                            cmdDelCrprt.ExecuteNonQuery();
                        }

                        string strQueryInsertUsrCrprt = "USER_REGISTERATION.SP_INS_USER_SUB_CORP";
                        foreach (clsEntityLayerUserSubBusness objEYUserCrprt in objlisUserSubBusnessDtls)
                        {
                            using (OracleCommand cmdInsertUsrCrprt = new OracleCommand())
                            {
                                cmdInsertUsrCrprt.Transaction = tran;
                                cmdInsertUsrCrprt.Connection = con;
                                cmdInsertUsrCrprt.CommandText = strQueryInsertUsrCrprt;
                                cmdInsertUsrCrprt.CommandType = CommandType.StoredProcedure;
                                cmdInsertUsrCrprt.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEYUserCrprt.OrgId;
                                cmdInsertUsrCrprt.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                                cmdInsertUsrCrprt.Parameters.Add("U_SUBCORP", OracleDbType.Int32).Value = objEYUserCrprt.SubBusUntId;
                                cmdInsertUsrCrprt.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertUsrCrprt.ExecuteNonQuery();
                            }
                        }
                    }

                    if (objlisDsgnRol != null)
                    {
                        string strQueryInsertDsgnRole = "USER_REGISTERATION.SP_INS_EMPRL_ROLES";
                        foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRol)
                        {
                            using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                            {
                                cmdInsertDsgRole.Transaction = tran;
                                cmdInsertDsgRole.Connection = con;
                                cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                                cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                                cmdInsertDsgRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertDsgRole.Parameters.Add("E_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                                cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                                cmdInsertDsgRole.ExecuteNonQuery();
                            }
                        }
                    }

                    if (objlisJobRlAppRol != null)
                    {
                        string strQueryInsertDsgnAppRole = "USER_REGISTERATION.SP_INS_EMPRL_APP_ROLES";
                        foreach (clsEntityLayerEmployeeAppRole objDsgnAppRol in objlisJobRlAppRol)
                        {
                            using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                            {
                                cmdInsertDsgAppRole.Transaction = tran;
                                cmdInsertDsgAppRole.Connection = con;
                                cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                                cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                                cmdInsertDsgAppRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                                cmdInsertDsgAppRole.Parameters.Add("E_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                                cmdInsertDsgAppRole.ExecuteNonQuery();
                            }
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
        // This Method displays User  details from the database
        public DataTable GridDisplay(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_READ_GN_USERS";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdGrid.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityUsrReg.UserStatus;
                cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityUsrReg.Cancel_Status;
                cmdGrid.Parameters.Add("C_DSGNID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
                cmdGrid.Parameters.Add("C_LIMITEDORNOT", OracleDbType.Int32).Value = objEntityUsrReg.LimitedUser;

                //0039
                if (objEntityUsrReg.LeaveFrmDate != DateTime.MinValue)
                {
                    cmdGrid.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityUsrReg.LeaveFrmDate;
                }
                else
                {
                    cmdGrid.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
                }
                if (objEntityUsrReg.LeaveToDate != DateTime.MinValue)
                {
                    cmdGrid.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityUsrReg.LeaveToDate;
                }
                else
                {
                    cmdGrid.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                }
                //end

                cmdGrid.Parameters.Add("U_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        //0039
        //method for storing exixting user code
        public void StoreExistingId(clsEntityLayerUserRegistration objEntityUsrReg)
        {           
            using (OracleCommand cmdUpdateUserEx = new OracleCommand())
            {
                cmdUpdateUserEx.CommandText = "USER_REGISTERATION.SP_UPDATE_USER_EXISTING_ID";
                cmdUpdateUserEx.CommandType = CommandType.StoredProcedure;
                cmdUpdateUserEx.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                cmdUpdateUserEx.Parameters.Add("U_ID_MAIN", OracleDbType.Int32).Value = objEntityUsrReg.UserIdMain;
                cmdUpdateUserEx.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUsrReg.UserTypeStatus;
                cmdUpdateUserEx.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdUpdateUserEx.Parameters.Add("U_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                clsDataLayer.ExecuteNonQuery(cmdUpdateUserEx);
            }
        }

        public void StoreNewId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdUpdateUserNew = new OracleCommand())
            {
                cmdUpdateUserNew.CommandText = "USER_REGISTERATION.SP_UPDATE_USER_NEW_ID";
                cmdUpdateUserNew.CommandType = CommandType.StoredProcedure;
                cmdUpdateUserNew.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                cmdUpdateUserNew.Parameters.Add("U_ID_MAIN", OracleDbType.Int32).Value = objEntityUsrReg.UserIdMain;
                cmdUpdateUserNew.Parameters.Add("U_NEWCODE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCodeNew;
                cmdUpdateUserNew.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUsrReg.UserTypeStatus;
                cmdUpdateUserNew.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdUpdateUserNew.Parameters.Add("U_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                clsDataLayer.ExecuteNonQuery(cmdUpdateUserNew);
            }
        }
        //end

        // This Method Updates the Status of User in the database
        public void UpdateStatus(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_UPDATE_GEN_USERS_ACTIVE";
            using (OracleCommand cmdUpdateStatus = new OracleCommand())
            {
                cmdUpdateStatus.CommandText = strCommandText;
                cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateStatus.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                cmdUpdateStatus.Parameters.Add("U_TYPE_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserTypeStatus;
                cmdUpdateStatus.Parameters.Add("U_UPD_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdUpdateStatus.Parameters.Add("U_UPD_DATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateStatus);
            }
        }
        //Read User master table according to their Id(Primary Key)
        public DataTable ReadUsrMasterEdit(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_USR_MASTER_BYID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                cmdReadDsgnEdit.Parameters.Add("U_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Method for updating User cancel details in gn_Designation master table.
        public void UpdateUsrCancel(clsEntityLayerUserRegistration objEntityUsrReg)
        {

            using (OracleCommand cmdupdateUsrCancel = new OracleCommand())
            {
                cmdupdateUsrCancel.InitialLONGFetchSize = 1000;
                cmdupdateUsrCancel.CommandText = "USER_REGISTERATION.SP_UPDATE_USER_CANCEL";
                cmdupdateUsrCancel.CommandType = CommandType.StoredProcedure;
                cmdupdateUsrCancel.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
                cmdupdateUsrCancel.Parameters.Add("U_CANCELID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdupdateUsrCancel.Parameters.Add("U_CANCELREASON", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCancelReason;
                cmdupdateUsrCancel.Parameters.Add("U_CANCELDATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;
                clsDataLayer.ExecuteNonQuery(cmdupdateUsrCancel);
            }
        }
        // This Method reads Corporate divisions based on corporate id's in the database 
        public DataTable ReadCrptDivisionsDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrprtDvsncDetails = new DataTable();
            using (OracleCommand cmdReadCrprtDivisions = new OracleCommand())
            {
                cmdReadCrprtDivisions.CommandText = "USER_REGISTERATION.SP_READ_CORP_DIVISIONS";
                cmdReadCrprtDivisions.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtDivisions.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdReadCrprtDivisions.Parameters.Add("U_DEPT_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtDept;
                cmdReadCrprtDivisions.Parameters.Add("U_CRPRT_DVSN_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCrprtDvsncDetails = clsDataLayer.SelectDataTable(cmdReadCrprtDivisions);
            }
            return dtCrprtDvsncDetails;
        }
        //005 START
        //FOR READING USER DETAILS
        public DataTable ReadUsrDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadUsrDetails = new OracleCommand())
            {
                cmdReadUsrDetails.CommandText = "USER_REGISTERATION.SP_READ_USER_DETAILS";
                cmdReadUsrDetails.CommandType = CommandType.StoredProcedure;
                cmdReadUsrDetails.Parameters.Add("U_USERID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdReadUsrDetails.Parameters.Add("U_USER_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadUsrDetails = new DataTable();
                dtReadUsrDetails = clsDataLayer.ExecuteReader(cmdReadUsrDetails);
                return dtReadUsrDetails;
            }
        }
        // This Method checks User Emp Code in the database for duplication
        public string CheckDupEmpCode(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckEmpCode = "USER_REGISTERATION.SP_CHECK_EMP_CODE";
            OracleCommand cmdCheckEmpCode = new OracleCommand();

            cmdCheckEmpCode.CommandText = strQueryCheckEmpCode;
            cmdCheckEmpCode.CommandType = CommandType.StoredProcedure;
            cmdCheckEmpCode.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdCheckEmpCode.Parameters.Add("U_USER_CODE", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCode;
            cmdCheckEmpCode.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckEmpCode.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckEmpCode);
            string strReturn = cmdCheckEmpCode.Parameters["U_COUNT"].Value.ToString();
            cmdCheckEmpCode.Dispose();
            return strReturn;

        }

        // This Method will fetch License Type details based on corporate and organization
        public DataTable ReadLicenseType(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadLicenseType = "USER_REGISTERATION.SP_READ_LICENSE_TYPE";
            OracleCommand cmdReadLicenseType = new OracleCommand();
            cmdReadLicenseType.CommandText = strQueryReadLicenseType;
            cmdReadLicenseType.CommandType = CommandType.StoredProcedure;
            cmdReadLicenseType.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdReadLicenseType.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
            cmdReadLicenseType.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdReadLicenseType.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadLicenseType);
            return dtResult;
        }


        // This Method will fetch Accommodation details based on corporate and organization
        public DataTable ReadAccommodationMstr(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadAccommodation = "USER_REGISTERATION.SP_READ_ACCOMMODATION";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdReadAccommodation.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
            cmdReadAccommodation.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        // This Method will fetch  Vehicle License Type Based on UserId.
        public DataTable ReadLicenseType_ByUsrId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadLicTyp = "USER_REGISTERATION.SP_RD_USRVHCLLICTYP_BY_USRID";
            OracleCommand cmdReadLicTyp = new OracleCommand();
            cmdReadLicTyp.CommandText = strQueryReadLicTyp;
            cmdReadLicTyp.CommandType = CommandType.StoredProcedure;
            cmdReadLicTyp.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdReadLicTyp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadLicTyp);
            return dtResult;
        }
        //0013
        //THIS METHOD IS FOR FETCHING JOB ROLE BY DESIGNATION ID
        public DataTable ReadJobRol(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadLicTyp = "USER_REGISTERATION.SP_READ_JOBROLE";
            OracleCommand cmdReadLicTyp = new OracleCommand();
            cmdReadLicTyp.CommandText = strQueryReadLicTyp;
            cmdReadLicTyp.CommandType = CommandType.StoredProcedure;
            cmdReadLicTyp.Parameters.Add("DESG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
            cmdReadLicTyp.Parameters.Add("O_ORGTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadLicTyp);
            return dtResult;
        }

        public DataTable ReadStaffWorkerBiDesgId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadLicTyp = "USER_REGISTERATION.SP_READ_STAFFWORKER_DESID";
            OracleCommand cmdReadLicTyp = new OracleCommand();
            cmdReadLicTyp.CommandText = strQueryReadLicTyp;
            cmdReadLicTyp.CommandType = CommandType.StoredProcedure;
            cmdReadLicTyp.Parameters.Add("DESG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
            cmdReadLicTyp.Parameters.Add("O_ORGTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadLicTyp);
            return dtResult;
        }
        
        //THIS METHOD IS FOR FETCHING SUB BUSSINESS UNIT BY MAIN BUSSINESS ID
        public DataTable ReadSubBusUnt(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadLicTyp = "USER_REGISTERATION.SP_READ_SUB_BUSNES";
            OracleCommand cmdReadLicTyp = new OracleCommand();
            cmdReadLicTyp.CommandText = strQueryReadLicTyp;
            cmdReadLicTyp.CommandType = CommandType.StoredProcedure;
            cmdReadLicTyp.Parameters.Add("CORP_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
            cmdReadLicTyp.Parameters.Add("O_ORGTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadLicTyp);
            return dtResult;
        }
        ////Read Desgnation master table according to their Id(Primary Key)
        //public DataTable ReadDsgnMasterEdit(clsEntityLayerUserRegistration objEntityUsrReg)
        //{
        //    using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
        //    {
        //        cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_DSGN_MASTER_BYID";
        //        cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
        //        cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
        //        cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtDsgnMasterEdit = new DataTable();
        //        dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
        //        return dtDsgnMasterEdit;
        //    }
        //}
        ////Read Desgnation APP Roles master table according to their Dsgn Id(Primary Key)
        //public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerUserRegistration objEntityUsrReg)
        //{
        //    using (OracleCommand cmdReadDsgnApp = new OracleCommand())
        //    {
        //        cmdReadDsgnApp.CommandText = "USER_REGISTERATION.SP_READ_DSGN_APPROLE_BY_DSGNID";
        //        cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
        //        cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
        //        cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtDsgnAppMasterEdit = new DataTable();
        //        dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
        //        return dtDsgnAppMasterEdit;
        //    }
        //}
        //Read ReadJobRl Roles table according to their Id(Primary Key)
        public DataTable ReadJobRlRoles(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_GN_JOBRL_ROLES_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserRoleId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Read Approles by ID
        public DataTable ReadJobRlAppRoles(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_GN_JOBRL_APPRL_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserRoleId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            string strCommandText = "JOB_ROLE.SP_RD_USR_IFLIMITED_BYUSRID";
            using (OracleCommand cmdUserDtl = new OracleCommand())
            {
                cmdUserDtl.CommandText = strCommandText;
                cmdUserDtl.CommandType = CommandType.StoredProcedure;
                cmdUserDtl.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdUserDtl.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispUserDtl = new DataTable();
                dtDispUserDtl = clsDataLayer.SelectDataTable(cmdUserDtl);
                return dtDispUserDtl;
            }
        }
        // This Method displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityLayerJobRole objEntityJobRl)
        {
            string strCommandText = "JOB_ROLE.SP_READ_USR_ROLE_MSTR";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityJobRl.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityJobRl.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityJobRl.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityJobRl.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityJobRl.UserLimited;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        //0013
        //this method for displaying sub business units in edit
        public DataTable ReadSubBuss(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_SUB_BUSI_UNIT";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdReadDsgnEdit.Parameters.Add("IN_CORP_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdReadDsgnEdit.Parameters.Add("IN_USER_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;

                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //evm-0024
        //Method for read nextid from database not incremented
        public DataTable ShowNextId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID_NOTINCREMENT";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEntityUsrReg.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }
        //end

        public DataTable ReadAcsCorpBy_Usr(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "USER_REGISTERATION.SP_READ_USR_ACS_CPRT_BYUSR";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("IN_USER_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }

        
        public DataTable ReadEmpnWelfareSrvc(clsEntityLayerUserRegistration objEntityUsrReg )   //EMP0025
        {
            string strCommandText = "USER_REGISTERATION.SP_READ_WELFARE_SERVICES";
            using (OracleCommand cmdWelfareSrvc = new OracleCommand())
            {
                cmdWelfareSrvc.CommandText = strCommandText;
                cmdWelfareSrvc.CommandType = CommandType.StoredProcedure;
                cmdWelfareSrvc.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdWelfareSrvc.Parameters.Add("D_DESGID", OracleDbType.Int32).Value = objEntityUsrReg.UserDsgnId;
                cmdWelfareSrvc.Parameters.Add("D_DEPTID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtDept;
                string s = objEntityUsrReg.UserDvsnId;
                //string[] values = s.Split(',');
                //for (int i = 0; i < values.Length; i++)
                //{
                //    values[i] = values[i].Trim();
                //}
                cmdWelfareSrvc.Parameters.Add("D_DSNID", OracleDbType.Varchar2).Value = objEntityUsrReg.UserDvsnId;
                cmdWelfareSrvc.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtWelfareScvc = new DataTable();
                dtWelfareScvc = clsDataLayer.SelectDataTable(cmdWelfareSrvc);
                return dtWelfareScvc;
            }
        }

        public DataTable ReadEmpnWelfare(clsEntityLayerEmployeeWelfareSrvc objEntityUsrReg)   //EMP0025
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_WELFARE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.Emp_Id;
                cmdwelfare.Parameters.Add("D_SUB_ID", OracleDbType.Varchar2).Value = objEntityUsrReg.WelfSub_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadEmpnWelfareDept(clsEntityLayerEmployeeWelfareSrvc objEntityUsrReg)   //EMP0025
        {
            string strCommandText = "USER_REGISTERATION.SP_READ_DEPTWELFARE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.Emp_Id;
                cmdwelfare.Parameters.Add("D_SUB_ID", OracleDbType.Varchar2).Value = objEntityUsrReg.Welfare_Id;
                cmdwelfare.Parameters.Add("D_DEPTID", OracleDbType.Varchar2).Value = objEntityUsrReg.DepId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadEmpnWelfareDesg(clsEntityLayerEmployeeWelfareSrvc objEntityUsrReg)   //EMP0025
        {
            string strCommandText = "USER_REGISTERATION.SP_READ_DESGWELFARE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityUsrReg.Emp_Id;
                cmdwelfare.Parameters.Add("D_SUB_ID", OracleDbType.Varchar2).Value = objEntityUsrReg.Welfare_Id;
                cmdwelfare.Parameters.Add("D_DESG_ID", OracleDbType.Varchar2).Value = objEntityUsrReg.DesgId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }

        public DataTable ReadDsgnWelfareById(clsEntityLayerEmployeeWelfareSrvc objEntityDeptnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_WELFARE_BYID";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDeptnWelfareSrvc.Welfare_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }


        public void Insert_EmpWelfare(List<clsEntityLayerEmployeeWelfareSrvc> objListEmpWelfare, clsEntityLayerEmployeeWelfareSrvc objEntityWelfareEmp)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                   
                                     
                        //EMP0025
                        foreach (clsEntityLayerEmployeeWelfareSrvc objEmp in objListEmpWelfare)
                        {
                            int chkSts = objEmp.chkSts;
                            int checkboxStatus = objEmp.checkboxsts;
                            if (checkboxStatus == 1)
                            {
                                if (chkSts == 0)
                                {
                                    string strQueryAddDesgWelfareSrvcLIST = "USER_REGISTERATION.SP_ADD_EMP_WELFARE";

                                    using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                    {
                                        cmdAddDesgWelfare.Transaction = tran;
                                        cmdAddDesgWelfare.Connection = con;
                                        cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvcLIST;
                                        cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                        cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmp.Emp_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityWelfareEmp.Welfare_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objEmp.Qty;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Int32).Value = objEmp.WelfrSub_Id;
                                        cmdAddDesgWelfare.ExecuteNonQuery();
                                    }



                                }
                                else
                                {

                                    string strQueryAddDesgWelfare = "USER_REGISTERATION.SP_UPDATE_EMP_WELFAREQTY";

                                    using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                    {
                                        cmdAddDesgWelfare.Transaction = tran;
                                        cmdAddDesgWelfare.Connection = con;
                                        cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfare;
                                        cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                        cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmp.Emp_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityWelfareEmp.Welfare_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objEmp.Qty;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Int32).Value = objEmp.WelfrSub_Id;
                                        cmdAddDesgWelfare.ExecuteNonQuery();
                                    }

                                }

                            }
                            else
                            {
                                if (chkSts == 0)
                                {
                                    string strQueryAddDesgWelfare = "USER_REGISTERATION.SP_ADD_EMP_WELFARECNCL";

                                    using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                    {
                                        cmdAddDesgWelfare.Transaction = tran;
                                        cmdAddDesgWelfare.Connection = con;
                                        cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfare;
                                        cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                        cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmp.Emp_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityWelfareEmp.Welfare_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objEmp.ActQty;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Int32).Value = objEmp.WelfrSub_Id;
                                        cmdAddDesgWelfare.ExecuteNonQuery();
                                    }

                                }
                                else
                                {
                                    string strQueryAddDesgWelfare = "USER_REGISTERATION.SP_UPDATE_EMP_WELFARECNCLDATE";

                                    using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                    {
                                        cmdAddDesgWelfare.Transaction = tran;
                                        cmdAddDesgWelfare.Connection = con;
                                        cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfare;
                                        cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                        cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmp.Emp_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityWelfareEmp.Welfare_Id;
                                        cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Int32).Value = objEmp.WelfrSub_Id;
                                        cmdAddDesgWelfare.ExecuteNonQuery();
                                    }

                                }
                            }
                        
                        }

                    
                        tran.Commit();
                        //return objEntityCorpdept.intDep_Id;
               
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }

        }

        public DataTable ReadReferenceFormatEmp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_EMPREF_FORMAT";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadCrprtSts(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_CORPORATE_STS";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public string CheckEmployeeCode(clsEntityLayerUserRegistration objEntityUsrReg)
        {

            string strQueryCheckCategoryName = "USER_REGISTERATION.SP_CHECK_EMPLOYEE_CODE";
            OracleCommand cmdCheckCategoryName = new OracleCommand();
            cmdCheckCategoryName.CommandText = strQueryCheckCategoryName;
            cmdCheckCategoryName.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityUsrReg.UsrRegistrationId;
            cmdCheckCategoryName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityUsrReg.UserCode;
            cmdCheckCategoryName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
            cmdCheckCategoryName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckCategoryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryName);
            string strReturn = cmdCheckCategoryName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCategoryName.Dispose();
            return strReturn;
        }

        //public DataTable ReadLeaveTypeByPayGrade(clsEntityLayerUserRegistration objEntityUsrReg)
        //{
        //    string strCommandText = "USER_REGISTERATION.SP_RD_LV_TYPE_PAYGD";
        //    using (OracleCommand cmdwelfare = new OracleCommand())
        //    {
        //        cmdwelfare.CommandText = strCommandText;
        //        cmdwelfare.CommandType = CommandType.StoredProcedure;
        //        cmdwelfare.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.Paygr;
        //        cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtDispwelfare = new DataTable();
        //        dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
        //        return dtDispwelfare;
        //    }
        //}
        //public DataTable ReadLeaveTypeByExperience(clsEntityLayerUserRegistration objEntityUsrReg)
        //{
        //    string strCommandText = "USER_REGISTERATION.SP_RD_LV_TYPE_EXP";
        //    using (OracleCommand cmdwelfare = new OracleCommand())
        //    {
        //        cmdwelfare.CommandText = strCommandText;
        //        cmdwelfare.CommandType = CommandType.StoredProcedure;
        //        cmdwelfare.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
        //        cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtDispwelfare = new DataTable();
        //        dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
        //        return dtDispwelfare;
        //    }
        //}
        public DataTable ReadBusUnits(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_BUS_UNIT";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadDept(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_DEPT";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                if(objEntityUsrReg.Fname.Trim()!="")
                cmdwelfare.Parameters.Add("D_BUIDS", OracleDbType.Varchar2).Value = objEntityUsrReg.Fname;
                else
                cmdwelfare.Parameters.Add("D_BUIDS", OracleDbType.Varchar2).Value = DBNull.Value;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadExportData(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_EXPORT_DATA";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                if(objEntityUsrReg.Fname.Trim()!="")
                cmdwelfare.Parameters.Add("D_BU_IDS", OracleDbType.Varchar2).Value = objEntityUsrReg.Fname;
                else
                cmdwelfare.Parameters.Add("D_BU_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
                if (objEntityUsrReg.ImagePath.Trim() != "")
                cmdwelfare.Parameters.Add("D_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityUsrReg.ImagePath;
                else
                cmdwelfare.Parameters.Add("D_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
                cmdwelfare.Parameters.Add("D_EMP_TYPE", OracleDbType.Int32).Value = objEntityUsrReg.EmployeeTypId;
                cmdwelfare.Parameters.Add("D_STS_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserStatus;
                cmdwelfare.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadAddDed(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_ADD_DED";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                if (objEntityUsrReg.Fname.Trim() != "")
                cmdwelfare.Parameters.Add("D_BU_IDS", OracleDbType.Varchar2).Value = objEntityUsrReg.Fname;
                else
                cmdwelfare.Parameters.Add("D_BU_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadAddDedEmp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_ADD_DED_EMP";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdwelfare.Parameters.Add("D_ADD_DED", OracleDbType.Varchar2).Value = objEntityUsrReg.UserName;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadAddDedEmpDate(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCommandText = "USER_REGISTERATION.SP_RD_ADD_DED_EMP_DATE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
    }
   
}
