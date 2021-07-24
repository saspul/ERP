using EL_Compzit;
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
    public class clsDataLayerStaffImmigration
    {
        // This Method adds customer details to the customer master table
        public void AddStaffImmigration(clsEntityStaffImmigration objEntityStaffImigrationDtls)
        {
            //fetching next value

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                string strQueryAddStaffImmigration = "STAFF_REGISTRATION.SP_INS_STAFF_VISA_DTLS";
                using (OracleCommand cmdAddStaffImmigration = new OracleCommand(strQueryAddStaffImmigration, con))
                {

                    cmdAddStaffImmigration.CommandType = CommandType.StoredProcedure;
                    //generate next value
                    clsDataLayer objDataLayer = new clsDataLayer();
                    clsEntityCommon objCommon = new clsEntityCommon();
                    //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Immigration);
                    objCommon.CorporateID = objEntityStaffImigrationDtls.CorpId;



                    cmdAddStaffImmigration.Parameters.Add("V_CANDID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CandId;
                    if (objEntityStaffImigrationDtls.intVisaTypeID == 0)
                    {

                        cmdAddStaffImmigration.Parameters.Add("V_VISATYPID", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddStaffImmigration.Parameters.Add("V_VISATYPID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.intVisaTypeID;


                    }
                    cmdAddStaffImmigration.Parameters.Add("V_VISANUM", OracleDbType.Varchar2).Value = objEntityStaffImigrationDtls.VisaNo;

                    if (objEntityStaffImigrationDtls.VisaExpDate == new DateTime())
                    {
                        cmdAddStaffImmigration.Parameters.Add("V_VISAVALIDITY", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddStaffImmigration.Parameters.Add("V_VISAVALIDITY", OracleDbType.Date).Value = objEntityStaffImigrationDtls.VisaExpDate;

                    }


                    cmdAddStaffImmigration.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.OrgId;
                    cmdAddStaffImmigration.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CorpId;
                    cmdAddStaffImmigration.Parameters.Add("V_VISAINSUSRID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.Imig_user_id;
                    cmdAddStaffImmigration.Parameters.Add("V_VISAINSDATE", OracleDbType.Date).Value = objEntityStaffImigrationDtls.UsrInsdate;

                    cmdAddStaffImmigration.Parameters.Add("V_PASSPORTNUM", OracleDbType.Varchar2).Value = objEntityStaffImigrationDtls.PassNo;


                    if (objEntityStaffImigrationDtls.PassExpDate == new DateTime())
                    {
                        cmdAddStaffImmigration.Parameters.Add("V_PASSPORTVALIDITY", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddStaffImmigration.Parameters.Add("V_PASSPORTVALIDITY", OracleDbType.Date).Value = objEntityStaffImigrationDtls.PassExpDate;

                    }
                    cmdAddStaffImmigration.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.Imig_Emp_id;


                    cmdAddStaffImmigration.ExecuteNonQuery();
                }







            }
        }
        //Method for Updating Immigration Details
        public void UpdateImmigration(clsEntityStaffImmigration objEntityStaffImigrationDtls)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                //generate next value
                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();

                string strQueryUpdateImmigration = "STAFF_REGISTRATION.SP_UPD_STAFF_VISA";
                using (OracleCommand cmdAddImmigration = new OracleCommand(strQueryUpdateImmigration, con))
                {
                    cmdAddImmigration.CommandType = CommandType.StoredProcedure;
                     cmdAddImmigration.Parameters.Add("V_CANDID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CandId;
                    if (objEntityStaffImigrationDtls.intVisaTypeID == 0)
                    {

                        cmdAddImmigration.Parameters.Add("V_VISATYPID", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddImmigration.Parameters.Add("V_VISATYPID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.intVisaTypeID;


                    }
                    cmdAddImmigration.Parameters.Add("V_VISANUM", OracleDbType.Varchar2).Value = objEntityStaffImigrationDtls.VisaNo;

                    if (objEntityStaffImigrationDtls.VisaExpDate == new DateTime())
                    {
                        cmdAddImmigration.Parameters.Add("V_VISAVALIDITY", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("V_VISAVALIDITY", OracleDbType.Date).Value = objEntityStaffImigrationDtls.VisaExpDate;

                    }


                    cmdAddImmigration.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.OrgId;
                    cmdAddImmigration.Parameters.Add("V_CORPRTID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CorpId;
                    cmdAddImmigration.Parameters.Add("V_VISAUPDUSRID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.Imig_user_id;
                    cmdAddImmigration.Parameters.Add("V_VISAUPDDATE", OracleDbType.Date).Value = objEntityStaffImigrationDtls.UsrInsdate;

                    cmdAddImmigration.Parameters.Add("V_PASSPORTNUM", OracleDbType.Varchar2).Value = objEntityStaffImigrationDtls.PassNo;


                    if (objEntityStaffImigrationDtls.PassExpDate == new DateTime())
                    {
                        cmdAddImmigration.Parameters.Add("V_PASSPORTVALIDITY", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("V_PASSPORTVALIDITY", OracleDbType.Date).Value = objEntityStaffImigrationDtls.PassExpDate;

                    }
                    cmdAddImmigration.Parameters.Add("V_STAFF_VISA_TYP_ID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.StaffImig_Id;

                    cmdAddImmigration.ExecuteNonQuery();
                }




            }
        }
        //This Method will fetch customer table by ID
        public DataTable ReadStaffImmigrationById(clsEntityStaffImmigration objEntityStaffImigrationDtls)
        {
            string strQueryReadStaffImmigrationById = "STAFF_REGISTRATION.SP_READ_STAFF_VISA_DTLS_BYID";
            OracleCommand cmdReadStaffImmigrationById = new OracleCommand();
            cmdReadStaffImmigrationById.CommandText = strQueryReadStaffImmigrationById;
            cmdReadStaffImmigrationById.CommandType = CommandType.StoredProcedure;
            cmdReadStaffImmigrationById.Parameters.Add("V_VISAID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.StaffImig_Id;

            cmdReadStaffImmigrationById.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.OrgId;
            cmdReadStaffImmigrationById.Parameters.Add("V_CORPRTID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CorpId;
            cmdReadStaffImmigrationById.Parameters.Add("V_USERID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CandId;
           
            cmdReadStaffImmigrationById.Parameters.Add("V_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadStaffImmigrationById);
            return dtCustomer;
        }
        //This Method will fetch customer table
        public DataTable ReadImmigrationList(clsEntityStaffImmigration objEntityStaffImigrationDtls)
        {
            string strQueryReadImmigrationById = "STAFF_REGISTRATION.SP_READ_STAFF_VISA_DTLS";
            OracleCommand cmdReadImmigrationById = new OracleCommand();
            cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
            cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
            cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.OrgId;
            cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CorpId;
            cmdReadImmigrationById.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityStaffImigrationDtls.CandId;
            cmdReadImmigrationById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadImmigrationById);
            return dtCustomer;
        }
        //This Method will CANCEL   by ID
        //public void CancelImmigrationById(clsEntityStaffImmigration objEntityImigrationDtls)
        //{
        //    string strQueryReadImmigrationById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_CAN_IMMIGRATION";
        //    OracleCommand cmdReadImmigrationById = new OracleCommand();
        //    cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
        //    cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
        //    cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
        //    cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
        //    cmdReadImmigrationById.Parameters.Add("C_EMPIMG_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
        //    cmdReadImmigrationById.Parameters.Add("C_CANDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigdate;
        //    cmdReadImmigrationById.Parameters.Add("C_CANUSR_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;

        //    cmdReadImmigrationById.Parameters.Add("C_RSN", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigCancelREASON;

        //    cmdReadImmigrationById.ExecuteNonQuery();
        //  DataTable dtCustomer = new DataTable();
        //  //  dtCustomer = clsDataLayer.ExecuteReader(cmdReadImmigrationById);
        // return dtCustomer;
        //}
        public void CancelImmigrationById(clsEntityStaffImmigration objEntityImigrationDtls)
        {
            string strQueryReadImmigrationById = "STAFF_REGISTRATION.SP_CAN_STAFF_VISA";
            using (OracleCommand cmdReadImmigrationById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadImmigrationById.Connection = con;


                cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
                cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
                cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
                cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
                cmdReadImmigrationById.Parameters.Add("V_VISAID", OracleDbType.Int32).Value = objEntityImigrationDtls.StaffImig_Id;
                cmdReadImmigrationById.Parameters.Add("C_CANDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigdate;
                cmdReadImmigrationById.Parameters.Add("C_CANUSR_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;

                cmdReadImmigrationById.Parameters.Add("C_RSN", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigCancelREASON;

                cmdReadImmigrationById.ExecuteNonQuery();
            }
        }
        //methode for read customer list 
        public DataTable ReadVisa(clsEntityStaffImmigration objEntityImigrationDtls)
        {
            string strQueryReadvisaList = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_VISA_LIST";
            OracleCommand cmdReadvisaList = new OracleCommand();
            cmdReadvisaList.CommandText = strQueryReadvisaList;
            cmdReadvisaList.CommandType = CommandType.StoredProcedure;
            cmdReadvisaList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
            cmdReadvisaList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
            cmdReadvisaList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtvisaList = new DataTable();
            dtvisaList = clsDataLayer.ExecuteReader(cmdReadvisaList);
            return dtvisaList;
        }

        public string Check_DOCNUM(clsEntityStaffImmigration objEntityImigrationDtls)
        {
            string strQueryReadProj = "EMPLOYEE_SPONSOR_IMIGRATION.SP_CHECK_PASSPORT_DTLS";
            OracleCommand cmdReadProj = new OracleCommand();
            cmdReadProj.CommandText = strQueryReadProj;
            cmdReadProj.CommandType = CommandType.StoredProcedure;
         //   cmdReadProj.Parameters.Add("P_NO", OracleDbType.Varchar2).Value = objEntityImigrationDtls.Imig_Doc_No;
///cmdReadProj.Parameters.Add("P_EMPIMG_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
            cmdReadProj.Parameters.Add("P_TYPE_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.ImigDocType_Id;

            cmdReadProj.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadProj);
            string strReturn = cmdReadProj.Parameters["P_OUT"].Value.ToString();
            cmdReadProj.Dispose();
            return strReturn;

        }
    }
}
