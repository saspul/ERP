using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
using CL_Compzit;
using System.Web;

namespace DL_Compzit.DataLayer_PMS
{
   public class clsDataLayerApprovalAssignment
    {
        public DataTable ReadDesgDDL( clsEntityApprovalAssign objEntityAcco)
        {
            string strQueryReadAccommodation = "PMS_APPROVAL_ASSIGNMENT.SP_READ_DESIGNATION";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
           
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable Readwrkflw(string strLikeName, clsEntityApprovalAssign objEntityAcco)
        {
            string strQueryReadAccommodation = "PMS_APPROVAL_ASSIGNMENT.SP_READ_WORKFLOW";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_WRKNAME", OracleDbType.Varchar2).Value = strLikeName;
            cmdReadAccommodation.Parameters.Add("A_DESG", OracleDbType.Int32).Value = objEntityAcco.desgid;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable Readapproval(string strLikeName, clsEntityApprovalAssign objEntityAcco)
        {
            string strQueryReadAccommodation = "PMS_APPROVAL_ASSIGNMENT.SP_READ_APPROVAL";
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
        public void insertApprovalAssignment(clsEntityApprovalAssign objentityPass, List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVAL_ASSIGNMENT.SP_INS_APPROVAL_ASSGNMNT";
           
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

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("AP_ID", OracleDbType.Int32).Value = 1;
                        cmdAddService.Parameters.Add("DSG_ID", OracleDbType.Int32).Value = objentityPass.desgid;
                        cmdAddService.Parameters.Add("COR_ID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("OR_ID", OracleDbType.Int32).Value = objentityPass.Organisation_id;

                        cmdAddService.Parameters.Add("A_IN_USR_ID", OracleDbType.Int32).Value = objentityPass.userid;
                        cmdAddService.Parameters.Add("A_INS_DATE ", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("A_UPD_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_UPD_DATE ", OracleDbType.Date).Value = DBNull.Value;
                       
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalAssign objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "PMS_APPROVAL_ASSIGNMENT.SP_INS_APPROVAL_ASSGNMNT_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("AP_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("WRKFLW_ID", OracleDbType.Int32).Value = objDetail.wrkflwid;
                            cmdAddInsertDetail.Parameters.Add("APPSET_ID", OracleDbType.Int32).Value = objDetail.apprsetid;
                            if (objDetail.StartDate != DateTime.MinValue)
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_START", OracleDbType.Date).Value = objDetail.StartDate;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_START", OracleDbType.Date).Value = DBNull.Value;
                            }
                            if (objDetail.EndDate != DateTime.MinValue)
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_END", OracleDbType.Date).Value = objDetail.EndDate;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_END", OracleDbType.Date).Value = DBNull.Value;
                            }
                            cmdAddInsertDetail.Parameters.Add("AP_CNCL_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("AP_CONSOLE", OracleDbType.Int32).Value = DBNull.Value;
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

        public void updatewrkflwftl(clsEntityApprovalAssign objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVAL_ASSIGNMENT.SP_UPD_DOCUMENT_WRKFLW_FLT";

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

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("A_ID", OracleDbType.Int32).Value = objentityPass.tempid;
                        cmdAddService.Parameters.Add("A_DSGN", OracleDbType.Int32).Value = objentityPass.desgid;
                        cmdAddService.Parameters.Add("A_USR", OracleDbType.Int32).Value = objentityPass.userid;
                        cmdAddService.Parameters.Add("WRK_APP_MN_STS", OracleDbType.Int32).Value = objentityPass.apprsetid;

                        cmdAddService.Parameters.Add("WRK_THR_PRD_STS", OracleDbType.Int32).Value = objentityPass.ThresholdPeriodMode;
                        cmdAddService.Parameters.Add("WRK_THR_PRD ", OracleDbType.Date).Value = objentityPass.ThresholdPeriodDays ;
                        cmdAddService.Parameters.Add("WRK_PEN_MSG_STS", OracleDbType.Int32).Value = objentityPass.AprvPendingSts;
                        cmdAddService.Parameters.Add("WRK_SMS_MSG_STS", OracleDbType.Date).Value = objentityPass.SmsSts;

                        cmdAddService.Parameters.Add("WRK_DSH_MSG_STS", OracleDbType.Int32).Value = objentityPass.SystemSts;
                        cmdAddService.Parameters.Add("WRK_TTC_EXD_MSG_STS", OracleDbType.Date).Value = objentityPass.TtExceededSts;
                        cmdAddService.Parameters.Add("A_APDSGN", OracleDbType.Int32).Value = objentityPass.Status_id;
                        cmdAddService.Parameters.Add("A_SDATE", OracleDbType.Date).Value = objentityPass.StartDate;
                        cmdAddService.Parameters.Add("A_EDATE", OracleDbType.Date).Value = objentityPass.EndDate;
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



        public DataTable ReadApprovalAss(clsEntityApprovalAssign objEntityAcco)
        {
            string strQueryReadAccommodation = "PMS_APPROVAL_ASSIGNMENT.SP_READ_APPROVALASS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;

            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadAppAssignment(clsEntityApprovalAssign objEntityAcco)
        {
            string strQueryReadAccommodation = "PMS_APPROVAL_ASSIGNMENT.SP_READ_APPROVALASSIGNMENT";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.tempid;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void cancelApprovalAss(clsEntityApprovalAssign objEntityAcco)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVAL_ASSIGNMENT.SP_CNCL_APPROVAL_ASSGNMNT_DTLS";
          
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
                     

                        cmdAddService.Parameters.Add("AP_DTL_ID", OracleDbType.Int32).Value = objEntityAcco.tempid;
                        cmdAddService.Parameters.Add("AP_ID", OracleDbType.Int32).Value = objEntityAcco.Status_id;
                        cmdAddService.Parameters.Add("AP_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityAcco.userid;
                       
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

        public void UpdateApprovalAssign(clsEntityApprovalAssign objentityPass, List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVAL_ASSIGNMENT.SP_UPD_APPROVAL_ASSGNMNT";

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

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("AP_ID", OracleDbType.Int32).Value = objentityPass.tempid;
                        cmdAddService.Parameters.Add("DSG_ID", OracleDbType.Int32).Value = objentityPass.desgid;
                        cmdAddService.Parameters.Add("A_UPD_ID", OracleDbType.Int32).Value = objentityPass.userid;
                        cmdAddService.Parameters.Add("A_UPD_DATE", OracleDbType.Date).Value = objentityPass.cDate;
                        

                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalAssign objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "PMS_APPROVAL_ASSIGNMENT.SP_UPD_APPROVAL_ASSGNMNT_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_ID", OracleDbType.Int32).Value = objDetail.desgid;
                            cmdAddInsertDetail.Parameters.Add("AP_ID", OracleDbType.Int32).Value = objDetail.tempid;
                            cmdAddInsertDetail.Parameters.Add("AWRKFLW_ID", OracleDbType.Int32).Value = objDetail.wrkflwid;
                            cmdAddInsertDetail.Parameters.Add("APPSET_ID", OracleDbType.Int32).Value = objDetail.apprsetid;
                            if (objDetail.StartDate != DateTime.MinValue)
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_START", OracleDbType.Date).Value = objDetail.StartDate;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_START", OracleDbType.Date).Value = DBNull.Value;
                            }
                            if (objDetail.EndDate != DateTime.MinValue)
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_END", OracleDbType.Date).Value = objDetail.EndDate;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("AP_END", OracleDbType.Date).Value = DBNull.Value;
                            }
                            cmdAddInsertDetail.Parameters.Add("AP_CNCL_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.Parameters.Add("AP_CONSOLE", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                  
                    //foreach (clsEntityApprovalAssign objDetail in objEntityTrficVioltnDetilsListDele)
                    //{
                    //    string strQueryInsertDetails = "PMS_APPROVAL_ASSIGNMENT.SP_DELETE_APPROVAL_ASS_DTLS";
                    //    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                    //    {
                    //        cmdAddInsertDetail.Transaction = tran;
                    //        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                    //        cmdAddInsertDetail.Parameters.Add("APP_DTL_ID", OracleDbType.Int32).Value = objDetail.tempid;
                           
                    //        cmdAddInsertDetail.ExecuteNonQuery();
                    //    }
                    //}

                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }



    }
}
