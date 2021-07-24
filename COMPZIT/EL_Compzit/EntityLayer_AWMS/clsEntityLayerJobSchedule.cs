using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
  public class clsEntityLayerJobSchedule
  {
      private int intJobSchdlId = 0;
      private int intJobSchdlUserId = 0;
      private DateTime dFromdate;
      private DateTime dTodate;
      private int intOrgid = 0;
      private int intCorpOffice = 0;
      private int intUserId = 0;
      private DateTime ddate;
      private string strCancelReason = "";      
      private int intStatus = 0;
      private int intCancelStatus = 0;
      private int intTimeSlotId = 0;
      private int intIsWeekWise = 0;
      private int intToConfirm = 0;
      private int intVehicleID = 0;
      //Property for storing Confirm Flag
      public int VehicleID
      {
          get
          {
              return intVehicleID;
          }
          set
          {
              intVehicleID = value;
          }
      }
      //Property for storing Confirm Flag
      public int ToConfirm
      {
          get
          {
              return intToConfirm;
          }
          set
          {
              intToConfirm = value;
          }
      }
      //Property for storing JobSchdl id.
      public int JobSchdlId
      {
          get
          {
              return intJobSchdlId;
          }
          set
          {
              intJobSchdlId = value;
          }
      }
      //Property for storing JobSchdl UserId id.
      public int JobSchdlUserId
      {
          get
          {
              return intJobSchdlUserId;
          }
          set
          {
              intJobSchdlUserId = value;
          }
      }
      //Property for storing the fom date .
      public DateTime Fromdate
      {
          get
          {
              return dFromdate;
          }
          set
          {
              dFromdate = value;
          }
      }
      //Property for storing the To date .
      public DateTime Todate
      {
          get
          {
              return dTodate;
          }
          set
          {
              dTodate = value;
          }
      }
      //Property for storing organistion id.
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

      //Property for storing Corporate office id.
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
      //Property for storing user id who do the event.
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
      //Property for storing the date when the event occurs.
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

      //Property for storing CanceReason 
      public string CancelReason
      {
          get
          {
              return strCancelReason;
          }
          set
          {
              strCancelReason = value;
          }
      }
    

      //methode of status id storing
      public int Status_id
      {
          get
          {
              return intStatus;
          }
          set
          {
              intStatus = value;
          }
      }
      //methode of provider name storing
      public int CancelStatus
      {
          get
          {
              return intCancelStatus;
          }
          set
          {
              intCancelStatus = value;
          }
      }

      //Property for storing TimeSlot id.
      public int TimeSlotId
      {
          get
          {
              return intTimeSlotId;
          }
          set
          {
              intTimeSlotId = value;
          }
      }
      //Property for storing if there is week wise or not
      public int IsWeekWiseAvailable
      {
          get
          {
              return intIsWeekWise;
          }
          set
          {
              intIsWeekWise = value;
          }
      }
    }
}
