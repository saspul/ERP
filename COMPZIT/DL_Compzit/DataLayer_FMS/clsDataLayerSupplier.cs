using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
   public class clsDataLayerSupplier
    {
       public DataTable CheckSupplierCnclSts(clsEntitySupplier objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_CHECK_CNCL_STS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
       public DataTable ReadSupplierDtlsById(clsEntitySupplier objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_READ_SUPPLIER_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
       public DataTable ReadSupplierList(clsEntitySupplier objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_READ_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
            cmdReadPayGrd.Parameters.Add("L_CNCL_STS", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerSts;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
       public void AddSupplier(clsEntitySupplier objEntityEmpSlry, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
       {
           string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_ADD_SUPPLIER";
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlry, con))
                   {
                       cmdReadPayGrd.Transaction = tran;
                       cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                       cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.SupplierName;
                       if (objEntityEmpSlry.CreditLimit != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_LMT", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditLimit;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_LMT", OracleDbType.Decimal).Value = DBNull.Value;
                       }
                       if (objEntityEmpSlry.Days != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_PRD", OracleDbType.Int32).Value = objEntityEmpSlry.Days;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_PRD", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.Addess;
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS_TWO", OracleDbType.Varchar2).Value = objEntityEmpSlry.AddessTwo;
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS_THREE", OracleDbType.Varchar2).Value = objEntityEmpSlry.AddessThree;
                       cmdReadPayGrd.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerSts;
                       if (objEntityEmpSlry.LedgerId != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                       cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
                       cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
                       cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
                       cmdReadPayGrd.Parameters.Add("L_CONTACTNO", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactNo;
                       if (objEntityEmpSlry.VendorCatgry != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_VENDORCATGRY", OracleDbType.Int32).Value = objEntityEmpSlry.VendorCatgry;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_VENDORCATGRY", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_RATING", OracleDbType.Decimal).Value = objEntityEmpSlry.Rating;
                       cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                       cmdReadPayGrd.ExecuteNonQuery();

                       string strReturn = cmdReadPayGrd.Parameters["L_OUT"].Value.ToString();
                       cmdReadPayGrd.Dispose();
                       objEntityEmpSlry.SupplierId = Convert.ToInt32(strReturn);
                   }

                   foreach (clsEntitySupplierContact objSubDetail in objEnitytSupplierCntctList)
                   {
                       string strQuerySubDetails = "FMS_SUPPLIER.SP_INSERT_SUPPLIER_CONTACT";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                       {
                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddSubDetail.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTNAME", OracleDbType.Varchar2).Value = objSubDetail.ContactName;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTADDRESS", OracleDbType.Varchar2).Value = objSubDetail.ContactAddress;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTMOBILE", OracleDbType.Varchar2).Value = objSubDetail.ContactMobile;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTPHONE", OracleDbType.Varchar2).Value = objSubDetail.ContactPhone;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTWEBSITE", OracleDbType.Varchar2).Value = objSubDetail.ContactWebsite;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTEMAIL", OracleDbType.Varchar2).Value = objSubDetail.ContactEmail;
                           cmdAddSubDetail.ExecuteNonQuery();
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

       public void UpdateSupplier(clsEntitySupplier objEntityEmpSlry, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
       {
           string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_UPD_SUPPLIER";
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlry, con))
                   {
                       cmdReadPayGrd.Transaction = tran;
                       cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                       cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
                       cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.SupplierName;
                       //  cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
                       if (objEntityEmpSlry.CreditLimit != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_LMT", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditLimit;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_LMT", OracleDbType.Decimal).Value = DBNull.Value;
                       }
                       if (objEntityEmpSlry.Days != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_PRD", OracleDbType.Int32).Value = objEntityEmpSlry.Days;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_CREDIT_PRD", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.Addess;
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS_TWO", OracleDbType.Varchar2).Value = objEntityEmpSlry.AddessTwo;
                       cmdReadPayGrd.Parameters.Add("L_ADDRESS_THREE", OracleDbType.Varchar2).Value = objEntityEmpSlry.AddessThree;
                       cmdReadPayGrd.Parameters.Add("L_LEDGER_STS", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerSts;
                       if (objEntityEmpSlry.LedgerId != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_LEDGER_ID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                       cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
                       cmdReadPayGrd.Parameters.Add("L_CONTACTNO", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactNo;
                       if (objEntityEmpSlry.VendorCatgry != 0)
                       {
                           cmdReadPayGrd.Parameters.Add("L_VENDORCATGRY", OracleDbType.Int32).Value = objEntityEmpSlry.VendorCatgry;
                       }
                       else
                       {
                           cmdReadPayGrd.Parameters.Add("L_VENDORCATGRY", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdReadPayGrd.Parameters.Add("L_RATING", OracleDbType.Decimal).Value = objEntityEmpSlry.Rating;
                       cmdReadPayGrd.ExecuteNonQuery();
                   }

                   string strQueryDelDetails = "FMS_SUPPLIER.SP_DELETE_SUPPLIER_CONTACT";
                   using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryDelDetails, con))
                   {
                       cmdAddSubDetail.Transaction = tran;
                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                       cmdAddSubDetail.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
                       cmdAddSubDetail.ExecuteNonQuery();
                   }

                   foreach (clsEntitySupplierContact objSubDetail in objEnitytSupplierCntctList)
                   {
                       string strQuerySubDetails = "FMS_SUPPLIER.SP_INSERT_SUPPLIER_CONTACT";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                       {
                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddSubDetail.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTNAME", OracleDbType.Varchar2).Value = objSubDetail.ContactName;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTADDRESS", OracleDbType.Varchar2).Value = objSubDetail.ContactAddress;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTMOBILE", OracleDbType.Varchar2).Value = objSubDetail.ContactMobile;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTPHONE", OracleDbType.Varchar2).Value = objSubDetail.ContactPhone;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTWEBSITE", OracleDbType.Varchar2).Value = objSubDetail.ContactWebsite;
                           cmdAddSubDetail.Parameters.Add("L_CONTACTEMAIL", OracleDbType.Varchar2).Value = objSubDetail.ContactEmail;
                           cmdAddSubDetail.ExecuteNonQuery();
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

       public void UpdateLedgerSts(clsEntitySupplier objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_UPD_STS_LEDGER";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
           cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
           clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
       }

       public void CancelSupplier(clsEntitySupplier objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_CANCEL_SUPPLIER";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
            cmdReadPayGrd.Parameters.Add("L_CNCL_REASON", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
            cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
        }
       public DataTable CheckDupName(clsEntitySupplier objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_CHECK_DUP_NAME";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
            cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.SupplierName;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

       public DataTable ReadVendorCatgry(clsEntitySupplier objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_READ_VENDOR_CATGRY";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
           cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
           cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtEmpSlry = new DataTable();
           dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtEmpSlry;
       }

       public DataTable ReadContactDtls(clsEntitySupplier objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "FMS_SUPPLIER.SP_READ_CONTACT_DTLS";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SupplierId;
           cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtEmpSlry = new DataTable();
           dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtEmpSlry;
       }


    }
}