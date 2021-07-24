using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
/// <summary>
/// Summary description for WebServiceInterviewProcess
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class WebServiceInterviewProcess : System.Web.Services.WebService {

    public WebServiceInterviewProcess () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string[] GetAsmnt(string strLikeAsmnt, int intSchdlId)
    {
        List<string> li_Vehicle = new List<string>();
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        objEntityIntervewProcess.SchdlLvlId = intSchdlId;


        DataTable dtVehicles = objBusinessIntervewProcess.ReadAsmntNotChcked(objEntityIntervewProcess);


        for (int intRowCount = 0; intRowCount < dtVehicles.Rows.Count; intRowCount++)
        {
            li_Vehicle.Add(string.Format("{0}<->{1}", dtVehicles.Rows[intRowCount]["INTWCTGRYDTL_NAME"].ToString(), dtVehicles.Rows[intRowCount]["INTWCTGRYDTL_ID"].ToString()));
        }

        return li_Vehicle.ToArray();

    }
    
}
