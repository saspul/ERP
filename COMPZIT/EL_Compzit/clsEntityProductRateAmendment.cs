using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:28/03/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
    public class clsEntityProductRateAmendment
    {

        private int intOrganisationId = 0;
        private int intCorporateId = 0;
        private string strProductExtCode = null;
        private decimal decProductRate = 0;
        private Int64 intUserId = 0;
        private DateTime dDate;
        private string strProductName = null;

        //methode of storing product name
        public string Product_Name
        {
            get
            {
                return strProductName;
            }
            set
            {
                strProductName = value;
            }
        }

        //Method of store the userid
        public Int64 User_Id
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
        //Method of storing the date when event occurs
        public DateTime D_Date
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
        //Method of storing id of organisation
        public int Org_Id
        {
            get
            {
                return intOrganisationId;
            }
            set
            {
                intOrganisationId = value;
            }
        }
        //Method of storing id of corporate office
        public int Corp_Id
        {
            get
            {
                return intCorporateId;
            }
            set
            {
                intCorporateId = value;
            }
        }
        //methode of storing product external code
        public string Product_Ext_Code
        {
            get
            {
                return strProductExtCode;
            }
            set
            {
                strProductExtCode = value;
            }
        }
        //methode of storing product rate
        public decimal Product_Rate
        {
            get
            {
                return decProductRate;
            }
            set
            {
                decProductRate = value;
            }
        }

    }
}
