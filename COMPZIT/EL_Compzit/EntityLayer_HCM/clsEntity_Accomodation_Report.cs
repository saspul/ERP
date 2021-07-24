using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_Accomodation_Report
    {
       private int intCorpId = 0;
       private int intDept=0;
       private int intDiv=0;
       private int intOrgId=0;
       private int intAccId=0;
       private int intUserId=0;
       private DateTime dtFromDate;
       private DateTime dtToDate;

       public int CorpId
       {
           get
           {
               return intCorpId;
           }
           set
           {
               intCorpId = value;
           }
       }
       public int DepartmentId
       {
           get
           {
               return intDept;
           }
           set
           {
               intDept = value;
           }
       }
       public int DivisionId
       {
           get
           {
               return intDiv;
           }
           set
           {
               intDiv = value;
           }
       }
       public int OrganizatonId
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
       public int Accomodation
       {
           get
           {
               return intAccId;
           }
           set
           {
               intAccId = value;
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
       public DateTime ToDate
       {
           get
           {
               return dtToDate;
           }
           set
           {
               dtToDate = value;
           }
       }
       public DateTime FromDate
       {
           get
           {
               return dtFromDate;
           }
           set
           {
               dtFromDate = value;
           }
       }
    }
}
