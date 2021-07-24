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

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Sts_Confirm_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           


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
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "CnFrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
            }

            GridLoad();
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

        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBussinessVhclSts.ReadStatusNotConfirmBydate(objEntityVhclSts);
        if (dtVehicleDetail.Rows.Count > 0)
        {
            GridVehiclePendingStatus.DataSource = dtVehicleDetail;
            GridVehiclePendingStatus.DataBind();
        }

    }
    protected void GridVehiclePendingStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridLoad();
        GridVehiclePendingStatus.PageIndex = e.NewPageIndex;
        GridVehiclePendingStatus.DataBind();
    }
}