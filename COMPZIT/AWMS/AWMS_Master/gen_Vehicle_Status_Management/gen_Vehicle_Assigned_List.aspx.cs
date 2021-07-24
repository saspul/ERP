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
using System.Text;
using System.IO;

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Assigned_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StatusTypeLoad();
            int intUserId = 0, intUsrRolMstrId, intEnableCancel = 0, intEnableClose = 0, intEnableConfirm = 0,intEnableModify=0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["CORPOFFICEID"] != null)
            {
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                hiddenOrgId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            if (Request.QueryString["VehId"] != null)
            {
                hiddenVehicleId.Value = Request.QueryString["VehId"].ToString();
            }

            if (Request.QueryString["Back"] != null)
            {
                HiddenBackPage.Value = Request.QueryString["Back"].ToString();
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Management);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleClose.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = "1";
                    }
                }
            }

            GridLoad();
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "CancelOther")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelete", "SuccessDelete();", true);
                }
                else if (strInsUpd == "CnFrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (strInsUpd == "CnfrmDup")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmDuplication", "ConfirmDuplication();", true);
                }
                    
                else if (strInsUpd == "StsCls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (strInsUpd == "UpdOther")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
                }
            }


           
        }
    }

    public void StatusTypeLoad()
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        DataTable dtStsType = new DataTable();
        dtStsType = objBusinessVehicle.ReadVehicleStatsType(objEntityVehicle);
        if (dtStsType.Rows.Count > 0)
        {
            ddlStatusType.DataSource = dtStsType;
            ddlStatusType.DataValueField = "VHCLSTSTYP_ID";
            ddlStatusType.DataTextField = "VHCLSTSTYP_NAME";
            ddlStatusType.DataBind();
            ddlStatusType.Items.Insert(0, "--SELECT--");
        }
       
    }
    public void GridLoad()
    {
        clsBussinesLayerVehicleStatusMngmnt objBussinessVhclSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVhclSts = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVhclSts.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVhclSts.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (hiddenVehicleId.Value != "")
        {
            objEntityVhclSts.VehicleId = Convert.ToInt32(hiddenVehicleId.Value);
        }
        objEntityVhclSts.VehicleStsTyp = 0;
        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadVehicleAssignListById(objEntityVhclSts);
        if (dtVehicleDetail.Rows.Count > 0)
        {
            GridVehicleAssignList.DataSource = dtVehicleDetail;
            GridVehicleAssignList.DataBind();
        }
        else
        {
            GridVehicleAssignList.DataSource = dtVehicleDetail;
            GridVehicleAssignList.DataBind();
        }

    }
    protected void GridVehicleAssignList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridLoad();
        GridVehicleAssignList.PageIndex = e.NewPageIndex;
        GridVehicleAssignList.DataBind();
    }
    protected void GridVehicleAssignList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (hiddenRoleCancel.Value != "1")
            {
                ImageButton imgDeleteOther = (ImageButton)e.Row.FindControl("imgDeleteOther");
                ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                if (imgDeleteOther != null && imgDeleteOtherNot != null)
                {
                    imgDeleteOtherNot.Visible = false;
                    imgDeleteOther.Visible = false;
                }
            }
            else
            {
                ImageButton OtherDeleteButton = (ImageButton)e.Row.FindControl("imgDeleteOther");
                ImageButton imgDeleteOtherNotButton = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                if (OtherDeleteButton != null && imgDeleteOtherNotButton!=null)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "VHCLASGN_CNFRM_STS").ToString() != "1")
                    {
                        ImageButton imgDeleteOther = (ImageButton)e.Row.FindControl("imgDeleteOther");
                        imgDeleteOther.Visible = true;
                        ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                        imgDeleteOtherNot.Visible = false;
                        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCLASGN_ID"));
                        OtherDeleteButton.Attributes.Add("onclick", "javascript:return DeleteOther(" + Ids + ")");
                    }
                    else
                    {
                        ImageButton imgDeleteOther = (ImageButton)e.Row.FindControl("imgDeleteOther");
                        imgDeleteOther.Visible = false;
                        ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                        imgDeleteOtherNot.Visible = true;
                        imgDeleteOtherNot.Attributes.Add("onclick", "javascript:return DeleteAssignNotPosible()");
                    }

                }

            }
            if (hiddenRoleClose.Value != "1")
            {
                Image imgCloseOther = (Image)e.Row.FindControl("imgCloseOther");
                Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseOtherNot");
                if (imgCloseOther != null && imgCloseOtherNot != null)
                {
                    imgCloseOtherNot.Visible = false;
                    imgCloseOther.Visible = false;
                }

            }
            else
            {
                //for close other
                Image CloseOther = (Image)e.Row.FindControl("imgCloseOther");
                Image CloseOtherNo = (Image)e.Row.FindControl("imgCloseOtherNot");

                if (DataBinder.Eval(e.Row.DataItem, "VHCLASGN_CNFRM_STS").ToString() == "1")
                {
                    if (CloseOther != null && CloseOtherNo != null)
                    {

                        Image imgCloseOther = (Image)e.Row.FindControl("imgCloseOther");
                        imgCloseOther.Visible = true;
                        Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseOtherNot");
                        imgCloseOtherNot.Visible = false;
                        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCLASGN_ID"));
                        imgCloseOther.Attributes.Add("onclick", "javascript:return CloseStatus(" + Ids + ")");


                    }
                }
                else
                {
                    if (CloseOther != null && CloseOtherNo != null)
                    {

                        Image imgCloseOther = (Image)e.Row.FindControl("imgCloseOther");
                        imgCloseOther.Visible = false;
                        Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseOtherNot");
                        imgCloseOtherNot.Visible = true;
                        imgCloseOtherNot.Attributes.Add("onclick", "javascript:return CloseStatusNot()");

                    }
                }

            }

            if (hiddenRoleConfirm.Value != "1")
            {
                Image imgAproveOther = (Image)e.Row.FindControl("imgApproveOther");
                Image imgAproveOtherNot = (Image)e.Row.FindControl("imgApproveOtherNot");
                if (imgAproveOther != null && imgAproveOtherNot != null)
                {
                    imgAproveOtherNot.Visible = false;
                    imgAproveOther.Visible = false;
                }
            }
            else
            {

                //for confirm Asign
                Image AproveAsgn = (Image)e.Row.FindControl("imgApproveOther");
                Image imgCloseAgnNo = (Image)e.Row.FindControl("imgApproveOtherNot");

                if (AproveAsgn != null && imgCloseAgnNo != null)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "VHCLASGN_CNFRM_STS").ToString() != "1")
                    {
                        Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveOther");
                        imgAproveAsign.Visible = true;
                        Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveOtherNot");
                        imgAproveAsignNot.Visible = false;

                        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCLASGN_ID"));
                        imgAproveAsign.Attributes.Add("onclick", "javascript:return ConfirmAssign(" + Ids + ")");
                    }
                    else
                    {
                        Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveOther");
                        imgAproveAsign.Visible = false;
                        Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveOtherNot");
                        imgAproveAsignNot.Visible = true;
                        imgAproveAsignNot.Attributes.Add("onclick", "javascript:return AlreadyConfirmed()");
                    }

                }
            }


            if (hiddenRoleUpdate.Value != "1")
            {
                Image imgeditOther = (Image)e.Row.FindControl("imgEdit");
                Image imgEditOtherNot = (Image)e.Row.FindControl("imgEditNot");
                if (imgeditOther != null && imgEditOtherNot != null)
                {
                    imgEditOtherNot.Visible = false;
                    imgeditOther.Visible = false;
                }
            }
            else
            {
                if (DataBinder.Eval(e.Row.DataItem, "VHCLASGN_CNFRM_STS").ToString() != "1")
                {
                    Image imgeditOther = (Image)e.Row.FindControl("imgEdit");
                    imgeditOther.Visible = true;
                    Image imgEditOtherNot = (Image)e.Row.FindControl("imgEditNot");
                    imgEditOtherNot.Visible = false;

                    int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCLASGN_ID"));
                    int intVid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                    imgeditOther.Attributes.Add("onclick", "javascript:return EditAssign(" + Ids + "," + intVid + ")");
                }
                else
                {
                    Image imgeditOther = (Image)e.Row.FindControl("imgEdit");
                    imgeditOther.Visible = false;
                    Image imgEditOtherNot = (Image)e.Row.FindControl("imgEditNot");
                    imgEditOtherNot.Visible = true;
                    int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCLASGN_ID"));
                    int intVid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                    imgEditOtherNot.Attributes.Add("onclick", "javascript:return ViewAssign(" + Ids + "," + intVid + ")");
                }

            }
          
        }
    }

    protected void btnSaveCancelReasonOther_Click(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBussinessVhclSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVhclSts = new clsEntityVehicleStatusMngmnt();
        string strVehId =hiddenVehicleId.Value;
        if (hiddenVehAsignCnclId.Value != "")
        {
            objEntityVhclSts.VehAsignId = Convert.ToInt32(hiddenVehAsignCnclId.Value);
        }
        if (Session["USERID"] != null)
        {
            hiddenUserId.Value = Session["USERID"].ToString();
            objEntityVhclSts.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityVhclSts.CancelReason = txtCancelreason.Text.Trim();

        objBussinessVhclSts.CancelOtherStatus(objEntityVhclSts);

        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {

            Response.Redirect("gen_Vehicle_Assigned_List.aspx?InsUpd=CancelOther&&VehId=" + strVehId + "&Back=" + Request.QueryString["Back"] + "");
        }
        else
        {
            Response.Redirect("gen_Vehicle_Assigned_List.aspx?InsUpd=CancelOther&&VehId=" + strVehId + "");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBussinessVhclSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVhclSts = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVhclSts.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVhclSts.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (hiddenVehicleId.Value != "")
        {
            objEntityVhclSts.VehicleId = Convert.ToInt32(hiddenVehicleId.Value);
        }
        if (ddlStatusType.SelectedItem.Value != "--SELECT--")
        {
            objEntityVhclSts.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
        }
        else
        {
            objEntityVhclSts.VehicleStsTyp = 0;
        }
        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadVehicleAssignListById(objEntityVhclSts);
        if (dtVehicleDetail.Rows.Count > 0)
        {
            GridVehicleAssignList.DataSource = dtVehicleDetail;
            GridVehicleAssignList.DataBind();
        }
        else
        {
            GridVehicleAssignList.DataSource = dtVehicleDetail;
            GridVehicleAssignList.DataBind();
        }
    }

}