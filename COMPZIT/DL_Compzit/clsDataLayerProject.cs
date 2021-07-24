using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:26/05/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
   public class clsDataLayerProject
   {

       //Method for check Project name already exist in the table or not.
       public string CheckProjectName(clsEntityProject objEntityProject)
       {
           string strQueryCheckProjectName = "PROJECT_MASTER.SP_CHECK_PROJECT_NAME";
           OracleCommand cmdCheckProjectName = new OracleCommand();
           cmdCheckProjectName.CommandText = strQueryCheckProjectName;
           cmdCheckProjectName.CommandType = CommandType.StoredProcedure;
           cmdCheckProjectName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
           cmdCheckProjectName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
           cmdCheckProjectName.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
           cmdCheckProjectName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckProjectName);
           string strReturnCount = cmdCheckProjectName.Parameters["P_COUNT"].Value.ToString();
           cmdCheckProjectName.Dispose();
           return strReturnCount; ;
       }
       //Method for inserting data about Projects to the Project master table and returning the project id
       // adding Project in Lead  Master
       public string Insert_Project_Return_PrjctId(clsEntityProject objEntityProject)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {


               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   clsDataLayer objDataLayer = new clsDataLayer();
                   clsEntityCommon objCommon = new clsEntityCommon();
                   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROJECT);
                   objCommon.CorporateID = objEntityProject.CorpOffice_Id;
                   string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                   objEntityProject.Project_Master_Id = Convert.ToInt32(strNextValue);

                   string strQueryInsertProject = "PROJECT_MASTER.SP_INSERT_PROJECT";
                   using (OracleCommand cmdInsertProject = new OracleCommand(strQueryInsertProject, con))
                   {
                       cmdInsertProject.Transaction = tran;
                       cmdInsertProject.CommandText = strQueryInsertProject;
                       cmdInsertProject.CommandType = CommandType.StoredProcedure;
                       cmdInsertProject.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
                       cmdInsertProject.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
                       cmdInsertProject.Parameters.Add("P_CUST_ID", OracleDbType.Int32).Value = objEntityProject.Customer_Id;
                       cmdInsertProject.Parameters.Add("P_CRPDIV_ID", OracleDbType.Int32).Value = objEntityProject.Corp_Div_id;
                       cmdInsertProject.Parameters.Add("P_PRJ_REF_ID", OracleDbType.Varchar2).Value = objEntityProject.Proj_Ref_Num;
                       if (objEntityProject.Employee_Id != 0)
                       {
                           cmdInsertProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityProject.Employee_Id;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = null;
                       }
                       if (objEntityProject.Contact_Name != "")
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = objEntityProject.Contact_Name;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityProject.Contact_Email != "")
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityProject.Contact_Email;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityProject.Contact_Phone != "")
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_PHN", OracleDbType.Varchar2).Value = objEntityProject.Contact_Phone;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_CNTCT_PHN", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityProject.Tender_Ref != "")
                       {
                           cmdInsertProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = objEntityProject.Tender_Ref;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityProject.Manager_Id != 0)
                       {
                           cmdInsertProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = objEntityProject.Manager_Id;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = null;
                       }
                       if (objEntityProject.Client_Ref != "")
                       {
                           cmdInsertProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = objEntityProject.Client_Ref;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityProject.Inter_Ref != "")
                       {
                           cmdInsertProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = objEntityProject.Inter_Ref;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = null;
                       }
                       cmdInsertProject.Parameters.Add("P_GRNTY_MOD", OracleDbType.Int32).Value = objEntityProject.GuaranteMOde_Id;
                       cmdInsertProject.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
                       cmdInsertProject.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
                       cmdInsertProject.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProject.Project_Status;
                       cmdInsertProject.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
                       cmdInsertProject.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityProject.D_Date;
                       if (objEntityProject.WarehouseIds != "")
                       {
                           cmdInsertProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = objEntityProject.WarehouseIds;
                           cmdInsertProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = objEntityProject.WarehousePrimaryId;
                       }
                       else
                       {
                           cmdInsertProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = null;
                           cmdInsertProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = null;
                       }

                       cmdInsertProject.ExecuteNonQuery();
                   }
                   
                   tran.Commit();
                   return strNextValue;
               }
               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }
           }


       }
       //Method for inserting data about Projects to the Project master table
       public void Insert_Project(clsEntityProject objEntityProject)
       {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {


                con.Open();
                tran = con.BeginTransaction();
                 
                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();
                objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROJECT);
                objCommon.CorporateID = objEntityProject.CorpOffice_Id;
                string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                objEntityProject.Project_Master_Id = Convert.ToInt32(strNextValue);

                string strQueryInsertProject = "PROJECT_MASTER.SP_INSERT_PROJECT";
                using (OracleCommand cmdInsertProject = new OracleCommand(strQueryInsertProject, con))
                {
                    cmdInsertProject.Transaction = tran;
                    cmdInsertProject.CommandText = strQueryInsertProject;
                    cmdInsertProject.CommandType = CommandType.StoredProcedure;
                    cmdInsertProject.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
                    cmdInsertProject.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
                    cmdInsertProject.Parameters.Add("P_CUST_ID", OracleDbType.Int32).Value = objEntityProject.Customer_Id;
                    cmdInsertProject.Parameters.Add("P_CRPDIV_ID", OracleDbType.Int32).Value = objEntityProject.Corp_Div_id;
                    cmdInsertProject.Parameters.Add("P_PRJ_REF_ID", OracleDbType.Varchar2).Value = objEntityProject.Proj_Ref_Num;
                    if (objEntityProject.Employee_Id != 0)
                    {
                        cmdInsertProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityProject.Employee_Id;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = null;
                    }
                    if (objEntityProject.Contact_Name != "")
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = objEntityProject.Contact_Name;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = null;
                    }
                    if (objEntityProject.Contact_Email != "")
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityProject.Contact_Email;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = null;
                    }
                    if (objEntityProject.Contact_Phone != "")
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_PHN", OracleDbType.Varchar2).Value = objEntityProject.Contact_Phone;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_CNTCT_PHN", OracleDbType.Varchar2).Value = null;
                    }
                    if (objEntityProject.Tender_Ref != "")
                    {
                        cmdInsertProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = objEntityProject.Tender_Ref;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = null;
                    }
                    if (objEntityProject.Manager_Id != 0)
                    {
                        cmdInsertProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = objEntityProject.Manager_Id;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = null;
                    }
                    if (objEntityProject.Client_Ref != "")
                    {
                        cmdInsertProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = objEntityProject.Client_Ref;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = null;
                    }
                    if (objEntityProject.Inter_Ref != "")
                    {
                        cmdInsertProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = objEntityProject.Inter_Ref;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = null;
                    }
                    cmdInsertProject.Parameters.Add("P_GRNTY_MOD", OracleDbType.Int32).Value = objEntityProject.GuaranteMOde_Id;
                    cmdInsertProject.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
                    cmdInsertProject.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
                    cmdInsertProject.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProject.Project_Status;
                    cmdInsertProject.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
                    cmdInsertProject.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityProject.D_Date;
                    if (objEntityProject.WarehouseIds != "")
                    {
                        cmdInsertProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = objEntityProject.WarehouseIds;
                        cmdInsertProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = objEntityProject.WarehousePrimaryId;
                    }
                    else
                    {
                        cmdInsertProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = null;
                        cmdInsertProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = null;
                    }
                  

                    cmdInsertProject.ExecuteNonQuery();
                }
                if (objEntityProject.Update_Decide != 0 && objEntityProject.Lead_Id != 0)
                {
                    string strQueryUpdate = "LEAD_INDIVIDUAL.SP_UPDATE_PROJECT";

                    using (OracleCommand cmdAddUpdate = new OracleCommand(strQueryUpdate, con))
                    {
                        cmdAddUpdate.Transaction = tran;

                        cmdAddUpdate.CommandType = CommandType.StoredProcedure;
                        cmdAddUpdate.Parameters.Add("L_LEADID", OracleDbType.Int32).Value = objEntityProject.Lead_Id;
                        cmdAddUpdate.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;

                        cmdAddUpdate.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }

       }
       //Method for read Project for list view.
       public DataTable ReadProjectList(clsEntityProject objEntityProject)
       {
           string strQueryReadProjectList = "PROJECT_MASTER.SP_READ_PROJECTLIST";
           using (OracleCommand cmdReadProjectList = new OracleCommand())
           {
               cmdReadProjectList.CommandText = strQueryReadProjectList;
               cmdReadProjectList.CommandType = CommandType.StoredProcedure;
               cmdReadProjectList.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityProject.User_Id;
               cmdReadProjectList.Parameters.Add("P_OPTION", OracleDbType.Int32).Value = objEntityProject.Project_Status;
               cmdReadProjectList.Parameters.Add("P_CANCEL", OracleDbType.Int32).Value = objEntityProject.Cancel_Status;
               cmdReadProjectList.Parameters.Add("P_DIVISION", OracleDbType.Int32).Value = objEntityProject.Corp_Div_id;
               cmdReadProjectList.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityProject.GuaranteMOde_Id;
               cmdReadProjectList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
               cmdReadProjectList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;

               cmdReadProjectList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityProject.CommonSearchTerm;
               cmdReadProjectList.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityProject.SearchName;
               cmdReadProjectList.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityProject.SearchRef;
               cmdReadProjectList.Parameters.Add("M_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityProject.SearchCust;
               cmdReadProjectList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityProject.OrderColumn;
               cmdReadProjectList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityProject.OrderMethod;
               cmdReadProjectList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityProject.PageMaxSize;
               cmdReadProjectList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityProject.PageNumber;

               cmdReadProjectList.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtProject = new DataTable();
               dtProject = clsDataLayer.SelectDataTable(cmdReadProjectList);
               return dtProject;
           }
       }
       //Method for updating the status of the Projects
       public void Update_Project_Status(clsEntityProject objEntityProject)
       {
           string strQueryUpdateProjectStatus = "PROJECT_MASTER.SP_UPDATE_STATUS";
           OracleCommand cmdUpdateProjectStatus = new OracleCommand();
           cmdUpdateProjectStatus.CommandText = strQueryUpdateProjectStatus;
           cmdUpdateProjectStatus.CommandType = CommandType.StoredProcedure;
           cmdUpdateProjectStatus.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdUpdateProjectStatus.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProject.Project_Status;
           cmdUpdateProjectStatus.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
           cmdUpdateProjectStatus.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityProject.D_Date;
           clsDataLayer.ExecuteNonQuery(cmdUpdateProjectStatus);
       }

       //Method for read Project by their id.
       public DataTable ReadProjectListById(clsEntityProject objEntityProject)
       {
           string strQueryReadProjectListById = "PROJECT_MASTER.SP_READ_PROJECT_BYID";
           using (OracleCommand cmdReadProjectListById = new OracleCommand())
           {
               cmdReadProjectListById.CommandText = strQueryReadProjectListById;
               cmdReadProjectListById.CommandType = CommandType.StoredProcedure;
               cmdReadProjectListById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
               cmdReadProjectListById.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadProjectListById);
               return dtCorpDept;
           }
       }
       //Method for Updating data about Project to the Project master table
       public void Update_Project(clsEntityProject objEntityProject)
       {
           string strQueryUpdateProject = "PROJECT_MASTER.SP_UPDATE_PROJECT";
           OracleCommand cmdUpdateProject = new OracleCommand();
           cmdUpdateProject.CommandText = strQueryUpdateProject;
           cmdUpdateProject.CommandType = CommandType.StoredProcedure;
           cmdUpdateProject.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdUpdateProject.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
           cmdUpdateProject.Parameters.Add("P_CUST_ID", OracleDbType.Int32).Value = objEntityProject.Customer_Id;
           cmdUpdateProject.Parameters.Add("P_CRPDIV_ID", OracleDbType.Int32).Value = objEntityProject.Corp_Div_id;
           if (objEntityProject.Employee_Id != 0)
           {
               cmdUpdateProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityProject.Employee_Id;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = null;
           }
           if (objEntityProject.Contact_Name != "")
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = objEntityProject.Contact_Name;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_NM", OracleDbType.Varchar2).Value = null;
           }
           if (objEntityProject.Contact_Email != "")
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityProject.Contact_Email;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = null;
           }
           if (objEntityProject.Contact_Phone != "")
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityProject.Contact_Phone;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_CNTCT_EMAIL", OracleDbType.Varchar2).Value = null;
           }
           if (objEntityProject.Tender_Ref != "")
           {
               cmdUpdateProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = objEntityProject.Tender_Ref;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_TNDR_REF", OracleDbType.Varchar2).Value = null;
           }
           if (objEntityProject.Manager_Id != 0)
           {
               cmdUpdateProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = objEntityProject.Manager_Id;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_MNGR_ID", OracleDbType.Int32).Value = null;
           }
           if (objEntityProject.Client_Ref != "")
           {
               cmdUpdateProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = objEntityProject.Client_Ref;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_CLNT_REF", OracleDbType.Varchar2).Value = null;
           }
           if (objEntityProject.Inter_Ref != "")
           {
               cmdUpdateProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = objEntityProject.Inter_Ref;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = null;
           }
           cmdUpdateProject.Parameters.Add("P_GRNTY_MOD", OracleDbType.Int32).Value = objEntityProject.GuaranteMOde_Id;
           cmdUpdateProject.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProject.Project_Status;
           cmdUpdateProject.Parameters.Add("P_UPDUSERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
           cmdUpdateProject.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = objEntityProject.D_Date;
           if (objEntityProject.WarehouseIds != "")
           {
               cmdUpdateProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = objEntityProject.WarehouseIds;
               cmdUpdateProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = objEntityProject.WarehousePrimaryId;
           }
           else
           {
               cmdUpdateProject.Parameters.Add("P_WAREHOUSEIDS", OracleDbType.Varchar2).Value = null;
               cmdUpdateProject.Parameters.Add("P_WAREHOUSEID_PRMRY", OracleDbType.Int32).Value = null;
           }

           clsDataLayer.ExecuteNonQuery(cmdUpdateProject);
       }

       //Method for check Project name already exist in the table or not at the time of updation
       public string CheckProjectNameUpdate(clsEntityProject objEntityProject)
       {
           string strQueryCheckProjectNameUpdate = "PROJECT_MASTER.SP_CHECK_PROJECTNAME_UPDATION";
           OracleCommand cmdCheckProjectNameUpdate = new OracleCommand();
           cmdCheckProjectNameUpdate.CommandText = strQueryCheckProjectNameUpdate;
           cmdCheckProjectNameUpdate.CommandType = CommandType.StoredProcedure;
           cmdCheckProjectNameUpdate.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProject.ProjectName;
           cmdCheckProjectNameUpdate.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckProjectNameUpdate);
           string strReturnCount = cmdCheckProjectNameUpdate.Parameters["P_COUNT"].Value.ToString();
           cmdCheckProjectNameUpdate.Dispose();
           return strReturnCount; ;
       }
       //Method for Cancel Project from Project master table so update cancel related fields
       public void Cancel_Project(clsEntityProject objEntityProject)
       {
           string strQueryCancelProject = "PROJECT_MASTER.SP_CANCEL_PROJECT";
           OracleCommand cmdCancelProject = new OracleCommand();
           cmdCancelProject.CommandText = strQueryCancelProject;
           cmdCancelProject.CommandType = CommandType.StoredProcedure;
           cmdCancelProject.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdCancelProject.Parameters.Add("P_CANCEL_USERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
           cmdCancelProject.Parameters.Add("P_CANCEL_DATE", OracleDbType.Date).Value = objEntityProject.D_Date;
           cmdCancelProject.Parameters.Add("P_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityProject.Project_Cancel_reason;
           clsDataLayer.ExecuteNonQuery(cmdCancelProject);
       }
       //Method for Recall Cancelled 
       public void ReCall_Project(clsEntityProject objEntityProject)
       {
           string strQueryRecallJob = "PROJECT_MASTER.SP_RECALL_PROJECT";
           OracleCommand cmdRecallJob = new OracleCommand();
           cmdRecallJob.CommandText = strQueryRecallJob;
           cmdRecallJob.CommandType = CommandType.StoredProcedure;
           cmdRecallJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdRecallJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
           cmdRecallJob.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityProject.D_Date;
           clsDataLayer.ExecuteNonQuery(cmdRecallJob);
       }
       //Method for READ EXISTING CUSTOMERS
       public DataTable ReadExistingCustomer(clsEntityProject objEntityProject)
       {
           string strQueryReadCustomers = "PROJECT_MASTER.SP_READ_EXST_CUSTOMER";
           using (OracleCommand cmdReadCustomers = new OracleCommand())
           {
               cmdReadCustomers.CommandText = strQueryReadCustomers;
               cmdReadCustomers.CommandType = CommandType.StoredProcedure;
               cmdReadCustomers.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
               cmdReadCustomers.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
               cmdReadCustomers.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadCustomers);
               return dtCorpDept;
           }
       }
       //Method for READ EXISTING CUSTOMERS
       public DataTable ReadExistingEmployee(clsEntityProject objEntityProject)
       {
           string strQueryReadEmployee = "PROJECT_MASTER.SP_READ_EXST_EMPLOYEE";
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = strQueryReadEmployee;
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
               cmdReadEmployee.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
               cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
               return dtCorpDept;
           }
       }
       //Method for READ DIVISION
       public DataTable ReadDivisionByUser(clsEntityProject objEntityProject)
       {
           string strQueryReadEmployee = "PROJECT_MASTER.SP_READ_DIVISION_BY_USR";
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = strQueryReadEmployee;
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
               cmdReadEmployee.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
               cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
               return dtCorpDept;
           }
       }
       //Method for READ DIVISION
       public DataTable ReadEmployeeDetail(clsEntityProject objEntityProject)
       {
           string strQueryReadEmployee = "PROJECT_MASTER.SP_READ_EMPLOYE_BY_ID";
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = strQueryReadEmployee;
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProject.User_Id;
               cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
               return dtCorpDept;
           }
       }

       public DataTable ReadWarehouses(clsEntityProject objEntityProject)
       {
           string strQueryReadEmployee = "PROJECT_MASTER.SP_READ_WAREHOUSE";
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = strQueryReadEmployee;
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
               cmdReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
               cmdReadEmployee.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadEmployee);
               return dtCorpDept;
           }
       }

       //Method for check Client Ref Number already exist in the table or not.
       public string CheckInternalRefNumber(clsEntityProject objEntityProject)
       {
           string strQueryCheckProjectName = "PROJECT_MASTER.SP_CHECK_INTRNL_REF_NUM";
           OracleCommand cmdCheckProjectName = new OracleCommand();
           cmdCheckProjectName.CommandText = strQueryCheckProjectName;
           cmdCheckProjectName.CommandType = CommandType.StoredProcedure;
           cmdCheckProjectName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
           cmdCheckProjectName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
           cmdCheckProjectName.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = objEntityProject.Inter_Ref;
           cmdCheckProjectName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckProjectName);
           string strReturnCount = cmdCheckProjectName.Parameters["P_COUNT"].Value.ToString();
           cmdCheckProjectName.Dispose();
           return strReturnCount; ;
       }

       public string CheckInternalRefNumberUpdation(clsEntityProject objEntityProject)
       {
           string strQueryCheckProjectNameUpdate = "PROJECT_MASTER.SP_CHECK_INTRNL_REFNUM_UPD";
           OracleCommand cmdCheckProjectNameUpdate = new OracleCommand();
           cmdCheckProjectNameUpdate.CommandText = strQueryCheckProjectNameUpdate;
           cmdCheckProjectNameUpdate.CommandType = CommandType.StoredProcedure;
           cmdCheckProjectNameUpdate.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProject.Organisation_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProject.CorpOffice_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProject.Project_Master_Id;
           cmdCheckProjectNameUpdate.Parameters.Add("P_INTR_REF", OracleDbType.Varchar2).Value = objEntityProject.Inter_Ref;
           cmdCheckProjectNameUpdate.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckProjectNameUpdate);
           string strReturnCount = cmdCheckProjectNameUpdate.Parameters["P_COUNT"].Value.ToString();
           cmdCheckProjectNameUpdate.Dispose();
           return strReturnCount; ;
       }



    }
}
