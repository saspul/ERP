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
// CREATED BY:EVM-0009
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class Master_gen_Timeslot_Master_gen_Timeslot_Master : System.Web.UI.Page
{
    //Creating objects for businesslayer
   
    clsBusinessLayerTimeslot objBusinessLayerTimeslot = new clsBusinessLayerTimeslot();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");    
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStartTime1.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlStartTime1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlEndTime1.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEndTime1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStartTime2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlStartTime2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlEndTime2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEndTime2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStartTime3.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlStartTime3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlEndTime3.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEndTime3.Attributes.Add("onchange", "IncrmntConfrmCounter()");    
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
           ddlAddTimeHr();
           ddlAddTimeMn();
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


          
           
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.InnerText = "Edit Time Slot";
                lblEntryB.InnerText = "Edit Time Slot";
            }
             //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.InnerText = "View Time Slot";
                lblEntryB.InnerText = "View Time Slot";
            }
             else
            {
                lblEntry.InnerText = "Add Time Slot";
                lblEntryB.InnerText = "Add Time Slot";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;

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
             //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Timeslot_Master);
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
                btnUpdateF.Visible = false;
            }
            

        

        }
}  
    //For adding to dropdown hour
    public void ddlAddTimeHr()
    {
        ddlStartTime1.Items.Clear();
        ddlEndTime1.Items.Clear();
        for (int i = 1; i < 13; i++)
        {
            if (i < 10)
            {
                string strNum = "0" + i;
                ddlStartTime1.Items.Add(strNum);
                ddlEndTime1.Items.Add(strNum);
            }
            else
            {
                ddlStartTime1.Items.Add(i.ToString());
                ddlEndTime1.Items.Add(i.ToString());
            }
        }
    }
    //For adding to dropdown minute
          public void ddlAddTimeMn()
      {
          ddlStartTime2.Items.Clear();
          ddlEndTime2.Items.Clear();
          for (int i = 0; i < 60; i=i+15)
          {
              if (i < 10)
              {
                  string strNum = "0" + i;
                  ddlStartTime2.Items.Add(strNum);
                  ddlEndTime2.Items.Add(strNum);
              }
              else
              {
                  ddlStartTime2.Items.Add(i.ToString());
                  ddlEndTime2.Items.Add(i.ToString());
              }
          }
         
      
                
      }
      

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityTimeslot objEntityTimeslot = new clsEntityTimeslot();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeslot.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeslot.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        string strDatetime = Convert.ToString("01-01-1000-" + ddlStartTime1.SelectedItem.Text + "-" + ddlStartTime2.SelectedItem.Text + "-" + ddlStartTime3.SelectedItem.Text);
        objEntityTimeslot.Start_Time = objBusinessLayerTimeslot.textWithTimeToDateTime(strDatetime);
        strDatetime = Convert.ToString("01-01-1000-" + ddlEndTime1.SelectedItem.Text + "-" + ddlEndTime2.SelectedItem.Text + "-" + ddlEndTime3.SelectedItem.Text);
        objEntityTimeslot.End_Time = objBusinessLayerTimeslot.textWithTimeToDateTime(strDatetime);
        //int result = DateTime.Compare(objEntityTimeslot.Start_Time, objEntityTimeslot.End_Time);
       
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityTimeslot.Timeslot_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityTimeslot.Timeslot_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeslot.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityTimeslot.D_Date = System.DateTime.Now;

        objEntityTimeslot.Timeslot_Name = txtName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerTimeslot.CheckTimeslotName(objEntityTimeslot);
        //If there is no name like this on table.    
        if (strNameCount == "0" )
        {
            objBusinessLayerTimeslot.Insert_Timeslot(objEntityTimeslot);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Timeslot_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Timeslot_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {

          
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtName.Focus();
           
        }
       
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityTimeslot objEntityTimeslot = new clsEntityTimeslot();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTimeslot.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTimeslot.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //convert start time and end time to datetime format
            string strDatetime = Convert.ToString("01-01-1000-" + ddlStartTime1.SelectedItem.Text + "-" + ddlStartTime2.SelectedItem.Text + "-" + ddlStartTime3.SelectedItem.Text);
            objEntityTimeslot.Start_Time = objBusinessLayerTimeslot.textWithTimeToDateTime(strDatetime);
            strDatetime = Convert.ToString("01-01-1000-" + ddlEndTime1.SelectedItem.Text + "-" + ddlEndTime2.SelectedItem.Text + "-" + ddlEndTime3.SelectedItem.Text);
            objEntityTimeslot.End_Time = objBusinessLayerTimeslot.textWithTimeToDateTime(strDatetime);

            //int result = DateTime.Compare(objEntityTimeslot.Start_Time,objEntityTimeslot.End_Time);
           
            if (cbxStatus.Checked == true)
            {
                objEntityTimeslot.Timeslot_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityTimeslot.Timeslot_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityTimeslot.Timeslot_Master_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityTimeslot.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityTimeslot.D_Date = System.DateTime.Now;

            objEntityTimeslot.Timeslot_Name = txtName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerTimeslot.CheckTimeslotName(objEntityTimeslot);
            //If there is no name like this on table.    
            if (strNameCount == "0" )
            {

                DataTable dtComplaintDetail = objBusinessLayerTimeslot.ReadTimeslotById(objEntityTimeslot);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["TMSLT_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["TMSLT_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerTimeslot.Update_Timeslot(objEntityTimeslot);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_Timeslot_Master.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_Timeslot_Master_List.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Timeslot_Master_List.aspx?InsUpd=AlCncl");
                    }
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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
      
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityTimeslot objEntityTimeslot = new clsEntityTimeslot();
        objEntityTimeslot.Timeslot_Master_Id = Convert.ToInt32(strP_Id);
        objEntityTimeslot.CorpOffice_Id = intCorpId;
        DataTable dtTimeslotById = objBusinessLayerTimeslot.ReadTimeslotById(objEntityTimeslot);
        if (dtTimeslotById.Rows.Count > 0)
        {
            
            txtName.Text = dtTimeslotById.Rows[0]["TMSLT_NAME"].ToString();

            //To fetch start time from table and display to dropdowns
            int inthr = Convert.ToInt32((dtTimeslotById.Rows[0][2].ToString()).Substring(0, 2));
            string strAM_PM = (dtTimeslotById.Rows[0][2].ToString()).Substring(6, 2);
            if (strAM_PM == "PM" && inthr > 12)
            {

                inthr = inthr - 12;
    
            }
            if (strAM_PM == "AM" && inthr == 0)
            {

                inthr = 12;
            }
            if (inthr < 10)
            {
                string strhr = "0" + inthr;
               
                ddlStartTime1.Items.FindByText(strhr).Selected = true;
            }
            else
            {
              
                ddlStartTime1.Items.FindByText(Convert.ToString(inthr)).Selected = true;
            }
          
            string strMn = (dtTimeslotById.Rows[0][2].ToString()).Substring(3, 2);
          
            ddlStartTime2.Items.FindByText(strMn).Selected = true;
     
            ddlStartTime3.Items.FindByText(strAM_PM).Selected = true;

            //To fetch end time from table and display to dropdowns

            inthr = Convert.ToInt32((dtTimeslotById.Rows[0][3].ToString()).Substring(0, 2));
            strAM_PM = (dtTimeslotById.Rows[0][3].ToString()).Substring(6, 2);
            if (strAM_PM == "PM" && inthr > 12)
            {

                inthr = inthr - 12;
            }
            if (strAM_PM == "AM" && inthr == 0)
            {

                inthr = 12;
            }
            if (inthr < 10)
            {
                string strhr = "0" + inthr;
                
                ddlEndTime1.Items.FindByText(strhr).Selected = true;
            }
            else
            {
             
                ddlEndTime1.Items.FindByText(Convert.ToString(inthr)).Selected = true;
            }
            strMn = (dtTimeslotById.Rows[0][3].ToString()).Substring(3, 2);
          
            ddlEndTime2.Items.FindByText(strMn).Selected = true;
           
            ddlEndTime3.Items.FindByText(strAM_PM).Selected = true;
           
           

            int intTimeslotStatus = Convert.ToInt32(dtTimeslotById.Rows[0]["TMSLT_STATUS"]);
            if (intTimeslotStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }
         //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityTimeslot objEntityTimeslot = new clsEntityTimeslot();
        objEntityTimeslot.Timeslot_Master_Id = Convert.ToInt32(strP_Id);
        objEntityTimeslot.CorpOffice_Id = intCorpId;
        DataTable dtTimeslotById = objBusinessLayerTimeslot.ReadTimeslotById(objEntityTimeslot);
        if (dtTimeslotById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtName.Text = dtTimeslotById.Rows[0]["TMSLT_NAME"].ToString();
            ddlStartTime1.Items.Clear();
            ddlStartTime2.Items.Clear();
            ddlEndTime3.Items.Clear();
            ddlEndTime1.Items.Clear();
            ddlEndTime2.Items.Clear();
            ddlStartTime3.Items.Clear();
            string strHr = (dtTimeslotById.Rows[0][2].ToString()).Substring(0, 2);
            string strMn = (dtTimeslotById.Rows[0][2].ToString()).Substring(3, 2);
            string strAM_PM = (dtTimeslotById.Rows[0][2].ToString()).Substring(6, 2);
            ListItem lst = new ListItem(strHr);
            ddlStartTime1.Items.Insert(0, lst);
            lst = new ListItem(strMn);
            ddlStartTime2.Items.Insert(0, lst);
            lst = new ListItem(strAM_PM);
            ddlStartTime3.Items.Insert(0, lst);

            strHr = (dtTimeslotById.Rows[0][3].ToString()).Substring(0, 2);
            strMn = (dtTimeslotById.Rows[0][3].ToString()).Substring(3, 2);
            strAM_PM = (dtTimeslotById.Rows[0][3].ToString()).Substring(6, 2);
            lst = new ListItem(strHr);
            ddlEndTime1.Items.Insert(0, lst);
            lst = new ListItem(strMn);
            ddlEndTime2.Items.Insert(0, lst);
            lst = new ListItem(strAM_PM);
            ddlEndTime3.Items.Insert(0, lst);
           
            int intTimeslotStatus = Convert.ToInt32(dtTimeslotById.Rows[0]["TMSLT_STATUS"]);
            if (intTimeslotStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;
        ddlStartTime1.Enabled = false;
        ddlStartTime2.Enabled = false;
        ddlStartTime3.Enabled = false;
        ddlEndTime1.Enabled = false;
        ddlEndTime2.Enabled = false;
        ddlEndTime3.Enabled = false;
       
        cbxStatus.Disabled = true;

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