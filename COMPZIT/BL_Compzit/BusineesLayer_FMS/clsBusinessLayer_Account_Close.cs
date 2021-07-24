using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
   public class clsBusinessLayer_Account_Close
    {
       clsDataLayer_Account_Close objDataLayerTaxCollectedAtSource = new clsDataLayer_Account_Close();
       public void InsertAccountClosing(clsEntityLayer_Account_Close objEntityTCS)
        {
            objDataLayerTaxCollectedAtSource.InsertAccountClosing(objEntityTCS);

        }
       public DataTable ReadCloseDates(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.ReadCloseDates(objEntityTCS);
           return dtReadTcsList;
       }
       public DataTable ReadOutStandingBal(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.ReadOutStandingBal(objEntityTCS);
           return dtReadTcsList;
       }
       public DataTable ReadAccntGrpList(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.ReadAccntGrpList(objEntityTCS);
           return dtReadTcsList;
       }

       public DataTable CheckAccountClosingDate(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckAccountClosingDate(objEntityTCS);
           return dtReadTcsList;
       }
       public DataTable CheckAccountClsDateCnclSts(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckAccountClsDateCnclSts(objEntityTCS);
           return dtReadTcsList;
       }

       public void CancelAccntClsDate(clsEntityLayer_Account_Close objEntityTCS)
        {
            objDataLayerTaxCollectedAtSource.CancelAccntClsDate(objEntityTCS);

        }
       public void ConfirmAccntClsDate(clsEntityLayer_Account_Close objEntityTCS)
       {
           objDataLayerTaxCollectedAtSource.ConfirmAccntClsDate(objEntityTCS);

       }
       public DataTable CheckAccountClsDateConfirmStatus(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckAccountClsDateConfirmStatus(objEntityTCS);
           return dtReadTcsList;
       }
       public DataTable CheckNonConfirmStatus(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckNonConfirmStatus(objEntityTCS);
           return dtReadTcsList;
       }
       public DataTable CheckYearEndClose(clsEntityLayer_Account_Close objEntityTCS)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckYearEndClose(objEntityTCS);
           return dtReadTcsList;
       }
       public void RecallAccountClose(clsEntityLayer_Account_Close objEntityTCS)
       {
           objDataLayerTaxCollectedAtSource.RecallAccountClose(objEntityTCS);
       }

       public DataTable CheckYearEndClosingDate(clsEntityLayer_Account_Close objEntity)
       {
           DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.CheckYearEndClosingDate(objEntity);
           return dtReadTcsList;
       }

    }
}
