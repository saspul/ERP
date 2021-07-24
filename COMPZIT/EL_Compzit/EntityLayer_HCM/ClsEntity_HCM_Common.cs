using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class ClsEntity_HCM_Common
    {
        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private DateTime dateFromDate = DateTime.MinValue;
        private DateTime dateToDate = DateTime.MinValue;
        private int intCandId = 0;
        private int intManpowerId = 0;
        private int intYear = 0;
        private int intmonth = 0;
        private int intEmployeRecId = 0;



        public int month
        {
            get
            {
                return intmonth;
            }
            set
            {
                intmonth = value;
            }
        }

        public int EmployeeRecruitmentId
        {
            get
            {
                return intEmployeRecId;
            }
            set
            {
                intEmployeRecId = value;
            }
        }




        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
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


        public int CorpId
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

        public int OrgId
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

        public DateTime FrmDate
        {
            get
            {
                return dateFromDate;
            }
            set
            {
                dateFromDate = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return dateToDate;
            }
            set
            {
                dateToDate = value;
            }
        }




        public int CandidateId
        {
            get
            {
                return intCandId;
            }
            set
            {
                intCandId = value;
            }
        }

        public int ManpowerId
        {
            get
            {
                return intManpowerId;
            }
            set
            {
                intManpowerId = value;
            }
        }

    }
}
