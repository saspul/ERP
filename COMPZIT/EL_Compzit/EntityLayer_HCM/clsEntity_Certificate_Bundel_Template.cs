using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Certificate_Bundel_Template
    {
        private int intUserId = 0;
        private DateTime dDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intStatus = 0;
        private int intCertificateBundelTempId = 0;
        private string strCertificateTemName = "";
        private string strCancelReason = "";
        private int intCancelStat = 0;



        public int UserId
        {
            get { return intUserId; }

            set { intUserId = value; }
        }

        public DateTime Date
        {

            get { return dDate; }
            set { dDate = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }


        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }

        }

        public int Status
        {

            get { return intStatus; }
            set { intStatus = value; }
        }
        public int CertificateBundelTempId
        {

            get { return intCertificateBundelTempId; }
            set { intCertificateBundelTempId = value; }
        }
        public string CertificateBundelName
        {


            get { return strCertificateTemName; }
            set { strCertificateTemName = value; }

        }


        public string CancelReason
        {

            get { return strCancelReason; }
            set { strCancelReason = value; }
        }


        public int CancelStatus
        {

            get { return intCancelStat; }
            set { intCancelStat = value; }
        }


    }


    public class clsEntity_Certificate_Bundel_Template_details
    {
        private int intCertificateBundelTempDetailsid = 0;
        private int intCertificateBundelTemDetStatus = 0;
        private string strCertificateBundelTemDetName = "";

        public int CertificateBundelTemplateDetailsid
        {

            get { return intCertificateBundelTempDetailsid; }
            set { intCertificateBundelTempDetailsid = value; }

        }

        public int CertificateBundelTemplateDetailsStatus
        {


            get { return intCertificateBundelTemDetStatus; }
            set { intCertificateBundelTemDetStatus = value; }


        }
        public string CertificateBundelTemplateDetailsName
        {
            get { return strCertificateBundelTemDetName; }
            set { strCertificateBundelTemDetName = value; }

        }
    }
}