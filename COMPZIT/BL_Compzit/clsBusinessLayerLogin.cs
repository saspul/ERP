using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE
namespace BL_Compzit
{
    //Creating objects of datalayer, and pass user email id and password to datalayer and return user id to uilayer. 
    public class clsBusinessLayerLogin
    {
        clsDataLayerLogin objDataLayerLogin = new clsDataLayerLogin();
        public DataTable LoadLogin(clsEntityLayerLogin objEntLogin)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.LoadLogin(objEntLogin);
            return dtLogin;
        }


           // This Method Read Primise Id and wrkstation id in database  by passing encryptedWorkID to Data Layer
        public DataTable ReadPremise(clsEntityLayerLogin objEntityLayer)
        {
              DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.ReadPremise(objEntityLayer);
            return dtLogin;
        }
        // METHOD TO FIND COUNT OF WORKSTN ID BASED ON ENCRYTED VALUE IN COOKIE
        public string CheckEncryptedWrkStnId(clsEntityLayerLogin objEntityLayer)
        {
            string strWid = objDataLayerLogin.CheckEncryptedWrkStnId(objEntityLayer);
            return strWid;
        }
        // METHOD TO decide if to show new registration link when  it is not cloud condition.If count is zero make visible if not zero make the lnk invisble
        public string CheckForNewRegister()
        {
            string strWid = objDataLayerLogin.CheckForNewReg();
            return strWid;
        }
        // METHOD TO decide if  TO PROCEED  for app admin .If all template type are not entered in GN_EMAIL_TEMPLATE THEN procedure return 0 else 1.If 0 then app admin will not be able to proceed
        public string CheckForEmailTemplatesPresent()
        {
            string strWid = objDataLayerLogin.CheckForEmailTemplatesPresent();
            return strWid;
        }

        // METHOD TO decide whether To proceed for app administrator. If Template for Organization Registration and App Administrator is configured in GN_CONFIG table.
        public Int32 DefaultMailTemplateExists()
        {
            Int32 intExistsOrNot = objDataLayerLogin.DefaultMailTemplateExists();
            return intExistsOrNot;
        }
        //  METHOD TO decide if to show Send Mail link when  it is not cloud condition.If count is zero make invisible if not zero make the lnk visble
        public string CheckForShowingSendMail()
        {
            string strWid = objDataLayerLogin.CheckForShowingSendMail();
            return strWid;
        }
        // METHOD  for CHECKING FOR EMAIL ID PRESENT IN GN_PARKING_ORG ALSO TO SELECT STATUS IF FOUND to alert the user
        public DataTable CheckReSendMAil_Notify(clsEntityLayerLogin objEntityLayer)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.CheckReSendMAil_Notify(objEntityLayer);
            return dtLogin;
        }
        // METHOD TO FIND COUNT OF EMSTR_ID BASED ON transaction id and tempalte id provided
        public string CheckEmailStore(Int64 intTransId,int intTemplateID)
        {
            string strWid = objDataLayerLogin.CheckEmailStore(intTransId, intTemplateID);
            return strWid;
        }

        // METHOD TO FIND Corporate NAME
        public DataTable ReadCorporateName(clsEntityLayerLogin objEntityLayer)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.ReadCorporateName(objEntityLayer);
            return dtLogin;
        }
        // METHOD TO FIND Organisation NAME
        public DataTable ReadOrganisationName(clsEntityLayerLogin objEntityLayer)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.ReadOrganisationName(objEntityLayer);
            return dtLogin;
        }
        // METHOD TO FIND Premise NAME
        public DataTable ReadPremiseName(clsEntityLayerLogin objEntityLayer)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.ReadPremiseName(objEntityLayer);
            return dtLogin;
        }
        // METHOD TO FIND whether to show landing page or not if app type menu count is 0 then directly show sales force home page
        //or if sales force count is 0 then dirctly show app adminstration  home page
        //if both not 0 then show landing page
        public DataTable Read_AppMenuCount(clsEntityLayerLogin objEntityLayer)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.Read_AppMenuCount(objEntityLayer);
            return dtLogin;
        }
        //get useroleId based on userid and Appid
        public DataTable Read_AppMenuDtl(int intUserId, int IntAppId)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.Read_AppMenuDtl(intUserId, IntAppId);
            return dtLogin;
        }
        //METHOD for Reading USER IMAGE AND OTHER DETAILS
        public DataTable Read_UserInfo(clsEntityLayerLogin objEntityLogin)
        {
            DataTable dtLogin = new DataTable();
            dtLogin = objDataLayerLogin.Read_UserInfo(objEntityLogin);
            return dtLogin;
        }
        //METHOD for Reading  Corporate Offices  of a organization when organization adminstrator login.Inorder him to choose a corporate
        public DataTable Read_CorpOffc_ByOrgId(clsEntityLayerLogin objEntityLogin)
        {
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.Read_CorpOffc_ByOrgId(objEntityLogin);
            return dtCorpOfc;
        }
        public DataTable ReadAcsCorpBy_Usr(clsEntityLayerLogin objEntityLogin)
        {
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.ReadAcsCorpBy_Usr(objEntityLogin);
            return dtCorpOfc;
        }
        //METHOD for Reading  Corporate Offices  of a organization when organization adminstrator login.Inorder him to choose a corporate
        public string Read_BussnsUnit_ByOrgId(clsEntityLayerLogin objEntityLogin, string Link)
        {
            clsBusinessLayer objBusness = new clsBusinessLayer();
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.Read_CorpOffc_ByOrgId(objEntityLogin);
            string strBussnsUnit = "";
            if (dtCorpOfc.Rows.Count > 1)
            {
                strBussnsUnit = objBusness.ConvertDataTableToHTML_List(dtCorpOfc, Link);
            }
            return strBussnsUnit;
        }
        public string ReadAcsBussnssUnit_Usr(clsEntityLayerLogin objEntityLogin, string Link)
        {
            clsBusinessLayer objBusness = new clsBusinessLayer();
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.ReadAcsCorpBy_Usr(objEntityLogin);
            string strBussnsUnit = "";
            if (dtCorpOfc.Rows.Count > 1)
            {
                strBussnsUnit = objBusness.ConvertDataTableToHTML_List(dtCorpOfc, Link);
            }
            return strBussnsUnit;
        }

        public string Read_BussnsUnit_ByOrgIdNew(clsEntityLayerLogin objEntityLogin, string Link)
        {
            clsBusinessLayer objBusness = new clsBusinessLayer();
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.Read_CorpOffc_ByOrgId(objEntityLogin);
            string strBussnsUnit = "";
            if (dtCorpOfc.Rows.Count > 1)
            {
                strBussnsUnit = objBusness.ConvertDataTableToHTML_ListNew(dtCorpOfc, Link);
            }
            return strBussnsUnit;
        }
        public string ReadAcsBussnssUnit_UsrNew(clsEntityLayerLogin objEntityLogin, string Link)
        {
            clsBusinessLayer objBusness = new clsBusinessLayer();
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.ReadAcsCorpBy_Usr(objEntityLogin);
            string strBussnsUnit = "";
            if (dtCorpOfc.Rows.Count > 1)
            {
                strBussnsUnit = objBusness.ConvertDataTableToHTML_ListNew(dtCorpOfc, Link);
            }
            return strBussnsUnit;
        }
        public DataTable Read_BussnsUnit_OrgId(clsEntityLayerLogin objEntityLogin)
        {
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.Read_CorpOffc_ByOrgId(objEntityLogin);
            return dtCorpOfc;
        }
        public DataTable ReadAcsBussnssUnit_UsrId(clsEntityLayerLogin objEntityLogin)
        {
            DataTable dtCorpOfc = new DataTable();
            dtCorpOfc = objDataLayerLogin.ReadAcsCorpBy_Usr(objEntityLogin);
            return dtCorpOfc;
        }
    }
   
}
