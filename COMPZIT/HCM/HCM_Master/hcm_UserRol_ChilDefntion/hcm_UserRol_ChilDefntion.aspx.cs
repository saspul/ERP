using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;


// CREATED BY:EVM-0008
// CREATED DATE:02/07/2018
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_UserRol_ChilDefntion_hcm_UserRol_ChilDefntion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HiddenChbxUserid.Value = "0";
            int intCorpId = 0, intOrgId = 0, intUserId=0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);


            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

          
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
            clsEntity_UserRol_ChilDefntion objEntity = new clsEntity_UserRol_ChilDefntion();
            objEntity.CorpOffice = intCorpId;
            objEntity.Orgid = intOrgId;
            objEntity.UserId = intUserId;
            objEntity.ChildRole = 7;
            HiddenChildRole.Value = "7";

            DataTable dtEmp = objUserRol.ReadEmployeOnLeave(objEntity);
            DataTable dtDistinctList = RemoveDuplicateRows(dtEmp, "USR_ID");
            HiddenRowCount.Value = dtDistinctList.Rows.Count.ToString();


            string STR = ConvertDataTableToHTML(dtDistinctList, HiddenChildRole.Value);
          divlistview.InnerHtml = STR;

          DataTable dtUsers = objUserRol.ReadEmployee(objEntity);
          LoadUserddl(dtUsers);
            //if (dtEmp.Rows.Count > 0)
            //{
                //foreach(DataRow Dr in dtEmp.Rows)
                //{
                //    string[] strArrEmpRole = Dr["USRROL_CHLDRL_DEFN"].ToString().Split(',');
                //    foreach (string strItem in strArrEmpRole)
                //{
                   
                //}
                //}

           // }

        }
    }
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    public void LoadUserddl(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlUSers.DataSource = dt;
            ddlUSers.DataTextField = "USR_NAME";
            ddlUSers.DataValueField = "USR_ID";
            ddlUSers.DataBind();

        }
        ddlUSers.ClearSelection();
        ddlUSers.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    public string ConvertDataTableToHTML(DataTable dt,string HiddenChildRole)
    {

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
      
   

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }


        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";



        strHtml += "<tr >";



        int intCnclUsrId = 0;
        int intReCallForTAble = 0;



        //for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        //{

        strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align: center;\"> <label class=\"checkbox\"style=\"margin-bottom: 13%;\" ><input type=\"checkbox\" title=\"SELECT ALL\"  onchange='return changeAll();'   onkeypress='return DisableEnter(event)'  id=\"cbMandatory\"><i  style=\"margin-left: 31%;margin-top: -31%;\"></i></label>";

                strHtml += "<th class=\"hasinput\" style=\"width:90%\">EMPLOYEE";



       // }


        //strHtml += "</th >";

        //strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        Decimal Arrearamount = 0;
        int rowcount = dt.Rows.Count;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

            clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
            clsEntity_UserRol_ChilDefntion objUserEntity = new clsEntity_UserRol_ChilDefntion();




            objUserEntity.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());
            DataTable dtUserRolProv = objUserRol.ReadUserRolProvsn(objUserEntity);
            string UserName = "";
          //  DataTable dtUsers = objUserRol.ReadEmployee(objUserEntity);
            if (dtUserRolProv.Rows.Count > 0)
            {
                foreach (DataRow Dr in dtUserRolProv.Rows)
                {
                    if (HiddenChildRole == Dr["CHILDROL_NUM"].ToString())
                    {
                        objUserEntity.ChildRole = Convert.ToInt32(Dr["CHILDROL_NUM"].ToString());
                        objUserEntity.AssgnUserid = Convert.ToInt32(Dr["USR_ID"].ToString());
                        objUserEntity.AssgnUsrRol = Convert.ToInt32(Dr["USROL_ID"].ToString());
                        objUserEntity.AssgnTempSts = Convert.ToInt32(Dr["CHILDROL_TEMP_STS"].ToString());
                         UserName = Dr["USR_NAME"].ToString();
                    }
                   
                }

            }



            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" onkeypress='return DisableEnter(event)'  onchange=\"return changeSingle('" + objUserEntity.AssgnUserid + "','" + intRowBodyCount + "','" + objUserEntity.ChildRole + "','" + UserName + "');\"  value=\"" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" id=\"cbMandatory" + intRowBodyCount + "\"><i  style=\"margin-left: 30%;\"></i></label></td>";


        strHtml += "<td class=\"tdT\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
       // string ID = dt.Rows[intRowBodyCount]["USERASSGNID"].ToString();
        strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + objUserEntity.AssgnUserid + "\" name=\"AssgnUserid" + intRowBodyCount + "\" id=\"AssgnUserid" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
        strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"       value=\"" + objUserEntity.AssgnUsrRol + "\" name=\"AssgnUserRol" + intRowBodyCount + "\" id=\"AssgnUserRol" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
        strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"       value=\"" + objUserEntity.AssgnTempSts + "\" name=\"AssgnTempSts" + intRowBodyCount + "\" id=\"AssgnTempSts" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
         
            strHtml += "</tr>";
        }
        if (rowcount == 0)
        {
           // strHtml += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >  </td>";
            strHtml += "<td class=\"tdT\" colspan=\"2\"  style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: center;\" > No data available in table </td>";
           
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string[] LoadChildRol(string intChildRl, string intuserid, string intorgid, string intcorpid)
    {
        string[] Res = new string[5];
        HCM_HCM_Master_hcm_UserRol_ChilDefntion_hcm_UserRol_ChilDefntion objRoles = new HCM_HCM_Master_hcm_UserRol_ChilDefntion_hcm_UserRol_ChilDefntion();
        clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
        clsEntity_UserRol_ChilDefntion objEntity = new clsEntity_UserRol_ChilDefntion();
        objEntity.ChildRole =Convert.ToInt32(intChildRl);
        objEntity.CorpOffice = Convert.ToInt32(intcorpid);
        objEntity.Orgid = Convert.ToInt32(intorgid);
        objEntity.UserId = Convert.ToInt32(intuserid);
        DataTable dtEmp = objUserRol.ReadEmployeOnLeave(objEntity);
        DataTable dtDistinctList = objRoles.RemoveDuplicateRows(dtEmp, "USR_ID");
        string STR = objRoles.ConvertDataTableToHTML(dtDistinctList, intChildRl);

        Res[0] = STR;
        Res[1] = dtDistinctList.Rows.Count.ToString();
        return Res;
    }
    protected void butnprsstemp_Click(object sender, EventArgs e)
    {
        //Session["SALARPRSS"] = null;
        int intOrgId = 0;

        clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
        clsEntity_UserRol_ChilDefntion objUserEntity = new clsEntity_UserRol_ChilDefntion();
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objUserEntity.Orgid = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objUserEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objUserEntity.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

      //  objUserEntity.Employeeid = Convert.ToInt32(ddlUSers.SelectedItem.Value);
      
      
        List<clsEntity_UserRol_ChilDefntion> objEmpList = new List<clsEntity_UserRol_ChilDefntion>();

        string[] empChecked = HiddenEmployeeId.Value.Split(',');
        string[] empCheckedAssgnUser = HiddenAssgnUsrID.Value.Split(',');
        string[] empCheckedAssgnUserRol = HiddenAssgnUSrRol.Value.Split('|');
        string[] empCheckedAssgnUserTemp = HiddenAssgnTempSts.Value.Split(',');
        int arrid = 0;
        foreach (string EachEmp in empChecked)
        {
            if (EachEmp != "" && EachEmp != null)
            {
                clsEntity_UserRol_ChilDefntion objEntity = new clsEntity_UserRol_ChilDefntion();
                objEntity.CorpOffice=  objUserEntity.CorpOffice;
                objEntity.Orgid=objUserEntity.Orgid;
                         

                objEntity.UserId = Convert.ToInt32(ddlUSers.SelectedItem.Value);
                objEntity.Employeeid = Convert.ToInt32(EachEmp);
                objEntity.ChildRole=Convert.ToInt32(HiddenChildRole.Value);
                if (empCheckedAssgnUser[arrid] != "")
                {
                    if (objEntity.UserId.ToString() != empCheckedAssgnUser[arrid])
                    {
                        objEntity.AssgnUserid = Convert.ToInt32(empCheckedAssgnUser[arrid]);
                        objEntity.AssgnUsrRol = Convert.ToInt32(empCheckedAssgnUserRol[arrid]);
                         objEntity.AssgnTempSts = Convert.ToInt32(empCheckedAssgnUserTemp[arrid]);
                        objUserRol.UserRolesDeleteByAssgnUserid(objEntity);
                    }
                }


               
                DataTable dtChildRoldetls = objUserRol.UserRolesDetails(objEntity);
                if (dtChildRoldetls.Rows.Count > 0)
                {
                    foreach (DataRow Dr in dtChildRoldetls.Rows)
                    {

                        objEntity.UserRoleid = Convert.ToInt32(Dr["USROL_ID"].ToString());
                        DataTable dtUserRoledtls = objUserRol.UserRolesDtlsAsssingnedUser(objEntity);
                        if (dtUserRoledtls.Rows.Count > 0)
                        {
                            objEntity.InsUpdSta = 1;
                            //if (dtUserRoledtls.Rows[0]["USRROL_CHLDRL_DEFN"].ToString() != "")
                            //{
                                string[] strArrEmpRole = dtUserRoledtls.Rows[0]["USRROL_CHLDRL_DEFN"].ToString().Split('-');
                                string value = objEntity.ChildRole.ToString();
                                int pos = Array.IndexOf(strArrEmpRole, value);
                                if (pos == -1)
                                {
                                    objEntity.UserRolTempSts = 1;
                                }
                            //}

                        }
                        else
                        {
                            objEntity.UserRolTempSts = 1;
                        }
                        if (objEntity.UserRol == "")
                        {
                            objEntity.UserRol = Dr["USROL_ID"].ToString();
                            objEntity.UserAppId = Dr["PRTZAPP_ID"].ToString();

                        }
                        else
                        {
                            objEntity.UserRol = objEntity.UserRol + "," + Dr["USROL_ID"].ToString();
                            objEntity.UserAppId = objEntity.UserAppId + "," + Dr["PRTZAPP_ID"].ToString();
                        }
                    }
                   
                }
                if (empCheckedAssgnUser[arrid] != "")
                {
                    if (objEntity.UserId.ToString() != empCheckedAssgnUser[arrid])
                    {
                        objEmpList.Add(objEntity);
                    }
                }
                arrid++;
            }
        }
      objUserRol.InsertChildRoles( objEmpList);
        Session["MESSGASSGNROL"] = "ROLE";
        Response.Redirect("hcm_UserRol_ChilDefntion.aspx");
    }
    //protected void btnRedirectAll_Click(object sender, EventArgs e)
    //{
    //    clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
    //    clsEntity_UserRol_ChilDefntion objUserEntity = new clsEntity_UserRol_ChilDefntion();
    //   objUserEntity.UserId=Convert.ToInt32(HiddenChbxUserid.Value);
    //   objUserEntity.ChildRole = Convert.ToInt32(HiddenChildRole.Value);
    //   DataTable dtUserRoledtls = objUserRol.ReadUserFromChildRolProvsn(objUserEntity);
    //   if (dtUserRoledtls.Rows.Count > 0)
    //   {
    //      int intUserid= Convert.ToInt32(dtUserRoledtls.Rows[0]["USR_ID"].ToString());
    //      ddlUSers.Items.FindByValue(dtUserRoledtls.Rows[0]["USR_ID"].ToString()).Selected = true;
    //   }
    //}
}