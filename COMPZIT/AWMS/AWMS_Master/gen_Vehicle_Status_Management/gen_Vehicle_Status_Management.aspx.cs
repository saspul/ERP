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
using System.Collections;

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Status_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProjectDefaultLoad();
            DivisionLoad();
            AutoCloseStatus();
            VehicleNumber();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableClose = 0, intEnableConfirm = 0;
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


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Management);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
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

            if (intEnableAdd == 0)
            {
                BtnBulkAssign.Visible = false;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "MkAvail")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMakeAvailable", "SuccessMakeAvailable();", true);
                }
                if (strInsUpd == "StsCls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                if (strInsUpd == "InsAsgn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAsign", "SuccessAsign();", true);
                }
                if (strInsUpd == "UpdAsign")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdAsign", "SuccessUpdAsign();", true);
                }
                if (strInsUpd == "InsOther")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessOtherStatus", "SuccessOtherStatus();", true);
                }
                if (strInsUpd == "CnFrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                if (strInsUpd == "CancelAsgn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelete", "SuccessDelete();", true);
                }
            }
            GridLoad();
            if (Request.QueryString["VhclID"] != null)
            {
                HiddenBackPage.Value = Request.QueryString["VhclID"].ToString();
                string strRandomMixedId = Request.QueryString["VhclID"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                ddlVehicleNumber.Items.FindByValue(strId).Selected = true;
               
                SearchClick();
            }
           
        }

    }
    //set vehcle renewal details
    private void VehicleNumber()
    {
        clsBussinesLayerVehicleStatusMngmnt objBussinessVhclSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVhclSts = new clsEntityVehicleStatusMngmnt();

        DataTable dtRenewal = objBussinessVhclSts.ReadVehicleNumber(objEntityVhclSts);

        ddlVehicleNumber.DataSource = dtRenewal;

        ddlVehicleNumber.DataTextField = "VHCL_NUMBR";
        ddlVehicleNumber.DataValueField = "VHCL_ID";
        ddlVehicleNumber.DataBind();
        ddlVehicleNumber.Items.Insert(0, "--SELECT VEHICLE NUMBER--");

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
        objEntityVhclSts.VehicleId = 0;
        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadVehicles(objEntityVhclSts);
        if (dtVehicleDetail.Rows.Count > 0)
        {
            GridVehicleStatusMngmnt.DataSource = dtVehicleDetail;
            GridVehicleStatusMngmnt.DataBind();
        }
        else
        {
            GridVehicleStatusMngmnt.DataSource = dtVehicleDetail;
            GridVehicleStatusMngmnt.DataBind();
        }

    }

    protected void GridVehicleStatusMngmnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridLoad();
        GridVehicleStatusMngmnt.PageIndex = e.NewPageIndex;
        GridVehicleStatusMngmnt.DataBind();
    }
    protected void btnSaveCancelReason_Click(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBussinessVhclSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVhclSts = new clsEntityVehicleStatusMngmnt();
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

        objBussinessVhclSts.CancelAssignVehicle(objEntityVhclSts);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelete", "SuccessDelete();", true);
        if (Request.QueryString["VhclID"] != null)
        {
            HiddenBackPage.Value = Request.QueryString["VhclID"].ToString();
            string strRandomMixedId = Request.QueryString["VhclID"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ddlVehicleNumber.Items.FindByValue(strId).Selected = true;
        }
        SearchClick();
        //Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=CancelAsgn");
    }


    protected void GridVehicleStatusMngmnt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        hiddenRowCount.Value = GridVehicleStatusMngmnt.Rows.Count.ToString();
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

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgVehConfrm = (Image)e.Row.FindControl("imgAssignVehNot");//evm-20
            imgVehConfrm.Visible = false;

            if (hiddenRoleCancel.Value != "1")
            {
                ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDeleteAsign");
                ImageButton imgDeleteNot = (ImageButton)e.Row.FindControl("ImageDeleteNotPos");
                if (imgDelete != null && imgDeleteNot != null)
                {
                    imgDeleteNot.Visible = false;
                    imgDelete.Visible = false;
                }

                //ImageButton imgDeleteOther = (ImageButton)e.Row.FindControl("imgDeleteOther");
                //ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                //if (imgDeleteOther != null && imgDeleteOtherNot != null)
                //{
                //    imgDeleteOtherNot.Visible = false;
                //    imgDeleteOther.Visible = false;
                //}
            }
            else
            {


                ImageButton AsgnDeleteButton = (ImageButton)e.Row.FindControl("imgDeleteAsign");
                if (AsgnDeleteButton != null)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "ASIGN_CNFRM_STS").ToString() != "1")
                        {
                            ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDeleteAsign");
                            imgDelete.Visible = true;
                            ImageButton imgDeleteNot = (ImageButton)e.Row.FindControl("ImageDeleteNotPos");
                            imgDeleteNot.Visible = false;

                            int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID"));
                            AsgnDeleteButton.Attributes.Add("onclick", "javascript:return DeleteAssign(" + Ids + ")");
                        }
                        else
                        {
                            ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDeleteAsign");
                            imgDelete.Visible = false;
                            ImageButton imgDeleteNot = (ImageButton)e.Row.FindControl("ImageDeleteNotPos");
                            imgDeleteNot.Visible = true;
                            imgDeleteNot.Attributes.Add("onclick", "javascript:return DeleteAssignNotPosible()");
                        }

                    }
                    else
                    {
                        ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDeleteAsign");
                        imgDelete.Visible = false;
                        ImageButton imgDeleteNot = (ImageButton)e.Row.FindControl("ImageDeleteNotPos");
                        imgDeleteNot.Visible = true;
                        imgDeleteNot.Attributes.Add("onclick", "javascript:return NotAssigned()");
                    }

                }

                //ImageButton OtherDeleteButton = (ImageButton)e.Row.FindControl("imgDeleteOther");

                //if (OtherDeleteButton != null)
                //{
                //    if (DataBinder.Eval(e.Row.DataItem, "OTHER_ASGNID") != DBNull.Value)
                //    {

                //        ImageButton imgDeleteOther = (ImageButton)e.Row.FindControl("imgDeleteOther");
                //        imgDeleteOther.Visible = true;
                //        ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                //        imgDeleteOtherNot.Visible = false;
                //        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OTHER_ASGNID"));
                //        OtherDeleteButton.Attributes.Add("onclick", "javascript:return DeleteOther(" + Ids + ")");

                //    }
                //    else
                //    {
                //        ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDeleteOther");
                //        imgDelete.Visible = false;
                //        ImageButton imgDeleteOtherNot = (ImageButton)e.Row.FindControl("ImageDeleteOtherNot");
                //        imgDeleteOtherNot.Visible = true;

                //    }

                //}

            }


            if (hiddenRoleAdd.Value != "1")
            {
                Image imgAddAsign = (Image)e.Row.FindControl("imgAssignVeh");
                Image imgAddOther = (Image)e.Row.FindControl("imgOtherSts");
                if (imgAddAsign != null && imgAddOther != null)
                {
                    imgAddOther.Visible = false;
                    imgAddAsign.Visible = false;
                }
            }
            else
            {
                Image imgAddAsign = (Image)e.Row.FindControl("imgAssignVeh");
                imgAddAsign.Visible = true;

                int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                if (DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value)
                {
                    int intAsignId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID"));
                    imgAddAsign.Attributes.Add("onclick", "javascript:return EditAssignCall(" + intAsignId + ")");
                    if (DataBinder.Eval(e.Row.DataItem, "ASIGN_CNFRM_STS").ToString() == "1")//evm-20
                    {
                        imgAddAsign.Visible = false;
                        imgVehConfrm.Visible = true;
                        imgVehConfrm.Attributes.Add("onclick", "javascript:return EditAssignCall(" + intAsignId + ")");
                    }
                }
                else
                {
                    imgAddAsign.Attributes.Add("onclick", "javascript:return AssignCall(" + Ids + ")");
                }


                Image imgAddOther = (Image)e.Row.FindControl("imgOtherSts");
                imgAddOther.Visible = true;
                imgAddOther.Attributes.Add("onclick", "javascript:return OtherStatusCall(" + Ids + ")");

            }

            if (hiddenRoleClose.Value != "1")
            {
                Image imgCloseAsign = (Image)e.Row.FindControl("imgCloseAsgn");
                Image imgCloseAgnNot = (Image)e.Row.FindControl("imgCloseAsgnNot");

                if (imgCloseAsign != null && imgCloseAgnNot != null)
                {
                    imgCloseAsign.Visible = false;
                    imgCloseAgnNot.Visible = false;
                }

                Image imgMakAvlAsign = (Image)e.Row.FindControl("imgMakeAvail");
                Image imgMakAvlAsignNot = (Image)e.Row.FindControl("imgMakeAvailNot");
                if (imgMakAvlAsign != null && imgMakAvlAsignNot != null)
                {
                    imgMakAvlAsign.Visible = false;
                    imgMakAvlAsignNot.Visible = true;
                    imgMakAvlAsignNot.Attributes.Add("onclick", "javascript:return MakeAvailableNot()");
                }
                //Image imgCloseOther = (Image)e.Row.FindControl("imgCloseOther");
                //Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseOtherNot");
                //if (imgCloseOther != null && imgCloseOtherNot != null)
                //{
                //    imgCloseOtherNot.Visible = false;
                //    imgCloseOther.Visible = false;
                //}

            }
            else
            {
                Image imgMakAvlAsign = (Image)e.Row.FindControl("imgMakeAvail");
                Image imgMakAvlAsignNot = (Image)e.Row.FindControl("imgMakeAvailNot");

                //FOR MAK AVAIL OR NOT
                objEntityVhclSts.VehicleId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                objEntityVhclSts.VehicleStsTyp = 0;
                DataTable dtVehicleDetail = new DataTable();
                dtVehicleDetail = objBussinessVhclSts.ReadVehicleAssignListById(objEntityVhclSts);
                string strMkPossible = "0";
                if (dtVehicleDetail.Rows.Count > 0)
                {
                    for (int count = 0; count < dtVehicleDetail.Rows.Count; count++)
                    {
                        if (dtVehicleDetail.Rows[count]["VHCLASGN_CNFRM_STS"].ToString() == "1")
                        {
                            strMkPossible = "1";
                        }
                    }
                }

                if ((DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value && DataBinder.Eval(e.Row.DataItem, "ASIGN_CNFRM_STS").ToString() == "1") || strMkPossible == "1")
                {
                    if (imgMakAvlAsign != null && imgMakAvlAsignNot != null)
                    {
                        imgMakAvlAsign.Visible = true;
                        imgMakAvlAsignNot.Visible = false;
                        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                        imgMakAvlAsign.Attributes.Add("onclick", "javascript:return MakeAvailable(" + Ids + ")");
                    }
                }
                else
                {
                    if (imgMakAvlAsign != null && imgMakAvlAsignNot != null)
                    {
                        imgMakAvlAsign.Visible = false;
                        imgMakAvlAsignNot.Visible = true;
                        int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
                        imgMakAvlAsignNot.Attributes.Add("onclick", "javascript:return AlreadyAvailable()");
                    }
                }
                //for close Asign
                Image CloseAsgn = (Image)e.Row.FindControl("imgCloseAsgn");
                Image imgCloseAgnNo = (Image)e.Row.FindControl("imgCloseAsgnNot");

                if (CloseAsgn != null && imgCloseAgnNo != null)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "ASIGN_CNFRM_STS").ToString() == "1")
                        {
                            Image imgCloseAsgn = (Image)e.Row.FindControl("imgCloseAsgn");
                            imgCloseAsgn.Visible = true;
                            Image imgCloseAgnNot = (Image)e.Row.FindControl("imgCloseAsgnNot");
                            imgCloseAgnNot.Visible = false;

                            int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID"));
                            imgCloseAsgn.Attributes.Add("onclick", "javascript:return CloseStatus(" + Ids + ")");
                        }
                        else
                        {
                            Image imgCloseAsgn = (Image)e.Row.FindControl("imgCloseAsgn");
                            imgCloseAsgn.Visible = false;
                            Image imgCloseAgnNot = (Image)e.Row.FindControl("imgCloseAsgnNot");
                            imgCloseAgnNot.Visible = true;
                            imgCloseAgnNot.Attributes.Add("onclick", "javascript:return CloseStatusNot()");
                        }
                    }
                    else
                    {
                        Image imgCloseAsgn = (Image)e.Row.FindControl("imgCloseAsgn");
                        imgCloseAsgn.Visible = false;
                        Image imgCloseAgnNot = (Image)e.Row.FindControl("imgCloseAsgnNot");
                        imgCloseAgnNot.Visible = true;
                        imgCloseAgnNot.Attributes.Add("onclick", "javascript:return NotAssigned()");
                    }
                }

                //for close other
                string s="chkVehicle"+e.Row.DataItemIndex;
                CheckBox CloseOther = (CheckBox)e.Row.FindControl("ChkVehlceSelect");
                Image CloseOtherNo = (Image)e.Row.FindControl("imgCloseAsgnNot");
                int Idsa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VHCL_ID"));
          
                if (CloseOther != null && CloseOtherNo != null)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value)
                    {

                        CheckBox imgCloseOther = (CheckBox)e.Row.FindControl("ChkVehlceSelect");
                        imgCloseOther.Enabled = false;
                        Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseAsgnNot");
                        imgCloseOtherNot.Visible = false;
                       
                    }
                    else
                    {
                         //  imgCloseOtherNo.Visible = true;
                        CheckBox imgCloseOther = (CheckBox)e.Row.FindControl("ChkVehlceSelect");
                        imgCloseOther.Visible = true;
                        Image imgCloseOtherNot = (Image)e.Row.FindControl("imgCloseAsgnNot");
                        imgCloseOtherNot.Visible = false;
                       int Ids = 0;
                        imgCloseOther.Attributes.Add("onclick", "javascript:return selectedcount(" + e.Row.RowIndex + ")");
                        imgCloseOther.InputAttributes.Add("value",  Idsa.ToString() );

                    }
                    //}

                }

                if (hiddenRoleConfirm.Value != "1")
                {
                    Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveAsign");
                    Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveAsignNot");
                    if (imgAproveAsign != null && imgAproveAsignNot != null)
                    {
                        imgAproveAsignNot.Visible = false;
                        imgAproveAsign.Visible = false;
                    }
                }
                else
                {

                    //for CONFIRM Asign
                    Image AproveAsgn = (Image)e.Row.FindControl("imgApproveAsign");
                    Image imgCloseAgnNo1 = (Image)e.Row.FindControl("imgApproveAsignNot");

                    if (AproveAsgn != null && imgCloseAgnNo1 != null)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID") != DBNull.Value)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, "ASIGN_CNFRM_STS").ToString() != "1")
                            {
                                Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveAsign");
                                imgAproveAsign.Visible = true;
                                Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveAsignNot");
                                imgAproveAsignNot.Visible = false;

                                int Ids = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ASIGN_ASGNID"));
                                imgAproveAsign.Attributes.Add("onclick", "javascript:return ConfirmAssign(" + Ids + ")");
                            }
                            else
                            {
                                Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveAsign");
                                imgAproveAsign.Visible = false;
                                Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveAsignNot");
                                imgAproveAsignNot.Visible = true;
                                imgAproveAsignNot.Attributes.Add("onclick", "javascript:return AlreadyConfirmed()");
                            }
                        }

                        else
                        {
                            Image imgAproveAsign = (Image)e.Row.FindControl("imgApproveAsign");
                            imgAproveAsign.Visible = false;
                            Image imgAproveAsignNot = (Image)e.Row.FindControl("imgApproveAsignNot");
                            imgAproveAsignNot.Visible = true;
                            imgAproveAsignNot.Attributes.Add("onclick", "javascript:return NotAssigned()");
                        }
                    }
                }
            }
        }

    }




    public void AutoCloseStatus()
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

        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadVehicleAssignForAllocate(objEntityVhclSts);
        if (dtVehicleDetail.Rows.Count > 0)
        {
            for (int intcount = 0; intcount < dtVehicleDetail.Rows.Count; intcount++)
            {
                objEntityVhclSts.VehAsignId = Convert.ToInt32(dtVehicleDetail.Rows[intcount]["VHCLASGN_ID"].ToString());
                objEntityVhclSts.User_Id = Convert.ToInt32(dtVehicleDetail.Rows[intcount]["VHCLASGN_INS_USR_ID"].ToString());
                objBussinessVhclSts.AutoCloseStatus(objEntityVhclSts);
            }

        }

    }
    
    public void SearchClick()
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
       
        if (ddlVehicleNumber.SelectedItem.Value != "--SELECT VEHICLE NUMBER--")
        {
        objEntityVhclSts.VehicleId = Convert.ToInt32(ddlVehicleNumber.SelectedItem.Value);
         }
        else
        {
        objEntityVhclSts.VehicleId = 0;
        }
       
        if (ddlAsignMode.SelectedItem.Value != "--SELECT--")
        {
            objEntityVhclSts.AssignMode = Convert.ToInt32(ddlAsignMode.SelectedItem.Value);
        }
        else
        {
            objEntityVhclSts.AssignMode = 0;
        }
        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadVehicles(objEntityVhclSts);

        if (dtVehicleDetail.Rows.Count > 0)
        {
            GridVehicleStatusMngmnt.DataSource = dtVehicleDetail;
            GridVehicleStatusMngmnt.DataBind();
        }
        else
        {
            GridVehicleStatusMngmnt.DataSource = dtVehicleDetail;
            GridVehicleStatusMngmnt.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchClick();
    }

    protected void BtnBulkAssign_Click(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
            
       // hiddenVehicleId.Value = Request.QueryString["BulkVehId"].ToString();
        hiddenVehicleId.Value = Hiddenchecklist.Value;
        string[] tokens = Hiddenchecklist.Value.Split(',');
        //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
        // {

        for (int i = 0; i < tokens.Count() - 1; i++)
        {
            btnAssign.Visible = true;
            objEntityVehicle.VehicleId = Convert.ToInt32(Request.QueryString["VehId"].ToString());
            objEntityVehicle.VehAsignId = 0;

            DataTable dtVehicleName = objBusinessVehicle.ReadVehNumber(objEntityVehicle);
            if (dtVehicleName.Rows.Count > 0)
            {
                // lblVehicleNum.Text = dtVehicleName.Rows[0]["VHCL_NUMBR"].ToString();

                lblVehicleNum.Text = lblVehicleNum.Text + tokens[i].ToString();
            } 
        }
    }
    public void ProjectDefaultLoad()
    {
     
        ddlProject_Employee.Items.Insert(0, "--SELECT--");
    }
    public void DivisionLoad()
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtInsDetails = new DataTable();
        dtInsDetails = objBusinessVehicle.ReadDivision(objEntityVehicle);
        if (dtInsDetails.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtInsDetails;
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--SELECT--");
        }

    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDivision.SelectedItem.Text != "--SELECT--")
        {
            objEntityVehicle.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }

        if (radioGeneral.Checked != true)
        {
            ddlProject_Employee.Items.Clear();
            if (radioEmployee.Checked == true)
            {
                DataTable dtEmployee = new DataTable();
                dtEmployee = objBusinessVehicle.ReadEmployee(objEntityVehicle);
                if (dtEmployee.Rows.Count > 0)
                {
                    ddlProject_Employee.DataSource = dtEmployee;
                    ddlProject_Employee.DataValueField = "USR_ID";
                    ddlProject_Employee.DataTextField = "USR_NAME";
                    ddlProject_Employee.DataBind();
                }
            }

            if (radioProject.Checked == true)
            {
                DataTable dtProject = new DataTable();
                dtProject = objBusinessVehicle.ReadProject(objEntityVehicle);
                if (dtProject.Rows.Count > 0)
                {
                    ddlProject_Employee.DataSource = dtProject;
                    ddlProject_Employee.DataValueField = "PROJECT_ID";
                    ddlProject_Employee.DataTextField = "PROJECT_NAME";
                    ddlProject_Employee.DataBind();
                }
            }
            //ddlProject_Employee.Enabled = true;
            ddlProject_Employee.Items.Insert(0, "--SELECT--");
            //lblproject_emp.Text = "Project/Employee*";
        }
        //else
        //{
        //    ddlProject_Employee.Enabled = false;
        //    lblproject_emp.Text = "Project/Employee";
        //}
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlFocus", "ddlFocus();", true);
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        string[] tokens = HiddenVehicleList.Value.Split(',');
        //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
        // {
        int flag = 1;
        for (int i = 0; i < tokens.Count() - 1 && tokens[i] != ""; i++)
        {

            hiddenVehicleId.Value=tokens[i];
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_ASSIGN);
            objEntityCommon.CorporateID = objEntityVehicle.CorporateId;
            objEntityCommon.Organisation_Id = objEntityVehicle.Org_Id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityVehicle.NextIdForAssign = Convert.ToInt32(strNextId);


            objEntityVehicle.VehicleId = Convert.ToInt32(hiddenVehicleId.Value);
            objEntityVehicle.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            if (radioProject.Checked == true)
            {
                objEntityVehicle.AssignMode = 1;
                objEntityVehicle.AssignedToPrjct = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);

            }
            if (radioEmployee.Checked == true)
            {
                objEntityVehicle.AssignMode = 2;
                objEntityVehicle.AssignedToUser = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);
            }
            if (radioGeneral.Checked == true)
            {
                objEntityVehicle.AssignMode = 3;
            }
            objEntityVehicle.VehicleStsTyp = 1;
            objEntityVehicle.VehicleSts = 1;

            if (txtFromDate.Text.Trim() != "")
            {
                objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            }

            if (txtToDate.Text.Trim() != "")
            {
                objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }

            string DateCount = objBusinessVehicle.CheckDateInAsgn(objEntityVehicle);
            if (DateCount == "0")
            {
                flag = 0;
                objBusinessVehicle.AddAssignVehicle(objEntityVehicle);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "InvalidDateAlert", "InvalidDateAlert();", true);

            }
        } 
        if (flag == 0)
        {
                
                    Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=InsAsgn");
               
            }
           
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
        ddlDivision.SelectedIndex = 0;
        ddlProject_Employee.SelectedIndex = 0;
        radioProject.Checked = true;

        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {
            // string strVeh = hiddenRedirect.Value.ToString();
            Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "");
        }
        if (Request.QueryString["VehAsgn"] != null)
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx");
        }
        if (Request.QueryString["VehId"] != null)
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx");
        }

    }


    public void Update(int VehAsgnId)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Management);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {

                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }

            }
        }
        objEntityVehicle.VehAsignId = VehAsgnId;

        DataTable dtAsignDetail = new DataTable();
        dtAsignDetail = objBusinessVehicle.ReadVehicleAssignDetailsById(objEntityVehicle);
        if (dtAsignDetail.Rows.Count > 0)
        {
            txtFromDate.Text = dtAsignDetail.Rows[0]["FROM_DATE"].ToString();
            txtToDate.Text = dtAsignDetail.Rows[0]["TO_DATE"].ToString();


            if (dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString() != "")
            {
                if (dtAsignDetail.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
                {
                    ddlDivision.Items.FindByValue(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["CPRDIV_NAME"].ToString(), dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }

                objEntityVehicle.DivisionId = Convert.ToInt32(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString());
            }

            if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "1")
            {
                radioProject.Checked = true;
                radioGeneral.Checked = false;
            }
            else if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "2")
            {
                radioEmployee.Checked = true;
                radioGeneral.Checked = false;
            }
            else if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "3")
            {
                radioGeneral.Checked = true;
            }

            if (radioGeneral.Checked != true)
            {
                ddlProject_Employee.Items.Clear();
                if (radioEmployee.Checked == true)
                {
                    DataTable dtEmployee = new DataTable();
                    dtEmployee = objBusinessVehicle.ReadEmployee(objEntityVehicle);
                    if (dtEmployee.Rows.Count > 0)
                    {
                        ddlProject_Employee.DataSource = dtEmployee;
                        ddlProject_Employee.DataValueField = "USR_ID";
                        ddlProject_Employee.DataTextField = "USR_NAME";
                        ddlProject_Employee.DataBind();
                    }
                }

                if (radioProject.Checked == true)
                {
                    DataTable dtProject = new DataTable();
                    dtProject = objBusinessVehicle.ReadProject(objEntityVehicle);
                    if (dtProject.Rows.Count > 0)
                    {
                        ddlProject_Employee.DataSource = dtProject;
                        ddlProject_Employee.DataValueField = "PROJECT_ID";
                        ddlProject_Employee.DataTextField = "PROJECT_NAME";
                        ddlProject_Employee.DataBind();
                    }
                }

                ddlProject_Employee.Items.Insert(0, "--SELECT--");
                //ddlProject_Employee.Enabled = true;
                //lblproject_emp.Text = "Project/Employee*";
            }
            else
            {
                //ddlProject_Employee.Enabled = false;
                //lblproject_emp.Text = "Project/Employee";
            }

            if (dtAsignDetail.Rows[0]["PROJECT_ID"].ToString() != "" && dtAsignDetail.Rows[0]["PROJECT_ID"] != DBNull.Value)
            {
                if (dtAsignDetail.Rows[0]["PROJECT_STATUS"].ToString() == "1")
                {
                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["PROJECT_NAME"].ToString(), dtAsignDetail.Rows[0]["PROJECT_ID"].ToString());
                    ddlProject_Employee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProject_Employee);

                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }

            }
            if (dtAsignDetail.Rows[0]["USR_ID"].ToString() != "" && dtAsignDetail.Rows[0]["USR_ID"] != DBNull.Value)
            {
                if (dtAsignDetail.Rows[0]["USR_STATUS"].ToString() == "1")
                {
                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["USR_NAME"].ToString(), dtAsignDetail.Rows[0]["USR_ID"].ToString());
                    ddlProject_Employee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProject_Employee);

                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }

            if (dtAsignDetail.Rows[0]["VHCLASGN_CNFRM_STS"].ToString() == "1")
            {
                lblEntry.Text = "View Vehicle Assign";
                btnUpdate.Visible = false;
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                ddlDivision.Enabled = false;
                ddlProject_Employee.Enabled = false;
                radioEmployee.Enabled = false;
                radioGeneral.Enabled = false;
                radioProject.Enabled = false;

            }


        }
        if (intEnableModify != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = false;
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ddlDivision.Enabled = false;
            ddlProject_Employee.Enabled = false;
            radioEmployee.Enabled = false;
            radioGeneral.Enabled = false;
            radioProject.Enabled = false;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlFocusonUpdate", "ddlFocusonUpdate();", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["VehAsgn"].ToString() != "")
        {
            objEntityVehicle.VehAsignId = Convert.ToInt32(Request.QueryString["VehAsgn"].ToString());

        }

        objEntityVehicle.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        if (radioProject.Checked == true)
        {
            objEntityVehicle.AssignMode = 1;
            objEntityVehicle.AssignedToPrjct = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);

        }
        if (radioEmployee.Checked == true)
        {
            objEntityVehicle.AssignMode = 2;
            objEntityVehicle.AssignedToUser = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);
        }
        if (radioGeneral.Checked == true)
        {
            objEntityVehicle.AssignMode = 3;
        }
        objEntityVehicle.VehicleStsTyp = 1;
        objEntityVehicle.VehicleSts = 1;

        if (txtFromDate.Text.Trim() != "")
        {
            objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text.Trim() != "")
        {
            objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }
        objBusinessVehicle.UpdateAssignVehicle(objEntityVehicle);
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {
            // string strVeh = hiddenRedirect.Value.ToString();
            Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "&InsUpd=UpdAsign");
        }
        else
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=UpdAsign");
        }


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