using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ServiceInterviewPanel
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ServiceInterviewPanel : System.Web.Services.WebService {

    public ServiceInterviewPanel () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public static string AddInterViewPanel(int intCorpId, int intOrgId, int RqstId, int Temp, int TempDetail, List<string> TotalDetail)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        string success = "true";

        objEntityJobIntrvPanel.Organisation_Id = intOrgId;
        objEntityJobIntrvPanel.CorpOffice_Id = intCorpId;
        objEntityJobIntrvPanel.ManPwrRqstId = RqstId;
        objEntityJobIntrvPanel.TemplateId = Temp;

        List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlList = new List<clsEntityLayer_InterViewPanel_Dtl>();

        string jsonDataPanel = "";
        string a = jsonDataPanel.Replace("\"{", "\\{");
        string b = a.Replace("\\n", "\r\n");
        string c = b.Replace("\\", "");
        string d = c.Replace("}\"]", "}]");
        string k = d.Replace("}\",", "},");

        List<clsPanelData> objPanelData = new List<clsPanelData>();
        objPanelData = JsonConvert.DeserializeObject<List<clsPanelData>>(k);
        for (int count = 0; count < objPanelData.Count; count++)
        {
            clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtl = new clsEntityLayer_InterViewPanel_Dtl();

            objEntityJobIntrvPanelDtl.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
            objEntityJobIntrvPanelDtl.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);

            objEntityJobIntrvPanelDtlList.Add(objEntityJobIntrvPanelDtl);

        }
        try
        {
            ObjBussinesIntrvPanel.Insert_Interv_Panel(objEntityJobIntrvPanel, objEntityJobIntrvPanelDtlList);
        }
        catch
        {
            success = "false";
        }
        return success;
    }

    public class clsPanelData
    {
        public string ROWID { get; set; }
        public string DDLVALUE { get; set; }
        public string CHKBXVALUE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
    }
    
}
