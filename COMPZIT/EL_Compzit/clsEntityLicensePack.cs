using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the License Pack.
namespace EL_Compzit
{
   public class clsEntityLicensePack
    {
        private int intLicPacId = 0;
        private int intLicPacStarts = 0;
        private int intLicPacEnds = 0;
        private int intLicPacStatus = 0;
        private string strLicPackName = "";
        // This is the property definition for storing Corporate Pack Minimum User.
        public int LicPacStarts
        {
            get
            {
                return intLicPacStarts;
            }
            set
            {
                intLicPacStarts = value;
            }
        }
        // This is the property definition for storing Corporate Pack Maximum User.
        public int LicPacEnds
        {
            get
            {
                return intLicPacEnds;
            }
            set
            {
                intLicPacEnds = value;
            }
        }

        // This is the property definition for storing Id of License Master.
        public int LicPackId
        {
            get
            {
                return intLicPacId;
            }
            set
            {
                intLicPacId = value;
            }
        }

        // This is the property definition for storing Status of License Master.
        public int LicPacStatus
        {
            get
            {
                return intLicPacStatus;
            }
            set
            {
                intLicPacStatus = value;
            }
        }
        // This is the property definition for storing Pack name of License.
        public string LicPacName
        {
            get
            {
                return strLicPackName;
            }
            set
            {
                strLicPackName = value;
            }
        }

    }
}
