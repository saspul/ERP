using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayer_Candidate_ShortList
    {
        private int intShortlistMasterId = 0;
        private int intShortlistDetailId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime UsrDate;
        private int intCandId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;
        private int intShrtlisconfrmstatus = 0;
        private int[] intCandList = new int[100];

        private int intRqstId = 0;
        public int Confirmstatus
        {
            get
            {
                return intShrtlisconfrmstatus;
            }
            set
            {
                intShrtlisconfrmstatus = value;
            }
        }

        public int ReqstID
        {
            get
            {
                return intRqstId;
            }
            set
            {
                intRqstId = value;
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

        public int[] CandidateList
        {
            get
            {
                return intCandList;
            }
            set
            {
                intCandList = value;
            }
        }


        public int ShortlistMasterId
        {
            get
            {
                return intShortlistMasterId;
            }
            set
            {
                intShortlistMasterId = value;
            }
        }
        public int ShortlistDetailId
        {
            get
            {
                return intShortlistDetailId;
            }
            set
            {
                intShortlistDetailId = value;
            }
        }

        public DateTime ShorltistDate
        {
            get
            {
                return UsrDate;
            }
            set
            {
                UsrDate = value;
            }
        }
        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }
        public int Deprt_Id
        {
            get
            {
                return intDeprt_Id;
            }
            set
            {
                intDeprt_Id = value;
            }
        }
        public int DesgId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
            }
        }
        public int DivId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }
    }
        public class ShortListedCandiate 
        {
            private int intCandId=0;
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
        
        }


    
}
