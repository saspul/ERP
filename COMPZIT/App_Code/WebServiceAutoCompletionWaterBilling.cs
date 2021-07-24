using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceAutoCompletionWaterBilling
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class WebServiceAutoCompletionWaterBilling : System.Web.Services.WebService {

    public WebServiceAutoCompletionWaterBilling () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetVehicleNumber(string strLikeVhclNumbr, int intOrgId, int intCorpId)
    {
        List<string> Vehicles = new List<string>();
        clsBusinessLayerWaterBilling objBusinessLayerWatrBilling = new clsBusinessLayerWaterBilling();
        clsEntityLayerWaterBilling objEntityWatrBilling = new clsEntityLayerWaterBilling();
        objEntityWatrBilling.Organisation_Id = intOrgId;
        objEntityWatrBilling.CorpOffice_Id = intCorpId;

        DataTable dtVehicles = objBusinessLayerWatrBilling.ReadVehiclesWebService(strLikeVhclNumbr.ToUpper(), objEntityWatrBilling);





        for (int intRowCount = 0; intRowCount < dtVehicles.Rows.Count; intRowCount++)
        {
            Vehicles.Add(string.Format("{0}<->{1}", dtVehicles.Rows[intRowCount]["VHCL_NUMBR"].ToString(), dtVehicles.Rows[intRowCount]["VHCL_ID"].ToString()));
        }



        return Vehicles.ToArray();

    }
}
