using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntity_Joining_Intimation
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

        private int intExprnc = 0;
        private int intGender = 0;
        private int intPaygrdId = 0;

        public int Experience
        {
            get
            {
                return intExprnc;
            }
            set
            {
                intExprnc = value;
            }
        }
        public int Gender
        {
            get
            {
                return intGender;
            }
            set
            {
                intGender = value;
            }
        }
        public int PayGradeId
        {
            get
            {
                return intPaygrdId;
            }
            set
            {
                intPaygrdId = value;
            }
        }


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

    public class SelectedCandiate
    {
        private int intCandId = 0;
        private string strEmailId = "";
        string strDivContent = "";
        private int Joinsts = 0;
        private DateTime dJoinDate;

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
        public string EmailId
        {
            get
            {
                return strEmailId;
            }
            set
            {
                strEmailId = value;
            }
        }
        public string DivContent
        {
            get
            {
                return strDivContent;
            }
            set
            {
                strDivContent = value;
            }
        }
        //update joining status evm-0019
        public int JoiningStatus
        {
            get
            {
                return Joinsts;
            }
            set
            {
                Joinsts = value;
            }
        }
        //evm-0019 end

        public DateTime JoinDate
        {
            get
            {
                return dJoinDate;
            }
            set
            {
                dJoinDate = value;
            }
        }

    }
}
