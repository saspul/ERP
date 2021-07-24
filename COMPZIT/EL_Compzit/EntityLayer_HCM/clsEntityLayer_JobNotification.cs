using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayer_JobNotification
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;

        private int intManPwrRqstId = 0;
        private int intEmpid = 0;
        private int intIfInterOfc = 0;
        private int intSendsts = 0;
        private int intConsltId = 0;
        private int intJObNotifyId = 0;

        private DateTime dateJ_Date;


        public DateTime J_Date
        {
            get
            {
                return dateJ_Date;
            }
            set
            {
                dateJ_Date = value;
            }
        }
        public int JObNotifyId
        {
            get
            {
                return intJObNotifyId;
            }
            set
            {
                intJObNotifyId = value;
            }
        }
        public int ConsltId
        {
            get
            {
                return intConsltId;
            }
            set
            {
                intConsltId = value;
            }
        }
        public int ManPwrRqstId
        {
            get
            {
                return intManPwrRqstId;
            }
            set
            {
                intManPwrRqstId = value;
            }
        }
        public int Empid
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        }
        public int IfInterOfc
        {
            get
            {
                return intIfInterOfc;
            }
            set
            {
                intIfInterOfc = value;
            }
        }

        public int Sendsts
        {
            get
            {
                return intSendsts;
            }
            set
            {
                intSendsts = value;
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
   public class clsEntityConsultDetail
   {
       private int intConsultId = 0;
       private string strConsltToaddrs = "";
       string strConsltContent = "";
       //Method for storing consult id who do the event.
       public int ConsultId
       {
           get
           {
               return intConsultId;
           }
           set
           {
               intConsultId = value;
           }
       }

       //Method for storing consult id who do the event.
       public string ConsltToaddrs
       {
           get
           {
               return strConsltToaddrs;
           }
           set
           {
               strConsltToaddrs = value;
           }
       }
       public string ConsltContent
       {
           get
           {
               return strConsltContent;
           }
           set
           {
               strConsltContent = value;
           }
       }
   }

   public class clsEntityDivisionDetail
   {
       private int intDivisionId = 0;
       private string strDivToaddrs = "";
       string strDivContent = "";
       //Method for storing consult id who do the event.
       public int DivisionId
       {
           get
           {
               return intDivisionId;
           }
           set
           {
               intDivisionId = value;
           }
       }

       //Method for storing consult id who do the event.
       public string DivToaddrs
       {
           get
           {
               return strDivToaddrs;
           }
           set
           {
               strDivToaddrs = value;
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
   }


   public class clsEntityDepartmentDetail
   {
       private int intDepartmentId = 0;
       private string strDepToaddrs = "";
       string strDepContent = "";
       //Method for storing consult id who do the event.
       public int DepartmentId
       {
           get
           {
               return intDepartmentId;
           }
           set
           {
               intDepartmentId = value;
           }
       }

       //Method for storing consult id who do the event.
       public string DepToaddrs
       {
           get
           {
               return strDepToaddrs;
           }
           set
           {
               strDepToaddrs = value;
           }
       }
       public string DepContent
       {
           get
           {
               return strDepContent;
           }
           set
           {
               strDepContent = value;
           }
       }
   }
   public class clsEntityEmployeeDetail
   {
       private int intEmpId = 0;
       private string strEmpToaddrs = "";
       string strEmpContent = "";
       //Method for storing consult id who do the event.
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

       //Method for storing consult id who do the event.
       public string EmpToaddrs
       {
           get
           {
               return strEmpToaddrs;
           }
           set
           {
               strEmpToaddrs = value;
           }
       }
       public string EmpContent
       {
           get
           {
               return strEmpContent;
           }
           set
           {
               strEmpContent = value;
           }
       }
   }
}
