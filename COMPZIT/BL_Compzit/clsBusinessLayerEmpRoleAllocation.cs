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
namespace BL_Compzit
{
   public class clsBusinessLayerEmpRoleAllocation
    {
       clsDataLayerEmpRoleAllocation objDataEmpRoleAllocation = new clsDataLayerEmpRoleAllocation();
        //Method for passing designation details from datalayer to uilayer.
       public DataTable ReadDesignation(int orgId, int userId)
        {
            DataTable dtReadCountry = objDataEmpRoleAllocation.ReadDesignation(orgId, userId);
            return dtReadCountry;
        }
       //Method for passing jobrole details from datalayer to uilayer.
       public DataTable ReadJobRole(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtJobrole = objDataEmpRoleAllocation.ReadJobRole(objEmpRoleAllocation);
           return dtJobrole;
       }
       //Method for passing employee details from datalayer to uilayer.
       public DataTable ReadEmployee(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtJobrole = objDataEmpRoleAllocation.ReadEmployee(objEmpRoleAllocation);
           return dtJobrole;
       }
       //Method for binding compzit modules
       public DataTable DisplayCompzitModuleByUsrId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtJobrole = objDataEmpRoleAllocation.DisplayCompzitModuleByUsrId(objEmpRoleAllocation);
           return dtJobrole;
       }
       //Method of passing employee id for finding designation Control from datalayer to uilayer.
       public char ReadDsgnControl(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           char charControl = Convert.ToChar(objDataEmpRoleAllocation.ReadDsgnControl(objEmpRoleAllocation));
           return charControl;
       }
       // This Method for   IF User is LIMITED OR NOT.
       public DataTable ReadIfUserLimitedByUsrId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadUsrMstr = objDataEmpRoleAllocation.ReadIfUserLimitedByUsrId(objEmpRoleAllocation);
           return dtReadUsrMstr;
       }
       //Fetch  displays USROL MASTR details from the database for showing in TREE
       public DataTable DisplayUserolMstr(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadUsrolMstr = objDataEmpRoleAllocation.DisplayUserolMstr(objEmpRoleAllocation);
           return dtReadUsrolMstr;
       }
       public DataTable DisplayUserolMstrFramewrk(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadUsrolMstr = objDataEmpRoleAllocation.DisplayUserolMstrFramewrk(objEmpRoleAllocation);
           return dtReadUsrolMstr;
       }
       //Fetch Designation master table from datalayer according to the id and pass to the ui layer. 
       public DataTable ReadDsgnMasterEdit(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadDsgnMstrEdit = objDataEmpRoleAllocation.ReadDsgnMasterEdit(objEmpRoleAllocation);
           return dtReadDsgnMstrEdit;
       }
       //Fetch Designation App Role master table from datalayer according to the id and pass to the ui layer. 
       public DataTable ReadDsgnAppRoleByDsgnId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadDsgnAppMstrEdit = objDataEmpRoleAllocation.ReadDsgnAppRoleByDsgnId(objEmpRoleAllocation);
           return dtReadDsgnAppMstrEdit;
       }
       //Method of passing next value for insertion from datalayer to uilayer.
       public DataTable ReadNextId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadnextId = objDataEmpRoleAllocation.ReadNextId(objEmpRoleAllocation);
           return dtReadnextId;
       }
       //Method passing all details of newly registering Designation from ui layer to datalayer.
       public void InsertEmpRlDetail(clsEntityEmpRoleAllocation objEmpRoleAllocation, List<clsEntityLayerEmployeeRole> objlisDsgnRolDtls, List<clsEntityLayerEmployeeAppRole> objlisDsgnAppRolDtls)
       {

           objDataEmpRoleAllocation.InsertEmpRlDetail(objEmpRoleAllocation, objlisDsgnRolDtls, objlisDsgnAppRolDtls);
       }
       //Method for passing employee list search from datalayer to uilayer.
       public DataTable ReadEmproleList(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtJobrole = objDataEmpRoleAllocation.ReadEmproleList(objEmpRoleAllocation);
           return dtJobrole;
       }
       public DataTable ReadEmpRLMasterById(clsEntityEmpRoleAllocation objEmpRoleAllocation)
       {
           DataTable dtReadDsgnMstrEdit = objDataEmpRoleAllocation.ReadEmpRLMasterById(objEmpRoleAllocation);
           return dtReadDsgnMstrEdit;
       }
       //Update JobRl Detail
       public void UpdateEmpRlDetail(clsEntityEmpRoleAllocation objEmpRoleAllocation, List<clsEntityLayerEmployeeRole> objlisDsgnRolDtls, List<clsEntityLayerEmployeeAppRole> objlisDsgnAppRolDtls)
       {

           objDataEmpRoleAllocation.UpdateEmpRlDetail(objEmpRoleAllocation, objlisDsgnRolDtls, objlisDsgnAppRolDtls);
       }
    }
}
