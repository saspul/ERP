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
// CREATED BY:EVM-0005
// CREATED DATE:18/10/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerVehicleMaster
    {
        // This Method will fetch vehicle class details
        public DataTable ReadVehicleClass(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehicleClass = objDataLayerVehicle.ReadVehicleClass(ObjVehicle);
            return dtReadVehicleClass;
        }
          // This Method will fetch fuel type details
        public DataTable ReadFuelType(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadFuelType = objDataLayerVehicle.ReadFuelType(ObjVehicle);
            return dtReadFuelType;
        }
                // This Method will fetch fuel type details
        public DataTable ReadRegistrationType()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadFuelType = objDataLayerVehicle.ReadRegistrationType();
            return dtReadFuelType;
        }
           
           // This Method will fetch INSURANCE provider details
        public DataTable ReadInsuranceProvider(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadInsProvider = objDataLayerVehicle.ReadInsuranceProvider(ObjVehicle);
            return dtReadInsProvider;
        }
                // This Method will fetch INSURANCE provider details
        public DataTable ReadVehicleType()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.ReadVehicleType();
            return dtReadVehType;
        }
                // This Method adds VEHICLE MSTER details to the table
        public void AddVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.AddVehicleMaster(ObjVehicle, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerAttchmntDeatilsListTR, objEntityInsAttchmntDeatilsListTR);
        }
                // This Method adds VEHICLE MASTER details to the table
        public void UpdateVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsListTR)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.UpdateVehicleMaster(ObjVehicle, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerDeleteAttchmntDeatilsList, objEntityInsDeleteAttchmntDeatilsList, objEntityVhclDeleteAttchmntDeatilsList, objEntityPerAttchmntDeatilsListTR, objEntityInsAttchmntDeatilsListTR, objEntityPerDeleteAttchmntDeatilsListTR, objEntityInsDeleteAttchmntDeatilsListTR);
        }
                // This Method checks VEHICLE NUMBER in the database for duplication.
        public string CheckVehicleNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname= objDataLayerVehicle.CheckVehicleNumber(ObjVehicle);
            return dupname;
        }
                // This Method checks PERMIT NUMBER in the database for duplication.
     /*  public string CheckPermitNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckPermitNumber(ObjVehicle);
            return dupname;
        }*/
                // This Method checks CHASE NUMBER in the database for duplication.
        public string CheckChasisNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckChasisNumber(ObjVehicle);
            return dupname;
        }
                // This Method checks INSURANCE NUMBER in the database for duplication.
        public string CheckInsuranceNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckInsuranceNumber(ObjVehicle);
            return dupname;
        }

         // This Method checks INSURANCE NUMBER in the database for duplication.
        public string CheckRF_IdNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckRF_IdNumber(ObjVehicle);
            return dupname;
        }


                //Method for cancel vehicle master
        public void CancelVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.CancelVehicleMaster(ObjVehicle);
        }
        
                //Method for cancel vehicle master
        public void RecallVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.RecallVehicleMaster(ObjVehicle);
        }
        // This Method will fetch vehicle DEATILS BY ID
        public DataTable ReadVehicleDetailsById(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVehicleDetailsById(ObjVehicle);
            return dtReadvehiclemaster;
        }
                // This Method will fetch vehicle master list
        public DataTable ReadVehicleMasterList(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVehicleMasterList(ObjVehicle);
            return dtReadvehiclemaster;
        }
                // This Method will fetch vehicle list BY SEARCH
        public DataTable ReadVehicleMasterListBySearch(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVehicleMasterListBySearch(ObjVehicle);
            return dtReadvehiclemaster;
        }
               // This Method will fetch attachment list
        public DataTable ReadVehicleMasterAttachment(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVehicleMasterAttachment(ObjVehicle);
            return dtReadvehiclemaster;
        }
                // This Method will fetch attachment list
        public void DeleteVehicleMasterAttachment(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.DeleteVehicleMasterAttachment(ObjVehicle);
        }

                // This Method will fetch attachment list
        public DataTable ReadInsuranceRenew(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadInsuranceRenew(ObjVehicle);
            return dtReadvehiclemaster;
        }

                // This Method will fetch attachment list
        public DataTable ReadPermitRenew(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadPermitRenew(ObjVehicle);
            return dtReadvehiclemaster;
        }
        //for fetch permit attachment files
        public DataTable ReadPermtFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtVehRenewalList = objDataLayerVehicle.ReadPermtFiles(ObjVehicle);
            return dtVehRenewalList;
        }
        //for fetch insurance attachment files
        public DataTable ReadInsurFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtVehRenewalList = objDataLayerVehicle.ReadInsurFiles(ObjVehicle);
            return dtVehRenewalList;
        }
        //for fetch vehicle attachment files
        public DataTable ReadVehicleFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtVehRenewalList = objDataLayerVehicle.ReadVehicleFiles(ObjVehicle);
            return dtVehRenewalList;
        }
        // This Method will fetch vehicle transmission type details
        public DataTable ReadVhclTransmsn()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.ReadVhclTransmsn();
            return dtReadVehType;
        }
        // This Method will fetch vehicle make type details
        public DataTable ReadVhclMake()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.ReadVhclMake();
            return dtReadVehType;
        }

        // This Method will fetch color details
        public DataTable ReadVhclColor()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.ReadVhclColor();
            return dtReadVehType;
        }
        // This Method will fetch insurance coverage type datails
        public DataTable ReadInsCoverageType()
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.ReadInsCoverageType();
            return dtReadVehType;
        }
        public string readVhclClassID(string strVhclClassName)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intVhclClassName = objDataLayerVehicle.readVhclClassID(strVhclClassName);
            return intVhclClassName;
        }
        public string readFuelTypeID(string strFuelType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intFuelTypeId = objDataLayerVehicle.readFuelTypeID(strFuelType);
            return intFuelTypeId;
        }
        public string readRegTypeID(string strRegType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intRegTypeId = objDataLayerVehicle.readRegTypeID(strRegType);
            return intRegTypeId;
        }
        public string readOwnershipID(string strOwnershipType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intOwnershipId = objDataLayerVehicle.readOwnershipID(strOwnershipType);
            return intOwnershipId;
        }
        public string readInsurPrvdrID(string strInsurPrvdr)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intInsurPrvdrId = objDataLayerVehicle.readInsurPrvdrID(strInsurPrvdr);
            return intInsurPrvdrId;
        }
        public string readInsurCovrgTypeID(string strInsurCovrgType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intCovrgTypeId = objDataLayerVehicle.readInsurCovrgTypeID(strInsurCovrgType);
            return intCovrgTypeId;
        }
        public void AddVehicleList(List<clsEntityLayerVehicleMaster> objEntityVhclList)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            objDataLayerVehicle.AddVehicleList(objEntityVhclList);
        }
        public string CheckTrailerNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckTrailerNumber(ObjVehicle);
            return dupname;
        }
        public string CheckTrailerInsNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string dupname = objDataLayerVehicle.CheckTrailerInsNumber(ObjVehicle);
            return dupname;
        }
        public DataTable readCategoryType(int vhclclsId)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadVehType = objDataLayerVehicle.readCategoryType(vhclclsId);
            return dtReadVehType;
        }
        public DataTable ReadVehicleSts(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVehicleSts(ObjVehicle);
            return dtReadvehiclemaster;
        }
        public DataTable readVhclClassName(string strVhclClassName)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readVhclClassName(strVhclClassName);
            return dtReadvehiclemaster;
        }
        public DataTable readFuelTypeName(string strFuelType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readFuelTypeName(strFuelType);
            return dtReadvehiclemaster;
        }
        public DataTable readRegTypeName(string strRegType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readRegTypeName(strRegType);
            return dtReadvehiclemaster;
        }
        public DataTable readOwnershipName(string strOwnershipType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readOwnershipName(strOwnershipType);
            return dtReadvehiclemaster;
        }
        public DataTable readInsurPrvdrName(string strInsurPrvdr)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readInsurPrvdrName(strInsurPrvdr);
            return dtReadvehiclemaster;
        }
        public DataTable readInsurCovrgTypeName(string strInsurCovrgType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readInsurCovrgTypeName(strInsurCovrgType);
            return dtReadvehiclemaster;
        }
        // This Method checks VehicleId in use or not(DutyRoster)
        public string CheckDutyRoster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string strReturn = objDataLayerVehicle.CheckDutyRoster(ObjVehicle);
            return strReturn;
        }

        public DataTable readVhclClassDtls(string strVhclClass)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readVhclClassDtls(strVhclClass);
            return dtReadvehiclemaster;
        }
        public DataTable ReadVhclCtgryByClsId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadVhclCtgryByClsId(ObjVehicle);
            return dtReadvehiclemaster;
        }
        public string readMakeTypId(string strMakeTyp)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            string intCovrgTypeId = objDataLayerVehicle.readMakeTypId(strMakeTyp);
            return intCovrgTypeId;
        }
        public DataTable readMakeTypName(string strInsurCovrgType)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.readMakeTypName(strInsurCovrgType);
            return dtReadvehiclemaster;
        }

        public DataTable ReadVehicleFilesTRper(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtVehRenewalList = objDataLayerVehicle.ReadVehicleFilesTRper(ObjVehicle);
            return dtVehRenewalList;
        }
        public DataTable ReadVehicleFilesTRins(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtVehRenewalList = objDataLayerVehicle.ReadVehicleFilesTRins(ObjVehicle);
            return dtVehRenewalList;
        }
        public DataTable ReadInsuranceRenewTR(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadInsuranceRenewTR(ObjVehicle);
            return dtReadvehiclemaster;
        }

        // This Method will fetch attachment list
        public DataTable ReadPermitRenewTR(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadPermitRenewTR(ObjVehicle);
            return dtReadvehiclemaster;
        }

        public DataTable ReadImagebyVehicleClsId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadImagebyVehicleClsId(ObjVehicle);
            return dtReadvehiclemaster;
        }

        public DataTable ReadImagebyFuelTypId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            clsDataLayerVehicleMaster objDataLayerVehicle = new clsDataLayerVehicleMaster();
            DataTable dtReadvehiclemaster = objDataLayerVehicle.ReadImagebyFuelTypId(ObjVehicle);
            return dtReadvehiclemaster;
        }



    }
}
