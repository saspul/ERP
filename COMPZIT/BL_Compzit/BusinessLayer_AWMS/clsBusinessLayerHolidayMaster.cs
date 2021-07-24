
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0008
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
  public class clsBusinessLayerHolidayMaster
    {

        //this metthod will read the holiday type
      public DataTable ReadHolType(clsEntityLayerHolidayMaster objEntHol)
        {
            clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
            DataTable dtReadveh = objDataLayerHol.ReadHolType(objEntHol);
            return dtReadveh;
        }

      ////this metthod will read the holiday mode
      //public DataTable ReadHolMode(clsEntityLayerHolidayMaster objEntHol)
      //{
      //    clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
      //    DataTable dtReadveh = objDataLayerHol.ReadHolMode(objEntHol);
      //    return dtReadveh;
      //}

      // This Method checks Accommodation name in the database for duplication.
      public string Checksalaryprocess(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          string count = objDataLayerHol.Checksalaryprocess(objEntHol);
          return count;
      }
                 
          // This Method checks Holiday title  in the database for duplication.
      public string CheckHolTitle(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          string count = objDataLayerHol.CheckHolTitle(objEntHol);
          return count;
      }
      public string CheckHolDate(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          string count = objDataLayerHol.CheckHolDate(objEntHol);
          return count;
      }
      // This Method insert Holiday details into the database.
      public void AddHolidayDetails(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
           objDataLayerHol.AddHolidayDetails(objEntHol);
      
      }

      // This Method update Holiday details into the database.
      public void UpdateHoldetails(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          objDataLayerHol.UpdateHoldetails(objEntHol);

      }
            
           // This Method confirm Holiday details into the database.
      public void ConfirmHoliday(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          objDataLayerHol.ConfirmHoliday(objEntHol);

      }
      // This Method reopen Holiday .
      public void ReOpenHoliday(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          objDataLayerHol.ReOpenHoliday(objEntHol);

      }

      //this metthod will read the holiday mode
      public DataTable ReadHolidaydetailsById(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          DataTable dtReadveh = objDataLayerHol.ReadHolidaydetailsById(objEntHol);
          return dtReadveh;
      }

      // This Method recall Holiday .
      public void ReCallHolidayDetails(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          objDataLayerHol.ReCallHolidayDetails(objEntHol);

      }
      // This Method cancel Holiday .
      public void CancelHoliday(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          objDataLayerHol.CancelHoliday(objEntHol);

      }

      //this method will search the holiday details
      public DataTable ReadHolidayListBySearch(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          DataTable dtReadveh = objDataLayerHol.ReadHolidayListBySearch(objEntHol);
          return dtReadveh;
      }
      
         public DataTable ReadYr(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          DataTable count = objDataLayerHol.ReadYr(objEntHol);
          return count;
      }

         public DataTable LeavAlloctnConfrmCk(clsEntityLayerHolidayMaster objEntHol)
      {
          clsDataLayerHolidayMaster objDataLayerHol = new clsDataLayerHolidayMaster();
          DataTable count = objDataLayerHol.LeavAlloctnConfrmCk(objEntHol);
          return count;
      }
    }
}
