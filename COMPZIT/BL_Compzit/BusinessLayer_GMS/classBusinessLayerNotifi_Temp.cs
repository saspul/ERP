using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_GMS
{
   public class classBusinessLayerNotifi_Temp
    {
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadTemplateType(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtNotType = new DataTable();
            dtNotType = ObjDataNotFcn.ReadTemplateType(objEntityNotTemp);
            return dtNotType;
        }
        // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadDivision(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtDivision = new DataTable();
            dtDivision = ObjDataNotFcn.ReadDivision(objEntityNotTemp);
            return dtDivision;
        }

        // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadDesignations(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtDesign = new DataTable();
            dtDesign = ObjDataNotFcn.ReadDesignations(objEntityNotTemp);
            return dtDesign;
        }

         // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadEmployee(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtEmploy = new DataTable();
            dtEmploy = ObjDataNotFcn.ReadEmployee(objEntityNotTemp);
            return dtEmploy;
        }


        // This Method adds job category details to the table
        public int AddNotifyTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
           int intNotifyId= ObjDataNotFcn.AddNotifyTemplate(objEntityNotTemp);
           return intNotifyId;
        }

        // This Method adds job category details to the table
        public void AddTemplateDetail(classEntityLayerNotifi_Temp ObjNotifyTemp, NotificationTemplateDetail objEntityNotTempDetail, List<NotificationTemplateAlert> objEntityTempAlertList)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.AddTemplateDetail(ObjNotifyTemp,objEntityNotTempDetail, objEntityTempAlertList);
        }

        // This Method adds job category details to the table
        public void AddTemplateAlert(List<NotificationTemplateAlert> objEntityTempAlertList,classEntityLayerNotifi_Temp objEntityNotTemp, NotificationTemplateDetail objEntityNotTempDetail)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.AddTemplateAlert(objEntityTempAlertList,objEntityNotTemp,objEntityNotTempDetail);
        }
        public DataTable ReadNotfcnTempList(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtEmploy = new DataTable();
            dtEmploy = ObjDataNotFcn.ReadNotfcnTempList(objEntityNotTemp);
            return dtEmploy;
        }

         // This Method checks TEMPLATE name in the database for duplication.
        public string CheckTemplateName(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            string strCoount = ObjDataNotFcn.CheckTemplateName(objEntityNotTemp);
            return strCoount;
        }

        //Method for cancel template
        public void CancelNotificationTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.CancelNotificationTemp(objEntityNotTemp);
        }
        //Method for Recall Cancelled template
        public void ReCallNotificationTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.ReCallNotificationTemp(objEntityNotTemp);
        }
         // This Method will fetCH template table datas BY ID
        public DataTable ReadTemplateById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtNotify = new DataTable();
            dtNotify = ObjDataNotFcn.ReadTemplateById(objEntityNotTemp);
            return dtNotify;
        }
        // This Method will fetCH template DEATILS table BY ID
        public DataTable ReadTemplateDetailById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtNotify = new DataTable();
            dtNotify = ObjDataNotFcn.ReadTemplateDetailById(objEntityNotTemp);
            return dtNotify;
        }
        //this table will fetch template alert table datas
        public DataTable ReadTemplateAlertById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            DataTable dtNotify = new DataTable();
            dtNotify = ObjDataNotFcn.ReadTemplateAlertById(objEntityNotTemp);
            return dtNotify;
        }

         //Method for change staus of template
        public void ChangeStatusTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.ChangeStatusTemp(objEntityNotTemp);
        }
          //Method for change default status of  template
        public void ChangeDefaultSts(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.ChangeDefaultSts(objEntityNotTemp);
        }
         // This Method Update template table
        public void UpdateNotifyTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.UpdateNotifyTemplate(objEntityNotTemp);
        }
         // This Method Update template detail table
        public void UpdateNotifyTemplateDetail(NotificationTemplateDetail objEntityNotTempDetail)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.UpdateNotifyTemplateDetail(objEntityNotTempDetail);
        }
        // This Method Update template alert table
        public void UpdateNotifyTemplateAlert(NotificationTemplateAlert objEntityTempAlert,NotificationTemplateDetail objEntityNotTempDetail)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.UpdateNotifyTemplateAlert(objEntityTempAlert, objEntityNotTempDetail);
        }

        // This Method DELETE ALERT details OF the table
        public void DeleteTemplateAlert(List<NotificationTemplateAlert> objEntityTempAlertList)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.DeleteTemplateAlert(objEntityTempAlertList);
        }


         // This Method DELETE Template details OF the table
        public void DeleteTemplateDetail(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.DeleteTemplateDetail(objEntityNotTemp);
        }
         // This Method DELETE Template  OF the table
        public void DeleteTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.DeleteTemplate(objEntityNotTemp);
        }
        // This Method DELETE Template  OF the table
        public void DeleteAllTemplateAlert(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            classDatalayerNotifi_Temp ObjDataNotFcn = new classDatalayerNotifi_Temp();
            ObjDataNotFcn.DeleteAllTemplateAlert(objEntityNotTemp);
        }
    }
}
