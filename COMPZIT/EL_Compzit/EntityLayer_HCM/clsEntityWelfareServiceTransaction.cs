using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityWelfareServiceTransaction
    {
        private int intUserId = 0;
        private DateTime dDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strCancelReason = "";
        private int intCancelStat = 0;
        private int intemployee = 0;
        private int intdivision = 0;
        private int intdepartment = 0;
        private int intdesig = 0;
        private int intServiceId = 0;
        private DateTime dDate1;

        private string strDate1Month = "";
        private string strDate2Month = "";
        private string strDateYear = "";

        private DateTime dDateFrom;
        private DateTime dDateTo;

        private int intEmpType = 0;
        private int intCancelStat1 = 0;
        public int CnclStsCbx
        {
            get { return intCancelStat1; }

            set { intCancelStat1 = value; }
        }
        public int EmployeeType
        {
            get { return intEmpType; }

            set { intEmpType = value; }
        }




        private int intServiceDateId = 0;
        public int ServiceDateId
        {
            get { return intServiceDateId; }

            set { intServiceDateId = value; }
        }

        public DateTime FromDate
        {

            get { return dDateFrom; }
            set { dDateFrom = value; }

        }
        public DateTime ToDate
        {

            get { return dDateTo; }
            set { dDateTo = value; }

        }




        public string Date1Month
        {

            get { return strDate1Month; }
            set { strDate1Month = value; }
        }
        public string Date2Month
        {

            get { return strDate2Month; }
            set { strDate2Month = value; }
        }
        public string DateYear
        {

            get { return strDateYear; }
            set { strDateYear = value; }
        }





        public DateTime Date1
        {

            get { return dDate1; }
            set { dDate1 = value; }

        }
        public int ServiceId
        {
            get { return intServiceId; }

            set { intServiceId = value; }
        }
        public int employee
        {
            get { return intemployee; }

            set { intemployee = value; }
        }
        public int division
        {
            get { return intdivision; }

            set { intdivision = value; }
        }
        public int department
        {
            get { return intdepartment; }

            set { intdepartment = value; }
        }
        public int designation
        {
            get { return intdesig; }

            set { intdesig = value; }
        }


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
   public class clsEntityWelfareServiceTransactionDtl
   {
       private int intUserId = 0;
       private DateTime dDate;
       private int intServiceId = 0;
       private decimal decAllotNum = 0;
       private decimal decRemaing = 0;
       private int intConfrmsts = 0;
       private decimal decAllotNumTot = 0;
       private int intColorsts = 0;
       private string strAvailability = "";
       private string strLimit = "";

       private int intServiceDateId = 0;
       public int ServiceDateId
       {
           get { return intServiceDateId; }

           set { intServiceDateId = value; }
       }

       public string Availability
       {
           get { return strAvailability; }

           set { strAvailability = value; }
       }
       public string Limit
       {
           get { return strLimit; }

           set { strLimit = value; }
       }


       public int ColorStatus
       {
           get { return intColorsts; }

           set { intColorsts = value; }
       }


       public decimal TotalAllot
       {
           get { return decAllotNumTot; }
           set { decAllotNumTot = value; }
       }

       public int ServiceId
       {
           get { return intServiceId; }

           set { intServiceId = value; }
       }
       public int EmployeeId
       {
           get { return intUserId; }

           set { intUserId = value; }
       }
       public DateTime AllotedDate
       {

           get { return dDate; }
           set { dDate = value; }

       }
       public decimal AllotedNum
       {
           get { return decAllotNum; }
           set { decAllotNum = value; }
       }
       public decimal RemainingNum
       {
           get { return decRemaing; }
           set { decRemaing = value; }
       }
       public int ConfrmSts
       {
           get { return intConfrmsts; }
           set { intConfrmsts = value; }
       }
   }
}
