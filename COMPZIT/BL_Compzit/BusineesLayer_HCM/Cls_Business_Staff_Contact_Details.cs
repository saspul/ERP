using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class Cls_Business_Staff_Contact_Details
    {

       Cls_Data_Staff_Contact_Details objDataLayerContactDtls = new Cls_Data_Staff_Contact_Details();





       public void insertContactDetails(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           objDataLayerContactDtls.insertContactDetails(objEntityContactDtls);
       }


       public DataTable ReadContactDetailsId(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           DataTable dtManpower = objDataLayerContactDtls.ReadContactDetailsId(objEntityContactDtls);
           return dtManpower;
       }



       public void UpdateContactDetails(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           objDataLayerContactDtls.UpdateContactDetails(objEntityContactDtls);
       }

       public DataTable ReadAccomdationn(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           DataTable dtDiv = objDataLayerContactDtls.ReadAccomdationn(objEntityContactDtls);
           return dtDiv;
       }

       public DataTable ReadSponser(ClsEntity_Staff_Contact_Details objEntityContactDtls)
       {
           DataTable dtDiv = objDataLayerContactDtls.ReadSponser(objEntityContactDtls);
           return dtDiv;
       }

    }
}
