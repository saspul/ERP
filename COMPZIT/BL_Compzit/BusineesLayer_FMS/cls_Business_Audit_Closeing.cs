using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class cls_Business_Audit_Closeing
    {
        clsDataLayer_Audit_Closing objDataAuditClose = new clsDataLayer_Audit_Closing();
        public void InsertAuditClosing(clsEntityLayerAuditClosing objEntityTCS)
        {
            objDataAuditClose.InsertAuditClosing(objEntityTCS);

        }
        public DataTable ReadCloseDates(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.ReadCloseDates(objEntityTCS);
            return dtReadTcsList;
        }

        public DataTable CheckAuditClosingDate(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.CheckAuditClosingDate(objEntityTCS);
            return dtReadTcsList;
        }
        public DataTable CheckAuditClsDateCnclSts(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.CheckAuditClsDateCnclSts(objEntityTCS);
            return dtReadTcsList;
        }

        public void CancelAuditClsDate(clsEntityLayerAuditClosing objEntityTCS)
        {
            objDataAuditClose.CancelAuditClsDate(objEntityTCS);
        }
        public void ConfirmAuditClsDate(clsEntityLayerAuditClosing objEntityTCS)
        {
            objDataAuditClose.ConfirmAuditClsDate(objEntityTCS);

        }
        public DataTable CheckAuditClsDateConfirmStatus(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.CheckAuditClsDateConfirmStatus(objEntityTCS);
            return dtReadTcsList;
        }
        public DataTable CheckNonConfirmEntry(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.CheckNonConfirmEntry(objEntityTCS);
            return dtReadTcsList;
        }
        public DataTable Read_Account_Close(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.Read_Account_Close(objEntityTCS);
            return dtReadTcsList;
        }
        public DataTable Read_Audit_Close(clsEntityLayerAuditClosing objEntityTCS)
        {
            DataTable dtReadTcsList = objDataAuditClose.Read_Audit_Close(objEntityTCS);
            return dtReadTcsList;
        }

        public DataTable CheckYearEndClosingDate(clsEntityLayerAuditClosing objEntity)
        {
            DataTable dtReadTcsList = objDataAuditClose.CheckYearEndClosingDate(objEntity);
            return dtReadTcsList;
        }

    }
}
