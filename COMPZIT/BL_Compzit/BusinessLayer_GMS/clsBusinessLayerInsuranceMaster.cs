using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class clsBusinessLayerInsuranceMaster
    {

        clsDataLayerInsuranceMaster objDataInsuranceMaster = new clsDataLayerInsuranceMaster();

        public DataTable ReadInsuranceProviders(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadInsuranceProviders(objEntityBnkGuarnte);
            return dtInsurance;
        }

        public DataTable ReadInsuranceTypes(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadInsuranceTypes(objEntityBnkGuarnte);
            return dtInsurance;
        }

        public DataTable ReadCurrency(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadCurrency(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadEmployee(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadEmployee(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadProjects(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadProjects(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadNotifyTemplates(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadNotifyTemplates(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadDefaultNotifyTemplates(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadDefaultNotifyTemplates(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public void AddInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.AddInsurance(objEntityBnkGuarnte);
        }
        public void Add_Pictures(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlList)
        {
            objDataInsuranceMaster.Add_Pictures(objEntityBnkGuarnte, objEntityLayerInsuranceAtchmntDtlList);
        }
        public void AddTemplateDetail(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, InsuranceTemplateDetail objEntityNotTempDetail, List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            objDataInsuranceMaster.AddTemplateDetail(objEntityBnkGuarnte, objEntityNotTempDetail, objEntityTempAlertList);
        }
        public DataTable ReadInsuranceList(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadInsuranceList(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable Read_AllAttachment()
        {
            DataTable dtInsurance = objDataInsuranceMaster.Read_AllAttachment();
            return dtInsurance;
        }
        public DataTable ReadInsuranceById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadInsuranceById(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadAttachmntsById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadAttachmntsById(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadTemplateById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadTemplateById(objEntityBnkGuarnte);
            return dtInsurance;
        }
        public DataTable ReadTemplateAlertById(InsuranceTemplateDetail objEntityNotTempDetail)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadTemplateAlertById(objEntityNotTempDetail);
            return dtInsurance;
        }
        public void Delete_Pictures(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, List<clsEntityLayerInsuranceAttachments> objEntityGurntattchAtchmntDtlListDel)
        {
            objDataInsuranceMaster.Delete_Pictures(objEntityBnkGuarnte, objEntityGurntattchAtchmntDtlListDel);
        }
        public void DeleteTemplateAlert(List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            objDataInsuranceMaster.DeleteTemplateAlert(objEntityTempAlertList);
        }
        public void DeleteTemplateDetailById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.DeleteTemplateDetailById(objEntityBnkGuarnte);
        }
        public void DeleteTemplateAlertById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.DeleteTemplateAlertById(objEntityBnkGuarnte);
        }

        public void UpdateInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.UpdateInsurance(objEntityBnkGuarnte);
        }
        public void UpdateTemplateDetail(InsuranceTemplateDetail objEntityNotTempDetail)
        {
            objDataInsuranceMaster.UpdateTemplateDetail(objEntityNotTempDetail);
        }
        public void AddTemplateAlert(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, InsuranceTemplateDetail objEntityNotTempDetail, List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            objDataInsuranceMaster.AddTemplateAlert(objEntityBnkGuarnte, objEntityNotTempDetail, objEntityTempAlertList);
        }
        public void UpdateTemplateAlert(InsuranceTemplateDetail objEntityNotTempDetail, InsuranceTemplateAlert objEntityTempAlert)
        {
            objDataInsuranceMaster.UpdateTemplateAlert(objEntityNotTempDetail, objEntityTempAlert);
        }

        public string CheckDupInsrncNo(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strInsurance = objDataInsuranceMaster.CheckDupInsrncNo(objEntityBnkGuarnte);
            return strInsurance;
        }
        public DataTable ReadInsuranceStatus(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtInsurance = objDataInsuranceMaster.ReadInsuranceStatus(objEntityBnkGuarnte);
            return dtInsurance;
        }

        public void ConfirmInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.ConfirmInsurance(objEntityBnkGuarnte);
        }

        public void CancelInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.CancelInsurance(objEntityBnkGuarnte);
        }
        public void ReCallInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.ReCallInsurance(objEntityBnkGuarnte);
        }
        public void ReOpenInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.ReOpenInsurance(objEntityBnkGuarnte);
        }
        public void MailStatusChangeBack(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.MailStatusChangeBack(objEntityBnkGuarnte);
        }
        public void CloseInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.CloseInsurance(objEntityBnkGuarnte);
        }
        public void RenewInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            objDataInsuranceMaster.RenewInsurance(objEntityBnkGuarnte);
        }
        public DataTable ReadAlertsByInsuID(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            DataTable dtGteeAlerts = new DataTable();
            dtGteeAlerts = objDataInsuranceMaster.ReadAlertsByInsuID(objEntityBnkGuarnte);
            return dtGteeAlerts;
        }
    }
}
