using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Configuration;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
//using System.Text.str

/// <summary>
/// Summary description for HelpDocWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]


public class HelpDocWebService : System.Web.Services.WebService {

    public HelpDocWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetUserRolByURL(string strURL, string strFullURL, string StrSearchString)
    {
        clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
        clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();
        ObjEntityHelpDoc.PageURL = strURL;
        ObjEntityHelpDoc.FullPageURL = strFullURL;
        ObjEntityHelpDoc.SearchString = StrSearchString;
       // ObjEntityHelpDoc
        DataTable dtGetUserRollByURL = objBusinessLayerHelpDoc.ReadUserRollByURL(ObjEntityHelpDoc);
        DataTable dtMainMenu;

        List<string> mainmenu = new List<string>();

        if (dtGetUserRollByURL.Rows.Count > 0)
        {
            if (dtGetUserRollByURL.Rows[0]["PRTZAPP_ID"].ToString() != "")
            {

                ObjEntityHelpDoc.AppId = Convert.ToInt32(dtGetUserRollByURL.Rows[0]["PRTZAPP_ID"].ToString());              
                dtMainMenu = objBusinessLayerHelpDoc.ReadMainUserRolsByAppId(ObjEntityHelpDoc);

                if (dtMainMenu.Rows.Count > 0)
                {
                    foreach(DataRow row in dtMainMenu.Rows)
                    {
                        mainmenu.Add(string.Format("{0}-{1}", row["USROL_NAME"], row["USROL_ID"]));
                    }
                }
            }
        }
        else
        {
            mainmenu.Add("MainMenuNotExist");
        }

        return mainmenu.ToArray();
    }


    [WebMethod]
    public string[] GetUserRolsByUserRolId(string ParentId, string StrSearchString)
    {
        clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
        clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

        ObjEntityHelpDoc.UserRolId = Convert.ToInt32(ParentId);
        ObjEntityHelpDoc.SearchString = StrSearchString;
        DataTable dtGetSubUserRols = objBusinessLayerHelpDoc.ReadUserRolsByUserRolId(ObjEntityHelpDoc);

        List<string> mainmenu = new List<string>();

        if (dtGetSubUserRols.Rows.Count > 0)
        {
            foreach (DataRow row in dtGetSubUserRols.Rows)
            {
                mainmenu.Add(string.Format("{0}-{1}", row["USROL_NAME"], row["USROL_ID"]));
            }
        }
        else
        {
            mainmenu.Add("SubMenuNotExist");
        }

        return mainmenu.ToArray();
    }

    [WebMethod]
    public string[] GetSectionsByURL(string strURL, string strFullURL, string StrSearchString)
    {
        clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
        clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();
        ObjEntityHelpDoc.PageURL = strURL;
        ObjEntityHelpDoc.FullPageURL = strFullURL;
        ObjEntityHelpDoc.SearchString = StrSearchString;
        List<string> sectionmenu = new List<string>();

        DataTable dtGetSections = objBusinessLayerHelpDoc.ReadSectionsByURL(ObjEntityHelpDoc);

        if (dtGetSections.Rows.Count > 0)
        {
            foreach (DataRow row in dtGetSections.Rows)
            {
                sectionmenu.Add(string.Format("{0}-{1}", row["HELPDOC_REF_SECTIO_NAME"], row["HELPDOC_SECTION_ID"]));
            }
        }

        return sectionmenu.ToArray();
    }


    [WebMethod]
    public string SaveHelpDoc(string SectionName, string MainMenu, string SubMenu, string Title, string Priority, string Status, string Description, string UserId, string SectionId, string ControlName, string BtnSaveMode)
    {
        clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
        clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

        ObjEntityHelpDoc.ParentSectionId = 0;
        if (SubMenu != "")
        {
            ObjEntityHelpDoc.UserRolId = Convert.ToInt32(SubMenu);
        }
        else if (MainMenu!="")
        {
            ObjEntityHelpDoc.UserRolId = Convert.ToInt32(MainMenu);
        }


        if (Status != "")
        {
            ObjEntityHelpDoc.Status = Convert.ToInt32(Status);
        }
        if (Priority != "")
        {
            ObjEntityHelpDoc.Priority = Convert.ToInt32(Priority);
        }
        if (UserId != "")
        {
            ObjEntityHelpDoc.UserId = Convert.ToInt32(UserId);
        }

        ObjEntityHelpDoc.SectionName = SectionName;
        ObjEntityHelpDoc.Title = Title;
        ObjEntityHelpDoc.Description = Description;
        if (SectionId != "")
        {
            ObjEntityHelpDoc.SectionId = Convert.ToInt32(SectionId);
        }

        if (BtnSaveMode == "btnSaveMain")
        {
            ObjEntityHelpDoc.HelpDocType = 0;
        }

        else if (BtnSaveMode == "btnSaveControl")
        {
            ObjEntityHelpDoc.ControlId = ControlName;
            ObjEntityHelpDoc.HelpDocType = 1;
        }

        else if (BtnSaveMode == "btnSaveSub")
        {
            ObjEntityHelpDoc.HelpDocType = 2;
        }

        ObjEntityHelpDoc.ActionMode = BtnSaveMode;

        objBusinessLayerHelpDoc.SaveHelpDoc(ObjEntityHelpDoc);

        return "";  
    }

     [WebMethod]
    public string[] EditView(string strURL,string strFullURL, string Mode,string ControlId)
    {
        clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
        clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();
        ObjEntityHelpDoc.PageURL = strURL;
        ObjEntityHelpDoc.FullPageURL = strFullURL;
        if (Mode == "MainSection")
        {
            ObjEntityHelpDoc.HelpDocType = 0;
        }
        else if (Mode == "ControlSection")
        {
            ObjEntityHelpDoc.HelpDocType = 1;
            ObjEntityHelpDoc.ControlId = ControlId;

        }
        List<string> editview = new List<string>();
        DataTable dtGetSections = new DataTable();

        if (Mode != "SubSection")
        {
            dtGetSections = objBusinessLayerHelpDoc.ReadEditView(ObjEntityHelpDoc);
        }
        
         

        if (dtGetSections.Rows.Count > 0)
        {
            editview.Add("EditView");
            editview.Add(dtGetSections.Rows[0]["HELPDOC_REF_SECTIO_NAME"].ToString());
            editview.Add(dtGetSections.Rows[0]["PARENT_USROL_NAME"].ToString());
            editview.Add(dtGetSections.Rows[0]["USROL_NAME"].ToString());

            editview.Add(dtGetSections.Rows[0]["HELPDOC_DTLS_TITLE"].ToString());
            if (Mode ==  "MainSection")
            {
                editview.Add(dtGetSections.Rows[0]["HELPDOC_PRIORITY"].ToString());
            }
            if (Mode == "ControlSection")
            {
                editview.Add(dtGetSections.Rows[0]["HELPDOC_DTLS_PRIORITY"].ToString());
            }
            editview.Add(dtGetSections.Rows[0]["HELPDOC_STATUS"].ToString());
            editview.Add(dtGetSections.Rows[0]["HELPDOC_DTLS_DESCRIPTION"].ToString());

            editview.Add(dtGetSections.Rows[0]["PARENT_USROL_ID"].ToString());
            editview.Add(dtGetSections.Rows[0]["HELPDOC_USROL_ID"].ToString());
            editview.Add(dtGetSections.Rows[0]["HELPDOC_SECTION_ID"].ToString());
            editview.Add(dtGetSections.Rows[0]["HELPDOC_DTLS_ID"].ToString());
        }
        else
        {
            editview.Add("AddView");
        }

        return editview.ToArray();
    }

     [WebMethod]
     public string UpdateHelpDoc(string SectionName, string MainMenu, string SubMenu, string Title, string Priority, string Status, string Description, string UserId, string SectionId, string ControlName,string DocDtlId, string BtnUpdateMode)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         ObjEntityHelpDoc.ParentSectionId = 0;
         if (SubMenu != "")
         {
             ObjEntityHelpDoc.UserRolId = Convert.ToInt32(SubMenu);
         }
         else if (MainMenu != "")
         {
             ObjEntityHelpDoc.UserRolId = Convert.ToInt32(MainMenu);
         }

         if (Status != "")
         {
             ObjEntityHelpDoc.Status = Convert.ToInt32(Status);
         }
         if (Priority != "")
         {
             ObjEntityHelpDoc.Priority = Convert.ToInt32(Priority);
         }
         if (UserId != "")
         {
             ObjEntityHelpDoc.UserId = Convert.ToInt32(UserId);
         }

         if (DocDtlId != "")
         {
             ObjEntityHelpDoc.HelpDocDtlsId = Convert.ToInt32(DocDtlId);
         }

         
         ObjEntityHelpDoc.SectionName = SectionName;
         ObjEntityHelpDoc.Title = Title;
         ObjEntityHelpDoc.Description = Description;
         if (SectionId != "")
         {
             ObjEntityHelpDoc.SectionId = Convert.ToInt32(SectionId);
         }

         if (BtnUpdateMode == "btnUpdateMain")
         {
             ObjEntityHelpDoc.HelpDocType = 0;
         }

         else if (BtnUpdateMode == "btnUpdateControl")
         {
             ObjEntityHelpDoc.ControlId = ControlName;
             ObjEntityHelpDoc.HelpDocType = 1;
         }

         else if (BtnUpdateMode == "btnUpdateSub")
         {
             ObjEntityHelpDoc.HelpDocType = 2;
         }

         ObjEntityHelpDoc.ActionMode = BtnUpdateMode;

         objBusinessLayerHelpDoc.UpdateHelpDoc(ObjEntityHelpDoc);

         return "";
     }

     public class clsCurrentPageControls
     {
         public string SectionId { get; set; }
         public string Control { get; set; }
     }

     [WebMethod]
     public string GetCurrentPageControls(string strURL, string strFullURL)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         ObjEntityHelpDoc.PageURL = strURL;
         ObjEntityHelpDoc.FullPageURL = strFullURL;

         DataTable dtGetCurrentPageControls = objBusinessLayerHelpDoc.ReadCurrentPageControls(ObjEntityHelpDoc);
         string strJsonControls = DataTableToJSONWithJavaScriptSerializer(dtGetCurrentPageControls);

         return strJsonControls;
     }


     [WebMethod]
     public string GetControlDescription(string SectionId, string ControlId)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         ObjEntityHelpDoc.SectionId = Convert.ToInt32(SectionId);
         ObjEntityHelpDoc.ControlId = ControlId;

         DataTable dtGetCurrentPageControls = objBusinessLayerHelpDoc.ReadControlsDescription(ObjEntityHelpDoc);
         string strDesccptn = "";
         if (dtGetCurrentPageControls.Rows.Count > 0)
         {
             strDesccptn = dtGetCurrentPageControls.Rows[0]["HELPDOC_DTLS_DESCRIPTION"].ToString();
         }

         return strDesccptn;
     }

     public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
     {
         JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
         List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
         Dictionary<string, object> childRow;
         foreach (DataRow row in table.Rows)
         {
             childRow = new Dictionary<string, object>();
             foreach (DataColumn col in table.Columns)
             {
                 childRow.Add(col.ColumnName, row[col]);
             }
             parentRow.Add(childRow);
         }
         return jsSerializer.Serialize(parentRow);
     }


     /*Section Class*/
     public class ParantSection
     {
         public int Id { get; set; }
         public string MainTitle { get; set; }
         public int SectionId { get; set; }
     }

     public class ChildSection
     {
         public int Id { get; set; }
         public string SubTitle { get; set; }
         public int ParentId { get; set; }
     }

     [WebMethod]
     public string[] GetAppIdUserRolId(string strURL, string strFullURL)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         ObjEntityHelpDoc.PageURL = strURL;
         ObjEntityHelpDoc.FullPageURL = strFullURL;

         DataTable dtAppIdUserRolId = objBusinessLayerHelpDoc.ReadAppIdUserRolId(ObjEntityHelpDoc);
         List<string> list = new List<string>();

         if (dtAppIdUserRolId.Rows.Count > 0)
         {
             list.Add(dtAppIdUserRolId.Rows[0]["PRTZAPP_ID"].ToString());
             list.Add(dtAppIdUserRolId.Rows[0]["HELPDOC_SECTION_ID"].ToString());
             list.Add(dtAppIdUserRolId.Rows[0]["HELPDOC_USROL_ID"].ToString());
         }
         return list.ToArray();
     }
    

     [WebMethod]
     public string GetSections(string strAppId)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         if (strAppId != "")
         {
             ObjEntityHelpDoc.AppId = Convert.ToInt32(strAppId);
         }

         StringBuilder sbHelpDoc = new StringBuilder();

         DataTable dtHelpDocSections = new DataTable();
         dtHelpDocSections = objBusinessLayerHelpDoc.ReadHelpCenterSections(ObjEntityHelpDoc);

         List<ParantSection> objpmenu = new List<ParantSection>();
         List<ChildSection> objcmenu = new List<ChildSection>();

         if (dtHelpDocSections.Rows.Count > 0)
         {
             for (int i = 0; i < dtHelpDocSections.Rows.Count; i++)
             {
                 if (dtHelpDocSections.Rows[i]["HELPDOC_DTLS_TYPE"].ToString() == "0")
                 {
                     objpmenu.Add(new ParantSection { Id = Convert.ToInt32(dtHelpDocSections.Rows[i]["HELPDOC_DTLS_ID"]), MainTitle = dtHelpDocSections.Rows[i]["HELPDOC_DTLS_TITLE"].ToString(), SectionId = Convert.ToInt32(dtHelpDocSections.Rows[i]["HELPDOC_SECTION_ID"]) });
                 }
                 else                 
                 {
                     objcmenu.Add(new ChildSection { Id = Convert.ToInt32(dtHelpDocSections.Rows[i]["HELPDOC_DTLS_ID"]), SubTitle = dtHelpDocSections.Rows[i]["HELPDOC_DTLS_TITLE"].ToString(), ParentId = Convert.ToInt32(dtHelpDocSections.Rows[i]["HELPDOC_SECTION_ID"]) });
                 }
             }
         }


         foreach (ParantSection _pitem in objpmenu)
         {
             var childitem = objcmenu.Where(m => m.ParentId == _pitem.SectionId).ToList();

             if (childitem.Count > 0)
             {
             }
             else
             {
             }

         }



         return "";
     }

     [WebMethod]
     public string GetSectionDetails(string strSectionId, string strControlId)
     {
         clsEntityHelpDoc ObjEntityHelpDoc = new clsEntityHelpDoc();
         clsBusinessLayerHelpDoc objBusinessLayerHelpDoc = new clsBusinessLayerHelpDoc();

         if (strSectionId != "")
         {
             ObjEntityHelpDoc.SectionId = Convert.ToInt32(strSectionId);
         }
         if (strControlId != "")
         {
             ObjEntityHelpDoc.ControlId = strControlId;
         }

         DataTable dtHelpDocSectionDtls = objBusinessLayerHelpDoc.ReadHelpCenterDetails(ObjEntityHelpDoc);



         if (dtHelpDocSectionDtls.Rows.Count > 0)
         {

         }


         return "";
     }



}
