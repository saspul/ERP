using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using EL_Compzit;

namespace BL_Compzit
{
   public class clsBusinessLayerOrganization
    {

        clsDataLayerOrganization objDataLayerOrg = new clsDataLayerOrganization();
        //Method for obtaining organisation basic details.
        public DataTable OrgDetails(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgDetails(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading organization category.
        public DataTable OrgType(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgType(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading contry.
        public DataTable OrgContry(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgContry(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading state.
        public DataTable OrgState(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgState(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading city.
        public DataTable OrgCity(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgCity(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading licence pack
        public DataTable OrgLicPack(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgLicPack(objEntityOrg);
            return dtOrgDetal;
        }
        //method for reading corporate pack
        public DataTable OrgCorpPack(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgCorpPack(objEntityOrg);
            return dtOrgDetal;
        }
        // This Method adds ORGANIZATION UPDATED details to the table
        public void AddOrgDetails(clsEntityOrganization ObjVehicle, List<clsEntityAttachment> objEntityAttchmntDeatilsList)
        {
            objDataLayerOrg.AddOrgDetails(ObjVehicle, objEntityAttchmntDeatilsList);
        }
        //method for reading card details.
        public DataTable OrgCrCard(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgCrCard(objEntityOrg);
            return dtOrgDetal;
        }
        //method for deleting file attachment.
        public void DeletAttachment(List<clsEntityAttachment> objEntityPerDeleteAttchmntDeatilsList)
        {
            objDataLayerOrg.DeletAttachment(objEntityPerDeleteAttchmntDeatilsList);
        }
        //method for inserting partner details in to database.
        public void AddPartner(List<clsAddPartner> objEntityPartnerList)
        {
            objDataLayerOrg.AddPartner(objEntityPartnerList);
        }
        //method for reading partner details from database.
        public DataTable OrgReadPartner(clsEntityOrganization objEntityOrg)
        {
            DataTable dtOrgDetal = objDataLayerOrg.OrgReadPartner(objEntityOrg);
            return dtOrgDetal;
        }
        
        //method for deleting partner details.
        public void DeletPartner(clsAddPartner objPartnerDtls)
        {
            objDataLayerOrg.DeletPartner(objPartnerDtls);
        }
        //method for updating partner details.
        public void UpdatePartner(List<clsAddPartner> objEntityPartnerList)
        {
            objDataLayerOrg.UpdatePartner(objEntityPartnerList);
        }
        public DataTable ReadState(clsEntityOrganization objEntityOrganization)
        {
            DataTable dtOrgDetal = objDataLayerOrg.ReadState(objEntityOrganization);
            return dtOrgDetal;
        }
        public DataTable ReadCity(clsEntityOrganization objEntityOrganization)
        {
            DataTable dtOrgDetal = objDataLayerOrg.ReadCity(objEntityOrganization);
            return dtOrgDetal;
        }
        public string ReadOrg(clsEntityOrganization objEntityOrganization)
        {
            string count = objDataLayerOrg.ReadOrg(objEntityOrganization);
            return count;
        }
        public string ReadCard(clsEntityOrganization objEntityOrganization)
        {
            string count = objDataLayerOrg.ReadCard(objEntityOrganization);
            return count;
        }
        public string ReadCrCard(clsEntityOrganization objEntityOrganization)
        {
            string count = objDataLayerOrg.ReadCrCard(objEntityOrganization);
            return count;
        }
        public string ReadCompCard(clsEntityOrganization objEntityOrganization)
        {
            string count = objDataLayerOrg.ReadCompCard(objEntityOrganization);
            return count;
        }
        
        public DataTable ReadPasswrd(clsEntityOrganization objEntityOrganization)
        {
            DataTable dtOrgDetal = objDataLayerOrg.ReadPasswrd(objEntityOrganization);
            return dtOrgDetal;
        }

        public clsEntityOrganization ReadAppMode(clsEntityOrganization objEntityOrganization)
        {
            DataTable dtOrgDetail = objDataLayerOrg.ReadAppMode(objEntityOrganization);

            clsEntityOrganization objEntityOrg = new clsEntityOrganization();
            objEntityOrg.OrgAppMode = Convert.ToInt16(dtOrgDetail.Rows[0]["ORG_APP_MODE"].ToString());
            return objEntityOrg;
        }
    }
}
