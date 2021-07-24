using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_FMS;

// CREATED BY:EVM-0002
// CREATED DATE:12/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding customer detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
    public class clsDataLayerCustomer
    {

        public void UpdateLedger(clsEntityLedger objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "CUSTOMER_MASTER.SP_UPD_LEDGER";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
            cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerName;
            cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
            cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
            cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
            cmdReadPayGrd.Parameters.Add("L_TDS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TDSstatus;
            cmdReadPayGrd.Parameters.Add("L_TCS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TCSstatus;
            cmdReadPayGrd.Parameters.Add("L_COST_STS", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterSts;
            cmdReadPayGrd.Parameters.Add("L_COMM_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactName;
            if (objEntityEmpSlry.LedgerZIP != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerZIP;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("L_TAX", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerTax;
            cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerAddess;
            cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            if (objEntityEmpSlry.TDSstatus == 0)
            {
                cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = objEntityEmpSlry.TDSid;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.TCSstatus == 0)
            {
                cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = objEntityEmpSlry.TCSid;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.DebitBalance != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.DebitBalance;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.CreditBalance != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditBalance;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = DBNull.Value;
            }

              if (objEntityEmpSlry.CreditBalance != -1)
            {
                cmdReadPayGrd.Parameters.Add("L_LDGR_MODE", OracleDbType.Decimal).Value = DBNull.Value;
               
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_LDGR_MODE", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditBalance;
            }

            if (objEntityEmpSlry.EffectiveDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = objEntityEmpSlry.EffectiveDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = DBNull.Value;
            }
            
            clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);


        }
        public string AddLedger(clsEntityLedger objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "CUSTOMER_MASTER.SP_ADD_LEDGER";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerName;
            cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
            cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
            cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
            cmdReadPayGrd.Parameters.Add("L_TDS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TDSstatus;
            cmdReadPayGrd.Parameters.Add("L_TCS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TCSstatus;
            cmdReadPayGrd.Parameters.Add("L_COST_STS", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterSts;
            cmdReadPayGrd.Parameters.Add("L_COMM_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactName;
            if (objEntityEmpSlry.LedgerZIP != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerZIP;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("L_TAX", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerTax;
            cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerAddess;
            cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            if (objEntityEmpSlry.TDSstatus == 0)
            {
                cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = objEntityEmpSlry.TDSid;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.TCSstatus == 0)
            {
                cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = objEntityEmpSlry.TCSid;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.DebitBalance != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.DebitBalance;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.CreditBalance != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditBalance;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("L_PAGE_STS", OracleDbType.Int32).Value = objEntityEmpSlry.PageSts;
            if (objEntityEmpSlry.EffectiveDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = objEntityEmpSlry.EffectiveDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityEmpSlry.CostCenterID != 0)
            {
                cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterID;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["L_ID"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;
        }


        // This Method adds customer details to the customer master table
        public int AddCustomer(clsEntityCustomer objEntityCustomer, List<clsEntityCustomer> objEntityMediaList, List<clsEntityCustomer> objEntityContactList)
        {
            //fetching next value

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddCustomer = "CUSTOMER_MASTER.SP_INSERT_CUSTOMER";
                    using (OracleCommand cmdAddCustomer = new OracleCommand(strQueryAddCustomer, con))
                    {

                        cmdAddCustomer.CommandType = CommandType.StoredProcedure;
                        //generate next value
                        //clsDataLayer objDataLayer = new clsDataLayer();
                        //clsEntityCommon objCommon = new clsEntityCommon();
                        //objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
                        //objCommon.CorporateID = objEntityCustomer.CorpId;
                        //string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);

                        //objEntityCustomer.Customer_Id = Convert.ToInt32(strNextValue);
                        cmdAddCustomer.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                        cmdAddCustomer.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Name;
                        cmdAddCustomer.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Group_Id;
                        cmdAddCustomer.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
                        cmdAddCustomer.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                        cmdAddCustomer.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityCustomer.Address1;
                        cmdAddCustomer.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityCustomer.Address2;
                        cmdAddCustomer.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityCustomer.Address3;
                        cmdAddCustomer.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntityCustomer.CountryId;
                        if (objEntityCustomer.StateId == 0)
                            cmdAddCustomer.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = null;
                        else
                            cmdAddCustomer.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityCustomer.StateId;
                        if (objEntityCustomer.CityId == 0)
                            cmdAddCustomer.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = null;
                        else
                            cmdAddCustomer.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCustomer.CityId;
                        cmdAddCustomer.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityCustomer.ZipCode;
                        cmdAddCustomer.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityCustomer.Phone_Number;
                        cmdAddCustomer.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntityCustomer.Mobile_Number;
                        cmdAddCustomer.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityCustomer.Web_Address;
                        cmdAddCustomer.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityCustomer.Email_Address;
                        cmdAddCustomer.Parameters.Add("C_PERIOD", OracleDbType.Int32).Value = objEntityCustomer.Customer_Credit_Period;
                        cmdAddCustomer.Parameters.Add("C_LIMIT", OracleDbType.Decimal).Value = objEntityCustomer.Customer_Credit_Limit;
                        cmdAddCustomer.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
                        cmdAddCustomer.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCustomer.UserId;
                        cmdAddCustomer.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCustomer.Date;
                        cmdAddCustomer.Parameters.Add("C_TIN_NUMBER", OracleDbType.Varchar2).Value = objEntityCustomer.TIN_Number;
                        if (objEntityCustomer.Payment_Terms != "")
                        {
                            cmdAddCustomer.Parameters.Add("C_PAYMENTTERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Payment_Terms;

                        }
                        else
                        {
                            cmdAddCustomer.Parameters.Add("C_PAYMENTTERMS", OracleDbType.Varchar2).Value = null;

                        }
                        cmdAddCustomer.Parameters.Add("C_CUSTOMERTYPE", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Type_Id;
                        if (objEntityCustomer.Price_Terms != "")
                        {
                            cmdAddCustomer.Parameters.Add("C_PRICE_TERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Price_Terms;
                        }
                        else
                        {
                            cmdAddCustomer.Parameters.Add("C_PRICE_TERMS", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityCustomer.Delivery_Terms != "")
                        {
                            cmdAddCustomer.Parameters.Add("C_DELIVERY_TERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Delivery_Terms;
                        }
                        else
                        {

                            cmdAddCustomer.Parameters.Add("C_DELIVERY_TERMS", OracleDbType.Varchar2).Value = null;
                        }
                        cmdAddCustomer.Parameters.Add("C_REFNUM", OracleDbType.Varchar2).Value = objEntityCustomer.CustomerRefnumber;
                        cmdAddCustomer.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityCustomer.LedgerSts;
                        if (objEntityCustomer.LedgerId != 0)
                        {
                            cmdAddCustomer.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityCustomer.LedgerId;
                        }
                        else
                        {
                            cmdAddCustomer.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddCustomer.Parameters.Add("L_CRDTLMT_RESTRICT", OracleDbType.Int32).Value = objEntityCustomer.CreditLimitRestrict;
                        cmdAddCustomer.Parameters.Add("L_CRDTLMT_WARN", OracleDbType.Int32).Value = objEntityCustomer.CreditLimitWarn;
                        cmdAddCustomer.Parameters.Add("L_CRDTPRD_RESTRICT", OracleDbType.Int32).Value = objEntityCustomer.CreditPeriodRestrict;
                        cmdAddCustomer.Parameters.Add("L_CRDTPRD_WARN", OracleDbType.Int32).Value = objEntityCustomer.CreditPeriodWarn;
                        cmdAddCustomer.ExecuteNonQuery();
                    }

                    //insert customer media details to the table
                    foreach (clsEntityCustomer objMedia in objEntityMediaList)
                    {
                        if (objMedia.Media_Description != "" && objMedia.Media_Description != null)
                        {
                            string strQueryInsertMediaDetail = "CUSTOMER_MASTER.SP_INSERT_MEDIA_DETAILS";
                            using (OracleCommand cmdAddInsertMediaDetail = new OracleCommand(strQueryInsertMediaDetail, con))
                            {
                                cmdAddInsertMediaDetail.Transaction = tran;

                                cmdAddInsertMediaDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertMediaDetail.Parameters.Add("C_MEDIAID", OracleDbType.Int32).Value = objMedia.Media_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("C_TRANSID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("C_DESCRIPTION", OracleDbType.Varchar2).Value = objMedia.Media_Description;
                                cmdAddInsertMediaDetail.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
                                cmdAddInsertMediaDetail.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                                cmdAddInsertMediaDetail.Parameters.Add("C_APPSECTION", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);

                                cmdAddInsertMediaDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    //insert customer extra contact details to the table
                    foreach (clsEntityCustomer objContact in objEntityContactList)
                    {
                        string strQueryInsertContactDetail = "CUSTOMER_MASTER.SP_INSERT_CUSTOMER_CONTACT";
                        using (OracleCommand cmdAddInsertContactDetail = new OracleCommand(strQueryInsertContactDetail, con))
                        {
                            cmdAddInsertContactDetail.Transaction = tran;

                            cmdAddInsertContactDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertContactDetail.Parameters.Add("C_CUSTOMERID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                            cmdAddInsertContactDetail.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objContact.Customer_Name;
                            cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS", OracleDbType.Varchar2).Value = objContact.Address1;
                            cmdAddInsertContactDetail.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objContact.Mobile_Number;
                            cmdAddInsertContactDetail.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objContact.Phone_Number;
                            cmdAddInsertContactDetail.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objContact.Email_Address;
                            cmdAddInsertContactDetail.Parameters.Add("C_EMAIL_ALWD", OracleDbType.Varchar2).Value = objContact.MailAllowed;
                            cmdAddInsertContactDetail.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objContact.Web_Address;
                            cmdAddInsertContactDetail.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                            cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS2", OracleDbType.Varchar2).Value = objContact.Address2;
                            cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS3", OracleDbType.Varchar2).Value = objContact.Address3;
                            cmdAddInsertContactDetail.ExecuteNonQuery();
                        }
                    }
                    if (objEntityCustomer.Update_Decide != 0 && objEntityCustomer.Lead_Id != 0)
                    {
                        string strQueryUpdate = "";
                        if (objEntityCustomer.Update_Decide == Convert.ToInt32(clsCommonLibrary.CustomerType.CUSTOMER))
                        {
                            strQueryUpdate = "LEAD_INDIVIDUAL.SP_UPDATE_CUSTOMER";
                        }
                        else if (objEntityCustomer.Update_Decide == Convert.ToInt32(clsCommonLibrary.CustomerType.CLIENT))
                        {
                            strQueryUpdate = "LEAD_INDIVIDUAL.SP_UPDATE_CLIENT";
                        }
                        else if (objEntityCustomer.Update_Decide == Convert.ToInt32(clsCommonLibrary.CustomerType.CONSULTANT))
                        {
                            strQueryUpdate = "LEAD_INDIVIDUAL.SP_UPDATE_CONSULTANT";
                        }
                        else if (objEntityCustomer.Update_Decide == Convert.ToInt32(clsCommonLibrary.CustomerType.CONTRACTOR))
                        {
                            strQueryUpdate = "LEAD_INDIVIDUAL.SP_UPDATE_CONTRACTOR";
                        }
                        using (OracleCommand cmdAddUpdate = new OracleCommand(strQueryUpdate, con))
                        {
                            cmdAddUpdate.Transaction = tran;

                            cmdAddUpdate.CommandType = CommandType.StoredProcedure;
                            cmdAddUpdate.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityCustomer.Lead_Id;
                            cmdAddUpdate.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;

                            cmdAddUpdate.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return objEntityCustomer.Customer_Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }
        //Method for change the active / inactive status of customer
        public void CustomerStatusChange(clsEntityCustomer objEntityCustomer)
        {
            string strQueryCustomerStatus = "CUSTOMER_MASTER.SP_UPDATE_STATUS";
            using (OracleCommand cmdCustomerStatus = new OracleCommand())
            {
                cmdCustomerStatus.CommandText = strQueryCustomerStatus;
                cmdCustomerStatus.CommandType = CommandType.StoredProcedure;
                cmdCustomerStatus.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                cmdCustomerStatus.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
                cmdCustomerStatus.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCustomer.UserId;
                cmdCustomerStatus.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCustomer.Date;
                clsDataLayer.ExecuteNonQuery(cmdCustomerStatus);
            }
        }

        //Method for Updating customer Details
        public void UpdateCustomer(clsEntityCustomer objEntityCustomer, List<clsEntityCustomer> objEntityMediaList, List<clsEntityCustomer> objEntityContactList)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {
                     string strQueryUpdateCustomer = "CUSTOMER_MASTER.SP_UPDATE_CUSTOMER";
                     using (OracleCommand cmdUpdateCustomer = new OracleCommand(strQueryUpdateCustomer, con))
                     {
                         cmdUpdateCustomer.CommandType = CommandType.StoredProcedure;
                         cmdUpdateCustomer.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                         cmdUpdateCustomer.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Name;
                         cmdUpdateCustomer.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Group_Id;
                         cmdUpdateCustomer.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
                         cmdUpdateCustomer.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                         cmdUpdateCustomer.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityCustomer.Address1;
                         cmdUpdateCustomer.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityCustomer.Address2;
                         cmdUpdateCustomer.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityCustomer.Address3;
                         cmdUpdateCustomer.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntityCustomer.CountryId;
                         if (objEntityCustomer.StateId == 0)
                             cmdUpdateCustomer.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = null;
                         else
                             cmdUpdateCustomer.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityCustomer.StateId;
                         if (objEntityCustomer.CityId == 0)
                             cmdUpdateCustomer.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = null;
                         else
                             cmdUpdateCustomer.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCustomer.CityId;
                         cmdUpdateCustomer.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityCustomer.ZipCode;
                         cmdUpdateCustomer.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityCustomer.Phone_Number;
                         cmdUpdateCustomer.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntityCustomer.Mobile_Number;
                         cmdUpdateCustomer.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityCustomer.Web_Address;
                         cmdUpdateCustomer.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityCustomer.Email_Address;
                         cmdUpdateCustomer.Parameters.Add("C_PERIOD", OracleDbType.Int32).Value = objEntityCustomer.Customer_Credit_Period;
                         cmdUpdateCustomer.Parameters.Add("C_LIMIT", OracleDbType.Decimal).Value = objEntityCustomer.Customer_Credit_Limit;
                         cmdUpdateCustomer.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
                         cmdUpdateCustomer.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCustomer.UserId;
                         cmdUpdateCustomer.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCustomer.Date;
                         cmdUpdateCustomer.Parameters.Add("C_TIN_NUMBER", OracleDbType.Varchar2).Value = objEntityCustomer.TIN_Number;
                         if (objEntityCustomer.Payment_Terms != "")
                         {
                             cmdUpdateCustomer.Parameters.Add("C_PAYMENTTERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Payment_Terms;

                         }
                         else
                         {
                             cmdUpdateCustomer.Parameters.Add("C_PAYMENTTERMS", OracleDbType.Varchar2).Value = null;

                         }
                         cmdUpdateCustomer.Parameters.Add("C_CUSTOMERTYPE", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Type_Id;
                         if (objEntityCustomer.Price_Terms != "")
                         {
                             cmdUpdateCustomer.Parameters.Add("C_PRICE_TERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Price_Terms;
                         }
                         else
                         {
                             cmdUpdateCustomer.Parameters.Add("C_PRICE_TERMS", OracleDbType.Varchar2).Value = null;

                         }
                         if (objEntityCustomer.Delivery_Terms != "")
                         {
                             cmdUpdateCustomer.Parameters.Add("C_DELIVERY_TERMS", OracleDbType.Varchar2).Value = objEntityCustomer.Delivery_Terms;
                         }
                         else
                         {

                             cmdUpdateCustomer.Parameters.Add("C_DELIVERY_TERMS", OracleDbType.Varchar2).Value = null;
                         }
                         cmdUpdateCustomer.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityCustomer.LedgerSts;
                         if (objEntityCustomer.LedgerId != 0)
                         {
                             cmdUpdateCustomer.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityCustomer.LedgerId;
                         }
                         else
                         {
                             cmdUpdateCustomer.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                         }
                         cmdUpdateCustomer.Parameters.Add("L_CRDTLMT_RESTRICT", OracleDbType.Int32).Value = objEntityCustomer.CreditLimitRestrict;
                         cmdUpdateCustomer.Parameters.Add("L_CRDTLMT_WARN", OracleDbType.Int32).Value = objEntityCustomer.CreditLimitWarn;
                         cmdUpdateCustomer.Parameters.Add("L_CRDTPRD_RESTRICT", OracleDbType.Int32).Value = objEntityCustomer.CreditPeriodRestrict;
                         cmdUpdateCustomer.Parameters.Add("L_CRDTPRD_WARN", OracleDbType.Int32).Value = objEntityCustomer.CreditPeriodWarn;
                         cmdUpdateCustomer.ExecuteNonQuery();
                     }
                     //delete media details based on current customer id
                     string strQueryDeleteMedia = "CUSTOMER_MASTER.SP_DELETE_MEDIA_DTLS";
                     using (OracleCommand cmdDeleteMedia = new OracleCommand(strQueryDeleteMedia, con))
                     {
                         cmdDeleteMedia.Transaction = tran;

                         cmdDeleteMedia.CommandType = CommandType.StoredProcedure;
                         cmdDeleteMedia.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;

                         cmdDeleteMedia.ExecuteNonQuery();
                     }

                     //insert media list
                     foreach (clsEntityCustomer objMedia in objEntityMediaList)
                     {
                         if (objMedia.Media_Description != "" && objMedia.Media_Description != null)
                         {
                             string strQueryInsertMediaDetail = "CUSTOMER_MASTER.SP_INSERT_MEDIA_DETAILS";
                             using (OracleCommand cmdAddInsertMediaDetail = new OracleCommand(strQueryInsertMediaDetail, con))
                             {
                                 cmdAddInsertMediaDetail.Transaction = tran;

                                 cmdAddInsertMediaDetail.CommandType = CommandType.StoredProcedure;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_MEDIAID", OracleDbType.Int32).Value = objMedia.Media_Id;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_TRANSID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_DESCRIPTION", OracleDbType.Varchar2).Value = objMedia.Media_Description;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                                 cmdAddInsertMediaDetail.Parameters.Add("C_APPSECTION", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);

                                 cmdAddInsertMediaDetail.ExecuteNonQuery();
                             }
                         }
                     }

                     //delete customer extra contact details based on customer id
                     string strQueryDeleteConatct = "CUSTOMER_MASTER.SP_DELETE_CUSTOMER_CONTACT";
                     using (OracleCommand cmdDeleteContact = new OracleCommand(strQueryDeleteConatct, con))
                     {
                         cmdDeleteContact.Transaction = tran;

                         cmdDeleteContact.CommandType = CommandType.StoredProcedure;
                         cmdDeleteContact.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;

                         cmdDeleteContact.ExecuteNonQuery();
                     }

                     //insert customer extra contact details to the table
                     foreach (clsEntityCustomer objContact in objEntityContactList)
                     {
                         string strQueryInsertContactDetail = "CUSTOMER_MASTER.SP_INSERT_CUSTOMER_CONTACT";
                         using (OracleCommand cmdAddInsertContactDetail = new OracleCommand(strQueryInsertContactDetail, con))
                         {
                             cmdAddInsertContactDetail.Transaction = tran;

                             cmdAddInsertContactDetail.CommandType = CommandType.StoredProcedure;
                             cmdAddInsertContactDetail.Parameters.Add("C_CUSTOMERID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                             cmdAddInsertContactDetail.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objContact.Customer_Name;
                             cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS", OracleDbType.Varchar2).Value = objContact.Address1;
                             cmdAddInsertContactDetail.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objContact.Mobile_Number;
                             cmdAddInsertContactDetail.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objContact.Phone_Number;
                             cmdAddInsertContactDetail.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objContact.Email_Address;
                             cmdAddInsertContactDetail.Parameters.Add("C_EMAIL_ALWD", OracleDbType.Varchar2).Value = objContact.MailAllowed;
                             cmdAddInsertContactDetail.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objContact.Web_Address;
                             cmdAddInsertContactDetail.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                             cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS2", OracleDbType.Varchar2).Value = objContact.Address2;
                             cmdAddInsertContactDetail.Parameters.Add("C_ADDRESS3", OracleDbType.Varchar2).Value = objContact.Address3;
                             cmdAddInsertContactDetail.ExecuteNonQuery();
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

        //Method for cancel customer
        public void CancelCustomer(clsEntityCustomer objEntityCustomer)
        {
            string strQueryCancelCustomer = "CUSTOMER_MASTER.SP_CANCEL_CUSTOMER";
            using (OracleCommand cmdCancelCustomer = new OracleCommand())
            {
                cmdCancelCustomer.CommandText = strQueryCancelCustomer;
                cmdCancelCustomer.CommandType = CommandType.StoredProcedure;
                cmdCancelCustomer.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                cmdCancelCustomer.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCustomer.UserId;
                cmdCancelCustomer.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCustomer.Date;
                cmdCancelCustomer.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCustomer.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCustomer);
            }
        }

        // This Method checks customer name in the database for duplication.
        public string CheckCustomerName(clsEntityCustomer objEntityCustomer)
        {
            string strQueryCheckCustomerName = "CUSTOMER_MASTER.SP_CHECK_CUSTOMER_NAME";
            OracleCommand cmdCheckCustomerName = new OracleCommand();
            cmdCheckCustomerName.CommandText = strQueryCheckCustomerName;
            cmdCheckCustomerName.CommandType = CommandType.StoredProcedure;
            cmdCheckCustomerName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdCheckCustomerName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Name;
            cmdCheckCustomerName.Parameters.Add("C_TYPID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Type_Id;
            cmdCheckCustomerName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdCheckCustomerName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdCheckCustomerName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCustomerName);
            string strReturn = cmdCheckCustomerName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCustomerName.Dispose();
            return strReturn;
        }

        // This Method will fetch customer table by ID
        public DataTable ReadCustomerById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadCustomerById = "CUSTOMER_MASTER.SP_READ_CUSTOMER_BYID";
            OracleCommand cmdReadCustomerById = new OracleCommand();
            cmdReadCustomerById.CommandText = strQueryReadCustomerById;
            cmdReadCustomerById.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadCustomerById.Parameters.Add("C_COPRID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdReadCustomerById.Parameters.Add("C_CUSTOMER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadCustomerById);
            return dtCustomer;
        }

        //fetch customer type 
        public DataTable ReadCustomerType(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadCustomerType = "CUSTOMER_MASTER.SP_READ_CUSTOMER_TYPE";
            OracleCommand cmdReadCustomerType = new OracleCommand();
            cmdReadCustomerType.CommandText = strQueryReadCustomerType;
            cmdReadCustomerType.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerType.Parameters.Add("C_TYPID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Type_Id;
            cmdReadCustomerType.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtType = new DataTable();
            dtType = clsDataLayer.ExecuteReader(cmdReadCustomerType);
            return dtType;
        }

        // This Method will fetch customer group based on corporate office
        public DataTable ReadCustomerGroup(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadCustomerGroup = "CUSTOMER_MASTER.SP_READ_CUSTOMER_GROUP";
            OracleCommand cmdReadCustomerGroup = new OracleCommand();
            cmdReadCustomerGroup.CommandText = strQueryReadCustomerGroup;
            cmdReadCustomerGroup.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerGroup.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadCustomerGroup.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdReadCustomerGroup.Parameters.Add("C_GROUP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtGroup = new DataTable();
            dtGroup = clsDataLayer.ExecuteReader(cmdReadCustomerGroup);
            return dtGroup;
        }

        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "CUSTOMER_MASTER.SP_READ_COUNTRY";
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

        //Methode for fetch state master details of selected country from database.
        public DataTable ReadState(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadState = "CUSTOMER_MASTER.SP_READ_STATE";
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryReadState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityCustomer.CountryId;
                cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadState = new DataTable();
                dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                return dtReadState;
            }
        }

        //Method for fetch city master details of selected state from datatbase.
        public DataTable ReadCity(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadState = "CUSTOMER_MASTER.SP_READ_CITY";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCustomer.StateId;
                cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }

        //methode for read customer list 
        public DataTable Read_Customer_List(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadCustomerList = "CUSTOMER_MASTER.SP_READ_CUSTOMER_LIST";
            OracleCommand cmdReadCustomerList = new OracleCommand();
            cmdReadCustomerList.CommandText = strQueryReadCustomerList;
            cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadCustomerList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdReadCustomerList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerList = new DataTable();
            dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
            return dtCustomerList;
        }

        
        //methode for read customer list based on customer name
        //public DataTable Read_Customer_List_BySearch(clsEntityCustomer objEntityCustomer)
        //{
        //    string strQueryReadCustomerList = "CUSTOMER_MASTER.SP_READ_CUSTOMER_BYSEARCH";
        //    OracleCommand cmdReadCustomerList = new OracleCommand();
        //    cmdReadCustomerList.CommandText = strQueryReadCustomerList;
        //    cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
        //    if (objEntityCustomer.Customer_Name == "")
        //    {
        //        cmdReadCustomerList.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = null;
        //    }
        //    else
        //    {
        //        cmdReadCustomerList.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.Customer_Name;
        //    }
        //    cmdReadCustomerList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
        //    cmdReadCustomerList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
        //    cmdReadCustomerList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
        //    cmdReadCustomerList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCustomer.Cancel_Status;
        //    cmdReadCustomerList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtCustomerList = new DataTable();
        //    dtCustomerList = clsDataLayer.ExecuteReader(cmdReadCustomerList);
        //    return dtCustomerList;
        //}

        //fetch media master  
        public DataTable Read_Customer_List_BySearch(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadMailConsole = "CUSTOMER_MASTER.SP_READ_CUSTOMER_TABLE";
            using (OracleCommand cmdReadMailConsole = new OracleCommand())
            {
                cmdReadMailConsole.CommandText = strQueryReadMailConsole;
                cmdReadMailConsole.CommandType = CommandType.StoredProcedure;
                cmdReadMailConsole.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
                cmdReadMailConsole.Parameters.Add("C_TYPE", OracleDbType.Int32).Value = objEntityCustomer.Customer_Type_Id;
                cmdReadMailConsole.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCustomer.Cancel_Status;
                cmdReadMailConsole.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
                cmdReadMailConsole.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
                cmdReadMailConsole.Parameters.Add("C_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityCustomer.CommonSearchTerm;
                cmdReadMailConsole.Parameters.Add("C_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityCustomer.SearchCusName;
                cmdReadMailConsole.Parameters.Add("C_SEARCH_ADDRESS", OracleDbType.Varchar2).Value = objEntityCustomer.SearchAdress;
                cmdReadMailConsole.Parameters.Add("C_SEARCH_GROUP", OracleDbType.Varchar2).Value = objEntityCustomer.SearchGroup;
                cmdReadMailConsole.Parameters.Add("C_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityCustomer.SearchType;
                cmdReadMailConsole.Parameters.Add("C_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityCustomer.SearchRef;
                cmdReadMailConsole.Parameters.Add("C_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityCustomer.OrderColumn;
                cmdReadMailConsole.Parameters.Add("C_ORDER_METHOD", OracleDbType.Int32).Value = objEntityCustomer.OrderMethod;
                cmdReadMailConsole.Parameters.Add("C_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityCustomer.PageMaxSize;
                cmdReadMailConsole.Parameters.Add("C_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityCustomer.PageNumber;
                cmdReadMailConsole.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMailConsole = new DataTable();
                dtMailConsole = clsDataLayer.SelectDataTable(cmdReadMailConsole);
                return dtMailConsole;
            }
        }

        public DataTable Read_Media_Master()
        {
            string strQueryMediaMaster = "CUSTOMER_MASTER.SP_READ_MEDIA_MASTER";
            OracleCommand cmdReadMediaMaster = new OracleCommand();
            cmdReadMediaMaster.CommandText = strQueryMediaMaster;
            cmdReadMediaMaster.CommandType = CommandType.StoredProcedure;
            cmdReadMediaMaster.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMedia = new DataTable();
            dtMedia = clsDataLayer.ExecuteReader(cmdReadMediaMaster);
            return dtMedia;
        }


        //fetch customer contact details based on customer id
        public DataTable Read_Contact_DetailsById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadContact = "CUSTOMER_MASTER.SP_READ_CONTACT_BYID";
            OracleCommand cmdReadContact = new OracleCommand();
            cmdReadContact.CommandText = strQueryReadContact;
            cmdReadContact.CommandType = CommandType.StoredProcedure;
            cmdReadContact.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadContact.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtContact = new DataTable();
            dtContact = clsDataLayer.ExecuteReader(cmdReadContact);
            return dtContact;
        }

        //fetch customer media details based on customer id
        public DataTable Read_Media_DetailsById(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadMedia = "CUSTOMER_MASTER.SP_READ_MEDIA_BYID";
            OracleCommand cmdReadMedia = new OracleCommand();
            cmdReadMedia.CommandText = strQueryReadMedia;
            cmdReadMedia.CommandType = CommandType.StoredProcedure;
            cmdReadMedia.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
            cmdReadMedia.Parameters.Add("C_SECTIONID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
            cmdReadMedia.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMedia = new DataTable();
            dtMedia = clsDataLayer.ExecuteReader(cmdReadMedia);
            return dtMedia;
        }

        // THIS PROCEDURE FETCHES TERMS BASED ON CORPORATE AND ORGANIZATION AND QUOTATION TEMPLATE ID
        public DataTable ReadTermTemplate(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadTermTemplate = "CUSTOMER_MASTER.SP_READ_TERM_TEMPLATES";
            OracleCommand cmdReadTermTemplate = new OracleCommand();
            cmdReadTermTemplate.CommandText = strQueryReadTermTemplate;
            cmdReadTermTemplate.CommandType = CommandType.StoredProcedure;
            cmdReadTermTemplate.Parameters.Add("C_TEMPLATETYPEID", OracleDbType.Int32).Value = objEntityCustomer.TemplateTypeId;
            cmdReadTermTemplate.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadTermTemplate.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdReadTermTemplate.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplateDtl = new DataTable();
            dtTemplateDtl = clsDataLayer.ExecuteReader(cmdReadTermTemplate);
            return dtTemplateDtl;
        }

        // THIS method FETCHES TERM DESCRIPTION BASED ON CORPORATE AND ORGANIZATION AND TERM TEMPLATE ID
        public DataTable ReadSelectedTermDtl(clsEntityCustomer objEntityCustomer)
        {
            string strQueryReadTermDtl = "CUSTOMER_MASTER.SP_RD_SELECTED_TERM_TMPLT_DTL";
            OracleCommand cmdReadTermDtl = new OracleCommand();
            cmdReadTermDtl.CommandText = strQueryReadTermDtl;
            cmdReadTermDtl.CommandType = CommandType.StoredProcedure;
            cmdReadTermDtl.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadTermDtl.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCustomer.CorpId;
            cmdReadTermDtl.Parameters.Add("C_TERM_TEMPLATE_ID", OracleDbType.Int32).Value = objEntityCustomer.TermTemplateId;
            cmdReadTermDtl.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplateDtl = new DataTable();
            dtTemplateDtl = clsDataLayer.ExecuteReader(cmdReadTermDtl);
            return dtTemplateDtl;
        }
        public void UpdateStatus(clsEntityCustomer objEntityCustomer)
        {

            string strQueryAddMailConsole = "CUSTOMER_MASTER.SP_UPDATE_STATUS";
            using (OracleCommand cmdUpdateMail = new OracleCommand())
            {
                cmdUpdateMail.CommandText = strQueryAddMailConsole;
                cmdUpdateMail.CommandType = CommandType.StoredProcedure;
                cmdUpdateMail.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCustomer.Customer_Id;
                cmdUpdateMail.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCustomer.UserId;
                cmdUpdateMail.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCustomer.Date;
                cmdUpdateMail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCustomer.Customer_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateMail);
            }
        }
    }
}

