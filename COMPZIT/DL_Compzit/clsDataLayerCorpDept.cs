using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using CL_Compzit;
 //CREATED BY:EVM-0002
 //CREATED DATE:05/06/2015
 //REVIEWED BY:
 //REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerCorpDept
    {
        //Method for read department for set main departments.
        public DataTable ReadCorporateDept(clsEntityCorpDept objEntityDept)
        {
            string strQueryReadCorporateDept = "CORPORATE_DEPARTMENTS.SP_READ_CORP_DEPT";
            using (OracleCommand cmdReadCorpDept = new OracleCommand())
            {
                cmdReadCorpDept.CommandText = strQueryReadCorporateDept;
                cmdReadCorpDept.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDept.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDept.Organisation_Id;
                cmdReadCorpDept.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDept.CorpOffice_Id;
               
                    cmdReadCorpDept.Parameters.Add("D_DEPTID", OracleDbType.Int32).Value = objEntityDept.intDep_Id;
               
                cmdReadCorpDept.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadCorpDept);
                return dtCorpDept;
            }
        }
        
        //Method for check department name already exist in the table or not.
        public string CheckDeptName(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryCheckDeptName = "CORPORATE_DEPARTMENTS.SP_CHECK_DEPT_NAME";
            OracleCommand cmdCheckDeptName = new OracleCommand();
            cmdCheckDeptName.CommandText = strQueryCheckDeptName;
            cmdCheckDeptName.CommandType = CommandType.StoredProcedure;
            cmdCheckDeptName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
            cmdCheckDeptName.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityCorpdept.Organisation_Id;
            cmdCheckDeptName.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityCorpdept.CorpOffice_Id;
            cmdCheckDeptName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityCorpdept.Department_Name;
            cmdCheckDeptName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDeptName);
            string strReturnCount = cmdCheckDeptName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDeptName.Dispose();
            return strReturnCount; ;
        }
        //evm-0023
        //Method for inserting data about department to the department master table
        public void Insert_Dept(clsEntityCorpDept objEntityCorpdept, List<clsEntityCorpIdListIns> objEntityCorpIdList, List<clsEntityDeptDivListIns> objDeptDivListIns)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {
                     string strQueryInsertCorporateDept = "CORPORATE_DEPARTMENTS.SP_INERT_CORP_DEPT";
                     using (OracleCommand cmdInsertCorpDept = new OracleCommand(strQueryInsertCorporateDept, con))
                      {
                          //generate next value
                          clsDataLayer objDataLayer = new clsDataLayer();
                          clsEntityCommon objCommon = new clsEntityCommon();
                          objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CORPORATE_DEPARTMENTS);
                          objCommon.CorporateID = objEntityCorpdept.CorpOffice_Id;
                          string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                          objEntityCorpdept.Department_Master_Id = Convert.ToInt32(strNextValue);
                          cmdInsertCorpDept.CommandText = strQueryInsertCorporateDept;
                          cmdInsertCorpDept.CommandType = CommandType.StoredProcedure;
                          cmdInsertCorpDept.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                          cmdInsertCorpDept.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityCorpdept.Department_Name;
                          cmdInsertCorpDept.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityCorpdept.Organisation_Id;
                          cmdInsertCorpDept.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityCorpdept.CorpOffice_Id;
                          cmdInsertCorpDept.Parameters.Add("D_DEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Id;
                          cmdInsertCorpDept.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityCorpdept.Dept_Status;
                          cmdInsertCorpDept.Parameters.Add("D_INSUSERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
                          cmdInsertCorpDept.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
                          cmdInsertCorpDept.ExecuteNonQuery();
                      }
                     //Insert Business unit from this department by id
                     foreach (clsEntityCorpIdListIns objCorpIdList in objEntityCorpIdList)
                     {
                         if (objCorpIdList.CorpIdList != 0 && objCorpIdList.CorpIdList != null)
                         {
                             string strQueryInsertCorpDeptUnits = "CORPORATE_DEPARTMENTS.SP_INSERT_CORP_DEPT_UNITS";
                             using (OracleCommand cmdInsertCorpDeptUnits = new OracleCommand(strQueryInsertCorpDeptUnits, con))
                             {
                                 cmdInsertCorpDeptUnits.Transaction = tran;
                                 cmdInsertCorpDeptUnits.CommandType = CommandType.StoredProcedure;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objCorpIdList.CorpIdList;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_INSUSERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
                                 cmdInsertCorpDeptUnits.ExecuteNonQuery();
                             }
                         }
                     }
                     //EVM-0023
                     //Insert Division unit from this department by id
                     foreach (clsEntityDeptDivListIns objEntityDeptDivListIns in objDeptDivListIns)
                     {
                         if (objEntityDeptDivListIns.DeptDivList != 0)
                         {
                             string strQueryInsertCorpDeptUnits = "CORPORATE_DEPARTMENTS.SP_INSERT_CORPDEPT_DIV_UNITS";
                             using (OracleCommand cmdInsertCorpDeptDevUnits = new OracleCommand(strQueryInsertCorpDeptUnits, con))
                             {
                                 cmdInsertCorpDeptDevUnits.Transaction = tran;
                                 cmdInsertCorpDeptDevUnits.CommandType = CommandType.StoredProcedure;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CPRTDEPT_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CPRTDIV_ID", OracleDbType.Int32).Value = objEntityDeptDivListIns.DeptDivList;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityCorpdept.CorpOffice_Id;
                                 cmdInsertCorpDeptDevUnits.ExecuteNonQuery();
                             }
                         }
                     }

                
                     tran.Commit();
                     //return objEntityCorpdept.intDep_Id;
                 }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
            
        }

        public void Insert_DeptWelfare(List<clsEntityLayerDepartmentWelfareSrvc> objListDesgWelfare, clsEntityLayerDepartmentWelfareSrvc objDept)
        {
           
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                  
                 
                 
                    //EMP0025
                    foreach (clsEntityLayerDepartmentWelfareSrvc objDsgn in objListDesgWelfare)
                    {
                        int chkSts = objDsgn.chkSts;
                        int checkboxStatus = objDsgn.checkboxsts;

                        if (checkboxStatus == 1)
                        {
                            if (chkSts == 0)
                            {
                                string strQueryAddDesgWelfareSrvc = "CORPORATE_DEPARTMENTS.SP_ADD_DEPT_WELFARE";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dept_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.Qty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string strQueryAddDesgWelfareSrvc = "CORPORATE_DEPARTMENTS.SP_UPDATE_DEPT_WELFAREQTY";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dept_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.Qty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            if (chkSts == 0)
                            {

                                string strQueryAddDesgWelfareSrvc = "CORPORATE_DEPARTMENTS.SP_ADD_DEPT_WELFARECNCL ";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dept_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.ActQty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }


                            }
                            else
                            {
                                string strQueryAddDesgWelfareSrvc = "CORPORATE_DEPARTMENTS.SP_UPDATE_DEPT_WELFARECNCLDATE";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dept_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    tran.Commit();
                    //return objEntityCorpdept.intDep_Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }

        }



        //Method for read department for list view.
        public DataTable ReadDeptList(clsEntityCorpDept objEntityDept)
        {
            string strQueryReadDeptList = "CORPORATE_DEPARTMENTS.SP_READ_DEPTLIST";
            using (OracleCommand cmdReadDeptList = new OracleCommand())
            {
                cmdReadDeptList.CommandText = strQueryReadDeptList;
                cmdReadDeptList.CommandType = CommandType.StoredProcedure;
                cmdReadDeptList.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDept.Organisation_Id;
                cmdReadDeptList.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDept.CorpOffice_Id;
                cmdReadDeptList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityDept.Dept_Status;
                cmdReadDeptList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityDept.Cancel_Status;
                cmdReadDeptList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityDept.CommonSearchTerm;
                cmdReadDeptList.Parameters.Add("M_SEARCH_DEPT", OracleDbType.Varchar2).Value = objEntityDept.SearchDepartment;
                cmdReadDeptList.Parameters.Add("M_SEARCH_MAIN_DEPT", OracleDbType.Varchar2).Value = objEntityDept.SearchMainDepartment;
                cmdReadDeptList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityDept.OrderColumn;
                cmdReadDeptList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityDept.OrderMethod;
                cmdReadDeptList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityDept.PageMaxSize;
                cmdReadDeptList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityDept.PageNumber;
                cmdReadDeptList.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadDeptList);
                return dtCorpDept;
            }
        }
        //Method for updating the status of the departments
        public void Update_Dept_Status(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryUpdateDeptStatus = "CORPORATE_DEPARTMENTS.SP_UPDATE_STATUS";
            OracleCommand cmdUpdateDeptStatus = new OracleCommand();
            cmdUpdateDeptStatus.CommandText = strQueryUpdateDeptStatus;
            cmdUpdateDeptStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdateDeptStatus.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
            cmdUpdateDeptStatus.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityCorpdept.Dept_Status;
            cmdUpdateDeptStatus.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
            cmdUpdateDeptStatus.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateDeptStatus);
        }

        //Method for read department by their id.
        public DataTable ReadDeptListById(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryReadDeptListById = "CORPORATE_DEPARTMENTS.SP_READ_DEPT_BYID";
            using (OracleCommand cmdReadDeptListById = new OracleCommand())
            {
                cmdReadDeptListById.CommandText = strQueryReadDeptListById;
                cmdReadDeptListById.CommandType = CommandType.StoredProcedure;
                cmdReadDeptListById.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                cmdReadDeptListById.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadDeptListById);
                return dtCorpDept;
            }
        }
        //Method for Updating data about department to the department master table
        public void Update_Dept(clsEntityCorpDept objEntityCorpdept, List<clsEntityCorpIdListIns> objEntityCorpIdListIns, List<clsEntityDeptDivListIns> objDeptDivListIns)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {
                     string strQueryUpdateCorporateDept = "CORPORATE_DEPARTMENTS.SP_UPDATE_CORP_DEPT";
                     using (OracleCommand cmdUpdateCorpDept = new OracleCommand(strQueryUpdateCorporateDept, con))
                {
                    cmdUpdateCorpDept.CommandText = strQueryUpdateCorporateDept;
                    cmdUpdateCorpDept.CommandType = CommandType.StoredProcedure;
                    cmdUpdateCorpDept.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                    cmdUpdateCorpDept.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityCorpdept.Department_Name;
                    cmdUpdateCorpDept.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityCorpdept.Dept_Status;
                    cmdUpdateCorpDept.Parameters.Add("D_DEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Id;
                    cmdUpdateCorpDept.Parameters.Add("D_UPDUSERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
                    cmdUpdateCorpDept.Parameters.Add("D_UPDDATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
                    cmdUpdateCorpDept.ExecuteNonQuery();
                }
                     
                     //Delete Business unit from this department by id
                     clsEntityCorpIdListToDel objCorpIdListDel = new clsEntityCorpIdListToDel();

                             string strQueryDelCorpDeptUnits = "CORPORATE_DEPARTMENTS.SP_DELETE_CORP_DEPT_UNITS_BYID";
                             using (OracleCommand cmdInsertCorpDeptUnits = new OracleCommand(strQueryDelCorpDeptUnits, con))
                             {
                                 cmdInsertCorpDeptUnits.Transaction = tran;
                                 cmdInsertCorpDeptUnits.CommandType = CommandType.StoredProcedure;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;

                                 cmdInsertCorpDeptUnits.ExecuteNonQuery();
                             }


                     //Insert Business unit from this department by id
                     foreach (clsEntityCorpIdListIns objCorpIdList in objEntityCorpIdListIns)
                     {
                         if (objCorpIdList.CorpIdList != 0)
                         {
                             string strQueryInsertCorpDeptUnits = "CORPORATE_DEPARTMENTS.SP_INSERT_CORP_DEPT_UNITS";
                             using (OracleCommand cmdInsertCorpDeptUnits = new OracleCommand(strQueryInsertCorpDeptUnits, con))
                             {
                                 cmdInsertCorpDeptUnits.Transaction = tran;
                                 cmdInsertCorpDeptUnits.CommandType = CommandType.StoredProcedure;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objCorpIdList.CorpIdList;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_INSUSERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
                                 cmdInsertCorpDeptUnits.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
                                 cmdInsertCorpDeptUnits.ExecuteNonQuery();
                             }
                         }
                     }

                    
                    
                 
                    



                     //EVM-0023
                     //Delete Division  from this department by id

                             string strQueryelCorpDivUnits = "CORPORATE_DEPARTMENTS.SP_DELETE_CORP_DIV_UNITS_BYID";
                             using (OracleCommand cmdDelCorpDivUnits = new OracleCommand(strQueryelCorpDivUnits, con))
                             {
                                 cmdDelCorpDivUnits.Transaction = tran;
                                 cmdDelCorpDivUnits.CommandType = CommandType.StoredProcedure;
                                 cmdDelCorpDivUnits.Parameters.Add("CPRDEPT_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;

                                 cmdDelCorpDivUnits.ExecuteNonQuery();
                             }

                     //Insert Division unit from this department by id
                     foreach (clsEntityDeptDivListIns objEntityDeptDivListIns in objDeptDivListIns)
                     {
                         if (objEntityDeptDivListIns.DeptDivList !=0)
                         {
                             string strQueryInsertCorpDeptUnits = "CORPORATE_DEPARTMENTS.SP_INSERT_CORPDEPT_DIV_UNITS";
                             using (OracleCommand cmdInsertCorpDeptDevUnits = new OracleCommand(strQueryInsertCorpDeptUnits, con))
                             {
                                 cmdInsertCorpDeptDevUnits.Transaction = tran;
                                 cmdInsertCorpDeptDevUnits.CommandType = CommandType.StoredProcedure;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CPRTDEPT_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CPRTDIV_ID", OracleDbType.Int32).Value = objEntityDeptDivListIns.DeptDivList;
                                 cmdInsertCorpDeptDevUnits.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityCorpdept.CorpOffice_Id;
                                 cmdInsertCorpDeptDevUnits.ExecuteNonQuery();
                             }
                         }
                     }


                     //EVM-0023 end

                     tran.Commit();
                 }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
            }
           
        }

      
        //Method for Cancel department from department master table so update department related fields
        public void Cancel_Dept(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryCancel_Dept = "CORPORATE_DEPARTMENTS.SP_CANCEL_DEPT";
            OracleCommand cmdCancelDept = new OracleCommand();
            cmdCancelDept.CommandText = strQueryCancel_Dept;
            cmdCancelDept.CommandType = CommandType.StoredProcedure;
            cmdCancelDept.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
            cmdCancelDept.Parameters.Add("D_CANCEL_USERID", OracleDbType.Int32).Value = objEntityCorpdept.User_Id;
            cmdCancelDept.Parameters.Add("D_CANCEL_DATE", OracleDbType.Date).Value = objEntityCorpdept.D_Date;
            cmdCancelDept.Parameters.Add("D_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityCorpdept.Department_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelDept);
        }
        //EVM-0012
        //Method for read all active business units.
        public DataTable ReadCorporateOffice(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryReadCorporateOffice = "CORPORATE_DEPARTMENTS.SP_READ_CORP_OFFICES";
            using (OracleCommand cmdReadCorpOffice = new OracleCommand())
            {
                cmdReadCorpOffice.CommandText = strQueryReadCorporateOffice;
                cmdReadCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdReadCorpOffice.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityCorpdept.Organisation_Id;
                cmdReadCorpOffice.Parameters.Add("D_OFFICES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadCorpOffice);
                return dtCorpDept;
            }
        }
        //EVM-012
        //ReadBusinessUnitsById
        public DataTable ReadBusinessUnitsById(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryReadCorporateOffice = "CORPORATE_DEPARTMENTS.SP_READ_CORP_DEPT_UNITS_BYID";
            using (OracleCommand cmdReadBusinessUnitsById = new OracleCommand())
            {
                cmdReadBusinessUnitsById.CommandText = strQueryReadCorporateOffice;
                cmdReadBusinessUnitsById.CommandType = CommandType.StoredProcedure;
                cmdReadBusinessUnitsById.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                cmdReadBusinessUnitsById.Parameters.Add("D_OFFICES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtBusinessUnits = new DataTable();
                dtBusinessUnits = clsDataLayer.SelectDataTable(cmdReadBusinessUnitsById);
                return dtBusinessUnits;
            }
        }

        //EVM-0023
        //Read Corperate division offices
        public DataTable ReadCorporateDivisionOffice(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryReadCorporateDivOffice = "CORPORATE_DIVISION.SP_READ_CORP_DIVISION_OFFICE";
            using (OracleCommand cmdReadCorpDivOffice = new OracleCommand())
            {
                cmdReadCorpDivOffice.CommandText = strQueryReadCorporateDivOffice;
                cmdReadCorpDivOffice.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDivOffice.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityCorpdept.CorpOffice_Id;
                cmdReadCorpDivOffice.Parameters.Add("D_DIV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDiv = new DataTable();
                dtCorpDiv = clsDataLayer.SelectDataTable(cmdReadCorpDivOffice);
                return dtCorpDiv;
            }
        }

        //EVM-023
        //Read Corperate division Units ById
        public DataTable ReadDivisionById(clsEntityCorpDept objEntityCorpdept)
        {
            string strQueryReadCorporDiv = "CORPORATE_DEPARTMENTS.SP_READ_CORP_DIV_UNITS_BYID";
            using (OracleCommand cmdReadCorpDivById = new OracleCommand())
            {
                cmdReadCorpDivById.CommandText = strQueryReadCorporDiv;
                cmdReadCorpDivById.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDivById.Parameters.Add("D_CPRDEPTID", OracleDbType.Int32).Value = objEntityCorpdept.Department_Master_Id;
                cmdReadCorpDivById.Parameters.Add("D_OFFICES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDivision = new DataTable();
                dtCorpDivision = clsDataLayer.SelectDataTable(cmdReadCorpDivById);
                return dtCorpDivision;
            }
        }
        public DataTable ReadDeptnWelfareSrvc(clsEntityCorpDept objEntityDeptnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "CORPORATE_DEPARTMENTS.SP_READ_WELFARE_SERVICES";
            using (OracleCommand cmdWelfareSrvc = new OracleCommand())
            {
                cmdWelfareSrvc.CommandText = strCommandText;
                cmdWelfareSrvc.CommandType = CommandType.StoredProcedure;
                cmdWelfareSrvc.Parameters.Add("D_DEPT", OracleDbType.Int32).Value = objEntityDeptnWelfareSrvc.Department_Id;
                cmdWelfareSrvc.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtWelfareScvc = new DataTable();
                dtWelfareScvc = clsDataLayer.SelectDataTable(cmdWelfareSrvc);
                return dtWelfareScvc;
            }
        }

        public DataTable ReadDsgnWelfare(clsEntityLayerDepartmentWelfareSrvc objEntityDeptnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "CORPORATE_DEPARTMENTS.SP_RD_WELFARE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDeptnWelfareSrvc.Dept_Id;
                cmdwelfare.Parameters.Add("D_SUB_ID", OracleDbType.Varchar2).Value = objEntityDeptnWelfareSrvc.WelfSub_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadDsgnWelfareById(clsEntityLayerDepartmentWelfareSrvc objEntityDeptnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "CORPORATE_DEPARTMENTS.SP_RD_WELFARE_BYID";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDeptnWelfareSrvc.Welfare_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
    }

}
