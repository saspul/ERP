
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
// CREATED BY:EVM-0008
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class AWMS_AWMS_Master_gen_Holiday_Master_gen_Holiday_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtHolidayTitle.Attributes.Add("onkeypress", "return isTag(event)");
        txtHolidayTitle.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlHolMode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlHolType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDate.Focus();
      //  cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";
        if (!IsPostBack)
        {

         
           
            imgbtnReOpen.Visible = false;
        
            HolTypeLoad();
            hiddenRoleReOpen.Value = "0";
            hiddenRoleConfirm.Value = "0";
            hiddenRoleAdd.Value = "0";
            hiddenstrid.Value = "0";
            btnConfirm.Visible = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUserId = 0, intUsrRolMstrId, intEnableReOpen, intEnableConfirm, intEnableAdd;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Holiday_Master);

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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = intEnableReOpen.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

            }


            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                            Update(strId);
                lblEntry.Text = "Edit Holiday Details";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                             View(strId);

                             lblEntry.Text = "View Holiday Details";
            }

            else
            {
                lblEntry.Text = "Add Holiday Details";

                             btnUpdate.Visible = false;
                           btnUpdateClose.Visible = false;
                           if (hiddenRoleAdd.Value != "")
                           {
                               if (hiddenRoleAdd.Value == "1")
                               {
                                   btnAdd.Visible = true;
                                   btnAddClose.Visible = true;
                               }
                               else
                               {
                                   btnCancel.Visible = true;
                                   btnAdd.Visible = false;
                                   btnAddClose.Visible = false;
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
                    else if (strInsUpd == "Cnfrm")
                    {
                      
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                    }
                    else if (strInsUpd == "ReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                    }
                }
            }

            // created object for business layer for compare the date

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;





        }
    }
  

    protected void HolTypeLoad()
    {
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        int intUserId;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["USERID"] != null)
        {
            objEntHol.User_Id = Convert.ToInt32(Session["USERID"].ToString());

            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable HolTypDetails = new DataTable();
        HolTypDetails = objbusHol.ReadHolType(objEntHol);
        if (HolTypDetails.Rows.Count > 0)
        {
            ddlHolType.DataSource = HolTypDetails;
            ddlHolType.DataValueField = "HLDAYTYP_ID";
            ddlHolType.DataTextField = "HLDAYTYP_NAME";
            ddlHolType.DataBind();

        }
        ddlHolType.Items.Insert(0, "--SELECT HOLIDAY TYPE--");

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntHol.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        //if (cbxStatus.Checked == true)
        //{
        //    objEntHol.Status_id = 1;
        //}
        //Status checkbox not checked
        //else
        //{
        //    objEntHol.Status_id = 0;
        //}


        objEntHol.HolidayTitle = txtHolidayTitle.Text.Trim().ToUpper();
        objEntHol.HolidayDate = objCommon.textToDateTime(txtDate.Text.Trim());
        if (ddlHolMode.SelectedItem.Value != "--SELECT HOLIDAY MODE--")
        {
            objEntHol.HolModeId = Convert.ToInt32(ddlHolMode.SelectedItem.Value);
        }
        if (ddlHolType.SelectedItem.Value != "--SELECT HOLIDAY TYPE--")
        {
            objEntHol.HOlTypeId = Convert.ToInt32(ddlHolType.SelectedItem.Value);
        }
       

        string strNameCount="0";
        string strprocesscount="0";
        string strDateCount = "0";
        //Holiday Date Duplication Checking\\\

        strprocesscount = objbusHol.Checksalaryprocess(objEntHol);

        //Checking is were the salary was processed
        strDateCount = objbusHol.CheckHolDate(objEntHol);


        //Checking is there table have any name like this
     strNameCount = objbusHol.CheckHolTitle(objEntHol);
        //If there is no name like this on table.    
     if (strNameCount == "0" && strprocesscount == "0" && strDateCount=="0")
        {
            objbusHol.AddHolidayDetails(objEntHol);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Holiday_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            if (strprocesscount != "" && strNameCount == "")
            {
                txtDate.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

            }
            if (strDateCount != "0")
            {
                txtHolidayTitle.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDate", "DuplicationDate();", true);

            }
            if (strNameCount != "0")
            {
                txtHolidayTitle.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }
            //else
            //{
            //    txtDate.Focus();
            //    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);
            //}

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();

        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntHol.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            //if (cbxStatus.Checked == true)
            //{
            //    objEntHol.Status_id = 1;
            //}
            //Status checkbox not checked
            //else
            //{
            //    objEntHol.Status_id = 0;
            //}
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strHolId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntHol.Holdy_Id = Convert.ToInt32(strHolId);
            objEntHol.HolidayTitle = txtHolidayTitle.Text.Trim().ToUpper();
            objEntHol.HolidayDate = objCommon.textToDateTime(txtDate.Text.Trim());
            if (ddlHolMode.SelectedItem.Value != "--SELECT HOLIDAY MODE--")
            {
                objEntHol.HolModeId = Convert.ToInt32(ddlHolMode.SelectedItem.Value);
            }
            if (ddlHolType.SelectedItem.Value != "--SELECT HOLIDAY TYPE--")
            {
                objEntHol.HOlTypeId = Convert.ToInt32(ddlHolType.SelectedItem.Value);
            }
            //Checking is were the salary was processed
            string strprocesscount = objbusHol.Checksalaryprocess(objEntHol);
            string strDateCount = "0";
            strDateCount = objbusHol.CheckHolDate(objEntHol);
            //Checking is there table have any name like this
            string strNameCount = objbusHol.CheckHolTitle(objEntHol);
            //If there is no name like this on table.    
            if (strNameCount == "0" && strprocesscount == "0")
            {
                objbusHol.UpdateHoldetails(objEntHol);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Holiday_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Upd");
                }

            }


                //If have
            else
            {
                if (strprocesscount != "" && strNameCount == "" && strDateCount == "0")
                {
                    txtDate.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

                }
                //else
                //{
                //    txtDate.Focus();
                //    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);
                //}
                if (strNameCount != "0")
                {
                    txtHolidayTitle.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
               
                if (strDateCount != "0")
                {
                    txtHolidayTitle.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDate", "DuplicationDate();", true);

                }
               
            }
        }
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntHol.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntHol.Holdy_Id = Convert.ToInt32(strWaterRechId);
            objEntHol.HolidayTitle = txtHolidayTitle.Text.Trim().ToUpper();
            objEntHol.HolidayDate = objCommon.textToDateTime(txtDate.Text.Trim());
            if (ddlHolMode.SelectedItem.Value != "--SELECT HOLIDAY MODE--")
            {
                objEntHol.HolModeId = Convert.ToInt32(ddlHolMode.SelectedItem.Value);
            }
            if (ddlHolType.SelectedItem.Value != "--SELECT HOLIDAY TYPE--")
            {
                objEntHol.HOlTypeId = Convert.ToInt32(ddlHolType.SelectedItem.Value);
            }

            if (hiddenRoleAdd.Value != "1")
            {
               
            }
            string strprocesscount = objbusHol.Checksalaryprocess(objEntHol);
            string strNameCount = objbusHol.CheckHolTitle(objEntHol);

            //if (strNameCount == "" || strNameCount == "0")
            //{
            //    objbusHol.UpdateHoldetails(objEntHol);
            //    objEntHol.HOlConfmn = 1;

            //    objbusHol.ConfirmHoliday(objEntHol);

            //    Response.Redirect("gen_Holiday_Master.aspx?InsUpd=Cnfrm");

            //}
            //else
            //{
            //    txtHolidayTitle.Focus();
            //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            //}

            if (strNameCount == "0" && strprocesscount == "0")
            {
                objbusHol.UpdateHoldetails(objEntHol);
                objEntHol.HOlConfmn = 1;

                  objbusHol.ConfirmHoliday(objEntHol);

                  Response.Redirect("gen_Holiday_Master.aspx?InsUpd=Cnfrm");

            }


              //If have
            else
            {
                if (strprocesscount != "" && strNameCount == "")
                {
                    txtDate.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

                }
                if (strNameCount != "0")
                {
                    txtHolidayTitle.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
                else
                {
                    txtDate.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);
                }

            }
            //objEntHol.HOlConfmn = 1;

            //objbusHol.ConfirmHoliday(objEntHol);

            //Response.Redirect("gen_Holiday_Master.aspx?InsUpd=Cnfrm");
        }
        
    }

    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntHol.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strHolId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntHol.Holdy_Id = Convert.ToInt32(strHolId);
            objEntHol.HOlConfmn = 0;



            objbusHol.ReOpenHoliday(objEntHol);

            Response.Redirect("gen_Holiday_Master.aspx?InsUpd=ReOpen");
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Holiday_Master.aspx");
    }

    //Fetching the table from business layer and assign them in  fields.
    public void Update(string strWId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        objEntHol.Holdy_Id = Convert.ToInt32(strWId);
        DataTable dtHolidayDetail = new DataTable();
        dtHolidayDetail = objbusHol.ReadHolidaydetailsById(objEntHol);
            //After fetch holiday details in datatable,we need to differentiate.
        if (dtHolidayDetail.Rows.Count > 0)
        {
            hiddenstrid.Value = strWId;
         
            txtHolidayTitle.Text = dtHolidayDetail.Rows[0]["HLDAYMSTR_TITLE"].ToString();

            txtDate.Text = dtHolidayDetail.Rows[0]["HLDAYMSTR_DATE"].ToString();
            ddlHolMode.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYMSTR_MODE"].ToString()).Selected = true;

            DateTime todate = System.DateTime.Now;

            string EmDate = new DateTime(todate.Year, todate.Month, todate.Day).ToString("dd-MM-yyyy");
         

            todate = objCommon.textToDateTime(EmDate);

           // todate = objCommon.textToDateTime(todate.Day+"-"+todate.Month+"-"+todate.Year);
            DateTime holidayDate = objCommon.textToDateTime(txtDate.Text.Trim());


            if (dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString() != "" && dtHolidayDetail.Rows[0]["HLDAYTYP_STATUS"].ToString() == "1")
            {
                ddlHolType.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtHolidayDetail.Rows[0]["HLDAYTYP_NAME"].ToString(), dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString());
                ddlHolType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlHolType);

                ddlHolType.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }

            //if (dtHolidayDetail.Rows[0]["HLDAYMSTR_STATUS"].ToString() == "1")
            //{

            //    cbxStatus.Checked = true;
            //}
            //else
            //{

            //    cbxStatus.Checked = false;
            //}




            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {

                    if (dtHolidayDetail.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString() == "1")
                    {
                        txtDate.Enabled = false;
                        txtHolidayTitle.Enabled = false;
                        ddlHolMode.Enabled = false;
                        ddlHolType.Enabled = false;
                        //  cbxStatus.Enabled = false;
                        if (holidayDate >= todate)
                        {
                            imgbtnReOpen.Visible = true;
                        }

                    }
                    else
                    {
                        imgbtnReOpen.Visible = false;
                    }
                }
                else
                {
                    if (dtHolidayDetail.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString() == "1")
                    {
                        imgbtnReOpen.Visible = false;
                        txtDate.Enabled = false;
                        txtHolidayTitle.Enabled = false;
                        ddlHolMode.Enabled = false;
                        ddlHolType.Enabled = false;
                    }
                }

            }
        
          


        }


        if (hiddenRoleConfirm.Value == "1")
        {

            if (dtHolidayDetail.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString() == "1")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
               // imgbtnReOpen.Visible = true;
            }
            else
            {
              //  imgbtnReOpen.Visible = false;
                btnConfirm.Visible = true;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
        }
        else
        {
            if (dtHolidayDetail.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString() == "0")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }
            else
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
        }


        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Holiday_Master);
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
            if (dtHolidayDetail.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString() == "1")
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
            }

        }
        else
        {

            btnUpdate.Visible = false;

        }

 
       
        DateTime dateCurnt;
        DateTime dateFrm, dateTo, dateHolConfm, dateLeavConfm;
        DataTable LeavAllocChk;
        int intFlag = 0, intAllcnChck = 0;


        foreach (DataRow row in dtHolidayDetail.Rows)
        {
            if (row["HLDAYMSTR_STATUS"].ToString() == "1")
            {

                objEntHol.HolidayDate = objCommon.textToDateTime(row["HLDAYMSTR_DATE"].ToString());
                dateCurnt = objEntHol.HolidayDate;

                if (row["HLDAYMSTR_CNFRM_DATE"] != DBNull.Value && row["HLDAYMSTR_CNFRM_DATE"].ToString() != null && row["HLDAYMSTR_CNFRM_DATE"].ToString() != "")
                {
                    dateHolConfm = objCommon.textToDateTime(row["HLDAYMSTR_CNFRM_DATE"].ToString());


                    LeavAllocChk = objbusHol.LeavAlloctnConfrmCk(objEntHol);
                    if (LeavAllocChk.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in LeavAllocChk.Rows)
                        {
                            if (row1["LEAVE_CNFRM_DATE"] != DBNull.Value && row1["LEAVE_CNFRM_DATE"].ToString() != null && row1["LEAVE_CNFRM_DATE"].ToString() != "")
                            {
                                dateLeavConfm = objCommon.textToDateTime(row1["LEAVE_CNFRM_DATE"].ToString());

                                if (dateHolConfm <= dateLeavConfm)
                                {

                                    if (row1["LEAVE_FROM_DATE"].ToString() == objEntHol.HolidayDate.ToString())
                                    {
                                        intFlag++;
                                        if (intFlag != 0)
                                        {
                                            break;
                                        }
                                    }
                                    if (row1["LEAVE_TO_DATE"] != DBNull.Value && row1["LEAVE_TO_DATE"].ToString() != null && row1["LEAVE_TO_DATE"].ToString() != "")
                                    {
                                        dateFrm = objCommon.textToDateTime(row1["LEAVE_FROM_DATE"].ToString());
                                        dateTo = objCommon.textToDateTime(row1["LEAVE_TO_DATE"].ToString());

                                        if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                                        {
                                            intFlag++;
                                            if (intFlag != 0)
                                            {
                                                break;
                                            }
                                        }

                                    }
                                }
                            }



                        }


                    }
                    else
                    {

                        //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
                    }
                }
            }
        }
        if (intFlag != 0)
        {
            intAllcnChck = 1;
        }


        //if (intAllcnChck == 0)
        //{

        //   // imgbtnReOpen.Visible = true;
        //}
        //else
        //{
        //    imgbtnReOpen.Visible = false;
        //}


        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

    }

    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


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


    public void View(string strWId)
    {

    clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();

        objEntHol.Holdy_Id = Convert.ToInt32(strWId);
      
        DataTable dtHolidayDetail = new DataTable();
        dtHolidayDetail = objbusHol.ReadHolidaydetailsById(objEntHol);
     

        if (dtHolidayDetail.Rows.Count > 0)
        {
          
            txtHolidayTitle.Text = dtHolidayDetail.Rows[0]["HLDAYMSTR_TITLE"].ToString();

            txtDate.Text = dtHolidayDetail.Rows[0]["HLDAYMSTR_DATE"].ToString();
            ddlHolMode.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYMSTR_MODE"].ToString()).Selected = true;
            


            if (dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString() != "" && dtHolidayDetail.Rows[0]["HLDAYTYP_STATUS"].ToString() == "1")
            {
                ddlHolType.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtHolidayDetail.Rows[0]["HLDAYTYP_NAME"].ToString(), dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString());
                ddlHolType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlHolType);

                ddlHolType.Items.FindByValue(dtHolidayDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }

            //if (dtHolidayDetail.Rows[0]["HLDAYMSTR_STATUS"].ToString() == "1")
            //{

            //    cbxStatus.Checked = true;
            //}
            //else
            //{

            //    cbxStatus.Checked = false;
            //}

        
            
        }

        txtDate.Enabled = false;
        txtHolidayTitle.Enabled = false;
        ddlHolMode.Enabled = false;
        ddlHolType.Enabled = false;
       // cbxStatus.Enabled = false;

        imgbtnReOpen.Visible = false;
        btnClear.Visible = false;
        btnConfirm.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
    }
}