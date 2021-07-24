using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using CL_Compzit;
namespace DL_Compzit.DataLayer_GMS
{
    public class classDatalayerNotifi_Temp
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetCH Notification template type
        public DataTable ReadTemplateType(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadJobCatgry = "NOTIFCTN_TEMPLATE.SP_READ_TEMP_TYPE";
            OracleCommand cmdReadJobCatgry = new OracleCommand();
            cmdReadJobCatgry.CommandText = strQueryReadJobCatgry;
            cmdReadJobCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadJobCatgry.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJobCatgry);
            return dtCategory;
        }

        // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadDivision(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadDivision = "NOTIFCTN_TEMPLATE.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
            cmdReadDivision.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
            cmdReadDivision.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtCategory;
        }
        // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadDesignations(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadDesignation = "NOTIFCTN_TEMPLATE.SP_READ_DESIGNATION";
            OracleCommand cmdReadDesignation = new OracleCommand();
            cmdReadDesignation.CommandText = strQueryReadDesignation;
            cmdReadDesignation.CommandType = CommandType.StoredProcedure;
            cmdReadDesignation.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
            cmdReadDesignation.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDesignation);
            return dtCategory;
        }
        // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadEmployee(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadEmployee = "NOTIFCTN_TEMPLATE.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmployee;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
            cmdReadEmp.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
            cmdReadEmp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }


        // This Method adds job category details to the table
        public int AddNotifyTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {
                     string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_INS_TEMPLATE";
                     using (OracleCommand cmdAddTemp = new OracleCommand(strQueryAddTemp, con))
                     {

                         cmdAddTemp.CommandType = CommandType.StoredProcedure;

                         //generate next value
                         clsDataLayer objDataLayer = new clsDataLayer();
                         clsEntityCommon objCommon = new clsEntityCommon();
                         objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.NOTIFICATION_TEMPLATE);
                         objCommon.CorporateID = objEntityNotTemp.CorpOffice_Id;
                         string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                         objEntityNotTemp.NotTempId = Convert.ToInt32(strNextValue);
                         cmdAddTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                         cmdAddTemp.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityNotTemp.TemplateName;
                         cmdAddTemp.Parameters.Add("T_TYPE_ID", OracleDbType.Int32).Value = objEntityNotTemp.TempTypeId;
                         cmdAddTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityNotTemp.Status;
                         cmdAddTemp.Parameters.Add("T_DFLT", OracleDbType.Int32).Value = objEntityNotTemp.DefaultOrNot;
                         cmdAddTemp.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
                         cmdAddTemp.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
                         cmdAddTemp.Parameters.Add("T_INSUSERID", OracleDbType.Int32).Value = objEntityNotTemp.User_Id;
                         clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                     }
                     tran.Commit();

                     return objEntityNotTemp.NotTempId;
                 }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
        }

        // This Method adds job category details to the table
        public void AddTemplateDetail(classEntityLayerNotifi_Temp ObjNotifyTemp, NotificationTemplateDetail objEntityNotTempDetail, List<NotificationTemplateAlert> objEntityTempAlertList)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 
                 {
                     string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_INS_TEMPLATE_DETAIL";
                     using (OracleCommand cmdAddTemp = new OracleCommand(strQueryAddTemp, con))
                     {
                         cmdAddTemp.CommandType = CommandType.StoredProcedure;

                         clsDataLayer objDataLayer = new clsDataLayer();
                         clsEntityCommon objCommon = new clsEntityCommon();
                         objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.NOTIFICATION_TEMPLATE_DETAIL);
                         objCommon.CorporateID = ObjNotifyTemp.CorpOffice_Id;
                         string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                         objEntityNotTempDetail.TempDetailId = Convert.ToInt32(strNextValue);

                         cmdAddTemp.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                         cmdAddTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = ObjNotifyTemp.NotTempId;
                         cmdAddTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = ObjNotifyTemp.Status;
                         cmdAddTemp.Parameters.Add("T_PERIOD", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetPeriod;
                         cmdAddTemp.Parameters.Add("T_DUR_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                         cmdAddTemp.Parameters.Add("T_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                         cmdAddTemp.Parameters.Add("T_MAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                        
                         clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                     }

                     foreach (NotificationTemplateAlert objEntityTempAlert in objEntityTempAlertList)
                     {
                         string strQueryAddTempAlert = "NOTIFCTN_TEMPLATE.SP_INS_TEMPLATE_ALERT";
                         using (OracleCommand cmdAddTempAlert = new OracleCommand(strQueryAddTempAlert, con))
                         {
                             cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                             cmdAddTempAlert.Parameters.Add("T_ID", OracleDbType.Int32).Value = ObjNotifyTemp.NotTempId;
                             cmdAddTempAlert.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                             cmdAddTempAlert.Parameters.Add("T_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                             if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                             {
                                 cmdAddTempAlert.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                             }
                             else
                             {
                                 cmdAddTempAlert.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = null;
                             }
                             if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                             {
                                 cmdAddTempAlert.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                             }
                             else
                             {
                                 cmdAddTempAlert.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = null;
                             }
                             cmdAddTempAlert.Parameters.Add("T_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                             cmdAddTempAlert.Parameters.Add("T_IS_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                             cmdAddTempAlert.Parameters.Add("T_IS_MAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                             cmdAddTempAlert.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = ObjNotifyTemp.CorpOffice_Id;
                             clsDataLayer.ExecuteNonQuery(cmdAddTempAlert);
                         }
                     }
                 
                  tran.Commit();
                 }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
        }


        // This Method Update template table
        public void UpdateNotifyTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {

                    string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_UPD_TEMPLATE";
                    using (OracleCommand cmdUpdTemp = new OracleCommand())
                    {
                         cmdUpdTemp.CommandText = strQueryAddTemp;
                        cmdUpdTemp.CommandType = CommandType.StoredProcedure;
                        cmdUpdTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                        cmdUpdTemp.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityNotTemp.TemplateName;
                        cmdUpdTemp.Parameters.Add("T_TYPE_ID", OracleDbType.Int32).Value = objEntityNotTemp.TempTypeId;
                        cmdUpdTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityNotTemp.Status;
                        cmdUpdTemp.Parameters.Add("T_DFLT", OracleDbType.Int32).Value = objEntityNotTemp.DefaultOrNot;
                        cmdUpdTemp.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
                        cmdUpdTemp.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
                        cmdUpdTemp.Parameters.Add("T_UPDUSERID", OracleDbType.Int32).Value = objEntityNotTemp.User_Id;
                        cmdUpdTemp.Parameters.Add("T_UPDDATE", OracleDbType.Date).Value = objEntityNotTemp.D_Date;
                        clsDataLayer.ExecuteNonQuery(cmdUpdTemp);
                    }

            
        }
        // This Method Update template detail table
        public void UpdateNotifyTemplateDetail(NotificationTemplateDetail objEntityNotTempDetail)
        {

            string strQueryUpdTemp = "NOTIFCTN_TEMPLATE.SP_UPD_TEMPLATE_DETAIL";
            using (OracleCommand cmdUpdTemp = new OracleCommand())
            {
                cmdUpdTemp.CommandText = strQueryUpdTemp;
                cmdUpdTemp.CommandType = CommandType.StoredProcedure;
                cmdUpdTemp.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                cmdUpdTemp.Parameters.Add("T_PERIOD", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetPeriod;
                cmdUpdTemp.Parameters.Add("T_DUR_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                cmdUpdTemp.Parameters.Add("T_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                cmdUpdTemp.Parameters.Add("T_MAILIS", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;

                clsDataLayer.ExecuteNonQuery(cmdUpdTemp);
            }

        }
        
        // This Method Update template alert table
        public void UpdateNotifyTemplateAlert(NotificationTemplateAlert objEntityTempAlert, NotificationTemplateDetail objEntityNotTempDetail)
        {

                    string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_UPD_TEMPLATE_ALERT";
                    using (OracleCommand cmdUpdTempAl = new OracleCommand())
                    {
                        cmdUpdTempAl.CommandText = strQueryAddTemp;
                        cmdUpdTempAl.CommandType = CommandType.StoredProcedure;

                        cmdUpdTempAl.Parameters.Add("T_AL_ID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertId;
                        cmdUpdTempAl.Parameters.Add("T_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                        if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                        {
                            cmdUpdTempAl.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                        }
                        else
                        {
                            cmdUpdTempAl.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = null;
                        }
                        if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                        {
                            cmdUpdTempAl.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                        }
                        else
                        {
                            cmdUpdTempAl.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = null;
                        }
                        cmdUpdTempAl.Parameters.Add("T_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                        cmdUpdTempAl.Parameters.Add("T_IS_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                        cmdUpdTempAl.Parameters.Add("T_IS_MAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;

                        clsDataLayer.ExecuteNonQuery(cmdUpdTempAl);

                    }
        }

        // This Method DELETE ALERT details OF the table
        public void DeleteTemplateAlert(List<NotificationTemplateAlert> objEntityTempAlertList)
        {
            foreach (NotificationTemplateAlert objEntityNotTemp in objEntityTempAlertList)
            {
                string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_DEL_TEMPLATE_ALERT";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_AL_ID", OracleDbType.Int32).Value = objEntityNotTemp.TemplateAlertId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
            }
        }

        // This Method DELETE Template details OF the table
        public void DeleteTemplateDetail(classEntityLayerNotifi_Temp objEntityNotTemp)
        {

                string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_DEL_TEMPLATE_DETAIL";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
         
        }
        // This Method DELETE Template  OF the table
        public void DeleteTemplate(classEntityLayerNotifi_Temp objEntityNotTemp)
        {

                string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_DEL_TEMPLATE";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
         
        }
        // This Method DELETE Template  OF the table
        public void DeleteAllTemplateAlert(classEntityLayerNotifi_Temp objEntityNotTemp)
        {

            string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_DEL_ALL_TEMPLATE_ALRT";
            using (OracleCommand cmdAddTemp = new OracleCommand())
            {
                cmdAddTemp.CommandText = strQueryAddTemp;
                cmdAddTemp.CommandType = CommandType.StoredProcedure;
                cmdAddTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                clsDataLayer.ExecuteNonQuery(cmdAddTemp);
            }

        }
        // This Method checks TEMPLATE name in the database for duplication.
        public string CheckTemplateName(classEntityLayerNotifi_Temp objEntityNotTemp)
        {

            string strQueryCheckCatName = "NOTIFCTN_TEMPLATE.SP_CHECK_TEMPLATE_NAME";
            OracleCommand cmdCheckJobName = new OracleCommand();
            cmdCheckJobName.CommandText = strQueryCheckCatName;
            cmdCheckJobName.CommandType = CommandType.StoredProcedure;
            cmdCheckJobName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdCheckJobName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityNotTemp.TemplateName;
            cmdCheckJobName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
            cmdCheckJobName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
            cmdCheckJobName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckJobName);
            string strReturn = cmdCheckJobName.Parameters["T_COUNT"].Value.ToString();
            cmdCheckJobName.Dispose();
            return strReturn;
        }
        // This Method adds job category details to the table
        public void AddTemplateAlert(List<NotificationTemplateAlert> objEntityTempAlertList,classEntityLayerNotifi_Temp objEntityNotTemp, NotificationTemplateDetail objEntityNotTempDetail)
        {
            foreach (NotificationTemplateAlert objEntityTempAlert in objEntityTempAlertList)
            {
                string strQueryAddTemp = "NOTIFCTN_TEMPLATE.SP_INS_TEMPLATE_ALERT";
                using (OracleCommand cmdAddTempAlert = new OracleCommand())
                {
                    cmdAddTempAlert.CommandText = strQueryAddTemp;
                    cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                    cmdAddTempAlert.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                    cmdAddTempAlert.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                    cmdAddTempAlert.Parameters.Add("T_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                    if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                    {
                        cmdAddTempAlert.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                    }
                    else
                    {
                        cmdAddTempAlert.Parameters.Add("T_NOT_ID", OracleDbType.Int32).Value = null;
                    }
                    if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                    {
                        cmdAddTempAlert.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                    }
                    else
                    {
                        cmdAddTempAlert.Parameters.Add("T_NOT_MAIL", OracleDbType.Varchar2).Value = null;
                    }
                    cmdAddTempAlert.Parameters.Add("T_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                    cmdAddTempAlert.Parameters.Add("T_IS_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                    cmdAddTempAlert.Parameters.Add("T_IS_MAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                    cmdAddTempAlert.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdAddTempAlert);
                }
            }
        }

        public DataTable ReadNotfcnTempList(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadJobCatgry = "NOTIFCTN_TEMPLATE.SP_READ_NOTFCNTEM_LIST";
            OracleCommand cmdReadJobCatgry = new OracleCommand();
            cmdReadJobCatgry.CommandText = strQueryReadJobCatgry;
            cmdReadJobCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadJobCatgry.Parameters.Add("T_TEMTYP", OracleDbType.Int32).Value = objEntityNotTemp.NotTypeId;
            cmdReadJobCatgry.Parameters.Add("T_STS", OracleDbType.Int32).Value = objEntityNotTemp.Status;
            cmdReadJobCatgry.Parameters.Add("T_CANSTS", OracleDbType.Int32).Value = objEntityNotTemp.Cancel_Status;
            cmdReadJobCatgry.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityNotTemp.Organisation_Id;
            cmdReadJobCatgry.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityNotTemp.CorpOffice_Id;
            cmdReadJobCatgry.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJobCatgry);
            return dtCategory;
        }

        //Method for cancel template
        public void CancelNotificationTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryCancelTemp = "NOTIFCTN_TEMPLATE.SP_CANCEL_TEMPLATE";
            using (OracleCommand cmdCancelTemp = new OracleCommand())
            {
                cmdCancelTemp.CommandText = strQueryCancelTemp;
                cmdCancelTemp.CommandType = CommandType.StoredProcedure;
                cmdCancelTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
                cmdCancelTemp.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityNotTemp.User_Id;
                cmdCancelTemp.Parameters.Add("T_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelTemp.Parameters.Add("T_REASON", OracleDbType.Varchar2).Value = objEntityNotTemp.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelTemp);
            }
        }
        //Method for Recall Cancelled template
        public void ReCallNotificationTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryRecallTemp = "NOTIFCTN_TEMPLATE.SP_RECALL_TEMPLATE";
            OracleCommand cmdRecallTemp = new OracleCommand();
            cmdRecallTemp.CommandText = strQueryRecallTemp;
            cmdRecallTemp.CommandType = CommandType.StoredProcedure;
            cmdRecallTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdRecallTemp.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityNotTemp.User_Id;
            cmdRecallTemp.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityNotTemp.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallTemp);
        }
        //Method for change staus of template
        public void ChangeStatusTemp(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryRecallTemp = "NOTIFCTN_TEMPLATE.SP_CHANGE_STS_TEMPLATE";
            OracleCommand cmdRecallTemp = new OracleCommand();
            cmdRecallTemp.CommandText = strQueryRecallTemp;
            cmdRecallTemp.CommandType = CommandType.StoredProcedure;
            cmdRecallTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdRecallTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityNotTemp.Status;
            clsDataLayer.ExecuteNonQuery(cmdRecallTemp);
        }
        //Method for change default status of  template
        public void ChangeDefaultSts(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryRecallTemp = "NOTIFCTN_TEMPLATE.SP_CHANGE_DFLT_STS";
            OracleCommand cmdRecallTemp = new OracleCommand();
            cmdRecallTemp.CommandText = strQueryRecallTemp;
            cmdRecallTemp.CommandType = CommandType.StoredProcedure;
            cmdRecallTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdRecallTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityNotTemp.DefaultOrNot;
            //EVM-0027
            cmdRecallTemp.Parameters.Add("T_TYPEID", OracleDbType.Int32).Value = objEntityNotTemp.NotTypeId;
            //END
            clsDataLayer.ExecuteNonQuery(cmdRecallTemp);
        }

        // This Method will fetCH template table datas BY ID
        public DataTable ReadTemplateById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadNotTemp = "NOTIFCTN_TEMPLATE.SP_READ_TEMPLATE_BY_ID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdReadNotTemp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }
        // This Method will fetCH template DEATILS table BY ID
        public DataTable ReadTemplateDetailById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadNotTemp = "NOTIFCTN_TEMPLATE.SP_READ_TEMPLATE_DETAIL_BY_ID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityNotTemp.NotTempId;
            cmdReadNotTemp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }

        //this table will fetch template alert table datas
        public DataTable ReadTemplateAlertById(classEntityLayerNotifi_Temp objEntityNotTemp)
        {
            string strQueryReadNotTemp = "NOTIFCTN_TEMPLATE.SP_READ_TEMPLATE_ALERT_BY_ID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTemp.TempDetailId;
            cmdReadNotTemp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }
    }
}
