using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AWMS_AWMS_Master_gen_Employee_Off_duty_gen_Employee_Off_duty : System.Web.UI.Page
{
    string[] mnthlydetailsidlist ;
    protected void Page_Load(object sender, EventArgs e)
    {
        mnthlydetailsidlist = new string[50];
      
        DataTable dtoffduty;

        if (!IsPostBack)
        {
            BindDropdown();
            hiddensavemonthly.Value = "No";
            hiddenupdate.Value = "No";
            hiddenweeklydataforload.Value = "";

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
    
            clsBusinessLayerDutyOff objbusDuty = new clsBusinessLayerDutyOff();
            clsEntityLayerDutyOff objEntDuty = new clsEntityLayerDutyOff();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
          
            
            
            
            int intUserId = 0;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntDuty.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                objEntDuty.Inserteduserid = Convert.ToInt32(Session["USERID"].ToString());
      
            }
            else if(Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
                 if (Session["CORPOFFICEID"] != null)
            {
                objEntDuty.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntDuty.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
           
            
            dtoffduty= objbusDuty.getdutyoff(objEntDuty);
           if (dtoffduty.Rows.Count > 0)
           {
               saveOffduty.Text = "Update";
               if (dtoffduty.Rows[0]["OFFDUTYID"] != DBNull.Value)
               {
                   HiddenFieldid.Value = dtoffduty.Rows[0]["OFFDUTYID"].ToString();
               }
               hiddensavemonthly.Value = "Yes";
               hiddenupdate.Value = "Yes";
             //  saveOffduty.Enabled = false;
             hiddenweeklydataforload.Value = dtoffduty.Rows[0]["WEEK"].ToString();
             for (int i = 0; i < dtoffduty.Rows.Count; i++)
             {
                 if (dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString() != "")
                 {
                     if (dtoffduty.Rows[0]["OFFDUTYDTL_ID"] != DBNull.Value)
                     {
                         mnthlydetailsidlist[i] = (dtoffduty.Rows[0]["OFFDUTYDTL_ID"].ToString());
                     }
                     hiddenmonthlydataforload.Value = "yes";
                     if (i == 0)
                     {
                        // string strdefltcurrcy = (int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1).ToString();
                         hiddenmonthlydataforload1.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                      //   ddltype1.Items.FindByValue(strdefltcurrcy).Selected = true;
                         ddltype1.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                     else if (i == 1)
                     {
                         hiddenmonthlydataforload2.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                         ddltype2.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                     else if (i == 2)
                     {
                         hiddenmonthlydataforload3.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                         ddltype3.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                     else if (i == 3)
                     {
                         hiddenmonthlydataforload4.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                         ddltype4.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                     else if (i == 4)
                     {
                         hiddenmonthlydataforload5.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                         ddltype5.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                     else if (i == 5)
                     {
                         hiddenmonthlydataforload6.Value = dtoffduty.Rows[i]["OFFDUTYDTL_DAYS"].ToString();
                         ddltype6.SelectedIndex = int.Parse(dtoffduty.Rows[i]["MN_OFFDUTY_TYP_ID"].ToString()) - 1;
                     }
                 }
             }

           }
           else
           {
               saveOffduty.Text = "Save";
               hiddenweeklydataforload.Value = ""; 
           }
           

            

            // created object for business layer for compare the date

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    hiddenupdate.Value = "Yes";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
            }


        }

    }
    protected void saveOffduty_Click(object sender, EventArgs e)
    {
        string strDuplicationCount = "5";
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerDutyOff objbusDuty = new clsBusinessLayerDutyOff();
        clsEntityLayerDutyOff objEntDuty = new clsEntityLayerDutyOff();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        
   
        if (Session["CORPOFFICEID"] != null)
        {
            objEntDuty.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntDuty.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntDuty.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            objEntDuty.Inserteduserid = Convert.ToInt32(Session["USERID"].ToString());
            objEntDuty.Updatedteduserid = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtoffduty = objbusDuty.getdutyoff(objEntDuty);
          dtoffduty = objbusDuty.getdutyoff(objEntDuty);
        for (int i = 0; i < dtoffduty.Rows.Count; i++)
        {
            if (dtoffduty.Rows[0]["OFFDUTYDTL_ID"] != DBNull.Value)
            {
                mnthlydetailsidlist[i] = (dtoffduty.Rows[i]["OFFDUTYDTL_ID"].ToString());
            }
        }

        objEntDuty.Insertedteduserdate = objCommon.textToDateTime(hiddenCurrentDate.Value);
        // objEntDuty.Updatedteduserid = 0;
        objEntDuty.Updateddate = objCommon.textToDateTime(hiddenCurrentDate.Value);
    








        if(hiddenupdate.Value=="No")
        {
        //Checking is there table have any name like this
        // strNameCount = objbusDuty.CheckDutyTitle(objEntDuty);
        //If there is no name like this on table.    
        //if (strNameCount == "0" && strprocesscount == "0")
        //{
        if (hiddensaveweekly.Value.ToString() == "Yes")
        {
            objEntDuty.OffdutyDays = "";
            objEntDuty.MonthlyOffdutyId = 0;
            objEntDuty.weeklyOffdutytypeid = 1;
            objEntDuty.weeklyOffdutydays = hiddenweeklydata.Value;

            objEntDuty.WeeklyOffdutyStatus = 1;
        }
        else//ADDED 10-5
        {
            objEntDuty.OffdutyDays = "";
            objEntDuty.MonthlyOffdutyId = 0;
            objEntDuty.weeklyOffdutytypeid = 1;
            objEntDuty.weeklyOffdutydays = "";

            objEntDuty.WeeklyOffdutyStatus = 1;
        }

        if (hiddensavemonthly.Value.ToString() == "Yes")
        {
            var dropvalues = hiddenmonthlydata.Value;
            objEntDuty.MonthlyOffdutyId = 1;
            objEntDuty.MnthlyOffdutyStatus = 1;
            objEntDuty.MnthlyOffdutyTypename = "";
            objEntDuty.OffdutyDays = "";

            string []monthlydatarray=new string[10];
            monthlydatarray[0] = hiddenmonthlydata1.Value;
            monthlydatarray[1] = hiddenmonthlydata2.Value;

            monthlydatarray[2] = hiddenmonthlydata3.Value;
            monthlydatarray[3] = hiddenmonthlydata4.Value;
            monthlydatarray[4] = hiddenmonthlydata5.Value;

            monthlydatarray[5] = hiddenmonthlydata6.Value;

            objEntDuty.monthlydatalist = monthlydatarray;
           // string[] ab= new string[10];

            string[] values = dropvalues.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
            objEntDuty.monthlytypelist = values;
           // objEntDuty.WeeklyOffdutyStatus = 1;


        }
        else if (hiddensavemonthly.Value.ToString() == "No")
        {
            objEntDuty.MonthlyOffdutyId = 0;
            //objEntDuty.MnthlyOffdutyStatus = 0;
            //objEntDuty.MnthlyOffdutyTypename = "";
            var dropvalues = hiddenmonthlydata.Value;
            objEntDuty.MonthlyOffdutyId = 1;
            objEntDuty.MnthlyOffdutyStatus = 1;
            objEntDuty.MnthlyOffdutyTypename = "";
            objEntDuty.OffdutyDays = "";

            string[] monthlydatarray = new string[10];
            monthlydatarray[0] = "";
            monthlydatarray[1] = "";

            monthlydatarray[2] = "";
            monthlydatarray[3] = "";
            monthlydatarray[4] = "";

            monthlydatarray[5] = "";

            objEntDuty.monthlydatalist = monthlydatarray;
            // string[] ab= new string[10];

            string[] values = dropvalues.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
            objEntDuty.monthlytypelist = values;
      


        }
        objEntDuty.OffdutyStatus = 1;
        objbusDuty.AddDutyOffDetails(objEntDuty);

        if (clickedButton.ID == "saveOffduty")
        {
            Response.Redirect("gen_Employee_Off_duty.aspx?InsUpd=Ins");
        }
            
        }
        else if (hiddenupdate.Value == "Yes")
        {


            if (hiddensaveweekly.Value.ToString() == "Yes")
            {
                objEntDuty.OffdutyDays = "";
                objEntDuty.MonthlyOffdutyId = 0;
                objEntDuty.weeklyOffdutytypeid = 1;
                objEntDuty.weeklyOffdutydays = hiddenweeklydata.Value;

                objEntDuty.WeeklyOffdutyStatus = 1;


            }
            else
            {

            }

            if (hiddensavemonthly.Value.ToString() == "Yes")
            {
                var dropvalues = hiddenmonthlydata.Value;
                objEntDuty.MonthlyOffdutyId = 1;
                objEntDuty.MnthlyOffdutyStatus = 1;
                objEntDuty.MnthlyOffdutyTypename = "";
                objEntDuty.OffdutyDays = "";

                string[] monthlydatarray = new string[10];
                monthlydatarray[0] = hiddenmonthlydata1.Value;


                monthlydatarray[1] = hiddenmonthlydata2.Value;

                monthlydatarray[2] = hiddenmonthlydata3.Value;
                monthlydatarray[3] = hiddenmonthlydata4.Value;
                monthlydatarray[4] = hiddenmonthlydata5.Value;

                monthlydatarray[5] = hiddenmonthlydata6.Value;

                objEntDuty.monthlydatalist = monthlydatarray;
               // string[] ab = new string[10];

                string[] values = dropvalues.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }


                //checking the duplicated data 
                 strDuplicationCount = "0";
                 for (int i = 0; i < 6; i++)
                 {
                     if (monthlydatarray[i] != null)
                     {
                         objEntDuty.monthlydetailid[i] = mnthlydetailsidlist[i];

                         objEntDuty.OffdutyId = Int32.Parse(HiddenFieldid.Value);
                         objEntDuty.MonthlyOffdutyId = int.Parse(values[i]);

                         objEntDuty.OffdutyDays = monthlydatarray[i];


                   //     strDuplicationCount = objbusDuty.CheckDuplication(objEntDuty);
                         if (strDuplicationCount != "0")
                         {
                             ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                         }
                     }

                 }

                objEntDuty.monthlytypelist = values;
                // objEntDuty.WeeklyOffdutyStatus = 1;
          
                objEntDuty.OffdutyId = Int32.Parse(HiddenFieldid.Value);
            }
            else if (hiddensavemonthly.Value.ToString() == "No")
            {
                objEntDuty.MonthlyOffdutyId = 0;
                //objEntDuty.MnthlyOffdutyStatus = 0;
                //objEntDuty.MnthlyOffdutyTypename = "";



            }
            //if (strDuplicationCount == "0")
          //  {
                objEntDuty.OffdutyStatus = 1;
                objEntDuty.weeklyOffdutydays = hiddenweeklydata.Value;
                // objEntDuty.User_Id = 0;
                objbusDuty.updatemnthlyoffdetails(objEntDuty);
              //  Response.Redirect(Request.RawUrl);

                if (clickedButton.ID == "saveOffduty")
                {
                    Response.Redirect("gen_Employee_Off_duty.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Employee_Off_duty.aspx?InsUpd=Upd");
                }

         //   }
         //   else
        //    {
         //       if (strDuplicationCount != "0")
           //     {
                  //  ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            //   }

           // }
        
        }

    }

    protected void BindDropdown()
    {

        clsBusinessLayerDutyOff objbusDuty1 = new clsBusinessLayerDutyOff();
      DataTable dt=  objbusDuty1.getmonthlytype();

      ddltype1.DataSource = dt;
      ddltype2.DataSource = dt;
      ddltype3.DataSource = dt;

      ddltype4.DataSource = dt;
      ddltype5.DataSource = dt;
      ddltype6.DataSource = dt;

      ddltype1.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype1.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype1.DataBind();
      ddltype2.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype2.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype2.DataBind();
      ddltype3.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype3.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype3.DataBind();
      ddltype4.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype4.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype4.DataBind();
      ddltype5.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype5.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype5.DataBind();
      ddltype6.DataTextField = "MN_OFFDUTY_TYP_NAME";
      ddltype6.DataValueField = "MN_OFFDUTY_TYP_ID";
      ddltype6.DataBind();


             
    }
}