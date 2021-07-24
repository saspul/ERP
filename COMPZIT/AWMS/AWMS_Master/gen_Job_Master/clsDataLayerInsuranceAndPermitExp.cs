using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;

namespace DL_Compzit.DataLayer_AWMS
{

    public class clsDataLayerInsuranceAndPermitRenewal
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch insuranse and permit expiry date list
        public DataTable ReadInsuranceAndPermitExpDate(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadInsuranceAndPermitExpDate = "INSURANCE_AND_PERMIT.SP_READ_INSRNC_AND_PERMT_LIST";
            OracleCommand cmdReadInsuranceAndPermitExpDate = new OracleCommand();
            cmdReadInsuranceAndPermitExpDate.CommandText = strQueryReadInsuranceAndPermitExpDate;
            cmdReadInsuranceAndPermitExpDate.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadInsuranceAndPermitExpDate);
            return dtCategoryList;
        }

        // This Method will fetCH Vehicle renewal
        public DataTable ReadVehicleRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadVehicleRenewal = "INSURANCE_AND_PERMIT.SP_VEHICLE_RENEWAL";
            OracleCommand cmdReadVehicleRenewal = new OracleCommand();
            cmdReadVehicleRenewal.CommandText = strQueryReadVehicleRenewal;
            cmdReadVehicleRenewal.CommandType = CommandType.StoredProcedure;
            //cmdReadVehicleRenewal.Parameters.Add("IP_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.RenewalId;
            cmdReadVehicleRenewal.Parameters.Add("IP_RENEWAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleRenewal);
            return dtCategory;
        }


        // This Method will fetch insuranse and permit expiry date list
        public DataTable ReadInsuranceAndPermitAsOnDate(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadInsuranceAndPermitExpDate = "INSURANCE_AND_PERMIT.SP_READ_INSRNC_PERMT_DATE_LIST";
            OracleCommand cmdReadInsuranceAndPermitExpDate = new OracleCommand();
            cmdReadInsuranceAndPermitExpDate.CommandText = strQueryReadInsuranceAndPermitExpDate;
            cmdReadInsuranceAndPermitExpDate.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.DisplayMode;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_VHCL_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.VehiclNmbr;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadInsuranceAndPermitExpDate);
            return dtCategoryList;
        }

        // this method will fetch the vehicle details according to the date

        public DataTable ReadExpVehicleDetails(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadExpInsuranceDetails = "INSURANCE_AND_PERMIT.SP_READ_VEHICLE_EXP_DETAILS";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_VEHID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }


        //Method for inserting data to insurance renewal table 
        public void InsertInsurnceRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList)
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_INS_INSR_EXP_DETAILS";
                    using (OracleCommand cmdInsertInsurnceRenewal = new OracleCommand(strQueryInsertInsurnceRenewal, con))
                    {
                        cmdInsertInsurnceRenewal.Transaction = tran;


                        cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumInsure;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_INSUR_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.OldNumber;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_INSUR_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.OldDate;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_INSURPRVDR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsPrvdrId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_INSUR_AMNT", OracleDbType.Decimal).Value = objEntityInsAndPrmt.OldInsureAmount;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_FIL_NM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.OldFileName;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_INSUR_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewNumber;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_INSUR_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_INSURPRVDR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.NewInsPrvdrId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_INSUR_AMNT", OracleDbType.Decimal).Value = objEntityInsAndPrmt.NewInsureAmount;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_FIL_NM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewFileName;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_INSURRNWL_INS_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEWSTATUS", OracleDbType.Int32).Value = objEntityInsAndPrmt.StatusForNew;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_COVRGTYP_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsCovrgTypId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_COVRGTYP_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.NewInsCovrgTypId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
                        clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
                    }


                    string strQueryUpdateNewStatus = "INSURANCE_AND_PERMIT.SP_UPD_NEWSTATUS_INS";
                    using (OracleCommand cmdUpdateNewStatus = new OracleCommand(strQueryUpdateNewStatus, con))
                    {
                        cmdUpdateNewStatus.Transaction = tran;

                        cmdUpdateNewStatus.CommandText = strQueryUpdateNewStatus;
                        cmdUpdateNewStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateNewStatus.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumInsure;
                        cmdUpdateNewStatus.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
                        cmdUpdateNewStatus.Parameters.Add("IP_NEW_INSUR_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
                        clsDataLayer.ExecuteNonQuery(cmdUpdateNewStatus);
                    }
                    foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityRnwlAttchmntDeatilsList)
                    {
                        string strQueryInsertAtcmntDtls = "INSURANCE_AND_PERMIT.SP_INS_INSUR_ATCHMNT_DTLS";
                        using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                        {
                            cmdInsertAtcmntDtls.Transaction = tran;

                            cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                            cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_INSURRNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumInsure;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_INSURRNWL_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_INSURRNWL_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_INSURRNWL_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                            clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
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

        //Method for inserting data to insurance renewal table 
        public void InsertPermtRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList)
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_INS_PRMT_EXP_DETAILS";
                    using (OracleCommand cmdInsertInsurnceRenewal = new OracleCommand(strQueryInsertInsurnceRenewal, con))
                    {
                        cmdInsertInsurnceRenewal.Transaction = tran;

                        cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
                        cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumPer;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_PERMIT_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.OldNumber;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_PRMT_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.OldDate;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_OLD_FIL_NM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.OldFileName;
                     //   cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_PERMIT_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewNumber;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_PRMT_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEW_FIL_NM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewFileName;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_PRMTRNWL_INS_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_NEWSTATUS", OracleDbType.Int32).Value = objEntityInsAndPrmt.StatusForNew;
                        cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
                        clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
                    }

                    string strQueryUpdateNewStatus = "INSURANCE_AND_PERMIT.SP_UPD_NEWSTATUS_PER";
                    using (OracleCommand cmdUpdateNewStatus = new OracleCommand(strQueryUpdateNewStatus, con))
                    {
                        cmdUpdateNewStatus.Transaction = tran;

                        cmdUpdateNewStatus.CommandText = strQueryUpdateNewStatus;
                        cmdUpdateNewStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateNewStatus.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumPer;
                        cmdUpdateNewStatus.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
                        cmdUpdateNewStatus.Parameters.Add("IP_NEW_PRMT_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
                        clsDataLayer.ExecuteNonQuery(cmdUpdateNewStatus);
                    }
                    foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityRnwlAttchmntDeatilsList)
                    {
                        string strQueryInsertAtcmntDtls = "INSURANCE_AND_PERMIT.SP_INS_PRMT_ATCHMNT_DTLS";
                        using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                        {
                            cmdInsertAtcmntDtls.Transaction = tran;

                            cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                            cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_PRMTRNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.NextNumPer;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_PRMTRNWL_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_PRMTRNWL_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_PRMTRNWL_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
                            cmdInsertAtcmntDtls.Parameters.Add("IP_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                            clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
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

        //Method for inserting data to insurance renewal table 
        public void CancelInsuranceRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_CANCEL_INSRNCE_RNWL";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsrnceRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_REASON", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.Cancelreason;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
        }
        //Method for inserting data to insurance renewal table 
        public void CancelPermitRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_CANCEL_PERMIT_RNWL";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.PermitRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_REASON", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.Cancelreason;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
        }



        public void CancelInsuranceRenewalTR(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_CNCL_INSRNCE_RNWL_TR";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsrnceRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_REASON", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.Cancelreason;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
        }


        public void CancelPermitRenewalTR(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_CANL_PERMIT_RNWL_TR";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.PermitRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_REASON", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.Cancelreason;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);
        }
        //Method for insurance renewal RECALL 
        public void RecallInsuranceRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_RECALL_INSRNCE_RNWL";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsrnceRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RECL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);


            string strQueryUpdateNewStatus = "INSURANCE_AND_PERMIT.SP_UPD_NEWSTATUS_INS";
            OracleCommand cmdUpdateNewStatus = new OracleCommand();
            cmdUpdateNewStatus.CommandText = strQueryUpdateNewStatus;
            cmdUpdateNewStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdateNewStatus.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.InsrnceRnwlId;
            cmdUpdateNewStatus.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdUpdateNewStatus.Parameters.Add("IP_NEW_INSUR_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
            clsDataLayer.ExecuteNonQuery(cmdUpdateNewStatus);
        }
        //Method for permit renewal recall
        public void RecallPermitRenewal(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryInsertInsurnceRenewal = "INSURANCE_AND_PERMIT.SP_RECALL_PERMIT_RNWL";
            OracleCommand cmdInsertInsurnceRenewal = new OracleCommand();
            cmdInsertInsurnceRenewal.CommandText = strQueryInsertInsurnceRenewal;
            cmdInsertInsurnceRenewal.CommandType = CommandType.StoredProcedure;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RNWL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.PermitRnwlId;
            cmdInsertInsurnceRenewal.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdInsertInsurnceRenewal.Parameters.Add("IP_RECL_USR_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdInsertInsurnceRenewal);

            string strQueryUpdateNewStatus = "INSURANCE_AND_PERMIT.SP_UPD_NEWSTATUS_PER";
            OracleCommand cmdUpdateNewStatus = new OracleCommand();
            cmdUpdateNewStatus.CommandText = strQueryUpdateNewStatus;
            cmdUpdateNewStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdateNewStatus.Parameters.Add("IP_NEXT", OracleDbType.Int32).Value = objEntityInsAndPrmt.PermitRnwlId;
            cmdUpdateNewStatus.Parameters.Add("IP_VHCL_ID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdUpdateNewStatus.Parameters.Add("IP_NEW_PRMT_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
            clsDataLayer.ExecuteNonQuery(cmdUpdateNewStatus);
        }


        // This Method will fetCH Vehicle Number
        public DataTable ReadVehicleNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadVehicleNumber = "INSURANCE_AND_PERMIT.SP_VEHICLE_NUMBER";
            OracleCommand cmdReadVehicleNumber = new OracleCommand();
            cmdReadVehicleNumber.CommandText = strQueryReadVehicleNumber;
            cmdReadVehicleNumber.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleNumber.Parameters.Add("IP_VEH_NUMBER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleNumber);
            return dtCategory;
        }
        // This Method will fetCH insurance provider id
        public DataTable ReadInsurncPrvdrId(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadInsurncPrvdrId = "INSURANCE_AND_PERMIT.SP_INSURNC_PRVDR_ID";
            OracleCommand cmdReadInsurncPrvdrId = new OracleCommand();
            cmdReadInsurncPrvdrId.CommandText = strQueryReadInsurncPrvdrId;
            cmdReadInsurncPrvdrId.CommandType = CommandType.StoredProcedure;
            cmdReadInsurncPrvdrId.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadInsurncPrvdrId.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadInsurncPrvdrId.Parameters.Add("IP_INSURNC_PRVDR_ID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsurncPrvdrId);
            return dtCategory;
        }

        // This Method will fetCH insurance provider id
        public DataTable ReadRenewalListBySearch(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadRenewalList = "INSURANCE_AND_PERMIT.SP_READ_RENEWAL_LIST";
            OracleCommand cmdReadRenewalList = new OracleCommand();
            cmdReadRenewalList.CommandText = strQueryReadRenewalList;
            cmdReadRenewalList.CommandType = CommandType.StoredProcedure;
            cmdReadRenewalList.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadRenewalList.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadRenewalList.Parameters.Add("IP_FROM", OracleDbType.Date).Value = objEntityInsAndPrmt.FromDate;
            cmdReadRenewalList.Parameters.Add("IP_TO", OracleDbType.Date).Value = objEntityInsAndPrmt.ToDate;
            cmdReadRenewalList.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.DisplayMode;
            cmdReadRenewalList.Parameters.Add("IP_CNCL", OracleDbType.Int32).Value = objEntityInsAndPrmt.CancelCheck;
            cmdReadRenewalList.Parameters.Add("IP_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRenewalList);
            return dtCategory;
        }

        // This Method checks PERMIT NUMBER in the database for duplication.
        public string CheckPermitNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {

            string strQueryChecKPerNum = "VEHICLE_MASTER.SP_CHECK_PERMITNUMBER";
            OracleCommand cmdCheckPerNum = new OracleCommand();
            cmdCheckPerNum.CommandText = strQueryChecKPerNum;
            cmdCheckPerNum.CommandType = CommandType.StoredProcedure;
            cmdCheckPerNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = 0;
            cmdCheckPerNum.Parameters.Add("V_PERNUM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewNumber;
            cmdCheckPerNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdCheckPerNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdCheckPerNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPerNum);
            string strReturn = cmdCheckPerNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckPerNum.Dispose();
            return strReturn;
        }
        // This Method checks INSURANCE NUMBER in the database for duplication.
        public string CheckInsuranceNumber(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {

            string strQueryChecKInsurNum = "VEHICLE_MASTER.SP_CHECK_INSUR_NUMBER";
            OracleCommand cmdCheckInsurNum = new OracleCommand();
            cmdCheckInsurNum.CommandText = strQueryChecKInsurNum;
            cmdCheckInsurNum.CommandType = CommandType.StoredProcedure;
            cmdCheckInsurNum.Parameters.Add("V_VEHICLEID", OracleDbType.Int32).Value = 0;
            cmdCheckInsurNum.Parameters.Add("V_INSNUM", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.NewNumber;
            cmdCheckInsurNum.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdCheckInsurNum.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdCheckInsurNum.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsurNum);
            string strReturn = cmdCheckInsurNum.Parameters["V_COUNT"].Value.ToString();
            cmdCheckInsurNum.Dispose();
            return strReturn;
        }


        public DataTable ReadPermtRnwlFiles(clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl)
        {
            string strQueryReadExpInsuranceDetails = "INSURANCE_AND_PERMIT.SP_READ_PERMT_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_PERMTID", OracleDbType.Int32).Value = objEntityAttchmntDtl.RnwlId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        public DataTable ReadInsurRnwlFiles(clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl)
        {
            string strQueryReadExpInsuranceDetails = "INSURANCE_AND_PERMIT.SP_READ_INSUR_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_INSURID", OracleDbType.Int32).Value = objEntityAttchmntDtl.RnwlId;
            cmdReadExpInsuranceDetails.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        public DataTable ReadPermitRnwlId(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {

            string strQueryChecKPerNum = "INSURANCE_AND_PERMIT.SP_READ_PRMT_RNWLID";
            OracleCommand cmdCheckPerNum = new OracleCommand();
            cmdCheckPerNum.CommandText = strQueryChecKPerNum;
            cmdCheckPerNum.CommandType = CommandType.StoredProcedure;
            cmdCheckPerNum.Parameters.Add("IP_VEHID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdCheckPerNum.Parameters.Add("IP_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.VehiclNmbr;
            cmdCheckPerNum.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPerNum);
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdCheckPerNum);
            return dtCategoryList;
        }
        public DataTable ReadPermitFiles(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {

            string strQueryChecKPerNum = "INSURANCE_AND_PERMIT.SP_READ_VHCL_PRMT_FILES";
            OracleCommand cmdCheckPerNum = new OracleCommand();
            cmdCheckPerNum.CommandText = strQueryChecKPerNum;
            cmdCheckPerNum.CommandType = CommandType.StoredProcedure;
            cmdCheckPerNum.Parameters.Add("IP_VEHID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdCheckPerNum.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            cmdCheckPerNum.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPerNum);
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdCheckPerNum);
            return dtCategoryList;
        }
        public DataTable ReadInsurFiles(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {

            string strQueryChecKPerNum = "INSURANCE_AND_PERMIT.SP_READ_VHCL_INSUR_FILES";
            OracleCommand cmdCheckPerNum = new OracleCommand();
            cmdCheckPerNum.CommandText = strQueryChecKPerNum;
            cmdCheckPerNum.CommandType = CommandType.StoredProcedure;
            cmdCheckPerNum.Parameters.Add("IP_VEHID", OracleDbType.Int32).Value = objEntityInsAndPrmt.VehicleId;
            cmdCheckPerNum.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.Mode;
            cmdCheckPerNum.Parameters.Add("IP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPerNum);
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdCheckPerNum);
            return dtCategoryList;
        }




        //evm-0027

        public DataTable ReadInsuranceAndPermit(clsEntityInsuranceAndPermitRenewal objEntityInsAndPrmt)
        {
            string strQueryReadInsuranceAndPermitExpDate = "INSURANCE_AND_PERMIT.SP_READ_INS_PERMT_RENWL_LIST";
            OracleCommand cmdReadInsuranceAndPermitExpDate = new OracleCommand();
            cmdReadInsuranceAndPermitExpDate.CommandText = strQueryReadInsuranceAndPermitExpDate;
            cmdReadInsuranceAndPermitExpDate.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_ORGID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Organisation_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_CORPID", OracleDbType.Int32).Value = objEntityInsAndPrmt.Corporate_Id;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_DATE", OracleDbType.Date).Value = objEntityInsAndPrmt.NewDate;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_MODE", OracleDbType.Int32).Value = objEntityInsAndPrmt.DisplayMode;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_VHCL_NUMBR", OracleDbType.Varchar2).Value = objEntityInsAndPrmt.VehiclNmbr;
            cmdReadInsuranceAndPermitExpDate.Parameters.Add("IP_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadInsuranceAndPermitExpDate);
            return dtCategoryList;
        }


        //END
    }
}