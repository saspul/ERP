using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;

public partial class MasterPage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "1";

        if (!IsPostBack)
        {
            int intUserId = 0;
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
            //Getting UserolMstrId for User

            DataTable dtUserRolMstrDtl = objBusinessLayer.LoadUserRolMstrIdByUserId(intUserId);
            string strHtm = ConvertDataTableToList(dtUserRolMstrDtl);
            //Write to divReport
            divRightList.InnerHtml = strHtm;

            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;
                if (Session["CORPOFFICEID"] != null)
                {
                    clsBusinessLayer objBusiness = new clsBusinessLayer();
                    DataTable dtCorpDetail = new DataTable();

                    int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorppId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        if (dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }

                clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
                objEntLogin.CorpOfficeId = Convert.ToInt32(strId);
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtCorpName = new DataTable();
                dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);


                if (dtCorpName.Rows.Count > 0)
                {
                    Session["CORPORATENAME"] = dtCorpName.Rows[0]["CORPRT_NAME"].ToString();
                }
            }
        }
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToList(DataTable dt)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();



        StringBuilder sb = new StringBuilder();
        string strHtml = "<div class=\"ullis_new\" >";
        strHtml += "<ul class=\"bg_ul_new\">";


        //add rows
        int intLiClassIncrement = 1;

        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
        {
            int intUsrRolMstrId = Convert.ToInt32(dt.Rows[intRowCount]["USROL_ID"].ToString());
            string strUsrRoleURL = dt.Rows[intRowCount]["USROL_URL"].ToString();

            if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Organisation_Type))
            {	//<li class="li_1"><a href="" class="a_1">Organization Types</a></li>
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_1\"> Organization Types</a></li>";
                intLiClassIncrement++;

            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.OrganisationVerification))
            {
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_2\">Organization Verification</a></li>";
                intLiClassIncrement++;
            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Corporate_Office))
            {
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_4\">Corporate Definition</a></li>";
                intLiClassIncrement++;

            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Corporate_Department))
            {
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_5\">Corporate Department</a></li>";
                intLiClassIncrement++;
            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Premise))
            {
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_6\">Premise Definition</a></li>";
                intLiClassIncrement++;
            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.WorkArea))
            {
                string strClass = "li_" + intLiClassIncrement;

                strHtml += "<li class=" + strClass + " ><a href=" + strUsrRoleURL + " class=\"a_7\">Premise-Area Definition</a></li>";
                intLiClassIncrement++;
            }

            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Country_Master))
            {
                AncrImageCountry.Visible = true;


            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Corporate_Pack))
            {
                AncrImageCorp.Visible = true;


            }
            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Licence_Pack))
            {
                AncrImageLic.Visible = true;


            }

            else if (intUsrRolMstrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.WorkStationMastr))
            {
                AncrImageWorkstn.Visible = true;


            }



        }

        strHtml += "</ul>";

        strHtml += "</div>";



        sb.Append(strHtml);
        return sb.ToString();
    }
}