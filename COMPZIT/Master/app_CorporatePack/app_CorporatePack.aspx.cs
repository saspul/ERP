using System;
using System.Web;
using BL_Compzit;
using System.Data;
using System.Text;
using EL_Compzit;
using System.Web.UI.WebControls;
using System.Web.UI;

// CREATED BY:EVM-0001
// CREATED DATE:16/02/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the UI Layer for Adding Corporate Pack and also updating and viewing the same .

public partial class Master_app_CorporatePack_app_CorporatePackAdd : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {

        txtCorpPackCount.Attributes.Add("onkeydown", "return isNumber(event)");
        txtCorpPackCount.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        txtCorpPackCount.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtCorpPackName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCorpPackName.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        //On not is post back
        if (!IsPostBack)
        { 
             txtCorpPackName.Focus();
            //when editing and viewing
            if (Request.QueryString["Id"] != null )
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
             
                Update(strId);
                lblEntry.Text = "Edit Corporate Pack";
              
            }

          
            else  
            {
                lblEntry.Text = "Add Corporate Pack";
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
    //When Save Button while editing  is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        
        //Created objects for business layer
        clsBusinessLayerCorporatePack objBusinessLayerCrpPac = new clsBusinessLayerCorporatePack();
        if (Request.QueryString["Id"] != null)
        {
            EL_Compzit.clsEntityCorporatePack objCrpPack = null;
            objCrpPack = new EL_Compzit.clsEntityCorporatePack();
            //assign values to entity layer objects and pass them to businesslayer.              
            objCrpPack.CrpStatus = 1;
            if (cbxStatus.Checked == false)
            {
                objCrpPack.CrpStatus = 0;
            }
        
            objCrpPack.CrpPackName = txtCorpPackName.Text.ToUpper().Trim();
            objCrpPack.CrprtPackCnt = Convert.ToInt32(txtCorpPackCount.Text);
         
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objCrpPack.CrprtPackId = Convert.ToInt32(strId);


             string strNameCount = objBusinessLayerCrpPac.CheckDupCorporatePackName(objCrpPack);
        if (strNameCount == "0")
        {
            string strOffcCount = objBusinessLayerCrpPac.CheckDupCorporatePackCount(objCrpPack);
            if (strOffcCount == "0")
            {

            objBusinessLayerCrpPac.UpdateCorporatePack(objCrpPack);

            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("app_CorporatePack.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("app_CorporatePackList.aspx?InsUpd=Upd");
            }
           
         
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCount", "DuplicationCount();", true);
                txtCorpPackCount.Focus();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtCorpPackName.Focus();
        }
        }
    }
    

    private void Update(string strPckId)
    {
        if (strPckId != "")
        {  //Created objects for business layer
            clsBusinessLayerCorporatePack objBusinessLayerCrpPac = new clsBusinessLayerCorporatePack();
            EL_Compzit.clsEntityCorporatePack objEntCrpPack = null;
            objEntCrpPack = new EL_Compzit.clsEntityCorporatePack();
            objEntCrpPack.CrprtPackId = Convert.ToInt32(strPckId);
            DataTable dtEditPack = new DataTable();
            //Fetching the table from businesslayer and assing the values in each field in our interferance.
            dtEditPack = objBusinessLayerCrpPac.EditPack(objEntCrpPack);
            txtCorpPackName.Text = dtEditPack.Rows[0]["CORP_PACK_NAME"].ToString();
            txtCorpPackCount.Text = dtEditPack.Rows[0]["CORP_PACK_COUNT"].ToString();
            if (dtEditPack.Rows[0]["CORP_PACK_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
        }
    }
    //On SaveSubmit Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {  //Created objects for business layer

        Button clickedButton = sender as Button;
      
        clsBusinessLayerCorporatePack objBusinessLayerCrpPac = new clsBusinessLayerCorporatePack();
        EL_Compzit.clsEntityCorporatePack objEntCrpPack = null;
        objEntCrpPack = new EL_Compzit.clsEntityCorporatePack();
        txtCorpPackName.Text = txtCorpPackName.Text.ToUpper();

        objEntCrpPack.CrpPackName = txtCorpPackName.Text.ToUpper().Trim();
        objEntCrpPack.CrprtPackCnt = Convert.ToInt32(txtCorpPackCount.Text);
        //When CheckBox For Active is unChecked
        if (cbxStatus.Checked == false)
        {
            objEntCrpPack.CrpStatus = 0;
        }
        else
        {
            objEntCrpPack.CrpStatus = 1;
        }
        string strNameCount = objBusinessLayerCrpPac.CheckDupCorporatePackName(objEntCrpPack);
        if (strNameCount == "0")
        {
            string strOffcCount = objBusinessLayerCrpPac.CheckDupCorporatePackCount(objEntCrpPack);
            if (strOffcCount == "0")
            {
                objBusinessLayerCrpPac.AddCorporatePack(objEntCrpPack);
                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("app_CorporatePack.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("app_CorporatePackList.aspx?InsUpd=Ins");
                }
               
               
                
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCount", "DuplicationCount();", true);
                txtCorpPackCount.Focus();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtCorpPackName.Focus();
        }
    }

  
   
 
}