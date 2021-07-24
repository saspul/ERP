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
   public class ClsBussiness_Passport_Handover_Sts
    {
       ClsData_Passport_Hand_Over_Sts objDataPassport = new ClsData_Passport_Hand_Over_Sts();

       public DataTable ReadDivision(ClsEntity_Passport_Handover_Sts objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadDivision(objentityPassport);
            return dtGuarnt;
        }
       public DataTable ReadDepartment(ClsEntity_Passport_Handover_Sts objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadDepartment(objentityPassport);
            return dtGuarnt;
        }
       public DataTable ReadDesignation(ClsEntity_Passport_Handover_Sts objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadDesignation(objentityPassport);
            return dtGuarnt;
        }
       public DataTable ReadEmployee(ClsEntity_Passport_Handover_Sts objentityPassport)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPassport.ReadEmployee(objentityPassport);
           return dtGuarnt;
       }
       public DataTable ReadEmployeepassportList(ClsEntity_Passport_Handover_Sts objentityPassport)
       {
           DataTable dtDetail = objDataPassport.ReadEmployeepassportList(objentityPassport);
           return dtDetail;
       }
       public DataTable ReadDivisionOfEmp(ClsEntity_Passport_Handover_Sts objentityPassport)
       {
           DataTable dtDetail = objDataPassport.ReadDivisionOfEmp(objentityPassport);
           return dtDetail;
       }
       public void AddPassportdate(ClsEntity_Passport_Handover_Sts objentityPassport, List<clsEntity_Passport_Handover_Stslist> objEntityuseridlist)
       {
           objDataPassport.AddPassportdate(objentityPassport, objEntityuseridlist);
       }


       public DataTable ReadCorporateAddress(ClsEntity_Passport_Handover_Sts objentityPassport)
       {
         
           DataTable dtCorp = new DataTable();
           dtCorp = objDataPassport.ReadCorporateAddress(objentityPassport);
           return dtCorp;

       }
    }
}
