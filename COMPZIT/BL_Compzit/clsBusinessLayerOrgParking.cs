using System;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerOrgParking
    {
        //Creating objects for datalayer.
        clsDataLayerOrgParking objDataLayerOrgParking = new clsDataLayerOrgParking();
        public DataTable ReadOrganisationType()
        {
            DataTable dtReadOrganisation = objDataLayerOrgParking.ReadOrganisationType();
            return dtReadOrganisation;
        }
        public DataTable ReadFramework()
        {
            DataTable dtReadOrganisation = objDataLayerOrgParking.ReadFramework();
            return dtReadOrganisation;
        }
        //Method for passing country table from datalayer to uilayer.
        public DataTable ReadCountry()
        {
            DataTable dtReadCountry = objDataLayerOrgParking.ReadCountry();
            return dtReadCountry;
        }
        //Method for passing state details in between the datalayer and ui layer.
        public DataTable ReadState(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtReadState = objDataLayerOrgParking.ReadState(objEntityOrgParking);
            return dtReadState;
        }
        //Method for passing city details in between the datalayer and ui layer.
        public DataTable ReadCity(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtReadCity = objDataLayerOrgParking.ReadCity(objEntityOrgParking);
            return dtReadCity;
        }
        //Method for passing license pack details from datalayer to ui layer
        public DataTable ReadLicensePack()
        {
            DataTable dtReadLicense = objDataLayerOrgParking.ReadLicensePack();
            return dtReadLicense;
        }
        //Method for passing corporate pack details from datalayer to ui layer
        public DataTable ReadCorporatePack()
        {
            DataTable dtReadCorporate = objDataLayerOrgParking.ReadCorporatePack();
            return dtReadCorporate;
        }
        //Method of passing license pack maximum users details from datalayer to ui layer.
        public DataTable ReadLicPacCount(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtLicPacCount = objDataLayerOrgParking.ReadLicPacCount(objEntityOrgParking);
            return dtLicPacCount;
        }
        //Method of passing corporate pack number of offices details from datalayer to ui layer.
        public DataTable ReadCorPacCount(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtCorPacCount = objDataLayerOrgParking.ReadCorPacCount(objEntityOrgParking);
            return dtCorPacCount;
        }
        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtReadnextId = objDataLayerOrgParking.ReadNextId(objEntityOrgParking);
            return dtReadnextId;
        }
        //Method for passing Email checking count from datalayer to ui layer.
        public DataTable EmailCheck(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtEmailCheck = objDataLayerOrgParking.EmailCheck(objEntityOrgParking);
            return dtEmailCheck;
        }
        //Method for passing Email checking count from datalayer to ui layer.
        public DataTable EmailCheckUser(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtEmailCheckUser = objDataLayerOrgParking.EmailCheckUser(objEntityOrgParking);
            return dtEmailCheckUser;
        }
        //Method of inserting values to organisation parking table and GN_EMAIL_STORE.
        public void InsertOrgParking_Mail(clsEntityOrgParking objEntityOrgParking, string strTempalteId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
            objDataLayerOrgParking.InsertOrgParking_Mail(objEntityOrgParking,strTempalteId,dtCompanyDetails,dtTemplateDetail);
        }
        //Method for passing organisation name and org name count in table in between two tables.
        public DataTable CheckOrgName(clsEntityOrgParking objEntityOrgParking)
        {
            DataTable dtOrgName = objDataLayerOrgParking.CheckOrg(objEntityOrgParking);
            return dtOrgName;
        }
    }
}
