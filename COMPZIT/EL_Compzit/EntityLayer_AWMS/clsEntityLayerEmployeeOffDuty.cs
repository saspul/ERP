using System;
// CREATED BY:EVM-0015
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerEmployeeOffDuty
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intclassId = 0;
        private DateTime dDate;

        private string strCancelReason = null;

        private int intOffdutyId = 0;
        private int intMnthlyOffdutyId = 0;

        private string strOffdutyDays = "";

        private int intOffdutyStatus = 0;
        private int intinserteduserid = 0;

        private DateTime intinserteddate;
        private DateTime intupdateddate;
        private int intupdatedteduserid = 0;
        private string strMnthlyOffdutyTypename = "";

        private int intMnthlyOffdutyStatus = 0;

        private string[] a = new string[10];
        private string[] idlist = new string[10];
        private int intwkoffdutytpestatus = 0;
        private int intwkoffdutytpeid = 0;
        private string strwkoffdutydys = "";


        //methode for holiday confirmation
        public int OffdutyId
        {
            get
            {
                return intOffdutyId;
            }
            set
            {
                intOffdutyId = value;
            }
        }

        //methode for holiday confirmation
        public int MonthlyOffdutyId
        {
            get
            {
                return intMnthlyOffdutyId;
            }
            set
            {
                intMnthlyOffdutyId = value;
            }
        }
        //methode of organisation id storing
        public int Organisation_id
        {
            get
            {
                return intOrgId;
            }
            set
            {
                intOrgId = value;
            }
        }
        //methode of corporate id storing
        public int Corporate_id
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }

        //methode of user id storing
        public int User_Id
        {
            get
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }

        public string OffdutyDays
        {
            get
            {
                return strOffdutyDays;
            }
            set
            {
                strOffdutyDays = value;
            }
        }
        //methode of status id storing
        public int OffdutyStatus
        {
            get
            {
                return intOffdutyStatus;
            }
            set
            {
                intOffdutyStatus = value;
            }
        }



        ////methode of provider name storing
        public int Inserteduserid
        {
            get
            {
                return intinserteduserid;
            }
            set
            {
                intinserteduserid = value;
            }
        }
        //methode of provider name storing
        public int Updatedteduserid
        {
            get
            {
                return intupdatedteduserid;
            }
            set
            {
                intupdatedteduserid = value;
            }
        }
        public DateTime Insertedteduserdate
        {
            get
            {
                return intinserteddate;
            }
            set
            {
                intinserteddate = value;
            }
        }
        //methode of provider name storing
        public DateTime Updateddate
        {
            get
            {
                return intupdateddate;
            }
            set
            {
                intupdateddate = value;
            }
        }
        //public int Inserteduserid
        //{
        //    get
        //    {
        //        return intinserteduserid;
        //    }
        //    set
        //    {
        //        intinserteduserid = value;
        //    }
        //}
        //methode of provider name storing
        public string MnthlyOffdutyTypename
        {
            get
            {
                return strMnthlyOffdutyTypename;
            }
            set
            {
                strMnthlyOffdutyTypename = value;
            }
        }
        public int MnthlyOffdutyStatus
        {
            get
            {
                return intMnthlyOffdutyStatus;
            }
            set
            {
                intMnthlyOffdutyStatus = value;
            }
        }
        public int WeeklyOffdutyStatus
        {
            get
            {
                return intwkoffdutytpestatus;
            }
            set
            {
                intwkoffdutytpestatus = value;
            }
        }
        public int weeklyOffdutytypeid
        {
            get
            {
                return intwkoffdutytpeid;
            }
            set
            {
                intwkoffdutytpeid = value;
            }
        }
        public string weeklyOffdutydays
        {
            get
            {
                return strwkoffdutydys;
            }
            set
            {
                strwkoffdutydys = value;
            }
        }
        public string[] monthlydatalist
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public string[] monthlytypelist
        {
            get
            {
                return idlist;
            }
            set
            {
                idlist = value;
            }
        }

    }
}
