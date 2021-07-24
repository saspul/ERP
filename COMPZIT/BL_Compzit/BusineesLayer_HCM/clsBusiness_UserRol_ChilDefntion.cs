using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusiness_UserRol_ChilDefntion
    {
       clsData_UserRol_ChilDefntion objData = new clsData_UserRol_ChilDefntion();


       public DataTable ReadEmployeOnLeave(clsEntity_UserRol_ChilDefntion objEntity)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objData.ReadEmployeOnLeave(objEntity);
            return dtGuarnt;
        }
       public DataTable ReadEmployee(clsEntity_UserRol_ChilDefntion objEntity)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.ReadEmployee(objEntity);
           return dtGuarnt;
       }
       public DataTable UserRolesDetails(clsEntity_UserRol_ChilDefntion objEntity)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.UserRolesDetails(objEntity);
           return dtGuarnt;
       }

 
       public DataTable UserRolesDtlsAsssingnedUser(clsEntity_UserRol_ChilDefntion objEntity)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.UserRolesDtlsAsssingnedUser(objEntity);
           return dtGuarnt;
       }

       public void InsertChildRoles(List<clsEntity_UserRol_ChilDefntion> objEntity)
       {

           objData.InsertChildRoles(objEntity);

       }

       public DataTable ReadUserFromChildRolProvsn(clsEntity_UserRol_ChilDefntion objEntity)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.ReadUserFromChildRolProvsn(objEntity);
           return dtGuarnt;
       }

       public void UserRolesDeleteByAssgnUserid(clsEntity_UserRol_ChilDefntion objEntity)
       {

           objData.UserRolesDeleteByAssgnUserid(objEntity);

       }

       public DataTable ReadUserRolProvsn(clsEntity_UserRol_ChilDefntion objEntity)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.ReadUserRolProvsn(objEntity);
           return dtGuarnt;
       }
       
       
    }
}
