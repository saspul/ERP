using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Corporate Pack Module .
namespace EL_Compzit
{
    public class clsEntityCorporatePack
    {
        private int intCorporateId = 0;
        private int intCorporateCnt = 0;
        private int intStatus = 0;
        private string strCrpPackName = "";
        // This is the property definition for storing Corporate Pack Count.
        public int CrprtPackCnt
        {
            get
            {
                return intCorporateCnt;
            }
            set
            {
                intCorporateCnt = value;
            }
        }

        // This is the property definition for storing Id of Corporate Master.
        public int CrprtPackId
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

        // This is the property definition for storing Status of Corporate Master.
        public int CrpStatus
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
        // This is the property definition for storing Pack name of Corporate .
        public string CrpPackName
        {
            get
            {
                return strCrpPackName;
            }
            set
            {
                strCrpPackName = value;
            }
        }

    }
}
