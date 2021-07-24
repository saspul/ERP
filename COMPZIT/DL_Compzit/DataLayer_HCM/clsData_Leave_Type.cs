using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
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
    public class clsData_Leave_Type
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        public DataTable ReadDesignation(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_DSGN_BY_USRID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;

                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;


                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadPaygrade(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_PAYGRADE";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityLeaveType.User_Id;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id; ;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadExperience(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_EXPERIENCE";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;

                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }




        public DataTable ReadLeaveTypeBySearch(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_READ_LEAVETYP_BYSEARCH";
            OracleCommand cmdReadLevTypsrch = new OracleCommand();
            cmdReadLevTypsrch.CommandText = strQueryLeaveTyp;
            cmdReadLevTypsrch.CommandType = CommandType.StoredProcedure;
            cmdReadLevTypsrch.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
            cmdReadLevTypsrch.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
            cmdReadLevTypsrch.Parameters.Add("L_OPTION", OracleDbType.Int32).Value = ObjEntityLeaveType.Status_id;
            cmdReadLevTypsrch.Parameters.Add("L_CANCEL", OracleDbType.Int32).Value = ObjEntityLeaveType.CancelStatus;
            cmdReadLevTypsrch.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadLevTypsrch);
            return dtLeavTyp;


        }

        public DataTable ReadConfirmedLevAllocn(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_READ_LEAVALLOCNSTATUS";
            OracleCommand cmdReadLevTypsrch = new OracleCommand();
            cmdReadLevTypsrch.CommandText = strQueryLeaveTyp;
            cmdReadLevTypsrch.CommandType = CommandType.StoredProcedure;
            // cmdReadLevTypsrch.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
            //cmdReadLevTypsrch.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
            cmdReadLevTypsrch.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
            cmdReadLevTypsrch.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadLevTypsrch);
            return dtLeavTyp;


        }

        public void AddLeaveType(clsEntity_Leave_Type ObjEntityLeaveType, List<clsEntity_designation_list> ObjEntityLeaveDesignationList, List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList, List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList, List<clsEntity_Users_list> objEntityUser_List)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_INS_LEAVE_TYPE_DETAILS";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdAddLeav = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddLeav.Transaction = tran;

                        cmdAddLeav.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_LEAVE_TYPE_MASTER);
                        objEntCommon.CorporateID = ObjEntityLeaveType.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        ObjEntityLeaveType.intleave = Convert.ToInt32(strNextNum);
                        cmdAddLeav.CommandText = strQueryLeaveTyp;
                        cmdAddLeav.CommandType = CommandType.StoredProcedure;
                        cmdAddLeav.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                        cmdAddLeav.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.Status_id;
                        cmdAddLeav.Parameters.Add("L_USERID", OracleDbType.Int32).Value = ObjEntityLeaveType.User_Id;
                        cmdAddLeav.Parameters.Add("L_NODAYS", OracleDbType.Int32).Value = ObjEntityLeaveType.NoOfDays;
                        cmdAddLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = ObjEntityLeaveType.LeaveTypeName;
                        cmdAddLeav.Parameters.Add("L_DESC", OracleDbType.Varchar2).Value = ObjEntityLeaveType.LeaveDesc;   
                        cmdAddLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
                        cmdAddLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                        cmdAddLeav.Parameters.Add("L_LEAVE_ABSENCE", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveOnAbsence;
                        cmdAddLeav.Parameters.Add("L_APPLICABLE_NONE_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.ApplicableNone;
                        cmdAddLeav.Parameters.Add("L_EXC_SAL_PROC_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.ExcSalProc;
                        cmdAddLeav.Parameters.Add("L_INC_DUTY_REJOIN_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.IncDutyRejoin;
                        cmdAddLeav.Parameters.Add("L_HOLIDAY_PAID_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.HoliPaid;
                        cmdAddLeav.Parameters.Add("L_OFFDAY_PAID_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.OffPaid;
                        cmdAddLeav.ExecuteNonQuery();
                    }


                    string strQueryInsertDetail = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_TYPE_DETAILS";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                        cmdAddInsertDetail.Parameters.Add("L_TRVLNEED", OracleDbType.Int32).Value = ObjEntityLeaveType.intTravelNeeded;
                        cmdAddInsertDetail.Parameters.Add("L_PAIDLEAV", OracleDbType.Int32).Value = ObjEntityLeaveType.intPaidLeave;
                        cmdAddInsertDetail.Parameters.Add("L_LEAVETYPE", OracleDbType.Int32).Value = ObjEntityLeaveType.intCalendarRb;
                        cmdAddInsertDetail.Parameters.Add("L_SEX", OracleDbType.Int32).Value = ObjEntityLeaveType.intsexRb;
                        cmdAddInsertDetail.Parameters.Add("L_MARITAL_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.MaritalStatus;
                        cmdAddInsertDetail.Parameters.Add("L_SETTLMTSTS", OracleDbType.Int32).Value = ObjEntityLeaveType.SettlmtSts;
                        cmdAddInsertDetail.Parameters.Add("L_MONTHLYINC", OracleDbType.Int32).Value = ObjEntityLeaveType.Monthly;
                        cmdAddInsertDetail.ExecuteNonQuery();
                    }

                    if (ObjEntityLeaveType.intDesignationStatus == 0)
                    {

                        foreach (clsEntity_designation_list objDetail in ObjEntityLeaveDesignationList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_DESIGNATION";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intDesignationliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_DESIGNATION_ID", OracleDbType.Int32).Value = objDetail.intDesignationlist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }



                        }
                       
                    }
                    else if (ObjEntityLeaveType.intDesignationStatus == 1)
                    {
                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_DESIGNATION";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intDesignationStatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_DESIGNATION_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                      
                    }



                    if (ObjEntityLeaveType.intpaygradestatus == 0)
                    {

                        foreach (clsEntity_paygrade_list objDetail in ObjEntityLeavPayGradeList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_PAYGRADE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intpaygradeliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_PAYGRADE_ID", OracleDbType.Int32).Value = objDetail.intpaygradelist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }


                        }
                      
                    }
                    else if (ObjEntityLeaveType.intpaygradestatus == 1)
                    {
                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_PAYGRADE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intpaygradestatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_PAYGRADE_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                       

                    }

                    if (ObjEntityLeaveType.intexperiencesstatus == 0)
                    {
                        foreach (clsEntity_experience_list objDetail in ObjEntityLeaveExpriencenOList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_EXPERIENCE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intexperienceliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_EXPERIENCDE_ID", OracleDbType.Int32).Value = objDetail.intexperiencelist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }

                        }
                     
                    }
                    else if (ObjEntityLeaveType.intexperiencesstatus == 1)
                    {
                       
                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_EXPERIENCE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intexperiencesstatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_EXPERIENCDE_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                  
                    }
                    if (ObjEntityLeaveType.intexperiencesstatus != 0 || ObjEntityLeaveType.intpaygradestatus != 0 || ObjEntityLeaveType.intDesignationStatus != 0)
                    {

                        string strQueryLeaveTypeDetails = "HCM_LEAVE_TYPE.SP_INS_ALL_USR_BY_EXP";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryLeaveTypeDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
                            cmdAddInsertDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                            cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                            cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        foreach (clsEntity_Users_list objDetailList in objEntityUser_List)
                        {
                            string strQueryLeaveTypeDetails = "HCM_LEAVE_TYPE.SP_INS_USER_LEAVE_TYPE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryLeaveTypeDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objDetailList.UserID;
                                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.ExecuteNonQuery();
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

        public void UpdateLeaveType(clsEntity_Leave_Type ObjEntityLeaveType, List<clsEntity_designation_list> ObjEntityLeaveDesignationList, List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList, List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList, List<clsEntity_Users_list> objEntityUser_List)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_UPD_LEAVE_TYPE_DETAILS";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdAddLeav = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddLeav.Transaction = tran;

                        cmdAddLeav.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_LEAVE_TYPE_MASTER);
                        objEntCommon.CorporateID = ObjEntityLeaveType.Corporate_id;
                        //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        //ObjEntityLeaveType.intleave = Convert.ToInt32(strNextNum);
                        cmdAddLeav.CommandText = strQueryLeaveTyp;
                        cmdAddLeav.CommandType = CommandType.StoredProcedure;
                        cmdAddLeav.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                        cmdAddLeav.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.Status_id;
                        cmdAddLeav.Parameters.Add("L_USERID", OracleDbType.Int32).Value = ObjEntityLeaveType.User_Id;
                        cmdAddLeav.Parameters.Add("L_NODAYS", OracleDbType.Int32).Value = ObjEntityLeaveType.NoOfDays;
                        cmdAddLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = ObjEntityLeaveType.LeaveTypeName;
                        cmdAddLeav.Parameters.Add("L_DESC", OracleDbType.Varchar2).Value = ObjEntityLeaveType.LeaveDesc;
                        cmdAddLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
                        cmdAddLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                        cmdAddLeav.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                        cmdAddLeav.Parameters.Add("L_LEAVE_ABSENCE", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveOnAbsence;
                        cmdAddLeav.Parameters.Add("L_APPLICABLE_NONE_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.ApplicableNone;
                        cmdAddLeav.Parameters.Add("L_EXC_SAL_PROC_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.ExcSalProc;
                        cmdAddLeav.Parameters.Add("L_INC_DUTY_REJOIN_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.IncDutyRejoin;
                        cmdAddLeav.Parameters.Add("L_HOLIDAY_PAID_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.HoliPaid;
                        cmdAddLeav.Parameters.Add("L_OFFDAY_PAID_STS", OracleDbType.Int32).Value = ObjEntityLeaveType.OffPaid;
                        cmdAddLeav.ExecuteNonQuery();
                    }


                    string strQueryInsertDetail = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_TYPE_DETAILS";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;

                        cmdAddInsertDetail.Parameters.Add("L_TRVLNEED", OracleDbType.Int32).Value = ObjEntityLeaveType.intTravelNeeded;
                        cmdAddInsertDetail.Parameters.Add("L_PAIDLEAV", OracleDbType.Int32).Value = ObjEntityLeaveType.intPaidLeave;
                        cmdAddInsertDetail.Parameters.Add("L_LEAVETYPE", OracleDbType.Int32).Value = ObjEntityLeaveType.intCalendarRb;
                        cmdAddInsertDetail.Parameters.Add("L_SEX", OracleDbType.Int32).Value = ObjEntityLeaveType.intsexRb;
                        cmdAddInsertDetail.Parameters.Add("L_MARITAL_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.MaritalStatus;
                        cmdAddInsertDetail.Parameters.Add("L_SETTLMTSTS", OracleDbType.Int32).Value = ObjEntityLeaveType.SettlmtSts;
                        cmdAddInsertDetail.Parameters.Add("L_MONTHLYINC", OracleDbType.Int32).Value = ObjEntityLeaveType.Monthly;
                        cmdAddInsertDetail.ExecuteNonQuery();
                    }
                    string strQuerydELETEDesg = "HCM_LEAVE_TYPE.SP_DELETE_DESG";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQuerydELETEDesg, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;

                        cmdAddInsertDetail.ExecuteNonQuery();
                    }
                    string strQueryRemoveLeaveType = "HCM_LEAVE_TYPE.SP_DEL_USER_LEAVE_TYPE";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryRemoveLeaveType, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                        cmdAddInsertDetail.ExecuteNonQuery();
                    }
                    if (ObjEntityLeaveType.intDesignationStatus == 0)
                    {

                        foreach (clsEntity_designation_list objDetail in ObjEntityLeaveDesignationList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_DESIGNATION";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intDesignationliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_DESIGNATION_ID", OracleDbType.Int32).Value = objDetail.intDesignationlist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }

                    }
                    else
                    {
                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_INS_HCM_LEAVE_DESIGNATION";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intDesignationStatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_DESIGNATION_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                    }

                    string strQuerydELETEPay = "HCM_LEAVE_TYPE.SP_DELETE_PAYGRD";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQuerydELETEPay, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;

                        cmdAddInsertDetail.ExecuteNonQuery();
                    }
                    if (ObjEntityLeaveType.intpaygradestatus == 0)
                    {

                        foreach (clsEntity_paygrade_list objDetail in ObjEntityLeavPayGradeList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_PAYGRADE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intpaygradeliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_PAYGRADE_ID", OracleDbType.Int32).Value = objDetail.intpaygradelist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }

                    }
                    else
                    {
                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_PAYGRADE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intpaygradestatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_PAYGRADE_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }


                    }
                    string strQuerydELETEExp = "HCM_LEAVE_TYPE.SP_DELETE_EXP";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQuerydELETEExp, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;

                        cmdAddInsertDetail.ExecuteNonQuery();
                    }
                    if (ObjEntityLeaveType.intexperiencesstatus == 0)
                    {

                        foreach (clsEntity_experience_list objDetail in ObjEntityLeaveExpriencenOList)
                        {

                            string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_EXPERIENCE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objDetail.intexperienceliststatus_id;
                                cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_EXPERIENCDE_ID", OracleDbType.Int32).Value = objDetail.intexperiencelist_id;

                                cmdAddInsertDetail.ExecuteNonQuery();
                            }

                        }

                    }
                    else
                    {

                        string strQueryInsertDetails = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_EXPERIENCE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = ObjEntityLeaveType.intexperiencesstatus;
                            cmdAddInsertDetail.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_EXPERIENCDE_ID", OracleDbType.Int32).Value = null;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                    }
                    if (ObjEntityLeaveType.intexperiencesstatus != 0 || ObjEntityLeaveType.intpaygradestatus != 0 || ObjEntityLeaveType.intDesignationStatus != 0)
                    {
                       
                        string strQueryLeaveTypeDetails = "HCM_LEAVE_TYPE.SP_INS_ALL_USR_BY_EXP";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryLeaveTypeDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
                            cmdAddInsertDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                            cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                            cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                            cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        foreach (clsEntity_Users_list objDetailList in objEntityUser_List)
                        {
                            string strQueryLeaveTypeDetails = "HCM_LEAVE_TYPE.SP_INS_USER_LEAVE_TYPE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryLeaveTypeDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objDetailList.UserID;
                                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                                cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.ExecuteNonQuery();
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
      

        public DataTable ReadLeavedetailsById(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_READ_HCM_LEAVE_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryLeaveTyp;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
            cmdReadHol.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;


        }


        public DataTable ReadLeavedDesigById(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_READ_DESINATION_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryLeaveTyp;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
            cmdReadHol.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;


        }

        public DataTable ReadLeavePaygradeById(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_READ_PAYGRADE_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryLeaveTyp;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
            cmdReadHol.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;


        }

        public DataTable ReadLeaveExprnsById(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_READ_EXPERIENCE_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryLeaveTyp;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
            cmdReadHol.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;


        }
        public void CancelLeaveType(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_CANCEL_LEAVE_DETAILS";
            using (OracleCommand cmdCanLev = new OracleCommand())
            {
                cmdCanLev.CommandText = strQueryLeaveTyp;
                cmdCanLev.CommandType = CommandType.StoredProcedure;
                cmdCanLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdCanLev.Parameters.Add("L_USERID", OracleDbType.Int32).Value = ObjEntityLeaveType.User_Id;
                cmdCanLev.Parameters.Add("L_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCanLev.Parameters.Add("L_CANRES", OracleDbType.Varchar2).Value = ObjEntityLeaveType.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCanLev);
            }
        }



        public string CheckLeaveName(clsEntity_Leave_Type ObjEntityLeaveType)
        {

            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_CHECK_LEAVE_TYPE_NAME";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
            cmdReadLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = ObjEntityLeaveType.LeaveTypeName;
            cmdReadLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = ObjEntityLeaveType.Organisation_id;
            cmdReadLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
            cmdReadLeav.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadLeav);
            string strReturn = cmdReadLeav.Parameters["L_COUNT"].Value.ToString();
            cmdReadLeav.Dispose();
            return strReturn;
        }




        public void ReCallLeaveDetails(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_RECALL_LEAVETYP_DETAILS";
            using (OracleCommand cmdRecLev = new OracleCommand())
            {
                cmdRecLev.CommandText = strQueryLeaveTyp;
                cmdRecLev.CommandType = CommandType.StoredProcedure;
                cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.intleave;
                cmdRecLev.Parameters.Add("L_USERID", OracleDbType.Int32).Value = ObjEntityLeaveType.User_Id;
                cmdRecLev.Parameters.Add("L_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecLev);
            }
        }

        public DataTable ReadDesignationUsers(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_DSGN_USERS";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("DSGN", OracleDbType.Varchar2).Value = ObjEntityLeaveType.DesignationID;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadPaygradeUsers(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_PAYGRADE_USERS";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("PAUGRD", OracleDbType.Varchar2).Value = ObjEntityLeaveType.Paygrade;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadExperienceUsers(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_EXPERINC_USERS";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("EXPR", OracleDbType.Varchar2).Value = ObjEntityLeaveType.Experience;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadExperienceUsersMore25(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadProj = "HCM_LEAVE_TYPE.SP_READ_EXPERINC_USERS_ABOVE";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadExperienceByID(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_EXPERIENCE_BYID";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
               // cmdReadExp.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.experience_id;
                cmdReadExp.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public string CheckLeavOnAbsnc(clsEntity_Leave_Type ObjEntityLeaveType)
        {

            string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_CHECK_LEAVE_ON_ABSNCE";
            OracleCommand cmdReadLeav = new OracleCommand();
            cmdReadLeav.CommandText = strQueryLeaveTyp;
            cmdReadLeav.CommandType = CommandType.StoredProcedure;
            cmdReadLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = ObjEntityLeaveType.Corporate_id;
            cmdReadLeav.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadLeav);
            string strReturn = cmdReadLeav.Parameters["L_COUNT"].Value.ToString();
            cmdReadLeav.Dispose();
            return strReturn;
        }

        public DataTable ReadIndividualLeavTypById(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_INDIVIDUAL_LEAVETYP";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_LEVTYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public void InsertUpdateDeleteIndividualLeavetyp(clsEntity_Leave_Type objEntityLeaveType, List<clsEntity_Leave_Type> ObjEntityLeaveTypeList, List<clsEntity_Leave_Type> ObjEntityLeaveTypeDeleteList, List<clsEntity_Leave_Type> ObjEntityLeaveTypeOverrideList)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_INS_INDIVIDUAL_LEAVETYP";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    objEntityLeaveType.IndvdlLeavIds = "";

                    //adding individual leave types
                    foreach (clsEntity_Leave_Type objEntity in ObjEntityLeaveTypeList)
                    {
                        using (OracleCommand cmdRecLev = new OracleCommand(strQueryLeaveTyp, con))
                        {
                            cmdRecLev.Transaction = tran;
                            cmdRecLev.CommandType = CommandType.StoredProcedure;
                            cmdRecLev.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveType.Corporate_id;
                            cmdRecLev.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveType.Organisation_id;
                            cmdRecLev.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLeaveType.User_Id;
                            cmdRecLev.Parameters.Add("L_LEVTYPEID", OracleDbType.Int32).Value = objEntityLeaveType.LeaveTypeMasterId;
                            cmdRecLev.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                            cmdRecLev.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntity.Date;
                            cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntity.IndividualLeavTypId;
                            cmdRecLev.Parameters.Add("L_CNFRM_STS", OracleDbType.Int32).Value = objEntity.ConfirmSts;
                            cmdRecLev.Parameters.Add("L_REOPEN_STS", OracleDbType.Int32).Value = objEntity.ReopenSts;
                            cmdRecLev.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdRecLev.ExecuteNonQuery();
                            string strReturn = cmdRecLev.Parameters["L_OUT"].Value.ToString();
                            cmdRecLev.Dispose();
                            objEntityLeaveType.IndvdlLeavIds = strReturn;
                        }

                        if (objEntity.IndividualLeavTypId != 0)
                        {
                            objEntityLeaveType.IndvdlLeavIds = objEntity.IndividualLeavTypId.ToString();
                        }

                        //on confirm add to gn_user_leave_types
                        if (objEntity.ConfirmSts == 1)
                        {
                            string strQueryLeaveTypeDetails = "HCM_LEAVE_TYPE.SP_INS_USER_LEAVE_TYPE";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryLeaveTypeDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveType.LeaveTypeMasterId;
                                cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = objEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLeaveType.NoOfDays;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }

                            //on override given
                            if (objEntity.OverRideSts == 1)
                            {
                                foreach (clsEntity_Leave_Type objEntityOvrd in ObjEntityLeaveTypeOverrideList)
                                {
                                    string strQueryLeaveOverdTyp = "HCM_LEAVE_TYPE.SP_INS_USR_OVERRIDE_LEAVETYP";
                                    using (OracleCommand cmdRecLev = new OracleCommand(strQueryLeaveOverdTyp, con))
                                    {
                                        cmdRecLev.Transaction = tran;
                                        cmdRecLev.CommandType = CommandType.StoredProcedure;
                                        cmdRecLev.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = objEntityOvrd.LeaveTypeMasterId;
                                        cmdRecLev.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                                        cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntity.IndividualLeavTypId;
                                        cmdRecLev.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = objEntity.Year;
                                        cmdRecLev.ExecuteNonQuery();
                                    }

                                    string strQueryLeaveOverdUpdTyp = "HCM_LEAVE_TYPE.SP_UPD_BALANCEON_OVERRIDE";
                                    using (OracleCommand cmdRecLev = new OracleCommand(strQueryLeaveOverdUpdTyp, con))
                                    {
                                        cmdRecLev.Transaction = tran;
                                        cmdRecLev.CommandType = CommandType.StoredProcedure;
                                        cmdRecLev.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = objEntityOvrd.LeaveTypeMasterId;
                                        cmdRecLev.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                                        cmdRecLev.Parameters.Add("L_DAYS", OracleDbType.Decimal).Value = objEntityOvrd.OverRideDays;
                                        cmdRecLev.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = objEntity.Year;
                                        cmdRecLev.ExecuteNonQuery();
                                    }

                                }
                            }
                        }
                        //on reopen delete from gn_user_leave_types
                        if (objEntity.ReopenSts == 1)
                        {
                            string strQueryRemoveLeaveType = "HCM_LEAVE_TYPE.SP_DEL_USRLVTYP_INDIVIDUALLY";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryRemoveLeaveType, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveType.LeaveTypeMasterId;
                                cmdAddInsertDetail.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }

                            //on override given
                            if (objEntity.OverRideSts == 1)
                            {
                                foreach (clsEntity_Leave_Type objEntityOvrd in ObjEntityLeaveTypeOverrideList)
                                {
                                    string strQueryLeaveOverdTyp = "HCM_LEAVE_TYPE.SP_DELETE_USERLVTYP_OVERRIDE";
                                    using (OracleCommand cmdRecLev = new OracleCommand(strQueryLeaveOverdTyp, con))
                                    {
                                        cmdRecLev.Transaction = tran;
                                        cmdRecLev.CommandType = CommandType.StoredProcedure;
                                        cmdRecLev.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = objEntityOvrd.LeaveTypeMasterId;
                                        cmdRecLev.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntity.EmployeeId;
                                        cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntity.IndividualLeavTypId;
                                        cmdRecLev.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = objEntity.Year;
                                        cmdRecLev.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                    }
                    //delete individual leave types
                    string strQueryLeaveCanclTyp = "HCM_LEAVE_TYPE.SP_DELETE_INDIVIDUAL_LEAVETYP";
                    foreach (clsEntity_Leave_Type objEntity in ObjEntityLeaveTypeDeleteList)
                    {
                        using (OracleCommand cmdRecLev = new OracleCommand(strQueryLeaveCanclTyp, con))
                        {
                            cmdRecLev.Transaction = tran;
                            cmdRecLev.CommandType = CommandType.StoredProcedure;
                            cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntity.CancelId;
                            cmdRecLev.ExecuteNonQuery();
                            objEntityLeaveType.IndvdlLeavIds = objEntity.CancelId.ToString();
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

        public DataTable ReadEmpJoinDate(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_JOIN_DATE";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public DataTable ReadUserPaidLeaveType(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_USERS_PAID_LEAVETYP";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdReadExp.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = ObjEntityLeaveType.Year;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public DataTable ReadUserLeavTypOverRide(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_USERLVTYP_OVERRIDE";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_ID", OracleDbType.Int32).Value = ObjEntityLeaveType.IndividualLeavTypId;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public DataTable ReadUserLeaveTypes(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_USER_LEAVETYPES";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_EXPMSTRID", OracleDbType.Int32).Value = ObjEntityLeaveType.ExpMstrId;
                cmdReadExp.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = ObjEntityLeaveType.FromDate;
                cmdReadExp.Parameters.Add("L_LEAVTYPID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public DataTable ReadOverRideDtlsByLeaveTypId(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_OVERRIDEDTLS_BYLVTYPID";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public DataTable ReadUserLeavTypDtlsByYr(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryReadExp = "HCM_LEAVE_TYPE.SP_READ_USRLEVTYPDTLS_BY_YEAR";
            using (OracleCommand cmdReadExp = new OracleCommand())
            {
                cmdReadExp.CommandText = strQueryReadExp;
                cmdReadExp.CommandType = CommandType.StoredProcedure;
                cmdReadExp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdReadExp.Parameters.Add("L_LEVTYPID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdReadExp.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = ObjEntityLeaveType.Year;
                cmdReadExp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtExp = new DataTable();
                dtExp = clsDataLayer.ExecuteReader(cmdReadExp);
                return dtExp;
            }
        }

        public void InsertUserNewLevRow(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_INS_USER_LEAVE_TYPE";
            using (OracleCommand cmdAddInsertDetail = new OracleCommand())
            {
                cmdAddInsertDetail.CommandText = strQueryLeaveTyp;
                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                cmdAddInsertDetail.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                clsDataLayer.ExecuteNonQuery(cmdAddInsertDetail);
            }
        }

        public void DeleteUserLeaveTypes(clsEntity_Leave_Type ObjEntityLeaveType)
        {
            string strQueryLeaveTyp = "HCM_LEAVE_TYPE.SP_INS_USER_LEAVE_TYPE";
            using (OracleCommand cmdAddInsertDetail = new OracleCommand())
            {
                cmdAddInsertDetail.CommandText = strQueryLeaveTyp;
                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                cmdAddInsertDetail.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = ObjEntityLeaveType.EmployeeId;
                cmdAddInsertDetail.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = ObjEntityLeaveType.LeaveTypeMasterId;
                cmdAddInsertDetail.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                cmdAddInsertDetail.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = ObjEntityLeaveType.NoOfDays;
                clsDataLayer.ExecuteNonQuery(cmdAddInsertDetail);
            }
        }


    }
}
        
        
    





    

