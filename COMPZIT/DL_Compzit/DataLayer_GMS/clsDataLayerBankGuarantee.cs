
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
    public class clsDataLayerBankGuarantee
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetCH projects
        public DataTable GuaranteeMode(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GUARANT_MODE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable GuaranteeModeClient(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GUARANT_MODELIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadSubContract(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_SUB_CONTRACT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadBankLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_BANK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadCurrency(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CURRENCY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadEmployee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_EMPLOYEE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadEmployeeData(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_EMPLOYEE_BY_ID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_EMPLYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.EmployeId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadcusAddress(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CUS_ADDRESS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_CUSID", OracleDbType.Int32).Value = objEntityBnkGuarnte.SubContractId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public void AddBankGuarantee(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_INS_BANKGUARNTY_DETAILS";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.NextIdForRqst;
                cmdAddRequest.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.RefNumber;
                cmdAddRequest.Parameters.Add("B_CATAGRY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuarCatgryId;
                cmdAddRequest.Parameters.Add("B_METHOD", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Guarantee_Method;
                if (ObjEntityBnkGurnt.Customer != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Customer;
                }
                //else {
                //    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = null;
                //}
                else if (ObjEntityBnkGurnt.Contrctr != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Contrctr;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = null;
                }
                cmdAddRequest.Parameters.Add("B_CURRNY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Currency;
                cmdAddRequest.Parameters.Add("B_AMOUNT", OracleDbType.Decimal).Value = ObjEntityBnkGurnt.Amount;
                cmdAddRequest.Parameters.Add("GURNT_NO", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.GuaranteeNo;
                if (ObjEntityBnkGurnt.ProjectId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ProjectId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = DBNull.Value;
                }
                cmdAddRequest.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.BankId;
                cmdAddRequest.Parameters.Add("B_GURN_TYP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuarTypeId;
                cmdAddRequest.Parameters.Add("B_OPNG_DATE", OracleDbType.Date).Value = ObjEntityBnkGurnt.OpenDate;
                if (ObjEntityBnkGurnt.OwnershipEmply == 0)
                {
                    cmdAddRequest.Parameters.Add("B_OWNERSHIP", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_OWNERSHIP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.OwnershipEmply;

                }
                cmdAddRequest.Parameters.Add("B_ADDRS", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Address;
                if (ObjEntityBnkGurnt.SubContractId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CONTR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.SubContractId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CONTR", OracleDbType.Int32).Value = null;
                }

                if (ObjEntityBnkGurnt.ExpireDate != DateTime.MinValue)
                {
                    cmdAddRequest.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = ObjEntityBnkGurnt.ExpireDate;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = null;
                }
                if (ObjEntityBnkGurnt.GuaranteeNoDays != 0)
                {
                    cmdAddRequest.Parameters.Add("B_NO_DAYS", OracleDbType.Int64).Value = ObjEntityBnkGurnt.GuaranteeNoDays;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = null;
                }
                if (ObjEntityBnkGurnt.Subject != "")
                {
                    cmdAddRequest.Parameters.Add("B_SUBJCT", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Subject;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_SUBJCT", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.Description != "")
                {
                    cmdAddRequest.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Description;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.EmployeName != "")
                {
                    cmdAddRequest.Parameters.Add("B_EMPLYID", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.EmployeName;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EMPLYID", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.Email != "")
                {
                    cmdAddRequest.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Email;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.ContactPersnUsrId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CONTPERUSRID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ContactPersnUsrId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CONTPERUSRID", OracleDbType.Int32).Value = null;
                }


                cmdAddRequest.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Organisation_Id;
                cmdAddRequest.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.CorpOffice_Id;
                cmdAddRequest.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                if (ObjEntityBnkGurnt.Remarks != "")
                {
                    cmdAddRequest.Parameters.Add("B_REMRKS", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Remarks;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_REMRKS", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.ReqstGrntId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_REQSTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ReqstGrntId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_REQSTID", OracleDbType.Int32).Value = null;
                }

                cmdAddRequest.Parameters.Add("B_DNT_NTFY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.DontNotify;
                cmdAddRequest.Parameters.Add("B_NTF_TEMP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.NotTempId;
                cmdAddRequest.Parameters.Add("B_PRJCTNAME", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.ProjectName;
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public DataTable Read_Attachment(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_ATTACHMNT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            // cmdReadBankGuarnt.Parameters.Add("B_CUSID", OracleDbType.Int32).Value = objEntityBnkGuarnte.SubContractId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public void Add_Pictures(clsEntityLayerBankGuarantee objEntityBnkGuarnte, List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuranteeAtchmntDtlList)
        {

            foreach (clsEntityLayerGuaranteeAttachments objEntityGurnteeattch in objEntityLayerGuranteeAtchmntDtlList)
            {
                string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_ADD_ATTACHMENT";
                using (OracleCommand cmdReadBankGuarnt = new OracleCommand())
                {

                    cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
                    cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

                    cmdReadBankGuarnt.Parameters.Add("B_GUARANTID_ID", OracleDbType.Int32).Value = objEntityGurnteeattch.GuarenteeId;
                    cmdReadBankGuarnt.Parameters.Add("B_FILE_NAME", OracleDbType.Varchar2).Value = objEntityGurnteeattch.FileName;
                    cmdReadBankGuarnt.Parameters.Add("B_ACTUAL_FILE_NAME", OracleDbType.Varchar2).Value = objEntityGurnteeattch.ActualFileName;
                    cmdReadBankGuarnt.Parameters.Add("B_SERIAL_NO", OracleDbType.Int32).Value = objEntityGurnteeattch.AttchmntSlNumber;
                    cmdReadBankGuarnt.Parameters.Add("B_LINK", OracleDbType.Varchar2).Value = objEntityGurnteeattch.CaptionName;

                    clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
                }

            }

        }

        public void Delete_Pictures(clsEntityLayerBankGuarantee objEntityBnkGuarnte, List<clsEntityLayerGuaranteeAttachments> objEntityGurntattchAtchmntDtlListDel)
        {

            foreach (clsEntityLayerGuaranteeAttachments objEntityGurntAttchmnt in objEntityGurntattchAtchmntDtlListDel)
            {
                string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_DEL_ATTACHMENT";
                using (OracleCommand cmdReadBankGuarnt = new OracleCommand())
                {

                    cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
                    cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
                    cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityGurntAttchmnt.PictureId;
                    clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
                }

            }



        }
        public DataTable GuaranteeModeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GUARANT_MODE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadSuplierLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_SUPLIERlOAD";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadCustomerLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CUSTOMERlOAD";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadRequestGuaranteeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadCntrctList = "BANK_GUARANTEE.SP_READ_GUARNTELIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadCntrctList;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_SUPCUSSRCH", OracleDbType.Int32).Value = objEntityBnkGuarnte.CusSupSrch;
            cmdReadBankGuarnt.Parameters.Add("B_SUPORCUSTMR", OracleDbType.Int32).Value = objEntityBnkGuarnte.SuplOrClient;
            if (objEntityBnkGuarnte.OpenDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.OpenDate;

            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = null;
                //Convert.ToDateTime( "09 - 02 - 17");

            }
            //cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.OpenDate;
            if (objEntityBnkGuarnte.ToDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ToDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Date).Value = null;
            }
            if (objEntityBnkGuarnte.FromDashboard ==1 )
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 1;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpiryFromDate;

            }
           else if (objEntityBnkGuarnte.FromDashboard == 2)
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 2;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 0;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }
   



            //cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.ToDate;
            cmdReadBankGuarnt.Parameters.Add("B_GURTYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarTypeId;
            cmdReadBankGuarnt.Parameters.Add("B_GUARMODE", OracleDbType.Int32).Value = objEntityBnkGuarnte.Guarantee_Method;
            cmdReadBankGuarnt.Parameters.Add("B_BINDG", OracleDbType.Int32).Value = objEntityBnkGuarnte.Biding;
            cmdReadBankGuarnt.Parameters.Add("B_AWARDED", OracleDbType.Int32).Value = objEntityBnkGuarnte.Awarded;
            cmdReadBankGuarnt.Parameters.Add("B_CUSSUPLY", OracleDbType.Int32).Value = objEntityBnkGuarnte.CusSuply;
            if (objEntityBnkGuarnte.ExpireDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpireDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = null;
            }
            // cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.ExpireDate;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityBnkGuarnte.Cancel_Status;
            cmdReadBankGuarnt.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityBnkGuarnte.BankId;
            cmdReadBankGuarnt.Parameters.Add("B_SRCHSTATS", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuartStsSrch;
            cmdReadBankGuarnt.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategoryList;
        }
        public DataTable ReadGuranteeById(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GURNT_BYID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable Read_Picture(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_ATTACHMNT_BYID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public void UpdateBankGuarantee(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_UPD_BANKGUARNTY_DETAILS";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                cmdAddRequest.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.RefNumber;
                cmdAddRequest.Parameters.Add("B_CATAGRY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuarCatgryId;
                cmdAddRequest.Parameters.Add("B_METHOD", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Guarantee_Method;
                if (ObjEntityBnkGurnt.Customer != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Customer;
                }
                //else {
                //    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = null;
                //}
                else if (ObjEntityBnkGurnt.Contrctr != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Contrctr;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CUSMR", OracleDbType.Int32).Value = null;
                }
                cmdAddRequest.Parameters.Add("B_CURRNY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Currency;
                cmdAddRequest.Parameters.Add("B_AMOUNT", OracleDbType.Decimal).Value = ObjEntityBnkGurnt.Amount;
                cmdAddRequest.Parameters.Add("GURNT_NO", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.GuaranteeNo;
                if (ObjEntityBnkGurnt.ProjectId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ProjectId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_PROJCTID", OracleDbType.Int32).Value = DBNull.Value;
                }
                cmdAddRequest.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.BankId;
                cmdAddRequest.Parameters.Add("B_GURN_TYP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuarTypeId;
                cmdAddRequest.Parameters.Add("B_OPNG_DATE", OracleDbType.Date).Value = ObjEntityBnkGurnt.OpenDate;
                if (ObjEntityBnkGurnt.OwnershipEmply == 0)
                {
                    cmdAddRequest.Parameters.Add("B_OWNERSHIP", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_OWNERSHIP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.OwnershipEmply;

                }
                cmdAddRequest.Parameters.Add("B_ADDRS", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Address;
                if (ObjEntityBnkGurnt.SubContractId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CONTR", OracleDbType.Int32).Value = ObjEntityBnkGurnt.SubContractId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CONTR", OracleDbType.Int32).Value = null;
                }

                if (ObjEntityBnkGurnt.ExpireDate != DateTime.MinValue)
                {
                    cmdAddRequest.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = ObjEntityBnkGurnt.ExpireDate;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EXPRE_DATE", OracleDbType.Date).Value = null;
                }
                if (ObjEntityBnkGurnt.GuaranteeNoDays != 0)
                {
                    cmdAddRequest.Parameters.Add("B_NO_DAYS", OracleDbType.Int64).Value = ObjEntityBnkGurnt.GuaranteeNoDays;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_NO_DAYS", OracleDbType.Int32).Value = null;
                }
                if (ObjEntityBnkGurnt.Subject != "")
                {
                    cmdAddRequest.Parameters.Add("B_SUBJCT", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Subject;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_SUBJCT", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.Description != "")
                {
                    cmdAddRequest.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Description;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_DESCPN", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.EmployeName != "")
                {
                    cmdAddRequest.Parameters.Add("B_EMPLYID", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.EmployeName;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EMPLYID", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.Email != "")
                {
                    cmdAddRequest.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Email;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_EMAIL", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.ContactPersnUsrId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_CONTPERUSRID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ContactPersnUsrId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_CONTPERUSRID", OracleDbType.Int32).Value = null;
                }


                cmdAddRequest.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.Organisation_Id;
                cmdAddRequest.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.CorpOffice_Id;
                cmdAddRequest.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdAddRequest.Parameters.Add("B_UPDATE_DTE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                if (ObjEntityBnkGurnt.Remarks != "")
                {
                    cmdAddRequest.Parameters.Add("B_REMRKS", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Remarks;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_REMRKS", OracleDbType.Varchar2).Value = null;
                }
                if (ObjEntityBnkGurnt.ReqstGrntId != 0)
                {
                    cmdAddRequest.Parameters.Add("B_REQSTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.ReqstGrntId;
                }
                else
                {
                    cmdAddRequest.Parameters.Add("B_REQSTID", OracleDbType.Int32).Value = null;
                }
                cmdAddRequest.Parameters.Add("B_DNT_NTFY", OracleDbType.Int32).Value = ObjEntityBnkGurnt.DontNotify;
                cmdAddRequest.Parameters.Add("B_NTF_TEMP", OracleDbType.Int32).Value = ObjEntityBnkGurnt.NotTempId;
                cmdAddRequest.Parameters.Add("B_PRJCTNAME", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.ProjectName;
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public void CancelRequest(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GURNT_CANCEL";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdCancelRequest.Parameters.Add("B_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelRequest.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }
        public void ReCallRequest(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GURNT_RECAL";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdCancelRequest.Parameters.Add("B_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }

        public string ChckDuplGurntNo(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GURNTNO_CHK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("GURNT_NO", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.GuaranteeNo;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }


        public void ConfirmBankGuarantee(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_CONFM_BANKGUARNTY_DETAILS";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                //  cmdAddRequest.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.RefNumber;
                cmdAddRequest.Parameters.Add("B_STATSNUM", OracleDbType.Int32).Value = ObjEntityBnkGurnt.StatusIdCheck;
                cmdAddRequest.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdAddRequest.Parameters.Add("B_UPDATE_DTE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public void ReOpenRequest(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_REOPEN_BANKGUARNTY_DETAILS";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                //  cmdAddRequest.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.RefNumber;
                cmdAddRequest.Parameters.Add("B_STATSNUM", OracleDbType.Int32).Value = ObjEntityBnkGurnt.StatusIdCheck;
                cmdAddRequest.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdAddRequest.Parameters.Add("B_UPDATE_DTE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }


        public void CloseRequest(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GURNT_CLOSE";
            using (OracleCommand cmdCancelRequest = new OracleCommand())
            {
                cmdCancelRequest.CommandText = strQueryReadBankGuarnt;
                cmdCancelRequest.CommandType = CommandType.StoredProcedure;
                cmdCancelRequest.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                cmdCancelRequest.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdCancelRequest.Parameters.Add("B_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelRequest.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelRequest);
            }
        }


        public void RenewBankGuarantee(clsEntityLayerBankGuarantee ObjEntityBnkGurnt)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_RENEW_BANKGUARNTY";
            using (OracleCommand cmdAddRequest = new OracleCommand())
            {
                cmdAddRequest.CommandText = strQueryReadBankGuarnt;
                cmdAddRequest.CommandType = CommandType.StoredProcedure;
                cmdAddRequest.Parameters.Add("B_ID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.GuaranteeId;
                //  cmdAddRequest.Parameters.Add("B_REFNUM", OracleDbType.Varchar2).Value = ObjEntityBnkGurnt.RefNumber;
                cmdAddRequest.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = ObjEntityBnkGurnt.User_Id;
                cmdAddRequest.Parameters.Add("B_UPDATE_DTE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddRequest);
            }
        }

        public DataTable ChkConfirmBankGuarantee(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_CHCK_GURNTSTATUS_BYID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
      

        public DataTable ReadDefualtCurrency(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READDEFLT_CURRENCY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadRequesClienttGuaranteeList(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadCntrctList = "BANK_GUARANTEE.SP_READ_GUARNTECLIENTLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadCntrctList;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            // cmdReadBankGuarnt.Parameters.Add("B_GURTYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarTypeId;
            cmdReadBankGuarnt.Parameters.Add("B_GUARMODE", OracleDbType.Int32).Value = objEntityBnkGuarnte.Guarantee_Method;

            cmdReadBankGuarnt.Parameters.Add("B_CUSSUPLY", OracleDbType.Int32).Value = objEntityBnkGuarnte.CusSuply;
            cmdReadBankGuarnt.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            //cmdReadBankGuarnt.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityBnkGuarnte.Cancel_Status;

            //cmdReadBankGuarnt.Parameters.Add("B_SRCHSTATS", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuartStsSrch;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategoryList;
        }

        public DataTable ReadRequestByID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CLIENT_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public string ChckDupReqstId(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_REQSTID_CHK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ReqstGrntId;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }

        public void UpdateReqstGuarnteStats(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_REQST_STSCHNG_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ReqstGrntId;
            //cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
        }

        public void UpdateReqstGuarnteStatsonReopn(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_REQST_STSCHNG_ONREPN";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ReqstGrntId;
            // cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
        }


        //-------for notification template------------

        public DataTable ReadNotifyTemplates(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadTemp = "BANK_GUARANTEE.SP_READ_NOT_TEMPLATES";
            OracleCommand cmdReadTemp = new OracleCommand();
            cmdReadTemp.CommandText = strQueryReadTemp;
            cmdReadTemp.CommandType = CommandType.StoredProcedure;
            cmdReadTemp.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadTemp.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadTemp.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadTemp);
            return dtCategory;
        }
        public DataTable ReadDefaultNotifyTemplates(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadTemp = "BANK_GUARANTEE.SP_READ_DFLT_NOT_TEMPLATES";
            OracleCommand cmdReadTemp = new OracleCommand();
            cmdReadTemp.CommandText = strQueryReadTemp;
            cmdReadTemp.CommandType = CommandType.StoredProcedure;
            cmdReadTemp.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadTemp.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadTemp.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadTemp);
            return dtCategory;
        }



        // This Method adds template details to the table
        public void AddTemplateDetail(clsEntityLayerBankGuarantee objEntityBnkGuarnte, BnkGrntyTemplateDetail objEntityNotTempDetail, List<BnkGrntyTemplateAlert> objEntityTempAlertList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddTemp = "BANK_GUARANTEE.SP_INS_TEMPLATE_DETAIL";
                    using (OracleCommand cmdAddTemp = new OracleCommand(strQueryAddTemp, con))
                    {
                        cmdAddTemp.CommandType = CommandType.StoredProcedure;

                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                        objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BANK_GRNTY_TEMPLT_DTL);
                        objCommon.CorporateID = objEntityBnkGuarnte.CorpOffice_Id;
                        string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                        objEntityNotTempDetail.TempDetailId = Convert.ToInt32(strNextValue);

                        cmdAddTemp.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
                        cmdAddTemp.Parameters.Add("T_GID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
                        cmdAddTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = 1;
                        cmdAddTemp.Parameters.Add("T_PERIOD", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetPeriod;
                        cmdAddTemp.Parameters.Add("T_DUR_COUNT", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailPeriodCount;
                        cmdAddTemp.Parameters.Add("T_DASH", OracleDbType.Int32).Value = objEntityNotTempDetail.IsDashBoard;
                        cmdAddTemp.Parameters.Add("T_MAIL", OracleDbType.Int32).Value = objEntityNotTempDetail.IsEmail;

                        clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                    }

                    foreach (BnkGrntyTemplateAlert objEntityTempAlert in objEntityTempAlertList)
                    {
                        string strQueryAddTempAlert = "BANK_GUARANTEE.SP_INS_TEMPLATE_ALERT";
                        using (OracleCommand cmdAddTempAlert = new OracleCommand(strQueryAddTempAlert, con))
                        {
                            cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                            cmdAddTempAlert.Parameters.Add("T_GID", OracleDbType.Int32).Value = objEntityBnkGuarnte.NextIdForRqst;
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
                            cmdAddTempAlert.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
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

        // This Method will fetCH template DEATILS table BY ID
        public DataTable ReadTemplateDetailById(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadNotTemp = "BANK_GUARANTEE.SP_READ_TEMPLATE_DETAIL_BY_ID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("T_GID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadNotTemp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }

        //this table will fetch template alert table datas
        public DataTable ReadTemplateAlertById(BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            string strQueryReadNotTemp = "BANK_GUARANTEE.SP_READ_TEMPLATE_ALERT_BY_ID";
            OracleCommand cmdReadNotTemp = new OracleCommand();
            cmdReadNotTemp.CommandText = strQueryReadNotTemp;
            cmdReadNotTemp.CommandType = CommandType.StoredProcedure;
            cmdReadNotTemp.Parameters.Add("T_DET_ID", OracleDbType.Int32).Value = objEntityNotTempDetail.TempDetailId;
            cmdReadNotTemp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplate = new DataTable();
            dtTemplate = clsDataLayer.ExecuteReader(cmdReadNotTemp);
            return dtTemplate;
        }




        // This Method Update template detail table
        public void UpdateNotifyTemplateDetail(BnkGrntyTemplateDetail objEntityNotTempDetail)
        {

            string strQueryUpdTemp = "BANK_GUARANTEE.SP_UPD_TEMPLATE_DETAIL";
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
        public void UpdateNotifyTemplateAlert(BnkGrntyTemplateAlert objEntityTempAlert, BnkGrntyTemplateDetail objEntityNotTempDetail)
        {

            string strQueryAddTemp = "BANK_GUARANTEE.SP_UPD_TEMPLATE_ALERT";
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
        public void DeleteTemplateAlert(List<BnkGrntyTemplateAlert> objEntityTempAlertList)
        {
            foreach (BnkGrntyTemplateAlert objEntityNotTemp in objEntityTempAlertList)
            {
                string strQueryAddTemp = "BANK_GUARANTEE.SP_DEL_TEMPLATE_ALERT";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_AL_ID", OracleDbType.Int32).Value = objEntityNotTemp.TemplateAlertId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
            }
        }

        // This Method DELETE DETAIL DATA details OF the table
        public void DeleteTemplateDetByGr(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
           
                string strQueryAddTemp = "BANK_GUARANTEE.SP_DEL_TEMPLATE_DTL_BY_GR";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_GR_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
            
        }
        // This Method DELETE ALERT details OF the table
        public void DeleteTemplateAlertByGr(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
                string strQueryAddTemp = "BANK_GUARANTEE.SP_DEL_TEMPLATE_ALERT_BY_GR";
                using (OracleCommand cmdAddTemp = new OracleCommand())
                {
                    cmdAddTemp.CommandText = strQueryAddTemp;
                    cmdAddTemp.CommandType = CommandType.StoredProcedure;
                    cmdAddTemp.Parameters.Add("T_GR_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
                    clsDataLayer.ExecuteNonQuery(cmdAddTemp);
                }
            
        }

        // This Method adds job category details to the table
        public void AddTemplateAlert(List<BnkGrntyTemplateAlert> objEntityTempAlertList, clsEntityLayerBankGuarantee objEntityBnkGuarnte, BnkGrntyTemplateDetail objEntityNotTempDetail)
        {
            foreach (BnkGrntyTemplateAlert objEntityTempAlert in objEntityTempAlertList)
            {
                string strQueryAddTemp = "BANK_GUARANTEE.SP_INS_TEMPLATE_ALERT";
                using (OracleCommand cmdAddTempAlert = new OracleCommand())
                {
                    cmdAddTempAlert.CommandText = strQueryAddTemp;
                    cmdAddTempAlert.CommandType = CommandType.StoredProcedure;
                    cmdAddTempAlert.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
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
                    cmdAddTempAlert.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdAddTempAlert);
                }
            }
        }
        public string ChkCatagory(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_CHK_CATAGRY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("B_CATGRY_ID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarCatgryId;

            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }

        public void MailStatusChange(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_REQST_MAILSTS_CHNG";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;

            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            //cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteNonQuery(cmdReadBankGuarnt);
        }


        public string ChckDuplRFQIdChek(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_RFQDUP_CHK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("RFQ_ID", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.ReqstGrntId;
            cmdReadBankGuarnt.Parameters.Add("GURNT_NO", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.GuaranteeNo;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadBankGuarnt);
            string strReturn = cmdReadBankGuarnt.Parameters["B_OUT"].Value.ToString();
            cmdReadBankGuarnt.Dispose();
            return strReturn;
        }
        //To load  Gtee Type DDL for Client
        public DataTable GteeTypeClient(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_GTEE_TYPE_LIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        //READ PROJECTS BY GTEE TYPE ID
        public DataTable ReadProjectGteeTypeID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_PROJECTS_BY_GTEE_TYPE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("C_GUANTCATID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarCatgryId;
            cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        //READ Customer Address BY Customer ID
        public DataTable ReadCustomerAddrByID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CSTMR_ADDR_BY_ID";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("C_CSTMRID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Customer;
            cmdReadBankGuarnt.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        //READ Customer Address, Customer ID BY PROJECT ID
        public DataTable ReadCustomerDtlByPrjID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadCustomerDtl = "BANK_GUARANTEE.SP_READ_CSTMR_DTL_BY_PRJ_ID";
            OracleCommand cmdReadCustomerDtl = new OracleCommand();
            cmdReadCustomerDtl.CommandText = strQueryReadCustomerDtl;
            cmdReadCustomerDtl.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerDtl.Parameters.Add("C_PRJID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ProjectId;
            cmdReadCustomerDtl.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerDtl = new DataTable();
            dtCustomerDtl = clsDataLayer.ExecuteReader(cmdReadCustomerDtl);
            return dtCustomerDtl;
        }
        //READ ALTERTS BY GTEE ID
        public DataTable ReadAlertsByGteeID(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_TMPLT_ALRT_BY_GTEE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("C_GUANTCATID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }



        public DataTable ReadRequestGuaranteeList1(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadCntrctList = "BANK_GUARANTEE.SP_READ_GUARNTELIST_ALL";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadCntrctList;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("B_SUPCUSSRCH", OracleDbType.Int32).Value = objEntityBnkGuarnte.CusSupSrch;
            cmdReadBankGuarnt.Parameters.Add("B_SUPORCUSTMR", OracleDbType.Int32).Value = objEntityBnkGuarnte.SuplOrClient;
            if (objEntityBnkGuarnte.OpenDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.OpenDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Date).Value = null;
                //Convert.ToDateTime( "09 - 02 - 17");
            }
            //cmdReadBankGuarnt.Parameters.Add("B_FRMDATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.OpenDate;
            if (objEntityBnkGuarnte.ToDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ToDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Date).Value = null;
            }
            if (objEntityBnkGuarnte.FromDashboard == 1)
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 1;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }
            else if (objEntityBnkGuarnte.FromDashboard == 2)
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 2;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }
            else if (objEntityBnkGuarnte.FromDashboard == 4)
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 4;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_DASHBOARD", OracleDbType.Int32).Value = 0;
                cmdReadBankGuarnt.Parameters.Add("B_FROMEXPRYDATE", OracleDbType.Date).Value = null;

            }




            //cmdReadBankGuarnt.Parameters.Add("B_TODATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.ToDate;
            cmdReadBankGuarnt.Parameters.Add("B_GURTYP", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarTypeId;
            cmdReadBankGuarnt.Parameters.Add("B_GUARMODE", OracleDbType.Int32).Value = objEntityBnkGuarnte.Guarantee_Method;
            cmdReadBankGuarnt.Parameters.Add("B_BINDG", OracleDbType.Int32).Value = objEntityBnkGuarnte.Biding;
            cmdReadBankGuarnt.Parameters.Add("B_AWARDED", OracleDbType.Int32).Value = objEntityBnkGuarnte.Awarded;
            cmdReadBankGuarnt.Parameters.Add("B_CUSSUPLY", OracleDbType.Int32).Value = objEntityBnkGuarnte.CusSuply;
            if (objEntityBnkGuarnte.ExpireDate != DateTime.MinValue)
            {
                cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = objEntityBnkGuarnte.ExpireDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Date).Value = null;
            }
            // cmdReadBankGuarnt.Parameters.Add("B_EXPRDATE", OracleDbType.Int32).Value = objEntityBnkGuarnte.ExpireDate;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityBnkGuarnte.Cancel_Status;
            cmdReadBankGuarnt.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityBnkGuarnte.BankId;
            cmdReadBankGuarnt.Parameters.Add("B_SRCHSTATS", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuartStsSrch;
            cmdReadBankGuarnt.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_INSRNC_PRVDR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceProvider;
            cmdReadBankGuarnt.Parameters.Add("B_POLCY_SEARCH", OracleDbType.Int32).Value = objEntityBnkGuarnte.PolicyType;
            cmdReadBankGuarnt.Parameters.Add("B_CRNCYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Currency;
            cmdReadBankGuarnt.Parameters.Add("B_POLICY_NUM", OracleDbType.Int32).Value = objEntityBnkGuarnte.PolicyNumber;
            cmdReadBankGuarnt.Parameters.Add("B_INSRNC_TYPMSTR", OracleDbType.Int32).Value = objEntityBnkGuarnte.InsuranceTypMstr;

            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategoryList;
        }

        public DataTable ReadPolicyNumLoad(clsEntityLayerBankGuarantee objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_POLICYNMBR";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_POLCY_SEARCH", OracleDbType.Int32).Value = objEntityBnkGuarnte.PolicyType;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

    }
}
