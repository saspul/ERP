using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;
// CREATED BY:EVM-0001
// CREATED DATE:10/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_TeamHierarchy_gen_TeamHierarchy : System.Web.UI.Page
{//Creating objects for businesslayer
    clsBusinessLayerTeamHierarchy objBusinessLayerTeamHierarchy = new clsBusinessLayerTeamHierarchy();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtTeamName.Attributes.Add("onkeypress", "return isTag(event)");
        txtTeamName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTeamLead.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTeamLead.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
           // imgBtnSearch.ImageUrl = "/Images/Icons/searchMedium.png";
            clsCommonLibrary objCommon = new clsCommonLibrary();

            hiddenUserImagePath.Value =objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
            txtTeamName.Focus();
            Division_Load();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                hiddenFieldTeamId.Value = strId;

                Update(strId);
                lblEntry.Text = "Edit Team";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

              //  View(strId);
                Update(strId);

                lblEntry.Text = "View Team";
                hiddenViewMode.Value = "1";
            }

            else
            {
                lblEntry.Text = "Add Team";
            //    TeamLead_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
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

    //Method for assigning Lead to the dropdown list
    //public void TeamLead_Load()
    //{
    //    clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    DataTable dtTeamLeader = objBusinessLayerTeamHierarchy.ReadUsersForTeamLead(objEntityTeamHierarchy);

    //    ddlTeamLead.DataSource = dtTeamLeader;

    //    ddlTeamLead.DataTextField = "USR_NAME";
    //    ddlTeamLead.DataValueField = "USR_ID";
    //    ddlTeamLead.DataBind();

    //    ddlTeamLead.Items.Insert(0, "--SELECT TEAM LEAD--");
    //}
    //Method for assigning Division to the dropdown list
    public void Division_Load()
    {
        clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDivsn = objBusinessLayerTeamHierarchy.ReadDivision(objEntityTeamHierarchy);

        ddlDivision.DataSource = dtDivsn;

        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityTeamHierarchy.TeamLeadEmp_Id = Convert.ToInt32(hiddenFieldTeamLeadEmp_Id.Value);


        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityTeamHierarchy.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityTeamHierarchy.Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityTeamHierarchy.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityTeamHierarchy.D_Date = System.DateTime.Now;
        txtTeamName.Text = txtTeamName.Text.ToUpper().Trim();
        objEntityTeamHierarchy.TeamName = txtTeamName.Text.Trim();
  


     

            List<clsEntityLayerTeamMember> objEntityTeamMemberList = new List<clsEntityLayerTeamMember>();

            if (HiddenField1.Value != "")
            {
                string jsonData = HiddenField1.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string g = c.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsTM_Data> objTM_DataList = new List<clsTM_Data>();
                //   UserData  data
                objTM_DataList = JsonConvert.DeserializeObject<List<clsTM_Data>>(i);




                foreach (clsTM_Data objClsTMData in objTM_DataList)
                {
                    clsEntityLayerTeamMember objEntityTeamMember = new clsEntityLayerTeamMember();

                    objEntityTeamMember.TeamMemberEmp_Id = Convert.ToInt32(objClsTMData.USERID);
                    objEntityTeamMember.CorpOffice_Id = objEntityTeamHierarchy.CorpOffice_Id;
                    objEntityTeamMember.Organisation_Id = objEntityTeamHierarchy.Organisation_Id;
                    objEntityTeamMemberList.Add(objEntityTeamMember);

                }


            }
              //Checking is there table have any name like this
               string strNameCount = objBusinessLayerTeamHierarchy.CheckTeamName(objEntityTeamHierarchy);
               //If there is no name like this on table.    
               if (strNameCount == "0")
               {
                   objBusinessLayerTeamHierarchy.InsertTeamDetail(objEntityTeamHierarchy, objEntityTeamMemberList);
                   if (clickedButton.ID == "btnAdd")
                   {
                       Response.Redirect("gen_TeamHierarchy.aspx?InsUpd=Ins");
                   }
                   else if (clickedButton.ID == "btnAddClose")
                   {
                       Response.Redirect("gen_TeamHierarchyList.aspx?InsUpd=Ins");
                   }
                 
                  
               }
               //If have
               else
               {
                   ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                   txtTeamName.Focus();
               }
          
        }
    

 public class clsTM_Data
    {
        public string USERID { get; set; }
      
    }
    //When Update Button is clicked
   protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            bool blMemberEdited=true;


            clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityTeamHierarchy.TeamLeadEmp_Id = Convert.ToInt32(hiddenFieldTeamLeadEmp_Id.Value);
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityTeamHierarchy.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityTeamHierarchy.Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityTeamHierarchy.TeamId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityTeamHierarchy.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityTeamHierarchy.D_Date = System.DateTime.Now;
            txtTeamName.Text = txtTeamName.Text.ToUpper().Trim();
            objEntityTeamHierarchy.TeamName = txtTeamName.Text.Trim();

             List<clsEntityLayerTeamMember> objEntityTeamMemberList = new List<clsEntityLayerTeamMember>();

            if (HiddenField1.Value != "")
            {
                if (hiddenCheckEdit.Value != "")
                {
                    blMemberEdited = true;

                    string jsonData = HiddenField1.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string g = c.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string i = h.Replace("}\",", "},");
                    List<clsTM_Data> objTM_DataList = new List<clsTM_Data>();
                    //   UserData  data
                    objTM_DataList = JsonConvert.DeserializeObject<List<clsTM_Data>>(i);




                    foreach (clsTM_Data objClsTMData in objTM_DataList)
                    {
                        clsEntityLayerTeamMember objEntityTeamMember = new clsEntityLayerTeamMember();

                        objEntityTeamMember.TeamMemberEmp_Id = Convert.ToInt32(objClsTMData.USERID);
                        objEntityTeamMember.CorpOffice_Id = objEntityTeamHierarchy.CorpOffice_Id;
                        objEntityTeamMember.Organisation_Id = objEntityTeamHierarchy.Organisation_Id;
                        objEntityTeamMemberList.Add(objEntityTeamMember);

                    }
                }
                else
                {
                    blMemberEdited = false;
                
                }

            }

            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerTeamHierarchy.CheckTeamName(objEntityTeamHierarchy);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLayerTeamHierarchy.Update_TeamDetail(objEntityTeamHierarchy, objEntityTeamMemberList,blMemberEdited);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_TeamHierarchy.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_TeamHierarchyList.aspx?InsUpd=Upd");
                }
               
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtTeamName.Focus();
            }    
           
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
   public void View(string strT_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
        objEntityTeamHierarchy.TeamId = Convert.ToInt32(strT_Id);
        DataTable dtTeamById = objBusinessLayerTeamHierarchy.ReadTeamById(objEntityTeamHierarchy);
        DataTable dtTeamMemberById = objBusinessLayerTeamHierarchy.ReadTeamMembersById(objEntityTeamHierarchy);

        txtTeamName.Text = dtTeamById.Rows[0]["TEAM_NAME"].ToString();
       // ddlTeamLead.Items.Clear();
        ListItem lst = new ListItem(dtTeamById.Rows[0]["USR_NAME"].ToString(), dtTeamById.Rows[0]["TEAM_LEAD_EMP_ID"].ToString());
     //   ddlTeamLead.Items.Insert(0, lst);

        int intStatus = Convert.ToInt32(dtTeamById.Rows[0]["TEAM_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        string strHtm = ConvertTableForView(dtTeamMemberById);
        //Write to divReport
        divMembersView.InnerHtml = strHtm;
        txtTeamName.Enabled = false;
       // ddlTeamLead.Enabled = false;
        cbxStatus.Enabled = false;
        hiddenView.Value = strT_Id;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strT_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
        objEntityTeamHierarchy.TeamId = Convert.ToInt32(strT_Id);
        DataTable dtTeamById = objBusinessLayerTeamHierarchy.ReadTeamById(objEntityTeamHierarchy);
        DataTable dtTeamMemberById = objBusinessLayerTeamHierarchy.ReadTeamMembersById(objEntityTeamHierarchy);

        txtTeamName.Text = dtTeamById.Rows[0]["TEAM_NAME"].ToString();
       // TeamLead_Load();
        //ie IF  Department IS ACTIVE
        if (dtTeamById.Rows[0]["USR_STATUS"].ToString() == "1" && dtTeamById.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
        {
        //    ddlTeamLead.Items.FindByValue(dtTeamById.Rows[0]["TEAM_LEAD_EMP_ID"].ToString()).Selected = true;
        }
        //else
        //{
        //    ListItem lst = new ListItem(dtTeamById.Rows[0]["USR_NAME"].ToString(), dtTeamById.Rows[0]["TEAM_LEAD_EMP_ID"].ToString());
        //    ddlTeamLead.Items.Insert(1, lst);

        //    SortDDL(ref this.ddlTeamLead);

        //    ddlTeamLead.Items.FindByValue(dtTeamById.Rows[0]["TEAM_LEAD_EMP_ID"].ToString()).Selected = true;
        //}


        if (dtTeamById.Rows[0]["USR_STATUS"].ToString() == "1" && dtTeamById.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
        {
            txtTeamLead.Text = dtTeamById.Rows[0]["USR_NAME"].ToString();
            hiddenFieldTeamLeadEmp_Id.Value = dtTeamById.Rows[0]["TEAM_LEAD_EMP_ID"].ToString();
        }
        else
        {

        }




        int intStatus = Convert.ToInt32(dtTeamById.Rows[0]["TEAM_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

      //  TeamLead_SelectedChanged();


        DataTable dtMbr = new DataTable();
        dtMbr.Columns.Add("UsrId", typeof(int));
        dtMbr.Columns.Add("UsrImg", typeof(string));
        dtMbr.Columns.Add("UsrName", typeof(string));
        if (dtTeamMemberById.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtTeamMemberById.Rows.Count; intcnt++)
            {
                DataRow dr = dtMbr.NewRow();
                dr["UsrId"] = Convert.ToInt32(dtTeamMemberById.Rows[intcnt]["TEAMBRS_MEMBRS_ID"].ToString());
                if (dtTeamMemberById.Rows[intcnt]["USR_IMAGE"].ToString() != "")
                {
                    string strImagePath =dtTeamMemberById.Rows[intcnt]["USR_IMAGE"].ToString();
                    dr["UsrImg"] = hiddenUserImagePath.Value + strImagePath;
                }
                else
                {
                    string strImagePath = "/Images/Icons/wlcm.png";
                    dr["UsrImg"] =  strImagePath;
                
                }
                dr["UsrName"] = dtTeamMemberById.Rows[intcnt]["USR_NAME"].ToString();
                dtMbr.Rows.Add(dr);
             
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtMbr);
            hiddenEdit.Value = strJson;
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
    //protected void ddlTeamLead_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    hiddenConfirmValue.Value = "IncrmntConfrmCounter";
    //  //  TeamLead_SelectedChanged();

    //}
    //public void TeamLead_SelectedChanged()
    //{
    //    clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();

    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (ddlTeamLead.SelectedValue == "--SELECT TEAM LEAD--")
    //    {

    //     //   divUsers.InnerHtml = "";

    //    }
    //    else
    //    {
    //        objEntityTeamHierarchy.TeamLeadEmp_Id = Convert.ToInt32(ddlTeamLead.SelectedValue);

    //        if (Request.QueryString["Id"] != null)
    //        {

    //            string strRandomMixedId = Request.QueryString["Id"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            string strId = strRandomMixedId.Substring(2, intLenghtofId);
    //            objEntityTeamHierarchy.TeamId = Convert.ToInt32(strId);
    //        }


    //        DataTable dtMembers = new DataTable();
    //        dtMembers = objBusinessLayerTeamHierarchy.ReadUsersForMember(objEntityTeamHierarchy);

    //     //   string strHtm = ConvertDataTableToHTML(dtMembers);
    //        //Write to divReport
    //       // divUsers.InnerHtml = strHtm;


    //    }

      
    //}


    //It build the Html table by using the datatable provided
    public string ConvertTableForView(DataTable dt)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();
        

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"TableMemberViewList\" style=\"border: 1px solid #afb6a2; height:52px;width:100%;\" cellspacing=\"0\" cellpadding=\"2px\" >";
        string strForImageDiv = "";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            strHtml += "<tr id=\"tr_" + dt.Rows[intRowBodyCount][0].ToString() + "\" class=\"border_bottom\" >";
     
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}




                if (intColumnBodyCount == 1)
                {
                 
                   // strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != null && dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                    {
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC) +dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                        strHtml += "<td  style=\"width:10%; height:40px; word-wrap:break-word;text-align: center;\">" + " <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img  id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' /> " + "</a> </td>";

                        strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

                        strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
                        strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
                        strForImageDiv += "</div>";

                    }
                    else
                    {
                        string strImagePath = "/Images/Icons/wlcm.png";// class=\"lightbox\"
                        strHtml += "<td   style=\"width:10%;height:40px; word-wrap:break-word;text-align: center;\" > <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img   id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' />" + "</a></td>";

                        strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

                        strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
                        strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
                        strForImageDiv += "</div>";
                    }
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td  style=\"font-family: Calibri;color: #a9b496;font-size: 14px;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0%; width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
               
                  
                

            }
            //strHtml += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;padding-left: 0;\"><a href=\"\" onclick = \"return removeRow(" + dt.Rows[intRowBodyCount][0].ToString() + ");\"> select<a> </td>";




         
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";


        divForgoofyView.InnerHtml = strForImageDiv;
        sb.Append(strHtml);
        return sb.ToString();
    }


    //It build the Html table by using the datatable provided
    //public string ConvertDataTableToHTML(DataTable dt)
    //{


    //    clsCommonLibrary objCommon = new clsCommonLibrary();


    //    // class="table table-bordered table-striped"
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"TableEmployeeList\" style=\"border: 1px solid #afb6a2;\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    string strForImageDiv = "";
    //    //add rows

    //    strHtml += "<tbody>";
    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {

    //        int intMemberInOtherTeamCount = Convert.ToInt32(dt.Rows[intRowBodyCount]["TMCOUNT"].ToString());
    //        strHtml += "<tr id=\"tr_" + dt.Rows[intRowBodyCount][0].ToString() + "\" class=\"border_bottom\" >";
    //        strHtml += " <td id=\"tdId_" + dt.Rows[intRowBodyCount][0].ToString() + "\" style=\"display: none;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
    //        //for flag to identify if a member is already selected in other group or not
    //        if (intMemberInOtherTeamCount != 0)
    //        {
    //            strHtml += "<td  style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
    //        }
    //        else
    //        {
    //            strHtml += "<td style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
    //                     "<img   src='../../Images/Icons/freeIcon.jpg' style=\"margin-top: 79%;\" /> " + " </td>";
    //        }
    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //        {
    //            //if (j == 0)
    //            //{
    //            //    int intCnt = i + 1;
    //            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //            //}




    //            if (intColumnBodyCount == 1)
    //            {

    //                // strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != null && dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
    //                {
    //                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC) + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
    //                    strHtml += "<td  style=\"width:10%; height:40px; word-wrap:break-word;text-align: center;\">" + " <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img  id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' /> " + "</a> </td>";

    //                    strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

    //                    strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
    //                    strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
    //                    strForImageDiv += "</div>";

    //                }
    //                else
    //                {
    //                    string strImagePath = "/Images/Icons/wlcm.png";// class=\"lightbox\"
    //                    strHtml += "<td   style=\"width:10%;height:40px; word-wrap:break-word;text-align: center;\" > <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img   id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' />" + "</a></td>";

    //                    strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

    //                    strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
    //                    strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
    //                    strForImageDiv += "</div>";
    //                }
    //            }
    //            if (intColumnBodyCount == 2)
    //            {
    //                strHtml += "<td  style=\"font-family: Calibri;color: #a9b496;font-size: 14px;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0%; width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }




    //        }
    //        //strHtml += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;padding-left: 0;\"><a href=\"\" onclick = \"return removeRow(" + dt.Rows[intRowBodyCount][0].ToString() + ");\"> select<a> </td>";




    //        //for check box
    //        strHtml += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0;\"  >" +
    //          "  <input type=\"checkbox\"  id=\"chbx_" + dt.Rows[intRowBodyCount][0].ToString() + "\"> " + " </td>";


    //        strHtml += "</tr>";
    //    }

    //    strHtml += "</tbody>";

    //    strHtml += "</table>";


    //    divForgoofy.InnerHtml = strForImageDiv;
    //    sb.Append(strHtml);
    //    return sb.ToString();
    //}

    //protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    //{
    //    clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();

    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    objEntityTeamHierarchy.TeamLeadEmp_Id = Convert.ToInt32(ddlTeamLead.SelectedValue);
    //    if (ddlDivision.SelectedValue == "--SELECT ALL DIVISIONS--")
    //    {
    //        objEntityTeamHierarchy.Divsnid = 0;
    

    //    }
    //    else
    //    {
    //        objEntityTeamHierarchy.Divsnid = Convert.ToInt32(ddlDivision.SelectedValue);
           
    //    }

    //    if (Request.QueryString["Id"] != null)
    //    {

    //        string strRandomMixedId = Request.QueryString["Id"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        string strId = strRandomMixedId.Substring(2, intLenghtofId);
    //        objEntityTeamHierarchy.TeamId = Convert.ToInt32(strId);
    //    }
    //        DataTable dtMembers = new DataTable();
    //        dtMembers = objBusinessLayerTeamHierarchy.ReadUsersForMember(objEntityTeamHierarchy);

    //        //string strHtm = ConvertDataTableToHTML(dtMembers);
    //        //Write to divReport
    //      //  divUsers.InnerHtml = strHtm;


        
    //}


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string[] GetTeamLlead(string prefix, string CorpId, string OrgId)
    {
        List<string> customers = new List<string>();

        clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
        clsBusinessLayerTeamHierarchy objBusinessLayerTeamHierarchy = new clsBusinessLayerTeamHierarchy();
        objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityTeamHierarchy.SearchText = prefix;

        DataTable dtTeamLeader = objBusinessLayerTeamHierarchy.ReadUsersForTeamLead(objEntityTeamHierarchy);
        foreach (DataRow r in dtTeamLeader.Rows)
        {
            customers.Add(string.Format("{0}—{1}", r[1], r[0]));
        }
        return customers.ToArray();
    }
}