using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerDutyRosterReports
    {
       public int intUserId = 0;
       public int intOrgId = 0;
       public int intCorprtId = 0;
       public int intemplyid = 0;
       public DateTime dateFromDate=DateTime.MinValue;
       public DateTime dateToDate=DateTime.MinValue;
       public DateTime dateOnDate=DateTime.MinValue;
       public DateTime dateHolidayFromDate;
       public DateTime dateHolidayToDate;
       public int intEmplyJobId = 0;

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
       public int OrgId
       {
           get
           {
               return intOrgId;
           }
           set 
           {
               intOrgId = value;
           }
       }
       public int CorprtId
       {
           get
           {
               return intCorprtId;
           }
           set
           {
               intCorprtId = value;
           }
       }
       public int EmplyId
       {
           get
           {
               return intemplyid;
           }
           set
           {
               intemplyid = value;
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
       public DateTime OnDate
       {
           get
           {
               return dateOnDate;
           }
           set
           {
               dateOnDate = value;
           }
       }
       public int EmplyJobId
       {
           get
           {
               return intEmplyJobId;
           }
           set
           {
               intEmplyJobId = value;
           }
       }
       public DateTime HolidayFromdate
       {
           get
           {
               return dateHolidayFromDate;
           }
           set
           {
               dateHolidayFromDate = value;
           }
       }
       public DateTime HolidayToate
       {
           get
           {
               return dateHolidayToDate;
           }
           set
           {
               dateHolidayToDate = value;
           }
       }

    }

    //emlpoyee multiple selection
   public class clsEntityDutyRosterReportEmpselection
   {
       private int intEmpSelectionId = 0;
       private int dateMultSelection=1;
       
   public int EmpSelectionId
   {
       get
       {
           return intEmpSelectionId;
       }
       set
       {
           intEmpSelectionId = value;
       }
   }

   public int DateSelection
   {
       get
       {
           return dateMultSelection;
       }
       set
       {
           dateMultSelection = value;
       }
   }

   
   }
}
