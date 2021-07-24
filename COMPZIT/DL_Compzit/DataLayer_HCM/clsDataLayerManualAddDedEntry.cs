using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerManualAddDedEntry
    {

        public DataTable ReadManualAddDed(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_MANUAL_ADD_DED";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadManualAddDedEdit(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_MANUAL_ADD_DED_EDIT";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadEmployee(clsEntityManualAddDedEntry objEntity,string strLikeEmployee)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_EMPLOYEE";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_NAME", OracleDbType.Varchar2).Value = strLikeEmployee;
                cmdReadInterviewCatByID.Parameters.Add("M_MNTH_ID", OracleDbType.Int32).Value = objEntity.MonthId;
                cmdReadInterviewCatByID.Parameters.Add("M_YEAR_ID", OracleDbType.Int32).Value = objEntity.YearId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadSubTableId(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_SUBTAB_ID";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                cmdReadInterviewCatByID.Parameters.Add("M_ADDDED_ID", OracleDbType.Int32).Value = objEntity.AddDedId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable readMonthYearData(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_MNTHYEAR_DATA";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_MNTH_ID", OracleDbType.Int32).Value = objEntity.MonthId;
                cmdReadInterviewCatByID.Parameters.Add("M_YEAR_ID", OracleDbType.Int32).Value = objEntity.YearId;
                cmdReadInterviewCatByID.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable checkEmployeeDuplication(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_CHECK_EMP_DUP";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_MNTH_ID", OracleDbType.Int32).Value = objEntity.MonthId;
                cmdReadInterviewCatByID.Parameters.Add("M_YEAR_ID", OracleDbType.Int32).Value = objEntity.YearId;
                cmdReadInterviewCatByID.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                if(objEntity.cancelReason.Trim()!="")
                cmdReadInterviewCatByID.Parameters.Add("M_TB_IDS", OracleDbType.Varchar2).Value = objEntity.cancelReason;
                else
                cmdReadInterviewCatByID.Parameters.Add("M_TB_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable readClearDta(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_CLEAR_DATA";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_MAIN_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_SUB_ID", OracleDbType.Int32).Value = objEntity.SubTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadList(clsEntityManualAddDedEntry objEntityAcco)
        {
            string strQueryReadAccommodation = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_LIST";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_Id;
            cmdReadAccommodation.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityAcco.CorpOffice_Id;
            cmdReadAccommodation.Parameters.Add("M_STS", OracleDbType.Int32).Value = objEntityAcco.StatusId;
            cmdReadAccommodation.Parameters.Add("M_CNCL_STS", OracleDbType.Int32).Value = objEntityAcco.CancelStatus;
            cmdReadAccommodation.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objEntityAcco.MonthId;
            cmdReadAccommodation.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objEntityAcco.YearId;

            cmdReadAccommodation.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityAcco.CommonSearchTerm;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_MONTH", OracleDbType.Varchar2).Value = objEntityAcco.searcMonth;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_YEAR", OracleDbType.Varchar2).Value = objEntityAcco.SearchYear;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_NUMEMP", OracleDbType.Varchar2).Value = objEntityAcco.SearchNumEmp;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_INSDATE", OracleDbType.Varchar2).Value = objEntityAcco.SearchInsDate;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_INSTIME", OracleDbType.Varchar2).Value = objEntityAcco.SearchInsTime;
            cmdReadAccommodation.Parameters.Add("M_SEARCH_STATUS", OracleDbType.Varchar2).Value = objEntityAcco.SearchStatus;
            cmdReadAccommodation.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityAcco.OrderColumn;
            cmdReadAccommodation.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityAcco.OrderMethod;
            cmdReadAccommodation.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityAcco.PageMaxSize;
            cmdReadAccommodation.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityAcco.PageNumber;

            cmdReadAccommodation.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void ReopConfDele(clsEntityManualAddDedEntry objentityPassport)
        {
            string strQueryCnclCost = " HCM_MANUAL_ADD_DED_ENTRY.SP_CONF_REOP_DELE_LIST";
            using (OracleCommand cmdCnclCostCenter = new OracleCommand())
            {
                cmdCnclCostCenter.CommandText = strQueryCnclCost;
                cmdCnclCostCenter.CommandType = CommandType.StoredProcedure;
                cmdCnclCostCenter.Parameters.Add("M_ID", OracleDbType.Int32).Value = objentityPassport.MasterTabId;
                cmdCnclCostCenter.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objentityPassport.Organisation_Id;
                cmdCnclCostCenter.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpOffice_Id;
                cmdCnclCostCenter.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                cmdCnclCostCenter.Parameters.Add("M_MODE", OracleDbType.Int32).Value = objentityPassport.ConfStatusId;
                cmdCnclCostCenter.Parameters.Add("M_CNSL_RSN", OracleDbType.Varchar2).Value = objentityPassport.cancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCnclCostCenter);
            }
        }
        public DataTable ReadDataById(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_BY_ID";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable checkEmpcode(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_CHECK_EMP_CODE";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CODE", OracleDbType.Varchar2).Value = objEntity.cancelReason;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public void insUpdEmpDtls(clsEntityManualAddDedEntry objentityPassport, List<clsEntityManualAddDedEntry> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_MANUAL_ADD_DED_ENTRY.SP_INS_UPD_MASTER_DTLS";
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
                        cmdAddService.Parameters.Add("M_ID", OracleDbType.Int32).Value = objentityPassport.MasterTabId;
                        cmdAddService.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objentityPassport.MonthId;
                        cmdAddService.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objentityPassport.YearId;
                        cmdAddService.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objentityPassport.Organisation_Id;
                        cmdAddService.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpOffice_Id;
                        cmdAddService.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("M_MODE", OracleDbType.Int32).Value = objentityPassport.ConfStatusId;
                        cmdAddService.Parameters.Add("M_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddService.ExecuteNonQuery();
                        string strReturn = cmdAddService.Parameters["M_OUT_ID"].Value.ToString();
                        if(objentityPassport.MasterTabId==0)
                        objentityPassport.MasterTabId = Convert.ToInt32(strReturn);
                    }

                    foreach (clsEntityManualAddDedEntry objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "HCM_MANUAL_ADD_DED_ENTRY.SP_INS_UPD_SUB_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("M_DTL_ID", OracleDbType.Int32).Value = objDetail.SubTabId;
                            cmdAddInsertDetail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objentityPassport.MasterTabId;
                            cmdAddInsertDetail.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objentityPassport.MonthId;
                            cmdAddInsertDetail.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objentityPassport.YearId;
                            cmdAddInsertDetail.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                            cmdAddInsertDetail.Parameters.Add("M_MODE", OracleDbType.Int32).Value = objentityPassport.ConfStatusId;
                            cmdAddInsertDetail.Parameters.Add("M_CURRENCY_ID", OracleDbType.Int32).Value = objentityPassport.CurrencyId;
                            cmdAddInsertDetail.Parameters.Add("M_EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("M_ADDDED_ID", OracleDbType.Int32).Value = objDetail.AddDedId;
                            cmdAddInsertDetail.Parameters.Add("M_AMNT", OracleDbType.Decimal).Value = objDetail.Amount;
                            cmdAddInsertDetail.Parameters.Add("M_DESC", OracleDbType.Varchar2).Value = objDetail.Description;
                            cmdAddInsertDetail.Parameters.Add("M_DESC_STS", OracleDbType.Int32).Value = objDetail.DescChangeSts;
                            cmdAddInsertDetail.Parameters.Add("M_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturnS = cmdAddInsertDetail.Parameters["M_OUT_ID"].Value.ToString();
                            if (strReturnS != "0")
                            {
                                 if (objentityPassport.cancelReason == "")
                                 {
                                     objentityPassport.cancelReason=objDetail.AddDedId+"%"+strReturnS;
                                 }
                                 else
                                 {
                                     objentityPassport.cancelReason = objentityPassport.cancelReason + "$" + objDetail.AddDedId + "%" + strReturnS;
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
        public void insUpdEmpDtlsEdit(clsEntityManualAddDedEntry objentityPassport, List<clsEntityManualAddDedEntry> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_MANUAL_ADD_DED_ENTRY.SP_INS_UPD_MASTER_DTLS_EDIT";
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
                        cmdAddService.Parameters.Add("M_ID", OracleDbType.Int32).Value = objentityPassport.MasterTabId;
                        cmdAddService.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objentityPassport.MonthId;
                        cmdAddService.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objentityPassport.YearId;
                        cmdAddService.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objentityPassport.Organisation_Id;
                        cmdAddService.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpOffice_Id;
                        cmdAddService.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                        cmdAddService.Parameters.Add("M_MODE", OracleDbType.Int32).Value = objentityPassport.ConfStatusId;
                        cmdAddService.Parameters.Add("M_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddService.ExecuteNonQuery();
                        string strReturn = cmdAddService.Parameters["M_OUT_ID"].Value.ToString();
                        if (objentityPassport.MasterTabId == 0)
                            objentityPassport.MasterTabId = Convert.ToInt32(strReturn);
                    }

                    foreach (clsEntityManualAddDedEntry objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "HCM_MANUAL_ADD_DED_ENTRY.SP_INS_UPD_SUB_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("M_DTL_ID", OracleDbType.Int32).Value = objDetail.SubTabId;
                            cmdAddInsertDetail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objentityPassport.MasterTabId;
                            cmdAddInsertDetail.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objentityPassport.MonthId;
                            cmdAddInsertDetail.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objentityPassport.YearId;
                            cmdAddInsertDetail.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                            cmdAddInsertDetail.Parameters.Add("M_MODE", OracleDbType.Int32).Value = objentityPassport.ConfStatusId;
                            cmdAddInsertDetail.Parameters.Add("M_CURRENCY_ID", OracleDbType.Int32).Value = objentityPassport.CurrencyId;
                            cmdAddInsertDetail.Parameters.Add("M_EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("M_ADDDED_ID", OracleDbType.Int32).Value = objDetail.AddDedId;
                            cmdAddInsertDetail.Parameters.Add("M_AMNT", OracleDbType.Decimal).Value = objDetail.Amount;
                            cmdAddInsertDetail.Parameters.Add("M_DESC", OracleDbType.Varchar2).Value = objDetail.Description;
                            cmdAddInsertDetail.Parameters.Add("M_DESC_STS", OracleDbType.Int32).Value = objDetail.DescChangeSts;
                            cmdAddInsertDetail.Parameters.Add("M_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturnS = cmdAddInsertDetail.Parameters["M_OUT_ID"].Value.ToString();
                            if (strReturnS != "0")
                            {
                                if (objentityPassport.cancelReason == "")
                                {
                                    objentityPassport.cancelReason = objDetail.AddDedId + "%" + strReturnS;
                                }
                                else
                                {
                                    objentityPassport.cancelReason = objentityPassport.cancelReason + "$" + objDetail.AddDedId + "%" + strReturnS;
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
        public DataTable checkEmpLeave(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_CHECK_EMP_LEAVE";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                cmdReadInterviewCatByID.Parameters.Add("M_FROM_DATE", OracleDbType.Date).Value = objEntity.StartDate;
                cmdReadInterviewCatByID.Parameters.Add("M_TO_DATE", OracleDbType.Date).Value = objEntity.EndDate;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }


        public DataTable ReadPrintList(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_PRINT_LIST";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_STS", OracleDbType.Int32).Value = objEntity.StatusId;
                cmdReadInterviewCatByID.Parameters.Add("M_CNCL_STS", OracleDbType.Int32).Value = objEntity.CancelStatus;
                cmdReadInterviewCatByID.Parameters.Add("M_MONTH", OracleDbType.Int32).Value = objEntity.MonthId;
                cmdReadInterviewCatByID.Parameters.Add("M_YEAR", OracleDbType.Int32).Value = objEntity.YearId;

                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public void UpdateDescription(clsEntityManualAddDedEntry objentityPassport)
        {
            string strQueryCnclCost = " HCM_MANUAL_ADD_DED_ENTRY.SP_UPD_DESCRIPTION";
            using (OracleCommand cmdCnclCostCenter = new OracleCommand())
            {
                cmdCnclCostCenter.CommandText = strQueryCnclCost;
                cmdCnclCostCenter.CommandType = CommandType.StoredProcedure;
                cmdCnclCostCenter.Parameters.Add("M_IDS", OracleDbType.Varchar2).Value = objentityPassport.cancelReason;
                cmdCnclCostCenter.Parameters.Add("M_DESC", OracleDbType.Varchar2).Value = objentityPassport.Description;
                cmdCnclCostCenter.Parameters.Add("M_CHANGE_STS", OracleDbType.Int32).Value = objentityPassport.DescChangeSts;
                cmdCnclCostCenter.Parameters.Add("M_USRID", OracleDbType.Int32).Value = objentityPassport.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdCnclCostCenter);
            }
        }
        public DataTable readMonthYearDataEdit(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_MANUAL_ADD_DED_ENTRY.SP_READ_MNTHYEAR_DATA_EDIT";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("M_ORG_ID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice_Id;
                cmdReadInterviewCatByID.Parameters.Add("M_MNTH_ID", OracleDbType.Int32).Value = objEntity.MonthId;
                cmdReadInterviewCatByID.Parameters.Add("M_YEAR_ID", OracleDbType.Int32).Value = objEntity.YearId;
                cmdReadInterviewCatByID.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntity.MasterTabId;
                cmdReadInterviewCatByID.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }

    }
}
