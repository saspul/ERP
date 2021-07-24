using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerAppointmentLtrParameter
    {

        // This Method adds ApptLetterParameter details to the database
        public void AddApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            objDataConslt.AddApptLetterParameterMstr(objEntityApptLtrParam);
        }
        // This Method checks ApptLetterParameter Name in the database for duplication (FOR UPDATE AND INSERT)
        public string CheckDupApptLetterParameterName(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            string strReturn = objDataConslt.CheckDupApptLetterParameterName(objEntityApptLtrParam);
            return strReturn;

        }
        //Read ApptLetterParameter list 
        public DataTable ReadApptLetterParameterList(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            DataTable dtApptLetterParameterList = new DataTable();
            dtApptLetterParameterList = objDataConslt.ReadApptLetterParameterList(objEntityApptLtrParam);
            return dtApptLetterParameterList;
        }
        //Read ApptLetterParameter DETAIL 
        public DataTable ReadApptLetterParameterByID(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            DataTable dtApptLetterParameterDetails = new DataTable();
            dtApptLetterParameterDetails = objDataConslt.ReadApptLetterParameterByID(objEntityApptLtrParam);
            return dtApptLetterParameterDetails;
        }
        // This Method update ApptLetterParameter details 
        public void UpdateApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            objDataConslt.UpdateApptLetterParameterMstr(objEntityApptLtrParam);
        }
        // This Method delete ApptLetterParameter details 
        public void CancelApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            clsDataLayerAppointmentLtrParameter objDataConslt = new clsDataLayerAppointmentLtrParameter();
            objDataConslt.CancelApptLetterParameterMstr(objEntityApptLtrParam);
        }
    }
}
