
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityLayerUserRegistration
    {
        private int intUsrRegistrationId = 0;
        private int intNextId = 0;
        private string strUserName = "";
        private int intUserDsgnId = 0;
        private int intUserRoleId = 0;//0013
        private DateTime dateJoining;
        private int intEmployeeTypId = 0;
        private string strNationalIdNumber = "";
        private string strUserCode = "";
        private string strUserMobile = "";
        private string strUserEmail = "";
        private string strOffclEmail = "";
        private string strImagePath = "";
        private int intMailSendStatus = 0;
        private int intMailReadStatus = 0;
        private int intUserStatus = 0;
      
        private int intUserCrprtId = 0;
        private int intUserCrprtDept = 0;
        private string strUserCrprtId = "0";
        private int intUserOrgId = 0;

        private char charDsgControl;

        private bool blLoginMust = false;
        private string strLoginName = "";
        private string strUserPsw = "";
        private int intLimitedUser = 1;
        private int intPasswordExpiry = 1;

        private bool blAutoWrkShopMust = false;
        private string strLicenseNumber = "";
        private DateTime dateLicenseExpiry;
        private int intAccommodationId = 0;
        private int intAllowDutyRoster = 0;
        private string strLicenseCopyPath = "";

        private int intUserId = 0;
        private string strCnclReason = "";
        private DateTime dateofEvent;
        private string strUserdvsnId = "";



        private string strOldUsrPsw = "";
        private int intCancelStatus = 0;


        private string strFname = "";
        private string strMname = "";
        private string strLname = "";
        private int intCountryid = 0;
        private int intGender = 0;

        private int intusrmode = 0;
        private int intEmpToReportid = 0;


        //0039
        private DateTime dateLeaveFrmDate;

        private DateTime dateLeaveToDate;

        private int intUserTypeStatus;
        private string strUserCodeNew;

        private int intUserIdMain;

        //end
              
        
        
        
        //For official name
        public string OffclEmail
        {
            get
            {
                return strOffclEmail;
            }
            set
            {
                strOffclEmail = value;
            }
        }
        //staff or wokers
        public int UsrType
        {
            get
            {
                return intusrmode;
            }
            set
            {
                intusrmode = value;
            }
        }

        // This is the property definition for storing Id of User Registered.
        public int UsrRegistrationId
        {
            get
            {
                return intUsrRegistrationId;
            }
            set
            {
                intUsrRegistrationId = value;
            }
        }

        // This is the property definition for storing Next Id of Registration in MASTER_ID_GENERATION table.
        public int NextId
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
        // This is the property definition for storing name of User.
        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
            }
        }

        // This is the property definition for storing Id of Designation assigned to User .
        public int UserDsgnId
        {
            get
            {
                return intUserDsgnId;
            }
            set
            {
                intUserDsgnId = value;
            }
        }
        public string UserDvsnId
        {
            get
            {
                return strUserdvsnId;
            }
            set
            {
                strUserdvsnId = value;
            }
        }
        //013
        // This is the property definition for storing Id of Job Role assigned to User .
        public int UserRoleId
        {
            get
            {
                return intUserRoleId;
            }
            set
            {
                intUserRoleId = value;
            }
        }
        // This is the property definition for storing Date of Joining .
        public DateTime JoiningDate
        {
            get
            {
                return dateJoining;
            }
            set
            {
                dateJoining = value;
            }
        }
        //methode of first name storing
        public string Fname
        {
            get
            {
                return strFname;
            }
            set
            {
                strFname = value;
            }
        }
        //methode of middle name storing
        public string Mname
        {
            get
            {
                return strMname;
            }
            set
            {
                strMname = value;
            }
        }
        //methode of last name storing
        public string Lname
        {
            get
            {
                return strLname;
            }
            set
            {
                strLname = value;
            }
        }
        //methode of country id storing
        public int CountryID
        {
            get
            {
                return intCountryid;
            }
            set
            {
                intCountryid = value;
            }
        }
        //methode of gender storing
        public int Gender
        {
            get
            {
                return intGender;
            }
            set
            {
                intGender = value;
            }
        }
        // This is the property definition for storing Type Id of User.
        public int EmployeeTypId
        {
            get
            {
                return intEmployeeTypId;
            }
            set
            {
                intEmployeeTypId = value;
            }
        }
        // This is the property definition for storing National Id Number of User.
        public string NationalIdNumber
        {
            get
            {
                return strNationalIdNumber;
            }
            set
            {
                strNationalIdNumber = value;
            }
        }
        // This is the property definition for storing Code of User.
        public string UserCode
        {
            get
            {
                return strUserCode;
            }
            set
            {
                strUserCode = value;
            }
        }

        // This is the property definition for storing Mobile number of User.
        public string UserMobile
        {
            get
            {
                return strUserMobile;
            }
            set
            {
                strUserMobile = value;
            }
        }
        // This is the property definition for storing  Email of Designation .
        public string UserEmail
        {
            get
            {
                return strUserEmail;
            }
            set
            {
                strUserEmail = value;
            }
        }
        // This is the property definition for storing Path of image.
        public string ImagePath
        {
            get
            {
                return strImagePath;
            }
            set
            {
                strImagePath = value;
            }
        }

        //This variable stores the value of Mail send from personal mail id or division mail
        public int MailSendSts
        {
            get
            {
                return intMailSendStatus;
            }
            set
            {
                intMailSendStatus = value;
            }
        }
        //This variable stores the value whether to read Mail of user or not
        public int MailReadSts
        {
            get
            {
                return intMailReadStatus;
            }
            set
            {
                intMailReadStatus = value;
            }
        }
        // This is the property definition for storing status for User .
        public int UserStatus
        {
            get
            {
                return intUserStatus;
            }
            set
            {
                intUserStatus = value;
            }
        }
        // This is the property definition for storing Corporate of user registered.
        public int UserCrprtId
        {
            get
            {
                return intUserCrprtId;
            }
            set
            {
                intUserCrprtId = value;
            }
        }

        // This is the property definition for storing CORPRT_ID for adding divisions.
        public string strCrprtId
        {
            get
            {
                return strUserCrprtId;
            }
            set
            {
                strUserCrprtId = value;
            }
        }
        // This is the property definition for storing Id of Corporate Drpartment assigned to User .
        public int UserCrprtDept
        {
            get
            {
                return intUserCrprtDept;
            }
            set
            {
                intUserCrprtDept = value;
            }
        }
        // This is the property definition for storing Organisation Id of the User .
        public int UserOrgId
        {
            get
            {
                return intUserOrgId;
            }
            set
            {
                intUserOrgId = value;
            }
        }

        // This is the property definition for storing  Control type of Designation .
        public char DsgControl
        {
            get
            {
                return charDsgControl;
            }
            set
            {
                charDsgControl = value;
            }
        }


        // This is the property definition for checking Login Must or not.
        public bool LoginMust
        {
            get
            {
                return blLoginMust;
            }
            set
            {
                blLoginMust = value;
            }
        }

        // This is the property definition for storing Login name of User.
        public string LoginName
        {
            get
            {
                return strLoginName;
            }
            set
            {
                strLoginName = value;
            }
        }


        // This is the property definition for storing Password of the User .
        public string UserPsw
        {
            get
            {
                return strUserPsw;
            }
            set
            {
                strUserPsw = value;
            }
        }

        // This is the property definition for storing If USER is Limited ORNot .
        public int LimitedUser
        {
            get
            {
                return intLimitedUser;
            }
            set
            {
                intLimitedUser = value;
            }
        }

        // This is the property definition for storing If USER's Password Expiry or not .
        public int PasswordExpiry
        {
            get
            {
                return intPasswordExpiry;
            }
            set
            {
                intPasswordExpiry = value;
            }
        }

        // This is the property definition for checking AutoWrkShop Must or not.
        public bool AutoWrkShopMust
        {
            get
            {
                return blAutoWrkShopMust;
            }
            set
            {
                blAutoWrkShopMust = value;
            }
        }

        // This is the property definition for storing License Number of the User .
        public string LicenseNumber
        {
            get
            {
                return strLicenseNumber;
            }
            set
            {
                strLicenseNumber = value;
            }
        }

        // This is the property definition for storing Date of Expiry .
        public DateTime LicenseExpiryDate
        {
            get
            {
                return dateLicenseExpiry;
            }
            set
            {
                dateLicenseExpiry = value;
            }
        }
        // This is the property definition for storing Accommodation.
        public int AccommodationId
        {
            get
            {
                return intAccommodationId;
            }
            set
            {
                intAccommodationId = value;
            }
        }
        // This is the property definition for storing If to Allow Duty Roster or not.
        public int AllowDutyRoster
        {
            get
            {
                return intAllowDutyRoster;
            }
            set
            {
                intAllowDutyRoster = value;
            }
        }

        // This is the property definition for storing path of license copy .
        public string LicenseCopyPath
        {
            get
            {
                return strLicenseCopyPath;
            }
            set
            {
                strLicenseCopyPath = value;
            }
        }
        // This is the property definition for storing Cancelation reason .
        public string UserCancelReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }
        // This is the property definition for storing Date of updation, cancelation and insertion .
        public DateTime UserDate
        {
            get
            {
                return dateofEvent;
            }
            set
            {
                dateofEvent = value;
            }
        }




        // This is the property definition for storing Id of User inserting,updating and canceling .
        public int UserId
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





        // This is the property definition for storing old Password of the User .
        public string UserOldPsw
        {
            get
            {
                return strOldUsrPsw;
            }
            set
            {
                strOldUsrPsw = value;
            }
        }
        //methode of cancel status storing
        public int Cancel_Status
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
        
        //0039

        public int UserIdMain
        {
            get
            {
                return intUserIdMain;
            }
            set
            {
                intUserIdMain = value;
            }
        }

        public DateTime LeaveFrmDate
        {
            get
            {
                return dateLeaveFrmDate;
            }
            set
            {
                dateLeaveFrmDate = value;
            }
        }

        public DateTime LeaveToDate
        {
            get
            {
                return dateLeaveToDate;
            }
            set
            {
                dateLeaveToDate = value;
            }
        }

        public int UserTypeStatus
        {
            get
            {
                return intUserTypeStatus;
            }
            set
            {
                intUserTypeStatus = value;
            }
        }

        public string UserCodeNew
        {
            get
            {
                return strUserCodeNew;
            }
            set
            {
                strUserCodeNew = value;
            }
        }

        //end
        public int EmployeeToReport    //EMP25
        {
            get
            {
                return intEmpToReportid;
            }
            set
            {
                intEmpToReportid = value;
            }
        }
    }
    // This class will be used for storing User Corporate information in case of multiple corporate choosen.
    public class clsEntityLayerUserCorporate
    {
        private int intUsrOrgId = 0;
        private int intUsrId = 0;
        private int intUsrCrprtId = 0;
        private int intSubBusUntId = 0;//0013
        // This is the property definition for storing USR_Org Id for adding to GN_USER_CORPORATE table.
        public int UsrOrgId
        {
            get
            {
                return intUsrOrgId;
            }
            set
            {
                intUsrOrgId = value;
            }
        }
        // This is the property definition for storing USR Id for adding to GN_USER_CORPORATE table.
        public int UsrUsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        // This is the property definition for storing CORPRT_ID for adding to GN_USER_CORPORATE table.
        public int UsrCrprtId
        {
            get
            {
                return intUsrCrprtId;
            }
            set
            {
                intUsrCrprtId = value;
            }
        }
        public int SubBusUntId
        {
            get
            {
                return intSubBusUntId;
            }
            set
            {
                intSubBusUntId = value;
            }
        }



    }

    // This class will be used for storing User lcense type GN_USER_VHCL_LICTYP.
    public class clsEntityLayerUserVhclType
    {
        private int intUsrVhclLicTypId = 0;
        private int intUsrId = 0;
        private int intLicTypeId = 0;
        // This is the property definition for storing VhclLicTypId Id for adding to GN_USER_VHCL_LICTYP table.
        public int UsrVhclLicTypId
        {
            get
            {
                return intUsrVhclLicTypId;
            }
            set
            {
                intUsrVhclLicTypId = value;
            }
        }
        // This is the property definition for storing USR Id for adding to GN_USER_VHCL_LICTYP table.
        public int UsrUsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        // This is the property definition for storing LicTypeId for adding to GN_USER_VHCL_LICTYP table.
        public int LicTypeId
        {
            get
            {
                return intLicTypeId;
            }
            set
            {
                intLicTypeId = value;
            }
        }


    }
    // This class will be used for storing User Division information in case of  Division choosen.
    public class clsEntityLayerUserDivision
    {
        private int intOrgId = 0;
        private int intUsrId = 0;
        private int intCrpDivisnId = 0;
        private int intDfltCrpDivisnId = 0;

        private int intPrimaryDivsnSts = 0;


        public int PrimaryDivsnSts
        {
            get
            {
                return intPrimaryDivsnSts;
            }
            set
            {
                intPrimaryDivsnSts = value;
            }
        }

        // This is the property definition for storing USR_Org Id for adding to GN_USER_DIVISION table.
        public int OrgId
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
        // This is the property definition for storing USR Id for adding to GN_USER_DIVISION table.
        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        // This is the property definition for storing DIVISION_ID for adding to GN_USER_DIVISION table.
        public int Divisn_Id
        {
            get
            {
                return intCrpDivisnId;
            }
            set
            {
                intCrpDivisnId = value;
            }
        }
        // This is the property definition for storing DFLT_DIVISION_ID for adding to GN_USER_DIVISION table.
        public int DfltCrpDivisnId
        {
            get
            {
                return intDfltCrpDivisnId;
            }
            set
            {
                intDfltCrpDivisnId = value;
            }
        }
    }
    //0013
    // This class will be used for storing User Sub Business Unit information in case of  Sub Business choosen.
    public class clsEntityLayerUserSubBusness
    {
        private int intOrgId = 0;
        private int intUsrId = 0;
        private int intSubBusUntId = 0;
        private int intDfltSubBusUntId = 0;
        private int intUsrCrprtId = 0;
        // This is the property definition for storing USR_Org Id for adding to GN_USER_DIVISION table.
        public int OrgId
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
        // This is the property definition for storing USR Id for adding to GN_USER_DIVISION table.
        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        // This is the property definition for storing DIVISION_ID for adding to GN_USER_DIVISION table.
        public int SubBusUntId
        {
            get
            {
                return intSubBusUntId;
            }
            set
            {
                intSubBusUntId = value;
            }
        }
        public int DfltSubBusUntId
        {
            get
            {
                return intDfltSubBusUntId;
            }
            set
            {
                intDfltSubBusUntId = value;
            }
        }
        public int UsrCrprtId
        {
            get
            {
                return intUsrCrprtId;
            }
            set
            {
                intUsrCrprtId = value;
            }
        }

    }
    public class clsEntityLayerEmployeeWelfareSrvc   //EMP0025
    {
        private int intEmp_Id = 0;
        private int intWelfare_Id = 0;
        private decimal decQty = 0;
        private decimal decActQty = 0;
        private string strWelfrSub_Id = "";
        private int intWlfrSub_Id = 0;

        private int intchkSts = 0;
        private int intcheckboxsts = 0;
        private int intDepId = 0;
        private int intDesgId=0;

        public int DesgId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
            }
        }
        public int DepId
        {
            get
            {
                return intDepId;
            }
            set
            {
                intDepId = value;
            }
        }
        public int checkboxsts
        {
            get
            {
                return intcheckboxsts;
            }
            set
            {
                intcheckboxsts = value;
            }
        }
        public int chkSts
        {
            get
            {
                return intchkSts;
            }
            set
            {
                intchkSts = value;
            }
        }
        public int WelfrSub_Id
        {
            get
            {
                return intWlfrSub_Id;
            }
            set
            {
                intWlfrSub_Id = value;
            }
        }
        public string WelfSub_Id
        {
            get
            {
                return strWelfrSub_Id;
            }
            set
            {
                strWelfrSub_Id = value;
            }
        }
        public int Emp_Id
        {
            get
            {
                return intEmp_Id;
            }
            set
            {
                intEmp_Id = value;
            }
        }

        public int Welfare_Id
        {
            get
            {
                return intWelfare_Id;
            }
            set
            {
                intWelfare_Id = value;
            }
        }
        public decimal ActQty
        {
            get
            {
                return decActQty;
            }
            set
            {
                decActQty = value;
            }
        }
        public decimal Qty
        {
            get
            {
                return decQty;
            }
            set
            {
                decQty = value;
            }
        }
    }
}
