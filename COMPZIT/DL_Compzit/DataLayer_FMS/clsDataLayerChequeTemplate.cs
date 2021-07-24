using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerChequeTemplate
    {

        public void InsertChequeTemplte(clsEntityChequeTemplate objEntityTCS)
        {

            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                    string strQueryAddTaxCollectedAtSource = "FMS_CHEQUE_TEMPLATE.SP_INS_DTL";
                    using (OracleCommand cmdAddTaxCollectedAtSource = new OracleCommand(strQueryAddTaxCollectedAtSource, con))
                    {
                        cmdAddTaxCollectedAtSource.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_FILE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.FileName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.ActFileName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_WIDTH", OracleDbType.Decimal).Value = objEntityTCS.Width;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_HEIGHT", OracleDbType.Decimal).Value = objEntityTCS.Height;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYEE_LEFT", OracleDbType.Decimal).Value = objEntityTCS.PayeeLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYEE_TOP", OracleDbType.Decimal).Value = objEntityTCS.PayeeTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_DATE_LEFT", OracleDbType.Decimal).Value = objEntityTCS.DateLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_DATE_TOP", OracleDbType.Decimal).Value = objEntityTCS.DateTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD1_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntWord1Left;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD1_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntWord1Top;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD2_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntWord2Left;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD2_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntWord2Top;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTNUM_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntNumLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTNUM_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntNumTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_INS_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_TOPS", OracleDbType.Varchar2).Value = objEntityTCS.CancelReason;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_TOPS_F", OracleDbType.Varchar2).Value = objEntityTCS.FinalTops;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.PayeeName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_DATE", OracleDbType.Varchar2).Value = objEntityTCS.PaymentDate;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_WORD_ONE", OracleDbType.Varchar2).Value = objEntityTCS.Amunt_word_one;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_WORD_TWO", OracleDbType.Varchar2).Value = objEntityTCS.Amunt_word_two;
                        if (objEntityTCS.AmntNum != 0)
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_NUM", OracleDbType.Decimal).Value = objEntityTCS.AmntNum;
                        }
                        else
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_NUM", OracleDbType.Decimal).Value = null;
                        }
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PRINT_POS", OracleDbType.Int32).Value = objEntityTCS.PrintPosition;
                        //EVM-0027 Aug 29
                        if (objEntityTCS.WordOneLength != 0)
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_WORDAMTONE_LEN", OracleDbType.Int32).Value = objEntityTCS.WordOneLength;
                        }
                        else
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_WORDAMTONE_LEN", OracleDbType.Int32).Value = null;
                        }
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
        public void UpdateChequeTemplte(clsEntityChequeTemplate objEntityTCS)
        {

            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                    string strQueryAddTaxCollectedAtSource = "FMS_CHEQUE_TEMPLATE.SP_UPDATE_DTL";
                    using (OracleCommand cmdAddTaxCollectedAtSource = new OracleCommand(strQueryAddTaxCollectedAtSource, con))
                    {
                        cmdAddTaxCollectedAtSource.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_TEMPLATE_ID", OracleDbType.Int32).Value = objEntityTCS.ChequeTemplateId;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_FILE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.FileName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.ActFileName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_WIDTH", OracleDbType.Decimal).Value = objEntityTCS.Width;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_HEIGHT", OracleDbType.Decimal).Value = objEntityTCS.Height;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYEE_LEFT", OracleDbType.Decimal).Value = objEntityTCS.PayeeLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYEE_TOP", OracleDbType.Decimal).Value = objEntityTCS.PayeeTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_DATE_LEFT", OracleDbType.Decimal).Value = objEntityTCS.DateLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_DATE_TOP", OracleDbType.Decimal).Value = objEntityTCS.DateTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD1_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntWord1Left;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD1_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntWord1Top;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD2_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntWord2Left;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTWORD2_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntWord2Top;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTNUM_LEFT", OracleDbType.Decimal).Value = objEntityTCS.AmntNumLeft;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_AMNTNUM_TOP", OracleDbType.Decimal).Value = objEntityTCS.AmntNumTop;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_CORPID", OracleDbType.Varchar2).Value = objEntityTCS.Corporate_id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_UPD_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_TOPS", OracleDbType.Varchar2).Value = objEntityTCS.CancelReason;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_TOPS_F", OracleDbType.Varchar2).Value = objEntityTCS.FinalTops;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_NAME", OracleDbType.Varchar2).Value = objEntityTCS.PayeeName;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_DATE", OracleDbType.Varchar2).Value = objEntityTCS.PaymentDate;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_WORD_ONE", OracleDbType.Varchar2).Value = objEntityTCS.Amunt_word_one;
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_WORD_TWO", OracleDbType.Varchar2).Value = objEntityTCS.Amunt_word_two;
                        if (objEntityTCS.AmntNum != 0)
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_NUM", OracleDbType.Decimal).Value = objEntityTCS.AmntNum;
                        }
                        else
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_PAYE_AMT_NUM", OracleDbType.Decimal).Value =null;
                        }
                        cmdAddTaxCollectedAtSource.Parameters.Add("T_PRINT_POS", OracleDbType.Int32).Value = objEntityTCS.PrintPosition;
                        if (objEntityTCS.WordOneLength != 0)
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_WORDAMTONE_LEN", OracleDbType.Int32).Value = objEntityTCS.WordOneLength;
                        }
                        else
                        {
                            cmdAddTaxCollectedAtSource.Parameters.Add("T_WORDAMTONE_LEN", OracleDbType.Int32).Value = null;
                        }
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
        public string DuplicationCheckName(clsEntityChequeTemplate objEntityTCS)
        {
            string strQueryAddTaxCollectedAtSource = "FMS_CHEQUE_TEMPLATE.SP_CHECK_DUP_NAME";
            OracleCommand cmdCheckTCSName = new OracleCommand();
            cmdCheckTCSName.CommandText = strQueryAddTaxCollectedAtSource;
            cmdCheckTCSName.CommandType = CommandType.StoredProcedure;
            cmdCheckTCSName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTCS.ChequeTemplateId;
            cmdCheckTCSName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
            cmdCheckTCSName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
            cmdCheckTCSName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
            cmdCheckTCSName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckTCSName);
            string strReturn = cmdCheckTCSName.Parameters["T_COUNT"].Value.ToString();
            cmdCheckTCSName.Dispose();
            return strReturn;
        }
        public DataTable ReadList(clsEntityChequeTemplate objEntityTCS)
        {
            string strQueryReadTcs = "FMS_CHEQUE_TEMPLATE.SP_READ_LIST";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
            cmdReadTcs.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
            cmdReadTcs.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTCS.Status;
            cmdReadTcs.Parameters.Add("T_CNCL_STS", OracleDbType.Int32).Value = objEntityTCS.cncl_sts;
            cmdReadTcs.Parameters.Add("T_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public DataTable ReadTemplateById(clsEntityChequeTemplate objEntityTCS)
        {
            string strQueryReadTcs = "FMS_CHEQUE_TEMPLATE.SP_READ_DTL_BYID";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
            cmdReadTcs.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
            cmdReadTcs.Parameters.Add("T_TCS_ID", OracleDbType.Int32).Value = objEntityTCS.ChequeTemplateId;
            cmdReadTcs.Parameters.Add("T_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public void CancelChequeTemplate(clsEntityChequeTemplate objEntityTCS)
        {
            string strQueryCncltCS = " FMS_CHEQUE_TEMPLATE.SP_CANCEL_TEMPLATE";
            using (OracleCommand cmdCncltCSn = new OracleCommand())
            {
                cmdCncltCSn.CommandText = strQueryCncltCS;
                cmdCncltCSn.CommandType = CommandType.StoredProcedure;
                cmdCncltCSn.Parameters.Add("T_TCS_ID", OracleDbType.Int32).Value = objEntityTCS.ChequeTemplateId;
                cmdCncltCSn.Parameters.Add("T_CNCL_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
                cmdCncltCSn.Parameters.Add("T_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityTCS.CancelReason;
                cmdCncltCSn.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
                cmdCncltCSn.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdCncltCSn);
            }
        }

    }
}
