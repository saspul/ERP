using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
  public  class ClsBusiness_Employee_Recruitment_Report
    {
      public DataTable ReadEmployeeRecruitment(ClsEntity_HCM_Common objEntityLayerHcmCommon)
      {
          ClsDataLayer_Employee_Recruitment_Report objDataEmployeeRecruitment = new ClsDataLayer_Employee_Recruitment_Report();
          DataTable dtVisaQuota = new DataTable();
          dtVisaQuota = objDataEmployeeRecruitment.ReadEmployeeRecruitment(objEntityLayerHcmCommon);
          return dtVisaQuota;
      }

      public DataTable ReadEmployeeRecruitmentById(ClsEntity_HCM_Common objEntityLayerHcmCommon)
      {
          ClsDataLayer_Employee_Recruitment_Report objDataEmployeeRecruitment = new ClsDataLayer_Employee_Recruitment_Report();
          DataTable dtVisaDtls = new DataTable();
          dtVisaDtls = objDataEmployeeRecruitment.ReadEmployeeRecruitmentById(objEntityLayerHcmCommon);
          return dtVisaDtls;
      }


      public DataTable ReadCorporateAddress(ClsEntity_HCM_Common objEntityLayerHcmCommon)
      {
          ClsDataLayer_Employee_Recruitment_Report objDataEmployeeRecruitment = new ClsDataLayer_Employee_Recruitment_Report();
          DataTable dtCorp = new DataTable();
          dtCorp = objDataEmployeeRecruitment.ReadCorporateAddress(objEntityLayerHcmCommon);
          return dtCorp;

      }



    }
}
