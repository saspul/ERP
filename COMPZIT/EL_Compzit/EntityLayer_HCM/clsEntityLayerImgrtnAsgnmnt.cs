using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayerImgrtnAsgnmnt
    {
       private int intImmgrtnAsgnDetailId = 0;
        private int intImmgrtnAsgnId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime DateUsrDate;
        private DateTime Datefinish;
        private DateTime DateClose;
        private int intCandId = 0;
        private int intRqstId = 0;
        private int intEmployeeId = 0;
        private int intRoundId = 0;
        private int intRoundStatusId = 0;
        private int intFinishstatus = 0;
        private int intCloseSts = 0;
        private int intSearchStatus = 0;

        //method to store date of close 
        public int SearchStatus
        {
            get
            {
                return intSearchStatus;
            }
            set
            {
                intSearchStatus = value;
            }
        }
        //method to store date of close 
        public DateTime CloseDate
        {
            get
            {
                return DateClose;
            }
            set
            {
                DateClose = value;
            }
        }
        //method to store date of finish 
        public DateTime FinishDate
        {
            get
            {
                return Datefinish;
            }
            set
            {
                Datefinish = value;
            }
        }
        //method to store date of the user insert date 
        public DateTime UsrDate
        {
            get
            {
                return DateUsrDate;
            }
            set
            {
                DateUsrDate = value;
            }
        }
        //method to store immigration detail id
        public int ImmgrtnAsgnDetailId
        {
            get
            {
                return intImmgrtnAsgnDetailId;
            }
            set
            {
                intImmgrtnAsgnDetailId = value;
            }
        }
        //method to store immigration master id
        public int ImmgrtnAsgnId
        {
            get
            {
                return intImmgrtnAsgnId;
            }
            set
            {
                intImmgrtnAsgnId = value;
            }
        }
        //method to store organisation id
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
        //method to store corporate id
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
        //method to store user id
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
        //method to store candidate id
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
        //method to store rqst id
        public int RqstId
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
        //method to store Round id
        public int EmployeeId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        //method to store Round id
        public int RoundId
        {
            get
            {
                return intRoundId;
            }
            set
            {
                intRoundId = value;
            }
        }
        //method to store Round status id
        public int RoundStatusId
        {
            get
            {
                return intRoundStatusId;
            }
            set
            {
                intRoundStatusId = value;
            }
        }
        //method to store finish sts
        public int Finishstatus
        {
            get
            {
                return intFinishstatus;
            }
            set
            {
                intFinishstatus = value;
            }
        }
       //method to store close sts
        public int CloseSts
        {
            get
            {
                return intCloseSts;
            }
            set
            {
                intCloseSts = value;
            }
        }
    }

   public class clsEntityLayerImgrtnAsgnmntEmpLoy
   {
       private int intEmployeeId = 0;

       //method to store date of close 
       public int EmployeeId
       {
           get
           {
               return intEmployeeId;
           }
           set
           {
               intEmployeeId = value;
           }
       }
   }
}
