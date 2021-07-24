using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0014
// CREATED DATE:27/04/2017
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Employee Contact Details .

namespace EL_Compzit
{
    public class clsEntityLayerContactDtls
    {
        private int IntEmpId = 0;
        private int IntCorp_Id = 0;
        private int IntOrg_Id = 0;
        private int IntUser_id = 0;
        //permanent Address 
        private int intCountryId = 0;
        private int? intStateId = 0;
        private int? intCityId = 0;
        private string strAdd1 = null;
        private string strAdd2 = null;
        private string strAdd3 = null;
        private string strZipCode = null;
        private string strPhone = null;
        private string strMobile = null;
        private string strEmail = null;
        private string strFax = null;
        //Communication Address
        private int intCommuCountryId = 0;
        private int? intCommuStateId = 0;
        private int? intCommuCityId = 0;
        private string strCommuAdd1 = null;
        private string strCommuAdd2 = null;
        private string strcommuAdd3 = null;
        private string strCommuZipCode = null;
        private string strCommuPhone = null;
        private string strCommuMobile = null;
        private string strCommuEmail = null;
        private string strCommuFax = null;
        //Emergency Adrress
        private string strEmgName = null;
        private string strEmgAdd = null;
        private string strEmgPhone = null;
        private string strEmgMobile = null;
        private string strEmgEmail = null;
        private string strEmgFax = null;
        private string strEmgRelat = null;
        private DateTime InsDate;
        private DateTime UpdDate;
        private int IntInsUser_id = 0;
        private int IntUpdUser_id = 0;

        public int EmpID
        {
            get
            {
                return IntEmpId;
            }
            set
            {
                IntEmpId = value;
            }
        }
        public int CorpOffice_Id
        {
            get
            {
                return IntCorp_Id;
            }
            set
            {
                IntCorp_Id = value;
            }
        }

        public int Organisation_Id
        {
            get
            {
                return IntOrg_Id;
            }
            set
            {
                IntOrg_Id = value;
            }
        }

        public int User_Id
        {
            get
            {
                return IntUser_id;
            }
            set
            {
                IntUser_id = value;
            }
        }

        //Methode for storing Country id of employee.
        public int CountryId
        {
            get
            {
                return intCountryId;
            }
            set
            {
                intCountryId = value;
            }
        }

        //Method for storing state id of employee.
        public int? StateId
        {
            get
            {
                return intStateId;
            }
            set
            {
                intStateId = value;
            }
        }

        //Method for storing city id of employee.
        public int? CityId
        {
            get
            {
                return intCityId;
            }
            set
            {
                intCityId = value;
            }
        }

        //Method for storing address of employee
        public string Address1
        {
            get
            {
                return strAdd1;
            }
            set
            {
                strAdd1 = value;
            }
        }

        //Method for storing address of employee
        public string Address2
        {
            get
            {
                return strAdd2;
            }
            set
            {
                strAdd2 = value;
            }
        }

        //Method for storing address of employee
        public string Address3
        {
            get
            {
                return strAdd3;
            }
            set
            {
                strAdd3 = value;
            }
        }

        //Method fort storing zip code/pin code of Employee.
        public string ZipCode
        {
            get
            {
                return strZipCode;
            }
            set
            {
                strZipCode = value;
            }
        }

        //Method for storing phone number of Employee.
        public string Phone_Number
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        //Method for storing mobile number of Employee.
        public string Mobile_Number
        {
            get
            {
                return strMobile;
            }
            set
            {
                strMobile = value;
            }
        }

        //Method of storing email address of employee.
        public string Email_Address
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }

        //Method of storing Fax number of employee.
        public string Fax
        {
            get
            {
                return strFax;
            }
            set
            {
                strFax = value;
            }
        }

        public int Cmu_CountryId
        {
            get
            {
                return intCommuCountryId;
            }
            set
            {
                intCommuCountryId = value;
            }
        }

        public int? Cmu_StateId
        {
            get
            {
                return intCommuStateId;
            }
            set
            {
                intCommuStateId = value;
            }
        }

        public int? Cmu_CityId
        {
            get
            {
                return intCommuCityId;
            }
            set
            {
                intCommuCityId = value;
            }
        }
        //Method for storing address of employee
        public string Cmu_Address1
        {
            get
            {
                return strCommuAdd1;
            }
            set
            {
                strCommuAdd1 = value;
            }
        }
        //Method for storing address of employee
        public string Cmu_Address2
        {
            get
            {
                return strCommuAdd2;
            }
            set
            {
                strCommuAdd2 = value;
            }
        }
        //Method for storing address of employee
        public string Cmu_Address3
        {
            get
            {
                return strcommuAdd3;
            }
            set
            {
                strcommuAdd3 = value;
            }
        }
        //Method fort storing zip code/pin code of Employee.
        public string Cmu_ZipCode
        {
            get
            {
                return strCommuZipCode;
            }
            set
            {
                strCommuZipCode = value;
            }
        }
        //Method for storing phone number of Employee.
        public string Cmu_Phone_Number
        {
            get
            {
                return strCommuPhone;
            }
            set
            {
                strCommuPhone = value;
            }
        }
        //Method for storing mobile number of Employee.
        public string Cmu_Mobile_Number
        {
            get
            {
                return strCommuMobile;
            }
            set
            {
                strCommuMobile = value;
            }
        }
        //Method of storing email address of employee.
        public string Cmu_Email_Address
        {
            get
            {
                return strCommuEmail;
            }
            set
            {
                strCommuEmail = value;
            }
        }
        //Method of storing Fax number of employee.
        public string Cmu_Fax
        {
            get
            {
                return strCommuFax;
            }
            set
            {
                strCommuFax = value;
            }
        }
        //Method of storing emergency contact name of employee.
        public string Emrg_Name
        {
            get
            {
                return strEmgName;
            }
            set
            {
                strEmgName = value;
            }
        }
        //Method of storing emergency contact Address of employee.
        public string Emrg_Address
        {
            get
            {
                return strEmgAdd;
            }
            set
            {
                strEmgAdd = value;
            }
        }
        //Method of storing emergency contact relation of employee.
        public string Emrg_Relation
        {
            get
            {
                return strEmgRelat;
            }
            set
            {
                strEmgRelat = value;
            }
        }
        //Method of storing emergency contact phonenumber of employee.
        public string Emrg_Phone
        {
            get
            {
                return strEmgPhone;
            }
            set
            {
                strEmgPhone = value;
            }
        }
        //Method of storing emergency contact mobile of employee.
        public string Emrg_Moble
        {
            get
            {
                return strEmgMobile;
            }
            set
            {
                strEmgMobile = value;
            }
        }
        //Method of storing emergency contact email of employee.
        public string Emrg_Email
        {
            get
            {
                return strEmgEmail;
            }
            set
            {
                strEmgEmail = value;
            }
        }
        //Method of storing emergency contact fax of employee.
        public string Emrg_Fax
        {
            get
            {
                return strEmgFax;
            }
            set
            {
                strEmgFax = value;
            }
        }
        //Method for storing insert date
        public DateTime Ins_date
        {
            get
            {
                return InsDate;
            }
            set
            {
                InsDate = value;
            }
        }
        //Method for storing updt date
        public DateTime Upd_Date
        {
            get
            {
                return UpdDate;
            }
            set
            {
                UpdDate = value;
            }
        }
        //Method for storing insert user id
        public int Ins_Userid
        {
            get
            {
                return IntInsUser_id;
            }
            set
            {
                IntInsUser_id = value;
            }
        }
        //Method for storing updt user id
        public int Upd_Userid
        {
            get
            {
                return IntUpdUser_id;
            }
            set
            {
                IntUpdUser_id = value;
            }
        }

    }
}
