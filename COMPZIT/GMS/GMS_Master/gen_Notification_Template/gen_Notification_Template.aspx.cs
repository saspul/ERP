using BL_Compzit.BusinessLayer_GMS;
using System;
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
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Script.Serialization;
// CREATED BY:EVM-0005
// CREATED DATE:27/2/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Notification_Template_gen_Notification_Template : System.Web.UI.Page
{
    classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["Mody"] != null)
        {
           
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        txtTemplateName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlTempType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxDefault.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            btnModify.Visible = false;
            btnModifyIns.Visible = false;
            ReadNotificationType();
           
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                DropDownEmployeeDataStore();
                DropdownDesignationDataStore();
                DropdownDivisionDataStore();

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                UpdateTemplate(strId);

                lblEntry.Text = "Edit Notification Template";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                DropDownEmployeeDataStore();
                DropdownDesignationDataStore();
                DropdownDivisionDataStore();

                lblEntry.Text = "View Notification Template";

                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ViewTemplate(strId);
            }
            //when  modyfying guarantee
            else if (Request.QueryString["Mody"] != null)
            {
                divList.Visible = false;
             DropDownEmployeeDataStore();
              DropdownDesignationDataStore();
          DropdownDivisionDataStore();

                lblEntry.Text = "Update Template Details to Gurantees";

                string strRandomMixedId = Request.QueryString["Mody"].ToString();
               string strLenghtofId = strRandomMixedId.Substring(0, 2);
               int intLenghtofId = Convert.ToInt16(strLenghtofId);
               string strId = strRandomMixedId.Substring(2, intLenghtofId);
               btnModify.Visible = true;
                ViewTemplate(strId);
                   HiddenGuaranteeId.Value = Request.QueryString["guaranteeId"].ToString();
                
            }
            //when  modyfying Insurance 
            else if (Request.QueryString["ModyIns"] != null)
            {
                divList.Visible = false;
                DropDownEmployeeDataStore();
                DropdownDesignationDataStore();
                DropdownDivisionDataStore();

                lblEntry.Text = "Update Template Details to Insurance";

                string strRandomMixedId = Request.QueryString["ModyIns"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                btnModifyIns.Visible = true;
                ViewTemplate(strId);

                if (Request.QueryString["InsID"]!=null)
                {
                   HiddenInsuranceId.Value = Request.QueryString["InsID"].ToString();  
                }
               

            }
            else
            {
                lblEntry.Text = "Add Notification Template";


                clsEntityCommon objEntityCommon = new clsEntityCommon();

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONTRACT);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                string year = DateTime.Today.Year.ToString();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                



                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                //Allocating child roles
                int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notification_Template);
                DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);

                if (dtChildRolCntrct.Rows.Count > 0)
                {
                    string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                    foreach (string strC_Role in strChildDefArrWords)
                    {
                        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                        {

                        }

                    }
                }



            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "InsFail")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FailedConfirmation", "FailedConfirmation();", true);
                }

            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notification_Template);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                btnUpdate.Visible = false;
            }

        }
    }
  
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityNotTemp.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityNotTemp.Status = 0;
        }

        int TemplateCount =Convert.ToInt32(hiddenTemplateCount.Value);
        string strEachTempTotalString = hiddenEachSliceData.Value;
        string strNotifyMode = hiddenNotificationMOde.Value;
        string strNotifyVia = hiddenNotifyVia.Value;
        string strNotifyDur = hiddenNotificationDuration.Value;

        objEntityNotTemp.TemplateName = txtTemplateName.Text.Trim().ToUpper();
        if (ddlTempType.SelectedItem.Value != "--SELECT TEMPLATE TYPE--")
        {
          objEntityNotTemp.TempTypeId =Convert.ToInt32(ddlTempType.SelectedItem.Value);
        }

        if (cbxStatus.Checked == true)
        {
            objEntityNotTemp.Status = 1;
        }
        else
        {
            objEntityNotTemp.Status = 0;
        }

        if (cbxDefault.Checked == true)
        {
            objEntityNotTemp.DefaultOrNot = 1;
        }
        else
        {
            objEntityNotTemp.DefaultOrNot = 0;
        }
        int intNotificationTemplateId = 0;

        string strNameCount = ObjBusinessNotiFi.CheckTemplateName(objEntityNotTemp);
        if (strNameCount == "0")
        {
            try
            {
                //for storing and retrieve the id of notification template
                intNotificationTemplateId = ObjBusinessNotiFi.AddNotifyTemplate(objEntityNotTemp);

                // Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Ins");
            }
            catch 
            {

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Notification_Template.aspx?InsUpd=InsFail");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=InsFail");
                }
               
            }

            objEntityNotTemp.NotTempId = intNotificationTemplateId;



            int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');
            try
            {

                //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                for (int intCount = 0; intCount < TempCount; intCount++)
                {
                    NotificationTemplateDetail objEntityTempDeatils = new NotificationTemplateDetail();

                    //for template mode
                    string jsonDataNotyMod = strNotifyMode;
                    string a = jsonDataNotyMod.Replace("\"{", "\\{");
                    string b = a.Replace("\\n", "\r\n");
                    string c = b.Replace("\\", "");
                    string d = c.Replace("}\"]", "}]");
                    string k = d.Replace("}\",", "},");

                    List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                    objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                    string MODEROWID = objEachTempDetModList[intCount].ROWID;
                    string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                    string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                    if (NOTMODE == "D")
                    {
                        objEntityTempDeatils.TempDetPeriod = 2;
                    }
                    else
                    {
                        objEntityTempDeatils.TempDetPeriod = 1;
                    }

                    //for template NotifyVia
                    string jsonDataNotyVia = strNotifyVia;
                    string l = jsonDataNotyVia.Replace("\"{", "\\{");
                    string m = l.Replace("\\n", "\r\n");
                    string n = m.Replace("\\", "");
                    string o = n.Replace("}\"]", "}]");
                    string p = o.Replace("}\",", "},");

                    List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                    objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                    string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                    string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                    string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                    if (VIAWHT.Contains("D"))
                    {
                        objEntityTempDeatils.IsDashBoard = 1;
                    }
                    if (VIAWHT.Contains("E"))
                    {
                        objEntityTempDeatils.IsEmail = 1;
                    }

                    //for template notify Duration
                    string jsonDataNotyDur = strNotifyDur;
                    string q = jsonDataNotyDur.Replace("\"{", "\\{");
                    string r = q.Replace("\\n", "\r\n");
                    string s = r.Replace("\\", "");
                    string t = s.Replace("}\"]", "}]");
                    string u = t.Replace("}\",", "},");

                    List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                    objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                    string DURROWID = objEachTempDetDurList[intCount].ROWID;
                    string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                    string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                    objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                    string jsonData = strEachTempString[intCount + 1];
                    string V = jsonData.Replace("\"{", "\\{");
                    string W = V.Replace("\\n", "\r\n");
                    string X = W.Replace("\\", "");
                    string Y = X.Replace("}\"]", "}]");
                    string Z = Y.Replace("}\",", "},");

                    List<NotificationTemplateAlert> objEntityTempAlertList = new List<NotificationTemplateAlert>();


                    List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                    objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                    if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                    {

                        for (int count = 0; count < objEachTempDetList.Count; count++)
                        {
                            string ROWID = objEachTempDetList[count].ROWID;

                            string VALUE = objEachTempDetList[count].DDLVALUE;
                            string DDLMODE = objEachTempDetList[count].DDLMODE;
                            string DTLID = objEachTempDetList[count].DTLID;
                            if (VALUE != "0")
                            {
                                NotificationTemplateAlert objEntityTemplateAlert = new NotificationTemplateAlert();
                                if (DDLMODE == "ddlDivision_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 0;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlDesignation_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 1;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlEmployee_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 2;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "txtGenMail_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 3;
                                    objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                }


                                objEntityTempAlertList.Add(objEntityTemplateAlert);
                            }
                        }

                    }
                    //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                    ObjBusinessNotiFi.AddTemplateDetail(objEntityNotTemp, objEntityTempDeatils, objEntityTempAlertList);
                }
            }
            catch
            {
                ObjBusinessNotiFi.DeleteAllTemplateAlert(objEntityNotTemp);
                ObjBusinessNotiFi.DeleteTemplateDetail(objEntityNotTemp);
                ObjBusinessNotiFi.DeleteTemplate(objEntityNotTemp);
                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Notification_Template.aspx?InsUpd=InsFail");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=InsFail");
                }

            }
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Notification_Template.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtTemplateName.Focus();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        if(Request.QueryString["Id"].ToString()!=null)
        {
         string strRandomMixedId = Request.QueryString["Id"].ToString();
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);
         objEntityNotTemp.NotTempId=Convert.ToInt32(strId);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityNotTemp.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityNotTemp.Status = 0;
        }

        int TemplateCount =Convert.ToInt32(hiddenTemplateCount.Value);
        string strEachTempTotalString = hiddenEachSliceData.Value;
        string strNotifyMode = hiddenNotificationMOde.Value;
        string strNotifyVia = hiddenNotifyVia.Value;
        string strNotifyDur = hiddenNotificationDuration.Value;

        objEntityNotTemp.TemplateName = txtTemplateName.Text.Trim().ToUpper();
        if (ddlTempType.SelectedItem.Value != "--SELECT TEMPLATE TYPE--")
        {
          objEntityNotTemp.TempTypeId =Convert.ToInt32(ddlTempType.SelectedItem.Value);
        }

        if (cbxStatus.Checked == true)
        {
            objEntityNotTemp.Status = 1;
        }
        else
        {
            objEntityNotTemp.Status = 0;
        }

        if (cbxDefault.Checked == true)
        {
            objEntityNotTemp.DefaultOrNot = 1;
        }
        else
        {
            objEntityNotTemp.DefaultOrNot = 0;
        }

        string strNameCount = ObjBusinessNotiFi.CheckTemplateName(objEntityNotTemp);
        if (strNameCount == "0")
        {
            try
            {
                objEntityNotTemp.D_Date = System.DateTime.Now;
                ObjBusinessNotiFi.UpdateNotifyTemplate(objEntityNotTemp);

                // Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Ins");
            }
            catch (Exception eXe)
            {
                throw eXe;
            }


            int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');

            //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
            for (int intCount = 0; intCount < TempCount; intCount++)
            {
                NotificationTemplateDetail objEntityTempDeatils = new NotificationTemplateDetail();

                //for template mode
                string jsonDataNotyMod = strNotifyMode;
                string a = jsonDataNotyMod.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                string MODEROWID = objEachTempDetModList[intCount].ROWID;
                string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                if (NOTMODE == "D")
                {
                    objEntityTempDeatils.TempDetPeriod = 2;
                }
                else
                {
                    objEntityTempDeatils.TempDetPeriod = 1;
                }
                if(MODETEMPID!="0")
                {
                    objEntityTempDeatils.TempDetailId=Convert.ToInt32(MODETEMPID);
                }
                //for template NotifyVia
                string jsonDataNotyVia = strNotifyVia;
                string l = jsonDataNotyVia.Replace("\"{", "\\{");
                string m = l.Replace("\\n", "\r\n");
                string n = m.Replace("\\", "");
                string o = n.Replace("}\"]", "}]");
                string p = o.Replace("}\",", "},");

                List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                if (VIAWHT.Contains("D"))
                {
                    objEntityTempDeatils.IsDashBoard = 1;
                }
                if (VIAWHT.Contains("E"))
                {
                    objEntityTempDeatils.IsEmail = 1;
                }

                //for template notify Duration
                string jsonDataNotyDur = strNotifyDur;
                string q = jsonDataNotyDur.Replace("\"{", "\\{");
                string r = q.Replace("\\n", "\r\n");
                string s = r.Replace("\\", "");
                string t = s.Replace("}\"]", "}]");
                string u = t.Replace("}\",", "},");

                List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                string DURROWID = objEachTempDetDurList[intCount].ROWID;
                string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                string jsonData = strEachTempString[intCount + 1];
                string V = jsonData.Replace("\"{", "\\{");
                string W = V.Replace("\\n", "\r\n");
                string X = W.Replace("\\", "");
                string Y = X.Replace("}\"]", "}]");
                string Z = Y.Replace("}\",", "},");

                List<NotificationTemplateAlert> objEntityTempAlertList = new List<NotificationTemplateAlert>();

               
                    List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                    objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                    if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                    {
                        int AddingCount = 0;
                        for (int count = 0; count < objEachTempDetList.Count; count++)
                        {
                            string ROWID = objEachTempDetList[count].ROWID;

                            string VALUE = objEachTempDetList[count].DDLVALUE;
                            string DDLMODE = objEachTempDetList[count].DDLMODE;
                            string DTLID = objEachTempDetList[count].DTLID;
                            if (VALUE != "0")
                            {
                                NotificationTemplateAlert objEntityTemplateAlert = new NotificationTemplateAlert();
                                if (DDLMODE == "ddlDivision_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 0;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlDesignation_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 1;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlEmployee_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 2;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "txtGenMail_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 3;
                                    objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                }

                                if (DTLID != "0")
                                {
                                    objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                    ObjBusinessNotiFi.UpdateNotifyTemplateAlert(objEntityTemplateAlert, objEntityTempDeatils);
                                }
                                else
                                {
                                    AddingCount++;
                                    objEntityTempAlertList.Add(objEntityTemplateAlert);
                                }
                            }
                        }
                        if (objEntityTempDeatils.TempDetailId != 0)
                        {
                            if (AddingCount != 0)
                            {
                                ObjBusinessNotiFi.AddTemplateAlert(objEntityTempAlertList, objEntityNotTemp, objEntityTempDeatils);
                            }

                        }
                }
                //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                if(objEntityTempDeatils.TempDetailId!=0)
                {
                    ObjBusinessNotiFi.UpdateNotifyTemplateDetail(objEntityTempDeatils);
                }
                else
                {
                ObjBusinessNotiFi.AddTemplateDetail(objEntityNotTemp, objEntityTempDeatils, objEntityTempAlertList);
                }
            }

            string strTotalDelete = hiddenDeleteSliceData.Value;
            string[] strEachTempDelete = new string[TempCount];
            strEachTempDelete = strTotalDelete.Split('!');
            for (int intDCount = 1; intDCount <= TempCount; intDCount++)
            {
                if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                {
                    string strDeletedAlert = strEachTempDelete[intDCount];
                    string jsonDataDeleted = strDeletedAlert;
                    string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                    string d2 = d1.Replace("\\n", "\r\n");
                    string d3 = d2.Replace("\\", "");
                    string d4 = d3.Replace("}\"]", "}]");
                    string d5 = d4.Replace("}\",", "},");
                    List<NotificationTemplateAlert> objEntityTempAlertDeleteList = new List<NotificationTemplateAlert>();


                    List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                    objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                    for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                    {
                        string ROWID = objAlertDelList[delcount].ROWID;
                        string AlertVALUE = objAlertDelList[delcount].DTLID;

                        NotificationTemplateAlert objEntityTempAlertDelete = new NotificationTemplateAlert();
                        objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                        objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                    }
                    ObjBusinessNotiFi.DeleteTemplateAlert(objEntityTempAlertDeleteList);

                }
            }

            if (clickedButton.ID == "btnUpdate")
            {
                //REDIRECT TO UPDATE VIEW 
                List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                objEntityCommon.RedirectUrl = "gen_Notification_Template.aspx";
                clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                objEntityQueryString.QueryString = "InsUpd";
                objEntityQueryString.QueryStringValue = "Upd";
                objEntityQueryString.Encrypt = 0;
                objEntityQueryStringList.Add(objEntityQueryString);
                objEntityQueryString = new clsEntityQueryString();
                objEntityQueryString.QueryString = "Id";
                objEntityQueryString.QueryStringValue = objEntityNotTemp.NotTempId.ToString();
                objEntityQueryString.Encrypt = 1;
                objEntityQueryStringList.Add(objEntityQueryString);
                string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                Response.Redirect(strRedirectUrl);

                //Response.Redirect("gen_Notification_Template.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Upd");
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtTemplateName.Focus();
        }
    
    }

    private void ReadNotificationType()
    {

        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtTempType = ObjBusinessNotiFi.ReadTemplateType(objEntityNotTemp);
        if (dtTempType.Rows.Count > 0)
        {
            ddlTempType.DataSource = dtTempType;
            ddlTempType.DataTextField = "TEMPTYPE_NAME";
            ddlTempType.DataValueField = "TEMPTYPE_ID";
            ddlTempType.DataBind();

        }

        ddlTempType.Items.Insert(0, "--SELECT TEMPLATE TYPE--");
    }

    public class clsEachTempDeatail
    {
        public string DDLVALUE { get; set; }
        public string ROWID { get; set; }
        public string DDLMODE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string DTLIDG { get; set; }
    }

    public class clsEachTempNotyMOde
    {
        public string ROWID { get; set; }
        public string NOTMODE { get; set; }
        public string TEMPID { get; set; }
        public string TEMPIDG { get; set; }
    }
    public class clsEachTempNotyVia
    {
        public string ROWID { get; set; }
        public string NOTVIA { get; set; }
        public string TEMPID { get; set; }
        public string TEMPIDG { get; set; }
    }
    public class clsEachTempNotyDur
    {
        public string ROWID { get; set; }
        public string NOTDUR { get; set; }
        public string TEMPID { get; set; }
        public string TEMPIDG { get; set; }
    }


    public class clsEachAlertDel
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
        public string DTLIDG { get; set; }
             public string TEMPIDG { get; set; }
    }
    public void DropdownDivisionDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDivisionddlData.Value = result;
    }


    public void DropdownDesignationDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = "dtTableDesignation";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDesignationddlData.Value = result;
    }

    public void DropDownEmployeeDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
          objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmployeeDdlData.Value = result;
    }
    [WebMethod]
    public static string DropdownDivisionBind(string tableName, int CorpId, int OrgId)
    {
         classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
         classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();

         objEntityNotTemp.CorpOffice_Id = CorpId;
         objEntityNotTemp.Organisation_Id = OrgId;
         DataTable dtDivisionList = new DataTable();
        dtDivisionList=ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
 
    }
    [WebMethod]
    public static string DropdownDesignationBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    [WebMethod]
    public static string DropdownEmployeeBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    public void   UpdateTemplate(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);

        if (dtTemplate.Rows.Count>0)
        {
            txtTemplateName.Text = dtTemplate.Rows[0]["NOTFTEMP_NAME"].ToString();
            int intStatus = Convert.ToInt32(dtTemplate.Rows[0]["NOTFTEMP_STATUS"]);
            int intDefaultSts = Convert.ToInt32(dtTemplate.Rows[0]["NOTFTEMP_DEFAULT"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            if (intDefaultSts == 1)
            {
                cbxDefault.Checked = true;
            }
            else
            {
                cbxDefault.Checked = false;
            }
            if (dtTemplate.Rows[0]["TEMPTYPE_STATUS"].ToString() == "1")
            {
                ddlTempType.Items.FindByValue(dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtTemplate.Rows[0]["TEMPTYPE_NAME"].ToString(), dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString());
                ddlTempType.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlTempType);
                ddlTempType.Items.FindByValue(dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString()).Selected = true;
            }
        }

        DataTable dtTemplateDetail = new DataTable();
        dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
        dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
        dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
        dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

        DataTable dtEachTemplateDetail = new DataTable();
        dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

        string strAlertDetailFull = "";
        if (dtEachTemplateDetail.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
            {
                DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                string strVia = "";
                if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString()=="1")
                {
                    strVia = strVia+ "," + "D";
                }
                if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                {
                    strVia = strVia + "," + "E";
                }
                drAttchTempDet["NotifyVia"] = strVia;

                dtTemplateDetail.Rows.Add(drAttchTempDet);

                objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                DataTable dtTemplateAlert = new DataTable();
                dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                if (dtTempAlertEachSlice.Rows.Count > 0)
                {
                    for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                    {
                        DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                        drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                        drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                        drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                        if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                        {
                            drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                        }
                        else
                        {
                            drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                        }

                        dtTemplateAlert.Rows.Add(drAttchTempAlert);
                    }
                }

                string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
            hiddenEachTemplateDetail.Value = strJson;
            hiddenTemplateAlertData.Value = strAlertDetailFull;
        }
    }


    public void ViewTemplate(string strId)
    {
        hiddenEditMode.Value = "View";
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);

        if (dtTemplate.Rows.Count > 0)
        {
            txtTemplateName.Text = dtTemplate.Rows[0]["NOTFTEMP_NAME"].ToString();
            int intStatus = Convert.ToInt32(dtTemplate.Rows[0]["NOTFTEMP_STATUS"]);
            int intDefaultSts = Convert.ToInt32(dtTemplate.Rows[0]["NOTFTEMP_DEFAULT"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            if (intDefaultSts == 1)
            {
                cbxDefault.Checked = true;
            }
            else
            {
                cbxDefault.Checked = false;
            }
            if (dtTemplate.Rows[0]["TEMPTYPE_STATUS"].ToString() == "1")
            {
                ddlTempType.Items.FindByValue(dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtTemplate.Rows[0]["TEMPTYPE_NAME"].ToString(), dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString());
                ddlTempType.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlTempType);
                ddlTempType.Items.FindByValue(dtTemplate.Rows[0]["TEMPTYPE_ID"].ToString()).Selected = true;
            }
        }

        DataTable dtTemplateDetail = new DataTable();
        dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
        dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
        dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
        dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

        DataTable dtEachTemplateDetail = new DataTable();
        dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

        string strAlertDetailFull = "";
        if (dtEachTemplateDetail.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
            {
                DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                string strVia = "";
                if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                {
                    strVia = strVia + "," + "D";
                }
                if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                {
                    strVia = strVia + "," + "E";
                }
                drAttchTempDet["NotifyVia"] = strVia;

                dtTemplateDetail.Rows.Add(drAttchTempDet);

                objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                DataTable dtTemplateAlert = new DataTable();
                dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                if (dtTempAlertEachSlice.Rows.Count > 0)
                {
                    for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                    {
                        DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                        drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                        drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                        drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                        if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                        {
                            drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                        }
                        else
                        {
                            drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                        }

                        dtTemplateAlert.Rows.Add(drAttchTempAlert);
                    }
                }

                string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
            hiddenEachTemplateDetail.Value = strJson;
            hiddenTemplateAlertData.Value = strAlertDetailFull;
        }

        ddlTempType.Enabled = false;
        txtTemplateName.Enabled = false;
        cbxDefault.Enabled = false;
        cbxStatus.Enabled = false;
       
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        string[] tokens = HiddenGuaranteeId.Value.Split(',');


        for (int i = 0; i < tokens.Length - 1; i++)
        {

            ObjEntityBnkGurnt.NextIdForRqst = Convert.ToInt32(tokens[i]);
            ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(tokens[i]);

            DataTable dtGteeAlerts = ObjBussinessBankGuarnt.ReadAlertsByGteeID(ObjEntityBnkGurnt);






            ObjBussinessBankGuarnt.DeleteTemplateAlertByGr(ObjEntityBnkGurnt);
            ObjBussinessBankGuarnt.DeleteTemplateDetByGr(ObjEntityBnkGurnt);
            int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
            string strEachTempTotalString = hiddenEachSliceData.Value;
            string strNotifyMode = hiddenNotificationMOde.Value;
            string strNotifyVia = hiddenNotifyVia.Value;
            string strNotifyDur = hiddenNotificationDuration.Value;
            //-----for template ---
            int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');

            //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
            for (int intCount = 0; intCount < TempCount; intCount++)
            {
                BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                //for template mode
                string jsonDataNotyMod = strNotifyMode;
                string a = jsonDataNotyMod.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                string MODEROWID = objEachTempDetModList[intCount].ROWID;
                string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                string MODETEMPID = objEachTempDetModList[intCount].TEMPIDG;

                if (NOTMODE == "D")
                {
                    objEntityTempDeatils.TempDetPeriod = 2;
                }
                else
                {
                    objEntityTempDeatils.TempDetPeriod = 1;
                }
                if (MODETEMPID != "0")
                {
                    objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                }
                //for template NotifyVia
                string jsonDataNotyVia = strNotifyVia;
                string l = jsonDataNotyVia.Replace("\"{", "\\{");
                string m = l.Replace("\\n", "\r\n");
                string n = m.Replace("\\", "");
                string o = n.Replace("}\"]", "}]");
                string p = o.Replace("}\",", "},");

                List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                string VIATEMPID = objEachTempDetViaList[intCount].TEMPIDG;

                if (VIAWHT.Contains("D"))
                {
                    objEntityTempDeatils.IsDashBoard = 1;
                }
                if (VIAWHT.Contains("E"))
                {
                    objEntityTempDeatils.IsEmail = 1;
                }

                //for template notify Duration
                string jsonDataNotyDur = strNotifyDur;
                string q = jsonDataNotyDur.Replace("\"{", "\\{");
                string r = q.Replace("\\n", "\r\n");
                string s = r.Replace("\\", "");
                string t = s.Replace("}\"]", "}]");
                string u = t.Replace("}\",", "},");

                List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                string DURROWID = objEachTempDetDurList[intCount].ROWID;
                string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                string DURTEMPID = objEachTempDetDurList[intCount].TEMPIDG;

                objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                string jsonData = strEachTempString[intCount + 1];
                string V = jsonData.Replace("\"{", "\\{");
                string W = V.Replace("\\n", "\r\n");
                string X = W.Replace("\\", "");
                string Y = X.Replace("}\"]", "}]");
                string Z = Y.Replace("}\",", "},");

                List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                {
                    int AddingCount = 0;
                    for (int count = 0; count < objEachTempDetList.Count; count++)
                    {
                        string ROWID = objEachTempDetList[count].ROWID;

                        string VALUE = objEachTempDetList[count].DDLVALUE;
                        string DDLMODE = objEachTempDetList[count].DDLMODE;
                        string DTLID = objEachTempDetList[count].DTLIDG;
                        if (VALUE != "0")
                        {
                            BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                            if (DDLMODE == "ddlDivision_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 0;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlDesignation_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 1;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlEmployee_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 2;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "txtGenMail_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 3;
                                objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                            }



                            //restore Mail send status -start
                            try
                            {
                                string strEmailSendStatus = "";
                                //direct mail option selected
                                if (objEntityTemplateAlert.TemplateAlertOptId == 3)
                                {

                                    string searchExpression = "GRNT_TMALRT_EMAIL = '" + objEntityTemplateAlert.TemplateNotifyWhoMail.ToString() +
                                        "' AND GRNT_TMALRT_COUNT = '" + objEntityTempDeatils.TempDetailPeriodCount.ToString() + "'AND GRNT_TMALRT_OPT = '" + objEntityTemplateAlert.TemplateAlertOptId.ToString() + "'";

                                    DataRow[] result = dtGteeAlerts.Select(searchExpression);
                                    foreach (DataRow row in result)
                                    {
                                        strEmailSendStatus = row["GRNT_MAILSEND_STS"].ToString();

                                    }

                                }
                                else
                                {
                                    string searchExpression = "GRNT_NTFY_ID = '" + objEntityTemplateAlert.TemplateWhoNotifyId.ToString() +
                                        "' AND GRNT_TMALRT_COUNT = '" + objEntityTempDeatils.TempDetailPeriodCount.ToString() + "'AND GRNT_TMALRT_OPT = '" + objEntityTemplateAlert.TemplateAlertOptId.ToString() + "'";

                                    DataRow[] result = dtGteeAlerts.Select(searchExpression);
                                    foreach (DataRow row in result)
                                    {
                                        strEmailSendStatus = row["GRNT_MAILSEND_STS"].ToString();

                                    }

                                }
                                if (strEmailSendStatus != "")
                                {
                                    if (strEmailSendStatus.ToString() == "1")
                                    {
                                        objEntityTemplateAlert.EmailSendStatus = 1;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                //objEntityTemplateAlert.EmailSendStatus = 0;
                               // throw;
                            }







                            //restore Mail send status -Ends





                            if (DTLID != "0")
                            {
                                objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                ObjBussinessBankGuarnt.UpdateNotifyTemplateAlert(objEntityTemplateAlert, objEntityTempDeatils);
                            }
                            else
                            {
                                AddingCount++;
                                objEntityTempAlertList.Add(objEntityTemplateAlert);
                            }
                        }

                    }
                    if (objEntityTempDeatils.TempDetailId != 0)
                    {
                        if (AddingCount != 0)
                        {
                            ObjBussinessBankGuarnt.AddTemplateAlert(objEntityTempAlertList, ObjEntityBnkGurnt, objEntityTempDeatils);
                        }
                    }
                }
                //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                if (objEntityTempDeatils.TempDetailId != 0)
                {
                    ObjBussinessBankGuarnt.UpdateNotifyTemplateDetail(objEntityTempDeatils);
                }
                else
                {
                    ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                }
            }

            string strTotalDelete = hiddenDeleteSliceData.Value;
            string[] strEachTempDelete = new string[TempCount];
            strEachTempDelete = strTotalDelete.Split('!');
            for (int intDCount = 1; intDCount <= TempCount; intDCount++)
            {
                if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                {
                    string strDeletedAlert = strEachTempDelete[intDCount];
                    string jsonDataDeleted = strDeletedAlert;
                    string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                    string d2 = d1.Replace("\\n", "\r\n");
                    string d3 = d2.Replace("\\", "");
                    string d4 = d3.Replace("}\"]", "}]");
                    string d5 = d4.Replace("}\",", "},");
                    List<BnkGrntyTemplateAlert> objEntityTempAlertDeleteList = new List<BnkGrntyTemplateAlert>();


                    List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                    objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                    for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                    {
                        string ROWID = objAlertDelList[delcount].ROWID;
                        string AlertVALUE = objAlertDelList[delcount].DTLIDG;

                        BnkGrntyTemplateAlert objEntityTempAlertDelete = new BnkGrntyTemplateAlert();
                        objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                        objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                    }
                    ObjBussinessBankGuarnt.DeleteTemplateAlert(objEntityTempAlertDeleteList);

                }
            }
        }
        Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=InsModify");
    }
        
    

    protected void btnModifyIns_Click(object sender, EventArgs e)
    {
        //clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();

    

        string[] tokens = HiddenInsuranceId.Value.Split(',');


        for (int i = 0; i < tokens.Length - 1; i++)
        {

            objEntityInsurance.NextIdForRqst = Convert.ToInt32(tokens[i]);
            objEntityInsurance.InsuranceId = Convert.ToInt32(tokens[i]);

            DataTable dtGteeAlerts = objBusinessInsurance.ReadAlertsByInsuID(objEntityInsurance);

            objBusinessInsurance.DeleteTemplateAlertById(objEntityInsurance);
            objBusinessInsurance.DeleteTemplateDetailById(objEntityInsurance);

            int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
            string strEachTempTotalString = hiddenEachSliceData.Value;
            string strNotifyMode = hiddenNotificationMOde.Value;
            string strNotifyVia = hiddenNotifyVia.Value;
            string strNotifyDur = hiddenNotificationDuration.Value;
            //-----for template ---
            int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');

            //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
            for (int intCount = 0; intCount < TempCount; intCount++)
            {
                InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                //for template mode
                string jsonDataNotyMod = strNotifyMode;
                string a = jsonDataNotyMod.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                string MODEROWID = objEachTempDetModList[intCount].ROWID;
                string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                string MODETEMPID = objEachTempDetModList[intCount].TEMPIDG;

                if (NOTMODE == "D")
                {
                    objEntityTempDeatils.TempDetPeriod = 2;
                }
                else
                {
                    objEntityTempDeatils.TempDetPeriod = 1;
                }
                if (MODETEMPID != "0")
                {
                    objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                }
                //for template NotifyVia
                string jsonDataNotyVia = strNotifyVia;
                string l = jsonDataNotyVia.Replace("\"{", "\\{");
                string m = l.Replace("\\n", "\r\n");
                string n = m.Replace("\\", "");
                string o = n.Replace("}\"]", "}]");
                string p = o.Replace("}\",", "},");

                List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                string VIATEMPID = objEachTempDetViaList[intCount].TEMPIDG;

                if (VIAWHT.Contains("D"))
                {
                    objEntityTempDeatils.IsDashBoard = 1;
                }
                if (VIAWHT.Contains("E"))
                {
                    objEntityTempDeatils.IsEmail = 1;
                }

                //for template notify Duration
                string jsonDataNotyDur = strNotifyDur;
                string q = jsonDataNotyDur.Replace("\"{", "\\{");
                string r = q.Replace("\\n", "\r\n");
                string s = r.Replace("\\", "");
                string t = s.Replace("}\"]", "}]");
                string u = t.Replace("}\",", "},");

                List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                string DURROWID = objEachTempDetDurList[intCount].ROWID;
                string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                string DURTEMPID = objEachTempDetDurList[intCount].TEMPIDG;

                objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                string jsonData = strEachTempString[intCount + 1];
                string V = jsonData.Replace("\"{", "\\{");
                string W = V.Replace("\\n", "\r\n");
                string X = W.Replace("\\", "");
                string Y = X.Replace("}\"]", "}]");
                string Z = Y.Replace("}\",", "},");

                List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();


                List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                {
                    int AddingCount = 0;
                    for (int count = 0; count < objEachTempDetList.Count; count++)
                    {
                        string ROWID = objEachTempDetList[count].ROWID;

                        string VALUE = objEachTempDetList[count].DDLVALUE;
                        string DDLMODE = objEachTempDetList[count].DDLMODE;
                        string DTLID = objEachTempDetList[count].DTLIDG;
                        if (VALUE != "0")
                        {
                            InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                            if (DDLMODE == "ddlDivision_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 0;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlDesignation_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 1;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlEmployee_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 2;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "txtGenMail_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 3;
                                objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                            }




                            //restore Mail send status -start
                            try
                            {
                                string strEmailSendStatus = "";
                                //direct mail option selected
                                if (objEntityTemplateAlert.TemplateAlertOptId == 3)
                                {

                                    string searchExpression = "INSRNC_TMPALRT_NTFYEMAILID = '" + objEntityTemplateAlert.TemplateNotifyWhoMail.ToString() +
                                        "' AND INSRNC_TMPALRT_COUNT = '" + objEntityTempDeatils.TempDetailPeriodCount.ToString() + "'AND INSRNC_TMPALRT_OPT = '" + objEntityTemplateAlert.TemplateAlertOptId.ToString() + "'";

                                    DataRow[] result = dtGteeAlerts.Select(searchExpression);
                                    foreach (DataRow row in result)
                                    {
                                        strEmailSendStatus = row["INSRNC_MAILSEND_STS"].ToString();

                                    }

                                }
                                else
                                {
                                    string searchExpression = "INSRNC_NOTIFY_ID = '" + objEntityTemplateAlert.TemplateWhoNotifyId.ToString() +
                                        "' AND INSRNC_TMPALRT_COUNT = '" + objEntityTempDeatils.TempDetailPeriodCount.ToString() + "'AND INSRNC_TMPALRT_OPT = '" + objEntityTemplateAlert.TemplateAlertOptId.ToString() + "'";

                                    DataRow[] result = dtGteeAlerts.Select(searchExpression);
                                    foreach (DataRow row in result)
                                    {
                                        strEmailSendStatus = row["INSRNC_MAILSEND_STS"].ToString();

                                    }

                                }
                                if (strEmailSendStatus != "")
                                {
                                    if (strEmailSendStatus.ToString() == "1")
                                    {
                                        objEntityTemplateAlert.EmailSendStatus = 1;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                //objEntityTemplateAlert.EmailSendStatus = 0;
                                // throw;
                            }







                            //restore Mail send status -Ends

                            if (DTLID != "0")
                            {
                                objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                objBusinessInsurance.UpdateTemplateAlert(objEntityTempDeatils, objEntityTemplateAlert);
                            }
                            else
                            {
                                AddingCount++;
                                objEntityTempAlertList.Add(objEntityTemplateAlert);
                            }
                        }

                    }
                    if (objEntityTempDeatils.TempDetailId != 0)
                    {
                        if (AddingCount != 0)
                        {
                            objBusinessInsurance.AddTemplateAlert(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }
                }
                //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                if (objEntityTempDeatils.TempDetailId != 0)
                {
                    objBusinessInsurance.UpdateTemplateDetail(objEntityTempDeatils);
                }
                else
                {
                    objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                }
            }

            string strTotalDelete = hiddenDeleteSliceData.Value;
            string[] strEachTempDelete = new string[TempCount];
            strEachTempDelete = strTotalDelete.Split('!');
            for (int intDCount = 1; intDCount <= TempCount; intDCount++)
            {
                if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                {
                    string strDeletedAlert = strEachTempDelete[intDCount];
                    string jsonDataDeleted = strDeletedAlert;
                    string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                    string d2 = d1.Replace("\\n", "\r\n");
                    string d3 = d2.Replace("\\", "");
                    string d4 = d3.Replace("}\"]", "}]");
                    string d5 = d4.Replace("}\",", "},");
                    List<InsuranceTemplateAlert> objEntityTempAlertDeleteList = new List<InsuranceTemplateAlert>();


                    List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                    objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                    for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                    {
                        string ROWID = objAlertDelList[delcount].ROWID;
                        string AlertVALUE = objAlertDelList[delcount].DTLIDG;

                        InsuranceTemplateAlert objEntityTempAlertDelete = new InsuranceTemplateAlert();
                        objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                        objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                    }
                    objBusinessInsurance.DeleteTemplateAlert(objEntityTempAlertDeleteList);

                }
            }
        }
        Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=InsModify");
    }
}