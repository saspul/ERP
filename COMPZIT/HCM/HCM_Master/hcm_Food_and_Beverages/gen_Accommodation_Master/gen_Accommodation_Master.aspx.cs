using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Collections;
using CL_Compzit;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
// CREATED BY:EVM-0009
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class Master_gen_Accommodation_Master_gen_Accommodation_Master : System.Web.UI.Page
{
    clsBusinessLayerAccommodation objBusinessLayerAccommodation = new clsBusinessLayerAccommodation();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAdrss.Attributes.Add("onkeypress", "return isTagEnter(evt)");
        txtAdrss.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtLocation.Attributes.Add("onkeypress", "return isTag(event)");
        txtLocation.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNoOfSubscribr.Attributes.Add("onkeypress", "return isTag(event)");
        txtNoOfSubscribr.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNoOfFloor.Attributes.Add("onkeypress", "return isTag(event)");
        txtNoOfFloor.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlAccmdtnType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxHaveMess.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            FillBusUnit();
            cbxHaveMess.Checked = false;
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
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

            txtName.Focus();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            Coordinator_Load();
            AccmdtnType_Load();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenAccomodationId.Value = strId;
                Update(strId, intCorpId);
                lblEntry.Text = "Edit Accommodation";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenAccomodationId.Value = strId;
                View(strId, intCorpId);

                lblEntry.Text = "View Accommodation";
            }
            else
            {
                lblEntry.Text = "Add Accommodation";
            
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;

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
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Accomodation_Master);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

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

    public void FillBusUnit()
    {
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccommodation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccommodation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmp = objBusinessLayerAccommodation.ReadBusinessUnits(objEntityAccommodation);
        if (dtEmp.Rows.Count > 0)
        {
            ddlBus.DataSource = dtEmp;
            ddlBus.DataTextField = "CORPRT_NAME";
            ddlBus.DataValueField = "CORPRT_ID";
            ddlBus.DataBind();

        }
    }
    //Method for assigning departments to the dropdown list
    public void AccmdtnType_Load()
    {
        ddlAccmdtnType.Items.Clear();
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccommodation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccommodation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtAccmdtnType = objBusinessLayerAccommodation.ReadAccommodationType(objEntityAccommodation);

        ddlAccmdtnType.DataSource = dtAccmdtnType;

        ddlAccmdtnType.DataTextField = "ACCOMDTNCAT_NAME";
        ddlAccmdtnType.DataValueField = "ACCOMDTNCAT_ID";
        ddlAccmdtnType.DataBind();
        SortDDL(ref this.ddlAccmdtnType);

        ddlAccmdtnType.Items.Insert(0, "--SELECT CATEGORY--");
    }
    //Method for assigning CORDINATOR to the dropdown list
    public void Coordinator_Load()
    {
        ddlCoordinator.Items.Clear();
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccommodation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccommodation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtAccmdtnType = objBusinessLayerAccommodation.ReadEmployeeList(objEntityAccommodation);

        ddlCoordinator.DataSource = dtAccmdtnType;

        ddlCoordinator.DataTextField = "USR_NAME";
        ddlCoordinator.DataValueField = "USR_ID";
        ddlCoordinator.DataBind();
        SortDDL(ref this.ddlCoordinator);
        ddlCoordinator.Items.Insert(0, "--SELECT COORDINATOR--");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccommodation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccommodation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (cbxStatus.Checked == true)
            {
                objEntityAccommodation.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityAccommodation.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityAccommodation.AccommodationId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityAccommodation.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityAccommodation.Date = System.DateTime.Now;
            objEntityAccommodation.AccoAddress = txtAdrss.Text.Trim();
            objEntityAccommodation.AccommodationType = Convert.ToInt32(ddlAccmdtnType.SelectedItem.Value);
            objEntityAccommodation.AccoName = txtName.Text.ToUpper().Trim();
            if (txtNoOfFloor.Text.Trim() != "")
            {
                objEntityAccommodation.No_Of_Floor = Convert.ToInt32(txtNoOfFloor.Text.Trim());
            }
            else
            {
                objEntityAccommodation.No_Of_Floor = Convert.ToInt32(hiddenNo_Of_Flr.Value);
            }
            objEntityAccommodation.Location = txtLocation.Text;
            if (cbxHaveMess.Checked == true)
            {
                objEntityAccommodation.HavMessId = 1;
                objEntityAccommodation.CordinatorId = Convert.ToInt32(ddlCoordinator.SelectedItem.Value);
                objEntityAccommodation.No_of_Sbscriber = Convert.ToInt32(txtNoOfSubscribr.Text.Trim());

            }
            else
            {
                objEntityAccommodation.HavMessId = 0;

            }
            objEntityAccommodation.Bus = HiddenFieldBu.Value;
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerAccommodation.CheckAccommodationName(objEntityAccommodation);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLayerAccommodation.UpdateAccommodation(objEntityAccommodation);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Accommodation_Master.aspx?InsUpd=Upd&Id=" + strRandomMixedId);
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Accommodation_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have

            else
            {


                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtName.Focus();

            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccommodation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccommodation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (cbxStatus.Checked == true)
        {
            objEntityAccommodation.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityAccommodation.Status_id = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityAccommodation.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityAccommodation.Date = System.DateTime.Now;
        objEntityAccommodation.AccoAddress = txtAdrss.Text.Trim();
        objEntityAccommodation.AccommodationType = Convert.ToInt32(ddlAccmdtnType.SelectedItem.Value);
        objEntityAccommodation.AccoName = txtName.Text.ToUpper().Trim();
        objEntityAccommodation.No_Of_Floor = Convert.ToInt32(txtNoOfFloor.Text.Trim());
        objEntityAccommodation.Location = txtLocation.Text;
        if (cbxHaveMess.Checked == true)
        {
            objEntityAccommodation.HavMessId = 1;
            objEntityAccommodation.CordinatorId = Convert.ToInt32(ddlCoordinator.SelectedItem.Value);
            objEntityAccommodation.No_of_Sbscriber = Convert.ToInt32(txtNoOfSubscribr.Text.Trim());

        }
        else
        {
            objEntityAccommodation.HavMessId = 0;

        }
        objEntityAccommodation.Bus = HiddenFieldBu.Value;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerAccommodation.CheckAccommodationName(objEntityAccommodation);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            int AccId = objBusinessLayerAccommodation.AddAccommodation(objEntityAccommodation);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            string strId = AccId.ToString();
            int intIdLength = AccId.ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Accommodation_Master.aspx?InsUpd=Ins&Id=" + Id);
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Accommodation_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {


            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtName.Focus();

        }
    }
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        objEntityAccommodation.AccommodationId = Convert.ToInt32(strP_Id);
        objEntityAccommodation.Corporate_id = intCorpId;
        DataTable dtAccommodationById = objBusinessLayerAccommodation.ReadAccommodationById(objEntityAccommodation);
        if (dtAccommodationById.Rows.Count > 0)
        {

            HiddenFieldBu.Value = dtAccommodationById.Rows[0]["ACCMDTN_BUS"].ToString();

            txtName.Text = dtAccommodationById.Rows[0]["ACCMDTN_NAME"].ToString();
            txtAdrss.Text = dtAccommodationById.Rows[0]["ACCMDTN_ADDRS"].ToString();
            
            if (dtAccommodationById.Rows[0]["ACCOMDTNCAT_STATUS"].ToString() == "1")
            {
                ddlAccmdtnType.Items.FindByValue(dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lst = new ListItem(dtAccommodationById.Rows[0]["ACCOMDTNCAT_NAME"].ToString(), dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString());
                ddlAccmdtnType.Items.Insert(1, lst);
                SortDDL(ref this.ddlAccmdtnType);
                ddlAccmdtnType.ClearSelection();
                ddlAccmdtnType.Items.FindByValue(dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString()).Selected = true;
            }

            int intAccmdtnStatus = Convert.ToInt32(dtAccommodationById.Rows[0]["ACCMDTN_STATUS"]);
            if (intAccmdtnStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            int inthavMess = Convert.ToInt32(dtAccommodationById.Rows[0]["ACCMDTN_HAVE_MESS_STS"]);
            if (inthavMess == 1)
            {
                cbxHaveMess.Checked = true;
                if (dtAccommodationById.Rows[0]["USR_STATUS"].ToString() == "1" && dtAccommodationById.Rows[0]["USR_CNCL_USR_ID"].ToString()!="")
                {
                    ddlCoordinator.Items.FindByValue(dtAccommodationById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {

                    ListItem lst = new ListItem(dtAccommodationById.Rows[0]["USR_NAME"].ToString(), dtAccommodationById.Rows[0]["USR_ID"].ToString());
                    ddlCoordinator.Items.Insert(1, lst);
                    SortDDL(ref this.ddlCoordinator);
                    ddlCoordinator.ClearSelection();
                    ddlCoordinator.Items.FindByValue(dtAccommodationById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                txtNoOfSubscribr.Text = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_SUBSCRBR"].ToString();
            }
            else
            {
                cbxHaveMess.Checked = false;
            }
          
            txtNoOfFloor.Text = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_FLOOR"].ToString();
            hiddenNo_Of_Flr.Value = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_FLOOR"].ToString();
            txtLocation.Text = dtAccommodationById.Rows[0]["ACCMDTN_LOCATION"].ToString();
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        hiddenViewTrue.Value = "1";
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        objEntityAccommodation.AccommodationId = Convert.ToInt32(strP_Id);
        objEntityAccommodation.Corporate_id = intCorpId;
        DataTable dtAccommodationById = objBusinessLayerAccommodation.ReadAccommodationById(objEntityAccommodation);
        if (dtAccommodationById.Rows.Count > 0)
        {
            HiddenFieldBu.Value = dtAccommodationById.Rows[0]["ACCMDTN_BUS"].ToString();
            txtName.Text = dtAccommodationById.Rows[0]["ACCMDTN_NAME"].ToString();
            txtAdrss.Text = dtAccommodationById.Rows[0]["ACCMDTN_ADDRS"].ToString();

            if (dtAccommodationById.Rows[0]["ACCOMDTNCAT_STATUS"].ToString() == "1")
            {
                ddlAccmdtnType.Items.FindByValue(dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lst = new ListItem(dtAccommodationById.Rows[0]["ACCOMDTNCAT_NAME"].ToString(), dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString());
                ddlAccmdtnType.Items.Insert(1, lst);
                SortDDL(ref this.ddlAccmdtnType);
                ddlAccmdtnType.ClearSelection();
                ddlAccmdtnType.Items.FindByValue(dtAccommodationById.Rows[0]["ACCOMDTNCAT_ID"].ToString()).Selected = true;
            }
            int intAccmdtnStatus = Convert.ToInt32(dtAccommodationById.Rows[0]["ACCMDTN_STATUS"]);
            if (intAccmdtnStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            int inthavMess = Convert.ToInt32(dtAccommodationById.Rows[0]["ACCMDTN_HAVE_MESS_STS"]);
            if (inthavMess == 1)
            {
                cbxHaveMess.Checked = true;
                if (dtAccommodationById.Rows[0]["USR_STATUS"].ToString() == "1")
                {
                    ddlCoordinator.Items.FindByValue(dtAccommodationById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {

                    ListItem lst = new ListItem(dtAccommodationById.Rows[0]["USR_NAME"].ToString(), dtAccommodationById.Rows[0]["USR_ID"].ToString());
                    ddlCoordinator.Items.Insert(1, lst);
                    SortDDL(ref this.ddlCoordinator);
                    ddlCoordinator.ClearSelection();
                    ddlCoordinator.Items.FindByValue(dtAccommodationById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                txtNoOfSubscribr.Text = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_SUBSCRBR"].ToString();
            }
            else
            {
                cbxHaveMess.Checked = false;
            }

            txtNoOfFloor.Text = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_FLOOR"].ToString();
            hiddenNo_Of_Flr.Value = dtAccommodationById.Rows[0]["ACCMDTN_NO_OF_FLOOR"].ToString();
            txtLocation.Text = dtAccommodationById.Rows[0]["ACCMDTN_LOCATION"].ToString();
        }
        txtName.Enabled = false;
        ddlAccmdtnType.Enabled = false;
        txtAdrss.Enabled = false;
        cbxStatus.Enabled = false;
        cbxHaveMess.Enabled = false;
        ddlCoordinator.Enabled = false;
        txtNoOfSubscribr.Enabled = false;
        txtLocation.Enabled = false;
        ddlBus.Enabled = false;
    }
  
    //for loading sub category table
    [WebMethod]
    public static string[] SubCategoryLoad(string strCatId,string strAccoId)
    {
        clsBusinessLayerAccommodation objBusinessLayerAccommodation = new clsBusinessLayerAccommodation();
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        objEntityAccommodation.AccommodationType = Convert.ToInt32(strCatId);
        string[] Passing = new string[2];
        DataTable dt = objBusinessLayerAccommodation.ReadAcmdtnDetailByid(objEntityAccommodation);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" style=\"margin-bottom: 0px;\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\" style=\"width:60%;text-align:left; word-wrap:break-word;\">ROOM NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:30%;text-align:left; word-wrap:break-word;\">COUNT</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 0;
        string possibleToeditFlr = "true";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string eachpossibleToeditFlr = "true";
            string Strid = dt.Rows[intRowBodyCount][0].ToString();
            int DetailCount = 0;
            if (strAccoId != "0")
            {
                objEntityAccommodation.AccommodationId = Convert.ToInt32(strAccoId);
                objEntityAccommodation.SubcategoryId = Convert.ToInt32(Strid);
                DataTable dtSubDetail = objBusinessLayerAccommodation.ReadSubCatDetail(objEntityAccommodation);
                DetailCount = dtSubDetail.Rows.Count;
                if (DetailCount > 0)
                {
                    possibleToeditFlr = "false";
                    eachpossibleToeditFlr = "false";
                }
            }
            count++;

            strHtml += "<tr  >";

            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

            strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\"  ><input style=\" width:38%;\" id=txt-" + Strid + " type=\"text\"  value=\""+DetailCount+"\"  disabled=\"disabled\" maxlength=\"3\" onkeydown=\"return isNumber(event);\" />";
            if (eachpossibleToeditFlr == "true")
            {
                if (strAccoId != "0")
                {
                    strHtml += "<input type=\"Button\" value=\"Add Detail\" id=btnMoreDtl-" + Strid + " style=\"  width:43%;margin-left: 8%;color: #0f4115;background-color: #bec9bf;\" onclick=DisplayPopUp(\'btnMoreDtl-" + Strid + "\',\'" + Strid + "\'); /></td>";
                }
                else
                {
                    strHtml += "<input type=\"Button\" value=\"Add Detail\" id=btnMoreDtl-" + Strid + " style=\"  width:43%;margin-left: 8%;color: #0f4115;background-color: #bec9bf;\" onclick=DontDisplayPopUp(); /></td>";
                }
            }

            else
            {
                strHtml += "<input type=\"Button\" value=\"Edit Detail\" id=btnMoreDtl-" + Strid + " style=\"  width:43%;margin-left: 8%;color: #0f4115;background-color: #bec9bf;\" onclick=DisplayPopUp(\'btnMoreDtl-" + Strid + "\',\'" + Strid + "\'); /></td>";
            }
            strHtml += "</tr>";
        }


        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        Passing[0] = sb.ToString();
        Passing[1] = possibleToeditFlr;
        return Passing;
        //divSubcatContainer.InnerHtml = sb.ToString();
    }
    public class clsAccomodData
    {
        public string ROWID { get; set; }
        public string NAME { get; set; }
        public string FLOOR { get; set; }
        public string DETAILID { get; set; }
        public string SUBDTLID { get; set; }
        public string EVENTNAME { get; set; }

    }
    protected void btnPopSave_Click(object sender, EventArgs e)
    {
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        List<clsEntityAccommodation> objEntityAccommodationAddList = new List<clsEntityAccommodation>();
        List<clsEntityAccommodation> objEntityAccommodationUpdateList = new List<clsEntityAccommodation>();
        List<clsEntityAccommodation> objEntityAccommodationDeleteList = new List<clsEntityAccommodation>();
        objEntityAccommodation.AccommodationId = Convert.ToInt32(hiddenAccomodationId.Value);
        objEntityAccommodation.AccommodationType = Convert.ToInt32(ddlAccmdtnType.SelectedItem.Value);
        if (hiddenTotalData.Value != "")
        {
            string jsonDataPW = hiddenTotalData.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsAccomodData> objWBDataPWList = new List<clsAccomodData>();
            // UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsAccomodData>>(R5PW);

            foreach (clsAccomodData objclsJSData in objWBDataPWList)
            {
                clsEntityAccommodation objEachAco = new clsEntityAccommodation();
                objEachAco.SubcategoryId = Convert.ToInt32(objclsJSData.DETAILID); ;
                objEachAco.FloorName = objclsJSData.NAME;
                objEachAco.FloorNo = Convert.ToInt32(objclsJSData.FLOOR);              
                if (objclsJSData.EVENTNAME == "INS")
                {
                    objEntityAccommodationAddList.Add(objEachAco);
                }
                else
                {
                    objEachAco.SubcategoryDetailId = Convert.ToInt32(objclsJSData.SUBDTLID);
                    objEntityAccommodationUpdateList.Add(objEachAco);
                }

            }

        }
        if (hiddenDeletedDetail.Value != "")
        {
            string DelData = hiddenDeletedDetail.Value;
            string[] SplitData = DelData.Split(',');
            foreach (string dataPlited in SplitData)
            {
                if (dataPlited != "")
                {
                    clsEntityAccommodation objEachAcoDel = new clsEntityAccommodation();
                    objEachAcoDel.SubcategoryDetailId = Convert.ToInt32(dataPlited);
                    objEntityAccommodationDeleteList.Add(objEachAcoDel);
                }
            }
        }
        string aa = txtNoOfFloor.Text;
        objBusinessLayerAccommodation.Insert_Sub_Detail(objEntityAccommodation, objEntityAccommodationAddList, objEntityAccommodationUpdateList, objEntityAccommodationDeleteList);

        ScriptManager.RegisterStartupScript(this, GetType(), "DetailsaveSucess", "DetailsaveSucess();", true);
    }

    [WebMethod]
    public static string[] ReadSuCatDetail(string intAccId, string intSubCatId)
    {
        clsBusinessLayerAccommodation objBusinessLayerAccommodation = new clsBusinessLayerAccommodation();
        clsEntityAccommodation objEntityAccommodation = new clsEntityAccommodation();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        objEntityAccommodation.AccommodationId = Convert.ToInt32(intAccId);
        objEntityAccommodation.SubcategoryId = Convert.ToInt32(intSubCatId);
        string[] strJsonDW = new string[1];

        DataTable dtSubDetail = objBusinessLayerAccommodation.ReadSubCatDetail(objEntityAccommodation);
        if (dtSubDetail.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("SubId", typeof(int));
            dtDetail.Columns.Add("SubDtlId", typeof(int));
            dtDetail.Columns.Add("DtlName", typeof(string));
            dtDetail.Columns.Add("DtlFloor", typeof(string));
            dtDetail.Columns.Add("SubId_Del_Chk", typeof(string));
            foreach (DataRow dtRow in dtSubDetail.Rows)
            {
                DataRow dtDetRow = dtDetail.NewRow();

                dtDetRow["SubId"] = dtRow["ACCOMDTNCATSUB_ID"];
                dtDetRow["SubDtlId"] = dtRow["ACSUBCATDTL_ID"];
                dtDetRow["DtlName"] = dtRow["ACSUBCATDTL_NAME"];
                dtDetRow["DtlFloor"] = dtRow["ACSUBCATDTL_FLOOR"];

                dtDetRow["SubId_Del_Chk"] = dtRow["DEL_ACSUBCATDTL_ID"];

                dtDetail.Rows.Add(dtDetRow);


            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[0] = jsSerializer.Serialize(parentRow);
        }

        return strJsonDW;
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
}

