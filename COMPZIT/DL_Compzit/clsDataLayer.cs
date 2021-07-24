using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit;
using HashingUtility;

// CREATED BY:EVM-0001
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer class that will be called everytime whenever there is actiivty with the database.
namespace DL_Compzit
{

    public class clsDataLayer
    {

        // when called ths method returns the connection string
        public static string GetConnectionString()
        {
            clsPassword objPwd = new clsPassword();
            string strPassword = objPwd.getOraclePassword();
            Int32 intConnectionLifeTime = 3600; // This is the connection Life Time in Seconds for the Connection Objects.
            Int32 intStmntCache = 100; // This is the Number of Statements to be Cache.
            string strConn = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString + "Password=" + strPassword + ";"
                + "Connection Lifetime = " + intConnectionLifeTime + "; Statement Cache Size = " + intStmntCache + ";";
            return strConn;

        }
        // Called when you want to perform an insert , update or delete operation
        public static void ExecuteNonQuery(OracleCommand cmdExecNonQuery)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                using (cmdExecNonQuery)
                {
                    try
                    {
                        cmdExecNonQuery.Transaction = tran;
                        cmdExecNonQuery.Connection = con;
                        cmdExecNonQuery.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
        }

        // This method returns multiple data to the user when called by returning a DataTable
        public static DataTable SelectDataTable(OracleCommand cmdSelDataTable)
        {
            DataTable dtDataLayer = new DataTable();
            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                using (OracleDataAdapter daDataLayer = new OracleDataAdapter(cmdSelDataTable))
                {
                    cmdSelDataTable.Connection = con;
                    daDataLayer.Fill(dtDataLayer);
                }
                return dtDataLayer;
            }
        }

        //Used when the query return more than a single value.For example,if the query returns rows of data 
        public static DataTable ExecuteReader(OracleCommand cmdExeReader)
        {
            DataTable dtDataLayer = new DataTable();
            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                using (cmdExeReader)
                {
                    cmdExeReader.Connection = con;
                    con.Open();
                    using (OracleDataReader dr = cmdExeReader.ExecuteReader())
                    {
                        dtDataLayer.Load(dr);
                    }
                    return dtDataLayer;
                }
            }
        }
        //Called when the query returns a single(scalar) value. For eg.queries that return the total number of rows in a table
        public static void ExecuteScalar(ref OracleCommand cmdExeScalar)
        {

            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                cmdExeScalar.Connection = con;
                con.Open();
                cmdExeScalar.ExecuteScalar();
                con.Close();
            }
        }
        // This method returns multiple data to the user when called by returning a DataSet
        public static DataSet SelectDataSet(OracleCommand cmdSelDataSet)
        {
            DataSet dsDataLayer = new DataSet();
            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                using (OracleDataAdapter daDataLayer = new OracleDataAdapter(cmdSelDataSet))
                {
                    cmdSelDataSet.Connection = con;
                    daDataLayer.Fill(dsDataLayer);
                }
                return dsDataLayer;
            }
        }
        // Called when you want to perform an insert , update or delete operation with reference
        public static void ExecuteNonQueryByref(ref OracleCommand cmdExeNonQueryByRef)
        {
            using (OracleConnection con = new OracleConnection(GetConnectionString()))
            {
                con.Open();
                try
                {
                    cmdExeNonQueryByRef.Connection = con;
                    cmdExeNonQueryByRef.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        // function to load menu according to designation id of user and his user role status 
        public DataTable LoadmenuDB(clsEntityLayerLogin objMenu)
        {
            string strCommandText = "LOAD_LOGIN.SP_READ_MENU";
            using (OracleCommand cmdMenu = new OracleCommand())
            {
                cmdMenu.CommandText = strCommandText;
                cmdMenu.CommandType = CommandType.StoredProcedure;
                cmdMenu.Parameters.Add("U_ID", OracleDbType.Int32).Value = objMenu.UserIdInt;
                cmdMenu.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objMenu.AppType;
                cmdMenu.Parameters.Add("M_PRTZAAPP_ID", OracleDbType.Char).Value = objMenu.Cmp_AppId;
                cmdMenu.Parameters.Add("M_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmdMenu.Parameters.Add("M_FRAMEWRK_TYP", OracleDbType.Int32).Value = objMenu.FrameworkTypId;
                cmdMenu.Parameters.Add("M_FRAMEWRK_ID", OracleDbType.Int32).Value = objMenu.FrameworkId;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdMenu);
                return dtGridDisp;
            }
        }
        // function to load Config Details
        public DataTable LoadConfigDetail()
        {
            string strCommandText = "COMMON.SP_READ_CONFIG_DETAIL";
            using (OracleCommand cmdConfig = new OracleCommand())
            {
                cmdConfig.CommandText = strCommandText;
                cmdConfig.CommandType = CommandType.StoredProcedure;
                cmdConfig.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCnfig = new DataTable();
                dtCnfig = SelectDataTable(cmdConfig);
                return dtCnfig;
            }
        }
        // function to load Child menu according to userole id and  user role status 
        public DataTable LoadChildMenuDB(clsEntityLayerLogin objMenu)
        {
            string strCommandText = "LOAD_LOGIN.SP_READ_CHILDMENU_BY_USROL_ID";
            using (OracleCommand cmdMenu = new OracleCommand())
            {
                cmdMenu.CommandText = strCommandText;
                cmdMenu.CommandType = CommandType.StoredProcedure;
                cmdMenu.Parameters.Add("U_ID", OracleDbType.Int32).Value = objMenu.UserIdInt;
                cmdMenu.Parameters.Add("M_USROLID", OracleDbType.Int32).Value = objMenu.UsroleId;
                cmdMenu.Parameters.Add("M_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdMenu);
                return dtGridDisp;
            }
        }


        // function to load Global details of a corpoarte 
        public DataTable LoadGlobalDetail(string strColumnNames, int intCorprtId = 0)
        {

            string strCommandText = "COMMON.SP_READ_DEFAULT_BY_CORPTID";
            using (OracleCommand cmdGlobal = new OracleCommand())
            {
                cmdGlobal.CommandText = strCommandText;
                cmdGlobal.CommandType = CommandType.StoredProcedure;
                cmdGlobal.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = intCorprtId;
                cmdGlobal.Parameters.Add("D_COLOUMNS", OracleDbType.Varchar2).Value = strColumnNames;
                cmdGlobal.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdGlobal);
                return dtGridDisp;
            }



        }
        // function to load sub Global details of a corpoarte 
        public DataTable Load_Sub_GlobalDetail(string strColumnNames, int intCorprtId = 0)
        {

            string strCommandText = "COMMON.SP_READ_SUB_DEFAULT_BY_CORPTID";
            using (OracleCommand cmdGlobal = new OracleCommand())
            {
                cmdGlobal.CommandText = strCommandText;
                cmdGlobal.CommandType = CommandType.StoredProcedure;
                cmdGlobal.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = intCorprtId;
                cmdGlobal.Parameters.Add("D_COLOUMNS", OracleDbType.Varchar2).Value = strColumnNames;
                cmdGlobal.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdGlobal);
                return dtGridDisp;
            }



        }
        // function to load Company details of a corpoarte 
        public DataTable LoadCompanyDetail(string strColumnNames)
        {
            string strCommandText = "COMMON.SP_READ_COMPANY";
            using (OracleCommand cmdCompany = new OracleCommand())
            {
                cmdCompany.CommandText = strCommandText;
                cmdCompany.CommandType = CommandType.StoredProcedure;
                cmdCompany.Parameters.Add("D_COLOUMNS", OracleDbType.Varchar2).Value = strColumnNames;
                cmdCompany.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdCompany);
                return dtGridDisp;
            }
        }

        //fetching ref number from ref next id table in database according the corp office id and section id for web as entity global is static
        public string ReadRefNumberWeb(clsEntityCommon objEntCommon, OracleTransaction tran = null, OracleConnection con = null, int intTaxId = 0)
        {
            string strCommandText = "COMMON.SP_READ_REFNUMBER";
            OracleCommand cmdCommn = new OracleCommand(strCommandText, con);


            cmdCommn.CommandType = CommandType.StoredProcedure;
            cmdCommn.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdCommn.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdCommn.Parameters.Add("R_AREAID", OracleDbType.Int32).Value = objEntCommon.WrkAreaId;
            cmdCommn.Parameters.Add("R_REFNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
            // clsDataLayer.ExecuteScalar(ref cmdGlobal);
            cmdCommn.ExecuteScalar();
            string strReturn = cmdCommn.Parameters["R_REFNUMBER"].Value.ToString();
            cmdCommn.Dispose();
            return strReturn;

        }
        //fetching stock id prefix for generate/identify barcode that generate through stock id
        public DataTable ReadStockIdPreference()
        {
            string strCommandReadStkIdPreference = "COMMON.SP_READ_STKID_PREFIX";
            OracleCommand cmdReadStkPrefence = new OracleCommand();
            cmdReadStkPrefence.CommandText = strCommandReadStkIdPreference;
            cmdReadStkPrefence.CommandType = CommandType.StoredProcedure;
            cmdReadStkPrefence.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtOut = new DataTable();
            dtOut = SelectDataTable(cmdReadStkPrefence);
            return dtOut;

        }

        //fetching ref number from ref next id table in database according the corp office id and section id Without updating on web as entity global is static
        public string ReadRefNumberOnlyWeb(clsEntityCommon objEntCommon)
        {
            string strCommandText = "COMMON.SP_READONLY_REFNUMBER";
            OracleCommand cmdGlobal = new OracleCommand();

            cmdGlobal.CommandText = strCommandText;
            cmdGlobal.CommandType = CommandType.StoredProcedure;
            cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdGlobal.Parameters.Add("R_AREAID", OracleDbType.Int32).Value = objEntCommon.WrkAreaId;
            cmdGlobal.Parameters.Add("R_REFNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdGlobal);
            string strReturn = cmdGlobal.Parameters["R_REFNUMBER"].Value.ToString();
            cmdGlobal.Dispose();
            return strReturn;

        }



        //fetching ref number from ref next id table in database according the corp office id and section id Without updating on web as entity global is static
        public string ReadNextNumber(clsEntityCommon objEntCommon)
        {
            string strCommandText = "COMMON.SP_READONLY_NEXT_NUMBER";
            OracleCommand cmdGlobal = new OracleCommand();

            cmdGlobal.CommandText = strCommandText;
            cmdGlobal.CommandType = CommandType.StoredProcedure;
            cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdGlobal.Parameters.Add("R_REFNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdGlobal);
            string strReturn = cmdGlobal.Parameters["R_REFNUMBER"].Value.ToString();
            cmdGlobal.Dispose();
            return strReturn;

        }

        //fetching NEXTID from primary key next id table in database according the corp office id and section id FOR USING IN WEB AS ENITY GLOBAL IS STATIC
        public string ReadNextNumberWeb(clsEntityCommon objEntCommon, OracleTransaction tran = null, OracleConnection con = null)
        {
            string strReturn = "";
            string strCommandText = "COMMON.SP_READ_NEXT_NUMBER";
            if (con != null)
            {
                using (OracleCommand cmdGlobal = new OracleCommand(strCommandText, con))
                {
                    cmdGlobal.Transaction = tran;

                    cmdGlobal.CommandType = CommandType.StoredProcedure;
                    cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
                    cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
                    cmdGlobal.Parameters.Add("R_NEXTNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
                    cmdGlobal.ExecuteScalar();
                    //  clsDataLayer.ExecuteScalar();
                    strReturn = cmdGlobal.Parameters["R_NEXTNUMBER"].Value.ToString();
                }
            }
            else
            {
                using (OracleConnection con1 = new OracleConnection(GetConnectionString()))
                {
                    con1.Open();
                    using (OracleCommand cmdGlobal = new OracleCommand(strCommandText, con1))
                    {
                        cmdGlobal.CommandType = CommandType.StoredProcedure;
                        cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
                        cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
                        cmdGlobal.Parameters.Add("R_NEXTNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
                        cmdGlobal.ExecuteScalar();
                        //  clsDataLayer.ExecuteScalar();
                        strReturn = cmdGlobal.Parameters["R_NEXTNUMBER"].Value.ToString();

                    }
                }
            }


            return strReturn;
        }
        //fetching NEXTID from primary key next id table in database according the corp office id and section id FOR USING IN WEB AS ENITY GLOBAL IS STATIC
        public string ReadNextNumberWebForUI(clsEntityCommon objEntCommon)
        {
            string StrReturnNxtId = ReadNextNumberWeb(objEntCommon);
            return StrReturnNxtId;
        }

        // This Method checks the current unit is breakable or not
        public string CheckUnit(clsEntityCommon objEntityCommon)
        {
            string strQueryCheckunit = "COMMON.SP_CHECK_BREAKABLE_UNIT";
            OracleCommand cmdCheckunit = new OracleCommand();
            cmdCheckunit.CommandText = strQueryCheckunit;
            cmdCheckunit.CommandType = CommandType.StoredProcedure;
            cmdCheckunit.Parameters.Add("O_UNITID", OracleDbType.Int32).Value = objEntityCommon.UOM_Id;
            cmdCheckunit.Parameters.Add("O_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckunit);
            string strReturn = cmdCheckunit.Parameters["O_OUT"].Value.ToString();
            cmdCheckunit.Dispose();
            return strReturn;
        }



        // function to load Child role definition of a user based on usrolMstrId 
        public DataTable LoadChildRoleDefnDetail(int intUserId, int intUsrolMstrId)
        {
            string strCommandText = "COMMON.SP_READ_CHILD_ROLE_DEFINITION";
            using (OracleCommand cmdChildDefn = new OracleCommand())
            {
                cmdChildDefn.CommandText = strCommandText;
                cmdChildDefn.CommandType = CommandType.StoredProcedure;
                cmdChildDefn.Parameters.Add("C_USERID", OracleDbType.Int32).Value = intUserId;
                cmdChildDefn.Parameters.Add("C_USROLID", OracleDbType.Int32).Value = intUsrolMstrId;
                cmdChildDefn.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtChildDef = new DataTable();
                dtChildDef = SelectDataTable(cmdChildDefn);
                return dtChildDef;
            }
        }
        // function to load usrolMstrId of a user based on usrId 
        public DataTable LoadUserRolMstrIdByUserId(int intUserId)
        {
            string strCommandText = "COMMON.SP_READ_USROLID_BY_USRID";
            using (OracleCommand cmdUserMasterDtl = new OracleCommand())
            {
                cmdUserMasterDtl.CommandText = strCommandText;
                cmdUserMasterDtl.CommandType = CommandType.StoredProcedure;
                cmdUserMasterDtl.Parameters.Add("C_USERID", OracleDbType.Int32).Value = intUserId;
                cmdUserMasterDtl.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUserMasterDtl = new DataTable();
                dtUserMasterDtl = SelectDataTable(cmdUserMasterDtl);
                return dtUserMasterDtl;
            }
        }

        // function to fetch Finacial Year start date and end date based on Financial year Id.
        public DataTable LoadFincyrDetail(int intFinanceYearId)
        {
            string strCommandText = "COMMON.SP_READ_FINCYR_START_END_DATE";
            using (OracleCommand cmdFyrDtl = new OracleCommand())
            {
                cmdFyrDtl.CommandText = strCommandText;
                cmdFyrDtl.CommandType = CommandType.StoredProcedure;
                cmdFyrDtl.Parameters.Add("C_FCYRID", OracleDbType.Int32).Value = intFinanceYearId;
                cmdFyrDtl.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtFyr = new DataTable();
                dtFyr = SelectDataTable(cmdFyrDtl);
                return dtFyr;
            }
        }

        // function to read divisions of a user based on usrId 
        public DataTable ReadDivisionsOfUser(int intUserId, int intOrgId)
        {
            string strCommandText = "COMMON.SP_READ_DIVSN_BY_USR_ID";
            using (OracleCommand cmdDivisions = new OracleCommand())
            {
                cmdDivisions.CommandText = strCommandText;
                cmdDivisions.CommandType = CommandType.StoredProcedure;
                cmdDivisions.Parameters.Add("C_USERID", OracleDbType.Int32).Value = intUserId;
                cmdDivisions.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = intOrgId;
                cmdDivisions.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDivisionsDtl = new DataTable();
                dtDivisionsDtl = SelectDataTable(cmdDivisions);
                return dtDivisionsDtl;
            }
        }

        //fetch lead status based on lead id
        public DataTable ReadLeadStatus(clsEntityLeadCreation ObjEntityLead)
        {
            string strCommandText = "COMMON.SP_FETCH_LEAD_STATUS";
            using (OracleCommand cmdLeadStatus = new OracleCommand())
            {
                cmdLeadStatus.CommandText = strCommandText;
                cmdLeadStatus.CommandType = CommandType.StoredProcedure;
                cmdLeadStatus.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = ObjEntityLead.LeadId;
                cmdLeadStatus.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadStatus = new DataTable();
                dtLeadStatus = SelectDataTable(cmdLeadStatus);
                return dtLeadStatus;
            }
        }

        //fetch all active Quotation Template
        public DataTable ReadQuotationTempalate()
        {
            string strCommandText = "COMMON.SP_READ_QTN_TEMPLATE";
            using (OracleCommand cmdQtnTemplate = new OracleCommand())
            {
                cmdQtnTemplate.CommandText = strCommandText;
                cmdQtnTemplate.CommandType = CommandType.StoredProcedure;
                cmdQtnTemplate.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtTmplt = new DataTable();
                dtTmplt = SelectDataTable(cmdQtnTemplate);
                return dtTmplt;
            }
        }
        //TO READ TEAM NAME BY TEAM ID
        public DataTable ReadTeamById(clsEntityLeadCreation ObjEntityLead)
        {
            string strCommandText = "COMMON.SP_READ_TEAM_BY_ID";
            using (OracleCommand cmdLeadStatus = new OracleCommand())
            {
                cmdLeadStatus.CommandText = strCommandText;
                cmdLeadStatus.CommandType = CommandType.StoredProcedure;
                cmdLeadStatus.Parameters.Add("L_TEAMID", OracleDbType.Int32).Value = ObjEntityLead.Team;
                cmdLeadStatus.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtTeamName = new DataTable();
                dtTeamName = SelectDataTable(cmdLeadStatus);
                return dtTeamName;
            }
        }

        //fetch send mail details using user corporate id //for no mail send
        public DataTable ReadFromMailDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryReadFromMail = "COMMON.SP_FETCH_FROM_MAIL";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("C_USER_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.UserCrprtId;
            cmdReadFromMail.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }


        //fetch currency details using currency id
        public DataTable ReadCurrencyDetailsById(clsEntityCommon objEntityCommon)
        {
            string strQueryReadCurrency = "COMMON.SP_FETCH_CURRENCY_DTL";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadCurrency;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("C_CURRENCY_ID", OracleDbType.Int32).Value = objEntityCommon.CurrencyId;
            cmdReadCurrency.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtReadFromMail;
        }
        //fetch reference number generalization format corp divisions
        public DataTable ReadReferenceFormat(clsEntityCommon objEntityCommon)
        {
            string strQueryReadReference = "COMMON.SP_FETCH_REFERENCE_FORMAT";
            OracleCommand cmdReadReference = new OracleCommand();
            cmdReadReference.CommandText = strQueryReadReference;
            cmdReadReference.CommandType = CommandType.StoredProcedure;
            cmdReadReference.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadReference.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadReference.Parameters.Add("C_CORP_DIV_ID", OracleDbType.Varchar2).Value = objEntityCommon.CorporateDivId;
            cmdReadReference.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadReference);
            return dtReadFromMail;
        }

        //Read User APP Roles master table according to their User Id(Primary Key)
        public DataTable ReadUserAppRoleByUserId(int intUserId)
        {
            using (OracleCommand cmdReadUsrApp = new OracleCommand())
            {
                cmdReadUsrApp.CommandText = "COMMON.SP_READ_USER_APPROLE_BY_USERID";
                cmdReadUsrApp.CommandType = CommandType.StoredProcedure;
                cmdReadUsrApp.Parameters.Add("U_ID", OracleDbType.Int32).Value = intUserId;
                cmdReadUsrApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUsrAppMasterEdit = new DataTable();
                dtUsrAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadUsrApp);
                return dtUsrAppMasterEdit;
            }
        }

        // function to load Child role definition of a DSGN based on usrolMstrId and to check if a Userol menu is present in Dsgn or not  
        public DataTable LoadDsgnRoleDetail(int intDsgnId, int intUsrolMstrId)
        {
            string strCommandText = "COMMON.SP_READ_DSGN_ROLE_DTLS";
            using (OracleCommand cmdChildDefn = new OracleCommand())
            {
                cmdChildDefn.CommandText = strCommandText;
                cmdChildDefn.CommandType = CommandType.StoredProcedure;
                cmdChildDefn.Parameters.Add("C_DSGNID", OracleDbType.Int32).Value = intDsgnId;
                cmdChildDefn.Parameters.Add("C_USROLID", OracleDbType.Int32).Value = intUsrolMstrId;
                cmdChildDefn.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtChildDef = new DataTable();
                dtChildDef = SelectDataTable(cmdChildDefn);
                return dtChildDef;
            }
        }
        //Read Active User types from User type Master
        public DataTable ReadUserTypeMaster()
        {
            using (OracleCommand cmdReadUsrTyp = new OracleCommand())
            {
                cmdReadUsrTyp.CommandText = "COMMON.SP_READ_USERTYPE_MSTR";
                cmdReadUsrTyp.CommandType = CommandType.StoredProcedure;
                cmdReadUsrTyp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUsrTyp = new DataTable();
                dtUsrTyp = SelectDataTable(cmdReadUsrTyp);
                return dtUsrTyp;
            }
        }

        //fetch reference number generalization format corp divisions
        public DataTable ReadGeneralLabelName(clsEntityCommon objEntityCommon)
        {
            string strQueryReadLabelName = "COMMON.SP_READ_COMMON_LBL_NAMES";
            OracleCommand cmdReadLabelName = new OracleCommand();
            cmdReadLabelName.CommandText = strQueryReadLabelName;
            cmdReadLabelName.CommandType = CommandType.StoredProcedure;
            cmdReadLabelName.Parameters.Add("APPMDSCT_ID", OracleDbType.Int32).Value = objEntityCommon.SectionId;
            cmdReadLabelName.Parameters.Add("CMNLBL_FIELD", OracleDbType.Varchar2).Value = objEntityCommon.CommonLabelFieldName;
            cmdReadLabelName.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadLabelName.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadLabelName.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadlabel = new DataTable();
            dtReadlabel = clsDataLayer.ExecuteReader(cmdReadLabelName);
            return dtReadlabel;
        }
        //fetch employee list for dropdownlist
        public DataTable ReadEmployeeDtl(clsEntityCommon objEntityCommon)
        {
            string strQueryReadEmploy = "COMMON.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        // function to read active financial year 
        public DataTable ReadFinancialYear(clsEntityCommon objfms)
        {
            string strCommandText = "COMMON.SP_READ_ACT_FISCALYR";
            using (OracleCommand cmdfms = new OracleCommand())
            {
                cmdfms.CommandText = strCommandText;
                cmdfms.CommandType = CommandType.StoredProcedure;
                cmdfms.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objfms.Organisation_Id;
                cmdfms.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objfms.CorporateID;
                cmdfms.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdfms);
                return dtGridDisp;
            }
        }
        // function to read last closing date
        public DataTable ReadAccountClsDate(clsEntityCommon objfms)
        {
            string strCommandText = "FMS_COMMON.SP_READ_CLOSED_DATE";
            using (OracleCommand cmdfms = new OracleCommand())
            {
                cmdfms.CommandText = strCommandText;
                cmdfms.CommandType = CommandType.StoredProcedure;
                cmdfms.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objfms.Organisation_Id;
                cmdfms.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objfms.CorporateID;
                cmdfms.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdfms);
                return dtGridDisp;
            }
        }

        // function to read last closing date
        public DataTable ReadLastAuditClose(clsEntityCommon objfms)
        {
            string strCommandText = "FMS_COMMON.SP_READ_AUDIT_CLOSED_DATE";
            using (OracleCommand cmdfms = new OracleCommand())
            {
                cmdfms.CommandText = strCommandText;
                cmdfms.CommandType = CommandType.StoredProcedure;
                cmdfms.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objfms.Organisation_Id;
                cmdfms.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objfms.CorporateID;
                cmdfms.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdfms);
                return dtGridDisp;
            }
        }
        public string ReadNextNumberSequanceWeb(clsEntityCommon objEntCommon, OracleTransaction tran = null, OracleConnection con = null)
        {
            string strReturn = "";
            string strCommandText = "COMMON.SP_READ_NEXT_NUMBER_FOR_CODE";
            if (con != null)
            {
                using (OracleCommand cmdGlobal = new OracleCommand(strCommandText, con))
                {
                    cmdGlobal.Transaction = tran;

                    cmdGlobal.CommandType = CommandType.StoredProcedure;
                    cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
                    cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
                    cmdGlobal.Parameters.Add("R_NEXTNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
                    cmdGlobal.ExecuteScalar();
                    //  clsDataLayer.ExecuteScalar();
                    strReturn = cmdGlobal.Parameters["R_NEXTNUMBER"].Value.ToString();
                }
            }
            else
            {
                using (OracleConnection con1 = new OracleConnection(GetConnectionString()))
                {
                    con1.Open();
                    using (OracleCommand cmdGlobal = new OracleCommand(strCommandText, con1))
                    {
                        cmdGlobal.CommandType = CommandType.StoredProcedure;
                        cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
                        cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
                        cmdGlobal.Parameters.Add("R_NEXTNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
                        cmdGlobal.ExecuteScalar();
                        strReturn = cmdGlobal.Parameters["R_NEXTNUMBER"].Value.ToString();

                    }
                }
            }


            return strReturn;
        }
        //fetching NEXTID from primary key next id table in database according the corp office id and section id FOR USING IN WEB AS ENITY GLOBAL IS STATIC
        public string ReadNextNumberSequanceForUI(clsEntityCommon objEntCommon)
        {
            string StrReturnNxtId = ReadNextNumberSequanceWeb(objEntCommon);
            return StrReturnNxtId;
        }


        public string ReadNextSequence(clsEntityCommon objEntCommon)
        {
            string strCommandText = "COMMON.SP_READONLY_NEXT_SEQUANCE";
            OracleCommand cmdGlobal = new OracleCommand();

            cmdGlobal.CommandText = strCommandText;
            cmdGlobal.CommandType = CommandType.StoredProcedure;
            cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdGlobal.Parameters.Add("R_REFNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdGlobal);
            string strReturn = cmdGlobal.Parameters["R_REFNUMBER"].Value.ToString();
            cmdGlobal.Dispose();
            return strReturn;

        }

        public DataTable ReadCodeFormate(clsEntityCommon objfms)
        {
            string strCommandText = "FMS_COMMON.SP_READ_CODE_FORMAT";
            using (OracleCommand cmdfms = new OracleCommand())
            {
                cmdfms.CommandText = strCommandText;
                cmdfms.CommandType = CommandType.StoredProcedure;
                cmdfms.Parameters.Add("F_APPMSC_ID", OracleDbType.Int32).Value = objfms.SectionId;
                cmdfms.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objfms.CorporateID;
                cmdfms.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdfms);
                return dtGridDisp;
            }
        }
        // function to read active financial year 
        public DataTable ReadFinancialYearById(clsEntityCommon objfms)
        {
            string strCommandText = "COMMON.SP_READ_ACT_FISCALYR_BYID";
            using (OracleCommand cmdfms = new OracleCommand())
            {
                cmdfms.CommandText = strCommandText;
                cmdfms.CommandType = CommandType.StoredProcedure;
                cmdfms.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objfms.Organisation_Id;
                cmdfms.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objfms.CorporateID;
                cmdfms.Parameters.Add("F_YRID", OracleDbType.Int32).Value = objfms.FinancialYrId;
                cmdfms.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                DataTable dtGridDisp = new DataTable();
                dtGridDisp = SelectDataTable(cmdfms);
                return dtGridDisp;
            }
        }
        public DataTable ReadPrintVersion(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_COMMON.SP_READ_DEFLT_PRINT_VERSION";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("R_VOUCHAR_TYPE", OracleDbType.Int32).Value = ObjEntitySales.Vouchar_Type;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadBankDetails(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_COMMON.SP_READ_BANK_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadAccountGrps(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_COMMON.SP_READ_ACCOUNT_GROUP";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_Id;
            cmdReadCustomerLdger.Parameters.Add("R_PRMRYGRPID", OracleDbType.Varchar2).Value = ObjEntitySales.PrimaryGrpIds;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadLedgers(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_COMMON.SP_READ_LEDGER";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_Id;
            cmdReadCustomerLdger.Parameters.Add("R_PRMRYGRPID", OracleDbType.Varchar2).Value = ObjEntitySales.PrimaryGrpIds;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadCorpDetails(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "COMMON.SP_READ_CORP_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadAppDetails(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "COMMON.SP_READ_APP_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_APPID", OracleDbType.Int32).Value = ObjEntitySales.SectionId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable CheckLastSalProcess(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "COMMON.SP_LAST_SAL_PROCESS_DATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_USERID", OracleDbType.Int32).Value = ObjEntitySales.UserId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        //read all employees with autocompletion (with search string)
        public DataTable ReadEmployees(clsEntityCommon objEntityCommon)
        {
            string strQueryReadEmploy = "COMMON.SP_READ_EMPLOYEE_LIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadEmp.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadEmp.Parameters.Add("M_NAME", OracleDbType.Varchar2).Value = objEntityCommon.Searchstring;
            cmdReadEmp.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        public DataTable ReadYearEndCloseDate(clsEntityCommon objEntityCommon)
        {
            string strQueryReadCustomerLdger = "FMS_COMMON.SP_CHECK_YEAREND_CLSDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadCustomerLdger.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("P_FISCALID", OracleDbType.Varchar2).Value = objEntityCommon.FinancialYrId;
            cmdReadCustomerLdger.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        //evm 0044

        public DataTable ReadDefaultModValues(clsEntityCommon objEntityCommon)
        {
            string strQueryReadDfaultValues = "FMS_COMMON.SP_READ_DEFLT_MODSETTINGS";
            OracleCommand cmdReadDfaultValues = new OracleCommand();
            cmdReadDfaultValues.CommandText = strQueryReadDfaultValues;
            cmdReadDfaultValues.CommandType = CommandType.StoredProcedure;
            cmdReadDfaultValues.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadDfaultValues.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadDfaultValues.Parameters.Add("R_ID", OracleDbType.Varchar2).Value = objEntityCommon.DefaultModId;
            cmdReadDfaultValues.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadDfaultValues);
            return dtCustomerLdger;
        }
        public string ReadNextNumberOnly(clsEntityCommon objEntCommon)
        {
            string strCommandText = "COMMON.SP_READ_NEXT_NUMBERONLY";
            OracleCommand cmdGlobal = new OracleCommand();

            cmdGlobal.CommandText = strCommandText;
            cmdGlobal.CommandType = CommandType.StoredProcedure;
            cmdGlobal.Parameters.Add("R_SECTIONID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdGlobal.Parameters.Add("R_REFNUMBER", OracleDbType.Int64).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdGlobal);
            string strReturn = cmdGlobal.Parameters["R_REFNUMBER"].Value.ToString();
            cmdGlobal.Dispose();
            return strReturn;

        }
        //--------------------

        public DataTable ReadCurrency(clsEntityCommon objEntCommon)
        {
            string strQueryReadRcpt = "COMMON.SP_READ_CURRENCY";
            OracleCommand cmdGlobal = new OracleCommand();
            cmdGlobal.CommandText = strQueryReadRcpt;
            cmdGlobal.CommandType = CommandType.StoredProcedure;
            cmdGlobal.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntCommon.Organisation_Id;
            cmdGlobal.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdGlobal.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdGlobal);
            return dt;
        }

        public DataTable ReadRefFormat(clsEntityCommon objEntCommon)
        {
            string strQueryRead = "COMMON.SP_READ_REFERENCENO_FORMAT";
            OracleCommand cmdRead = new OracleCommand();
            cmdRead.CommandText = strQueryRead;
            cmdRead.CommandType = CommandType.StoredProcedure;
            cmdRead.Parameters.Add("R_SECTION_ID", OracleDbType.Int32).Value = objEntCommon.SectionId;
            cmdRead.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntCommon.CorporateID;
            cmdRead.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdRead);
            return dt;
        }


    }
}
