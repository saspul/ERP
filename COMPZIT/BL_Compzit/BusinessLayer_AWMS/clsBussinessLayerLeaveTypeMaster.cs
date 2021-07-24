
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
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
  public class clsBussinessLayerLeaveTypeMaster
    {

                 
          // This Method checksLeave type  in the database for duplication.
      public string CheckLeaveName(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          string count = objDataLayerLeave.CheckLeaveName(objEntLev);
          return count;
      }

      // This Method insert Holiday details into the database.
      public void AddLeaveType(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          objDataLayerLeave.AddLeaveType(objEntLev);

      }

      // This Method update Leave details into the database.
      public void UpdateLeaveType(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          objDataLayerLeave.UpdateLeaveType(objEntLev);

      }
            
    

      //this metthod will read the holiday mode
      public DataTable ReadLeavedetailsById(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          DataTable dtReadLeav = objDataLayerLeave.ReadLeavedetailsById(objEntLev);
          return dtReadLeav;
      }

      // This Method recall leave type .
      public void ReCallLeaveDetails(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          objDataLayerLeave.ReCallLeaveDetails(objEntLev);

      }
      // This Method cancel leave type .
      public void CancelLeaveType(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          objDataLayerLeave.CancelLeaveType(objEntLev);

      }

      //this method will search the leave type details
      public DataTable ReadLeaveTypeBySearch(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          DataTable dtReadLeav = objDataLayerLeave.ReadLeaveTypeBySearch(objEntLev);
          return dtReadLeav;
      }

      public DataTable ReadConfirmedLevAllocn(clsEntityLayerLeaveTypeMaster objEntLev)
      {
          clsDataLayerLeaveTypeMaster objDataLayerLeave = new clsDataLayerLeaveTypeMaster();
          DataTable dtReadLeav = objDataLayerLeave.ReadConfirmedLevAllocn(objEntLev);
          return dtReadLeav;
      }
    }
}

