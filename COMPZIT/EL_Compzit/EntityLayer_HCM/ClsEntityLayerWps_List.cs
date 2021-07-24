using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class ClsEntityLayerWps_List
  {
      private int intDivision = 0;
      private int intDep = 0;
      private int intEmployee = 0;
      private int intDesg = 0;

      private DateTime ddate = new DateTime();
      private DateTime dCurrentDate = new DateTime();
      private int intuserId = 0;
      private int intOrgId = 0;
      private int intCorprtId = 0;
      private int intuserType = 0;
      private int intMonth = 0;
      private int intYear = 0;
      private int intMode = 0;
      private int intSavConf = 0;
      private int intBusnsUnit = 0;
      private int intCloseId = 0;
      private int intBankId = 0;
      private DateTime dDate;
      private DateTime filecreate;
      private decimal decPaidAmnt = 0;
      private int intNxtId = 0;
      private int intBankName =0;
      private int intExportstatus = 0;
      private int intEmpCount_WPS = 0;
      private DateTime ExportDate;
      private string intemprEID ="";
      private DateTime filectreatetime;
      private int intpeid = 0;
      private int intpQid = 0;
      private string iban = "";
      private Decimal totalsal = 0;
      private int totalrec = 0;
      private Decimal decSalaryPrcssdBasicSalary = 0;
      private string eQid = "";
      private string VisaID = "";
      private string strEmpName = "";
      private string strEmpBAnk = "";
      private string empbankacc ="";
      private double nowork = 0;
      private Decimal netsal = 0;
      private Decimal basicsal = 0;
      private decimal extrahr = 0;
      private Decimal extrain = 0;
      private Decimal deductn = 0;
      private string comment = "";
      private string freq = "";
      private int intRowId = 0;
      private int intsettledId = 0;
      private DateTime FromDate;
      private DateTime ToDate;
      private int intPayerBankId = 0;
      private int intSponsorId = 0;
      public int SponsorId
      {
          get
          {
              return intSponsorId;
          }
          set
          {
              intSponsorId = value;
          }
      }
      public DateTime LvFromDate
      {
          get
          {
              return FromDate;
          }
          set
          {
              FromDate = value;
          }
      }
      public DateTime LvToDate
      {
          get
          {
              return ToDate;
          }
          set
          {
              ToDate = value;
          }
      }
      public int PayerBankId
      {
          get
          {
              return intPayerBankId;
          }
          set
          {
              intPayerBankId = value;
          }
      }
      public int SettledId
      {
          get
          {
              return intsettledId;
          }
          set
          {
              intsettledId = value;
          }
      }
      public int RowId
      {
          get
          {
              return intRowId;
          }
          set
          {
              intRowId = value;
          }
      }
      public string SalFreqncy
      {
          get
          {
              return freq;
          }
          set
          {
              freq = value;
          }
      }
      public DateTime Filetime
      {
          get
          {
              return filectreatetime;
          }
          set
          {
              filectreatetime = value;
          }
      }
      public string Commentss
      {
          get
          {
              return comment;
          }
          set
          {
              comment = value;
          }
      }
      public Decimal Deduction
      {
          get
          {
              return deductn;
          }
          set
          {
              deductn = value;
          }
      }
      public Decimal ExtraIncome
      {
          get
          {
              return extrain;
          }
          set
          {
              extrain = value;
          }
      }
      public decimal ExtraHr
      {
          get
          {
              return extrahr;
          }
          set
          {
              extrahr = value;
          }
      }

      public Decimal SalaryPrcssdBasicSalary
      {
          get
          {
              return decSalaryPrcssdBasicSalary;
          }
          set
          {
              decSalaryPrcssdBasicSalary = value;
          }
      }

      public Decimal BasicSalary
      {
          get
          {
              return basicsal;
          }
          set
          {
              basicsal = value;
          }
      }
      public Decimal NetSalary
      {
          get
          {
              return netsal;
          }
          set
          {
              netsal = value;
          }
      }
      public double WorkingDays
      {
          get
          {
              return nowork;
          }
          set
          {
              nowork = value;
          }
      }
      public string BankAccountno
      {
          get
          {
              return empbankacc;
          }
          set
          {
              empbankacc = value;
          }
      }
      public string PayerBankName
      {
          get
          {
              return strEmpBAnk;
          }
          set
          {
              strEmpBAnk = value;
          }
      }
      public string EmpName
      {
          get
          {
              return strEmpName;
          }
          set
          {
              strEmpName = value;
          }
      }
      public string EmpVisa
      {
          get
          {
              return VisaID;
          }
          set
          {
              VisaID = value;
          }
      }
      public string EmpQid
      {
          get
          {
              return eQid;
          }
          set
          {
              eQid = value;
          }
      }
      public int PayerEid
      {
          get
          {
              return intpeid;
          }
          set
          {
              intpeid = value;
          }
      }
      public int PayerQID
      {
          get
          {
              return intpQid;
          }
          set
          {
              intpQid = value;
          }
      }
      public string IBAN
      {
          get
          {
              return iban;
          }
          set
          {
              iban = value;
          }
      }

      public Decimal TotalSalary
      {
          get
          {
              return totalsal;
          }
          set
          {
              totalsal = value;
          }
      }

      public int TotalRecord
      {
          get
          {
              return totalrec;
          }
          set
          {
              totalrec = value;
          }
      }
      public string EmpEID
      {
          get
          {
              return intemprEID;
          }
          set
          {
              intemprEID = value;
          }
      }
      public int ExportEmpCount
      {
          get
          {
              return intEmpCount_WPS;
          }
          set
          {
              intEmpCount_WPS = value;
          }
      }
      public int ExportStatus
      {
          get
          {
              return intExportstatus;
          }
          set
          {
              intExportstatus = value;
          }
      }
      public int NxtID

      {
          get
          {
              return intNxtId;
          }
          set
          {
              intNxtId = value;
          }
      }
      public int SavConf
      {
          get
          {
              return intSavConf;
          }
          set
          {
              intSavConf = value;
          }
      }
      public int BankId
      {
          get
          {
              return intBankId;
          }
          set
          {
              intBankId = value;
          }
      }
      public int BusnsUnitId
      {
          get
          {
              return intBusnsUnit;
          }
          set
          {
              intBusnsUnit = value;
          }
      }
      public int Mode
      {
          get
          {
              return intMode;
          }
          set
          {
              intMode = value;
          }
      }
      public DateTime CurrentDate
      {
          get
          {
              return dCurrentDate;
          }
          set
          {
              dCurrentDate = value;
          }
      }
      public DateTime FileDate
      {
          get
          {
              return filecreate;
          }
          set
          {
              filecreate = value;
          }
      }
      public DateTime date
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

      public DateTime WPS_date
      {
          get
          {
              return ExportDate;
          }
          set
          {
              ExportDate = value;
          }
      }
      public int Designation
      {
          get
          {
              return intDesg;
          }
          set
          {
              intDesg = value;
          }
      }


      public int Employee
      {
          get
          {
              return intEmployee;
          }
          set
          {
              intEmployee = value;
          }
      }

      public int Department
      {
          get
          {
              return intDep;
          }
          set
          {
              intDep = value;
          }
      }
      public int Division
      {
          get
          {
              return intDivision;
          }
          set
          {
              intDivision = value;
          }
      }

      public int Month
      {
          get
          {
              return intMonth;
          }
          set
          {
              intMonth = value;
          }
      }
      public int Year
      {
          get
          {
              return intYear;
          }
          set
          {
              intYear = value;
          }
      }

      public int UserId
      {
          get
          {
              return intuserId;
          }
          set
          {
              intuserId = value;
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
      public int Staff_Worker
      {
          get
          {
              return intuserType;
          }
          set
          {
              intuserType = value;
          }
      }
      public int EmpBank
      {
          get
          {
              return intBankName;
          }
          set
          {
              intBankName = value;
          }
      }
    }
}
