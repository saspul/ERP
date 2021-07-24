using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

namespace DL_Compzit
{
    public class clsDataLayerBank
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();



        public DataTable ReadChkBookDtlsById(clsEntityLayerBank objEntityBank)
        {
            string strQueryReadVehicleClassList = "BANK_MASTER.SP_READ_CHEQUE_BOOK_DTLS";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleClassList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityBank.BankId;
            cmdReadVehicleList.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
            cmdReadVehicleList.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
            cmdReadVehicleList.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
            
            cmdReadVehicleList.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }

        public DataTable ReadChequeTemplateDtl(clsEntityLayerBank objEntityBank)
        {
            string strQueryReadVehicleClassList = "BANK_MASTER.SP_READ_CHEQUE_TEMP_DTLS";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleClassList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
            cmdReadVehicleList.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
            cmdReadVehicleList.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
            
            cmdReadVehicleList.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }


        // This Method adds bank details details to the table
        public void AddBankName(clsEntityLayerBank objEntityBank,List<clsEntityLayerBank> objListchbk)
        {
            OracleTransaction trans;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                trans = con.BeginTransaction();
                try
                {
                    string strReturn = "";
              

                string strQueryAddBank = "BANK_MASTER.SP_INSERT_BANK_DETAILS";
                OracleCommand cmdAddBankName = new OracleCommand();
                                    cmdAddBankName.CommandText = strQueryAddBank;
                    cmdAddBankName.CommandType = CommandType.StoredProcedure;
                    cmdAddBankName.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityBank.BankName;
                    // cmdAddBankName.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityBank.ImageId;
                    cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
                    cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
                    cmdAddBankName.Parameters.Add("B_STATUS", OracleDbType.Int32).Value = objEntityBank.Status;
                    cmdAddBankName.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
                    cmdAddBankName.Parameters.Add("B_BANK_ADDRESS", OracleDbType.Varchar2).Value = objEntityBank.BankAddrs;
                    cmdAddBankName.Parameters.Add("B_BANK_ACC_NO", OracleDbType.Varchar2).Value = objEntityBank.AccNo;
                    cmdAddBankName.Parameters.Add("B_BANK_IFSC_CODE", OracleDbType.Varchar2).Value = objEntityBank.IfscCode;
                    cmdAddBankName.Parameters.Add("B_BANK_SWIFT_CODE", OracleDbType.Varchar2).Value = objEntityBank.SwiftCode;
                    cmdAddBankName.Parameters.Add("B_BANK_I_BAN_NO", OracleDbType.Varchar2).Value = objEntityBank.IBank;
                    //EVM-0027
                    cmdAddBankName.Parameters.Add("B_BANK_SHORT_NAME", OracleDbType.Varchar2).Value = objEntityBank.BankShortName;
                    //END
                    //EVM-0027 SEP18
                    cmdAddBankName.Parameters.Add("B_HCM_STATUS", OracleDbType.Int32).Value = objEntityBank.HCMStatus;


                    cmdAddBankName.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityBank.LedgerSts;
                    if (objEntityBank.LedgerId != 0)
                    {
                        cmdAddBankName.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityBank.LedgerId;
                    }
                    else
                    {
                        cmdAddBankName.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                    } 
                    //END
                    cmdAddBankName.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    clsDataLayer.ExecuteScalar(ref cmdAddBankName);
                    strReturn = cmdAddBankName.Parameters["L_ID"].Value.ToString();
                    objEntityBank.BankId = Convert.ToInt32(strReturn);
                    cmdAddBankName.Dispose();


                    foreach (clsEntityLayerBank objChkbk in objListchbk)
                    {


                        string strQueryAddBank1 = "BANK_MASTER.SP_INSERT_CHKBOOK_DETAILS";
                        using (OracleCommand cmdInsertprdt = new OracleCommand())
                        {
                            cmdInsertprdt.Transaction = trans;
                            cmdInsertprdt.Connection = con;
                            cmdInsertprdt.CommandText = strQueryAddBank1;
                            cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                            cmdInsertprdt.Parameters.Add("B_NEXTID", OracleDbType.Int32).Value =Convert.ToInt32(strReturn);
                            cmdInsertprdt.Parameters.Add("B_CHKBK", OracleDbType.Varchar2).Value = objChkbk.ChequeBk;
                            cmdInsertprdt.Parameters.Add("B_NUMFROM", OracleDbType.Int32).Value = objChkbk.ChkNumFrm;
                            cmdInsertprdt.Parameters.Add("B_NUMTO", OracleDbType.Int32).Value = objChkbk.ChkNumTo;
                            cmdInsertprdt.Parameters.Add("B_STS", OracleDbType.Int32).Value = objChkbk.ChkStatus;
                            cmdInsertprdt.Parameters.Add("B_TEMPID", OracleDbType.Int32).Value = objChkbk.ChkTemp;
                           
                            cmdInsertprdt.Parameters.Add("B_CNCL_CHQ_STS", OracleDbType.Int32).Value = objChkbk.CancelChqSts;
                            cmdInsertprdt.Parameters.Add("B_CNCLNUM", OracleDbType.Varchar2).Value = objChkbk.ChequeLfNums;
                            cmdInsertprdt.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objChkbk.ChqCnclRsn;
                            cmdInsertprdt.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                
                }
                catch (Exception)
                {

                    trans.Rollback();
                }
            }
            
        }
        // This Method update bank details details to the table
        public void UpdateBankName(clsEntityLayerBank objEntityBank,List<clsEntityLayerBank> objEntityPerfomList,string[] strarrCancldtlIds)
        {

               OracleTransaction trans;
               using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
               {
                   con.Open();
                   trans = con.BeginTransaction();
                   try
                   {

                       string strQueryAddBank = "BANK_MASTER.SP_UPD_BANK_DETAILS";
                       using (OracleCommand cmdAddBankName = new OracleCommand())
                       {
                           cmdAddBankName.CommandText = strQueryAddBank;
                           cmdAddBankName.CommandType = CommandType.StoredProcedure;
                           cmdAddBankName.Transaction = trans;
                           cmdAddBankName.Connection = con;

                           cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Varchar2).Value = objEntityBank.BankId;
                           cmdAddBankName.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityBank.BankName;
                           // cmdAddBankName.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityBank.ImageId;
                           cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
                           cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
                           cmdAddBankName.Parameters.Add("B_STATUS", OracleDbType.Int32).Value = objEntityBank.Status;
                           cmdAddBankName.Parameters.Add("B_UPDUSERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
                           cmdAddBankName.Parameters.Add("B_UPDATE", OracleDbType.Date).Value = objEntityBank.BankDate;
                           cmdAddBankName.Parameters.Add("B_BANK_ADDRESS", OracleDbType.Varchar2).Value = objEntityBank.BankAddrs;
                           cmdAddBankName.Parameters.Add("B_BANK_ACC_NO", OracleDbType.Varchar2).Value = objEntityBank.AccNo;
                           cmdAddBankName.Parameters.Add("B_BANK_IFSC_CODE", OracleDbType.Varchar2).Value = objEntityBank.IfscCode;
                           cmdAddBankName.Parameters.Add("B_BANK_SWIFT_CODE", OracleDbType.Varchar2).Value = objEntityBank.SwiftCode;
                           cmdAddBankName.Parameters.Add("B_BANK_I_BAN_NO", OracleDbType.Varchar2).Value = objEntityBank.IBank;
                           //EVM-0027
                           cmdAddBankName.Parameters.Add("B_BANK_SHORT_NAME", OracleDbType.Varchar2).Value = objEntityBank.BankShortName;
                           //END
                           //EVM-0027 SEP18
                           cmdAddBankName.Parameters.Add("B_HCM_STATUS", OracleDbType.Int32).Value = objEntityBank.HCMStatus;




                           cmdAddBankName.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityBank.LedgerSts;
                           if (objEntityBank.LedgerId != 0)
                           {
                               cmdAddBankName.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityBank.LedgerId;
                           }
                           else
                           {
                               cmdAddBankName.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                           } 
                           //END

                           cmdAddBankName.ExecuteNonQuery();
                       }

                       foreach (clsEntityLayerBank objChkbk in objEntityPerfomList)
                       {
                           if (objChkbk.UpdOrIns == "INS")
                           {

                               string strQueryAddBank1 = "BANK_MASTER.SP_INSERT_CHKBOOK_DETAILS";
                               using (OracleCommand cmdInsertprdt = new OracleCommand())
                               {
                                   cmdInsertprdt.Transaction = trans;
                                   cmdInsertprdt.Connection = con;
                                   cmdInsertprdt.CommandText = strQueryAddBank1;
                                   cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                   cmdInsertprdt.Parameters.Add("B_NEXTID", OracleDbType.Int32).Value = objEntityBank.BankId;
                                   cmdInsertprdt.Parameters.Add("B_CHKBK", OracleDbType.Varchar2).Value = objChkbk.ChequeBk;
                                   cmdInsertprdt.Parameters.Add("B_NUMFROM", OracleDbType.Int32).Value = objChkbk.ChkNumFrm;
                                   cmdInsertprdt.Parameters.Add("B_NUMTO", OracleDbType.Int32).Value = objChkbk.ChkNumTo;
                                   cmdInsertprdt.Parameters.Add("B_STS", OracleDbType.Int32).Value = objChkbk.ChkStatus;
                                   cmdInsertprdt.Parameters.Add("B_TEMPID", OracleDbType.Int32).Value = objChkbk.ChkTemp;
                                   cmdInsertprdt.Parameters.Add("B_CNCL_CHQ_STS", OracleDbType.Int32).Value = objChkbk.CancelChqSts;
                                   cmdInsertprdt.Parameters.Add("B_CNCLNUM", OracleDbType.Varchar2).Value = objChkbk.ChequeLfNums;
                                   cmdInsertprdt.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objChkbk.ChqCnclRsn;
                                   cmdInsertprdt.ExecuteNonQuery();
                               }
                           }
                           else
                           {
                               string strQueryAddBank1 = "BANK_MASTER.SP_UPDATE_CHKBOOK_DETAILS";
                               using (OracleCommand cmdInsertprdt = new OracleCommand())
                               {
                                   cmdInsertprdt.Transaction = trans;
                                   cmdInsertprdt.Connection = con;
                                   cmdInsertprdt.CommandText = strQueryAddBank1;
                                   cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                   cmdInsertprdt.Parameters.Add("B_NEXTID", OracleDbType.Int32).Value = objEntityBank.BankId;
                                   cmdInsertprdt.Parameters.Add("B_CHKBK", OracleDbType.Varchar2).Value = objChkbk.ChequeBk;
                                   cmdInsertprdt.Parameters.Add("B_NUMFROM", OracleDbType.Int32).Value = objChkbk.ChkNumFrm;
                                   cmdInsertprdt.Parameters.Add("B_NUMTO", OracleDbType.Int32).Value = objChkbk.ChkNumTo;
                                   cmdInsertprdt.Parameters.Add("B_STS", OracleDbType.Int32).Value = objChkbk.ChkStatus;
                                   cmdInsertprdt.Parameters.Add("B_TEMPID", OracleDbType.Int32).Value = objChkbk.ChkTemp;
                                   cmdInsertprdt.Parameters.Add("B_CNCL_CHQ_STS", OracleDbType.Int32).Value = objChkbk.CancelChqSts;
                                   cmdInsertprdt.Parameters.Add("B_CNCLNUM", OracleDbType.Varchar2).Value = objChkbk.ChequeLfNums;
                                   cmdInsertprdt.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objChkbk.ChqCnclRsn;
                                   cmdInsertprdt.Parameters.Add("B_CHKBOOKID", OracleDbType.Varchar2).Value = objChkbk.ChkBookId;


                                   cmdInsertprdt.ExecuteNonQuery();
                               }
                           }
                       }

                       //Cancel the rows that have been cancelled when editing in Detail table
                       foreach (string strDtlId in strarrCancldtlIds)
                       {
                           if (strDtlId != "" && strDtlId != null)
                           {
                               int intDtlId = Convert.ToInt32(strDtlId);

                               string strQueryCancelDetail = "BANK_MASTER.SP_DEL_CHKBOOK_DETAILS";
                               using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                               {
                                   cmdCancelDetail.Transaction = trans;

                                   cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                   cmdCancelDetail.Parameters.Add("B_NEXTID", OracleDbType.Int32).Value = objEntityBank.BankId;
                                   cmdCancelDetail.Parameters.Add("B_CHKBOOKID", OracleDbType.Int32).Value = intDtlId;

                                   cmdCancelDetail.ExecuteNonQuery();
                               }
                           }
                       }
                       trans.Commit();
                   }
                   catch (Exception)
                   {

                       trans.Rollback();
                   }
               }
                
        }
        // This Method checks Bank name in the database for duplication.
        public string CheckBankName(clsEntityLayerBank objEntityBank)
        {

            string strQueryAddBank = "BANK_MASTER.SP_CHECK_BANK_NAME";
            OracleCommand cmdAddBankName = new OracleCommand();
            cmdAddBankName.CommandText = strQueryAddBank;
            cmdAddBankName.CommandType = CommandType.StoredProcedure;
            cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBank.BankId;
            cmdAddBankName.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityBank.BankName;
            cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
            cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
            cmdAddBankName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdAddBankName);
            string strReturn = cmdAddBankName.Parameters["B_COUNT"].Value.ToString();
            cmdAddBankName.Dispose();
            return strReturn;
        }
        //Method for cancel Bank details
        public void CancelBank(clsEntityLayerBank objEntityBank)
        {
            string strQueryCancelBank = "BANK_MASTER.SP_CANCEL_BANK_DETAILS";
            using (OracleCommand cmdCancelBank = new OracleCommand())
            {
                cmdCancelBank.CommandText = strQueryCancelBank;
                cmdCancelBank.CommandType = CommandType.StoredProcedure;
                cmdCancelBank.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBank.BankId;
                cmdCancelBank.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
                cmdCancelBank.Parameters.Add("B_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelBank.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objEntityBank.CanclReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelBank);
            }
        }


        // This Method will fetCH bank DEATILS BY ID
        public DataTable ReadBankById(clsEntityLayerBank objEntityBank)
        {
            string strQueryReadBankById = "BANK_MASTER.SP_READ_BANK_DETAILS_BY_ID";
            OracleCommand cmdReadBankById = new OracleCommand();
            cmdReadBankById.CommandText = strQueryReadBankById;
            cmdReadBankById.CommandType = CommandType.StoredProcedure;
            cmdReadBankById.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBank.BankId;
            cmdReadBankById.Parameters.Add("B_COPRID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
            cmdReadBankById.Parameters.Add("B_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankById);
            return dtCategory;
        }
        // This Method will fetch bank detail list
        public DataTable ReadBankDetailList(clsEntityLayerBank objEntityBank)
        {
            string strQueryReadVehicleClassList = "BANK_MASTER.SP_READ_BANK_DETAILS_LIST";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleClassList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBank.Organisation_id;
            cmdReadVehicleList.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBank.Corporate_id;
            cmdReadVehicleList.Parameters.Add("B_OPTION", OracleDbType.Int32).Value = objEntityBank.Status;
            cmdReadVehicleList.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityBank.CancelStatus;
            cmdReadVehicleList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityBank.CommonSearchTerm;
            cmdReadVehicleList.Parameters.Add("M_SEARCH_BANK", OracleDbType.Varchar2).Value = objEntityBank.SearchBank;
            cmdReadVehicleList.Parameters.Add("M_SEARCH_ACCOUNT", OracleDbType.Varchar2).Value = objEntityBank.SearchAccount;
            cmdReadVehicleList.Parameters.Add("M_SEARCH_IBAN", OracleDbType.Varchar2).Value = objEntityBank.SearchIban;
            cmdReadVehicleList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityBank.OrderColumn;
            cmdReadVehicleList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityBank.OrderMethod;
            cmdReadVehicleList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityBank.PageMaxSize;
            cmdReadVehicleList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityBank.PageNumber;

            cmdReadVehicleList.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }

        //Method for recall bank
        public void ReCallBank(clsEntityLayerBank objEntityBank)
        {
            string strQueryReCallBank = "BANK_MASTER.SP_RECALL_BANK";
            using (OracleCommand cmdReCallBank = new OracleCommand())
            {
                cmdReCallBank.CommandText = strQueryReCallBank;
                cmdReCallBank.CommandType = CommandType.StoredProcedure;
                cmdReCallBank.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBank.BankId;
                cmdReCallBank.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
                cmdReCallBank.Parameters.Add("B_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdReCallBank);
            }
        }
        public void ChangeStatus(clsEntityLayerBank objEntityBank)
        {
            string strQueryReCallBank = "BANK_MASTER.SP_CHANGE_STS_BANK";
            using (OracleCommand cmdReCallBank = new OracleCommand())
            {
                cmdReCallBank.CommandText = strQueryReCallBank;
                cmdReCallBank.CommandType = CommandType.StoredProcedure;
                cmdReCallBank.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBank.BankId;
                cmdReCallBank.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBank.User_Id;
                cmdReCallBank.Parameters.Add("B_STS", OracleDbType.Int32).Value = objEntityBank.Status;
                clsDataLayer.ExecuteNonQuery(cmdReCallBank);
            }
        }

    }
}