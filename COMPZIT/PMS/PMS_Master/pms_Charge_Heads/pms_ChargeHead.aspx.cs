using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using System.Data;
public partial class PMS_PMS_Master_pms_Charge_Heads_pms_ChargeHead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Pms.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            txtChargeHead.Focus();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
            clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                objEntityChargeHead.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }

            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            LoadChargeHeadCategory();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PMS_Charge_Head);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                LoadChargeHeadDetails(strId, 1);
                lblEntry.Text = "Edit Charge Head";
                btnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                ButtnClear.Visible = false;

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                LoadChargeHeadDetails(strId, 0);
                lblEntry.Text = "View Charge Head";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnsaveAndClose.Visible = false;
                btnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                ButtnClear.Visible = false;

            }
            else
            {
                lblEntry.Text = "Add Charge Head";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnsaveAndClose.Visible = false;
                btnsave.Visible = true;
                btnsaveAndClose.Visible = true;
            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsert", "SuccessInsert();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            else if (strInsUpd == "Dup")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int flag = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityChargeHead.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityChargeHead.ChargeHead = txtChargeHead.Text.Trim();
        objEntityChargeHead.ChargeHeadCode= txtChargeHeadCode.Text.Trim();
        objEntityChargeHead.CHCategoryId =Convert.ToInt32( ddlCategory.SelectedItem.Value);
        objEntityChargeHead.CHCalculate = Convert.ToInt32(ddlCalcultnMethod.SelectedItem.Value);

        if (ChkStatus.Checked == true)
        {
            objEntityChargeHead.Status = 1;
        }
        else
        {
            objEntityChargeHead.Status = 0;
        }

        List<clsEntityChargeHeads> objEntityListCHCategory = new List<clsEntityChargeHeads>();
        string AllCategory = hiddenCHCategory.Value;
        string[] EachCatId = AllCategory.Split(',');
        foreach (string CatId in EachCatId)
        {
            if (CatId != "")
            {
                clsEntityChargeHeads objEntityListCHCat = new clsEntityChargeHeads();
                objEntityListCHCat.CHCategoryId = Convert.ToInt32(CatId);
                objEntityListCHCategory.Add(objEntityListCHCat);
            }
        }

        DataTable dtIns = objBusinessChargeHead.ChargeHeadDplctnChk(objEntityChargeHead);
        if (dtIns.Rows.Count > 0)
        {
            int idcount = Convert.ToInt32(dtIns.Rows[0][0].ToString());
            if (idcount > 0)
            {
                flag++;
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
        else
        {
            objBusinessChargeHead.InsertChargeHead(objEntityChargeHead, objEntityListCHCategory);
            if (clickedButton.ID == "btnsave")
            {
                Response.Redirect("pms_ChargeHead.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnsaveAndClose")
            {
                Response.Redirect("pms_ChargeHeadList.aspx?InsUpd=Ins");
            }
        }

    }
    public void LoadChargeHeadDetails(string strP_Id, int EditOrView)
    {

        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityChargeHead.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityChargeHead.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityChargeHead.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityChargeHead.vendorCategoryID = Convert.ToInt32(strP_Id);
        DataTable dt = objBusinessChargeHead.ReadChargeHead_ByID(objEntityChargeHead);
        if (dt.Rows.Count > 0)
        {
            txtChargeHead.Text = dt.Rows[0]["CHRGHD_NAME"].ToString();
            txtChargeHeadCode.Text = dt.Rows[0]["CHRGHD_CODE"].ToString();
            ddlCalcultnMethod.SelectedValue = dt.Rows[0]["CHRGHD_CALCULATE"].ToString();
            if (dt.Rows[0]["CHRGHD_STATUS"].ToString() == "1")
            {
                ChkStatus.Checked = true;
            }
            else
            {
                ChkStatus.Checked = false;
            }
        }

        DataTable dtCategory = objBusinessChargeHead.ReadChargeHeadCategoryByID(objEntityChargeHead);

        for (int i = 0; i < dtCategory.Rows.Count; i++)
        {
            hiddenCHCategory.Value = hiddenCHCategory.Value + "," + dtCategory.Rows[i]["CHRGCTGRY_ID"].ToString();
        }

        if (EditOrView == 0)
        {
            txtChargeHead.Enabled = false;
            txtChargeHeadCode.Enabled = false;
            ChkStatus.Disabled = true;
            ddlCalcultnMethod.Enabled = false;
            ddlCategory.Enabled = false;
        }

    }
    public void LoadChargeHeadCategory()
    {
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccount = objBusinessChargeHead.ReadChargeHeadCategory(objEntityChargeHead);
        ddlCategory.Items.Clear();

        ddlCategory.DataSource = dtAccount;
        ddlCategory.DataTextField = "CHRGCTGRY_NAME";
        ddlCategory.DataValueField = "CHRGCTGRY_ID";
        ddlCategory.DataBind();
        //ddlParntGrp.Items.Insert(0, "");

        //int prmryVal = Convert.ToInt32(dtAccount.Rows[0]["PRIMARY"].ToString());

        //   Convert.ToInt32( (clsCommonLibrary.ACNT_GRP_ID.PRIMARY).ToString());
        //ListItem selectedListItem = ddlParntGrp.Items.FindByValue(prmryVal.ToString());

        //if (selectedListItem != null)
        //{
        //    selectedListItem.Selected = true;
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityChargeHead.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityChargeHead.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityChargeHead.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityChargeHead.vendorCategoryID = Convert.ToInt32(strId);
        objEntityChargeHead.ChargeHead = txtChargeHead.Text;
        objEntityChargeHead.ChargeHeadCode = txtChargeHeadCode.Text;
        objEntityChargeHead.CHCategoryId =Convert.ToInt32( ddlCategory.SelectedItem.Value);
        objEntityChargeHead.CHCalculate = Convert.ToInt32(ddlCalcultnMethod.SelectedItem.Value);
        if (ChkStatus.Checked == true)
        {
            objEntityChargeHead.Status = 1;
        }
        else
        {
            objEntityChargeHead.Status = 0;
        }

        List<clsEntityChargeHeads> objEntityListCHCategory = new List<clsEntityChargeHeads>();
        string AllCategory = hiddenCHCategory.Value;
        string[] EachCatId = AllCategory.Split(',');
        foreach (string CatId in EachCatId)
        {
            if (CatId != "")
            {
                clsEntityChargeHeads objEntityListCHCat = new clsEntityChargeHeads();
                objEntityListCHCat.CHCategoryId = Convert.ToInt32(CatId);
                objEntityListCHCategory.Add(objEntityListCHCat);
            }
        }




        string strNameCount = "0";
        DataTable dtIns = objBusinessChargeHead.ChargeHeadDplctnChk(objEntityChargeHead);
        if (dtIns.Rows.Count > 0 )
        {
            int idcount = Convert.ToInt32(dtIns.Rows[0][0].ToString());
            if (idcount > 0 && strId!=idcount.ToString())
            {
                //flag++;
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
        else
        {
            if (txtChargeHead.Text != "" && txtChargeHead.Text != null && txtChargeHeadCode.Text != "" && txtChargeHeadCode != null)
            {
                objBusinessChargeHead.updateChargeHead(objEntityChargeHead, objEntityListCHCategory);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("pms_ChargeHead.aspx?InsUpd=Upd&Id=" + Request.QueryString["Id"].ToString());
                }
                else
                {
                    Response.Redirect("pms_ChargeHeadList.aspx?InsUpd=Upd");
                }
            }
        }
    }
}

      //$(document).ready(function () {

      //      var CntryId = document.getElementById("<%=hiddenCntrySelectd.ClientID%>").value;
      //              var CntryName = document.getElementById("<%=hiddenCntryName.ClientID%>").value;
      //              var CntrySts = document.getElementById("<%=hiddenCntryStatus.ClientID%>").value;

      //              var totalString = CntryId;
      //              var Status = CntryName;
      //              var UserName = CntrySts;
      //              varSts = Status.split(',');
      //              varUsernm = UserName.split(',');
      //              eachString = totalString.split(',');
      //              var newVar = new Array();
      //              for (count = 0; count < eachString.length; count++) {
      //                  if (eachString[count] != "") {
      //                      newVar.push(eachString[count]);

      //                      if (varSts[count] == "False") {

      //                          var newOption = "<option value='" + eachString[count] + "'>" + varUsernm[count] + "</option>";

      //                          $('#<%=ddlCategory.ClientID%>').append(newOption);
      //                  //SORTING DDL
      //                  var options = $("#<%=ddlCategory.ClientID%> option");                    // Collect options         
      //                  options.detach().sort(function (a, b) {               // Detach from select, then Sort
      //                      var at = $(a).text();
      //                      var bt = $(b).text();
      //                      return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
      //                  });
      //                  options.appendTo('#<%=ddlCategory.ClientID%>');
      //              }


      //          }
      //      }

      //              $('#cphMain_ddlCountry').val(newVar);
      //              $("#cphMain_ddlCountry").trigger("change");
      //          });
