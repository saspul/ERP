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


namespace BL_Compzit.BusinessLayer_AWMS
{
  public class clsBusinessLayerJobMaster
  {
      clsDataLayerJobMaster objDataJob = new clsDataLayerJobMaster();
      // This Method adds job details to the table
      public void AddJobDetails(clsEntityLayerJobMaster objEntityjob)
      {
          objDataJob.AddJobDetails(objEntityjob);

      }
      // This Method update job details to the table
      public void UpdateJobDetails(clsEntityLayerJobMaster objEntityjob)
      {
          objDataJob.UpdateJobDetails(objEntityjob);
      }

      // This Method checks job name in the database for duplication.
      public string CheckJobTitle(clsEntityLayerJobMaster objEntityjob)
      {

          string count = objDataJob.CheckJobTitle(objEntityjob);
          return count;
      }
      //Method for cancel job
      public void CancelJobTitle(clsEntityLayerJobMaster objEntityjob)
      {

          objDataJob.CancelJobTitle(objEntityjob);
      }

      // This Method will fetCH job DEATILS BY ID
      public DataTable ReadJobTitleById(clsEntityLayerJobMaster objEntityjob)
      {
          DataTable dtAccodetails = objDataJob.ReadJobTitleById(objEntityjob);
          return dtAccodetails;
      }
      // This Method will fetch job details list
      public DataTable ReadJobTitleList(clsEntityLayerJobMaster objEntityjob)
      {
          DataTable dtAccodetails = objDataJob.ReadJobTitleList(objEntityjob);
          return dtAccodetails;
      }


      // This Method recll job details to the table
      public void ReCalljob(clsEntityLayerJobMaster objEntityjob)
      {
          objDataJob.ReCalljob(objEntityjob);
      }

      public void ChangeStatus(clsEntityLayerJobMaster objJob)
      {
          objDataJob.ChangeStatus(objJob);
      }

  }
}
