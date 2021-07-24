using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityLayerLeadAttchmntDtl
    {
        private int intLeadAttchmntDtlId = 0;
        private string strFileName = "";
        private string strActualFileName = "";
        private int intLeadAttchmntSlNumber = 0;
        //Method of storing Detail id of lead attachment
        public int LeadAttchmntDtlId
        {
            get
            {
                return intLeadAttchmntDtlId;
            }
            set
            {
                intLeadAttchmntDtlId = value;
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
        //Method of storing actual file name of attachment 
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
        //Method of storing Slnumber of Lead attachment
        public int LeadAttchmntSlNumber
        {
            get
            {
                return intLeadAttchmntSlNumber;
            }
            set
            {
                intLeadAttchmntSlNumber = value;
            }
        }
    }
}
