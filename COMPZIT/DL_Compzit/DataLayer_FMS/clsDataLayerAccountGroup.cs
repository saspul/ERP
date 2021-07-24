using EL_Compzit.EntityLayer_FMS;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerAccountGroup
    {
        public void InsertAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityAccountGroup.CodeSts == 0)
                    {

                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        //   LoadAccountGroup();


                        int intCorpId = 0;
                        if (objEntityAccountGroup.CorpId != null)
                        {


                            objEntityCommon.CorporateID = objEntityAccountGroup.CorpId;
                        }

                        if (objEntityAccountGroup.OrgId != null)
                        {

                            objEntityCommon.Organisation_Id = objEntityAccountGroup.OrgId;
                        }
                        clsDataLayer ObjDataLayer = new clsDataLayer();





                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP);
                        //commented to avoid code creation in datalayer evm 0044 21/01/2020
                        //DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
                        //string refFormatByDiv = "";
                        //string strRealFormat = "";
                        //if (dtFormate.Rows.Count > 0)
                        //{
                        //    if (objEntityAccountGroup.NatureId != null)
                        //    {

                        //        int NaureCode = 0;
                        //        string CodeFormate = "";
                        //        int intNature = objEntityAccountGroup.NatureId;

                        //        if (intNature == 0)
                        //        {
                        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
                        //        }
                        //        else if (intNature == 1)
                        //        {
                        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
                        //        }
                        //        else if (intNature == 2)
                        //        {
                        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
                        //        }
                        //        else if (intNature == 3)
                        //        {
                        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
                        //        }



                        //        CodeFormate = NaureCode.ToString();

                        //        // CodeFormate = NaureCode.ToString() + dtNextNumber;
                        //        if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
                        //        {
                        //            refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                        //            string strReferenceFormat = "";
                        //            strReferenceFormat = refFormatByDiv;
                        //            string[] arrReferenceSplit = strReferenceFormat.Split('*');
                        //            int intArrayRowCount = arrReferenceSplit.Length;
                        //            int Codecount = 0;
                        //            strRealFormat = refFormatByDiv.ToString();
                        //            if (strRealFormat.Contains("#NAT#"))
                        //            {
                        //                strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


                        //            }
                        //            if (strRealFormat.Contains("#NUM#"))
                        //            {
                        //                string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);
                        //                strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                        //            }
                        //            if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                        //            {
                        //                Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                        //            }

                        //            int CodeLength = strRealFormat.Length;
                        //            if (CodeLength < Codecount)
                        //            {
                        //                int Difrnce = Codecount - CodeLength;
                        //                CodeLength = CodeLength + Difrnce;
                        //                //  hello.PadLeft(50, '#');
                        //                strRealFormat = strRealFormat.PadLeft(CodeLength, '0');
                        //            }


                        //            objEntityAccountGroup.GrpCode = strRealFormat;
                        //        }
                        //    }
                        //}


                    }


                    string strQueryInsertAccount = "FMS_ACCOUNT_GROUP.SP_INS_ACCOUNTGROUP";
                    using (OracleCommand cmdInsertAccountGroup = new OracleCommand())
                    {

                        cmdInsertAccountGroup.Transaction = tran;
                        cmdInsertAccountGroup.Connection = con;
                        cmdInsertAccountGroup.CommandText = strQueryInsertAccount;
                        cmdInsertAccountGroup.CommandType = CommandType.StoredProcedure;
                        cmdInsertAccountGroup.Parameters.Add("ACC_NAME", OracleDbType.Varchar2).Value = objEntityAccountGroup.AccountGrpName;
                        cmdInsertAccountGroup.Parameters.Add("ACC_PARNT_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.ParentAccountGrpId;
                        cmdInsertAccountGroup.Parameters.Add("ACC_NATURE", OracleDbType.Int32).Value = objEntityAccountGroup.NatureId;
                        cmdInsertAccountGroup.Parameters.Add("ACC_NAT_TYPE", OracleDbType.Int32).Value = objEntityAccountGroup.NatureType;
                        cmdInsertAccountGroup.Parameters.Add("ACC_GRP_STS", OracleDbType.Int32).Value = objEntityAccountGroup.GroupStatus;
                        cmdInsertAccountGroup.Parameters.Add("ACC_USRID", OracleDbType.Int32).Value = objEntityAccountGroup.UserId;
                        cmdInsertAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                        cmdInsertAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                        cmdInsertAccountGroup.Parameters.Add("ACC_GP", OracleDbType.Int32).Value = objEntityAccountGroup.Affect_Gross_Profit;
                        cmdInsertAccountGroup.Parameters.Add("ACC_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AddressStatus;
                        cmdInsertAccountGroup.Parameters.Add("ACC_GRP_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.GrpCode;
                        cmdInsertAccountGroup.ExecuteNonQuery(); 
                        
                       
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
        public void UpdateAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityAccountGroup.CodeSts == 0)
                    {


                        DataTable CheckNatureChange = ReadAccountGroupByID(objEntityAccountGroup);
                        if (CheckNatureChange.Rows.Count > 0)
                        {

                            if (CheckNatureChange.Rows[0]["ACNT_NATURE_STS"].ToString() != "")
                            {
                                if (Convert.ToInt32(CheckNatureChange.Rows[0]["ACNT_NATURE_STS"].ToString()) != objEntityAccountGroup.NatureId)
                                {
                                    clsCommonLibrary objCommon = new clsCommonLibrary();
                                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                                    //   LoadAccountGroup();


                                    int intCorpId = 0;
                                    if (objEntityAccountGroup.CorpId != null)
                                    {


                                        objEntityCommon.CorporateID = objEntityAccountGroup.CorpId;
                                    }

                                    if (objEntityAccountGroup.OrgId != null)
                                    {

                                        objEntityCommon.Organisation_Id = objEntityAccountGroup.OrgId;
                                    }
                                    clsDataLayer ObjDataLayer = new clsDataLayer();
                                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP);
                                    //commented on 21/01/2020 evm 0044 to disable code generation by format
                                    //DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
                                    //string refFormatByDiv = "";
                                    //string strRealFormat = "";
                                    //if (dtFormate.Rows.Count > 0)
                                    //{
                                    //    if (objEntityAccountGroup.NatureId != null)
                                    //    {

                                    //        int NaureCode = 0;
                                    //        string CodeFormate = "";
                                    //        int intNature = objEntityAccountGroup.NatureId;

                                    //        if (intNature == 0)
                                    //        {
                                    //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
                                    //        }
                                    //        else if (intNature == 1)
                                    //        {
                                    //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
                                    //        }
                                    //        else if (intNature == 2)
                                    //        {
                                    //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
                                    //        }
                                    //        else if (intNature == 3)
                                    //        {
                                    //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
                                    //        }



                                    //        CodeFormate = NaureCode.ToString();

                                    //        // CodeFormate = NaureCode.ToString() + dtNextNumber;
                                    //        if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
                                    //        {
                                    //            refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                                    //            string strReferenceFormat = "";
                                    //            strReferenceFormat = refFormatByDiv;
                                    //            string[] arrReferenceSplit = strReferenceFormat.Split('*');
                                    //            int intArrayRowCount = arrReferenceSplit.Length;
                                    //            int Codecount = 0;
                                    //            strRealFormat = refFormatByDiv.ToString();
                                    //            if (strRealFormat.Contains("#NAT#"))
                                    //            {
                                    //                strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


                                    //            }
                                    //            if (strRealFormat.Contains("#NUM#"))
                                    //            {
                                    //                string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);
                                    //                strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                                    //            }
                                    //            if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                                    //            {
                                    //                Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                                    //            }

                                    //            int CodeLength = strRealFormat.Length;
                                    //            if (CodeLength < Codecount)
                                    //            {
                                    //                int Difrnce = Codecount - CodeLength;
                                    //                CodeLength = CodeLength + Difrnce;
                                    //                //  hello.PadLeft(50, '#');
                                    //                strRealFormat = strRealFormat.PadLeft(CodeLength, '0');
                                    //            }


                                    //            objEntityAccountGroup.GrpCode = strRealFormat;
                                    //        }
                                    //    }
                                    //}
                                }
                            }
                        }


                    }
                    string strQueryUpdateAccount = "FMS_ACCOUNT_GROUP.SP_UPD_ACCOUNTGROUP";
                    using (OracleCommand cmdUpdateAccountGroup = new OracleCommand())
                    {
                        cmdUpdateAccountGroup.Transaction = tran;
                        cmdUpdateAccountGroup.Connection = con;
                        cmdUpdateAccountGroup.CommandText = strQueryUpdateAccount;
                        cmdUpdateAccountGroup.CommandType = CommandType.StoredProcedure;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_NAME", OracleDbType.Varchar2).Value = objEntityAccountGroup.AccountGrpName;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_PARNT_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.ParentAccountGrpId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_NATURE", OracleDbType.Int32).Value = objEntityAccountGroup.NatureId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_NAT_TYPE", OracleDbType.Int32).Value = objEntityAccountGroup.NatureType;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_GRP_STS", OracleDbType.Int32).Value = objEntityAccountGroup.GroupStatus;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_USRID", OracleDbType.Int32).Value = objEntityAccountGroup.UserId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_GP", OracleDbType.Int32).Value = objEntityAccountGroup.Affect_Gross_Profit;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AddressStatus;
                        cmdUpdateAccountGroup.Parameters.Add("ACC_GRP_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.GrpCode;
                        cmdUpdateAccountGroup.ExecuteNonQuery();
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
        public DataTable ReadAccountGroupByID(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroupByID = new DataTable();
            using (OracleCommand cmdReadAccountGroupByID = new OracleCommand())
            {
                cmdReadAccountGroupByID.CommandText = "FMS_ACCOUNT_GROUP.SP_READ_ACCOUNTGROUP_BY_ID";
                cmdReadAccountGroupByID.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroupByID.Parameters.Add("ACC_GRP_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroupByID = clsDataLayer.SelectDataTable(cmdReadAccountGroupByID);
            }
            return dtAccountGroupByID;
        }
        public DataTable LoadAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroup = new DataTable();
            using (OracleCommand cmdReadAccountGroup = new OracleCommand())
            {
                cmdReadAccountGroup.CommandText = "FMS_ACCOUNT_GROUP.LOAD_ACCOUNT_GROUP";
                cmdReadAccountGroup.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroup.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroup);
            }
            return dtAccountGroup;
        }

        public DataTable ReadAccountGroupList(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroupByID = new DataTable();
            using (OracleCommand cmdReadAccountGroupByID = new OracleCommand())
            {
                cmdReadAccountGroupByID.CommandText = "FMS_ACCOUNT_GROUP.SP_READ_ACCOUNT_GROUP_LIST";
                cmdReadAccountGroupByID.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroupByID.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_STS", OracleDbType.Int32).Value = objEntityAccountGroup.GroupStatus;
                cmdReadAccountGroupByID.Parameters.Add("ACC_GRP", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdReadAccountGroupByID.Parameters.Add("ACC_CANCEL_STS", OracleDbType.Int32).Value = objEntityAccountGroup.Cancel_status;
                cmdReadAccountGroupByID.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroupByID = clsDataLayer.SelectDataTable(cmdReadAccountGroupByID);
            }
            return dtAccountGroupByID;
        }
        public void ChangeAccountStatus(clsEntityAccountGroup objEntityAccountGroup)
        {
            string strQueryAccountStatus = "FMS_ACCOUNT_GROUP.SP_UPD_CHANGE_STATUS";
            using (OracleCommand cmdAccountStatus = new OracleCommand())
            {
                cmdAccountStatus.CommandText = strQueryAccountStatus;
                cmdAccountStatus.CommandType = CommandType.StoredProcedure;
                cmdAccountStatus.Parameters.Add("ACC_GRP", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdAccountStatus.Parameters.Add("ACC_USRID", OracleDbType.Int32).Value = objEntityAccountGroup.UserId;
                cmdAccountStatus.Parameters.Add("ACC_STS", OracleDbType.Int32).Value = objEntityAccountGroup.Cancel_status;

                clsDataLayer.ExecuteNonQuery(cmdAccountStatus);
            }
        }
        public void CancelAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            string strQueryAccountStatus = "FMS_ACCOUNT_GROUP.SP_CANCEL_ACCOUNTGROUP";
            using (OracleCommand cmdAccountStatus = new OracleCommand())
            {
                cmdAccountStatus.CommandText = strQueryAccountStatus;
                cmdAccountStatus.CommandType = CommandType.StoredProcedure;
                cmdAccountStatus.Parameters.Add("ACC_GRP", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdAccountStatus.Parameters.Add("ACC_USRID", OracleDbType.Int32).Value = objEntityAccountGroup.UserId;
                cmdAccountStatus.Parameters.Add("ACC_REASON", OracleDbType. Varchar2).Value = objEntityAccountGroup.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdAccountStatus);
            }
        }
        public DataTable AccountGroupDplctnChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroup = new DataTable();
            using (OracleCommand cmdReadAccountGroup = new OracleCommand())
            {
                cmdReadAccountGroup.CommandText = "FMS_ACCOUNT_GROUP.INS_ACCOUNT_GROUP_DUP";
                cmdReadAccountGroup.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroup.Parameters.Add("ACC_NAME", OracleDbType.Varchar2).Value = objEntityAccountGroup.AccountGrpName;
                cmdReadAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroup.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroup);
            }
            return dtAccountGroup;
        }
        public DataTable AccountGroupDplctnUpdChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroup = new DataTable();
            using (OracleCommand cmdReadAccountGroup = new OracleCommand())
            {
                cmdReadAccountGroup.CommandText = "FMS_ACCOUNT_GROUP.UPD_ACCOUNT_GROUP_DUP";
                cmdReadAccountGroup.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroup.Parameters.Add("ACC_GRP", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdReadAccountGroup.Parameters.Add("ACC_NAME", OracleDbType.Varchar2).Value = objEntityAccountGroup.AccountGrpName;
                cmdReadAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroup.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroup);
            }
            return dtAccountGroup;
        }
        public DataTable AccountGroupCancelChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountGroup = new DataTable();
            using (OracleCommand cmdReadAccountGroup = new OracleCommand())
            {
                cmdReadAccountGroup.CommandText = "FMS_ACCOUNT_GROUP.ACCOUNT_GROUP_CNCL_CHK";
                cmdReadAccountGroup.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroup.Parameters.Add("ACC_GRP", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdReadAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                cmdReadAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                cmdReadAccountGroup.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroup);
            }
            return dtAccountGroup;
        }

        public string CheckCodeDuplicatn(clsEntityAccountGroup objEntityAccountGroup)
        {
            string strQueryAddBank = "FMS_ACCOUNT_GROUP.SP_CHECK_DUP_CODE";
            OracleCommand cmdAddBankName = new OracleCommand();
            cmdAddBankName.CommandText = strQueryAddBank;
            cmdAddBankName.CommandType = CommandType.StoredProcedure;
            cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
            cmdAddBankName.Parameters.Add("B_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.GrpCode;
            cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
            cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
            cmdAddBankName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdAddBankName);
            string strReturn = cmdAddBankName.Parameters["B_COUNT"].Value.ToString();
            cmdAddBankName.Dispose();
            return strReturn;
        }

        //em 0044 21/01/2020
        public DataTable LoadAccountGroupById(clsEntityAccountGroup  objEntityAccountGroup)
        {
            DataTable dtAccountGroup = new DataTable();
            using (OracleCommand cmdReadAccountGroupById = new OracleCommand())
            {
                cmdReadAccountGroupById.CommandText = "FMS_ACCOUNT_GROUP.LOAD_ACCOUNT_GROUP_BYID";
                cmdReadAccountGroupById.CommandType = CommandType.StoredProcedure;
                cmdReadAccountGroupById.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId ;
                cmdReadAccountGroupById.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId ;
                cmdReadAccountGroupById.Parameters.Add("ACC_ID", OracleDbType.Int32).Value = objEntityAccountGroup.AccountGrpId;
                cmdReadAccountGroupById.Parameters.Add("ACC_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroupById);
            }
            return dtAccountGroup;
        }
        public void UpdateAccountGroupNextGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                        
                            string strQueryUpdateAccount = "FMS_ACCOUNT_GROUP.UP_ACCOUNT_GROUP_NEXTGRPID";
                            using (OracleCommand cmdUpdateAccountGroup = new OracleCommand(strQueryUpdateAccount, con))
                            {
                                cmdUpdateAccountGroup.Transaction = tran;
                                cmdUpdateAccountGroup.CommandType = CommandType.StoredProcedure;
                                cmdUpdateAccountGroup.Parameters.Add("ACC_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.OrgId;
                                cmdUpdateAccountGroup.Parameters.Add("ACC_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.CorpId;
                                cmdUpdateAccountGroup.Parameters.Add("ACC_ID", OracleDbType.Int32).Value = objEntityAccountGroup.ParentAccountGrpId;
                                cmdUpdateAccountGroup.ExecuteNonQuery();
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
    }
}
