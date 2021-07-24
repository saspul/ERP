using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
  public  class clsBusiness_ImmigrationTaskReport
    {
      clsData_ImmigrationTaskReport objDataVisaQuota = new clsData_ImmigrationTaskReport();
      public DataTable ReadImgratnRnd(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadImgratnRnd(objEntityVisaQuot);
          return dtGuarnt;
      }
      public DataTable ReadCandidate(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadCandidate(objEntityVisaQuot);
          return dtGuarnt;
      }

      public DataTable ReadProject(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadProject(objEntityVisaQuot);
          return dtGuarnt;
      }

      public DataTable ReadEmployee(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadEmployee(objEntityVisaQuot);
          return dtGuarnt;
      }
      public DataTable ReadEmployeebyDtlId(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadEmployeebyDtlId(objEntityVisaQuot);
          return dtGuarnt;
      }
      public DataTable ReadImmigrationTask(clsEntity_ImmigrationTaskReport objEntityVisaQuot)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataVisaQuota.ReadImmigrationTask(objEntityVisaQuot);
          return dtGuarnt;
      }
      public DataTable ReadCorporateAddress(clsEntity_ImmigrationTaskReport objEntityLayerManpwr)
      {
          DataTable dtCorp = new DataTable();
          dtCorp = objDataVisaQuota.ReadCorporateAddress(objEntityLayerManpwr);
          return dtCorp;
      }
      public DataTable readCandidateById(clsEntity_ImmigrationTaskReport objEntityLayerManpwr)
      {
          DataTable dtCorp = new DataTable();
          dtCorp = objDataVisaQuota.readCandidateById(objEntityLayerManpwr);
          return dtCorp;
      }
    }
}
