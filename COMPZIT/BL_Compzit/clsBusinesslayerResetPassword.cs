using System;
using System.Text;
using EL_Compzit;
using System.Data;
using BL_Compzit;
using DL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:28/10/2015
// REVIEWED BY:
// REVIEW DATE:


namespace BL_Compzit
{
  public  class clsBusinesslayerResetPassword
    { //Creating object for datalayer.
        clsDataLayerResetPassword objDataLayerRstPwd = new clsDataLayerResetPassword();
        //Read user under the corporate and  organisation who are above designtion 2 and not canceled and active
        public DataTable ReadCorporateUsers(clsEntityResetPassword objEntityResetPwd)
        {
            DataTable dtCrpUsers = objDataLayerRstPwd.ReadCorporateUsers(objEntityResetPwd);
            return dtCrpUsers;
        }
        //Method for passing data about USER Password modification for updation  from ui layer to data layer
        public void UpdatePassword(clsEntityResetPassword objEntityResetPwd)
        {
            objDataLayerRstPwd.UpdatePassword(objEntityResetPwd);
        }
        public DataTable ReadEmployeeNameEmail(clsEntityResetPassword objEntityResetPwd)
        {
            DataTable dt = objDataLayerRstPwd.ReadEmployeeAndMail(objEntityResetPwd);
            return dt;
        }
    }
}
