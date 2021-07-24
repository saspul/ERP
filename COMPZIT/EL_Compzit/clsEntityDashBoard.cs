using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityDashBoard
    {
        private int intCorporateOfficeID = 0;
        private int intOrgid = 0;
        private int intSectionId = 0;
        private int intCurrencyId = 0;
        private int intUserId = 0;

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
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }
        public int SectionId
        {
            get
            {
                return intSectionId;
            }
            set
            {
                intSectionId = value;
            }
        }
        //Method for storing Login Corporate Office ID
        public int CorporateID
        {
            get
            {
                return intCorporateOfficeID;
            }
            set
            {
                intCorporateOfficeID = value;
            }
        }  //property for storing organistion id.
        public int Organisation_Id
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }
    }
}
