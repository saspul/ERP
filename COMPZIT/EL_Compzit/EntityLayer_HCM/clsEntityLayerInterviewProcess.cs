using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayerInterviewProcess
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;
        private int intRermntId = 0;
        private int intSchdlLvlId = 0;
        private int intCandId = 0;
        private string strName = "";
        private int intSts = 0;
        private string strCancelResn = "";
        private DateTime dDate;
        private int intProcessId = 0;

        public int IntervewProcessId
        {
            get
            {
                return intProcessId;
            }
            set
            {
                intProcessId = value;
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

        public string CancelReasn
        {
            get
            {
                return strCancelResn;
            }
            set
            {
                strCancelResn = value;
            }
        }
        public string AsmntName
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
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
        public int SchdlLvlId
        {
            get
            {
                return intSchdlLvlId;
            }
            set
            {
                intSchdlLvlId = value;
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


   public class clsEntityLayerScheduleLevelDtls
   {
       private int intSchedlLvlId = 0;
       private int intInterctgryId = 0;
       private int intScoreId = 0;
       private int intDesnId = 0;
       private int intIntervwrId = 0;
       private int intInterTempltDtlId = 0;
       private int intSchdlTableId = 0;
       private DateTime dInterVDate;
        public int SchdlTableId
       {
           get
           {
               return intSchdlTableId;
           }
           set
           {
               intSchdlTableId = value;
           }
       }
       public DateTime IntervewDate
       {
           get
           {
               return dInterVDate;
           }
           set
           {
               dInterVDate = value;
           }
       }

       public int SchdlLvlId
       {
           get
           {
               return intSchedlLvlId;
           }
           set
           {
               intSchedlLvlId = value;
           }
       }
       public int IntervCtgryId
       {
           get
           {
               return intInterctgryId;
           }
           set
           {
               intInterctgryId = value;
           }
       }
       public int ScoreId
       {
           get
           {
               return intScoreId;
           }
           set
           {
               intScoreId = value;
           }
       }
       public int DescnId
       {
           get
           {
               return intDesnId;
           }
           set
           {
               intDesnId = value;
           }
       }
       public int IntervewrId
       {
           get
           {
               return intIntervwrId;
           }
           set
           {
               intIntervwrId = value;
           }
       }
       public int TempltDtlId
       {
           get
           {
               return intInterTempltDtlId;
           }
           set
           {
               intInterTempltDtlId = value;
           }
       }
   }


   public class clsEntityLayerAssessmentDtls
   {
       private int intAsmntId = 0;
       private int intInterctgryDtlId = 0;
       private int intScore = 0;
       private int intSchdlLvlId = 0;
       private int intAsmntTableId = 0;


       public int AsmntTableId
       {
           get
           {
               return intAsmntTableId;
           }
           set
           {
               intAsmntTableId = value;
           }
       }
       public int SchdlLvlAsmntId
       {
           get
           {
               return intSchdlLvlId;
           }
           set
           {
               intSchdlLvlId = value;
           }
       }
       public int AsmntId
       {
           get
           {
               return intAsmntId;
           }
           set
           {
               intAsmntId = value;
           }
       }
       public int IntervCtgryDtlId
       {
           get
           {
               return intInterctgryDtlId;
           }
           set
           {
               intInterctgryDtlId = value;
           }
       }
       public int Score
       {
           get
           {
               return intScore;
           }
           set
           {
               intScore = value;
           }
       }
      
   }

}
