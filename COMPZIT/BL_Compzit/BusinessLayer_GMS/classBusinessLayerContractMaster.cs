using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class classBusinessLayerContractMaster
    {
        classDatalayerContractMaster objDataContract = new classDatalayerContractMaster();
        // This Method will fetCH projects
        public DataTable ReadProjects(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtProjects = new DataTable();
            dtProjects = objDataContract.ReadProjects(objEntityCntrct);
            return dtProjects;
        }
        // This Method will fetCH contract category
        public DataTable ReadContractCategory(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtCategory = new DataTable();
            dtCategory = objDataContract.ReadContractCategory(objEntityCntrct);
            return dtCategory;
        }
                // This Method will fetCH JOB category
        public DataTable ReadJobCategory(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtCategory = new DataTable();
            dtCategory = objDataContract.ReadJobCategory(objEntityCntrct);
            return dtCategory;
        }
                    // This Method will fetCH JOB category
        public DataTable ReadContractor(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtCategory = new DataTable();
            dtCategory = objDataContract.ReadContractor(objEntityCntrct);
            return dtCategory;
        }
                // This Method will fetCH JOB category
        public DataTable ReadParentContract(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtCategory = new DataTable();
            dtCategory = objDataContract.ReadParentContract(objEntityCntrct);
            return dtCategory;
        }
        // This Method adds job category details to the table
        public string AddContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strId = "";
            strId=objDataContract.AddContract(objEntityCntrct);
            return strId;
        }
        public void UpdateContract(classEntityLayerContractMaster objEntityCntrct)
        {
            objDataContract.UpdateContract(objEntityCntrct);
        }
        public void ChangeContractStatus(classEntityLayerContractMaster objEntityCntrct)
        {
            objDataContract.ChangeContractStatus(objEntityCntrct);
        }
         // This Method checks job category name in the database for duplication.
        public string CheckContractName(classEntityLayerContractMaster objEntityCntrct)
        {
            string strReturn = objDataContract.CheckContractName(objEntityCntrct);
            return strReturn;
        }
                // This Method checks job category name in the database for duplication.
        public string CheckContractCode(classEntityLayerContractMaster objEntityCntrct)
        {
            string strReturn = objDataContract.CheckContractCode(objEntityCntrct);
            return strReturn;
        }
         //Method for cancel job category
        public void CancelContract(classEntityLayerContractMaster objEntityCntrct)
        {
            objDataContract.CancelContract(objEntityCntrct);
        }
         //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        public void ReCallContract(classEntityLayerContractMaster objEntityCntrct)
        {
            objDataContract.ReCallContract(objEntityCntrct);
        }
         // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadContractById(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtContract = new DataTable();
            dtContract = objDataContract.ReadContractById(objEntityCntrct);
            return dtContract;
        }
         // This Method will fetch job category list
        public DataTable ReadContractList(classEntityLayerContractMaster objEntityCntrct)
        {
            DataTable dtContract = new DataTable();
            dtContract = objDataContract.ReadContractList(objEntityCntrct);
            return dtContract;
        }
          
    }
}
