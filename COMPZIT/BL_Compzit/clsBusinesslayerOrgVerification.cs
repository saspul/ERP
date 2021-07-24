using System;
using System.Text;
using EL_Compzit;
using System.Data;
using DL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:29/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{    
    public class clsBusinesslayerOrgVerification
    {
        //Creating objects for datalayer.
        clsDataLayerOrgVerification objDataLayerOrgVef = new clsDataLayerOrgVerification();
        //Method for passing verification code and result in between two layers.
        public DataTable OrgVerification(clsEntityLayerOrgVerification objOrgVef)
        {
            DataTable dtOrgVef = objDataLayerOrgVef.OrgVerification(objOrgVef);
            return dtOrgVef;
        }

        //For updating status in parking table pass the data from ui layer to data layer and to insert in and GN_EMAIL_STORE.
        public void OrgStatusChange_Mail(clsEntityLayerOrgVerification objOrgVef, string strTempalteId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
            objDataLayerOrgVef.OrgstatusChange_Mail(objOrgVef,  strTempalteId,  dtCompanyDetails,  dtTemplateDetail);
        }
    }
}
