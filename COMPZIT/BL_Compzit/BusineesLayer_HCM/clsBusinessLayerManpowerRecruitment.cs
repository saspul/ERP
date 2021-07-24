using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayerManpowerRecruitment
    {
       clsDataLayerManpowerRecruitment objDataLayerManpowerRecruitment = new clsDataLayerManpowerRecruitment();
       public void AddManpowerRecruitment(CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment)
        {
            objDataLayerManpowerRecruitment.AddManpowerRecruitment(ObjEntityManpowerRecruitment);

        }
       public void UpdateManpowerRecruitment(CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment)
       {
           objDataLayerManpowerRecruitment.UpdateManpowerRecruitment(ObjEntityManpowerRecruitment);
       }
       // ////Method of passing ManpowerRecruitment master table data from datalayer to ui layer
       public void CancelManpowerRecruitmentById(CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment)
       {
           objDataLayerManpowerRecruitment.CancelManpowerRecruitmentById(ObjEntityManpowerRecruitment);

       }
       // ////Method of cancelling 
        //public DataTable ReadManpowerRecruitmentById(CllsEntityManpowerRecruitment objEntityImigrationDtls)
        //{
        //    DataTable dtReadsupplier = objDataLayerManpowerRecruitment.ReadManpowerRecruitmentById(ObjEntityManpowerRecruitment);
        //    return dtReadsupplier;
        //}
        //public DataTable ReadManpowerRecruitmentList(CllsEntityManpowerRecruitment objEntityImigrationDtls)
        //{
        //    DataTable dtReadsupplier = objDataLayerManpowerRecruitment.ReadManpowerRecruitmentList(ObjEntityManpowerRecruitment);
        //    return dtReadsupplier;
        //}
       //fetch country 
       public DataTable ReadProject(CllsEntityManpowerRecruitment objEntityImigrationDtls)
       {
           DataTable dtProject = objDataLayerManpowerRecruitment.ReadProject(objEntityImigrationDtls);
           return dtProject;
       }
       public DataTable ReadPaygrade(CllsEntityManpowerRecruitment objEntityImigrationDtls)
       {
           DataTable dtPaygrade = objDataLayerManpowerRecruitment.ReadPaygrade(objEntityImigrationDtls);
           return dtPaygrade;
       }

       public DataTable ReadIndenter(CllsEntityManpowerRecruitment objEntityImigrationDtls)
       {
           DataTable dtIndenter = objDataLayerManpowerRecruitment.ReadIndenter(objEntityImigrationDtls);
           return dtIndenter;
       }
          public DataTable ReadManpowerRecruitment(CllsEntityManpowerRecruitment objEntityImigrationDtls)
       {
           DataTable dtManpower = objDataLayerManpowerRecruitment.ReadManpowerRecruitment(objEntityImigrationDtls);
           return dtManpower;
       }
          public void ChangeEntryStatus(CllsEntityManpowerRecruitment objEntityImigrationDtls)
          {
              objDataLayerManpowerRecruitment.ChangeEntryStatus(objEntityImigrationDtls);
             
          }
          public DataTable ReadManpowerRecruitmentId(CllsEntityManpowerRecruitment objEntityImigrationDtls)
          {
              DataTable dtManpower = objDataLayerManpowerRecruitment.ReadManpowerRecruitmentId(objEntityImigrationDtls);
              return dtManpower;
          }
          public DataTable ReadManpower_search(CllsEntityManpowerRecruitment objEntityMnpwrrMstr)
          {
              DataTable dtManpower = objDataLayerManpowerRecruitment.ReadManpower_search(objEntityMnpwrrMstr);
              return dtManpower;

          }
          public void Confirm(CllsEntityManpowerRecruitment objEntityImigrationDtls)
          {
              objDataLayerManpowerRecruitment.Confirm(objEntityImigrationDtls);

          }
          public void Verify(CllsEntityManpowerRecruitment objEntityImigrationDtls)
          {
              objDataLayerManpowerRecruitment.Verify(objEntityImigrationDtls);

          }
          public void Approve(CllsEntityManpowerRecruitment objEntityImigrationDtls)
          {
              objDataLayerManpowerRecruitment.Approve(objEntityImigrationDtls);

          }
          public string GetEmployeeCount(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
          {
              clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
              string strReturn = objDataLayerManpowerRecruitment.GetEmployeeCount(objEntityEntityJobDetails);

              return strReturn;
          }
          public DataTable ReadDesignation(CllsEntityManpowerRecruitment objEntityImigrationDtls)
       {
           DataTable dtIndenter = objDataLayerManpowerRecruitment.ReadDesignation(objEntityImigrationDtls);
           return dtIndenter;
       }
          public void ProcessStatus(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
          {
              objDataLayerManpowerRecruitment.ChangeProcessStatus(objEntityEntityJobDetails);

          
          }
          public void Close(CllsEntityManpowerRecruitment objEntityEntityJobDetails)
          {
              objDataLayerManpowerRecruitment.Close(objEntityEntityJobDetails);


          }
          public DataTable ReadDivision(CllsEntityManpowerRecruitment ObjEntityManPwrRqmnt)   //emp25
          {
              DataTable dtReadManPowr = objDataLayerManpowerRecruitment.ReadDivision(ObjEntityManPwrRqmnt);
              return dtReadManPowr;
          }
    }
}
