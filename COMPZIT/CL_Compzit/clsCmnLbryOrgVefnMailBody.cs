using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Common library for the Mail body creation .

namespace CL_Compzit
{
    public class clsCmnLbryOrgVefnMailBody
    {
        //Create method for entity layers.
        clsEntityLayerOrgVerification objEntityOrgVef = new clsEntityLayerOrgVerification();
        public string MailBody(string strBody, string strDisclaimer, DataTable dtCompanyDetail, clsEntityOrgParking objEntityOrgParking = null, clsEntityLayerOrgVerification objEntityOrgVef = null)
        {
            string strCompanyname = "", strCompanyAdrr = "";
            if (dtCompanyDetail.Rows.Count > 0)
            {


                strCompanyname = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
                strCompanyAdrr = dtCompanyDetail.Rows[0]["CMPNY_ADDR1"].ToString() + "," + dtCompanyDetail.Rows[0]["CMPNY_ADDR2"].ToString() +
                    ",\n" + dtCompanyDetail.Rows[0]["CMPNY_ADDR3"].ToString() + "," + dtCompanyDetail.Rows[0]["CMPNY_CITY"].ToString() +
                    ",\n" + dtCompanyDetail.Rows[0]["CMPNY_STATE"].ToString() + "," + dtCompanyDetail.Rows[0]["CMPNY_COUNTRY"].ToString() +
                    ",\n" + dtCompanyDetail.Rows[0]["CMPNY_WEB"].ToString() +
                    ",\n" + dtCompanyDetail.Rows[0]["CMPNY_EMAIL"].ToString() +
                    ",\n" + dtCompanyDetail.Rows[0]["CMPNY_PHONE"].ToString() + ".";

            }

            if (objEntityOrgParking != null)
            {
                string strMailBody = "\nHi " + objEntityOrgParking.Organisation_Name + ",\n\n" + strBody + "\n\nYour Verification Code Is: " + objEntityOrgParking.Verification_Code +
                    "\n\nPlease Verify Your Registration Through this Link\n" + objEntityOrgParking.Verification_Link +
                    "\n\n" + strCompanyname + ",\n" + strCompanyAdrr + "" +
                    "\n\n\n\nDisclaimer: " + strDisclaimer;
                return strMailBody;
            }
            else if (objEntityOrgVef != null)
            {
                string strMailBody = "\nHi,\n\n" + objEntityOrgVef.Organisation_Name +
                    " Have Completed Their Email Verification.\n\nMobile Number: " + objEntityOrgVef.Mobile_Number +
                    "\n\nSelected Corporate Pack: " + objEntityOrgVef.CorporatePack_Name +
                    "\n\nSelected License Pack: " + objEntityOrgVef.LicensePac_Name +
                    "\n\n" + strCompanyname + "\n" + strCompanyAdrr;
                if (strDisclaimer != "")
                {
                    strMailBody = strMailBody + "\n\n\n\nDisclaimer: " + strDisclaimer;
                }
                return strMailBody;
            }
            else
            {
                string strMailBody = strBody +
                    "\n\n\n\n\n\n\n\n\n\tDisclaimer: " + strDisclaimer;
                return strMailBody;
            }

        }
    }
}
