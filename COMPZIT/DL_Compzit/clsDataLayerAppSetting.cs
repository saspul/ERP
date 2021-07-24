using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;

namespace DL_Compzit
{
    public class clsDataLayerAppSetting
    {
        public void UpdateAppSettingHCM(clsEntityAppSetting objEntityAppSetting)
        {
            //OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                //tran = con.BeginTransaction();
                string str = "APPSETTING.SP_UPD_HCMAPPSETHCM";
                using (OracleCommand cmdRead = new OracleCommand(str, con))
                {
                    cmdRead.CommandText = str;
                    cmdRead.CommandType = CommandType.StoredProcedure;
                    //cmdReadPayGrd.Transaction = tran;

                    //leavesettlement
                    cmdRead.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAppSetting.Corp_Id;
                    cmdRead.Parameters.Add("A_LEVSTRTDT_HOLIDAYSTS", OracleDbType.Int32).Value = objEntityAppSetting.allowstart;
                    cmdRead.Parameters.Add("A_LEVEND_HOLIDAYSTS", OracleDbType.Int32).Value = objEntityAppSetting.allowend;
                    cmdRead.Parameters.Add("A_LEVSTRTDT_OFFDUTYSTS", OracleDbType.Int32).Value = objEntityAppSetting.allowoffday;
                    cmdRead.Parameters.Add("A_LEVEND_OFFDUTYSTS", OracleDbType.Int32).Value = objEntityAppSetting.blockoffday;
                    cmdRead.Parameters.Add("A_OFFDUTYDAYS_STATUS", OracleDbType.Int32).Value = objEntityAppSetting.calculateoffduty;
                    cmdRead.Parameters.Add("A_ELIGIBLE_LEAVE_STLMNT_LMT", OracleDbType.Int32).Value = objEntityAppSetting.leaveeligible;
                    cmdRead.Parameters.Add("A_EMPDLYHR_FUTURE_DAYS", OracleDbType.Int32).Value = objEntityAppSetting.attendancesheet;
                    if (objEntityAppSetting.leavesettlementdays != 0)
                    {
                        cmdRead.Parameters.Add("A_GN_LEAVE_SETTLE_DAYS", OracleDbType.Int32).Value = objEntityAppSetting.leavesettlementdays;
                    }
                    else
                    {
                        cmdRead.Parameters.Add("A_GN_LEAVE_SETTLE_DAYS", OracleDbType.Int32).Value = DBNull.Value;
                    }

                    //payroll
                    cmdRead.Parameters.Add("A_BASIC_PAY", OracleDbType.Int32).Value = objEntityAppSetting.basicpay;
                    cmdRead.Parameters.Add("A_PAYROLL_INDIVIDUAL_ROUND", OracleDbType.Int32).Value = objEntityAppSetting.payrollround;
                    cmdRead.Parameters.Add("A_COPRT_SALARY_DATE", OracleDbType.Date).Value = objEntityAppSetting.corpsalary;
                    cmdRead.Parameters.Add("A_GRATUITY_START_DATE", OracleDbType.Date).Value = objEntityAppSetting.gratuitystart;
                    cmdRead.Parameters.Add("A_ELIGIBLE_GRATUITY_DAYS", OracleDbType.Int32).Value = objEntityAppSetting.gratuitydays;
                    cmdRead.Parameters.Add("A_WORKDAY_FIXED_PAYRL_MODE", OracleDbType.Int32).Value = objEntityAppSetting.payrollworkday;
                    cmdRead.Parameters.Add("A_FIXED_PAYRL_MODE_JOIN", OracleDbType.Int32).Value = objEntityAppSetting.payrolljoin;


                    //dutyrejoin
                    cmdRead.Parameters.Add("A_REJOIN_CONFIRMATION_MODE", OracleDbType.Int32).Value = objEntityAppSetting.rejoinmode;
                    cmdRead.Parameters.Add("A_JOINING_DATE_LIMIT", OracleDbType.Int32).Value = objEntityAppSetting.joininglimit;

                    //employeesection
                    cmdRead.Parameters.Add("A_EMP_REF_FORMAT", OracleDbType.Varchar2).Value = objEntityAppSetting.employeereferenceformat;
                    cmdRead.Parameters.Add("A_EMPID_AUTOFILL_STS", OracleDbType.Int32).Value = objEntityAppSetting.employeestatus;

                    //mail

                    cmdRead.Parameters.Add("A_HR_EMAIL", OracleDbType.Varchar2).Value = objEntityAppSetting.hrmail;
                    cmdRead.Parameters.Add("A_RPLY_NO_MAIL", OracleDbType.Varchar2).Value = objEntityAppSetting.noreply;

                    //messbill

                    cmdRead.Parameters.Add("A_FOOD_AUTRTY_CAPTION", OracleDbType.Varchar2).Value = objEntityAppSetting.foodcaption;
                    cmdRead.Parameters.Add("A_FOOD_AUTRTY_NUMBER", OracleDbType.Varchar2).Value = objEntityAppSetting.safetynumber;

                    //general

                    cmdRead.Parameters.Add("A_MENU_STATUS", OracleDbType.Int32).Value = objEntityAppSetting.menubar;
                    cmdRead.Parameters.Add("A_FREQNT_COUNT", OracleDbType.Int32).Value = objEntityAppSetting.frequent;
                    cmdRead.Parameters.Add("A_RECNT_COUNT", OracleDbType.Int32).Value = objEntityAppSetting.recent;


                    clsDataLayer.ExecuteNonQuery(cmdRead);
                }
            }
        }
        public void UpdateAppSettingFAS(clsEntityAppSetting objEntityAppSetting)
        {
            //OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                //tran = con.BeginTransaction();
                string str = "APPSETTING.SP_UPD_HCMAPPSETFAS";
                using (OracleCommand cmdRead1 = new OracleCommand(str, con))
                {
                    cmdRead1.CommandText = str;
                    cmdRead1.CommandType = CommandType.StoredProcedure;
                    //cmdReadPayGrd.Transaction = tran;

                    //accountcode
                    cmdRead1.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAppSetting.Corp_Id;
                    cmdRead1.Parameters.Add("A_FMS_VIEW_CODE_STS", OracleDbType.Int32).Value = objEntityAppSetting.codestatus;
                    cmdRead1.Parameters.Add("A_FMS_CODE_FORMATE", OracleDbType.Int32).Value = objEntityAppSetting.codeformat;
                    cmdRead1.Parameters.Add("A_FMS_CODE_NUMBER_FORMAT", OracleDbType.Int32).Value = objEntityAppSetting.codeaddition;
                    
                    

                    //duplication
                    cmdRead1.Parameters.Add("A_FMS_LDGR_DUPLICATION", OracleDbType.Int32).Value = objEntityAppSetting.ledgerdup;
                    cmdRead1.Parameters.Add("A_FMS_PRDT_DUPLICATION", OracleDbType.Int32).Value = objEntityAppSetting.productdup;


                    //audit and acccount close
                    cmdRead1.Parameters.Add("A_FMS_SALE_PRCHS_VISBLE_STATUS", OracleDbType.Int32).Value = objEntityAppSetting.salesandpurchase;

                    cmdRead1.Parameters.Add("AUDIT_DEPNDENT_STATUS", OracleDbType.Int32).Value = objEntityAppSetting.auditing;
                    cmdRead1.Parameters.Add("REFNUM_ACCNTCLS_STS", OracleDbType.Int32).Value = objEntityAppSetting.accountclosing;

                    //emp-0043 start
                    //currency settings
                    cmdRead1.Parameters.Add("A_DEFLT_CURNCY_MST_ID", OracleDbType.Int32).Value = objEntityAppSetting.primarycurrency;


                    clsDataLayer.ExecuteNonQuery(cmdRead1);
                }
            }
        }
        public void UpdateAppSettingGeneral(clsEntityAppSetting objEntityAppSetting)
        {
            //OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                //tran = con.BeginTransaction();
                string str = "APPSETTING.SP_UPD_HCMAPPSETGENERAL";
                using (OracleCommand cmdRead2 = new OracleCommand(str, con))
                {
                    cmdRead2.CommandText = str;
                    cmdRead2.CommandType = CommandType.StoredProcedure;
                    //cmdReadPayGrd.Transaction = tran;

                    //taxation
                    cmdRead2.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAppSetting.Corp_Id;
                    cmdRead2.Parameters.Add("A_TAXATION_SYSTEM", OracleDbType.Varchar2).Value = objEntityAppSetting.taxsystem;
                    cmdRead2.Parameters.Add("A_GN_TAX_ENABLED", OracleDbType.Int32).Value = objEntityAppSetting.taxenabled;
                    cmdRead2.Parameters.Add("A_TAX_PERC_DECIMAL", OracleDbType.Int32).Value = objEntityAppSetting.taxdecimal;
                    



                    //color
                    cmdRead2.Parameters.Add("A_GN_APP_HEADER_COLOR", OracleDbType.Varchar2).Value = objEntityAppSetting.appheader;
                    cmdRead2.Parameters.Add("A_GN_APP_FOOTER_COLOR", OracleDbType.Varchar2).Value = objEntityAppSetting.appfooter;
                    cmdRead2.Parameters.Add("A_GN_SALES_HEADER_COLOR", OracleDbType.Varchar2).Value = objEntityAppSetting.salesheader;
                    cmdRead2.Parameters.Add("A_GN_SALES_FOOTER_COLOR", OracleDbType.Varchar2).Value = objEntityAppSetting.salesfooter;

                    //listing

                    cmdRead2.Parameters.Add("A_LISTING_MODE", OracleDbType.Int32).Value = objEntityAppSetting.listingmode;
                    cmdRead2.Parameters.Add("A_LISTING_MODE_SIZE", OracleDbType.Int32).Value = objEntityAppSetting.listingsize;
                    cmdRead2.Parameters.Add("A_ITEM_LISTING_MODE", OracleDbType.Int32).Value = objEntityAppSetting.itemlistingmode;


                    cmdRead2.Parameters.Add("A_CNCL_REASN_MUST", OracleDbType.Int32).Value = objEntityAppSetting.cancelreason;
                    //cmdRead2.Parameters.Add("A_CMN_IMAGE_PATH", OracleDbType.Varchar2).Value = objEntityAppSetting.imagepath;
                    cmdRead2.Parameters.Add("A_CMDTY_MANTN_OFFCE", OracleDbType.Int32).Value = objEntityAppSetting.commoditystatus;




                    clsDataLayer.ExecuteNonQuery(cmdRead2);
                }
            }
        }
    }
}