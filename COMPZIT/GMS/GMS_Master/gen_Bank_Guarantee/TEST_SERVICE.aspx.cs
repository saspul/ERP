using System;
using System.IO;
using System.Net.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using DataLayerMailUtility;
using System.Web;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using HashingUtility;
using OpenPop;
using OpenPop.Mime;
using BL_Compzit;
using System.Windows;
using OpenPop.Mime.Header;
//using System.Web.Mail;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using EL_Compzit;
using System.Net.Mail;

public partial class GMS_GMS_Master_gen_Bank_Guarantee_TEST_SERVICE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        string strCommonPath = "ServiceError\\GMS_Mail.txt";
        string strFilePath = strServerPath + strCommonPath;

        //if any exception on the time of mail fetching
        if (File.Exists(strFilePath))
        {
            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(strFilePath, "Mail Send Start");
        }

        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        DateTime dtDateNow = DateTime.Now;
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);

        DateTime dateRfqCloseDate = DateTime.MinValue;
        DataTable dtReqstGuarnteedetails = objBusnssTemMailServce.ReqstGuarnteedetails(EntityTemMailServce);
        if (dtReqstGuarnteedetails.Rows.Count > 0)
        {
            foreach (DataRow rowrqst in dtReqstGuarnteedetails.Rows)
            {
                dateRfqCloseDate = objCommon.textToDateTime(rowrqst["RFQ_CLOSING_DATE"].ToString());
                if (dtDateNow >= dateRfqCloseDate)
                {
                    EntityTemMailServce.ReqstGrntId = Convert.ToInt32(rowrqst["RFQ_ID"].ToString());
                    objBusnssTemMailServce.UpdateRfqCloseDate(EntityTemMailServce);
                }
            }
        }


        //hiddenCurrentDate.Value = strCurrentDate;
        DataTable dtBankGuaranteeDtls = objBusnssTemMailServce.ReadBankDetails(EntityTemMailServce);
        int intTimeDiff = 0, intdays = 0, inthour = 0, intSectId = 0;
        DateTime dtdatehourDiff;
        //DateTime dtDateNow = DateTime.Now;


        if (dtBankGuaranteeDtls.Rows.Count > 0)
        {
            foreach (DataRow row in dtBankGuaranteeDtls.Rows)
            {
                DateTime dateExpiredte = DateTime.MinValue;
                if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                {
                    dateExpiredte = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                }
                DateTime dateGuarnteeDate = new DateTime();
                if (row["GUARANTEE_DATE"].ToString() != "")
                {
                    dateGuarnteeDate = objCommon.textToDateTime(row["GUARANTEE_DATE"].ToString());
                }
                int inttempltAlertOptn = Convert.ToInt32(row["GRNT_TMALRT_OPT"].ToString());
                EntityTemMailServce.GuaranteeId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                int intCorpId = 0;
                intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
                EntityTemMailServce.CorpOffice_Id = intCorpId;
                DataTable dtGR = objBusnssTemMailServce.ReadGuranteeById(EntityTemMailServce);
                EntityTemMailServce.TempAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());

                int intGurntId = 0, intTemAlertId = 0, GuarntypeChk = 0;
                string strRefNo = "", strGurantTyp = "";
                strGurantTyp = row["GUARNTYPE_ID"].ToString();
                if (strGurantTyp == "101")
                {
                    GuarntypeChk = 1;
                }
                strRefNo = row["GUARANTEE_REF_NUM"].ToString();
                intGurntId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                intTemAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());
                if (row["GRTY_TMDTL_DASHBOARD"].ToString() != "0" || row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                {
                    if (row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                    {
                        DataTable dtMailServce;
                        string MailAddress = "";
                        // MailAddress = "ajinks@volviar.com";
                        //TempMailSend(MailAddress);TemAlertId

                        string strMailSndNot = row["GRNT_MAILSEND_STS"].ToString();
                        if (inttempltAlertOptn != 3)
                        {
                            intSectId = Convert.ToInt32(row["GRNT_NTFY_ID"].ToString());
                            EntityTemMailServce.EmployeId = intSectId;
                        }

                        if (row["GRTY_TMDTL_PERIOD"].ToString() == "1")
                        {
                            if (GuarntypeChk != 1)
                            {
                                inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                dtdatehourDiff = dateExpiredte.AddHours(-(inthour));


                                if (dtDateNow >= dtdatehourDiff)
                                {
                                    if (strMailSndNot == "0")
                                    {

                                        if (inttempltAlertOptn == 0)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                        }
                                        else if (inttempltAlertOptn == 1)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                foreach (DataRow roww in dtMailServce.Rows)
                                                {


                                                    MailAddress = roww["USR_EMAIL"].ToString();

                                                    //MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                }
                                            }


                                        }
                                        else if (inttempltAlertOptn == 2)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                            MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                        }
                                        else if (inttempltAlertOptn == 3)
                                        {
                                            string strMailAddrs = "";
                                            dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                string[] strAddrs = strMailAddrs.Split(',');
                                                foreach (string str in strAddrs)
                                                {
                                                    MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                dtdatehourDiff = dateGuarnteeDate.AddHours((inthour));
                                if (dtDateNow >= dtdatehourDiff)
                                {
                                    if (strMailSndNot == "0")
                                    {

                                        if (inttempltAlertOptn == 0)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                        }
                                        else if (inttempltAlertOptn == 1)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                foreach (DataRow roww in dtMailServce.Rows)
                                                {


                                                    MailAddress = roww["USR_EMAIL"].ToString();

                                                    //MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                }
                                            }


                                        }
                                        else if (inttempltAlertOptn == 2)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                            MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                        }
                                        else if (inttempltAlertOptn == 3)
                                        {
                                            string strMailAddrs = "";
                                            dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                string[] strAddrs = strMailAddrs.Split(',');
                                                foreach (string str in strAddrs)
                                                {
                                                    MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else if (row["GRTY_TMDTL_PERIOD"].ToString() == "2")
                        {
                            if (GuarntypeChk != 1)
                            {
                                intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                                {
                                    EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                                }


                                //  intTimeDiff = Math.Abs(Convert.ToInt32(dateExpiredte.ToShortTimeString()) - Convert.ToInt32(dateCurrntdte.ToShortTimeString()));
                                intTimeDiff = Convert.ToInt32((dateExpiredte - dateCurrntdte).TotalDays);
                                if (intdays >= intTimeDiff)
                                {
                                    if (strMailSndNot == "0")
                                    {

                                        if (inttempltAlertOptn == 0)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                        }
                                        else if (inttempltAlertOptn == 1)
                                        {


                                            dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                foreach (DataRow roww in dtMailServce.Rows)
                                                {


                                                    MailAddress = roww["USR_EMAIL"].ToString();

                                                    //MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                }
                                            }

                                        }
                                        else if (inttempltAlertOptn == 2)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                            MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                        }
                                        else if (inttempltAlertOptn == 3)
                                        {
                                            //string strMailAddrs = "";
                                            string strMailAddrs = "";
                                            dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                string[] strAddrs = strMailAddrs.Split(',');
                                                foreach (string str in strAddrs)
                                                {
                                                    MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                        }


                                    }


                                }
                            }
                            else
                            {
                                intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                intdays++;
                                DateTime dateExpGurntDate = dateGuarnteeDate.AddDays(intdays);
                                if (dtDateNow >= dateExpGurntDate)
                                {

                                    if (strMailSndNot == "0")
                                    {

                                        if (inttempltAlertOptn == 0)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                        }
                                        else if (inttempltAlertOptn == 1)
                                        {


                                            dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                foreach (DataRow roww in dtMailServce.Rows)
                                                {


                                                    MailAddress = roww["USR_EMAIL"].ToString();

                                                    //MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                }
                                            }

                                        }
                                        else if (inttempltAlertOptn == 2)
                                        {
                                            dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                            MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                        }
                                        else if (inttempltAlertOptn == 3)
                                        {
                                            //string strMailAddrs = "";
                                            string strMailAddrs = "";
                                            dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                            if (dtMailServce.Rows.Count > 0)
                                            {
                                                strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                string[] strAddrs = strMailAddrs.Split(',');
                                                foreach (string str in strAddrs)
                                                {
                                                    MailAddress = str;
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                        }


                                    }


                                }

                            }
                        }

                    }

                }



            }
        }
    }
    public void TempMailSend(string MailAddress, int intCorpId, int intGurntId, string strRefNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId, DataTable dtGR)
    {

        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


        EntityTemMailServce.CorpOffice_Id = intCorpId;
        EntityTemMailServce.GuaranteeId = intGurntId;
        EntityTemMailServce.TempAlertId = intTemAlertId;
        EntityTemMailServce.MailMOdule = "RFG";
        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        MailMessage mail = new MailMessage();
        DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
        DataTable dtUserDetails = new DataTable();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string g_Ref = "";
        string g_Mode = "";
        string g_Type = "";
        string g_ExDate = "";
        string g_Projct_Ref = "";
        string g_Projct_Name = "";
        string g_Contact_PName = "";
        string g_Cont_PEmail = "";
        string g_Bank_gurn_date = "";
        string g_Cust_SupplierName = "";
        string g_Amount = "";
        string g_CurrencyType = "";
        string g_BankName = "";
        // string g_Per_No = "";
        if (dtGR.Rows.Count > 0)
        {
            /////
            //FOR TRACKING TABLE
            EntityTemMailServce.Organisation_Id = Convert.ToInt32(dtGR.Rows[0]["ORG_ID"].ToString());
            EntityTemMailServce.RefNumber = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();

            if (dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString() != "")
            {
                g_Ref = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            }



            if (dtGR.Rows[0]["GUARNTMODE_NAME"].ToString() != "")
            {
                g_Mode = dtGR.Rows[0]["GUARNTMODE_NAME"].ToString();
            }

            if (dtGR.Rows[0]["GUARNTYPE_NAME"].ToString() != "")
            {
                g_Type = dtGR.Rows[0]["GUARNTYPE_NAME"].ToString();
            }
            else
            {
                g_Type = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString() != "")
            {
                g_ExDate = dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString();
            }


            if (dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
            {
                g_Projct_Ref = dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            }
            else
            {

                g_Projct_Ref = "";
            }

            if (dtGR.Rows[0]["PROJECT_NAME"].ToString() != "")
            {
                g_Projct_Name = dtGR.Rows[0]["PROJECT_NAME"].ToString();
            }
            else
            {

                g_Projct_Name = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString() != "")
            {
                g_Contact_PName = dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString();
            }
            else
            {
                g_Contact_PName = "";
            }

            if (dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString() != "")
            {
                g_Cont_PEmail = dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString();
            }
            else
            {
                g_Cont_PEmail = "";
            }

            //if (dtGR.Rows[0]["USR_NAME"].ToString() != "")
            //{
            //    g_Per_No = dtGR.Rows[0]["USR_NAME"].ToString();
            //}
            //else
            //{
            //    g_Per_No = "";
            //}
            if (dtGR.Rows[0]["GUARANTEE_DATE"].ToString() != "")
            {
                g_Bank_gurn_date = dtGR.Rows[0]["GUARANTEE_DATE"].ToString();
            }
            else
            {
                g_Bank_gurn_date = "";
            }
            //Mod by EVM-0012
            if (dtGR.Rows[0]["CSTMR_NAME"].ToString() != "")
            {
                g_Cust_SupplierName = dtGR.Rows[0]["CSTMR_NAME"].ToString();
            }
            else
            {
                g_Cust_SupplierName = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString() != "")
            {
                string strAmount = dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                g_Amount = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
            }
            else
            {
                g_Amount = "";
            }
            if (dtGR.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                g_CurrencyType = dtGR.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            else
            {
                g_CurrencyType = "";
            }
            if (dtGR.Rows[0]["BANK_NAME"].ToString() != "")
            {
                g_BankName = dtGR.Rows[0]["BANK_NAME"].ToString();
            }
            else
            {
                g_BankName = "";
            }

        }

        string content = "";
        if (GuarntypeChk != 1)
        {
            content = " Dear Sir/Madam,<br/><br/> The below guarantee will expire on Date " + g_ExDate + ".";
        }
        else
        {
            content = " Dear Sir/Madam,<br/><br/> The below guarantee created on Date " + g_Bank_gurn_date + ".";
        }
        content += "<br/><br/><b><u>Guarantee Management System Notification</u></b>";
        //Evm-0012
        //table
        content += "<br/><br/><br/><table>";
        if (g_Cust_SupplierName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Customer/Supplier&emsp;</th><td>:&emsp;" + g_Cust_SupplierName + "</td></tr>";


        }

        if (g_Amount != "")
        {

            content += "<tr style=\"text-align: left;\"><th>Amount&emsp;</th><td>:&emsp;" + g_Amount + " " + g_CurrencyType + "</td></tr>";
        }


        if (g_BankName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Bank name&emsp;</th><td>:&emsp;" + g_BankName + "</td></tr>";

        }


        if (g_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Ref #&emsp;</th><td>:&emsp;" + g_Ref + "</td></tr>";
        }
        if (g_Mode != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Mode&emsp;</th><td>:&emsp;" + g_Mode + "</td></tr>";
        }
        if (g_Type != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Type&emsp;</th><td>:&emsp;" + g_Type + "</td></tr>";
        }
        if (GuarntypeChk != 1)
        {
            if (g_ExDate != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Expiry Date&emsp;</th><td>:&emsp;" + g_ExDate + "</td></tr>";
            }
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Ref&emsp;</th><td>:&emsp;" + g_Projct_Ref + "</td></tr>";
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Name&emsp;</th><td>:&emsp;" + g_Projct_Name + "</td></tr>";
        }
        if (g_Contact_PName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Name&emsp;</th><td>:&emsp;" + g_Contact_PName + "</td></tr>";

        }
        if (g_Cont_PEmail != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Email&emsp;</th><td>:&emsp;" + g_Cont_PEmail + "</td></tr>";

        }
        content += "</table>";

        content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
        content += "<br/><br/><br/>Best Regards,";
        content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


        if (dtFromMail.Rows.Count > 0)
        {

            objEntityMail.To_Email_Address = MailAddress;
            objEntityMail.Email_Subject = "BANK GUARANTEE EXPIRATION";
            objEntityMail.Email_Content = content;
            objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
            objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
            objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
            objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
            objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
            objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();



            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
            try
            {
                SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                objBusnssTemMailServce.UpdateMailChk(EntityTemMailServce);


                EntityTemMailServce.D_Date = DateTime.Now;
                EntityTemMailServce.FromMailId = objEntityMail.From_Email_Address;
                EntityTemMailServce.ToMailId = objEntityMail.To_Email_Address;

                EntityTemMailServce.MailSubject = objEntityMail.Email_Subject;
                objBusnssTemMailServce.InsertMailTracking(EntityTemMailServce);

            }
            catch
            {


            }

        }
    }

    public void SendMailAsHtml(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
    {

        clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        SmtpClient SmtpServer = new SmtpClient(objEntityMail.Out_Service_Name);
        mail.From = new MailAddress(objEntityMail.From_Email_Address);
        mail.To.Add(objEntityMail.To_Email_Address);
        foreach (classEntityToMailAddress objEntityToMailAddress in objEntityToMailAddressList)
        {
            if (objEntityToMailAddress.ToAddress != "" && objEntityToMailAddress.ToAddress != null)
            {
                mail.To.Add(new MailAddress(objEntityToMailAddress.ToAddress));
            }
        }

        foreach (clsEntityMailCcBCc objEntityMailCcBCc in objEntityMailCcBCcList)
        {
            if (objEntityMailCcBCc.CcMail != "" && objEntityMailCcBCc.CcMail != null)
            {
                mail.CC.Add(new MailAddress(objEntityMailCcBCc.CcMail)); //Adding Multiple CC email Id
            }
            if (objEntityMailCcBCc.BCcMail != "" && objEntityMailCcBCc.BCcMail != null)
            {

                mail.Bcc.Add(new MailAddress(objEntityMailCcBCc.BCcMail)); //Adding Multiple BCC email Id
            }
        }



        //string strBody = objEntityMail.Email_Content + objEntityMail.Signature;
        //string strBody = objEntityMail.Email_Content;
        mail.Subject = objEntityMail.Email_Subject;
        mail.Body = objEntityMail.Email_Content;
        // mail.IsBodyHtml = true;


        //ContentType mimeType = new System.Net.Mime.ContentType("text/html");
        //// Add the alternate body to the message.

        //AlternateView alternate = AlternateView.CreateAlternateViewFromString(strBody, mimeType);
        //mail.AlternateViews.Add(alternate);


        //for attachment
        foreach (clsEntityMailAttachment objEntityAtt in objEntityMailAttachList)
        {
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(objEntityAtt.Attch_Path);
            mail.Attachments.Add(attachment);
        }
        SmtpServer.Port = Convert.ToInt32(objEntityMail.Out_Port_Number);
        string strPassword = objEncryptDecrypt.Decrypt(objEntityMail.Password);
        if (objEntityMail.SSL_Status == 1)
            SmtpServer.EnableSsl = true;
        else
            SmtpServer.EnableSsl = false;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Credentials = new System.Net.NetworkCredential(objEntityMail.From_Email_Address, strPassword);
        SmtpServer.Send(mail);
        SmtpServer.Dispose();
        mail.Dispose();
    }
    
}