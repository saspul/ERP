using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.Collections.Generic;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;
using System.Collections;
using System.IO;
//using System.Diagnostics;
//using System.Net;
public partial class Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List : System.Web.UI.Page
{
//WebClient webClient;             
//Stopwatch sw = new Stopwatch(); 
 
    public string strUsrId;

    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3

    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }
    protected void Page_Load(object sender, EventArgs e)
    {

       ////0039
       // txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
       // txtTodate.Attributes.Add("onkeypress", "return isTag(event)");
       // //end
        //On not is post back
        if (!IsPostBack)
        {
            cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED), intUsrDsgnId = 0;

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            objEntityDsgnation.DesignationUserId = intUserId;
            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
                intUsrDsgnId = Convert.ToInt32(dtUserDetails.Rows[0]["DSGN_ID"].ToString());

            }

            FillBusUnit();
            //FillDept();

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }



                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }
              

                //Creating object for business layer and data table
                clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
                clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();

                hiddenDsgnTypId.Value = "0";
                hiddenDsgnControlId.Value = "C";
                if (Session["DSGN_TYPID"] != null)
                {
                    hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["DSGN_CONTROL"] != null)
                {
                    hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
               
                if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c" )
                {

                    if (Session["CORPOFFICEID"] != null)
                    {

                        objEntityUserRegistration.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                HiddenFieldCorpId.Value = Convert.ToString(objEntityUserRegistration.UserCrprtId);

                objEntityUserRegistration.LimitedUser = intUserLimited;
                objEntityUserRegistration.UserDsgnId = intUsrDsgnId;

                HiddenFieldLmtdUser.Value=intUserLimited.ToString();
                HiddenFieldUserDesgId.Value = intUsrDsgnId.ToString();

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    hiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split('_');

                    string strddlStatus = strSearchFields[0];
                    string strCbxShowCancel = strSearchFields[1];





                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxShowCancel == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }
               

                //0039
                clsCommonLibrary.CORP_GLOBAL[] arrEnumerfin = {  clsCommonLibrary.CORP_GLOBAL.USRID_GNRT_TYPE
                                                              };

                //int intCorpId1 = 162;

                 int intCorpId1 =      objEntityUserRegistration.UserCrprtId;
                DataTable dtCorpDetailutp = new DataTable();
                dtCorpDetailutp = objBusinessLayer.LoadGlobalDetail(arrEnumerfin, intCorpId1);
                //
                if (dtCorpDetailutp.Rows.Count > 0)
                {
                    hiddenUserIdType.Value = dtCorpDetailutp.Rows[0]["USRID_GNRT_TYPE"].ToString();
                }
                else
                {
                    hiddenUserIdType.Value = "0";   // default value updating new row with exist usercode
                }
                //end





                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityUserRegistration.UsrRegistrationId = Convert.ToInt32(strId);
                    objEntityUserRegistration.UserId = intUserId;

                    objEntityUserRegistration.UserDate = System.DateTime.Now;

                    if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
                    {
                        int intCorpId = 0;

                        intCorpId = objEntityUserRegistration.UserCrprtId;



                        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                      
                                                              };

                       
                        DataTable dtCorpDetail = new DataTable();
                        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                        if (dtCorpDetail.Rows.Count > 0)
                        {
                            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                            if (CnclrsnMust == "0")
                            {
                                objEntityUserRegistration.UserCancelReason = objCommon.CancelReason();
                                objBusinessLayerUsrReg.UpdateUsrCancel(objEntityUserRegistration);
                                if (hiddenSearchField.Value == "")
                                {
                                    Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl");
                                }
                                else
                                {
                                    Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                                }

                            }
                            else
                            {

                                DataTable dtUser = new DataTable();
                                if (hiddenSearchField.Value == "")
                                {
                                    objEntityUserRegistration.UserStatus = 1;
                                    objEntityUserRegistration.Cancel_Status = 0;


                                }
                                else
                                {
                                    string strHidden = hiddenSearchField.Value;

                                    string[] strSearchFields = strHidden.Split('_');

                                    string strddlStatus = strSearchFields[0];
                                    string strCbxShowCancel = strSearchFields[1];

                                    objEntityUserRegistration.UserStatus = Convert.ToInt32(strddlStatus);
                                    objEntityUserRegistration.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                                }

                                hiddenCancelPrimaryId.Value = strId;
                            }

                        }

                    }
                    else
                    {
                        objEntityUserRegistration.UserCancelReason = objCommon.CancelReason();
                        objBusinessLayerUsrReg.UpdateUsrCancel(objEntityUserRegistration);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }
                }
                else
                {

                    if (hiddenSearchField.Value == "")
                    {
                        objEntityUserRegistration.UserStatus = 1;
                        objEntityUserRegistration.Cancel_Status = 0;


                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityUserRegistration.UserStatus = Convert.ToInt32(strddlStatus);
                        objEntityUserRegistration.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                    }
                    //string strInsUpd1 = Request.QueryString["InsUpd"].ToString();
                    //if (strInsUpd1 == "true")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNewID", "SuccessNewID();", true);
                    //}


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
                        //code 005 start
                        else if (strInsUpd == "Ipsd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFail", "MailsendFail();", true);
                        }
                        else if (strInsUpd == "IpRMSsd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFailReviewMailStng", "MailsendFailReviewMailStng();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "true")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNewID", "SuccessNewID();", true);
                        }
                        else if (strInsUpd == "false")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessOldID", "SuccessOldID();", true);
                        }
                    }
                }

            }
            else
            {

                divAdd.Visible = false;
            }

        }
    }

    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
   

    public void FillBusUnit()
    {
        clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = objBusinessLayerUsrReg.ReadBusUnits(objEntityUserRegistration);
        if (dtEmp.Rows.Count > 0)
        {
            ddlBu.DataSource = dtEmp;
            ddlBu.DataTextField = "CORPRT_NAME";
            ddlBu.DataValueField = "CORPRT_ID";
            ddlBu.DataBind();

        }
    }
    public void FillDept()
    {
        clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = objBusinessLayerUsrReg.ReadDept(objEntityUserRegistration);
        if (dtEmp.Rows.Count > 0)
        {
            ddlDep.DataSource = dtEmp;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Created objects for business layer
        clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityUserRegistration.UsrRegistrationId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityUserRegistration.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityUserRegistration.UserDate = System.DateTime.Now;

            objEntityUserRegistration.UserCancelReason = txtCnclReason.Text.Trim();
            objBusinessLayerUsrReg.UpdateUsrCancel(objEntityUserRegistration);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

            }


        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {


        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0, intEnableCancel = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }

        }

            clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
            clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();

            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED), intUsrDsgnId = 0;

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            objEntityDsgnation.DesignationUserId = intUserId;
            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
                intUsrDsgnId = Convert.ToInt32(dtUserDetails.Rows[0]["DSGN_ID"].ToString());

            }
            objEntityUserRegistration.LimitedUser = intUserLimited;
            objEntityUserRegistration.UserDsgnId = intUsrDsgnId;

            objEntityUserRegistration.UserStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityUserRegistration.Cancel_Status = 1;
            }
            else
            {
                objEntityUserRegistration.Cancel_Status = 0;
            }

            hiddenDsgnTypId.Value = "0";
            hiddenDsgnControlId.Value = "C";
            if (Session["DSGN_TYPID"] != null)
            {
                hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
            {

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityUserRegistration.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

    }

    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    public DataTable RemoveDuplicateRows1(DataTable dTable, string colName1)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName1]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName1], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    //0039
    [WebMethod]
    public static string IdGenerate_Auto(string orgID, string corptID, string IndId, string IndTypeId)
    {
        //string strRets = "";


        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUsrReg = new clsEntityLayerUserRegistration();
        string strRandomMixedId = IndId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);


        objEntityUsrReg.UserOrgId = Convert.ToInt32(orgID);
        objEntityUsrReg.UserCrprtId = Convert.ToInt32(corptID);
        objEntityUsrReg.UsrRegistrationId = Convert.ToInt32(strId);
        objEntityUsrReg.UserTypeStatus = Convert.ToInt32(IndTypeId);
        
        if (IndTypeId != "")
        {
            if (IndTypeId == "0")
            {
                clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
                clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();


                objEntityUsrReg.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.UserId);//104
                //DataTable dtNextIdnw = objBusinessLayerUserRegisteration.ShowNextId(objEntityUsrReg);  //exi

                DataTable dtNextIdnw = objBusinessLayerUserRegisteration.ReadNextId(objEntityUsrReg);  //new id



                objEntityUsrReg.UsrRegistrationId = Convert.ToInt32(dtNextIdnw.Rows[0]["MST_NEXT_VALUE"]);

                int intNewIncrNextId = Convert.ToInt32(dtNextIdnw.Rows[0]["MST_NEXT_VALUE"].ToString());
                int newId = Convert.ToInt32(intNewIncrNextId.ToString());

                objEntityUsrReg.UserIdMain = Convert.ToInt32(strId);
                objEntityUsrReg.UsrRegistrationId = newId;
                objBusinessLayerUserRegisteration.StoreExistingId(objEntityUsrReg);
                //strRets = "SuccessExis";
            }
            else if (IndTypeId == "1")
            {
                //0030 nw

                clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
                clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
                

                objEntityUsrReg.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.UserId);//104
                //DataTable dtNextIdnw = objBusinessLayerUserRegisteration.ShowNextId(objEntityUsrReg);  //exi

                DataTable dtNextIdnw = objBusinessLayerUserRegisteration.ReadNextId(objEntityUsrReg);  //new id



                objEntityUsrReg.UsrRegistrationId = Convert.ToInt32(dtNextIdnw.Rows[0]["MST_NEXT_VALUE"]);

                int intNewIncrNextId = Convert.ToInt32(dtNextIdnw.Rows[0]["MST_NEXT_VALUE"].ToString());//////
                int newId = Convert.ToInt32(intNewIncrNextId.ToString());

                clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
                objEntityUsrReg.UserCrprtId = Convert.ToInt32(corptID);
                DataTable dtRefFormat = objBusinessLayerUserRegisteration.ReadReferenceFormatEmp(objEntityUsrReg);              
                string strRealFormat = "";


                if (dtRefFormat.Rows.Count > 0)
                {
                    strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "0" + newId;
                }

                objEntityUsrReg.UserCodeNew = strRealFormat;
                //0039 NWW
                objEntityUsrReg.UserIdMain =Convert.ToInt32(strId);
                objEntityUsrReg.UsrRegistrationId = newId;
                objBusinessLayerUserRegisteration.StoreNewId(objEntityUsrReg);
                //strRets = "SuccessNew";
            }

        }
        return "";
  
    }

    //EMP0026
    public string ConvertDataTable(string Id)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();
        List<clsEntityLayerUserDivision> objlisUsrDivisionDtls = new List<clsEntityLayerUserDivision>();
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityPersonalDtls objEntityPersonalDetails = new clsEntityPersonalDtls();
        clsBusinessLayerPersonalDtls objBusinessPersonalDetails = new clsBusinessLayerPersonalDtls();
        objEntityPersonalDetails.EmpUserId = Convert.ToInt32(strId);

        DataTable dtBank = objBusinessPersonalDetails.ReadBankDtlsById(objEntityPersonalDetails);

        objEntityJobDetails.EmployeeId = Int32.Parse(strId);
        clsBusinessLayerJobDetails objBusinessjob = new clsBusinessLayerJobDetails();

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        DataTable dtJob = objBusinessjob.ReadJobtDetails(objEntityJobDetails);

        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLanguage.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityLanguage.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLanguage.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        objEntityLanguage.EmpUser_id = Convert.ToInt32(strId);
        DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
        objEntityPersonalDtls.EmpUserId = Convert.ToInt32(strId);
        DataTable dt = objBusinessPersonalDtls.ReadPersnlDtlsById(objEntityPersonalDtls);
        clsEntityLayerContactDtls objEntityEmp = new clsEntityLayerContactDtls();
        clsBusinessLayerContactDtls objBusinessEmp = new clsBusinessLayerContactDtls();
        DataTable dtReadContctDtls = new DataTable();
        objEntityEmp.EmpID = Convert.ToInt32(strId);
        dtReadContctDtls = objBusinessEmp.ReadContactDtlsById(objEntityEmp);


        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(strId);
        DataTable dtUsrMastr = objBusinessLayerUserRegisteration.ReadUsrMasterEdit(objEntityUsrRegistr);
       
        DataTable dtSubBussUnit = new DataTable();
        DataTable dtLicType = objBusinessLayerUserRegisteration.ReadLicenseType_ByUsrId(objEntityUsrRegistr);
        dtSubBussUnit = objBusinessLayerUserRegisteration.ReadSubBusUnt(objEntityUsrRegistr);
        int UserOrgId = 0;
        int intCorpId = 0;
        int intUserId = 0;
        DataTable dtSubBussUnit1 = new DataTable();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        if (Session["ORGID"] != null)
        {

            UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (dtUsrMastr.Rows[0]["CORPRT_ID"].ToString() != "")
        {
            intCorpId = Convert.ToInt32(dtUsrMastr.Rows[0]["CORPRT_ID"].ToString());
        }
        objEntityUsrRegistr.UserId = intUserId;
        objEntityUsrRegistr.UserOrgId = UserOrgId;
        objEntityUsrRegistr.UserCrprtId = intCorpId;
        dtSubBussUnit1 = objBusinessLayerUserRegisteration.ReadSubBuss(objEntityUsrRegistr);
        objEntityImigrationDtls.CorpId = intCorpId;
        objEntityImigrationDtls.OrgId = UserOrgId;
        objEntityImigrationDtls.Imig_Emp_id = Int32.Parse(strId);

        DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);

        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(strId);

        DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);

        string GENDER = "";
        string STATUS = "";
        string MARRIED = "";
        string ACCOUNTTYPE = "";
        string username = "";
        string designation = "";
        string JOBROLE = "";
        string NATIONAL = "";
        string EMPLOYEETYPE = "";
        string MOBILE = "";
        string nationality = "";
        string gender = "";
        string employeecde = "";
        string status = "";
        string OFFICIALMAIL = "";
        string BUSSINESSUNIT = "";
        string CRPTDEPT = "";
        string DIVISION = "";
        string DRVLICNUM = "";
        string LICEXPDTE = "";
        string LICTYPE = "";
        string SUBDIV = "";
        string PLACEOFBIRTH = "";
        string JOINDATE = "";
        string RELIGION = "";
        string BLOODGROUP = "";
        string DOB = "";
        string REPORTING = "";
        string ACCOMADATION = "";
        string ACCOSUB = "";
        string ROOMNAME = "";
        string ACCFROM = "";
        string ACCTO = "";
        string MESSFROM = "";
        string MESSTO = "";
        string BANKNAME = "";
        string BRANCH = "";
        string IBAN = "";
        string ADDRESS1 = "";
        string ADDRESS2 = "";
        string EMAIL = "";
        string PHONE = "";
        string EMGPHONE = "";

        string CARDNUM = "";
        string EMPLOYEEID = "";
        string DOCUMENTPASS = "";
        string DOCUMENTVISA = "";
        string DOCUMENTRP = "";
        string DOCUMENTHEALTH = "";
        string NUMBERPASS = "";
        string NUMBERVISA = "";
        string NUMBERRP = "";
        string NUMBERHEALTH = "";
        string SPONCER = "";
        string DIV = "";
        string DEPT = "";
        string JOBTYPE = "";
        string PRJCT = "";
        string PAYGRADE = "";
        string BASICPAY = "";
        string PGRANGEFRM = "";
        string lang = "";
        string RSGNSTS = "";


        if (dtUsrMastr.Rows.Count > 0)
        {
            username = dtUsrMastr.Rows[0]["USR_NAME1"].ToString() + " " + dtUsrMastr.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtUsrMastr.Rows[0]["EMPERDTL_LNAME"].ToString();
            designation = dtUsrMastr.Rows[0]["DSGN_NAME"].ToString();
            JOBROLE = dtUsrMastr.Rows[0]["JOBRL_NAME"].ToString();
            NATIONAL = dtUsrMastr.Rows[0]["USR_NTNLID_NUMBR"].ToString();
            EMPLOYEETYPE = dtUsrMastr.Rows[0]["USRTYP_NAME"].ToString();
            MOBILE = dtUsrMastr.Rows[0]["USR_MOBILE"].ToString();
            nationality = dtUsrMastr.Rows[0]["CNTRY_NAME"].ToString();
            gender = dtUsrMastr.Rows[0]["EMPERDTL_GENDER"].ToString();
            employeecde = dtUsrMastr.Rows[0]["USR_CODE"].ToString();
            status = dtUsrMastr.Rows[0]["USR_STATUS"].ToString();
            OFFICIALMAIL = dtUsrMastr.Rows[0]["USR_OFFCL_EMAIL"].ToString();
            BUSSINESSUNIT = dtUsrMastr.Rows[0]["CORPRT_NAME"].ToString();
            CRPTDEPT = dtUsrMastr.Rows[0]["CPRDEPT_NAME"].ToString();
            DRVLICNUM = dtUsrMastr.Rows[0]["USR_DRVLIC_NUMBR"].ToString();
            LICEXPDTE = dtUsrMastr.Rows[0]["LICEXPDATE"].ToString();
            RSGNSTS = dtUsrMastr.Rows[0]["RSGN_STS"].ToString();

          

        }
        //evm-0024
        DataView view = new DataView(dtUsrMastr);
        DataTable distinctValues = view.ToTable(true, "CPRDIV_NAME");
        //end
        for (int intRowBodyCount = 0; intRowBodyCount < distinctValues.Rows.Count; intRowBodyCount++)
        {
            //if (DIVISION == "")
            //{
            //    string strDivName = dtUsrMastr.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString();
            //    DIVISION = dtUsrMastr.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString();
            //}
            //else
            //{
            //    DIVISION = DIVISION + "," + dtUsrMastr.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString();
            //}

            string strDivName = dtUsrMastr.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString();
            if (dtUsrMastr.Rows[intRowBodyCount]["USRDIV_PRIMARY_STS"].ToString() == "1")
            {
                DIVISION = dtUsrMastr.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString();
            }
        }
        DataTable dtDistinctList = RemoveDuplicateRows(dtUsrMastr, "SUBCORPID");
        if (dtDistinctList.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtDistinctList.Rows.Count; intRowBodyCount++)
            {
                if (SUBDIV == "")
                {
                    SUBDIV = dtDistinctList.Rows[intRowBodyCount]["CORPRT_NAME2"].ToString();
                }
                else
                {
                    SUBDIV = SUBDIV + "," + dtDistinctList.Rows[intRowBodyCount]["CORPRT_NAME2"].ToString();
                }
            }

        }
        if (dtSubBussUnit1.Rows.Count > 0)
        {

        }
        if (dtLicType.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtLicType.Rows.Count; intRowBodyCount++)
            {
                if (LICTYPE == "")
                {
                    LICTYPE = dtLicType.Rows[intRowBodyCount]["VHCLLCNSTYP_NAME"].ToString();
                }
                else
                {
                    LICTYPE = LICTYPE + "," + dtLicType.Rows[intRowBodyCount]["VHCLLCNSTYP_NAME"].ToString();
                }
            }
        }
        if (dt.Rows.Count > 0)
        {
            EMPLOYEEID = dt.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString();
            PLACEOFBIRTH = dt.Rows[0]["EMPERDTL_BIRTH_PLC"].ToString();
            JOINDATE = dt.Rows[0]["JOIN_DATE"].ToString();
            if (dt.Rows[0]["EMPERDTL_MRTL_STS"].ToString() == "0")
            {
                MARRIED = "MARRIED";
            }
            if (dt.Rows[0]["EMPERDTL_MRTL_STS"].ToString() == "1")
            {
                MARRIED = "UNMARRIED";
            }
            RELIGION = dt.Rows[0]["RELIGION_NAME"].ToString();
            BLOODGROUP = dt.Rows[0]["BLOODGRP_NAME"].ToString();
            DOB = dt.Rows[0]["DOB"].ToString();
            REPORTING = dt.Rows[0]["REPORT_NAME"].ToString();
            ACCOMADATION = dt.Rows[0]["ACCMDTN_NAME"].ToString();
            ACCOSUB = dt.Rows[0]["ACCOMDTNCATSUB_NAME"].ToString();
            ROOMNAME = dt.Rows[0]["ACSUBCATDTL_NAME"].ToString();
            ACCFROM = dt.Rows[0]["ACCMDTN_DATE"].ToString();
            ACCTO = dt.Rows[0]["ACCMDTN_TO_DATE"].ToString();
            MESSFROM = dt.Rows[0]["MESS_FROM_DATE"].ToString();
            MESSTO = dt.Rows[0]["MESS_TO_DATE"].ToString();
        }
        if (dtBank.Rows.Count > 0)
        {
            BANKNAME = dtBank.Rows[0]["BANK_NAME"].ToString();
            if (dtBank.Rows[0]["EMPBANK_ACCOUNT_TYP"].ToString() == "1")
            {
                ACCOUNTTYPE = "SALARY ACCOUNT";
            }
            if (dtBank.Rows[0]["EMPBANK_ACCOUNT_TYP"].ToString() == "2")
            {
                ACCOUNTTYPE = "PAY CARD";
            }
            BRANCH = dtBank.Rows[0]["EMPBANK_BRANCH"].ToString();
            IBAN = dtBank.Rows[0]["EMPBANK_IBAN"].ToString();

            CARDNUM = dtBank.Rows[0]["EMPBANK_CARDNUM"].ToString();
        }
        if (dtReadContctDtls.Rows.Count > 0)
        {
            ADDRESS1 = dtReadContctDtls.Rows[0]["EMCNDT_ADR1"].ToString() + " " + dtReadContctDtls.Rows[0]["EMCNDT_ADR2"].ToString() + " " + dtReadContctDtls.Rows[0]["EMCNDT_ADR3"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["CITY_NAME"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["STATE_NAME"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["CNTRY_NAME"].ToString() + " <br>PIN/ZIP CODE:" + dtReadContctDtls.Rows[0]["EMCNDT_ZIPCODE"].ToString();
            ADDRESS2 = dtReadContctDtls.Rows[0]["EMCNDT_CUM_ADR1"].ToString() + " " + dtReadContctDtls.Rows[0]["EMCNDT_CUM_ADR2"].ToString() + " " + dtReadContctDtls.Rows[0]["EMCNDT_CUM_ADR3"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["COM_CITY_NAME"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["COM_STATE_NAME"].ToString() + " <br>" + dtReadContctDtls.Rows[0]["COM_CNTRY_NAME"].ToString() + " <br>PIN/ZIP CODE:" + dtReadContctDtls.Rows[0]["EMCNDT_CUM_ZIPCODE"].ToString();
            EMAIL = dtReadContctDtls.Rows[0]["EMCNDT_EMAIL"].ToString();
            PHONE = dtReadContctDtls.Rows[0]["EMCNDT_PHONE"].ToString();
            EMGPHONE = dtReadContctDtls.Rows[0]["EMCNDT_EMG_CON_PHONE"].ToString();
        }
        if (dtImigrations.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtImigrations.Rows.Count; intRowBodyCount++)
            {
                if (dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString() == "Passport")
                {
                    DOCUMENTPASS = dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString();
                    if (NUMBERPASS == "")
                    {
                        NUMBERPASS = dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }
                    else
                    {
                        NUMBERPASS = NUMBERPASS + "," + dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }

                }
                if (dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString() == "Visa")
                {
                    DOCUMENTVISA = dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString();
                    if (NUMBERVISA == "")
                    {
                        NUMBERVISA = dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }
                    else
                    {
                        NUMBERVISA = NUMBERVISA + "," + dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }

                }
                if (dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString() == "RP")
                {
                    DOCUMENTRP = dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString();
                    if (NUMBERRP == "")
                    {
                        NUMBERRP = dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }
                    else
                    {
                        NUMBERRP = NUMBERRP + "," + dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }

                }
                if (dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString() == "Health Card")
                {
                    DOCUMENTHEALTH = dtImigrations.Rows[intRowBodyCount]["DOCUMENT"].ToString();
                    if (NUMBERHEALTH == "")
                    {
                        NUMBERHEALTH = dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }
                    else
                    {
                        NUMBERHEALTH = NUMBERHEALTH + "," + dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
                    }

                }


            }
            //for (int intRowBodyCount = 0; intRowBodyCount < dtImigrations.Rows.Count; intRowBodyCount++)
            //{
            //    if (NUMBER == "")
            //    {
            //        NUMBER = dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
            //    }
            //    else
            //    {
            //        NUMBER = NUMBER + "," + dtImigrations.Rows[intRowBodyCount]["NUMBER"].ToString();
            //    }
            //}

        }
        if (dtLanglist.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtLanglist.Rows.Count; intRowBodyCount++)
            {
                if (lang == "")
                {
                    lang = dtLanglist.Rows[intRowBodyCount]["LANGMSTR_NAME"].ToString();
                }
                else
                {
                    lang = lang + "," + dtLanglist.Rows[intRowBodyCount]["LANGMSTR_NAME"].ToString();
                }
            }
        }
        if (dtJob.Rows.Count > 0)
        {
            SPONCER = dtJob.Rows[0]["SPNSR_NAME"].ToString();
            DIV = dtJob.Rows[0]["CPRDIV_NAME"].ToString();
            DEPT = dtJob.Rows[0]["CPRDEPT_NAME"].ToString();
            JOBTYPE = dtJob.Rows[0]["EMP_JOB_TYPE"].ToString();
            PRJCT = dtJob.Rows[0]["PROJECT_NAME"].ToString();
        }
        if (dtSlry.Rows.Count > 0)
        {
            PAYGRADE = dtSlry.Rows[0]["PYGRD_NAME"].ToString();
            BASICPAY = dtSlry.Rows[0]["AMOUNTFRM"].ToString() + "-" + dtSlry.Rows[0]["CRNCMST_ABBRV"].ToString();
            PGRANGEFRM = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + "-" + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "-" + dtSlry.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        if (gender == "0")
        {
            GENDER = "MALE";
        }
        if (gender == "1")
        {
            GENDER = "FEMALE";
        }
        if (gender == "2")
        {
            GENDER = "OTHER";
        }
        if (status == "0")
        {
            STATUS = "INACTIVE";
        }
        if (status == "1")
        {
            STATUS = "ACTIVE";
        }
        if (RSGNSTS == "1")
        {
            STATUS = "RESIGNED";
        }

        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strHtml += "<tbody >";


        if (username != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >EMPLOYEE NAME </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + username + "</td>";
            strHtml += "</tr>";
        }
        if (employeecde != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >EMPLOYEE ID </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + employeecde + "</td>";
            strHtml += "</tr>";
        }
        if (BUSSINESSUNIT != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >BUSINESS UNIT</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + BUSSINESSUNIT + "</td>";
            strHtml += "</tr>";
        }
        if (designation != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >DESIGNATION </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + designation + "</td>";
            strHtml += "</tr>";
        }
        if (CRPTDEPT != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >CORPORATE DEPARTMENT</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + CRPTDEPT + "</td>";
            strHtml += "</tr>";
        }

        if (DIVISION != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >CORPORATE DIVISION</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + DIVISION + "</td>";
            strHtml += "</tr>";
        }

        if (SUBDIV != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >SUB BUSINESS UNIT</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + SUBDIV + "</td>";
            strHtml += "</tr>";
        }
        if (JOBROLE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >JOB ROLE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + JOBROLE + "</td>";
            strHtml += "</tr>";
        }
        if (ADDRESS1 != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > PERMENENT ADDRESS</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + ADDRESS1 + "</td>";
            strHtml += "</tr>";

        }
        if (EMAIL != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > EMAIL ID</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + EMAIL + "</td>";
            strHtml += "</tr>";
        }
        if (PHONE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > PHONE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + PHONE + "</td>";
            strHtml += "</tr>";
        }
        if (ADDRESS2 != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ADDRESS FOR COMMUNICATION</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + ADDRESS2 + "</td>";
            strHtml += "</tr>";
        }
        if (EMGPHONE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > EMERGENCY CONTACT NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + EMGPHONE + "</td>";
            strHtml += "</tr>";
        }

        if (MOBILE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >MOBILE NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + MOBILE + "</td>";
            strHtml += "</tr>";
        }
        if (NATIONAL != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >NATIONAL ID</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + NATIONAL + "</td>";
            strHtml += "</tr>";
        }
        if (EMPLOYEETYPE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >EMPLOYMENT TYPE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + EMPLOYEETYPE + "</td>";
            strHtml += "</tr>";
        }

        if (nationality != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >NATIONALITY</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + nationality + "</td>";
            strHtml += "</tr>";
        }
        if (gender != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >GENDER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + GENDER + "</td>";
            strHtml += "</tr>";
        }
        //if (employeecde != "")
        //{
        //    strHtml += "<tr>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >EMPLOYEE CODE</td>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + employeecde + "</td>";
        //    strHtml += "</tr>";
        //}
        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >STATUS</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + STATUS + "</td>";
        strHtml += "</tr>";
        if (OFFICIALMAIL != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >OFFICIAL MAIL</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + OFFICIALMAIL + "</td>";
            strHtml += "</tr>";
        }



        if (DRVLICNUM != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >DRIVING LICENCE NUMBER </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + DRVLICNUM + "</td>";
            strHtml += "</tr>";
        }
        if (LICEXPDTE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > LICENCE EXPIRY DATE </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + LICEXPDTE + "</td>";
            strHtml += "</tr>";
        }
        if (LICTYPE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >LICENCE TYPE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + LICTYPE + "</td>";
            strHtml += "</tr>";
        }
        if (PLACEOFBIRTH != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >PLACE OF BIRTH </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + PLACEOFBIRTH + "</td>";
            strHtml += "</tr>";
        }
        //if (JOINDATE != "")
        //{
        //    strHtml += "<tr>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >EXPECTED JOIN DATE </td>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + JOINDATE + "</td>";
        //    strHtml += "</tr>";
        //}
        if (MARRIED != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >MARITAL STATUS</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + MARRIED + "</td>";
            strHtml += "</tr>";
        }
        if (RELIGION != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >RELIGION </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + RELIGION + "</td>";
            strHtml += "</tr>";
        }
        if (BLOODGROUP != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >BLOOD GROUP </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + BLOODGROUP + "</td>";
            strHtml += "</tr>";
        }
        if (DOB != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >DATE OF BIRTH </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + DOB + "</td>";
            strHtml += "</tr>";
        }
        if (REPORTING != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >REPORTING OFFICER </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + REPORTING + "</td>";
            strHtml += "</tr>";
        }
        if (ACCOMADATION != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ACCOMODATION </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + ACCOMADATION + "</td>";
            strHtml += "</tr>";
        }
        if (ACCOSUB != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ACCOMODATION SUBCATOGORY </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + ACCOSUB + "</td>";
            strHtml += "</tr>";
        }

        if (ROOMNAME != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ROOM NAME </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + ROOMNAME + "</td>";
            strHtml += "</tr>";
        }
        if (ACCFROM != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ACCOMODATION FROM </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + ACCFROM + "</td>";
            strHtml += "</tr>";
        }
        if (ACCTO != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ACCOMODATION TO </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + ACCTO + "</td>";
            strHtml += "</tr>";
        }
        if (MESSFROM != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >MESS FROM DATE  </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + MESSFROM + "</td>";
            strHtml += "</tr>";
        }
        if (MESSTO != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >MESS TO DATE  </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + MESSTO + "</td>";
            strHtml += "</tr>";
        }
        if (BANKNAME != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >BANK NAME  </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + BANKNAME + "</td>";
            strHtml += "</tr>";
        }
        if (BRANCH != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >BRANCH </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + BRANCH + "</td>";
            strHtml += "</tr>";
        }
        if (ACCOUNTTYPE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ACCOUNT TYPE  </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + ACCOUNTTYPE + "</td>";
            strHtml += "</tr>";
        }

        if (IBAN != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >IBAN NUMBER </td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + IBAN + "</td>";
            strHtml += "</tr>";
        }

        if (CARDNUM != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > BANK CARD NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + CARDNUM + "</td>";
            strHtml += "</tr>";
        }
        if (DOCUMENTPASS != "")
        {

            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > PASSPORT NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + NUMBERPASS + "</td>";
            strHtml += "</tr>";
        }
        if (DOCUMENTHEALTH != "")
        {

            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > HEALTH CARD NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + NUMBERHEALTH + "</td>";
            strHtml += "</tr>";
        }
        if (DOCUMENTVISA != "")
        {

            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > VISA NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + NUMBERVISA + "</td>";
            strHtml += "</tr>";
        }
        if (DOCUMENTRP != "")
        {

            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" > RP NUMBER</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + NUMBERRP + "</td>";
            strHtml += "</tr>";
        }
        //if (NUMBER != "")
        //{
        //    strHtml += "<tr>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >DOCUMENT NUMBER</td>";
        //    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + NUMBER + "</td>";
        //    strHtml += "</tr>";
        //}
        if (SPONCER != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >JOB SPONSOR</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + SPONCER + "</td>";
            strHtml += "</tr>";
        }
        if (DIV != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >CORPORATE DIVISION</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + DIV + "</td>";
            strHtml += "</tr>";
        }
        if (DEPT != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >CORPORATE DEPARTMENT</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + DEPT + "</td>";
            strHtml += "</tr>";
        }
        if (JOBTYPE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >JOB TYPE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + JOBTYPE + "</td>";
            strHtml += "</tr>";
        }
        if (PRJCT != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >PROJECT</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + PRJCT + "</td>";
            strHtml += "</tr>";
        }
        if (PAYGRADE != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >PAYGRADE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + PAYGRADE + "</td>";
            strHtml += "</tr>";
        }
        if (BASICPAY != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >BASIC PAY</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + BASICPAY + "</td>";
            strHtml += "</tr>";
        }
        if (PGRANGEFRM != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >PAYGRADE RANGE</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + PGRANGEFRM + "</td>";
            strHtml += "</tr>";
        }
        if (lang != "")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >LANGUAGES KNOWN</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;text-transform: uppercase;\" >" + lang + "</td>";
            strHtml += "</tr>";
        }
        sb.Append(strHtml);
        return sb.ToString();



    }
    [WebMethod]
    public static string preview1(string Id)
    {
        Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List obj = new Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List();
        string Details = obj.ConvertDataTable(Id);
        return Details;
    }
    [WebMethod]
    public static string changeBus(string orgID, string Bus)
    {
        string sts = "";
        try
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
            clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
            objEntityUserRegistration.UserOrgId = Convert.ToInt32(orgID);
            objEntityUserRegistration.Fname = Bus.Replace('-',',');
            DataTable dt = objBusinessLayerUsrReg.ReadDept(objEntityUserRegistration);
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<option value=\"" + dr["CPRDEPT_ID"].ToString() + "\">" + dr["CPRDEPT_NAME"].ToString() + "</option>");
            }
            sts = sb.ToString();
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    protected void btnClickExp_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        if (dt.Rows.Count > 0)
        {
            string strImagePath = "";
            string filepath = "";
            string strResult = DataTableToCSV(dt, ',');
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            try
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXPORT_EMPLOYEE_DETAILS_CSV);
                string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
                string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Export Employee Details/Employee_List_" + strNextId + ".csv");
                System.IO.File.WriteAllText(newFilePath, strResult);
                filepath = "Employee_List_" + strNextId + ".csv";
                Response.ContentType = "csv";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EXPORT_EMPLOYEE_DETAILS_CSV);
                Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
                Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
                Response.End();
                if (File.Exists(MapPath(strImagePath) + filepath))
                {
                    File.Delete(MapPath(strImagePath) + filepath);
                }
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "NodataCsv", "NodataCsv();", true);
        }
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
    public DataTable GetTable()
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable table = new DataTable();
        table.Columns.Add("Employee Code", typeof(string));
        table.Columns.Add("Employee Name", typeof(string));
        table.Columns.Add("Employee Type", typeof(string));
        table.Columns.Add("Business Unit", typeof(string));
        table.Columns.Add("Designation", typeof(string));
        table.Columns.Add("Department", typeof(string));
        table.Columns.Add("Reporting-To", typeof(string));
        table.Columns.Add("Gender", typeof(string));
        table.Columns.Add("Current Status", typeof(string));
        table.Columns.Add("Nationality", typeof(string));
        table.Columns.Add("National-ID", typeof(string));
        table.Columns.Add("DOB", typeof(string));
        table.Columns.Add("DOJ", typeof(string));
        table.Columns.Add("Address", typeof(string));
        table.Columns.Add("Email", typeof(string));
        table.Columns.Add("Bank Name", typeof(string));
        table.Columns.Add("A/c Type", typeof(string));
        table.Columns.Add("A/c Number", typeof(string));
        table.Columns.Add("PP#", typeof(string));
        table.Columns.Add("PP-Expiry", typeof(string));
        table.Columns.Add("Visa#", typeof(string));
        table.Columns.Add("Visa-Expiry", typeof(string));
        table.Columns.Add("RP#", typeof(string));
        table.Columns.Add("RP-Expiry", typeof(string));
        table.Columns.Add("HC#", typeof(string));
        table.Columns.Add("HC-Expiry", typeof(string));
        table.Columns.Add("Basic Pay", typeof(string));

      clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
      clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
      if (Session["ORGID"] != null)
      {
          objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["CORPOFFICEID"] != null)
      {
          objEntityUserRegistration.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      objEntityUserRegistration.Fname = HiddenFieldBu.Value;
      objEntityUserRegistration.ImagePath = HiddenFieldDept.Value;
      objEntityUserRegistration.EmployeeTypId = Convert.ToInt32(HiddenFieldExpEmpType.Value);
      objEntityUserRegistration.UserStatus = Convert.ToInt32(HiddenFieldExpSts.Value);
      DataTable dt = objBusinessLayerUsrReg.ReadExportData(objEntityUserRegistration);
     
      DataTable dtCol = objBusinessLayerUsrReg.ReadAddDed(objEntityUserRegistration);
      for(int i=0;i<dtCol.Rows.Count;i++){
       table.Columns.Add(dtCol.Rows[i]["PAYRL_NAME"].ToString(), typeof(string));
      }
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            int cnt = 0;
            if (dt.Rows[0]["CNT"].ToString() != "")
            {
                cnt = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            }
            string formatString = String.Concat("{0:F", cnt, "}");

            DataRow drDtl = table.NewRow();
            drDtl["Employee Code"] ='"' + dt.Rows[j]["USR_CODE"].ToString() + '"';
            drDtl["Employee Name"] ='"' + dt.Rows[j]["NAME"].ToString() + '"';
            drDtl["Employee Type"] ='"' + dt.Rows[j]["TYPE_EMP"].ToString() + '"'; 
            drDtl["Business Unit"] ='"' + dt.Rows[j]["CORPRT_NAME"].ToString() + '"';
            drDtl["Designation"] ='"' + dt.Rows[j]["DESIGNATION"].ToString() + '"';
            drDtl["Department"] ='"' + dt.Rows[j]["DEPARTMENT"].ToString() + '"';
            drDtl["Reporting-To"] ='"' + dt.Rows[j]["REPORT_OFFICER"].ToString() + '"'; 
            drDtl["Gender"] ='"' + dt.Rows[j]["GENDER"].ToString() + '"';
            if (dt.Rows[j]["LEAVE_STS"].ToString() != "0")
            {
                string strStatus = "ON LEAVE";
                drDtl["Current Status"] = '"' + strStatus + '"';
            }
            else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "0")
            {
                drDtl["Current Status"] = '"' + dt.Rows[j]["STATUS"].ToString() + '"';
            }
            else
            {
                string strStatus = "";
                if (dt.Rows[j]["RESIGN STATUS"].ToString() == "1")
                {
                    strStatus = "RESIGN";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "2")
                {
                    strStatus = "TERMINATION";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "3")
                {
                    strStatus = "RETIREMENT";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "4")
                {
                    strStatus = "ABSCOND";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "5")
                {
                    strStatus = "DEATH";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "6")
                {
                    strStatus = "REJOIN";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "7")
                {
                    strStatus = "UNDER POLICE CUSTODY";
                }
                else if (dt.Rows[j]["RESIGN STATUS"].ToString() == "8")
                {
                    strStatus = "OTHER";
                }
                drDtl["Current Status"] = '"' + strStatus + '"';
            }
            //EVM0041

            //START

            drDtl["Nationality"] = '"' + dt.Rows[j]["CNTRY_NAME"].ToString() + '"';
            drDtl["National-ID"] = '"' + dt.Rows[j]["USR_NTNLID_NUMBR"].ToString() + '"';
            drDtl["DOB"] = '"' + dt.Rows[j]["DOB"].ToString() + '"';
            drDtl["DOJ"] = '"' + dt.Rows[j]["JOINDATE"].ToString() + '"';
            drDtl["Address"] = '"' + dt.Rows[j]["EMCNDT_ADR1"].ToString() + '"';
            drDtl["Email"] = '"' + dt.Rows[j]["USR_EMAIL"].ToString() + '"';
            drDtl["Bank Name"] = '"' + dt.Rows[j]["BANK_NAME"].ToString() + '"';
            drDtl["A/c Type"] = '"' + dt.Rows[j]["EMPBANK_ACCOUNT_TYP"].ToString() + '"';
            drDtl["A/c Number"] = '"' + dt.Rows[j]["EMPBANK_IBAN"].ToString() + '"' + "\t";

            //END
            decimal BasPay = 0;
            if (dt.Rows[j]["BASIC_PAY"].ToString() != "")
            {
                BasPay=Convert.ToDecimal(dt.Rows[j]["BASIC_PAY"].ToString());
            }
            objEntityUserRegistration.UserId = Convert.ToInt32(dt.Rows[j]["USR_ID"].ToString());
            DataTable dtCol1 = objBusinessLayerUsrReg.ReadAddDedEmp(objEntityUserRegistration);
            DataTable dtCe234 = objBusinessLayerUsrReg.ReadAddDedEmpDate(objEntityUserRegistration);
            string pp = "", ppDate = "", visa = "", visaDate = "", rp = "", rpDate = "", hc = "", hcDate = "";
            for (int k = 0; k < dtCe234.Rows.Count; k++)
            {
                if (dtCe234.Rows[k][2].ToString() == "1")
                {
                    pp = dtCe234.Rows[k][0].ToString();
                    ppDate = dtCe234.Rows[k][1].ToString();
                }
                else if (dtCe234.Rows[k][2].ToString() == "2")
                {
                    visa = dtCe234.Rows[k][0].ToString();
                    visaDate = dtCe234.Rows[k][1].ToString();
                }
                else if (dtCe234.Rows[k][2].ToString() == "3")
                {
                    rp = dtCe234.Rows[k][0].ToString();
                    rpDate = dtCe234.Rows[k][1].ToString();
                }
                else if (dtCe234.Rows[k][2].ToString() == "4")
                {
                    hc = dtCe234.Rows[k][0].ToString();
                    hcDate = dtCe234.Rows[k][1].ToString();
                }

            }
            drDtl["PP#"] = '"' + pp + '"';
            drDtl["PP-Expiry"] = '"' + ppDate + '"';
            drDtl["Visa#"] = '"' + visa + '"';
            drDtl["Visa-Expiry"] = '"' + visaDate + '"';
            drDtl["RP#"] = '"' + rp + '"';
            drDtl["RP-Expiry"] = '"' + rpDate + '"';
            drDtl["HC#"] = '"' + hc + '"';
            drDtl["HC-Expiry"] = '"' + hcDate + '"';
            drDtl["Basic Pay"] = '"' + dt.Rows[j]["BASIC_PAY"].ToString() + '"';

            decimal totAddAmnt = 0;
            for (int i = 0; i < dtCol1.Rows.Count; i++)
            {
                if (dtCol1.Rows[i][4].ToString()=="1")
                {
                        if (dtCol1.Rows[i][1].ToString() == "0")
                        {
                            totAddAmnt = totAddAmnt+Convert.ToDecimal(dtCol1.Rows[i][2].ToString());
                        }
                        else
                        {
                            totAddAmnt = totAddAmnt + BasPay * ((Convert.ToDecimal(dtCol1.Rows[i][3].ToString()) / 100));
                        }
                      
                }             
            }

            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                string strAmnt = "";
                if (dtCol1.Rows.Count > 0)
                {
                    DataRow[] result = dtCol1.Select("PAYRL_NAME ='" + dtCol.Rows[i]["PAYRL_NAME"].ToString() + "'");
                    foreach (DataRow row in result)
                    {
                        if (row[1].ToString() == "0")
                        {
                            strAmnt = row[2].ToString();
                        }
                        else
                        {
                            if (row[5].ToString() == "0")
                            {
                                strAmnt = Convert.ToString(BasPay * ((Convert.ToDecimal(row[3].ToString()) / 100)));
                            }
                            else
                            {
                                strAmnt = Convert.ToString((BasPay+totAddAmnt) * ((Convert.ToDecimal(row[3].ToString()) / 100)));
                            }
                        }
                        strAmnt = String.Format(formatString, Convert.ToDecimal(strAmnt)).ToString();
                    }
                }
                drDtl[dtCol.Rows[i]["PAYRL_NAME"].ToString()] = '"' + strAmnt + '"';
            }
            table.Rows.Add(drDtl);
        }
        return table;
    }
   

}