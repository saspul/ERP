using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:29/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Organisation registration verification .

namespace EL_Compzit
{
    public class clsEntityLayerOrgVerification
    {
        private  string strVerifiactionCode = null;
        private  string strOrgName = null;
        private  string strLicPacName = null;
        private  string strCorPacName = null;
        private  string strMobileNumber = null;
        private  string strOrgParkId = null;
        private  DateTime Date;

        //Method for storing verification code.
        public string Verification_Code
        {
            get
            {
                return strVerifiactionCode;
            }
            set
            {
                strVerifiactionCode = value;
            }
        }

        //Method for storing License Pack Name.
        public string LicensePac_Name
        {
            get
            {
                return strLicPacName;
            }
            set
            {
                strLicPacName = value;
            }
        }

        //Method for storing Corpoarte Pack Name.
        public string CorporatePack_Name
        {
            get
            {
                return strCorPacName;
            }
            set
            {
                strCorPacName = value;
            }
        }

        //Method for storing Organisation Name.
        public string Organisation_Name
        {
            get
            {
                return strOrgName;
            }
            set
            {
                strOrgName = value;
            }
        }

        //Method for storing Mobile Number.
        public string Mobile_Number
        {
            get
            {
                return strMobileNumber;
            }
            set
            {
                strMobileNumber = value;
            }
        }

        //Method for storing OrganisationPark Id.
        public string Organisation_Id
        {
            get
            {
                return strOrgParkId;
            }
            set
            {
                strOrgParkId = value;
            }
        }

        //Method for storing Date of the event.
        public DateTime Date_Verification
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }
    }
}

