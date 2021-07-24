using System;  
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;
using System.Web;
namespace DL_Compzit
{
    public class clsDataLayerApprovalHierarchyTemp
    {

        public DataTable ReadDesgDDL(string strLikeName,clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_DESIGNATION";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = strLikeName;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadEmployeeDDL(string strLikeName,clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_EMPLOYEE";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_DESG_ID", OracleDbType.Int32).Value = objEntityAcco.DesgId;
            cmdReadAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = strLikeName;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable CheckDupName(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_CHECK_DUP_NAME";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.TempId;
            cmdReadAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objEntityAcco.Name;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable CheckDupName1(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_CHECK_DUP_NAME";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.TempId;
            cmdReadAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable CheckEmpDup(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_CHECK_DUP_EMP";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.TempId;
            cmdReadAccommodation.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objEntityAcco.ParentId;
            cmdReadAccommodation.Parameters.Add("A_EMP_ID", OracleDbType.Int32).Value = objEntityAcco.EmployeeId;
            if (objEntityAcco.CancelReason != "")
            {
                cmdReadAccommodation.Parameters.Add("A_DELE_IDS", OracleDbType.Varchar2).Value = objEntityAcco.CancelReason;
            }
            else
            {
                cmdReadAccommodation.Parameters.Add("A_DELE_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadList(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_LIST";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_STS", OracleDbType.Int32).Value = objEntityAcco.Status_id;
            cmdReadAccommodation.Parameters.Add("A_CNCL_STS", OracleDbType.Int32).Value = objEntityAcco.CancelStatus;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadTemplatedtls(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_TEMP_DTLS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadSubtableDtls(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_SUBTABLE_DTL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.TempId;
            cmdReadAccommodation.Parameters.Add("A_MODE", OracleDbType.Int32).Value = objEntityAcco.Mode;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void CancelTemplate(clsEntityApprovalHierarchyTemp objEntity)
        {
            string strQueryCnclCost = " APPROVAL_HIERARCHY_TEMP.SP_CANCEL_TEMPLATE";
            using (OracleCommand cmdCnclCostCenter = new OracleCommand())
            {
                cmdCnclCostCenter.CommandText = strQueryCnclCost;
                cmdCnclCostCenter.CommandType = CommandType.StoredProcedure;
                cmdCnclCostCenter.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntity.TempId;
                cmdCnclCostCenter.Parameters.Add("A_CNCL_USRID", OracleDbType.Int32).Value = objEntity.User_Id;
                cmdCnclCostCenter.Parameters.Add("A_CNSL_RSN", OracleDbType.Varchar2).Value = objEntity.CancelReason;
                cmdCnclCostCenter.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                cmdCnclCostCenter.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdCnclCostCenter);
            }
        }

        public void insertHierarchyData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "APPROVAL_HIERARCHY_TEMP.SP_INS_HIERARCHY_DATA";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROV_HIERARCHY_TEMPLATE);
                        objEntCommon.CorporateID = objentityPassport.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objentityPassport.TempId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                        cmdAddService.Parameters.Add("H_NAME", OracleDbType.Varchar2).Value = objentityPassport.Name;
                        cmdAddService.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objentityPassport.Status_id;
                        cmdAddService.Parameters.Add("H_MAJ_APRV_STS", OracleDbType.Int32).Value = objentityPassport.MajorityAprvSts;
                        if (objentityPassport.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("H_START_DATE", OracleDbType.Date).Value = objentityPassport.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("H_START_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPassport.EndDate != DateTime.MinValue)
                        {
                        cmdAddService.Parameters.Add("H_END_DATE", OracleDbType.Date).Value = objentityPassport.EndDate;
                        }
                        else
                        {
                         cmdAddService.Parameters.Add("H_END_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("ORGID", OracleDbType.Int32).Value = objentityPassport.Organisation_id;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objentityPassport.Corporate_id;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("H_SINGLE_APPRV_STS", OracleDbType.Int32).Value = objentityPassport.SingleApprvlSts;
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {
                        string strQueryInsertDetails = "APPROVAL_HIERARCHY_TEMP.SP_INS_HIERARCHY_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                            cmdAddInsertDetail.Parameters.Add("H_PARENT_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("H_LEVEL", OracleDbType.Int32).Value = 0;
                            cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_MANDSTS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("H_SUBST_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_MODE", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_PENDSTS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("H_TTC_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("H_SMS_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("H_SYS_STS", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("H_MAIL_STS", OracleDbType.Int32).Value = objDetail.MailSts;
                            cmdAddInsertDetail.Parameters.Add("H_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetail.SkipLvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_SINGLE_APPRV_STS", OracleDbType.Int32).Value = objentityPassport.SingleApprvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["H_OUT"].Value.ToString();
                            if (objDetail.TempId == 0)
                            {
                                objDetail.TempId = Convert.ToInt32(strReturn);
                            }
                        }

                        foreach (clsEntityApprovalHierarchyTemp objSubDetail in objEntitySubstituteList)
                        {
                            if (objSubDetail.Count == objDetail.Count)
                            {
                                string strQueryInsertSubDetails = "APPROVAL_HIERARCHY_TEMP.SP_INSERT_SUBSTITUTE_EMP";
                                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                {
                                    cmdAddInsertDetail.Transaction = tran;
                                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                                    cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objSubDetail.DesgId;
                                    cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                                    cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                                    cmdAddInsertDetail.ExecuteNonQuery();
                                }
                            }
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
        public void updateHierarchyData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "APPROVAL_HIERARCHY_TEMP.SP_UPD_HIERARCHY_DATA";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                        cmdAddService.Parameters.Add("H_NAME", OracleDbType.Varchar2).Value = objentityPassport.Name;
                        cmdAddService.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objentityPassport.Status_id;
                        cmdAddService.Parameters.Add("H_MAJ_APRV_STS", OracleDbType.Int32).Value = objentityPassport.MajorityAprvSts;
                        if (objentityPassport.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("H_START_DATE", OracleDbType.Date).Value = objentityPassport.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("H_START_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPassport.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("H_END_DATE", OracleDbType.Date).Value = objentityPassport.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("H_END_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("ORGID", OracleDbType.Int32).Value = objentityPassport.Organisation_id;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objentityPassport.Corporate_id;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("H_SINGLE_APPRV_STS", OracleDbType.Int32).Value = objentityPassport.SingleApprvlSts;
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListIns)
                    {
                        string strQueryInsertDetails = "APPROVAL_HIERARCHY_TEMP.SP_INS_HIERARCHY_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                            cmdAddInsertDetail.Parameters.Add("H_PARENT_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("H_LEVEL", OracleDbType.Int32).Value = 0;
                            cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_MANDSTS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("H_SUBST_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_MODE", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_PENDSTS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("H_TTC_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("H_SMS_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("H_SYS_STS", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("H_MAIL_STS", OracleDbType.Int32).Value = objDetail.MailSts;
                            cmdAddInsertDetail.Parameters.Add("H_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetail.SkipLvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_SINGLE_APPRV_STS", OracleDbType.Int32).Value = objentityPassport.SingleApprvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["H_OUT"].Value.ToString();
                            if (objDetail.TempId == 0)
                            {
                                objDetail.TempId = Convert.ToInt32(strReturn);
                            }
                        }

                        string strQueryDelete = "APPROVAL_HIERARCHY_TEMP.DELETE_SUBSTITUTE_EMPS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryDelete, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                        foreach (clsEntityApprovalHierarchyTemp objSubDetail in objEntitySubstituteList)
                        {
                            if (objSubDetail.Count == objDetail.Count)
                            {
                                string strQueryInsertSubDetails = "APPROVAL_HIERARCHY_TEMP.SP_INSERT_SUBSTITUTE_EMP";
                                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                {
                                    cmdAddInsertDetail.Transaction = tran;
                                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                                    cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objSubDetail.DesgId;
                                    cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                                    cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                                    cmdAddInsertDetail.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "APPROVAL_HIERARCHY_TEMP.SP_DELE_HIERARCHY_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public void updateHierarchyDataSub(List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListIns)
                    {
                        string strQueryInsertDetails = "APPROVAL_HIERARCHY_TEMP.SP_INS_HIERARCHY_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objDetail.Status_id;
                            cmdAddInsertDetail.Parameters.Add("H_PARENT_ID", OracleDbType.Int32).Value = objDetail.ParentId;
                            cmdAddInsertDetail.Parameters.Add("H_LEVEL", OracleDbType.Int32).Value = objDetail.Level;
                            cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_MANDSTS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("H_SUBST_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_MODE", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("H_THRESH_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("H_APPRV_PENDSTS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("H_TTC_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("H_SMS_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("H_SYS_STS", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("H_MAIL_STS", OracleDbType.Int32).Value = objDetail.MailSts;
                            cmdAddInsertDetail.Parameters.Add("H_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetail.SkipLvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_SINGLE_APPRV_STS", OracleDbType.Int32).Value = objDetail.SingleApprvlSts;
                            cmdAddInsertDetail.Parameters.Add("H_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["H_OUT"].Value.ToString();
                            if (objDetail.TempId == 0)
                            {
                                objDetail.TempId = Convert.ToInt32(strReturn);
                            }
                        }

                        string strQueryDelete = "APPROVAL_HIERARCHY_TEMP.DELETE_SUBSTITUTE_EMPS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryDelete, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                        foreach (clsEntityApprovalHierarchyTemp objSubDetail in objEntitySubstituteList)
                        {
                            if (objSubDetail.Count == objDetail.Count)
                            {
                                string strQueryInsertSubDetails = "APPROVAL_HIERARCHY_TEMP.SP_INSERT_SUBSTITUTE_EMP";
                                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                {
                                    cmdAddInsertDetail.Transaction = tran;
                                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                                    cmdAddInsertDetail.Parameters.Add("H_DESG_ID", OracleDbType.Int32).Value = objSubDetail.DesgId;
                                    cmdAddInsertDetail.Parameters.Add("H_EMP_ID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                                    cmdAddInsertDetail.Parameters.Add("H_ID", OracleDbType.Int32).Value = objDetail.Status_id;
                                    cmdAddInsertDetail.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "APPROVAL_HIERARCHY_TEMP.SP_DELE_HIERARCHY_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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

        //  DOCUMENT WORKFLOW //
        public DataTable ReadSubtableDOCDtls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOC_DTLS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.TempId;
            cmdReadAccommodation.Parameters.Add("A_MODE", OracleDbType.Int32).Value = objentityPass.Mode;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadDocumentdtls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCUMENT_DTLS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void insertDocwrkData(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                
                       
                        cmdAddService.Parameters.Add("WRKFLW_ID", OracleDbType.Int32).Value = 1;
                        cmdAddService.Parameters.Add("WRFLW_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
                        cmdAddService.Parameters.Add("DOCID", OracleDbType.Varchar2).Value = objentityPass.Doc;
                        cmdAddService.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPass.Status_id;
                        cmdAddService.Parameters.Add("WOK_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("WRK_APP_TRANS", OracleDbType.Int32).Value = objentityPass.apptrans;
                        cmdAddService.Parameters.Add("WRK_APP_MDF", OracleDbType.Int32).Value = objentityPass.appmdf;
                        cmdAddService.Parameters.Add("WRK_PRIORITY", OracleDbType.Int32).Value = objentityPass.prity;
                        cmdAddService.Parameters.Add("WRK_DEPID", OracleDbType.Varchar2).Value = objentityPass.Dep;
                        cmdAddService.Parameters.Add("WRK_DIVID", OracleDbType.Varchar2).Value = objentityPass.div;
                        cmdAddService.Parameters.Add("WRK_HRCHYID", OracleDbType.Int32).Value = objentityPass.hrid;
                        cmdAddService.Parameters.Add("WRK_APP_PNDNG_MSG_STS", OracleDbType.Int32).Value = objentityPass.appnd;
                        cmdAddService.Parameters.Add("WRK_SMS", OracleDbType.Int32).Value = objentityPass.sms;
                        cmdAddService.Parameters.Add("WRK_DASH", OracleDbType.Int32).Value = objentityPass.dash;
                        cmdAddService.Parameters.Add("WRK_TTC", OracleDbType.Int32).Value = objentityPass.ttc;
                        if (objentityPass.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = objentityPass.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPass.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = objentityPass.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("WRK_CNFRM_STS", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WORPRT_ID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                        cmdAddService.Parameters.Add("WRK_INSUSR_ID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("WRK_INS_DATE ", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("WRK_UPD_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_UPD_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRKFLW_CNFM_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_CNFM_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_REOPEN_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_REOPEN_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_CNCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_CNCL_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("WRK_CNCL_REASN ", OracleDbType.Varchar2).Value = objentityPass.CancelReason;
                        cmdAddService.Parameters.Add("WRK_HIERARCHY_STS ", OracleDbType.Int32).Value = DBNull.Value;
                         cmdAddService.ExecuteNonQuery();
                    }

                   // foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    //{
                     //   string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOC_WRKFLW_DTLS";
                       
                      //  using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                      //  {
                       //     cmdAddInsertDetail.Transaction = tran;
                        //    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        //    cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = 09;
                        //    cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = 1;
                         //   cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                        //    cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = 0;
                         //   cmdAddInsertDetail.Parameters.Add("ADSGN_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                          //  cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                          //  cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                          //  cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                          //  cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                          //  cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                          //  cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                           // cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                          //  cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                           // cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;

                          //  cmdAddInsertDetail.Parameters.Add("A_CANCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                          //  cmdAddInsertDetail.ExecuteNonQuery();
                        //}
                  //  }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltn)
                    {

                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOC_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = 09;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = 1;
                            if (objDetail.ParentId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = objDetail.ParentId;
                            }
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = objDetail.Level;
                            cmdAddInsertDetail.Parameters.Add("ADSGN_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CANCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();
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

        public void insertdoccnfm(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele, clsEntityApprovalHierarchyTemp objentityPasspo)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SUP_UPD_DOCUMENT_CONFIRM";
            string strQueryLeaveTyp1 = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_FLT";
             
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {

                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;

                        cmdAddService.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objentityPassport.Name;
                        cmdAddService.Parameters.Add("DOCID", OracleDbType.Varchar2).Value = objentityPassport.Doc;
                        cmdAddService.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPassport.Status_id;
                        cmdAddService.Parameters.Add("WOK_DESC", OracleDbType.Varchar2).Value = objentityPassport.descr;
                        cmdAddService.Parameters.Add("WRK_APP_TRANS", OracleDbType.Int32).Value = objentityPassport.apptrans;
                        cmdAddService.Parameters.Add("WRK_APP_MDF", OracleDbType.Int32).Value = objentityPassport.appmdf;
                        cmdAddService.Parameters.Add("WRK_PRIORITY", OracleDbType.Int32).Value = objentityPassport.prity;
                        cmdAddService.Parameters.Add("WRK_DEPID", OracleDbType.Varchar2).Value = objentityPassport.Dep;
                        cmdAddService.Parameters.Add("WRK_DIVID", OracleDbType.Varchar2).Value = objentityPassport.div;
                        cmdAddService.Parameters.Add("WRK_HRCHYID", OracleDbType.Int32).Value = objentityPassport.hrid;
                        cmdAddService.Parameters.Add("WRK_APP_PNDNG_MSG_STS", OracleDbType.Int32).Value = objentityPassport.appnd;
                        cmdAddService.Parameters.Add("WRK_SMS", OracleDbType.Int32).Value = objentityPassport.sms;
                        cmdAddService.Parameters.Add("WRK_DASH", OracleDbType.Int32).Value = objentityPassport.dash;
                        cmdAddService.Parameters.Add("WRK_TTC", OracleDbType.Int32).Value = objentityPassport.ttc;
                        if (objentityPassport.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = objentityPassport.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPassport.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = objentityPassport.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("WRK_CNFRM_STS", OracleDbType.Int32).Value = 1;
                        cmdAddService.Parameters.Add("WORPRT_ID", OracleDbType.Int32).Value = objentityPassport.Corporate_id;
                        cmdAddService.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objentityPassport.Organisation_id;

                        cmdAddService.Parameters.Add("WRKFLW_CNFM_USR_ID ", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("WRK_CNFM_DATE ", OracleDbType.Date).Value = objentityPassport.cDate;


                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListIns)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = 0;
                            cmdAddInsertDetail.Parameters.Add("ADESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CANCL_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELE_DOCUMENT_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = objDetail.Status_id;
                            cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = objDetail.ParentId;
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = objDetail.Level;
                            cmdAddInsertDetail.Parameters.Add("ADSGN_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CNCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();

                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDele)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELE_DOCUMENT_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                   
                     using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp1, con))
                    {

                        cmdAddService.Transaction = tran;
                       
                        cmdAddService.CommandText = strQueryLeaveTyp1;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                            //cmdAddService.Parameters.Add("AWRK_ID", OracleDbType.Int32).Value = 1;
                            cmdAddService.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPasspo.TempId; ;
                        
                            cmdAddService.ExecuteNonQuery();
                        
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
      

         public void updateDocumentData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SP_UPD_DOCUMNT_DATA";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                        cmdAddService.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objentityPassport.Name;
                        cmdAddService.Parameters.Add("DOCID", OracleDbType.Varchar2).Value = objentityPassport.Doc;
                        cmdAddService.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPassport.Status_id;
                        cmdAddService.Parameters.Add("WOK_DESC", OracleDbType.Varchar2).Value = objentityPassport.descr;
                        cmdAddService.Parameters.Add("WRK_APP_TRANS", OracleDbType.Int32).Value = objentityPassport.apptrans;
                        cmdAddService.Parameters.Add("WRK_APP_MDF", OracleDbType.Int32).Value = objentityPassport.appmdf;
                        cmdAddService.Parameters.Add("WRK_PRIORITY", OracleDbType.Int32).Value = objentityPassport.prity;
                        cmdAddService.Parameters.Add("WRK_DEPID", OracleDbType.Varchar2).Value = objentityPassport.Dep;
                        cmdAddService.Parameters.Add("WRK_DIVID", OracleDbType.Varchar2).Value = objentityPassport.div;
                        cmdAddService.Parameters.Add("WRK_HRCHYID", OracleDbType.Int32).Value = objentityPassport.hrid;
                        cmdAddService.Parameters.Add("WRK_APP_PNDNG_MSG_STS", OracleDbType.Int32).Value = objentityPassport.appnd;
                        cmdAddService.Parameters.Add("WRK_SMS", OracleDbType.Int32).Value = objentityPassport.sms;
                        cmdAddService.Parameters.Add("WRK_DASH", OracleDbType.Int32).Value = objentityPassport.dash;
                        cmdAddService.Parameters.Add("WRK_TTC", OracleDbType.Int32).Value = objentityPassport.ttc;
                        if (objentityPassport.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = objentityPassport.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPassport.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = objentityPassport.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("WRK_CNFRM_STS", OracleDbType.Int32).Value = 1;
                        cmdAddService.Parameters.Add("WORPRT_ID", OracleDbType.Int32).Value = objentityPassport.Corporate_id;
                        cmdAddService.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objentityPassport.Organisation_id;

                        cmdAddService.Parameters.Add("WRKFLW_CNFM_USR_ID ", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("WRK_CNFM_DATE ", OracleDbType.Date).Value = objentityPassport.cDate;
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListIns)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPassport.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = 0;
                            cmdAddInsertDetail.Parameters.Add("ADESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value =  objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CANCL_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELE_DOCUMENT_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
      





        public void updateDocwrkDataconform(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SUP_UPD_DOCUMENT_CONFIRMSTS";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                      

                        cmdAddService.Parameters.Add("WRK_ID", OracleDbType.Int32).Value = objentityPass.TempId;


                        cmdAddService.Parameters.Add("CONFIRM_ID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("CONFIRM_DATE", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("CONFIRM_STS", OracleDbType.Int32).Value = 1;
                       
                        cmdAddService.ExecuteNonQuery();
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


        public void updateDocwrkDataReopen(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SUP_UPD_DOCUMENT_REOPENSTS";
            string strQueryLeaveTyp1 = "DOCUMENT_WORKFLOW.SUP_DELE_DOCUMENT_FLT";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                  
                        cmdAddService.Parameters.Add("WRK_ID", OracleDbType.Int32).Value = objentityPass.TempId;


                        cmdAddService.Parameters.Add("USER_ID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("USER_DATE", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("CONFIRM_STS", OracleDbType.Int32).Value = 2;

                        cmdAddService.ExecuteNonQuery();
                    }
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp1, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;

                        cmdAddService.Parameters.Add("WRK_ID", OracleDbType.Int32).Value = objentityPass.TempId;

                        cmdAddService.ExecuteNonQuery();
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


        public void cancelDocwrkData(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "APPROVAL_HIERARCHY_TEMP.SP_CANCEL_DOCUMENT";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("AWK_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("AT_CANCEL_USERID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("AT_CANCEL_DATE", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("AT_CANCEL_REASON ", OracleDbType.Varchar2).Value = objentityPass.CancelReason;
                        
                        cmdAddService.ExecuteNonQuery();
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
        //public void Msgbox(String s)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + s + "');", true);
        //}
        public void insertDocwrkcnfm(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SUP_UPD_DOCUMENT_CONFIRM";
                    
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROV_HIERARCHY_TEMPLATE);
                        objEntCommon.CorporateID = objentityPass.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objentityPass.TempId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;

                        //cmdAddService.Parameters.Add("WRKFLW_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
                        cmdAddService.Parameters.Add("DOCID", OracleDbType.Varchar2).Value = objentityPass.Doc;
                        cmdAddService.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPass.Status_id;
                        cmdAddService.Parameters.Add("WOK_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("WRK_APP_TRANS", OracleDbType.Int32).Value = objentityPass.apptrans;
                        cmdAddService.Parameters.Add("WRK_APP_MDF", OracleDbType.Int32).Value = objentityPass.appmdf;
                        cmdAddService.Parameters.Add("WRK_PRIORITY", OracleDbType.Int32).Value = objentityPass.prity;
                        cmdAddService.Parameters.Add("WRK_DEPID", OracleDbType.Varchar2).Value = objentityPass.Dep;
                        cmdAddService.Parameters.Add("WRK_DIVID", OracleDbType.Varchar2).Value = objentityPass.div;
                        cmdAddService.Parameters.Add("WRK_HRCHYID", OracleDbType.Int32).Value = objentityPass.hrid;
                        cmdAddService.Parameters.Add("WRK_APP_PNDNG_MSG_STS", OracleDbType.Int32).Value = objentityPass.appnd;
                        cmdAddService.Parameters.Add("WRK_SMS", OracleDbType.Int32).Value = objentityPass.sms;
                        cmdAddService.Parameters.Add("WRK_DASH", OracleDbType.Int32).Value = objentityPass.dash;
                        cmdAddService.Parameters.Add("WRK_TTC", OracleDbType.Int32).Value = objentityPass.ttc;
                        if (objentityPass.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = objentityPass.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPass.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = objentityPass.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("WRK_CNFRM_STS", OracleDbType.Int32).Value = 1;
                        cmdAddService.Parameters.Add("WORPRT_ID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                      
                        cmdAddService.Parameters.Add("WRKFLW_CNFM_USR_ID ", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("WRK_CNFM_DATE ", OracleDbType.Date).Value = objentityPass.cDate;
                       
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListIns)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = 0;
                            cmdAddInsertDetail.Parameters.Add("ADESG_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CANCL_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                   
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELE_DOCUMENT_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public void updateDocwrkcnfm(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "APPROVAL_HIERARCHY_TEMP.SUP_UPD_DOCUMENT";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROV_HIERARCHY_TEMPLATE);
                        objEntCommon.CorporateID = objentityPass.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objentityPass.TempId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
 
                        cmdAddService.Parameters.Add("DOCID", OracleDbType.Varchar2).Value = objentityPass.Doc;
                        cmdAddService.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPass.Status_id;
                        cmdAddService.Parameters.Add("WOK_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("WRK_APP_TRANS", OracleDbType.Int32).Value = objentityPass.apptrans;
                        cmdAddService.Parameters.Add("WRK_APP_MDF", OracleDbType.Int32).Value = objentityPass.appmdf;
                        cmdAddService.Parameters.Add("WRK_PRIORITY", OracleDbType.Int32).Value = objentityPass.prity;
                        cmdAddService.Parameters.Add("WRK_DEPID", OracleDbType.Varchar2).Value = objentityPass.Dep;
                        cmdAddService.Parameters.Add("WRK_DIVID", OracleDbType.Varchar2).Value = objentityPass.div;
                        cmdAddService.Parameters.Add("WRK_HRCHYID", OracleDbType.Int32).Value = objentityPass.hrid;
                        cmdAddService.Parameters.Add("WRK_APP_PNDNG_MSG_STS", OracleDbType.Int32).Value = objentityPass.appnd;
                        cmdAddService.Parameters.Add("WRK_SMS", OracleDbType.Int32).Value = objentityPass.sms;
                        cmdAddService.Parameters.Add("WRK_DASH", OracleDbType.Int32).Value = objentityPass.dash;
                        cmdAddService.Parameters.Add("WRK_TTC", OracleDbType.Int32).Value = objentityPass.ttc;
                        if (objentityPass.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = objentityPass.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_STDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objentityPass.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = objentityPass.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("WRK_EDATE", OracleDbType.Date).Value = DBNull.Value;
                        }


                        cmdAddService.Parameters.Add("WRK_UPD_USR_ID ", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("WRK_UPD_DATE ", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("AWK_NAME", OracleDbType.Varchar2).Value = objentityPass.Name1;
                        cmdAddService.ExecuteNonQuery();
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
        public DataTable Readwrkflwname(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            string strQueryRead = "APPROVAL_HIERARCHY_TEMP.SP_CHECK_DUP_WRKFLW";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryRead;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("WRK_NAME", OracleDbType.Varchar2).Value = objentityPass1.Name;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
          
        }
        
       
        public void updatehrchyemp(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "APPROVAL_HIERARCHY_TEMP.SP_UPD_APP_HRCHY_EMP";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objentityPass.EmployeeId;
                        cmdAddService.Parameters.Add("AHRCHY_ID", OracleDbType.Varchar2).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        
                        cmdAddService.ExecuteNonQuery();
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
       

       
        


        public void insertDocumentDataDtlsSUB(List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {


                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INS_DOCUMENT_WRKFLW_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("A_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("A_ID", OracleDbType.Int32).Value = objDetail.Status_id;
                            cmdAddInsertDetail.Parameters.Add("A_PARENT_DTL_ID", OracleDbType.Int32).Value = objDetail.ParentId;
                            cmdAddInsertDetail.Parameters.Add("A_LEVEL", OracleDbType.Int32).Value = objDetail.Level;
                            cmdAddInsertDetail.Parameters.Add("ADSGN_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("AUSR_ID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetail.MajorityAprvSts;
                            cmdAddInsertDetail.Parameters.Add("A_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetail.SubstituteEmpSts;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetail.ThresholdPeriodMode;
                            cmdAddInsertDetail.Parameters.Add("A_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetail.ThresholdPeriodDays;
                            cmdAddInsertDetail.Parameters.Add("A_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetail.AprvPendingSts;
                            cmdAddInsertDetail.Parameters.Add("A_SMS_MSG_STS", OracleDbType.Int32).Value = objDetail.SmsSts;
                            cmdAddInsertDetail.Parameters.Add("A_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetail.SystemSts;
                            cmdAddInsertDetail.Parameters.Add("A_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetail.TtExceededSts;
                            cmdAddInsertDetail.Parameters.Add("A_CNCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();

                        }
                    }
                  
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDele)
                    {
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELE_DOCUMENT_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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

        public DataTable ReadSubstutEmptls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_READ_SUBSTITUTE_EMPS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("H_DTL_ID", OracleDbType.Int32).Value = objentityPass.TempId;
            cmdReadAccommodation.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }


    }
}
