using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Exception Tracking.
namespace EL_Compzit
{
    public class clsEntityException
    {
        private string strExcMsg;
        private string strExcmodule;
        private string strExcmethode;
        private string strErrDescription;

        //This methode for storing exception Message.
        public string Excmsg
        {
            get
            {
                return strExcMsg;
            }
            set
            {
                strExcMsg = value;
            }
        }
        //This methode used for storing exception occured module name.
        public string ExcModule
        {
            get
            {
                return strExcmodule;
            }
            set
            {
                strExcmodule = value;
            }
        }
        //This methode for storing methode name that have exception.
        public string ExcMethode
        {
            get
            {
                return strExcmethode;
            }
            set
            {
                strExcmethode = value;
            }
        }

        //This method for storing internal exception Message.
        public string ErrorDescription
        {
            get
            {
                return strErrDescription;
            }
            set
            {
                strErrDescription = value;
            }
        }


    }
}
