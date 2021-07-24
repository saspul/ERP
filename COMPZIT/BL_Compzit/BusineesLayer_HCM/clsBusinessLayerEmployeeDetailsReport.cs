using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayerEmployeeDetailsReport
    {
       clsDataLayerEmployeeDetailsReport objDataEmployeeDetailsReport = new clsDataLayerEmployeeDetailsReport();
       public DataTable ReadEmployeeList(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtDiv = objDataEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);
           return dtDiv;
       }
       public DataTable ReadDivisionOfEmp(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtDiv = objDataEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);
           return dtDiv;
       }
       public DataTable ReadDivision(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtProject = objDataEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);
           return dtProject;
       }
       public DataTable readCountry()
       {
           DataTable dtPaygrade = objDataEmployeeDetailsReport.readCountry();
           return dtPaygrade;
       }
       public DataTable ReadProject(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadDesignation(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadDesignation(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadDepartment(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadDepartment(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadPaygrade(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadPaygrade(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable readReligion()
       {
           DataTable dtPaygrade = objDataEmployeeDetailsReport.readReligion();
           return dtPaygrade;
       }
       public DataTable ReadEmpDetailsById(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadEmpDetailsById(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadProjectDetails(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadCorporateAddress(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadCorporateAddress(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
       public DataTable ReadLeave(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
       {
           DataTable dtIndenter = objDataEmployeeDetailsReport.ReadLeave(objEntityEmployeeDetailsreport);
           return dtIndenter;
       }
    }
}
