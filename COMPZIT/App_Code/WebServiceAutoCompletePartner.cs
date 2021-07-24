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
/// Summary description for WebServiceAutoCompletePartner
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceAutoCompletePartner : System.Web.Services.WebService {

    public WebServiceAutoCompletePartner () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetPartner(string strLikePartner, int intOrgId)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.Organisation_Id = intOrgId;



        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadPartnerWebService(strLikePartner.ToUpper(), objEntityCorp);





        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["PRTNR_ID"].ToString(), dtEmployess.Rows[intRowCount]["PRTNR_NAME"].ToString()));
        }



        return Employees.ToArray();

    }
    
}
