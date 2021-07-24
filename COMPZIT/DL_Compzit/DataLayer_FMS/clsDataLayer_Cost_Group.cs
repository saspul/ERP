using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_Cost_Group
    {
        public void InsertCostGroup(clsEntityLayer_Cost_Group objEntityCost)
        {

            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {

                    // commented by evm 0044
                    //if (objEntityCost.CodePrsncSts == 1)
                    //{

                    //    if (objEntityCost.CodeSts == 0)
                    //    {

                    //        clsCommonLibrary objCommon = new clsCommonLibrary();
                    //        clsEntityCommon objEntityCommon = new clsEntityCommon();
                    //        //   LoadAccountGroup();


                    //        int intCorpId = 0;
                    //        if (objEntityCost.Corp_Id != null)
                    //        {


                    //            objEntityCommon.CorporateID = objEntityCost.Corp_Id;
                    //        }

                    //        if (objEntityCost.Org_Id != null)
                    //        {

                    //            objEntityCommon.Organisation_Id = objEntityCost.Org_Id;
                    //        }
                    //        clsDataLayer ObjDataLayer = new clsDataLayer();





                    //        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Cost_Group);
                    //        DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
                    //        string refFormatByDiv = "";
                    //        string strRealFormat = "";
                    //        if (dtFormate.Rows.Count > 0)
                    //        {


                    //            int NaureCode = 0;
                    //            string CodeFormate = "";



                    //            CodeFormate = NaureCode.ToString();

                    //            // CodeFormate = NaureCode.ToString() + dtNextNumber;
                    //            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
                    //            {
                    //                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                    //                string strReferenceFormat = "";
                    //                strReferenceFormat = refFormatByDiv;
                    //                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                    //                int intArrayRowCount = arrReferenceSplit.Length;
                    //                int Codecount = 0;
                    //                strRealFormat = refFormatByDiv.ToString();

                    //                if (strRealFormat.Contains("#NUM#"))
                    //                {
                    //                    string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);
                    //                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                    //                }
                    //                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                    //                {
                    //                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                    //                }

                    //                int CodeLength = strRealFormat.Length;
                    //                if (CodeLength < Codecount)
                    //                {
                    //                    int Difrnce = Codecount - CodeLength;
                    //                    CodeLength = CodeLength + Difrnce;
                    //                    //  hello.PadLeft(50, '#');
                    //                    strRealFormat = strRealFormat.PadLeft(CodeLength, '0');
                    //                }


                    //                objEntityCost.GrpCode = strRealFormat;
                    //            }

                    //        }


                    //    }


                    //}
                    //else
                    //{
                    //   objEntityCost.GrpCode =  null;
                    //}



                    string strQueryCostGroup = "FMS_COST_GROUP.SP_INS_COST";
                    using (OracleCommand cmdAddCostGroup = new OracleCommand(strQueryCostGroup, con))
                    {
                        cmdAddCostGroup.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();

                        cmdAddCostGroup.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCost.Name;
                        cmdAddCostGroup.Parameters.Add("C_STS", OracleDbType.Int32).Value = objEntityCost.Status;
                        cmdAddCostGroup.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
                        cmdAddCostGroup.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
                        cmdAddCostGroup.Parameters.Add("C_INS_USRID", OracleDbType.Int32).Value = objEntityCost.UserId;
                        cmdAddCostGroup.Parameters.Add("C_HIRID", OracleDbType.Int32).Value = objEntityCost.HierarchyId;
                        cmdAddCostGroup.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCost.GrpCode;

                        cmdAddCostGroup.ExecuteNonQuery();

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
        public string CheckCostName(clsEntityLayer_Cost_Group objEntityCost)
        {

            string strQueryAddTaxCollectedAtSource = "FMS_COST_GROUP.SP_CHECK_COST_NAME";
            OracleCommand cmdCheckCostName = new OracleCommand();
            cmdCheckCostName.CommandText = strQueryAddTaxCollectedAtSource;
            cmdCheckCostName.CommandType = CommandType.StoredProcedure;
            cmdCheckCostName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
            cmdCheckCostName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCost.Name;
            cmdCheckCostName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
            cmdCheckCostName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
            cmdCheckCostName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;

            clsDataLayer.ExecuteScalar(ref cmdCheckCostName);
            string strReturn = cmdCheckCostName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCostName.Dispose();
            return strReturn;
        }
        public DataTable ReadCOSTList(clsEntityLayer_Cost_Group objEntityCost)
        {
            string strQueryReadCOST = "FMS_COST_GROUP.SP_COST_LIST";
            OracleCommand cmdReadCOST = new OracleCommand();
            cmdReadCOST.CommandText = strQueryReadCOST;
            cmdReadCOST.CommandType = CommandType.StoredProcedure;
            cmdReadCOST.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
            cmdReadCOST.Parameters.Add("C_STS", OracleDbType.Int32).Value = objEntityCost.Status;
            cmdReadCOST.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
            cmdReadCOST.Parameters.Add("C_CNCL_STS", OracleDbType.Int32).Value = objEntityCost.Cancl_Status;
            cmdReadCOST.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadCOST);
            return dtLeav;

        }
        public DataTable ReadCOSTById(clsEntityLayer_Cost_Group objEntityCost)
        {
            string strQueryReadCost = "FMS_COST_GROUP.SP_READ_COST_BYID";
            OracleCommand cmdReadCost = new OracleCommand();
            cmdReadCost.CommandText = strQueryReadCost;
            cmdReadCost.CommandType = CommandType.StoredProcedure;

            cmdReadCost.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
            cmdReadCost.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
            cmdReadCost.Parameters.Add("C_COST_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
            cmdReadCost.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadCost);
            return dtLeav;

        }
        public void UpdateCostGroup(clsEntityLayer_Cost_Group objEntityCost)
        {

            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                    if (objEntityCost.CodePrsncSts == 0)
                    {
                        objEntityCost.GrpCode = null;
                    }


                    string strQueryAddCostGroup = "FMS_COST_GROUP.SP_UPDATE_COST";
                    using (OracleCommand cmdAddTaxCollectedAtSource = new OracleCommand(strQueryAddCostGroup, con))
                    {
                        cmdAddTaxCollectedAtSource.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_COST_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCost.Name;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_STS", OracleDbType.Int32).Value = objEntityCost.Status;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_CORPID", OracleDbType.Varchar2).Value = objEntityCost.Corp_Id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_UPD_USRID", OracleDbType.Int32).Value = objEntityCost.UserId;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_HIRID", OracleDbType.Int32).Value = objEntityCost.HierarchyId;
                        cmdAddTaxCollectedAtSource.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCost.GrpCode;
                        cmdAddTaxCollectedAtSource.ExecuteNonQuery();

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
        public void CancelCostGroup(clsEntityLayer_Cost_Group objEntityCost)
     {
         string strQueryCnclCost = " FMS_COST_GROUP.SP_CANCEL_COST";
         using (OracleCommand cmdCnclCost = new OracleCommand())
         {
             cmdCnclCost.CommandText = strQueryCnclCost;
             cmdCnclCost.CommandType = CommandType.StoredProcedure;
             cmdCnclCost.Parameters.Add("C_COST_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
             cmdCnclCost.Parameters.Add("C_CNCL_USRID", OracleDbType.Int32).Value = objEntityCost.UserId;
             cmdCnclCost.Parameters.Add("C_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityCost.CancelReason;
             cmdCnclCost.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
             cmdCnclCost.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
             clsDataLayer.ExecuteNonQuery(cmdCnclCost);
         }
     }
        public DataTable ReadCostCnclChck(clsEntityLayer_Cost_Group objEntityCost)
        {
            string strQueryReadCost = "FMS_COST_GROUP.SP_READ_COST_CNCLCHCK";
            OracleCommand cmdReadCost = new OracleCommand();
            cmdReadCost.CommandText = strQueryReadCost;
            cmdReadCost.CommandType = CommandType.StoredProcedure;

            cmdReadCost.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
            cmdReadCost.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
            cmdReadCost.Parameters.Add("C_COST_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
            cmdReadCost.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadCost);
            return dtLeav;

        }
        public DataTable CostGroupCancelChk(clsEntityLayer_Cost_Group objEntityCost)
        {
            string strQueryReadCost = "FMS_COST_GROUP.SP_READ_COST_GRP_CNCLCHCK";
            OracleCommand cmdReadCost = new OracleCommand();
            cmdReadCost.CommandText = strQueryReadCost;
            cmdReadCost.CommandType = CommandType.StoredProcedure;

            cmdReadCost.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCost.Org_Id;
            cmdReadCost.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCost.Corp_Id;
            cmdReadCost.Parameters.Add("C_COST_ID", OracleDbType.Int32).Value = objEntityCost.CostId;
            cmdReadCost.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadCost);
            return dtLeav;

        }
        public DataTable ReadCostGroupHierarchy(clsEntityLayer_Cost_Group objEntityCost)
        {
            string strQueryReadCost = "FMS_COST_GROUP.SP_READ_COST_GRP_HIERACRCHY";
            OracleCommand cmdReadCost = new OracleCommand();
            cmdReadCost.CommandText = strQueryReadCost;
            cmdReadCost.CommandType = CommandType.StoredProcedure;
            cmdReadCost.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadCost);
            return dtLeav;

        }

        public string CheckCodeDuplicatn(clsEntityLayer_Cost_Group objEntityAccountGroup)
        {
            string strQueryAddBank = "FMS_COST_GROUP.SP_CHECK_DUP_CODE";
            OracleCommand cmdAddBankName = new OracleCommand();
            cmdAddBankName.CommandText = strQueryAddBank;
            cmdAddBankName.CommandType = CommandType.StoredProcedure;
            cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityAccountGroup.CostId;
            cmdAddBankName.Parameters.Add("B_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.GrpCode;
            cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.Corp_Id;
            cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.Org_Id;
            cmdAddBankName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdAddBankName);
            string strReturn = cmdAddBankName.Parameters["B_COUNT"].Value.ToString();
            cmdAddBankName.Dispose();
            return strReturn;
        }
    }
}
