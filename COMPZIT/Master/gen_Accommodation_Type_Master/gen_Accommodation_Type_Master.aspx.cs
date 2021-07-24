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
// CREATED DATE:13/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Accommodation_Master_gen_Accommodation_Type_Master : System.Web.UI.Page
{
    clsBusinessLayerAccommodationType objBusinessLayerAccommodationType = new clsBusinessLayerAccommodationType();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
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
                btnClearf.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.InnerText = "Edit Accommodation Type";

            }
             //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                btnClearf.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.InnerText = "View Accommodation Type";
            }
             else
            {
                lblEntry.InnerText = "Add Accommodation Type";
             
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
                btnUpdatef.Visible = false;
                btnUpdateClosef.Visible = false;
                btnAddf.Visible = true;
                btnAddClosef.Visible = true;
                btnClearf.Visible = true;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Accommodation_Type_Master);
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
                btnUpdatef.Visible = false;

            }
            

        

        
       }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityAccommodationType objEntityAccommodationType = new clsEntityAccommodationType();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccommodationType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccommodationType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }        
         

            if (cbxStatus.Checked == true)
            {
                objEntityAccommodationType.AccommodationType_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityAccommodationType.AccommodationType_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityAccommodationType.AccommodatonType_Master_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityAccommodationType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityAccommodationType.D_Date = System.DateTime.Now;

            objEntityAccommodationType.AccommodationType_Name = txtName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerAccommodationType.CheckAccommodationTypeName(objEntityAccommodationType);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLayerAccommodationType.Update_AccommodationType(objEntityAccommodationType);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Accommodation_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Accommodation_Type_Master_List.aspx?InsUpd=Upd");
                }
               else if (clickedButton.ID == "btnUpdatef")
                {
                    Response.Redirect("gen_Accommodation_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClosef")
                {
                    Response.Redirect("gen_Accommodation_Type_Master_List.aspx?InsUpd=Upd");
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
        clsEntityAccommodationType objEntityAccommodationType = new clsEntityAccommodationType();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccommodationType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccommodationType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

       
        if (cbxStatus.Checked == true)
        {
            objEntityAccommodationType.AccommodationType_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityAccommodationType.AccommodationType_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityAccommodationType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityAccommodationType.D_Date = System.DateTime.Now;

        objEntityAccommodationType.AccommodationType_Name = txtName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerAccommodationType.CheckAccommodationTypeName(objEntityAccommodationType);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerAccommodationType.Insert_AccommodationType(objEntityAccommodationType);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Accommodation_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Accommodation_Type_Master_List.aspx?InsUpd=Ins");
            }
           else if (clickedButton.ID == "btnAddf")
            {
                Response.Redirect("gen_Accommodation_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClosef")
            {
                Response.Redirect("gen_Accommodation_Type_Master_List.aspx?InsUpd=Ins");
            }
        }
        //If have
        else
        {


            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtName.Focus();

        }
       
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {

        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdatef.Visible = true;
        btnUpdateClosef.Visible = true;
        clsEntityAccommodationType objEntityAccommodationType = new clsEntityAccommodationType();
        objEntityAccommodationType.AccommodatonType_Master_Id = Convert.ToInt32(strP_Id);
        objEntityAccommodationType.CorpOffice_Id = intCorpId;
        DataTable dtAccommodationTypeById = objBusinessLayerAccommodationType.ReadAccommodationTypeById(objEntityAccommodationType);
        if (dtAccommodationTypeById.Rows.Count > 0)
        {

            txtName.Text = dtAccommodationTypeById.Rows[0]["ACCMDTNTYP_NAME"].ToString();
            int intAccmdtnTypeStatus = Convert.ToInt32(dtAccommodationTypeById.Rows[0]["ACCMDTNTYP_STATUS"]);
            if (intAccmdtnTypeStatus == 1)
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
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdatef.Visible = false;
        btnUpdateClosef.Visible = false;
        clsEntityAccommodationType objEntityAccommodationType = new clsEntityAccommodationType();
        objEntityAccommodationType.AccommodatonType_Master_Id = Convert.ToInt32(strP_Id);
        objEntityAccommodationType.CorpOffice_Id = intCorpId;
        DataTable dtAccommodationTypeById = objBusinessLayerAccommodationType.ReadAccommodationTypeById(objEntityAccommodationType);
        if (dtAccommodationTypeById.Rows.Count > 0)
        {

            txtName.Text = dtAccommodationTypeById.Rows[0]["ACCMDTNTYP_NAME"].ToString();

            int intAccmdtnTypeStatus = Convert.ToInt32(dtAccommodationTypeById.Rows[0]["ACCMDTNTYP_STATUS"]);
            if (intAccmdtnTypeStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;     
        cbxStatus.Enabled = false;

    }

}