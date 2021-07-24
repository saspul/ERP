using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class ClsEntity_Experiance_Certificate
    {


        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intEmpId = 0;

        private string strRemarks = "";




        private DateTime ddate = new DateTime();
        private DateTime dateFromDate = DateTime.MinValue;
        private DateTime dateToDate = DateTime.MinValue;

        private string strConduct = "";
        private string strAttendancePerfo = "";
        private string strTradePerfo = "";

        public string Conduct
        {
            get
            {
                return strConduct;
            }
            set
            {
                strConduct = value;
            }
        }

        public string AttendancePerfo
        {
            get
            {
                return strAttendancePerfo;
            }
            set
            {
                strAttendancePerfo = value;
            }
        }

        public string TradePerfo
        {
            get
            {
                return strTradePerfo;
            }
            set
            {
                strTradePerfo = value;
            }
        }

        public int EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        public string Remarks
        {
            get
            {
                return strRemarks;
            }
            set
            {
                strRemarks = value;
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
