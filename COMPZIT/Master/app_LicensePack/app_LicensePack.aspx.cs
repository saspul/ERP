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

// CREATED BY:EVM-0001
// CREATED DATE:19/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_app_LicensePack_app_LicensePackAdd : System.Web.UI.Page
{
   
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

     
        txtMaxUser.Attributes.Add("onkeydown", "return isNumber(event)");
        txtMaxUser.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        txtMaxUser.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLicePacName.Attributes.Add("onkeypress", "return isTag(event)");
        txtLicePacName.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        cbLicPacActive.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbLicPacActive.Attributes.Add("onchange", " IncrmntConfrmCounter()");


        //On not is post back
        if (!IsPostBack)
        {
            txtLicePacName.Focus();


            //when editing and viewing
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit License Pack";

            }


            else
            {
                lblEntry.Text = "Add License Pack";
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

    //assigning new data to the entity layer for updation.
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerLicensePack objBusinessLayerLicPac = new clsBusinessLayerLicensePack();
        if (Request.QueryString["Id"] != null)
        {
            EL_Compzit.clsEntityLicensePack objEntLicPac = null;
            objEntLicPac = new EL_Compzit.clsEntityLicensePack();
            objEntLicPac.LicPacName = txtLicePacName.Text.ToUpper().Trim();
            objEntLicPac.LicPacEnds = Convert.ToInt32(txtMaxUser.Text);
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntLicPac.LicPackId = Convert.ToInt32(strId);
            if (cbLicPacActive.Checked)
            {
                objEntLicPac.LicPacStatus = 1;
            }
            else
            {
                objEntLicPac.LicPacStatus = 0;
            }


            string strNameCount = objBusinessLayerLicPac.CheckDupLicensePackName(objEntLicPac);
            if (strNameCount == "0")
            {
              
                    string strMaxUserCount = objBusinessLayerLicPac.CheckDupLicensePackMaxUserCount(objEntLicPac);
                    if (strMaxUserCount == "0")
                    {
                        //passing new data from users to business layer for update table
                        objBusinessLayerLicPac.UpdateLicPac(objEntLicPac);

                        if (clickedButton.ID == "btnUpdate")
                        {
                            Response.Redirect("app_LicensePack.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose")
                        {
                            Response.Redirect("app_LicensePackList.aspx?InsUpd=Upd");
                        }
                        

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMaxUser", "DuplicationMaxUser();", true);
                        txtMaxUser.Focus();
                    }
                
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtLicePacName.Focus();
            }





         
        }
    }
   
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strPckId)
    {
        clsBusinessLayerLicensePack objBusinessLayerLicPac = new clsBusinessLayerLicensePack();
        if (strPckId != "")
        {
            EL_Compzit.clsEntityLicensePack objEntLicPac = null;
            objEntLicPac = new EL_Compzit.clsEntityLicensePack();
            objEntLicPac.LicPackId = Convert.ToInt32(strPckId);
            DataTable dtLicPac = new DataTable();
            dtLicPac = objBusinessLayerLicPac.ReadLicPacEdit(objEntLicPac);
            txtLicePacName.Text = dtLicPac.Rows[0]["LIC_PACK_NAME"].ToString();        
            txtMaxUser.Text = dtLicPac.Rows[0]["LIC_PACK_ENDS"].ToString();
            string strLicpacAct = dtLicPac.Rows[0]["LIC_PACK_STATUS"].ToString();
            if (strLicpacAct == "1")
            {
                cbLicPacActive.Checked = true;
            }
            else
            {
                cbLicPacActive.Checked = false;
            }
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
        }
    }
    //On SaveSubmit Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerLicensePack objBusinessLayerLicPac = new clsBusinessLayerLicensePack();
        //accuring data from users and assign them on entity layer objects then passing to the business layer.
        EL_Compzit.clsEntityLicensePack objEntLicPac = null;
        objEntLicPac = new EL_Compzit.clsEntityLicensePack();
    
        objEntLicPac.LicPacName = txtLicePacName.Text.ToUpper().Trim();
        objEntLicPac.LicPacEnds = Convert.ToInt32(txtMaxUser.Text);
        if (cbLicPacActive.Checked)
        {
            objEntLicPac.LicPacStatus = 1;
        }
        else
        {
            objEntLicPac.LicPacStatus = 0;
        }
        string strNameCount = objBusinessLayerLicPac.CheckDupLicensePackName(objEntLicPac);
        if (strNameCount == "0")
        {
         
                string strMaxUserCount = objBusinessLayerLicPac.CheckDupLicensePackMaxUserCount(objEntLicPac);
                if (strMaxUserCount == "0")
                {
                    objBusinessLayerLicPac.AddLicensePack(objEntLicPac);
                    if (clickedButton.ID == "btnAdd")
                    {
                        Response.Redirect("app_LicensePack.aspx?InsUpd=Ins");
                    }
                    else if (clickedButton.ID == "btnAddClose")
                    {
                        Response.Redirect("app_LicensePackList.aspx?InsUpd=Ins");
                    }
                 
               
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMaxUser", "DuplicationMaxUser();", true);
                    txtMaxUser.Focus();
                }
            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtLicePacName.Focus();
        }
    }


   
  
}
