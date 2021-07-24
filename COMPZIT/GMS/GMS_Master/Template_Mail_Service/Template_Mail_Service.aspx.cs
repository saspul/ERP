
using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web.Script.Services;
using System.Web.Mail;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
//using System.Linq;


public partial class GMS_GMS_Master_Template_Mail_Service_Template_Mail_Service : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
            Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //if (Session["USERID"] != null)
            //{

            //    EntityTemMailServce.User_Id = Convert.ToInt32(Session["USERID"]);


            //}
            //else if (Session["USERID"] == null)
            //{
            //    Response.Redirect("/Default.aspx");
            //}


            //if (Session["CORPOFFICEID"] != null)
            //{

            //    EntityTemMailServce.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            //}
            //else if (Session["CORPOFFICEID"] == null)
            //{
            //    Response.Redirect("/Default.aspx");
            //}
            //if (Session["ORGID"] != null)
            //{
            //    EntityTemMailServce.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            //}
            //else if (Session["ORGID"] == null)
            //{
            //    Response.Redirect("/Default.aspx");
            //}
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

            // DataTable dtReqstGuarnteedetails = objBusnssTemMailServce.ReqstGuarnteedetails(EntityTemMailServce);


            //hiddenCurrentDate.Value = strCurrentDate;
            DataTable dtBankGuaranteeDtls = objBusnssTemMailServce.ReadBankDetails(EntityTemMailServce);
            int intTimeDiff = 0, intdays = 0, inthour = 0, intSectId = 0;
            DateTime dtdatehourDiff;
           // DateTime dtDateNow = DateTime.Now;

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
                            int intCorpId = 0;
                            intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
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
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                    EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());


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
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, dateExpiredte, GuarntypeChk, intTemAlertId);
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
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void TempMailSend(string MailAddress, int intCorpId, int intGurntId, string strRefNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId)
    {
        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


        EntityTemMailServce.CorpOffice_Id = intCorpId;
        EntityTemMailServce.GuaranteeId = intGurntId;
        EntityTemMailServce.TempAlertId = intTemAlertId;
        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        MailMessage mail = new MailMessage();
        DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
        DataTable dtUserDetails = new DataTable();
    
        string content = "";
        if (GuarntypeChk != 1)
        {
            content = "\n\n We wish to remind you that your Bank Guarantee of Ref No:" + strRefNo + "Will Expire On Date " + dateExpiredte + ".Please do the needful procedures for renewing the same if necessary.";
        }
        else
        {
            content = "\n\nYour Bank Guarantee Ref No:" + strRefNo + "Will Expire On Date " + dateExpiredte + "";
        }
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


            MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
            try
            {
                objMail.SendMail(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                objBusnssTemMailServce.UpdateMailChk(EntityTemMailServce);
            }
            catch
            {


            }

        }

    }





}