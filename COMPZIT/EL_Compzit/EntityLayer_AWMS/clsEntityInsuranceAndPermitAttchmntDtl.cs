using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityInsuranceAndPermitAttchmntDtl
    {
        private int intRnwlAttchmntDtlId = 0;
        private string strFileName = "";
        private string strActualFileName = "";
        private int intRnwlAttchmntSlNumber = 0;
        private int intRnwlId = 0;
        private int intCorpOffice_Id = 0;
        private int intRnwlFileType = 0;
        private string strDescrptn = "";
        //property of storing Detail id of attachment
        public int RnwlAttchmntDtlId
        {
            get
            {
                return intRnwlAttchmntDtlId;
            }
            set
            {
                intRnwlAttchmntDtlId = value;
            }
        }


        //Property of storing the file name of attachment
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
        //property of storing actual file name of attachment 
        public string ActualFileName
        {
            get
            {
                return strActualFileName;
            }
            set
            {
                strActualFileName = value;
            }
        }
        //property of storing Slnumber of  attachment
        public int RnwlAttchmntSlNumber
        {
            get
            {
                return intRnwlAttchmntSlNumber;
            }
            set
            {
                intRnwlAttchmntSlNumber = value;
            }
        }

        public int RnwlId
        {
            get
            {
                return intRnwlId;
            }
            set
            {
                intRnwlId = value;
            }
        }
        public int CorpOffice_Id
        {
            get
            {
                return intCorpOffice_Id;
            }
            set
            {
                intCorpOffice_Id = value;
            }
        }

        public int RnwlFileType
        {
            get
            {
                return intRnwlFileType;
            }
            set
            {
                intRnwlFileType = value;
            }
        }

        //Property of storing the description of attachment
        public string Description
        {
            get
            {
                return strDescrptn;
            }
            set
            {
                strDescrptn = value;
            }
        }
    }
}
