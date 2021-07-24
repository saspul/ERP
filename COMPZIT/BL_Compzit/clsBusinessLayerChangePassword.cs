using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;
// CREATED BY:EVM-0001
// CREATED DATE:26/10/2015
// REVIEWED BY:
// REVIEW DATE:


namespace BL_Compzit
{
   public class clsBusinessLayerChangePassword
    {
        //Creating object for datalayer
        clsDataLayerChangePassword objDataLayerChngePwd = new clsDataLayerChangePassword();


        public int CheckCurrentPasswd(clsEntityLayerUserRegistration objEntityUsrReg)
        {

            string strCount = objDataLayerChngePwd.CheckCurrentPasswd(objEntityUsrReg);
            int intCount = Convert.ToInt32(strCount);
            return intCount;
        }
        //Method for passing data about USER Password modification for updation  from ui layer to data layer
        public void UpdatePassword(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            objDataLayerChngePwd.UpdatePassword(objEntityUsrReg);
        }
        // Method for fetch the email id,username,login name of user from the database
        //0006
        public DataTable ReadMailId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadMailId = objDataLayerChngePwd.ReadMailId(objEntityUsrReg);
            return dtReadMailId;
        }
    }
}
