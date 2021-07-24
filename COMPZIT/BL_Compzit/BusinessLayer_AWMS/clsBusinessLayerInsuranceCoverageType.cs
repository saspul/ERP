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
    public class clsBusinessLayerInsuranceCoverageType
    {
        // This Method adds coverage type details to the table
        public void AddCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            ObjDataCoverageType.AddCoverageType(objEntityCoverageType);

        }
        // This Method update vehical class details to the table
        public void UpdateCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            ObjDataCoverageType.UpdateCoverageType(objEntityCoverageType);
        }

        // This Method checks coverage type name in the database for duplication.
        public string CheckCoverageTypeName(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            string count = ObjDataCoverageType.CheckCoverageTypeName(objEntityCoverageType);
            return count;
        }
        //Method for cancel vehical class
        public void CancelCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            ObjDataCoverageType.CancelCoverageType(objEntityCoverageType);
        }
        //Method for Recall vehical class
        public void RecallCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            ObjDataCoverageType.RecallCoverageType(objEntityCoverageType);
        }
        // This Method will fetCH category type DEATILS BY ID
        public DataTable ReadCoverageTypeById(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            DataTable dtAccodetails = ObjDataCoverageType.ReadCoverageTypeById(objEntityCoverageType);
            return dtAccodetails;
        }
        // This Method will fetch vehical class list
        public DataTable ReadCoverageTypeList(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            clsDataLayerInsuranceCoverageType ObjDataCoverageType = new clsDataLayerInsuranceCoverageType();
            DataTable dtAccodetails = ObjDataCoverageType.ReadCoverageTypeList(objEntityCoverageType);
            return dtAccodetails;
        }
        
    }
}
