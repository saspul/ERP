using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_WPS_List_WPS_List : System.Web.UI.Page
{
    string filepath="";
    protected void Page_Load(object sender, EventArgs e)
    {
        
       if (Session["fileName"] != null)
       {
         
           filepath=Session["fileName"].ToString();

       }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strImagePath;
        try {
                Response.ContentType = "csv";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WPS_LIST);
                Response.AddHeader("content-Disposition", "attachment;filename=\""+filepath+"\"");
                Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
                Response.End();
                if (File.Exists(MapPath(strImagePath) + filepath))
                {
                    File.Delete(MapPath(strImagePath) + filepath);
                }
               
            }
            catch (Exception)
            {
              
            }
        } 
}