using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;
// CREATED BY:EVM-0009
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit
{
    public class clsDataLayerAccommodation
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds accommodation details to the table
        public int AddAccommodation(clsEntityAccommodation objEntityAcco)
        {
            int intAccoId = 0;
            clsEntityCommon objEntCommon = new clsEntityCommon();
            clsDataLayer objDatatLayer = new clsDataLayer();
            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOMODATION);
            objEntCommon.CorporateID = objEntityAcco.Corporate_id;
            string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
            intAccoId = Convert.ToInt32(strNextNum);

            string strQueryAddAccommodation = "ACCOMMODATION.SP_INS_ACCOMMODATION_DETAILS";
            using (OracleCommand cmdAddAccommodation = new OracleCommand())
            {
                cmdAddAccommodation.CommandText = strQueryAddAccommodation;
                cmdAddAccommodation.CommandType = CommandType.StoredProcedure;
                cmdAddAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = intAccoId;
                cmdAddAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objEntityAcco.AccoName;
                cmdAddAccommodation.Parameters.Add("A_ADDRESS", OracleDbType.Varchar2).Value = objEntityAcco.AccoAddress;
                cmdAddAccommodation.Parameters.Add("A_TYPE", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
                cmdAddAccommodation.Parameters.Add("A_HVMESS", OracleDbType.Int32).Value = objEntityAcco.HavMessId;
                cmdAddAccommodation.Parameters.Add("A_CORD", OracleDbType.Int32).Value = objEntityAcco.CordinatorId;
                cmdAddAccommodation.Parameters.Add("A_NOSBSCRB", OracleDbType.Int32).Value = objEntityAcco.No_of_Sbscriber;
                cmdAddAccommodation.Parameters.Add("A_NOFLR", OracleDbType.Int32).Value = objEntityAcco.No_Of_Floor;
                cmdAddAccommodation.Parameters.Add("A_LOCTN", OracleDbType.Varchar2).Value = objEntityAcco.Location;
                cmdAddAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
                cmdAddAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
                cmdAddAccommodation.Parameters.Add("A_STATUS", OracleDbType.Int32).Value = objEntityAcco.Status_id;
                cmdAddAccommodation.Parameters.Add("A_INSUSERID", OracleDbType.Int32).Value = objEntityAcco.User_Id;
                cmdAddAccommodation.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdAddAccommodation.Parameters.Add("A_BUS", OracleDbType.Varchar2).Value = objEntityAcco.Bus;
                clsDataLayer.ExecuteNonQuery(cmdAddAccommodation);
            }
            return intAccoId;
        }
        // This Method update accommoadation details to the table
        public void UpdateAccommodation(clsEntityAccommodation objEntityAcco)
        {
            string strQueryUpdateAccommodation = "ACCOMMODATION.SP_UPD_ACCOMMODATION_DETAILS";
            using (OracleCommand cmdUpdateAccommodation = new OracleCommand())
            {
                cmdUpdateAccommodation.CommandText = strQueryUpdateAccommodation;
                cmdUpdateAccommodation.CommandType = CommandType.StoredProcedure;

                cmdUpdateAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                cmdUpdateAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objEntityAcco.AccoName;
                cmdUpdateAccommodation.Parameters.Add("A_TYPE", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
                cmdUpdateAccommodation.Parameters.Add("A_ADDRESS", OracleDbType.Varchar2).Value = objEntityAcco.AccoAddress;
                cmdUpdateAccommodation.Parameters.Add("A_STATUS", OracleDbType.Int32).Value = objEntityAcco.Status_id;
                cmdUpdateAccommodation.Parameters.Add("A_HVMESS", OracleDbType.Int32).Value = objEntityAcco.HavMessId;
                cmdUpdateAccommodation.Parameters.Add("A_CORD", OracleDbType.Int32).Value = objEntityAcco.CordinatorId;
                cmdUpdateAccommodation.Parameters.Add("A_NOSBSCRB", OracleDbType.Int32).Value = objEntityAcco.No_of_Sbscriber;
                cmdUpdateAccommodation.Parameters.Add("A_NOFLR", OracleDbType.Int32).Value = objEntityAcco.No_Of_Floor;
                cmdUpdateAccommodation.Parameters.Add("A_LOCTN", OracleDbType.Varchar2).Value = objEntityAcco.Location;
                cmdUpdateAccommodation.Parameters.Add("A_UPDUSERID", OracleDbType.Int32).Value = objEntityAcco.User_Id;
                cmdUpdateAccommodation.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdUpdateAccommodation.Parameters.Add("A_BUS", OracleDbType.Varchar2).Value = objEntityAcco.Bus;
                clsDataLayer.ExecuteNonQuery(cmdUpdateAccommodation);
            }
        }
        // This Method checks Accommodation name in the database for duplication.
        public string CheckAccommodationName(clsEntityAccommodation objEntityAcco)
        {

            string strQueryCheckAccoName = "ACCOMMODATION.SP_CHECK_ACCOMMODATION_NAME";
            OracleCommand cmdCheckAccoName = new OracleCommand();
            cmdCheckAccoName.CommandText = strQueryCheckAccoName;
            cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
            cmdCheckAccoName.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
            cmdCheckAccoName.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objEntityAcco.AccoName;
            cmdCheckAccoName.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdCheckAccoName.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdCheckAccoName.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
            string strReturn = cmdCheckAccoName.Parameters["A_COUNT"].Value.ToString();
            cmdCheckAccoName.Dispose();
            return strReturn;
        }
        //Method for cancel Accommodation
        public void CancelAccommodation(clsEntityAccommodation objEntityAcco)
        {
            string strQueryCancelAccommodation = "ACCOMMODATION.SP_CANCEL_ACCOMMODATION";
            using (OracleCommand cmdCancelAccommodation = new OracleCommand())
            {
                cmdCancelAccommodation.CommandText = strQueryCancelAccommodation;
                cmdCancelAccommodation.CommandType = CommandType.StoredProcedure;
                cmdCancelAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                cmdCancelAccommodation.Parameters.Add("A_USERID", OracleDbType.Int32).Value = objEntityAcco.User_Id;
                cmdCancelAccommodation.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelAccommodation.Parameters.Add("A_REASON", OracleDbType.Varchar2).Value = objEntityAcco.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelAccommodation);
            }
        }


        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadAccommodationById(clsEntityAccommodation objEntityAcco)
        {
            string strQueryReadAccommodation = "ACCOMMODATION.SP_READ_ACCOMMODATION_BY_ID";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
            cmdReadAccommodation.Parameters.Add(" A_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        // This Method will fetch ACCOMODATION list
        public DataTable ReadAccommodationList(clsEntityAccommodation objEntityAcco)
        {
            string strQueryReadList = "ACCOMMODATION.SP_READ_ACCOMMODATION_LIST";
            OracleCommand cmdReadList = new OracleCommand();
            cmdReadList.CommandText = strQueryReadList;
            cmdReadList.CommandType = CommandType.StoredProcedure;
            cmdReadList.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadList.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadList.Parameters.Add("A_OPTION", OracleDbType.Int32).Value = objEntityAcco.Status_id;
            cmdReadList.Parameters.Add("A_ACCMDTN_TYPE", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
            cmdReadList.Parameters.Add("A_CANCEL", OracleDbType.Int32).Value = objEntityAcco.CancelStatus;

            cmdReadList.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadList);
            return dtList;
        }
        // This Method will fetch accommmodation Type for dropdown
        public DataTable ReadAccommodationType(clsEntityAccommodation objEntityAcco)
        {
            string strQueryAccmdtnType = "ACCOMMODATION.SP_READ_ACCMDTN_CAT";
            using (OracleCommand cmdAccmdtnType = new OracleCommand())
            {
                cmdAccmdtnType.CommandText = strQueryAccmdtnType;
                cmdAccmdtnType.CommandType = CommandType.StoredProcedure;
                cmdAccmdtnType.Parameters.Add("AT_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdAccmdtnType);
                return dtResultSet;
            }
        }
        // This Method will fetch accommmodation CATEGORY DETAIL
        public DataTable ReadAcmdtnDetailByid(clsEntityAccommodation objEntityAcco)
        {
            string strQueryAccmdtnType = "ACCOMMODATION.SP_READ_ACCMDTN_CAT_DTL_BYID";
            using (OracleCommand cmdAccmdtnType = new OracleCommand())
            {
                cmdAccmdtnType.CommandText = strQueryAccmdtnType;
                cmdAccmdtnType.CommandType = CommandType.StoredProcedure;
                cmdAccmdtnType.Parameters.Add("A_ACCMDTN_CAT", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
                cmdAccmdtnType.Parameters.Add("AT_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdAccmdtnType);
                return dtResultSet;
            }
        }
        //status change Accomodation
        public void StatusChangeAccomodation(clsEntityAccommodation objEntityAcco)
        {
            string strQueryCancelAccomodation = "ACCOMMODATION.SP_STATUS_CH_ACC_MSTR";
            using (OracleCommand cmdCancelAccomodation = new OracleCommand())
            {
                cmdCancelAccomodation.CommandText = strQueryCancelAccomodation;
                cmdCancelAccomodation.CommandType = CommandType.StoredProcedure;
                cmdCancelAccomodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                cmdCancelAccomodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
                cmdCancelAccomodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdCancelAccomodation);
            }
        }
        //Method for Recall Cancelled Accommodation  from Accommodation  master table so update cancel related fields
        public void Recall_Accommodation(clsEntityAccommodation objEntityAccommodation)
        {
            string strQueryRecallAccmdtn = "ACCOMMODATION.SP_RECALL_ACCMDTN";
            OracleCommand cmdRecallAccmdtn = new OracleCommand();
            cmdRecallAccmdtn.CommandText = strQueryRecallAccmdtn;
            cmdRecallAccmdtn.CommandType = CommandType.StoredProcedure;
            cmdRecallAccmdtn.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAccommodation.AccommodationId;
            cmdRecallAccmdtn.Parameters.Add("A_USERID", OracleDbType.Int32).Value = objEntityAccommodation.User_Id;
            cmdRecallAccmdtn.Parameters.Add("A_DATE", OracleDbType.Date).Value = objEntityAccommodation.Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallAccmdtn);
        }
        //To read employee list from the database
        public DataTable ReadEmployeeList(clsEntityAccommodation objEntityAcco)
        {
            string strQueryAccmdtnEmp = "ACCOMMODATION.SP_READ_EMPLOYEE";
            using (OracleCommand cmdAccmdtnEmp = new OracleCommand())
            {
                cmdAccmdtnEmp.CommandText = strQueryAccmdtnEmp;
                cmdAccmdtnEmp.CommandType = CommandType.StoredProcedure;
                cmdAccmdtnEmp.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
                cmdAccmdtnEmp.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
                cmdAccmdtnEmp.Parameters.Add("AT_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdAccmdtnEmp);
                return dtResultSet;
            }
        }
        //To read SUB CATEGARY DETAIL AGAINST ACCOMODATION from the database
        public DataTable ReadSubCatDetail(clsEntityAccommodation objEntityAcco)
        {
            string strQueryAccmdtnEmp = "ACCOMMODATION.SP_READ_SUBCAT_DTL";
            using (OracleCommand cmdAccmdtnEmp = new OracleCommand())
            {
                cmdAccmdtnEmp.CommandText = strQueryAccmdtnEmp;
                cmdAccmdtnEmp.CommandType = CommandType.StoredProcedure;
                cmdAccmdtnEmp.Parameters.Add("A_ACCID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                cmdAccmdtnEmp.Parameters.Add("A_SUBCAT", OracleDbType.Int32).Value = objEntityAcco.SubcategoryId;
                cmdAccmdtnEmp.Parameters.Add("AT_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdAccmdtnEmp);
                return dtResultSet;
            }
        }
        public void Insert_Sub_Detail(clsEntityAccommodation objEntityAcco, List<clsEntityAccommodation> objEntityAccoAdd, List<clsEntityAccommodation> objEntityAccoEdit, List<clsEntityAccommodation> objEntityAccoDelete)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntityAccommodation objEntityAdd in objEntityAccoAdd)
                    {
                        string strQueryAddVisa = "ACCOMMODATION.SP_INSERT_SUBCAT_DETAIL";
                        using (OracleCommand cmdInsertSub = new OracleCommand(strQueryAddVisa, con))
                        {
                            cmdInsertSub.Transaction = tran;

                            cmdInsertSub.CommandType = CommandType.StoredProcedure;

                            cmdInsertSub.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                            cmdInsertSub.Parameters.Add("P_TYPID", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
                            cmdInsertSub.Parameters.Add("P_SUBID", OracleDbType.Int32).Value = objEntityAdd.SubcategoryId;
                            cmdInsertSub.Parameters.Add("P_FLR", OracleDbType.Int32).Value = objEntityAdd.FloorNo;
                            cmdInsertSub.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityAdd.FloorName;
                            cmdInsertSub.ExecuteNonQuery();

                        }
                    }
                    foreach (clsEntityAccommodation objEntityEdit in objEntityAccoEdit)
                    {
                        string strQueryAddEmp = "ACCOMMODATION.SP_UPDATE_SUBCAT_DETAIL";
                        using (OracleCommand cmdEditSub = new OracleCommand(strQueryAddEmp, con))
                        {
                            cmdEditSub.Transaction = tran;

                            cmdEditSub.CommandType = CommandType.StoredProcedure;
                            cmdEditSub.Parameters.Add("P_SUBDTLID", OracleDbType.Int32).Value = objEntityEdit.SubcategoryDetailId;
                            cmdEditSub.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityAcco.AccommodationId;
                            cmdEditSub.Parameters.Add("P_TYPID", OracleDbType.Int32).Value = objEntityAcco.AccommodationType;
                            cmdEditSub.Parameters.Add("P_SUBID", OracleDbType.Int32).Value = objEntityEdit.SubcategoryId;
                            cmdEditSub.Parameters.Add("P_FLR", OracleDbType.Int32).Value = objEntityEdit.FloorNo;
                            cmdEditSub.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityEdit.FloorName;
                            cmdEditSub.ExecuteNonQuery();

                        }
                    }
                    foreach (clsEntityAccommodation objEntityDel in objEntityAccoDelete)
                    {
                        string strQueryAddEmp = "ACCOMMODATION.SP_DELETE_SUBCAT_DETAIL";
                        using (OracleCommand cmdEditSub = new OracleCommand(strQueryAddEmp, con))
                        {
                            cmdEditSub.Transaction = tran;

                            cmdEditSub.CommandType = CommandType.StoredProcedure;
                            cmdEditSub.Parameters.Add("P_SUBDTLID", OracleDbType.Int32).Value = objEntityDel.SubcategoryDetailId;
                            cmdEditSub.ExecuteNonQuery();

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


        public DataTable ReadBusinessUnits(clsEntityAccommodation objEntityAcco)
        {
            string strQueryReadList = "ACCOMMODATION.SP_READ_BUS_UNITS";
            OracleCommand cmdReadList = new OracleCommand();
            cmdReadList.CommandText = strQueryReadList;
            cmdReadList.CommandType = CommandType.StoredProcedure;
            cmdReadList.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadList.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadList.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadList);
            return dtList;
        }





    }

}
