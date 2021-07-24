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
// CREATED BY:EVM-0001
// CREATED DATE:11/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_WorkStation_gen_WorkStationAdd : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinessLayerWorkStation objBusinessLayerWorkStation = new clsBusinessLayerWorkStation();
   
    protected void Page_Load(object sender, EventArgs e)
    {



        //Assigning  Key actions  .

        txtWorkStationName.Attributes.Add("onkeypress", "return isTag(event)");
        txtWorkStationName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlWorkArea.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlWorkArea.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //cbxMultipleInstance.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //cbxMultipleInstance.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            txtWorkStationName.Focus();

          
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Workstation";
                lblEntryB.InnerText = "Edit Workstation";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Workstation";
                lblEntryB.InnerText = "View Workstation";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Workstation";
                lblEntryB.InnerText = "Add Workstation";
                WorkArea_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
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
            }
        }
    }
    //Method for assigning Premise to the dropdown list
    public void WorkArea_Load()
    {
        clsEntityWorkStation objEntityStation = new clsEntityWorkStation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityStation.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityStation.Organisation_Id = Convert.ToInt32(Session["ORGID"]);

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        DataTable dtWorkArea = objBusinessLayerWorkStation.ReadWorkArea(objEntityStation);
        DataView dvWorkArea = new DataView(dtWorkArea);
        dvWorkArea.Sort = "DPTAREA_NAME";
        ddlWorkArea.DataSource = dvWorkArea;
        for (int intDtCnt = 0; intDtCnt < dtWorkArea.Rows.Count; intDtCnt++)
        {
            ddlWorkArea.DataTextField = "DPTAREA_NAME";
            ddlWorkArea.DataValueField = "DPTAREA_ID";
            ddlWorkArea.DataBind();
        }
        ddlWorkArea.Items.Insert(0, "--SELECT PREMISE AREA--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityWorkStation objEntityStation = new clsEntityWorkStation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityStation.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityStation.Organisation_Id = Convert.ToInt32(Session["ORGID"]);

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
     

        objEntityStation.WorkArea_Id = Convert.ToInt32(ddlWorkArea.SelectedItem.Value);
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityStation.WorkStation_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityStation.WorkStation_Status = 0;
        }
        //need multiple instatnce or not
        //if (cbxMultipleInstance.Checked == true)
        //{
        //    objEntityStation.Multiple_Instance = 1;
        //}
        //else
        //{
        //    objEntityStation.Multiple_Instance = 0;
        //}
        if (Session["USERID"] != null)
        {
            objEntityStation.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityStation.D_Date = System.DateTime.Now;
        txtWorkStationName.Value = txtWorkStationName.Value.ToUpper().Trim();
        objEntityStation.WorkStation_Name = txtWorkStationName.Value;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerWorkStation.Check_WorkStation_Name(objEntityStation);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerWorkStation.Insert_WorkStation(objEntityStation);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_WorkStation.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_WorkStationList.aspx?InsUpd=Ins");
            }
          
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtWorkStationName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityWorkStation objEntityStation = new clsEntityWorkStation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityStation.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityStation.Organisation_Id = Convert.ToInt32(Session["ORGID"]);

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        objEntityStation.WorkArea_Id = Convert.ToInt32(ddlWorkArea.SelectedItem.Value);
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityStation.WorkStation_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityStation.WorkStation_Status = 0;
        }
        //need multiple instatnce or not
        //if (cbxMultipleInstance.Checked == true)
        //{
        //    objEntityStation.Multiple_Instance = 1;
        //}
        //else
        //{
        //    objEntityStation.Multiple_Instance = 0;
        //}
        if (Session["USERID"] != null)
        {
            objEntityStation.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityStation.D_Date = System.DateTime.Now;
        txtWorkStationName.Value = txtWorkStationName.Value.ToUpper().Trim();
        objEntityStation.WorkStation_Name = txtWorkStationName.Value;
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityStation.WorkStation_Master_Id = Convert.ToInt32(strId);
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerWorkStation.Check_WorkStation_NameUpdation(objEntityStation);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerWorkStation.Update_WorkStation(objEntityStation);

            if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
            {
                Response.Redirect("gen_WorkStation.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
            {
                Response.Redirect("gen_WorkStationList.aspx?InsUpd=Upd");
            }
           
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtWorkStationName.Focus();
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strWS_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityWorkStation objEntityStation = new clsEntityWorkStation();
        objEntityStation.WorkStation_Master_Id = Convert.ToInt32(strWS_Id);
        DataTable dtWorkStationById = objBusinessLayerWorkStation.ReadWorkStationById(objEntityStation);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtWorkStationName.Value = dtWorkStationById.Rows[0]["WRKSTN_NAME"].ToString();

        ddlWorkArea.Items.Clear();
        ListItem lst = new ListItem(dtWorkStationById.Rows[0]["DPTAREA_NAME"].ToString(), dtWorkStationById.Rows[0]["DPTAREA_ID"].ToString());
        ddlWorkArea.Items.Insert(0, lst);
        
        int intWorkAreaStatus = Convert.ToInt32(dtWorkStationById.Rows[0]["WRKSTN_STATUS"]);
        if (intWorkAreaStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        int intMultipleInstance = Convert.ToInt32(dtWorkStationById.Rows[0]["WRKSTN_MULT_INSTCE"]);
        //if (intMultipleInstance == 1)
        //{
        //    cbxMultipleInstance.Checked = true;
        //}
        //else
        //{
        //    cbxMultipleInstance.Checked = false;
        //}
        txtWorkStationName.Disabled = true;
        ddlWorkArea.Enabled = false;
        //cbxMultipleInstance.Enabled = false;
        cbxStatus.Disabled = true;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWS_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityWorkStation objEntityStation = new clsEntityWorkStation();
        objEntityStation.WorkStation_Master_Id = Convert.ToInt32(strWS_Id);
        DataTable dtWorkStationById = objBusinessLayerWorkStation.ReadWorkStationById(objEntityStation);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtWorkStationName.Value = dtWorkStationById.Rows[0]["WRKSTN_NAME"].ToString();
        WorkArea_Load();
        //ie IF  DPTAREA IS ACTIVE
        if (dtWorkStationById.Rows[0]["DPTAREA_STATUS"].ToString() == "1" && dtWorkStationById.Rows[0]["DPTAREA_CNCL_USR_ID"].ToString() == "")
        {
            ddlWorkArea.Items.FindByText(dtWorkStationById.Rows[0]["DPTAREA_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lst = new ListItem(dtWorkStationById.Rows[0]["DPTAREA_NAME"].ToString(), dtWorkStationById.Rows[0]["DPTAREA_ID"].ToString());
            ddlWorkArea.Items.Insert(1, lst);

            SortDDL(ref this.ddlWorkArea);

            ddlWorkArea.Items.FindByText(dtWorkStationById.Rows[0]["DPTAREA_NAME"].ToString()).Selected = true;
        }
       //work area status
        int intWorkAreaStatus = Convert.ToInt32(dtWorkStationById.Rows[0]["WRKSTN_STATUS"]);
        if (intWorkAreaStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        //multiple instatnces
        int intMultipleInstance = Convert.ToInt32(dtWorkStationById.Rows[0]["WRKSTN_MULT_INSTCE"]);
        //if (intMultipleInstance == 1)
        //{
        //    cbxMultipleInstance.Checked = true;
        //}
        //else
        //{
        //    cbxMultipleInstance.Checked = false;
        //}
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
