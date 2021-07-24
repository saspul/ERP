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
   public class clsBusiness_Job_Description_Master
    {
       clsData_Job_Description_Master objDataJobDescrptn = new clsData_Job_Description_Master();

       public DataTable ReadDivision(clsEntity_Job_Description_Master objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadDivision(objEntityjob);
            return dtGuarnt;
        }
       public DataTable ReadDepartment(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadDepartment(objEntityjob);
           return dtGuarnt;
       }
       public DataTable ReadPayGrade(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadPayGrade(objEntityjob);
           return dtGuarnt;
       }

       public DataTable ReadDesignation(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadDesignation(objEntityjob);
           return dtGuarnt;
       }
       public DataTable ReadDesignationReport(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadDesignationReport(objEntityjob);
           return dtGuarnt;
       }
       
       public void AddJobDescptn(clsEntity_Job_Description_Master objEntityjob)
       {
  
         objDataJobDescrptn.AddJobDescptn(objEntityjob);
        
       }
       public void CancelJobDesrp(clsEntity_Job_Description_Master objEntityjob)
       {

           objDataJobDescrptn.CancelJobDesrp(objEntityjob);

       }

       public DataTable ReadJobDesList(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadJobDesList(objEntityjob);
           return dtGuarnt;
       }
       public DataTable ReadJobDescrpnById(clsEntity_Job_Description_Master objEntityjob)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataJobDescrptn.ReadJobDescrpnById(objEntityjob);
           return dtGuarnt;
       }

       public void UpdateJobDescptn(clsEntity_Job_Description_Master objEntityjob)
       {

           objDataJobDescrptn.UpdateJobDescptn(objEntityjob);

       }

    }
}
