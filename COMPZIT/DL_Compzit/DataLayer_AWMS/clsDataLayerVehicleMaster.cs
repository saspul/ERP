using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerVehicleMaster
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch vehicle class details
        public DataTable ReadVehicleClass(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleClass = "VEHICLE_MASTER.SP_READ_VEHICLE_CLASS";
            OracleCommand cmdReadVehicleClass = new OracleCommand();
            cmdReadVehicleClass.CommandText = strQueryReadVehicleClass;
            cmdReadVehicleClass.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleClass.Parameters.Add("I_VCLASS", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
            cmdReadVehicleClass.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdReadVehicleClass.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdReadVehicleClass.Parameters.Add(" I_VEHCLASS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleClass);
            return dtCategory;
        }

        // This Method will fetch fuel type details
        public DataTable ReadFuelType(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadFuelType = "VEHICLE_MASTER.SP_READ_FUEL_TYPE";
            OracleCommand cmdReadFuelType = new OracleCommand();
            cmdReadFuelType.CommandText = strQueryReadFuelType;
            cmdReadFuelType.CommandType = CommandType.StoredProcedure;
            cmdReadFuelType.Parameters.Add("I_TYPEID", OracleDbType.Int32).Value = ObjVehicle.FuelTypeId;
            cmdReadFuelType.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdReadFuelType.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdReadFuelType.Parameters.Add(" I_FUELTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadFuelType);
            return dtCategory;
        }
        // This Method will fetch fuel type details
        public DataTable ReadRegistrationType()
        {
            string strQueryReadFuelType = "VEHICLE_MASTER.SP_READ_REGISTR_TYPE";
            OracleCommand cmdReadFuelType = new OracleCommand();
            cmdReadFuelType.CommandText = strQueryReadFuelType;
            cmdReadFuelType.CommandType = CommandType.StoredProcedure;
            cmdReadFuelType.Parameters.Add(" V_REGTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadFuelType);
            return dtCategory;
        }
        // This Method will fetch INSURANCE provider details
        public DataTable ReadInsuranceProvider(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadInsProvider = "VEHICLE_MASTER.SP_READ_INSURANCE_PRVDR";
            OracleCommand cmdReadInsProvider = new OracleCommand();
            cmdReadInsProvider.CommandText = strQueryReadInsProvider;
            cmdReadInsProvider.CommandType = CommandType.StoredProcedure;
            cmdReadInsProvider.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdReadInsProvider.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdReadInsProvider.Parameters.Add(" I_INSPROVDR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsProvider);
            return dtCategory;
        }
        // This Method will fetch INSURANCE provider details
        public DataTable ReadVehicleType()
        {
            string strQueryReadVehType = "VEHICLE_MASTER.SP_READ_VEHICLE_TYPE";
            OracleCommand cmdReadVehType = new OracleCommand();
            cmdReadVehType.CommandText = strQueryReadVehType;
            cmdReadVehType.CommandType = CommandType.StoredProcedure;
            cmdReadVehType.Parameters.Add(" I_VEHTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdReadVehType);
            return dtVehType;
        }
        //EVM-0016
        // This Method adds VEHICLE MSTER details to the table
        public void AddVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR)
        {
            
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                     {
            string strQueryAddVehicle = "VEHICLE_MASTER.SP_INS_VEHICLE_DETAILS";
            using (OracleCommand cmdAddVehicle = new OracleCommand(strQueryAddVehicle,con))
            {
                cmdAddVehicle.CommandText = strQueryAddVehicle;
                cmdAddVehicle.CommandType = CommandType.StoredProcedure;
                cmdAddVehicle.Parameters.Add("V_NEXTID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                cmdAddVehicle.Parameters.Add("V_VEHCLASSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
                cmdAddVehicle.Parameters.Add("V_VEHTYPID", OracleDbType.Int32).Value = ObjVehicle.VehicleTypeId;
                cmdAddVehicle.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
                cmdAddVehicle.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                cmdAddVehicle.Parameters.Add("V_FUELTYPID", OracleDbType.Int32).Value = ObjVehicle.FuelTypeId;
                cmdAddVehicle.Parameters.Add("V_VEHNUM", OracleDbType.Varchar2).Value = ObjVehicle.VehicleNumber;
                cmdAddVehicle.Parameters.Add("V_VEHPURDAT", OracleDbType.Date).Value = ObjVehicle.VehPurchaseDate;
                cmdAddVehicle.Parameters.Add("V_CHASENUM", OracleDbType.Varchar2).Value = ObjVehicle.ChasisNumber;
                cmdAddVehicle.Parameters.Add("V_KML", OracleDbType.Decimal).Value = ObjVehicle.KilometerPerLitre;

                cmdAddVehicle.Parameters.Add("V_MILEAGE", OracleDbType.Decimal).Value = ObjVehicle.Mileage;
                cmdAddVehicle.Parameters.Add("V_VMODALYEAR", OracleDbType.Int32).Value = ObjVehicle.ModalYear;
               // cmdAddVehicle.Parameters.Add("V_PERNUMBER", OracleDbType.Varchar2).Value = ObjVehicle.PermitNumber;
                cmdAddVehicle.Parameters.Add("V_PEREXPDATE", OracleDbType.Date).Value = ObjVehicle.PermitExpiryDate;
                cmdAddVehicle.Parameters.Add("V_FILENAME", OracleDbType.Varchar2).Value = ObjVehicle.FileName;
                cmdAddVehicle.Parameters.Add("V_FILENAME_INSUR", OracleDbType.Varchar2).Value = ObjVehicle.FileNameInsur;
                cmdAddVehicle.Parameters.Add("V_INSURANCE", OracleDbType.Varchar2).Value = ObjVehicle.Insurance;
                cmdAddVehicle.Parameters.Add("V_INSURPRVDRID", OracleDbType.Int32).Value = ObjVehicle.InsureProviderId;
                cmdAddVehicle.Parameters.Add("V_INSEXPDATE", OracleDbType.Date).Value = ObjVehicle.InsuranceExpirydate;
                cmdAddVehicle.Parameters.Add("V_INSAMOUNT", OracleDbType.Decimal).Value = ObjVehicle.InsuranceAmount;
                cmdAddVehicle.Parameters.Add("V_ENGCAPACITY", OracleDbType.Decimal).Value = ObjVehicle.EngineCapacity;
                cmdAddVehicle.Parameters.Add("V_DESCRIPTION", OracleDbType.Varchar2).Value = ObjVehicle.Description;
                if (ObjVehicle.TankCapacity != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = ObjVehicle.TankCapacity;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = null;
                }
                if (ObjVehicle.AmountPerBarrel != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = ObjVehicle.AmountPerBarrel;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = null;
                }
                cmdAddVehicle.Parameters.Add("V_RFNUM", OracleDbType.Varchar2).Value = ObjVehicle.RfIdTagNum;
                cmdAddVehicle.Parameters.Add("V_REGTYP", OracleDbType.Int32).Value = ObjVehicle.RegTypeId;
                cmdAddVehicle.Parameters.Add("V_ISTANK", OracleDbType.Int32).Value = ObjVehicle.IsTanker;
                cmdAddVehicle.Parameters.Add("V_FUELLIMIT", OracleDbType.Decimal).Value = ObjVehicle.FuelLimit;
                cmdAddVehicle.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = ObjVehicle.Status_id;
                cmdAddVehicle.Parameters.Add("V_INSUSERID", OracleDbType.Int32).Value = ObjVehicle.User_Id;


                cmdAddVehicle.Parameters.Add("V_MAKE", OracleDbType.Int32).Value = ObjVehicle.Make;
                cmdAddVehicle.Parameters.Add("V_MODEL", OracleDbType.Varchar2).Value = ObjVehicle.Model;
                if (ObjVehicle.TransmsnTypeId != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = ObjVehicle.TransmsnTypeId;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.ColorId != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = ObjVehicle.ColorId;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = null;
                }
                cmdAddVehicle.Parameters.Add("V_DEALER_NAME", OracleDbType.Varchar2).Value = ObjVehicle.DealerName;
                cmdAddVehicle.Parameters.Add("V_CONTACT_NO", OracleDbType.Varchar2).Value = ObjVehicle.ContactNo;
                if (ObjVehicle.Price != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = ObjVehicle.Price;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = null;
                }
               
                cmdAddVehicle.Parameters.Add("V_COVERAGE_TYPEID", OracleDbType.Int32).Value = ObjVehicle.CoverageTypeId;
                cmdAddVehicle.Parameters.Add("V_TRLER_REGNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerRegNum;
                cmdAddVehicle.Parameters.Add("V_TRLER_INSNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerInsNum;
                if (ObjVehicle.TRregstrnExpDate != DateTime.MinValue)
                {
                    cmdAddVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRregstrnExpDate;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = null;
                }
                if (ObjVehicle.TRinsrnceExpDate != DateTime.MinValue)
                {
                    cmdAddVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRinsrnceExpDate;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = null;
                }
                if (ObjVehicle.TRinsrncePrvdrId != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = ObjVehicle.TRinsrncePrvdrId;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.TRinsrnceCvrgTypId != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = ObjVehicle.TRinsrnceCvrgTypId;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.TRinsuranceAmnt != 0)
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = ObjVehicle.TRinsuranceAmnt;
                }
                else
                {
                    cmdAddVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = null;
                }


                cmdAddVehicle.ExecuteNonQuery();
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPermitAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_PERMIT_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {
                    

                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsurAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_INSUR_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {
                   

                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_VHCL_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {
                   

                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }



            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPerAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_TRPER_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }


            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_TRINS_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            tran.Commit();
                     }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
          
        }

        //EVM-0016
        // This Method adds VEHICLE MASTER details to the table
        public void UpdateVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsListTR, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsListTR)
        {
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                    {
            string strQueryUpdVehicle = "VEHICLE_MASTER.SP_UPD_VEHICLE_DETAILS";
            using (OracleCommand cmdUpdVehicle = new OracleCommand(strQueryUpdVehicle,con))
            {
                cmdUpdVehicle.CommandText = strQueryUpdVehicle;
                cmdUpdVehicle.CommandType = CommandType.StoredProcedure;
                cmdUpdVehicle.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                cmdUpdVehicle.Parameters.Add("V_VEHCLASSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
                cmdUpdVehicle.Parameters.Add("V_VEHTYPID", OracleDbType.Int32).Value = ObjVehicle.VehicleTypeId;
                cmdUpdVehicle.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
                cmdUpdVehicle.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                cmdUpdVehicle.Parameters.Add("V_FUELTYPID", OracleDbType.Int32).Value = ObjVehicle.FuelTypeId;
                cmdUpdVehicle.Parameters.Add("V_VEHNUM", OracleDbType.Varchar2).Value = ObjVehicle.VehicleNumber;
                cmdUpdVehicle.Parameters.Add("V_VEHPURDAT", OracleDbType.Date).Value = ObjVehicle.VehPurchaseDate;
                cmdUpdVehicle.Parameters.Add("V_CHASENUM", OracleDbType.Varchar2).Value = ObjVehicle.ChasisNumber;
                cmdUpdVehicle.Parameters.Add("V_KML", OracleDbType.Decimal).Value = ObjVehicle.KilometerPerLitre;
                cmdUpdVehicle.Parameters.Add("V_MILEAGE", OracleDbType.Decimal).Value = ObjVehicle.Mileage;
                cmdUpdVehicle.Parameters.Add("V_VMODALYEAR", OracleDbType.Int32).Value = ObjVehicle.ModalYear;
                //cmdUpdVehicle.Parameters.Add("V_PERNUMBER", OracleDbType.Varchar2).Value = ObjVehicle.PermitNumber;
                cmdUpdVehicle.Parameters.Add("V_PEREXPDATE", OracleDbType.Date).Value = ObjVehicle.PermitExpiryDate;
                cmdUpdVehicle.Parameters.Add("V_FILENAME", OracleDbType.Varchar2).Value = ObjVehicle.FileName;
                cmdUpdVehicle.Parameters.Add("V_FILENAME_INSUR", OracleDbType.Varchar2).Value = ObjVehicle.FileNameInsur;
                cmdUpdVehicle.Parameters.Add("V_INSURANCE", OracleDbType.Varchar2).Value = ObjVehicle.Insurance;
                cmdUpdVehicle.Parameters.Add("V_INSURPRVDRID", OracleDbType.Int32).Value = ObjVehicle.InsureProviderId;
                cmdUpdVehicle.Parameters.Add("V_INSEXPDATE", OracleDbType.Date).Value = ObjVehicle.InsuranceExpirydate;
                cmdUpdVehicle.Parameters.Add("V_INSAMOUNT", OracleDbType.Decimal).Value = ObjVehicle.InsuranceAmount;
                cmdUpdVehicle.Parameters.Add("V_ENGCAPACITY", OracleDbType.Decimal).Value = ObjVehicle.EngineCapacity;
                cmdUpdVehicle.Parameters.Add("V_DESCRIPTION", OracleDbType.Varchar2).Value = ObjVehicle.Description;
                if (ObjVehicle.TankCapacity != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = ObjVehicle.TankCapacity;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = null;
                }
                if (ObjVehicle.AmountPerBarrel != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = ObjVehicle.AmountPerBarrel;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = null;
                }
                cmdUpdVehicle.Parameters.Add("V_RFNUM", OracleDbType.Varchar2).Value = ObjVehicle.RfIdTagNum;
                cmdUpdVehicle.Parameters.Add("V_REGTYP", OracleDbType.Int32).Value = ObjVehicle.RegTypeId;
                cmdUpdVehicle.Parameters.Add("V_ISTANK", OracleDbType.Int32).Value = ObjVehicle.IsTanker;
                cmdUpdVehicle.Parameters.Add("V_FUELLIMIT", OracleDbType.Decimal).Value = ObjVehicle.FuelLimit;
                cmdUpdVehicle.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = ObjVehicle.Status_id;
                cmdUpdVehicle.Parameters.Add("V_UPDUSERID", OracleDbType.Int32).Value = ObjVehicle.User_Id;
                cmdUpdVehicle.Parameters.Add("V_UPDDATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();

                cmdUpdVehicle.Parameters.Add("V_MAKE", OracleDbType.Varchar2).Value = ObjVehicle.Make;

                cmdUpdVehicle.Parameters.Add("V_MODEL", OracleDbType.Varchar2).Value = ObjVehicle.Model;
                if (ObjVehicle.TransmsnTypeId != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = ObjVehicle.TransmsnTypeId;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.ColorId != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = ObjVehicle.ColorId;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = null;
                }
                cmdUpdVehicle.Parameters.Add("V_DEALER_NAME", OracleDbType.Varchar2).Value = ObjVehicle.DealerName;
                cmdUpdVehicle.Parameters.Add("V_CONTACT_NO", OracleDbType.Varchar2).Value = ObjVehicle.ContactNo;
                if (ObjVehicle.Price != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = ObjVehicle.Price;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = null;
                }
                cmdUpdVehicle.Parameters.Add("V_COVERAGE_TYPEID", OracleDbType.Int32).Value = ObjVehicle.CoverageTypeId;
                cmdUpdVehicle.Parameters.Add("V_TRLER_REGNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerRegNum;
                cmdUpdVehicle.Parameters.Add("V_TRLER_INSNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerInsNum;

                if (ObjVehicle.TRregstrnExpDate != DateTime.MinValue)
                {
                    cmdUpdVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRregstrnExpDate;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = null;
                }
                if (ObjVehicle.TRinsrnceExpDate != DateTime.MinValue)
                {
                    cmdUpdVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRinsrnceExpDate;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = null;
                }
                if (ObjVehicle.TRinsrncePrvdrId != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = ObjVehicle.TRinsrncePrvdrId;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.TRinsrnceCvrgTypId != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = ObjVehicle.TRinsrnceCvrgTypId;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicle.TRinsuranceAmnt != 0)
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = ObjVehicle.TRinsuranceAmnt;
                }
                else
                {
                    cmdUpdVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = null;
                }

                cmdUpdVehicle.ExecuteNonQuery();
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPermitAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_PERMIT_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_PERMIT_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsurAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_INSUR_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_VHCL_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            //for deleting files
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPerDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_DELE_PER_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_DELE_INS_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_DELE_VHCL_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPerAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_TRPER_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }


            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_INS_TRINS_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_INSUR_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPerDeleteAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_DELE_TRPER_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsDeleteAttchmntDeatilsListTR)
            {
                string strQueryInsertAtcmntDtls = "VEHICLE_MASTER.SP_DELE_TRINS_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                    cmdInsertAtcmntDtls.Parameters.Add("IP_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            tran.Commit();
                    }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }

        

        }
        //EVM-0016
        // This Method checks VEHICLE NUMBER in the database for duplication.
        public string CheckVehicleNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_CHECK_VEHICLENUMBER";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckVehNum.Parameters.Add("V_VEHNUM", OracleDbType.Varchar2).Value = ObjVehicle.VehicleNumber;
            cmdCheckVehNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckVehNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;          
            cmdCheckVehNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string strReturn = cmdCheckVehNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return strReturn;
        }

      
        // This Method checks CHASIS NUMBER in the database for duplication.
        public string CheckChasisNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKChasisNum = "VEHICLE_MASTER.SP_CHECK_CHASE_NUMBER";
            OracleCommand cmdCheckChaseNum = new OracleCommand();
            cmdCheckChaseNum.CommandText = strQueryChecKChasisNum;
            cmdCheckChaseNum.CommandType = CommandType.StoredProcedure;
            cmdCheckChaseNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckChaseNum.Parameters.Add("V_CHASENUM", OracleDbType.Varchar2).Value = ObjVehicle.ChasisNumber;
            cmdCheckChaseNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckChaseNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckChaseNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckChaseNum);
            string strReturn = cmdCheckChaseNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckChaseNum.Dispose();
            return strReturn;
        }
        // This Method checks INSURANCE NUMBER in the database for duplication.
        public string CheckInsuranceNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKInsurNum = "VEHICLE_MASTER.SP_CHECK_INSUR_NUMBER";
            OracleCommand cmdCheckInsurNum = new OracleCommand();
            cmdCheckInsurNum.CommandText = strQueryChecKInsurNum;
            cmdCheckInsurNum.CommandType = CommandType.StoredProcedure;
            cmdCheckInsurNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckInsurNum.Parameters.Add("V_INSNUM", OracleDbType.Varchar2).Value = ObjVehicle.Insurance;
            cmdCheckInsurNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckInsurNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckInsurNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsurNum);
            string strReturn = cmdCheckInsurNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckInsurNum.Dispose();
            return strReturn;
        }

        // This Method checks INSURANCE NUMBER in the database for duplication.
        public string CheckRF_IdNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKInsurNum = "VEHICLE_MASTER.SP_CHECK_RFID_NUMBER";
            OracleCommand cmdCheckInsurNum = new OracleCommand();
            cmdCheckInsurNum.CommandText = strQueryChecKInsurNum;
            cmdCheckInsurNum.CommandType = CommandType.StoredProcedure;
            cmdCheckInsurNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckInsurNum.Parameters.Add("V_RFNUM", OracleDbType.Varchar2).Value = ObjVehicle.RfIdTagNum;
            cmdCheckInsurNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckInsurNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckInsurNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsurNum);
            string strReturn = cmdCheckInsurNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckInsurNum.Dispose();
            return strReturn;
        }

        // This Method will fetch vehicle DEATILS BY ID
        public DataTable ReadVehicleDetailsById(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleDetail = "VEHICLE_MASTER.SP_READ_VEHICLE_BY_ID";
            OracleCommand cmdReadVehicleDetail = new OracleCommand();
            cmdReadVehicleDetail.CommandText = strQueryReadVehicleDetail;
            cmdReadVehicleDetail.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleDetail.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleDetail.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleDetail);
            return dtCategory;
        }

        //Method for cancel vehicle master
        public void CancelVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryCancelVehicle = "VEHICLE_MASTER.SP_CANCEL_VEHICLE";
            using (OracleCommand cmdVehicleMaster = new OracleCommand())
            {
                cmdVehicleMaster.CommandText = strQueryCancelVehicle;
                cmdVehicleMaster.CommandType = CommandType.StoredProcedure;
                cmdVehicleMaster.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                cmdVehicleMaster.Parameters.Add("V_CNCLUSERID", OracleDbType.Int32).Value = ObjVehicle.User_Id;
                cmdVehicleMaster.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdVehicleMaster.Parameters.Add("V_REASON", OracleDbType.Varchar2).Value = ObjVehicle.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdVehicleMaster);
            }
        }
        //Method for cancel vehicle master
        public void RecallVehicleMaster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryRecallVehicle = "VEHICLE_MASTER.SP_RECALL_VEHICLE";
            using (OracleCommand cmdVehicleMaster = new OracleCommand())
            {
                cmdVehicleMaster.CommandText = strQueryRecallVehicle;
                cmdVehicleMaster.CommandType = CommandType.StoredProcedure;
                cmdVehicleMaster.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
                cmdVehicleMaster.Parameters.Add("V_RCLUSERID", OracleDbType.Int32).Value = ObjVehicle.User_Id;
                cmdVehicleMaster.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdVehicleMaster);
            }
        }
        // This Method will fetch vehicle list
        public DataTable ReadVehicleMasterList(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleList = "VEHICLE_MASTER.SP_READ_VEHICLE_LIST";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdReadVehicleList.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdReadVehicleList.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }
        // This Method will fetch vehicle list BY SEARCH
        public DataTable ReadVehicleMasterListBySearch(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleListBySearch = "VEHICLE_MASTER.SP_READ_VEHICLE_LIST_BYSEARCH";
            OracleCommand cmdReadVehicleListBySearch = new OracleCommand();
            cmdReadVehicleListBySearch.CommandText = strQueryReadVehicleListBySearch;
            cmdReadVehicleListBySearch.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleListBySearch.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdReadVehicleListBySearch.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            if (ObjVehicle.SearchField == "")
            {
                cmdReadVehicleListBySearch.Parameters.Add("V_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadVehicleListBySearch.Parameters.Add("V_SEARCH_WORD", OracleDbType.Varchar2).Value = ObjVehicle.SearchField;
            }
            cmdReadVehicleListBySearch.Parameters.Add("V_DATABASE_FIELD", OracleDbType.Varchar2).Value = ObjVehicle.DataBase_Field;
            cmdReadVehicleListBySearch.Parameters.Add("V_CLASSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
            cmdReadVehicleListBySearch.Parameters.Add("V_OPTION", OracleDbType.Int32).Value = ObjVehicle.Status_id;
            cmdReadVehicleListBySearch.Parameters.Add("V_CANCEL", OracleDbType.Int32).Value = ObjVehicle.CancelStatus;
            cmdReadVehicleListBySearch.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleListBySearch);
            return dtCategoryList;
        }
       // This Method will fetch attachment list
        public DataTable ReadVehicleMasterAttachment(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_ATTACHMENT";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }
        // This Method will fetch attachment list
        public void DeleteVehicleMasterAttachment(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_DELETE_ATTACHMENT";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            clsDataLayer.ExecuteNonQuery(cmdReadVehicleAttachment);

        }

        // This Method will fetch attachment list
        public DataTable ReadInsuranceRenew(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_INS_RENEW";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }
        // This Method will fetch attachment list
        public DataTable ReadPermitRenew(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_PRMT_RENEW";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }
       //for fetch permit attachment files
        public DataTable ReadPermtFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadExpInsuranceDetails = "VEHICLE_MASTER.SP_READ_PERMT_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        //for fetch insurance attachment files
        public DataTable ReadInsurFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadExpInsuranceDetails = "VEHICLE_MASTER.SP_READ_INSUR_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        //for fetch vehicle attachment files
        public DataTable ReadVehicleFiles(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadExpInsuranceDetails = "VEHICLE_MASTER.SP_READ_VHCL_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        // This Method will fetch vehicle transmission type details
        public DataTable ReadVhclTransmsn()
        {
            string strQueryReadVehType = "VEHICLE_MASTER.SP_READ_TRANSMSN_TYPE";
            OracleCommand cmdReadVehType = new OracleCommand();
            cmdReadVehType.CommandText = strQueryReadVehType;
            cmdReadVehType.CommandType = CommandType.StoredProcedure;
            cmdReadVehType.Parameters.Add(" V_TRANSMSN_TYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdReadVehType);
            return dtVehType;
        }

        // This Method will fetch vehicle make type details
        public DataTable ReadVhclMake()
        {
            string strQueryReadVhclMake = "VEHICLE_MASTER.SP_READ_MAKE_TYPE";
            OracleCommand cmdReadVhclMake = new OracleCommand();
            cmdReadVhclMake.CommandText = strQueryReadVhclMake;
            cmdReadVhclMake.CommandType = CommandType.StoredProcedure;
            cmdReadVhclMake.Parameters.Add("V_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdReadVhclMake);
            return dtVehType;
        }
        // This Method will fetch vehicle transmission type details
        public DataTable ReadVhclColor()
        {
            string strQueryReadVehType = "VEHICLE_MASTER.SP_READ_COLOR";
            OracleCommand cmdReadVehType = new OracleCommand();
            cmdReadVehType.CommandText = strQueryReadVehType;
            cmdReadVehType.CommandType = CommandType.StoredProcedure;
            cmdReadVehType.Parameters.Add(" V_COLOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdReadVehType);
            return dtVehType;
        }
        // This Method will fetch insurance coverage type details
        public DataTable ReadInsCoverageType()
        {
            string strQueryReadVehType = "VEHICLE_MASTER.SP_READ_INS_COVRG_TYPE";
            OracleCommand cmdReadVehType = new OracleCommand();
            cmdReadVehType.CommandText = strQueryReadVehType;
            cmdReadVehType.CommandType = CommandType.StoredProcedure;
            cmdReadVehType.Parameters.Add(" V_COVRG_TYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdReadVehType);
            return dtVehType;
        }
       //FOR ID'S FOR DROPDOWN ITEMS
        public string readVhclClassID(string strVhclClassName)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_VHCLCLS_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_VHCLCLS_NAME", OracleDbType.Varchar2).Value = strVhclClassName;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);

            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public string readFuelTypeID(string strFuelType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_FUELTYP_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_FUELTYP", OracleDbType.Varchar2).Value = strFuelType;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public string readRegTypeID(string strRegType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_REGTYP_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_REGTYP", OracleDbType.Varchar2).Value = strRegType;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public string readOwnershipID(string strOwnershipType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_OWNERSHIP_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_OWNERSHPTYP", OracleDbType.Varchar2).Value = strOwnershipType;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public string readInsurPrvdrID(string strInsurPrvdr)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_INSPRVDR_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_INSPRVDRTYP", OracleDbType.Varchar2).Value = strInsurPrvdr;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public string readInsurCovrgTypeID(string strInsurCovrgType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_INSCOVRG_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_COVRGTYP", OracleDbType.Varchar2).Value = strInsurCovrgType;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }


        public void AddVehicleList(List<clsEntityLayerVehicleMaster> objEntityVhclList)
        {
            foreach (clsEntityLayerVehicleMaster ObjVehicle in objEntityVhclList)
            {
                string strQueryAddVehicle = "VEHICLE_MASTER.SP_INS_VEHICLE_DETAILS";
                using (OracleCommand cmdAddVehicle = new OracleCommand())
                {
                    cmdAddVehicle.CommandText = strQueryAddVehicle;
                    cmdAddVehicle.CommandType = CommandType.StoredProcedure;
                    cmdAddVehicle.Parameters.Add("V_NEXTID", OracleDbType.Int32).Value = ObjVehicle.NextIdForVehicle;
                    cmdAddVehicle.Parameters.Add("V_VEHCLASSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
                    cmdAddVehicle.Parameters.Add("V_VEHTYPID", OracleDbType.Int32).Value = ObjVehicle.VehicleTypeId;
                    cmdAddVehicle.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
                    cmdAddVehicle.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
                    cmdAddVehicle.Parameters.Add("V_FUELTYPID", OracleDbType.Int32).Value = ObjVehicle.FuelTypeId;
                    cmdAddVehicle.Parameters.Add("V_VEHNUM", OracleDbType.Varchar2).Value = ObjVehicle.VehicleNumber;
                    cmdAddVehicle.Parameters.Add("V_VEHPURDAT", OracleDbType.Date).Value = ObjVehicle.VehPurchaseDate;
                    cmdAddVehicle.Parameters.Add("V_CHASENUM", OracleDbType.Varchar2).Value = ObjVehicle.ChasisNumber;
                    cmdAddVehicle.Parameters.Add("V_KML", OracleDbType.Decimal).Value = ObjVehicle.KilometerPerLitre;

                    cmdAddVehicle.Parameters.Add("V_MILEAGE", OracleDbType.Decimal).Value = ObjVehicle.Mileage;
                    cmdAddVehicle.Parameters.Add("V_VMODALYEAR", OracleDbType.Int32).Value = ObjVehicle.ModalYear;
                    // cmdAddVehicle.Parameters.Add("V_PERNUMBER", OracleDbType.Varchar2).Value = ObjVehicle.PermitNumber;
                    cmdAddVehicle.Parameters.Add("V_PEREXPDATE", OracleDbType.Date).Value = ObjVehicle.PermitExpiryDate;
                    cmdAddVehicle.Parameters.Add("V_FILENAME", OracleDbType.Varchar2).Value = ObjVehicle.FileName;
                    cmdAddVehicle.Parameters.Add("V_FILENAME_INSUR", OracleDbType.Varchar2).Value = ObjVehicle.FileNameInsur;
                    cmdAddVehicle.Parameters.Add("V_INSURANCE", OracleDbType.Varchar2).Value = ObjVehicle.Insurance;
                    cmdAddVehicle.Parameters.Add("V_INSURPRVDRID", OracleDbType.Int32).Value = ObjVehicle.InsureProviderId;
                    cmdAddVehicle.Parameters.Add("V_INSEXPDATE", OracleDbType.Date).Value = ObjVehicle.InsuranceExpirydate;
                    cmdAddVehicle.Parameters.Add("V_INSAMOUNT", OracleDbType.Decimal).Value = ObjVehicle.InsuranceAmount;
                    cmdAddVehicle.Parameters.Add("V_ENGCAPACITY", OracleDbType.Decimal).Value = ObjVehicle.EngineCapacity;
                    cmdAddVehicle.Parameters.Add("V_DESCRIPTION", OracleDbType.Varchar2).Value = ObjVehicle.Description;
                    if (ObjVehicle.TankCapacity != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = ObjVehicle.TankCapacity;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TNKCAP", OracleDbType.Decimal).Value = null;
                    }
                    if (ObjVehicle.AmountPerBarrel != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = ObjVehicle.AmountPerBarrel;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_AMNTPERBRL", OracleDbType.Decimal).Value = null;
                    }
                    cmdAddVehicle.Parameters.Add("V_RFNUM", OracleDbType.Varchar2).Value = ObjVehicle.RfIdTagNum;
                    cmdAddVehicle.Parameters.Add("V_REGTYP", OracleDbType.Int32).Value = ObjVehicle.RegTypeId;
                    cmdAddVehicle.Parameters.Add("V_ISTANK", OracleDbType.Int32).Value = ObjVehicle.IsTanker;
                    cmdAddVehicle.Parameters.Add("V_FUELLIMIT", OracleDbType.Decimal).Value = ObjVehicle.FuelLimit;
                    cmdAddVehicle.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = 1;
                    cmdAddVehicle.Parameters.Add("V_INSUSERID", OracleDbType.Int32).Value = ObjVehicle.User_Id;


                    cmdAddVehicle.Parameters.Add("V_MAKE", OracleDbType.Varchar2).Value = ObjVehicle.Make;
                    cmdAddVehicle.Parameters.Add("V_MODEL", OracleDbType.Varchar2).Value = ObjVehicle.Model;
                    if (ObjVehicle.TransmsnTypeId != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = ObjVehicle.TransmsnTypeId;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TRANSMSN_TYPEID", OracleDbType.Int32).Value = null;
                    }
                    if (ObjVehicle.ColorId != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = ObjVehicle.ColorId;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_COLORID", OracleDbType.Int32).Value = null;
                    }
                    cmdAddVehicle.Parameters.Add("V_DEALER_NAME", OracleDbType.Varchar2).Value = ObjVehicle.DealerName;
                    cmdAddVehicle.Parameters.Add("V_CONTACT_NO", OracleDbType.Varchar2).Value = ObjVehicle.ContactNo;
                    if (ObjVehicle.Price != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = ObjVehicle.Price;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_PRICE", OracleDbType.Decimal).Value = null;
                    }

                    cmdAddVehicle.Parameters.Add("V_COVERAGE_TYPEID", OracleDbType.Int32).Value = ObjVehicle.CoverageTypeId;
                    cmdAddVehicle.Parameters.Add("V_TRLER_REGNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerRegNum;
                    cmdAddVehicle.Parameters.Add("V_TRLER_INSNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerInsNum;
                    if (ObjVehicle.TRregstrnExpDate != DateTime.MinValue)
                    {
                        cmdAddVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRregstrnExpDate;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TRPER_EXPDATE", OracleDbType.Date).Value = null;
                    }
                    if (ObjVehicle.TRinsrnceExpDate != DateTime.MinValue)
                    {
                        cmdAddVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = ObjVehicle.TRinsrnceExpDate;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TRINS_EXPDATE", OracleDbType.Date).Value = null;
                    }
                    if (ObjVehicle.TRinsrncePrvdrId != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = ObjVehicle.TRinsrncePrvdrId;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSPRVDRID", OracleDbType.Int32).Value = null;
                    }
                    if (ObjVehicle.TRinsrnceCvrgTypId != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = ObjVehicle.TRinsrnceCvrgTypId;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSCVRGID", OracleDbType.Int32).Value = null;
                    }
                    if (ObjVehicle.TRinsuranceAmnt != 0)
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = ObjVehicle.TRinsuranceAmnt;
                    }
                    else
                    {
                        cmdAddVehicle.Parameters.Add("V_TR_INSAMNT", OracleDbType.Decimal).Value = null;
                    }
                    clsDataLayer.ExecuteNonQuery(cmdAddVehicle);
                }
               

            } 
           
        }


       


        public string CheckTrailerInsNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKInsurNum = "VEHICLE_MASTER.SP_CHECK_TRLER_INSNUM";
            OracleCommand cmdCheckInsurNum = new OracleCommand();
            cmdCheckInsurNum.CommandText = strQueryChecKInsurNum;
            cmdCheckInsurNum.CommandType = CommandType.StoredProcedure;
            cmdCheckInsurNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckInsurNum.Parameters.Add("V_TRLER_INSNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerInsNum;
            cmdCheckInsurNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckInsurNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckInsurNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsurNum);
            string strReturn = cmdCheckInsurNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckInsurNum.Dispose();
            return strReturn;
        }

        public string CheckTrailerNumber(clsEntityLayerVehicleMaster ObjVehicle)
        {

            string strQueryChecKInsurNum = "VEHICLE_MASTER.SP_CHECK_TRLER_REGNUM";
            OracleCommand cmdCheckInsurNum = new OracleCommand();
            cmdCheckInsurNum.CommandText = strQueryChecKInsurNum;
            cmdCheckInsurNum.CommandType = CommandType.StoredProcedure;
            cmdCheckInsurNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdCheckInsurNum.Parameters.Add("V_TRLER_REGNUM", OracleDbType.Varchar2).Value = ObjVehicle.TrailerRegNum;
            cmdCheckInsurNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckInsurNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckInsurNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsurNum);
            string strReturn = cmdCheckInsurNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckInsurNum.Dispose();
            return strReturn;
        }
        public DataTable readCategoryType(int vhclclsId)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_CTGRYNAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_VHCLCLS_ID", OracleDbType.Int32).Value = vhclclsId;
            cmdCheckVehNum.Parameters.Add(" V_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehType = new DataTable();
            dtVehType = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtVehType;
        }
        public DataTable ReadVehicleSts(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleDetail = "VEHICLE_MASTER.SP_READ_VEHICLE_STS";
            OracleCommand cmdReadVehicleDetail = new OracleCommand();
            cmdReadVehicleDetail.CommandText = strQueryReadVehicleDetail;
            cmdReadVehicleDetail.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleDetail.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleDetail.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleDetail);
            return dtCategory;
        }
        //FOR NAMES'S FOR DROPDOWN ITEMS
        public DataTable readVhclClassName(string strVhclClassName)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_VHCLCLS_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_VHCLCLS_NAME", OracleDbType.Int32).Value = Convert.ToInt32(strVhclClassName);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable readFuelTypeName(string strFuelType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_FUELTYP_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_FUELTYP", OracleDbType.Int32).Value = Convert.ToInt32(strFuelType);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable readRegTypeName(string strRegType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_REGTYP_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_REGTYP", OracleDbType.Int32).Value = Convert.ToInt32(strRegType);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable readOwnershipName(string strOwnershipType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_OWNERSHIP_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_OWNERSHPTYP", OracleDbType.Int32).Value = Convert.ToInt32(strOwnershipType);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable readInsurPrvdrName(string strInsurPrvdr)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_INSPRVDR_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_INSPRVDRTYP", OracleDbType.Int32).Value =Convert.ToInt32( strInsurPrvdr);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable readInsurCovrgTypeName(string strInsurCovrgType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_INSCOVRG_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_COVRGTYP", OracleDbType.Int32).Value = Convert.ToInt32(strInsurCovrgType);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        // This Method checks VehicleId in use or not(DutyRoster)
        public string CheckDutyRoster(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryCheckDutyRoster = "VEHICLE_MASTER.SP_CHECK_DUTYGNRTN";
            OracleCommand cmdCheckDutyRoster = new OracleCommand();
            cmdCheckDutyRoster.CommandText = strQueryCheckDutyRoster;
            cmdCheckDutyRoster.CommandType = CommandType.StoredProcedure;
            cmdCheckDutyRoster.Parameters.Add("V_VEHICLEID", OracleDbType.Varchar2).Value = ObjVehicle.VehicleId;
            cmdCheckDutyRoster.Parameters.Add("V_ORG_ID", OracleDbType.Int32).Value = ObjVehicle.Organisation_id;
            cmdCheckDutyRoster.Parameters.Add("V_CORPRT_ID", OracleDbType.Int32).Value = ObjVehicle.Corporate_id;
            cmdCheckDutyRoster.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDutyRoster);
            string strReturn = cmdCheckDutyRoster.Parameters["V_COUNT"].Value.ToString();
            cmdCheckDutyRoster.Dispose();
            return strReturn;

        }


        public DataTable readVhclClassDtls(string strVhclClass)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_VHCL_CLS_DTLS";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_VHLCLS", OracleDbType.Varchar2).Value = strVhclClass;
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }
        public DataTable ReadVhclCtgryByClsId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleDetail = "VEHICLE_MASTER.SP_READ_VHCL_CTGRY_BYID";
            OracleCommand cmdReadVehicleDetail = new OracleCommand();
            cmdReadVehicleDetail.CommandText = strQueryReadVehicleDetail;
            cmdReadVehicleDetail.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleDetail.Parameters.Add("V_CLSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
            cmdReadVehicleDetail.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleDetail);
            return dtCategory;
        }
        public string readMakeTypId(string strMakeTyp)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_MAKETYP_ID";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_MAKETYP", OracleDbType.Varchar2).Value = strMakeTyp;
            cmdCheckVehNum.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehNum);
            string intReturn = cmdCheckVehNum.Parameters["V_ID"].Value.ToString();
            cmdCheckVehNum.Dispose();
            return intReturn;
        }
        public DataTable readMakeTypName(string strInsurCovrgType)
        {

            string strQueryChecKVehNum = "VEHICLE_MASTER.SP_READ_MAKE_NAME";
            OracleCommand cmdCheckVehNum = new OracleCommand();
            cmdCheckVehNum.CommandText = strQueryChecKVehNum;
            cmdCheckVehNum.CommandType = CommandType.StoredProcedure;
            cmdCheckVehNum.Parameters.Add("V_MAKETYP", OracleDbType.Int32).Value = Convert.ToInt32(strInsurCovrgType);
            cmdCheckVehNum.Parameters.Add(" V_VEHICLEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdCheckVehNum);
            return dtCategory;
        }

        public DataTable ReadVehicleFilesTRper(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadExpInsuranceDetails = "VEHICLE_MASTER.SP_READ_TRPER_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        public DataTable ReadVehicleFilesTRins(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadExpInsuranceDetails = "VEHICLE_MASTER.SP_READ_TRINS_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }


        public DataTable ReadInsuranceRenewTR(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_INS_RENEW_TR";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }

        public DataTable ReadPermitRenewTR(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_PRMT_RENEW_TR";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();

            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = ObjVehicle.VehicleId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }

        public DataTable ReadImagebyVehicleClsId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_VEHICLECLASSIMG";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();
            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_VEHICLECLSID", OracleDbType.Int32).Value = ObjVehicle.VehicleClassId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }

        public DataTable ReadImagebyFuelTypId(clsEntityLayerVehicleMaster ObjVehicle)
        {
            string strQueryReadVehicleAttach = "VEHICLE_MASTER.SP_READ_FUELTYPIMG";
            OracleCommand cmdReadVehicleAttachment = new OracleCommand();
            cmdReadVehicleAttachment.CommandText = strQueryReadVehicleAttach;
            cmdReadVehicleAttachment.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleAttachment.Parameters.Add("V_FUELTYPID", OracleDbType.Int32).Value = ObjVehicle.FuelTypeId;
            cmdReadVehicleAttachment.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAttachList = new DataTable();
            dtAttachList = clsDataLayer.ExecuteReader(cmdReadVehicleAttachment);
            return dtAttachList;
        }

    }
}
