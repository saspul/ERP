using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0009
// CREATED DATE:11/07/2017
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Employee Details Report.

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityEmployeeDetailsReport
    {

       private int intDesgntnId = 0;
       private int intDepartmntId = 0;
       private int intDivisionId = 0;
       private int intGradeId = 0;
       private int intProjectId = 0;
       private int intstatusId = 0;
       private int intNationltyId = 0;
       private int intReligionId = 0;
       private int intGenderId = 0;
       private int intAgeFrom = 0;
       private int intAgeTo = 0;
       private int intNumOfYears = 0;
       private int intOrgId = 0;
       private int intCorprtId = 0;
       private int intUserId = 0;
       private DateTime dDate;

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
       public int DesignationId
       {
           get
           {
               return intDesgntnId;
           }
           set
           {
               intDesgntnId = value;
           }
       }
       public int DepartmentId
       {
           get
           {
               return intDepartmntId;
           }
           set
           {
               intDepartmntId = value;
           }
       }
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
       public int GradeId
       {
           get
           {
               return intGradeId;
           }
           set
           {
               intGradeId = value;
           }
       }
       public int ProjectId
       {
           get
           {
               return intProjectId;
           }
           set
           {
               intProjectId = value;
           }
       }
       public int StatusId
       {
           get
           {
               return intstatusId;
           }
           set
           {
               intstatusId = value;
           }
       }
       public int NationalityId
       {
           get
           {
               return intNationltyId;
           }
           set
           {
               intNationltyId = value;
           }
       }
       public int ReligionId
       {
           get
           {
               return intReligionId;
           }
           set
           {
               intReligionId = value;
           }
       }
       public int GenderId
       {
           get
           {
               return intGenderId;
           }
           set
           {
               intGenderId = value;
           }
       }
       public int AgeFrom
       {
           get
           {
               return intAgeFrom;
           }
           set
           {
               intAgeFrom = value;
           }
       }
       public int AgeTo
       {
           get
           {
               return intAgeTo;
           }
           set
           {
               intAgeTo = value;
           }
       }
       public int NumOfYears
       {
           get
           {
               return intNumOfYears;
           }
           set
           {
               intNumOfYears = value;
           }
       }
       public int OrganisationId
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

       
        public int Corporate_id
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
       

    }
}
