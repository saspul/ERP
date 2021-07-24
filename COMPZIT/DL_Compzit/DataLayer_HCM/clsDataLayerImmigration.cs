using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayerImmigration
    {
        // This Method adds customer details to the customer master table
       public void AddImmigration(clsEntityImmigration objEntityImigrationDtls)
        {
            //fetching next value

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                string strQueryAddImmigration = "EMPLOYEE_SPONSOR_IMIGRATION.SP_INSERT_EMPLOYEE_IMIG";
                    using (OracleCommand cmdAddImmigration = new OracleCommand(strQueryAddImmigration, con))
                    {

                        cmdAddImmigration.CommandType = CommandType.StoredProcedure;
                        //generate next value
                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                     //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Immigration);
                        objCommon.CorporateID = objEntityImigrationDtls.CorpId;



                        cmdAddImmigration.Parameters.Add("C_TYPEID", OracleDbType.Int32).Value = objEntityImigrationDtls.ImigDocType_Id;
                        if (objEntityImigrationDtls.intVisaType == 0)
                        {

                            cmdAddImmigration.Parameters.Add("C_VISA_TYPEID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddImmigration.Parameters.Add("C_VISA_TYPEID", OracleDbType.Int32).Value = objEntityImigrationDtls.intVisaType;


                        }
                        
                        cmdAddImmigration.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigDocName;
                        cmdAddImmigration.Parameters.Add("C_DOCNO", OracleDbType.Varchar2).Value = objEntityImigrationDtls.Imig_Doc_No;

                      
                        if (objEntityImigrationDtls.Imigissuedate == new DateTime())
                        {
                            cmdAddImmigration.Parameters.Add("C_ISSUEDATE", OracleDbType.Date).Value = null; 
                        }
                        else
                        {
                            cmdAddImmigration.Parameters.Add("C_ISSUEDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigissuedate;

                        }
                        if (objEntityImigrationDtls.ImigExpdate == new DateTime())
                        {
                            cmdAddImmigration.Parameters.Add("C_EXPIRYDATE", OracleDbType.Date).Value = null;
                                                 }
                        else
                        {
                            cmdAddImmigration.Parameters.Add("C_EXPIRYDATE", OracleDbType.Date).Value = objEntityImigrationDtls.ImigExpdate;
   
                        }
                             cmdAddImmigration.Parameters.Add("C_ELIGBLE_STATUS", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigStatus;
                             if (objEntityImigrationDtls.IssuedBy == -1)
                             {
                                 cmdAddImmigration.Parameters.Add("C_ISSUEDBY", OracleDbType.Int32).Value = null;
                             }
                             else
                             {
                                 cmdAddImmigration.Parameters.Add("C_ISSUEDBY", OracleDbType.Int32).Value = objEntityImigrationDtls.IssuedBy;

                             }
                             if (objEntityImigrationDtls.Imigrvwdate == new DateTime())
                             {
                                 cmdAddImmigration.Parameters.Add("C_RVWDATE", OracleDbType.Date).Value = null;
                             }
                             else
                             {
                                 cmdAddImmigration.Parameters.Add("C_RVWDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigrvwdate;
                             }
                         cmdAddImmigration.Parameters.Add("C_COMMENTS", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigComments;
                        cmdAddImmigration.Parameters.Add("C_ATTACHMENT", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigAttachname;
                        cmdAddImmigration.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigdate;
                        cmdAddImmigration.Parameters.Add("C_INSUSR_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;

                        cmdAddImmigration.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
                        cmdAddImmigration.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;

                        cmdAddImmigration.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Emp_id;
                        cmdAddImmigration.Parameters.Add("C_CENTER_NUM", OracleDbType.Varchar2).Value = objEntityImigrationDtls.CenterNum;

                        cmdAddImmigration.ExecuteNonQuery();
                    }

                 
                      
            
                   
            
                
            }
        }
        //Method for Updating Immigration Details
       public void UpdateImmigration(clsEntityImmigration objEntityImigrationDtls)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
        
                //generate next value
                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();

                string strQueryUpdateImmigration = "EMPLOYEE_SPONSOR_IMIGRATION.SP_UPD_EMPLOYEE_IMIGRATION";
                using (OracleCommand cmdAddImmigration = new OracleCommand(strQueryUpdateImmigration, con))
                {
                    cmdAddImmigration.CommandType = CommandType.StoredProcedure;
                    cmdAddImmigration.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
                    cmdAddImmigration.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
                    cmdAddImmigration.Parameters.Add("C_TYPEID", OracleDbType.Int32).Value = objEntityImigrationDtls.ImigDocType_Id;
                    if (objEntityImigrationDtls.intVisaType == 0)
                    {

                        cmdAddImmigration.Parameters.Add("C_VISA_TYPEID", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddImmigration.Parameters.Add("C_VISA_TYPEID", OracleDbType.Int32).Value = objEntityImigrationDtls.intVisaType;


                    }
                        
                    
                    cmdAddImmigration.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigDocName;
                    cmdAddImmigration.Parameters.Add("C_DOCNO", OracleDbType.Varchar2).Value = objEntityImigrationDtls.Imig_Doc_No;

                    if (objEntityImigrationDtls.Imigissuedate == new DateTime())
                    {
                        cmdAddImmigration.Parameters.Add("C_ISSUEDATE", OracleDbType.Date).Value = null;
                                  }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("C_ISSUEDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigissuedate;
         
                    }
                    if (objEntityImigrationDtls.ImigExpdate == new DateTime())
                    {
                        cmdAddImmigration.Parameters.Add("C_EXPIRYDATE", OracleDbType.Date).Value = null;     
                    }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("C_EXPIRYDATE", OracleDbType.Date).Value = objEntityImigrationDtls.ImigExpdate;
               
                    }
                    cmdAddImmigration.Parameters.Add("C_ELIGBLE_STATUS", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigStatus;
                    if (objEntityImigrationDtls.IssuedBy == -1)
                    {
                        cmdAddImmigration.Parameters.Add("C_ISSUEDBY", OracleDbType.Int32).Value = null;
                    }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("C_ISSUEDBY", OracleDbType.Int32).Value = objEntityImigrationDtls.IssuedBy;

                    }
                    if (objEntityImigrationDtls.Imigrvwdate == new DateTime())
                    {
                        cmdAddImmigration.Parameters.Add("C_RVWDATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddImmigration.Parameters.Add("C_RVWDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigrvwdate;
                    }
                    cmdAddImmigration.Parameters.Add("C_COMMENTS", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigComments;
                    cmdAddImmigration.Parameters.Add("C_ATTACHMENT", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigAttachname;
                    cmdAddImmigration.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigdate;
                    cmdAddImmigration.Parameters.Add("C_UPDUSR_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;
                    cmdAddImmigration.Parameters.Add("C_EMPIMG_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
                    cmdAddImmigration.Parameters.Add("C_CENTER_NUM", OracleDbType.Varchar2).Value = objEntityImigrationDtls.CenterNum;
                    cmdAddImmigration.ExecuteNonQuery();
                }




            }
        }
        //This Method will fetch customer table by ID
       public DataTable ReadImmigrationById(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadImmigrationById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_BY_ID";
           OracleCommand cmdReadImmigrationById = new OracleCommand();
           cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
           cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
           cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
           cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
           cmdReadImmigrationById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
           cmdReadImmigrationById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomer = new DataTable();
           dtCustomer = clsDataLayer.ExecuteReader(cmdReadImmigrationById);
           return dtCustomer;
       }
       //This Method will fetch customer table
       public DataTable ReadImmigrationList(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadImmigrationById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_IMIG_LIST";
           OracleCommand cmdReadImmigrationById = new OracleCommand();
           cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
           cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
           cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
           cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
           cmdReadImmigrationById.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Emp_id;
           cmdReadImmigrationById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomer = new DataTable();
           dtCustomer = clsDataLayer.ExecuteReader(cmdReadImmigrationById);
           return dtCustomer;
       }
       //This Method will CANCEL   by ID
       //public void CancelImmigrationById(clsEntityImmigration objEntityImigrationDtls)
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
       public void CancelImmigrationById(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadImmigrationById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_CAN_IMMIGRATION";
           using (OracleCommand cmdReadImmigrationById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadImmigrationById.Connection = con;
           
           
               cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
               cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
               cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
               cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
               cmdReadImmigrationById.Parameters.Add("C_EMPIMG_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
               cmdReadImmigrationById.Parameters.Add("C_CANDATE", OracleDbType.Date).Value = objEntityImigrationDtls.Imigdate;
               cmdReadImmigrationById.Parameters.Add("C_CANUSR_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;

               cmdReadImmigrationById.Parameters.Add("C_RSN", OracleDbType.Varchar2).Value = objEntityImigrationDtls.ImigCancelREASON;

               cmdReadImmigrationById.ExecuteNonQuery();
           }
       }
       //methode for read customer list 
       public DataTable Read_Visa_ById(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadvisaList = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_VISA_LIST";
           OracleCommand cmdReadvisaList = new OracleCommand();
           cmdReadvisaList.CommandText = strQueryReadvisaList;
           cmdReadvisaList.CommandType = CommandType.StoredProcedure;
           cmdReadvisaList.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Emp_id;
           cmdReadvisaList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
           cmdReadvisaList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
           cmdReadvisaList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtvisaList = new DataTable();
           dtvisaList = clsDataLayer.ExecuteReader(cmdReadvisaList);
           return dtvisaList;
       }
       //methode for read customer list 
       public DataTable ReadVisaByType(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadvisaList = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_VISA_BY_TYPE";
           OracleCommand cmdReadvisaList = new OracleCommand();
           cmdReadvisaList.CommandText = strQueryReadvisaList;
           cmdReadvisaList.CommandType = CommandType.StoredProcedure;

           cmdReadvisaList.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Emp_id;
           cmdReadvisaList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_user_id;
           cmdReadvisaList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityImigrationDtls.OrgId;
           cmdReadvisaList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityImigrationDtls.CorpId;
           cmdReadvisaList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtvisaList = new DataTable();
           dtvisaList = clsDataLayer.ExecuteReader(cmdReadvisaList);
           return dtvisaList;
       }
       public DataTable ReadVisa(clsEntityImmigration objEntityImigrationDtls)
       {
           string strQueryReadvisaList = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_VISA";
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

      public string Check_DOCNUM(clsEntityImmigration objEntityImigrationDtls)
        {
            string strQueryReadProj = "EMPLOYEE_SPONSOR_IMIGRATION.SP_CHECK_PASSPORT_DTLS";
              OracleCommand cmdReadProj = new OracleCommand();
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_NO", OracleDbType.Varchar2).Value = objEntityImigrationDtls.Imig_Doc_No;
                cmdReadProj.Parameters.Add("P_EMPIMG_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.Imig_Id;
                cmdReadProj.Parameters.Add("P_TYPE_ID", OracleDbType.Int32).Value = objEntityImigrationDtls.ImigDocType_Id;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdReadProj);
                string strReturn = cmdReadProj.Parameters["P_OUT"].Value.ToString();
                cmdReadProj.Dispose();
                return strReturn;
            
        }
    }
    }

