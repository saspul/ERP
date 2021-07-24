using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using CL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsData_Mess_Bill
    {//metghod to read accomodation
        public DataTable ReadAccomodation(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadAcco = "MESS_BILL.SP_READ_ACCOMODATION";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadAcco.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        //to read mess bill
        public DataTable ReadMessBill_List(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadEx = "MESS_BILL.SP_READ_MESBILL_LIST";
            using (OracleCommand cmdReadEx = new OracleCommand())
            {
                cmdReadEx.CommandText = strQueryReadEx;
                cmdReadEx.CommandType = CommandType.StoredProcedure;
                cmdReadEx.Parameters.Add("E_ACCID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                if (objEntityMessBill.Fromdate != DateTime.MinValue)
                    cmdReadEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                else
                    cmdReadEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = null;
                if (objEntityMessBill.Todate != DateTime.MinValue)
                    cmdReadEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                else
                    cmdReadEx.Parameters.Add("E_TO", OracleDbType.Date).Value = null;

                cmdReadEx.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadEx.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadEx.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEntityMessBill.CancelStatus;
                cmdReadEx.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadEx);
                return dtCust;
            }
        }
        //read mess bill data by id
        public DataTable ReadMessBillData_ById(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadData = "MESS_BILL.SP_READ_MESBILL_DATA_BYID";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadData.Parameters.Add("E_BILL_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }
        //to insert mess bill deatils
        public void InsertMessBill(clsEntity_Mess_Bill objEntityMessBill, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertEx = "MESS_BILL.SP_INSERT_MESBILL";
                    using (OracleCommand cmdInsertEx = new OracleCommand())
                    {
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MESS_BILL);
                        objEntCommon.CorporateID = objEntityMessBill.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityMessBill.MessBillId = Convert.ToInt32(strNextNum);

                        cmdInsertEx.Transaction = tran;
                        cmdInsertEx.Connection = con;
                        cmdInsertEx.CommandText = strQueryInsertEx;
                        cmdInsertEx.CommandType = CommandType.StoredProcedure;
                        cmdInsertEx.Parameters.Add("E_BILL_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                        cmdInsertEx.Parameters.Add("E_ACCID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                        cmdInsertEx.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                        cmdInsertEx.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                        cmdInsertEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                        cmdInsertEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                        cmdInsertEx.Parameters.Add("E_AMOUNT", OracleDbType.Decimal).Value = objEntityMessBill.TotalAmount;
                        cmdInsertEx.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityMessBill.User_Id;
                        clsDataLayer.ExecuteNonQuery(cmdInsertEx);
                    }

                    string strQueryInsertMessBillEmpDtl = "MESS_BILL.SP_INSERT_MESBILL_EMP_DTL";
                    foreach (clsEntity_Mess_Bill_EMP_DTLS objIntEmpDtl in objEntityMessEmpDtlList)
                    {
                        string strReturn = "";
                        using (OracleCommand cmdInsertMessEmpDtl = new OracleCommand())
                        {
                            cmdInsertMessEmpDtl.Transaction = tran;
                            cmdInsertMessEmpDtl.Connection = con;
                            cmdInsertMessEmpDtl.CommandText = strQueryInsertMessBillEmpDtl;
                            cmdInsertMessEmpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertMessEmpDtl.Parameters.Add("M_MESS_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objIntEmpDtl.EmpId;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_DAYS", OracleDbType.Int32).Value = objIntEmpDtl.MessEmpDys;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_AMT", OracleDbType.Decimal).Value = objIntEmpDtl.MessEmpAmt;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_CHANGE_STS", OracleDbType.Int32).Value = objIntEmpDtl.ChangeSts;
                            cmdInsertMessEmpDtl.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                            cmdInsertMessEmpDtl.Parameters.Add("M_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdInsertMessEmpDtl.ExecuteScalar();
                            strReturn = cmdInsertMessEmpDtl.Parameters["M_ID"].Value.ToString();
                            cmdInsertMessEmpDtl.Dispose();
                        }


                           string strQueryInsertMessBillEmpDtlM = "MESS_BILL.SP_INSERT_MESBILL_EMP_DTL_MNTH";
                           foreach (clsEntity_Mess_Bill_EMP_DTLS objIntEmpDtlm in objEntityMessEmpDtlMnthWiseList)
                           {
                               if(objIntEmpDtlm.EmpId==objIntEmpDtl.EmpId){
                                  using (OracleCommand cmdInsertMessEmpDtlM = new OracleCommand())
                                  {
                                  cmdInsertMessEmpDtlM.Transaction = tran;
                                  cmdInsertMessEmpDtlM.Connection = con;
                                  cmdInsertMessEmpDtlM.CommandText = strQueryInsertMessBillEmpDtlM;
                                  cmdInsertMessEmpDtlM.CommandType = CommandType.StoredProcedure;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_MESS_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_MESSEMP_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objIntEmpDtlm.EmpId;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_DAYS", OracleDbType.Int32).Value = objIntEmpDtlm.MessEmpDys;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_AMT", OracleDbType.Decimal).Value = objIntEmpDtlm.MessEmpAmt;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_MONTH", OracleDbType.Int32).Value = objIntEmpDtlm.MessMonth;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_YEAR", OracleDbType.Int32).Value = objIntEmpDtlm.MessYear;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                                  cmdInsertMessEmpDtlM.ExecuteNonQuery();
                                 }
                               }
                            }




                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
        }
        //update mess bill details
        public void UpdateMessBill(clsEntity_Mess_Bill objEntityMessBill, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdUpdateEx = new OracleCommand())
                    {
                        string strQueryUpdateEx = "";
                        if (objEntityMessBill.ConfirmStatus == 0)
                        {
                            strQueryUpdateEx = "MESS_BILL.SP_UPDATE_MESBILL";
                        }
                        else
                        {
                            strQueryUpdateEx = "MESS_BILL.SP_CONFIRM_MESBILL";
                        }
                        cmdUpdateEx.Transaction = tran;
                        cmdUpdateEx.Connection = con;
                        cmdUpdateEx.CommandText = strQueryUpdateEx;
                        cmdUpdateEx.CommandType = CommandType.StoredProcedure;
                        cmdUpdateEx.Parameters.Add("E_BILL_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                        cmdUpdateEx.Parameters.Add("E_ACCID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                        cmdUpdateEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                        cmdUpdateEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                        cmdUpdateEx.Parameters.Add("E_AMOUNT", OracleDbType.Decimal).Value = objEntityMessBill.TotalAmount;
                        cmdUpdateEx.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityMessBill.User_Id;
                        clsDataLayer.ExecuteNonQuery(cmdUpdateEx);
                    }


                    using (OracleCommand cmdDelMessEmpDtl = new OracleCommand())
                    {
                        string strQuerydELETEMessBillEmpDtl_ById = "MESS_BILL.SP_DELETE_MESBILL_EMP_DTL_BYID";
                        cmdDelMessEmpDtl.Transaction = tran;
                        cmdDelMessEmpDtl.Connection = con;
                        cmdDelMessEmpDtl.CommandText = strQuerydELETEMessBillEmpDtl_ById;
                        cmdDelMessEmpDtl.CommandType = CommandType.StoredProcedure;
                        cmdDelMessEmpDtl.Parameters.Add("M_MESS_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                        clsDataLayer.ExecuteNonQuery(cmdDelMessEmpDtl);
                    }


                    string strQueryInsertMessBillEmpDtl = "MESS_BILL.SP_INSERT_MESBILL_EMP_DTL";
                    foreach (clsEntity_Mess_Bill_EMP_DTLS objIntEmpDtl in objEntityMessEmpDtlList)
                    {
                        string strReturn = "";
                        using (OracleCommand cmdInsertMessEmpDtl = new OracleCommand())
                        {
                            cmdInsertMessEmpDtl.Transaction = tran;
                            cmdInsertMessEmpDtl.Connection = con;
                            cmdInsertMessEmpDtl.CommandText = strQueryInsertMessBillEmpDtl;
                            cmdInsertMessEmpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertMessEmpDtl.Parameters.Add("M_MESS_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objIntEmpDtl.EmpId;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_DAYS", OracleDbType.Int32).Value = objIntEmpDtl.MessEmpDys;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_AMT", OracleDbType.Decimal).Value = objIntEmpDtl.MessEmpAmt;
                            cmdInsertMessEmpDtl.Parameters.Add("M_EMP_CHANGE_STS", OracleDbType.Int32).Value = objIntEmpDtl.ChangeSts;
                            cmdInsertMessEmpDtl.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                            cmdInsertMessEmpDtl.Parameters.Add("M_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdInsertMessEmpDtl.ExecuteScalar();
                            strReturn = cmdInsertMessEmpDtl.Parameters["M_ID"].Value.ToString();
                            cmdInsertMessEmpDtl.Dispose();

                        }

                           string strQueryInsertMessBillEmpDtlM = "MESS_BILL.SP_INSERT_MESBILL_EMP_DTL_MNTH";
                           foreach (clsEntity_Mess_Bill_EMP_DTLS objIntEmpDtlm in objEntityMessEmpDtlMnthWiseList)
                           {
                               if(objIntEmpDtlm.EmpId==objIntEmpDtl.EmpId){
                                  using (OracleCommand cmdInsertMessEmpDtlM = new OracleCommand())
                                  {
                                  cmdInsertMessEmpDtlM.Transaction = tran;
                                  cmdInsertMessEmpDtlM.Connection = con;
                                  cmdInsertMessEmpDtlM.CommandText = strQueryInsertMessBillEmpDtlM;
                                  cmdInsertMessEmpDtlM.CommandType = CommandType.StoredProcedure;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_MESS_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_MESSEMP_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_ID", OracleDbType.Int32).Value = objIntEmpDtlm.EmpId;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_DAYS", OracleDbType.Int32).Value = objIntEmpDtlm.MessEmpDys;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_AMT", OracleDbType.Decimal).Value = objIntEmpDtlm.MessEmpAmt;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_MONTH", OracleDbType.Int32).Value = objIntEmpDtlm.MessMonth;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_EMP_YEAR", OracleDbType.Int32).Value = objIntEmpDtlm.MessYear;
                                  cmdInsertMessEmpDtlM.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                                  cmdInsertMessEmpDtlM.ExecuteNonQuery();
                                 }
                               }
                            }


                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
        }
        //update mess bill details
        public void DeleteMessBill(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryUpdateEx = "MESS_BILL.SP_CANCEL_MESBILL";
            OracleCommand cmdUpdateEx = new OracleCommand();
            cmdUpdateEx.CommandText = strQueryUpdateEx;
            cmdUpdateEx.CommandType = CommandType.StoredProcedure;
            cmdUpdateEx.Parameters.Add("E_EXPT_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
            cmdUpdateEx.Parameters.Add("E_RSN", OracleDbType.Varchar2).Value = objEntityMessBill.cancelReason;
            cmdUpdateEx.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityMessBill.User_Id;
            cmdUpdateEx.Parameters.Add("E_DATE", OracleDbType.Date).Value = DateTime.Today;
            clsDataLayer.ExecuteNonQuery(cmdUpdateEx);
        }
        //read mess Employee data by ACCOMODATION Id
        public DataTable ReadEmployee_ByAccoId(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadData = "MESS_BILL.SP_READ_EMP_DATA_BY_ACCID";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadData.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                cmdReadData.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                cmdReadData.Parameters.Add("E_ACC_ID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }
        //read mess bill data by id
        public DataTable ReadMessExemDataByDate(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadData = "MESS_BILL.SP_READ_MESS_EXEM_IN_DATE";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessBill.EmpId;
                cmdReadData.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                cmdReadData.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadCorp = "MESS_BILL.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        //To check duplication in mess BILL
        public DataTable CheckDuplication(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadDup = "MESS_BILL.SP_CHECK_DUPLICATION";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("I_ACC", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
            cmdReadDup.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
            cmdReadDup.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
            cmdReadDup.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }
        public DataTable ReadMessBackup(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadDup = "MESS_BILL.SP_READ_MESS_BACKUP";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessBill.EmpId;
            cmdReadDup.Parameters.Add("E_ACC", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
            cmdReadDup.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
            cmdReadDup.Parameters.Add("E_TODATE", OracleDbType.Date).Value = objEntityMessBill.Todate;
            cmdReadDup.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }

        public DataTable ReadCurrentMess(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadDup = "MESS_BILL.SP_READ_MESS_CURRENT";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessBill.EmpId;
            cmdReadDup.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }
        public DataTable ReadMessEmpDtl(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadAcco = "MESS_BILL.SP_READ_MESSBILL_EMP_DTL";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("E_BILL_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadAcco.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable ReadEmployees(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadAcco = "MESS_BILL.SP_READ_EMPLOYEES";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadAcco.Parameters.Add("E_SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityMessBill.SearchString;
                cmdReadAcco.Parameters.Add("E_ACCMDTN_ID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                cmdReadAcco.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtEmp;
            }
        }

        public DataTable CheckEmployeeMessDate(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadData = "MESS_BILL.SP_CHECK_EMP_MESS_DATE";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_BILL_ID", OracleDbType.Int32).Value = objEntityMessBill.MessBillId;
                cmdReadData.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessBill.EmpId;
                cmdReadData.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessBill.Fromdate;
                cmdReadData.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessBill.Todate;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }

        public DataTable ReadBusnsUnitsAcmdtn(clsEntity_Mess_Bill objEntityMessBill)
        {
            string strQueryReadData = "MESS_BILL.SP_READ_BUSNS_UNIT_ACMDTN";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessBill.Organisation_Id;
                cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessBill.CorpOffice_Id;
                cmdReadData.Parameters.Add("E_ACMDTN_ID", OracleDbType.Int32).Value = objEntityMessBill.AccomoDationId;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }





    }
}
