using BL_Compzit;
using EL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceAutoCompletion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class WebServiceAutoCompletion : System.Web.Services.WebService {

    public WebServiceAutoCompletion () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetProducts(string strLikePrdctName, int intListingMode, int intOrgId, int intCorpId, string strDivsionIds)
    {
        List<string> products = new List<string>();
        clsBusinessLayerQuotation objBusinessLayerQuotation = new clsBusinessLayerQuotation();
        clsEntityLayerQuotation objEntityQuotation = new clsEntityLayerQuotation();
        objEntityQuotation.Organisation_Id = intOrgId;
        objEntityQuotation.CorpOffice_Id = intCorpId;
        objEntityQuotation.Divisionids = strDivsionIds;
        DataTable dtProducts = objBusinessLayerQuotation.ReadProductsWebService(strLikePrdctName.ToUpper(), intListingMode, objEntityQuotation);





        for (int intRowCount = 0; intRowCount < dtProducts.Rows.Count; intRowCount++)
        {
            products.Add(string.Format("{0}<->{1}", dtProducts.Rows[intRowCount]["PRDT_NAME"].ToString(), dtProducts.Rows[intRowCount]["PRDT_ID"].ToString()));
        }



        return products.ToArray();

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetProductsCategory(string strLikePrdctName, int intListingMode, int intOrgId, int intCorpId, string strDivsionIds)
    {
        List<string> products = new List<string>();
        clsBusinessLayerQuotation objBusinessLayerQuotation = new clsBusinessLayerQuotation();
        clsEntityLayerQuotation objEntityQuotation = new clsEntityLayerQuotation();
        objEntityQuotation.Organisation_Id = intOrgId;
        objEntityQuotation.CorpOffice_Id = intCorpId;
        objEntityQuotation.Divisionids = strDivsionIds;
        DataTable dtProducts = objBusinessLayerQuotation.ReadProductcatgryWebService(strLikePrdctName.ToUpper(), intListingMode, objEntityQuotation);





        //for (int intRowCount = 0; intRowCount < dtProducts.Rows.Count; intRowCount++)
        //{
        //    products.Add(string.Format("{0}<->{1}", dtProducts.Rows[intRowCount]["CTGRY_NAME"].ToString(), dtProducts.Rows[intRowCount]["CTGRY_ID"].ToString()));
        //}



        return products.ToArray();

    }
}
