using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityCostGrpPerfAnalysis
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intHeirarchyId = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private int intCostGrpId = 0;
        private string strCostGrpIds = "";
        private int intMode = 0;
        private int intAllCstCntr = 0;
        private string strCostCentreIds = "";

        public string CostCentreIds
        {
            get
            {
                return strCostCentreIds;
            }
            set
            {
                strCostCentreIds = value;
            }
        }
        public int AllCostCentres
        {
            get
            {
                return intAllCstCntr;
            }
            set
            {
                intAllCstCntr = value;
            }
        }
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
            }
        }
        public string CostGrpIds
        {
            get
            {
                return strCostGrpIds;
            }
            set
            {
                strCostGrpIds = value;
            }
        }
        public int CostGrpId
        {
            get
            {
                return intCostGrpId;
            }
            set
            {
                intCostGrpId = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
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
        public int HeirarchyId
        {
            get
            {
                return intHeirarchyId;
            }
            set
            {
                intHeirarchyId = value;
            }
        }
    }
}

