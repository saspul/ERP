using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_UserRol_ChilDefntion
    {

        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intChildRole = 0;
        private int intEmployeeid = 0;
        private int intUserRoleid = 0;
        private int intAssgnUserid = 0;
        private int intAssgnUsrRol = 0;
        private int intAssgnTempSts = 0;

        private string strUserRol="" ;
        private int strUserRolTempSts = 0;
        private int strInsUpdSta = 0;
        private string strUserAppId = "";
        private DateTime dDate = DateTime.MinValue;



        public int AssgnTempSts
        {
            get
            {
                return intAssgnTempSts;
            }
            set
            {
                intAssgnTempSts = value;
            }
        }
        public int AssgnUsrRol
        {
            get
            {
                return intAssgnUsrRol;
            }
            set
            {
                intAssgnUsrRol = value;
            }
        }
        public int AssgnUserid
        {
            get
            {
                return intAssgnUserid;
            }
            set
            {
                intAssgnUserid = value;
            }
        }
        public string UserAppId
        {
            get
            {
                return strUserAppId;
            }
            set
            {
                strUserAppId = value;
            }
        }
        public int InsUpdSta
        {
            get
            {
                return strInsUpdSta;
            }
            set
            {
                strInsUpdSta = value;
            }
        }
        public int UserRolTempSts
        {
            get
            {
                return strUserRolTempSts;
            }
            set
            {
                strUserRolTempSts = value;
            }
        }
        public int UserRoleid
        {
            get
            {
                return intUserRoleid;
            }
            set
            {
                intUserRoleid = value;
            }
        }

        public int Employeeid
        {
            get
            {
                return intEmployeeid;
            }
            set
            {
                intEmployeeid = value;
            }
        }
        public int ChildRole
        {
            get
            {
                return intChildRole;
            }
            set
            {
                intChildRole = value;
            }
        }
        public string UserRol
        {
            get
            {
                return strUserRol;
            }
            set
            {
                strUserRol = value;
            }
        }
        public int Orgid
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }
        public int CorpOffice
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
            }
        }
        public int UserId
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
    }
}
