using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_Arrivl_Confrmtn
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intArrvedStsId = 0;
        private int intChckArrved = 0;
        private int intCandId = 0;

 
        private DateTime ddate = new DateTime();
        private DateTime dateFromDate = DateTime.MinValue;
        private DateTime dateToDate = DateTime.MinValue;



        public int CandId
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
        public DateTime datenow
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }
        public int ChckArrved
        {
            get
            {
                return intChckArrved;
            }
            set
            {
                intChckArrved = value;
            }
        }
        public int ArrvedStsId
        {
            get
            {
                return intArrvedStsId;
            }
            set
            {
                intArrvedStsId = value;
            }
        }
        public DateTime FromDate
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
