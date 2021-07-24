using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using System.Data;
using EL_Compzit;
// CREATED BY:EVM-0002
// CREATED DATE:01/06/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerTermsTemplate
    {

        //create objects for data layer
        clsDataLayerTermsTemplate objDataLayerTemplate = new clsDataLayerTermsTemplate();

        // This Method adds template details to the template master table
        public void AddTemplateMaster(clsEntityTermsTemplate objEntityTemplate)
        {
            objDataLayerTemplate.AddTemplateMaster(objEntityTemplate);
        }

        //Method for change the active / inactive status of template master
        public void TemplateStatusChange(clsEntityTermsTemplate objEntityTerms)
        {
            objDataLayerTemplate.TemplateStatusChange(objEntityTerms);
        }

          //Method for Updating template details
        public void UpdateTemplate(clsEntityTermsTemplate objEntityTerms)
        {
            objDataLayerTemplate.UpdateTemplate(objEntityTerms);
        }

         //Method for cancel Template
        public void CancelTemplate(clsEntityTermsTemplate objEntityTerms)
        {
            objDataLayerTemplate.CancelTemplate(objEntityTerms);
        }

         // This Method checks Template name in the database for duplication.
        public string CheckTemplateName(clsEntityTermsTemplate objEntityTerms)
        {
            string strReturn = objDataLayerTemplate.CheckTemplateName(objEntityTerms);
            return strReturn;
        }

         // This Method will fetch Template Detail by ID
        public DataTable ReadTemplateById(clsEntityTermsTemplate objEntityTerms)
        {
            DataTable dtTemplate = objDataLayerTemplate.ReadTemplateById(objEntityTerms);
            return dtTemplate;
        }

         // This Method will fetch template master table
        public DataTable ReadTempList(clsEntityTermsTemplate objEntityTerms)
        {
            DataTable dtTempList = objDataLayerTemplate.ReadTempList(objEntityTerms);
            return dtTempList;
        }

         // This Method will fetch quotation template master
        public DataTable ReadTempMaster()
        {
            DataTable dtTempMaster = objDataLayerTemplate.ReadTempMaster();
            return dtTempMaster;
        }
    }
}
