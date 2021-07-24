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
   public class ClsBusiness_Experiance_Certificate
    {


       ClsDataLayer_Experiance_Certificate objLeavFacltyAssmnt = new ClsDataLayer_Experiance_Certificate();
       public DataTable ReadEmployee(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployee(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadLevEmplyById(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadLevEmplyById(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadDivisionOfEmp(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadDivisionOfEmp(objEntityOnBoarding);
           return dtDetail;
       }

       public DataTable ReadEmpFather(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadEmpFather(objEntityOnBoarding);
           return dtDetail;
       }


       public DataTable ReadJoinLevDate(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadJoinLevDate(objEntityOnBoarding);
           return dtDetail;
       }
       public void InsertempCertGerndtls(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
           objLeavFacltyAssmnt.InsertempCertGerndtls(objEntityOnBoarding);
        
       }
       public DataTable ReadEmployList(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployList(objEntityOnBoarding);
           return dtDetail;
       }

       public void UpdateempCertGerndtls(ClsEntity_Experiance_Certificate objEntityOnBoarding)
       {
      objLeavFacltyAssmnt.UpdateempCertGerndtls(objEntityOnBoarding);
         
       }

       public DataTable ReadEmployeeCrtfct(ClsEntity_Experiance_Certificate objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployeeCrtfct(objEntityOnBoarding);
            return dtDetail;
        }
       
    }
}
