using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerVehicleMaster
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intStatus = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;
        private int intImageId = 0;
        private int intAppModeSection = 0;

        private int intVehicleId = 0;
        private int intVehicleClassId = 0;
        private int intVehicleTypeId = 0;
        private int intInsureProviderId=0;
        private int intFuelTypeId = 0;
        private int intModalYear = 0;
        private decimal intKml = 0;
        private decimal intMileage = 0;
        private decimal intCapacity = 0;
        private int intNextId = 0;
        private int intSerialNumber = 0;
        private int intSerialNumber2 = 0;
        private string strFileName = "";
        private string strFileNameInsur = "";
        private string strVehicleNumber = "";
        private string strDescription;
        private string strInsurance = "";
        private string strPermitNumber = "";
        private string strChasisNumber = "";
        private DateTime dateVehPurchaseDate;
        private DateTime dateInsuranceExpirydate;
        private DateTime datePermitExpiryDate;
        private int intRegTypeId = 0;
        private string strRfIdTagNum = "";
        private decimal intFuelLimit = 0;
        private int intIsTanker = 0;
        private decimal intTankCapacity = 0;
        private decimal intAmountperBarrel = 0;
        private decimal IntInsuranceAmount = 0;

        private string strVehFileName1 = "";
        private string strVehFileName1Deleted = "";
        private string strVehFileNameAct1 = "";
        private string strVehFileName2 = "";
        private string strVehFileName2Deleted = "";
        private string strVehFileNameAct2 = "";

        private int strMake = 0;
        private string strModel = "";
        private int intTransmsnTpeId = 0;
        private int intColorId = 0;
        private string strDealerName = "";
        private string strContactNo = "";
        private decimal decPrice = 0;
        private int intCoverageType = 0;

        private string strTrailerRegNum = "";
        private string strTrailerInsNUm = "";

        private DateTime dTRregExpdate;
        private int intTRinsPrvdrId = 0;
        private DateTime dTRinsExpDate;
        private decimal decTRinsAmnt = 0;
        private int intTRinsCvrgTyp = 0;


        public decimal TRinsuranceAmnt
        {
            get
            {
                return decTRinsAmnt;
            }
            set
            {
                decTRinsAmnt = value;
            }
        }

        public DateTime TRregstrnExpDate
        {
            get
            {
                return dTRregExpdate;
            }
            set
            {
                dTRregExpdate = value;
            }
        }

        public DateTime TRinsrnceExpDate
        {
            get
            {
                return dTRinsExpDate;
            }
            set
            {
                dTRinsExpDate = value;
            }
        }

        public int TRinsrnceCvrgTypId
        {
            get
            {
                return intTRinsCvrgTyp;
            }
            set
            {
                intTRinsCvrgTyp = value;
            }
        }

        public int TRinsrncePrvdrId
        {
            get
            {
                return intTRinsPrvdrId;
            }
            set
            {
                intTRinsPrvdrId = value;
            }
        }

        //methode of storing chasis name of vehicle 
        public decimal InsuranceAmount
        {
            get
            {
                return IntInsuranceAmount;
            }
            set
            {
                IntInsuranceAmount = value;
            }
        }
        //methode of storing chasis name of vehicle 
        public string RfIdTagNum
        {
            get
            {
                return strRfIdTagNum;
            }
            set
            {
                strRfIdTagNum = value;
            }
        }
        //methode of storing Is Amount per barrel
        public decimal AmountPerBarrel
        {
            get
            {
                return intAmountperBarrel;
            }
            set
            {
                intAmountperBarrel = value;
            }
        }
        //methode of storing Is tanker capacity
        public decimal TankCapacity
        {
            get
            {
                return intTankCapacity;
            }
            set
            {
                intTankCapacity = value;
            }
        }
        //methode of storing Is tanker or not
        public int IsTanker
        {
            get
            {
                return intIsTanker;
            }
            set
            {
                intIsTanker = value;
            }
        }
        //methode of storing Fuel limit
        public decimal FuelLimit
        {
            get
            {
                return intFuelLimit;
            }
            set
            {
                intFuelLimit = value;
            }
        }
        //methode of storing Registration Type number
        public int RegTypeId
        {
            get
            {
                return intRegTypeId;
            }
            set
            {
                intRegTypeId = value;
            }
        }
        //methode of storing chasis name of vehicle 
        public string ChasisNumber
        {
            get
            {
                return strChasisNumber;
            }
            set
            {
                strChasisNumber = value;
            }
        }
        //methode of storing deleted file name 
        public string VehFileName2Deleted
        {
            get
            {
                return strVehFileName2Deleted;
            }
            set
            {
                strVehFileName2Deleted = value;
            }
        }
        //methode of storing deleted file name 
        public string VehFileName1Deleted
        {
            get
            {
                return strVehFileName1Deleted;
            }
            set
            {
                strVehFileName1Deleted = value;
            }
        }
        //methode of storing serial number
        public int SerialNumber2
        {
            get
            {
                return intSerialNumber2;
            }
            set
            {
                intSerialNumber2 = value;
            }
        }
        //methode of storing serial number
        public int SerialNumber
        {
            get
            {
                return intSerialNumber;
            }
            set
            {
                intSerialNumber = value;
            }
        }
        //methode of storing next id file name 
        public int NextIdForVehicle
        {
            get
            {
                return intNextId;
            }
            set
            {
                intNextId = value;
            }
        }
        //methode of storing file name 
        public string VehFileName1
        {
            get
            {
                return strVehFileName1;
            }
            set
            {
                strVehFileName1 = value;
            }
        }
        //methode of storing file name 
        public string VehFileNameAct1
        {
            get
            {
                return strVehFileNameAct1;
            }
            set
            {
                strVehFileNameAct1 = value;
            }
        }
        //methode of storing file name 
        public string VehFileName2
        {
            get
            {
                return strVehFileName2;
            }
            set
            {
                strVehFileName2 = value;
            }
        }
        //methode of storing file name 
        public string VehFileNameAct2
        {
            get
            {
                return strVehFileNameAct2;
            }
            set
            {
                strVehFileNameAct2 = value;
            }
        }
        //methode of storing file name 
        public int VehicleId
        {
            get
            {
                return intVehicleId;
            }
            set
            {
                intVehicleId = value;
            }
        }
       
         //methode of storing file name 
        public string FileNameInsur
        {
            get
            {
                return strFileNameInsur;
            }
            set
            {
                strFileNameInsur = value;
            }
        }
        //methode of storing file name 
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        //methode of storing insurance expiry of vehicle
        public DateTime InsuranceExpirydate
        {
            get
            {
                return dateInsuranceExpirydate;
            }
            set
            {
                dateInsuranceExpirydate = value;
            }
        }
        //methode of storing permit expiry of vehicle
        public DateTime PermitExpiryDate
        {
            get
            {
                return datePermitExpiryDate;
            }
            set
            {
                datePermitExpiryDate = value;
            }
        }
        //methode of storing permit of vehicle
        public string PermitNumber
        {
            get
            {
                return strPermitNumber;
            }
            set
            {
                strPermitNumber = value;
            }
        }
        //methode of storing vehicle purchase date
        public DateTime VehPurchaseDate
        {
            get
            {
                return dateVehPurchaseDate;
            }
            set
            {
                dateVehPurchaseDate = value;
            }
        }
        //methode of storing mileage of vehicle
        public string Insurance
        {
            get
            {
                return strInsurance;
            }
            set
            {
                strInsurance = value;
            }
        }
        //methode of storing mileage of vehicle
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }
        //methode of storing mileage of vehicle
        public string VehicleNumber
        {
            get
            {
                return strVehicleNumber;
            }
            set
            {
                strVehicleNumber = value;
            }
        }

        //methode of storing mileage of vehicle
        public decimal Mileage
        {
            get
            {
                return intMileage;
            }
            set
            {
                intMileage = value;
            }
        }

        //methode of kilometre per litre storing
        public decimal KilometerPerLitre
        {
            get
            {
                return intKml;
            }
            set
            {
                intKml = value;
            }
        }
        //methode of storing vehicle modal year
        public int ModalYear
        {
            get
            {
                return intModalYear;
            }
            set
            {
                intModalYear = value;
            }
        }
        //methode of fuel type id storing
        public int FuelTypeId
        {
            get
            {
                return intFuelTypeId;
            }
            set
            {
                intFuelTypeId = value;
            }
        }
        //methode of insurance provider id storing
        public int InsureProviderId
        {
            get
            {
                return intInsureProviderId;
            }
            set
            {
                intInsureProviderId = value;
            }
        }

        //methode of vehicle type id storing
        public int VehicleTypeId
        {
            get
            {
                return intVehicleTypeId;
            }
            set
            {
                intVehicleTypeId = value;
            }
        }
        //methode of vehicle class id storing
        public int VehicleClassId
        {
            get
            {
                return intVehicleClassId;
            }
            set
            {
                intVehicleClassId = value;
            }
        }


        //methode of App mode section id storing
        public int AppModeSection
        {
            get
            {
                return intAppModeSection;
            }
            set
            {
                intAppModeSection = value;
            }
        }
        //methode of organisation id storing
        public int Organisation_id
        {
            get
            {
                return intOrgId;
            }
            set
            {
                intOrgId = value;
            }
        }
        //methode of corporate id storing
        public int Corporate_id
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }

        //methode of user id storing
        public int User_Id
        {
            get
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }
        //methode of status id storing
        public int Status_id
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
      

        //methode of storing date of the entry
        public DateTime Date
        {
            get
            {
                return dDate;
            }
            set
            {
                dDate = value;
            }
        }

        //methode of cancel reason storing storing
        public string CancelReason
        {
            get
            {
                return strCancelReason;
            }
            set
            {
                strCancelReason = value;
            }
        }
        //methode of storing cancel status
        public int CancelStatus
        {
            get
            {
                return intCancelStatus;
            }
            set
            {
                intCancelStatus = value;
            }
        }
        //methode of storing cancel status
        public int ImageId
        {
            get
            {
                return intImageId;
            }
            set
            {
                intImageId = value;
            }
        }
         //methode of storing cancel status
        public decimal EngineCapacity
        {
            get
            {
                return intCapacity;
            }
            set
            {
                intCapacity = value;
            }
        }
        //methode of vehicle class name storing
        public string SearchField
        {
            get
            {
                return strSearchField;
            }
            set
            {
                strSearchField = value;
            }
        }
        //methode of vehicle class name storing
        public string DataBase_Field
        {
            get
            {
                return strDataBaseField;
            }
            set
            {
                strDataBaseField = value;
            }
        }
        //method for storing vehicle make
        public int Make
        {
            get
            {
                return strMake;
            }
            set
            {
                strMake = value;
            }
        }
        //method for storing vehicle model
        public string Model
        {
            get
            {
                return strModel;
            }
            set
            {
                strModel = value;
            }
        }
        //method for storing vehicle transmission type Id
        public int TransmsnTypeId
        {
            get
            {
                return intTransmsnTpeId;
            }
            set
            {
                intTransmsnTpeId = value;
            }
        }
        //method for storing vehicle color Id
        public int ColorId
        {
            get
            {
                return intColorId;
            }
            set
            {
                intColorId = value;
            }
        }
        //method for storing dealer name
        public string DealerName
        {
            get
            {
                return strDealerName;
            }
            set
            {
                strDealerName = value;
            }
        }
        //method for storing contact number
        public string ContactNo
        {
            get
            {
                return strContactNo;
            }
            set
            {
                strContactNo = value;
            }
        }
        //method for storing vehicle price
        public decimal Price
        {
            get
            {
                return decPrice;
            }
            set
            {
                decPrice = value;
            }
        }
        //method for storing insurance coverage type
        public int CoverageTypeId
        {
            get
            {
                return intCoverageType;
            }
            set
            {
                intCoverageType = value;
            }
        }
        //method for storing registration number of trailer
        public string TrailerRegNum
        {
            get
            {
                return strTrailerRegNum;
            }
            set
            {
               strTrailerRegNum = value;
            }
        }

        //method for storing insurance number of trailer
        public string TrailerInsNum
        {
            get
            {
                return strTrailerInsNUm;
            }
            set
            {
               strTrailerInsNUm = value;
            }
        }


    }
}
