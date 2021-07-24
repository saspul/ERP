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
    public class clsBusinessLayerInsuranceAndPermitExp
    {
        // This Method will fetch expired insurance and permit 
        public DataTable ReadInsuranceAndPermitExpDate(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtInsrnc = ObjDataInsrnc.ReadInsuranceAndPermitExpDate(objEntityInsAndPrmt);
            return dtInsrnc;
        }

        // This Method will fetCH vehicle renewal type details  BY ID
        public DataTable ReadVehicleRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewal = ObjDataInsrnc.ReadVehicleRenewal(objEntityInsAndPrmt);
            return dtVehRenewal;
        }

        // This Method will fetch expired insurance and permit as on date
        public DataTable ReadInsuranceAndPermitAsOnDate(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtInsrnc = ObjDataInsrnc.ReadInsuranceAndPermitAsOnDate(objEntityInsAndPrmt);
            return dtInsrnc;
        }

        // This Method will fetch expired insurance details as on date
        public DataTable ReadExpVehicleDetails(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtInsrnc = ObjDataInsrnc.ReadExpVehicleDetails(objEntityInsAndPrmt);
            return dtInsrnc;
        }

        // This Method adds insurance renewal details to the table
        public void InsertInsurnceRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.InsertInsurnceRenewal(objEntityInsAndPrmt, objEntityRnwlAttchmntDeatilsList);
        }
        
        // This Method adds permit renewal details to the table
        public void InsertPermtRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.InsertPermtRenewal(objEntityInsAndPrmt, objEntityRnwlAttchmntDeatilsList);
        }
                //Method for CANCEL insurance renewal table 
        public void CancelInsuranceRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.CancelInsuranceRenewal(objEntityInsAndPrmt);
        }
        //Method for CANCEL PERMIT renewal table 
        public void CancelPermitRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.CancelPermitRenewal(objEntityInsAndPrmt);
        }
        // This Method will fetCH vehicle renewal type details
        public DataTable ReadVehicleNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewal = ObjDataInsrnc.ReadVehicleNumber(objEntityInsAndPrmt);
            return dtVehRenewal;
        }

        // This Method will fetCH insuranced provider id type details
        public DataTable ReadInsurncPrvdrId(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewal = ObjDataInsrnc.ReadInsurncPrvdrId(objEntityInsAndPrmt);
            return dtVehRenewal;
        }
                // This Method will fetCH insurance provider id
        public DataTable ReadRenewalListBySearch(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadRenewalListBySearch(objEntityInsAndPrmt);
            return dtVehRenewalList;
        }
        // This Method checks PERMIT NUMBER in the database for duplication.
        public string CheckPermitNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            string dupname = ObjDataInsrnc.CheckPermitNumber(objEntityInsAndPrmt);
            return dupname;
        }

        // This Method checks PERMIT NUMBER in the database for duplication.
        public string CheckInsuranceNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            string dupname = ObjDataInsrnc.CheckInsuranceNumber(objEntityInsAndPrmt);
            return dupname;
        }
        public DataTable ReadPermtRnwlFiles(clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadPermtRnwlFiles(objEntityAttchmntDtl);
            return dtVehRenewalList;
        }
        public DataTable ReadInsurRnwlFiles(clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadInsurRnwlFiles(objEntityAttchmntDtl);
            return dtVehRenewalList;
        }
        public DataTable ReadPermitRnwlId(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadPermitRnwlId(objEntityInsAndPrmt);
            return dtVehRenewalList;
        }
        public DataTable ReadPermitFiles(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadPermitFiles(objEntityInsAndPrmt);
            return dtVehRenewalList;
        }
        public DataTable ReadInsurFiles(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtVehRenewalList = ObjDataInsrnc.ReadInsurFiles(objEntityInsAndPrmt);
            return dtVehRenewalList;
        }

        public void CancelInsuranceRenewalTR(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.CancelInsuranceRenewalTR(objEntityInsAndPrmt);
        }
        public void CancelPermitRenewalTR(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            ObjDataInsrnc.CancelPermitRenewalTR(objEntityInsAndPrmt);
        }


        //evm-0027
        public DataTable ReadInsuranceAndPermit(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            clsDataLayerInsuranceAndPermitRenewal ObjDataInsrnc = new clsDataLayerInsuranceAndPermitRenewal();
            DataTable dtInsrnc = ObjDataInsrnc.ReadInsuranceAndPermit(objEntityInsAndPrmt);
            return dtInsrnc;
        }

        
        //end

    }
}
