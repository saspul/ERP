using System;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:06/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusineesLayerException
    {
        //Creating objects for businesslayer.
        clsDataLayerException objDataLayerException = new clsDataLayerException();
        EL_Compzit.clsEntityException objEntityException = new EL_Compzit.clsEntityException();
        public void ExceptionHandling(Exception Exc)
        {
            if (Exc != null)
            {
                //Fetch the Exception from Global.asax and sort the essential details from it.
                Exc = Exc.GetBaseException();
                objEntityException.Excmsg = Exc.Message;
                StackTrace trace = new StackTrace(Exc, true);
                objEntityException.ExcModule = trace.GetFrame(0).GetFileName();
                objEntityException.ExcMethode = trace.GetFrame(0).GetMethod().ToString();
                if (trace.ToString().Length > 2000)
                {
                    objEntityException.ErrorDescription = trace.ToString().Substring(1, 2000);
                }
                else
                {
                    objEntityException.ErrorDescription = trace.ToString().Substring(1, trace.ToString().Length - 1);
                }

                objDataLayerException.AddException(objEntityException);
            }
        }
    }
}
