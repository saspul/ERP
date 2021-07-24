using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityOnBoardingPartialProcess
    {

        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intRermntId = 0;
        private int intCandId = 0;
        private int intSts = 0;
        private int intOnbrddtlId = 0;
        private DateTime dDate;
        private DateTime asgndDate;
        private DateTime toDate;
        private int intVisaDtlId = 0;
        private string strFileName="";

        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }

        private string strActualFileName="";

        public string ActFileName
        {
            get { return strActualFileName; }
            set { strActualFileName = value; }
        }
        public int VisaDetailId
        {
            get
            {
                return intVisaDtlId;
            }
            set
            {
                intVisaDtlId = value;
            }
        }

        public int OnbrdDtlId
        {
            get
            {
                return intOnbrddtlId;
            }
            set
            {
                intOnbrddtlId = value;
            }
        }
        public DateTime AsgndDate
        {
            get
            {
                return asgndDate;
            }
            set
            {
                asgndDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return toDate;
            }
            set
            {
                toDate = value;
            }
        }

        public int StatusId
        {
            get
            {
                return intSts;
            }
            set
            {
                intSts = value;
            }
        }
        public DateTime date
        {
            get
            {
                return dDate;
            }
            set
            {
                dDate = value;
            }
        }

       
       

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
       
        public int ReqrmntId
        {
            get
            {
                return intRermntId;
            }
            set
            {
                intRermntId = value;
            }
        }

        
        
        public int Organisation_Id
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


        //Method for storing Corporate office id.
        public int CorpOffice_Id
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


        //Method for storing user id who do the event.
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
    }
}
