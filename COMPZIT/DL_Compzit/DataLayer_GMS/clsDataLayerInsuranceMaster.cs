using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using DL_Compzit;

namespace DL_Compzit.DataLayer_GMS
{
    public class clsDataLayerInsuranceMaster
    {
        public DataTable ReadInsuranceProviders(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_INSURANCE_PROVIDER";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadInsuranceTypes(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_INSURANCE_TYP_MSTR";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadCurrency(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_CURRENCY";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadEmployee(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_EMPLOYEE";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadProjects(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_PROJECTS";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        //-------for notification template------------

        public DataTable ReadNotifyTemplates(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_NOT_TEMPLATES";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadDefaultNotifyTemplates(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_DFLT_NOT_TEMPLATES";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public void AddInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_INSERT_INSURANCE";
            using (OracleCommand cmdInsurance = new OracleCommand())
            {
                cmdInsurance.CommandText = strQueryText;
                cmdInsurance.CommandType = CommandType.StoredProcedure;
                cmdInsurance.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
                cmdInsurance.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.RefNumber;
                cmdInsurance.Parameters.Add("B_INSURANCENO", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.InsuranceNo;
                cmdInsurance.Parameters.Add("B_INSRNCPRVDR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceProvider;

                if (objEntityBnkGuarnte.ProjectId != 0)
                {
                    cmdInsurance.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ProjectId;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = DBNull.Value;
                }
                cmdInsurance.Parameters.Add("B_INSRNC_TYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTyp;
                cmdInsurance.Parameters.Add("B_AMOUNT", OracleDbType.Decimal).Value = objEntityBnkGuarnte.Amount;
                cmdInsurance.Parameters.Add("B_CURRNCY", OracleDbType.Int32).Value = objEntityBnkGuarnte.Currency;
                cmdInsurance.Parameters.Add("B_OPNG_DATE", OracleDbType.Date).Value = objEntityBnkGuarnte.OpenDate;
                if (objEntityBnkGuarnte.ExpireDate != DateTime.MinValue)
                {
                    cmdInsurance.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpireDate;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = null;
                }

                if (objEntityBnkGuarnte.NoOfDays != 0)
                {
                    cmdInsurance.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = objEntityBnkGuarnte.NoOfDays;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = null;
                }

                cmdInsurance.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Description;

                if (objEntityBnkGuarnte.EmployeName != "")
                {
                    cmdInsurance.Parameters.Add("B_EMPNAME", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.EmployeName;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMPNAME", OracleDbType.Varchar2).Value = null;
                }

                if (objEntityBnkGuarnte.Email != "")
                {
                    cmdInsurance.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Email;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = null;
                }

                if (objEntityBnkGuarnte.ContactPersnUsrId != 0)
                {
                    cmdInsurance.Parameters.Add("B_EMPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ContactPersnUsrId;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMPID", OracleDbType.Int32).Value = null;
                }
                cmdInsurance.Parameters.Add("B_DNT_NTFY", OracleDbType.Int32).Value = objEntityBnkGuarnte.DontNotify;
                cmdInsurance.Parameters.Add("B_NTF_TEMP", OracleDbType.Int32).Value = objEntityBnkGuarnte.NotTempId;
                cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
                cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
                cmdInsurance.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                cmdInsurance.Parameters.Add("B_PRJCTNAME", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.ProjectName;
                cmdInsurance.Parameters.Add("B_INSRNC_TYPMSTR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTypMstr;
                clsDataLayer.ExecuteNonQuery(cmdInsurance);
            }
        }

        public void Add_Pictures(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlList)
        {
            foreach (clsEntityLayerInsuranceAttachments objEntityGurnteeattch in objEntityLayerInsuranceAtchmntDtlList)
            {
                string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_INSERT_ATTACHMENT";
                using (OracleCommand cmdReadBankGuarnt = new OracleCommand())
                {
                    cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
                    cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
                    cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityGurnteeattch.InsuranceId;
                    cmdReadBankGuarnt.Parameters.Add("B_FILE_NAME", OracleDbType.Varchar2).Value = objEntityGurnteeattch.FileName;
                    cmdReadBankGuarnt.Parameters.Add("B_ACTUAL_FILE_NAME", OracleDbType.Varchar2).Value = objEntityGurnteeattch.ActualFileName;
                    cmdReadBankGuarnt.Parameters.Add("B_SERIAL_NO", OracleDbType.Int32).Value = objEntityGurnteeattch.AttchmntSlNumber;
                    cmdReadBankGuarnt.Parameters.Add("B_CAPTN", OracleDbType.Varchar2).Value = objEntityGurnteeattch.CaptionName;
                    cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
                }
            }
        }

        public void AddTemplateDetail(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, InsuranceTemplateDetail objEntityNotTempDetail, List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddTemp = "INSURANCE_MASTER.SP_INSERT_TEMPLATE";
                    using (OracleCommand cmdAddTemp = new OracleCommand(strQueryAddTemp, con))
                    {
                        cmdAddTemp.CommandType = CommandType.StoredProcedure;

                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                        objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_TEMPLATE);
                        objCommon.CorporateID = objEntityBnkGuarnte.CorpOffice_Id;
                        string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                        objEntityNotTempDetail.TempDetailId = Convert.ToInt32(strNextValue);

                        cmdAddTemp.Parameters.Add("B_TMPDTL_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                        cmdAddTemp.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
                        cmdAddTemp.Parameters.Add("B_TMPDTL_PERIOD", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetPeriod;
                        cmdAddTemp.Parameters.Add("B_TMPDTL_CNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                        cmdAddTemp.Parameters.Add("B_TMPDTL_DASHBRD", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                        cmdAddTemp.Parameters.Add("B_TMPDTL_EMAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;

                        clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                    }

                    foreach (InsuranceTemplateAlert objEntityTempAlert in objEntityTempAlertList)
                    {
                        string strQueryAddTempAlert = "INSURANCE_MASTER.SP_INS_TEMPLATE_ALERT";
                        using (OracleCommand cmdAddTempAlert = new OracleCommand(strQueryAddTempAlert, con))
                        {
                            cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                            cmdAddTempAlert.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
                            cmdAddTempAlert.Parameters.Add("B_TMPDTL_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                            cmdAddTempAlert.Parameters.Add("B_TMPALRT_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                            if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                            {
                                cmdAddTempAlert.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                            }
                            else
                            {
                                cmdAddTempAlert.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = null;
                            }
                            if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                            {
                                cmdAddTempAlert.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                            }
                            else
                            {
                                cmdAddTempAlert.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = null;
                            }
                            cmdAddTempAlert.Parameters.Add("B_TMPALRT_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                            cmdAddTempAlert.Parameters.Add("B_TMPALRT_DASHBRD", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                            cmdAddTempAlert.Parameters.Add("B_TMPALRT_EMAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                            cmdAddTempAlert.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
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

        public DataTable ReadInsuranceList(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_INSURANCE_LIST";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdInsurance.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityBnkGuarnte.Cancel_Status;
            cmdInsurance.Parameters.Add("B_INSRNC_PRVDR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceProvider;
            if (objEntityBnkGuarnte.ExpiryFromDate != DateTime.MinValue)
            {
                cmdInsurance.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpiryFromDate;
            }
            else
            {
                cmdInsurance.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityBnkGuarnte.ToDate != DateTime.MinValue)
            {
                cmdInsurance.Parameters.Add("B_TODATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ToDate;
            }
            else
            {
                cmdInsurance.Parameters.Add("B_TODATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityBnkGuarnte.ExpireDate != DateTime.MinValue)
            {
                cmdInsurance.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpireDate;
            }
            else
            {
                cmdInsurance.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdInsurance.Parameters.Add("B_SRCHSTATS", OracleDbType.Int32).Value = objEntityBnkGuarnte.StatusSrch;
            cmdInsurance.Parameters.Add("B_INSRNCTYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTyp;
            cmdInsurance.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = objEntityBnkGuarnte.FromDashboard;
            cmdInsurance.Parameters.Add("B_INSRNC_TYPMSTR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTypMstr;

            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable Read_AllAttachment()
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_READ_ATTACHMNT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadInsuranceById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_INSURANCE_BYID";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdInsurance.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadAttachmntsById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_ATTCHMNTS_BYID";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadTemplateById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_READ_TEMPLATE_BYID";
            OracleCommand cmdInsurance = new OracleCommand();
            cmdInsurance.CommandText = strQueryText;
            cmdInsurance.CommandType = CommandType.StoredProcedure;
            cmdInsurance.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdInsurance.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtInsurance = new DataTable();
            dtInsurance = clsDataLayer.ExecuteReader(cmdInsurance);
            return dtInsurance;
        }

        public DataTable ReadTemplateAlertById(InsuranceTemplateDetail objEntityNotTempDetail)
        {
            string strQueryReadNotTemp = "INSURANCE_MASTER.SP_READ_TEMPLATE_ALERTS_BYID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("B_TEMPDTLID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
            cmdReadNotTemp.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }
        
        public void Delete_Pictures(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, List<clsEntityLayerInsuranceAttachments> objEntityGurntattchAtchmntDtlListDel)
        {
            foreach (clsEntityLayerInsuranceAttachments objEntityGurntAttchmnt in objEntityGurntattchAtchmntDtlListDel)
            {
                string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_DEL_ATTACHMENT_BYID";
                using (OracleCommand cmdReadBankGuarnt = new OracleCommand())
                {
                    cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
                    cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
                    cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityGurntAttchmnt.PictureId;
                    clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
                }
            }
        }

        public void DeleteTemplateAlert(List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            foreach (InsuranceTemplateAlert objEntityNotTemp in objEntityTempAlertList)
            {
                string strQueryAddTemp = "INSURANCE_MASTER.SP_DEL_TEMPLATE_ALERT_BYID";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("B_TMPLTALRTID", OracleDbType.Int32).Value = objEntityNotTemp.TemplateAlertId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
            }
        }

        public void DeleteTemplateDetailById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryAddTemp = "INSURANCE_MASTER.SP_DEL_TEMPLATE_DETAIL_INSRNC";
            using (OracleCommand cmdAddTemp = new OracleCommand())
            {
                cmdAddTemp.CommandText = strQueryAddTemp;
                cmdAddTemp.CommandType = CommandType.StoredProcedure;
                cmdAddTemp.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                clsDataLayer.ExecuteNonQuery(cmdAddTemp);
            }
        }

        public void DeleteTemplateAlertById(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryAddTemp = "INSURANCE_MASTER.SP_DEL_TEMPLATE_ALERTS_INSRNC";
            using (OracleCommand cmdAddTemp = new OracleCommand())
            {
                cmdAddTemp.CommandText = strQueryAddTemp;
                cmdAddTemp.CommandType = CommandType.StoredProcedure;
                cmdAddTemp.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                clsDataLayer.ExecuteNonQuery(cmdAddTemp);
            }
        }

        public void UpdateInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryText = "INSURANCE_MASTER.SP_UPDATE_INSURANCE";
            using (OracleCommand cmdInsurance = new OracleCommand())
            {
                cmdInsurance.CommandText = strQueryText;
                cmdInsurance.CommandType = CommandType.StoredProcedure;
                cmdInsurance.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdInsurance.Parameters.Add("B_INSURANCENO", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.InsuranceNo;
                cmdInsurance.Parameters.Add("B_INSRNCPRVDR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceProvider;
                if (objEntityBnkGuarnte.ProjectId != 0)
                {
                    cmdInsurance.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ProjectId;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = DBNull.Value;
                }
                cmdInsurance.Parameters.Add("B_INSRNC_TYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTyp;
                cmdInsurance.Parameters.Add("B_AMOUNT", OracleDbType.Decimal).Value = objEntityBnkGuarnte.Amount;
                cmdInsurance.Parameters.Add("B_CURRNCY", OracleDbType.Int32).Value = objEntityBnkGuarnte.Currency;
                cmdInsurance.Parameters.Add("B_OPNG_DATE", OracleDbType.Date).Value = objEntityBnkGuarnte.OpenDate;
                if (objEntityBnkGuarnte.ExpireDate != DateTime.MinValue)
                {
                    cmdInsurance.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpireDate;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = null;
                }

                if (objEntityBnkGuarnte.NoOfDays != 0)
                {
                    cmdInsurance.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = objEntityBnkGuarnte.NoOfDays;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = null;
                }

                cmdInsurance.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Description;

                if (objEntityBnkGuarnte.EmployeName != "")
                {
                    cmdInsurance.Parameters.Add("B_EMPNAME", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.EmployeName;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMPNAME", OracleDbType.Varchar2).Value = null;
                }

                if (objEntityBnkGuarnte.Email != "")
                {
                    cmdInsurance.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Email;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = null;
                }

                if (objEntityBnkGuarnte.ContactPersnUsrId != 0)
                {
                    cmdInsurance.Parameters.Add("B_EMPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ContactPersnUsrId;
                }
                else
                {
                    cmdInsurance.Parameters.Add("B_EMPID", OracleDbType.Int32).Value = null;
                }
                cmdInsurance.Parameters.Add("B_DNT_NTFY", OracleDbType.Int32).Value = objEntityBnkGuarnte.DontNotify;
                cmdInsurance.Parameters.Add("B_NTF_TEMP", OracleDbType.Int32).Value = objEntityBnkGuarnte.NotTempId;
                cmdInsurance.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                cmdInsurance.Parameters.Add("B_PRJCTNAME", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.ProjectName;
                cmdInsurance.Parameters.Add("B_INSRNC_TYPMSTR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTypMstr;

                clsDataLayer.ExecuteNonQuery(cmdInsurance);
            }
        }

        public void UpdateTemplateDetail(InsuranceTemplateDetail objEntityNotTempDetail)
        {
            string strQueryUpdTemp = "INSURANCE_MASTER.SP_UPDATE_TEMPLATE";
            using (OracleCommand cmdUpdTemp = new OracleCommand())
            {
                cmdUpdTemp.CommandText = strQueryUpdTemp;
                cmdUpdTemp.CommandType = CommandType.StoredProcedure;
                cmdUpdTemp.Parameters.Add("B_TMPDTL_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                cmdUpdTemp.Parameters.Add("B_TMPDTL_PERIOD", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetPeriod;
                cmdUpdTemp.Parameters.Add("B_TMPDTL_CNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                cmdUpdTemp.Parameters.Add("B_TMPDTL_DASHBRD", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                cmdUpdTemp.Parameters.Add("B_TMPDTL_EMAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                clsDataLayer.ExecuteNonQuery(cmdUpdTemp);
            }
        }

        public void AddTemplateAlert(clsEntityLayerInsuranceMaster objEntityBnkGuarnte, InsuranceTemplateDetail objEntityNotTempDetail, List<InsuranceTemplateAlert> objEntityTempAlertList)
        {
            foreach (InsuranceTemplateAlert objEntityTempAlert in objEntityTempAlertList)
            {
                string strQueryAddTemp = "INSURANCE_MASTER.SP_INS_TEMPLATE_ALERT";
                using (OracleCommand cmdAddTempAlert = new OracleCommand())
                {
                    cmdAddTempAlert.CommandText = strQueryAddTemp;
                    cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                    cmdAddTempAlert.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
                    cmdAddTempAlert.Parameters.Add("B_TMPDTL_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                    cmdAddTempAlert.Parameters.Add("B_TMPALRT_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                    if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                    {
                        cmdAddTempAlert.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                    }
                    else
                    {
                        cmdAddTempAlert.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = null;
                    }
                    if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                    {
                        cmdAddTempAlert.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                    }
                    else
                    {
                        cmdAddTempAlert.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = null;
                    }
                    cmdAddTempAlert.Parameters.Add("B_TMPALRT_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                    cmdAddTempAlert.Parameters.Add("B_TMPALRT_DASHBRD", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                    cmdAddTempAlert.Parameters.Add("B_TMPALRT_EMAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                    cmdAddTempAlert.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdAddTempAlert);
                }
            }
        }

        public void UpdateTemplateAlert(InsuranceTemplateDetail objEntityNotTempDetail, InsuranceTemplateAlert objEntityTempAlert)
        {
            string strQueryAddTemp = "INSURANCE_MASTER.SP_UPDATE_TEMPLATE_ALERT";
            using (OracleCommand cmdUpdTempAl = new OracleCommand())
            {
                cmdUpdTempAl.CommandText = strQueryAddTemp;
                cmdUpdTempAl.CommandType = CommandType.StoredProcedure;
                cmdUpdTempAl.Parameters.Add("B_TMPDTL_ID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertId;
                cmdUpdTempAl.Parameters.Add("B_TMPALRT_OPTION", OracleDbType.Int32).Value = objEntityTempAlert.TemplateAlertOptId;
                if (objEntityTempAlert.TemplateWhoNotifyId != 0)
                {
                    cmdUpdTempAl.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = objEntityTempAlert.TemplateWhoNotifyId;
                }
                else
                {
                    cmdUpdTempAl.Parameters.Add("B_TMPALRT_NOTIFYID", OracleDbType.Int32).Value = null;
                }
                if (objEntityTempAlert.TemplateNotifyWhoMail != "")
                {
                    cmdUpdTempAl.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = objEntityTempAlert.TemplateNotifyWhoMail;
                }
                else
                {
                    cmdUpdTempAl.Parameters.Add("B_TMPALRT_NTFYEMAILID", OracleDbType.Varchar2).Value = null;
                }
                cmdUpdTempAl.Parameters.Add("B_TMPALRT_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                cmdUpdTempAl.Parameters.Add("B_TMPALRT_DASHBRD", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                cmdUpdTempAl.Parameters.Add("B_TMPALRT_EMAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;
                clsDataLayer.ExecuteNonQuery(cmdUpdTempAl);
            }
        }

        public string CheckDupInsrncNo(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_READ_DUP_INSURNCNO";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdReadBankGuarnt.Parameters.Add("B_INSURANCENO", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.InsuranceNo;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }

        public DataTable ReadInsuranceStatus(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_READ_STATUS_BYID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public void ConfirmInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_CONFIRM_INSURANCE";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdAddRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public void CancelInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_CANCEL_INSURANCE";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                cmdCancelRequest.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }
        public void ReCallInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_RECALL_INSURANCE";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }

        public void ReOpenInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_REOPEN_INSURANCE";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdAddRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public void MailStatusChangeBack(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_MAILSTATUS_CHNGREOPN";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
        }


        public void CloseInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_CLOSE_INSURANCE";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                cmdCancelRequest.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }


        public void RenewInsurance(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_RENEW_INSURANCE";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
                cmdAddRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        //READ ALTERTS BY GTEE ID
        public DataTable ReadAlertsByInsuID(clsEntityLayerInsuranceMaster objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "INSURANCE_MASTER.SP_READ_TMPLT_ALRT_BY_INSU_ID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
    }
}
