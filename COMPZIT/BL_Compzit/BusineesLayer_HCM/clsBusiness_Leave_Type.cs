using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusiness_Leave_Type
    {
       clsData_Leave_Type objDataLayerJobDetails = new clsData_Leave_Type();
       public DataTable ReadDesignation(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtReadsupplier = objDataLayerJobDetails.ReadDesignation(ObjEntityLeaveType);
           return dtReadsupplier;
       }
       public DataTable ReadPaygrade(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtIndenter = objDataLayerJobDetails.ReadPaygrade(ObjEntityLeaveType);
           return dtIndenter;
       }
       public DataTable ReadExperience(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtIndenter = objDataLayerJobDetails.ReadExperience(ObjEntityLeaveType);
           return dtIndenter;
       }
       public void AddLeaveType(clsEntity_Leave_Type ObjEntityLeaveType, List<clsEntity_designation_list> ObjEntityLeaveDesignationList, List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList, List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList, List<clsEntity_Users_list> objEntityUser_List)
       {

           objDataLayerJobDetails.AddLeaveType(ObjEntityLeaveType, ObjEntityLeaveDesignationList, ObjEntityLeavPayGradeList, ObjEntityLeaveExpriencenOList, objEntityUser_List);

       }
       public DataTable ReadLeavedetailsById(clsEntity_Leave_Type ObjEntityLeaveType )
       {
           DataTable dtReadLeav = objDataLayerJobDetails.ReadLeavedetailsById(ObjEntityLeaveType);
           return dtReadLeav;
       }

       public DataTable ReadLeavedDesigById(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtReadLeav = objDataLayerJobDetails.ReadLeavedDesigById(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public DataTable ReadLeavePaygradeById(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtReadLeav = objDataLayerJobDetails.ReadLeavePaygradeById(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public DataTable ReadLeaveExprnsById(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtReadLeav = objDataLayerJobDetails.ReadLeaveExprnsById(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public void UpdateLeaveType(clsEntity_Leave_Type ObjEntityLeaveType, List<clsEntity_designation_list> ObjEntityLeaveDesignationList, List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList, List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList, List<clsEntity_Users_list> objEntityUser_List)
       {

           objDataLayerJobDetails.UpdateLeaveType(ObjEntityLeaveType, ObjEntityLeaveDesignationList, ObjEntityLeavPayGradeList, ObjEntityLeaveExpriencenOList, objEntityUser_List);

       }

       public DataTable ReadConfirmedLevAllocn(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           DataTable dtReadLeav = objDataLayerJobDetails.ReadConfirmedLevAllocn(ObjEntityLeaveType);
           return dtReadLeav;
       }



       public DataTable ReadLeaveTypeBySearch(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           DataTable dtReadLeav = objDataLayerJobDetails.ReadLeaveTypeBySearch(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public void CancelLeaveType(clsEntity_Leave_Type ObjEntityLeaveType)
      {

          objDataLayerJobDetails.CancelLeaveType(ObjEntityLeaveType);

      }

       public string CheckLeaveName(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           string count = objDataLayerJobDetails.CheckLeaveName(ObjEntityLeaveType);
           return count;
       }

       public void ReCallLeaveDetails(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           objDataLayerJobDetails.ReCallLeaveDetails(ObjEntityLeaveType);

       }

       public DataTable ReadDesignationUsers(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           DataTable dtReadLeav = objDataLayerJobDetails.ReadDesignationUsers(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public DataTable ReadPaygradeUsers(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           DataTable dtReadLeav = objDataLayerJobDetails.ReadPaygradeUsers(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public DataTable ReadExperienceUsers(clsEntity_Leave_Type ObjEntityLeaveType)
       {

           DataTable dtReadLeav = objDataLayerJobDetails.ReadExperienceUsers(ObjEntityLeaveType);
           return dtReadLeav;
       }
       public DataTable ReadExperienceUsersMore25(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtReadLeav = objDataLayerJobDetails.ReadExperienceUsersMore25(ObjEntityLeaveType);
           return dtReadLeav;
       }

       public DataTable ReadExperienceByID(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dtExperinc = objDataLayerJobDetails.ReadExperienceByID(ObjEntityLeaveType);
           return dtExperinc;
       }

       public string CheckLeavOnAbsnc(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           string count = objDataLayerJobDetails.CheckLeavOnAbsnc(ObjEntityLeaveType);
           return count;
       }

       public DataTable ReadIndividualLeavTypById(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadIndividualLeavTypById(ObjEntityLeaveType);
           return dt;
       }

       public void InsertUpdateDeleteIndividualLeavetyp(clsEntity_Leave_Type objEntityLeaveType, List<clsEntity_Leave_Type> ObjEntityLeaveTypeList, List<clsEntity_Leave_Type> ObjEntityLeaveTypeDeleteList, List<clsEntity_Leave_Type> ObjEntityLeaveTypeOverrideList)
       {
           objDataLayerJobDetails.InsertUpdateDeleteIndividualLeavetyp(objEntityLeaveType, ObjEntityLeaveTypeList, ObjEntityLeaveTypeDeleteList, ObjEntityLeaveTypeOverrideList);
       }

       public DataTable ReadEmpJoinDate(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadEmpJoinDate(ObjEntityLeaveType);
           return dt;
       }

       public DataTable ReadUserPaidLeaveType(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadUserPaidLeaveType(ObjEntityLeaveType);
           return dt;
       }

       public DataTable ReadUserLeavTypOverRide(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadUserLeavTypOverRide(ObjEntityLeaveType);
           return dt;
       }

       public DataTable ReadUserLeaveTypes(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadUserLeaveTypes(ObjEntityLeaveType);
           return dt;
       }

       public DataTable ReadOverRideDtlsByLeaveTypId(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadOverRideDtlsByLeaveTypId(ObjEntityLeaveType);
           return dt;
       }

       public DataTable ReadUserLeavTypDtlsByYr(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           DataTable dt = objDataLayerJobDetails.ReadUserLeavTypDtlsByYr(ObjEntityLeaveType);
           return dt;
       }

       public void InsertUserNewLevRow(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           objDataLayerJobDetails.InsertUserNewLevRow(ObjEntityLeaveType);
       }

       public void DeleteUserLeaveTypes(clsEntity_Leave_Type ObjEntityLeaveType)
       {
           objDataLayerJobDetails.DeleteUserLeaveTypes(ObjEntityLeaveType);
       }


    }
}


