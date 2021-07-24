using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_Interview_Temp
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intTemplateId = 0;
        private int intTempSts = 0;
        private int intValidateSts = 0;
        private int intNextTempId = 0;


      
        private int intCancel_Status = 0;
   
   


        private string strTemplateNme = "";
        private string strCancel_Reason = "";



        private DateTime ddate = new DateTime();

        public int NextTempId
        {
            get
            {
                return intNextTempId;
            }
            set
            {
                intNextTempId = value;
            }
        }
        public string Cancel_Reason
        {
            get
            {
                return strCancel_Reason;
            }
            set
            {
                strCancel_Reason = value;
            }
        }
        public int Cancel_Status
        {
            get
            {
                return intCancel_Status;
            }
            set
            {
                intCancel_Status = value;
            }
        }
       
        public string TemplateNme
        {
            get
            {
                return strTemplateNme;
            }
            set
            {
                strTemplateNme = value;
            }
        }
        

       
        public int ValidateSts
        {
            get
            {
                return intValidateSts;
            }
            set
            {
                intValidateSts = value;
            }
        }
        public int TempSts
        {
            get
            {
                return intTempSts;
            }
            set
            {
                intTempSts = value;
            }
        }
        public int TemplateId
        {
            get
            {
                return intTemplateId;
            }
            set
            {
                intTemplateId = value;
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
        //Method for storing the date when the event occurs.
        public DateTime D_Date
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
   }
        public class clsEntityInterviewShedule
        {
            private int intShedulId = 0;
            private int intCatagryId = 0;
            //private int intImgEmpId = 0;
            private int intShdlTypId = 0;
            private int intScoreStsstatus = 0;


            private DateTime Inetwrdate;

            private int intCorpId = 0;
            private int intOrgId = 0;
            private int intUsrId = 0;
            private string strsheduleNme = "";


            public int ShedulId
            {
                get
                {
                    return intShedulId;
                }
                set
                {
                    intShedulId = value;
                }
            }

            public int CatagryId
            {
                get
                {
                    return intCatagryId;
                }
                set
                {
                    intCatagryId = value;
                }
            }
            public int ScoreStsstatus
            {
                get
                {
                    return intScoreStsstatus;
                }
                set
                {
                    intScoreStsstatus = value;
                }
            }



            public int ShdlTypId
            {
                get
                {
                    return intShdlTypId;
                }
                set
                {
                    intShdlTypId = value;
                }
            }



            public int UserId
            {
                get
                {
                    return intUsrId;
                }
                set
                {
                    intUsrId = value;
                }
            }




            public DateTime InterviewDate
            {
                get
                {
                    return Inetwrdate;
                }
                set
                {
                    Inetwrdate = value;
                }
            }

            public string sheduleNme
            {
                get
                {
                    return strsheduleNme;
                }
                set
                {
                    strsheduleNme = value;
                }

            }

        }
    }

