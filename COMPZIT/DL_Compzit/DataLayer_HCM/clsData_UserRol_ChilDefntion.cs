using CL_Compzit;
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
   public class clsData_UserRol_ChilDefntion
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        public DataTable ReadEmployeOnLeave(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_EMPLOYEE_LEV";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntity.ChildRole;
           // cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = objCommon.;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadEmployee(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_EMPLOYEE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice;
           // cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntity.ChildRole;
            // cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = objCommon.;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable UserRolesDetails(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_USERROLE_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.CorpOffice;
           cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntity.ChildRole;
           cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntity.Employeeid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

     

        public DataTable UserRolesDtlsAsssingnedUser(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_ASSIGNED_USER_ROLE_DTS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            
         
           cmdReadPayGrd.Parameters.Add("P_USERROLE", OracleDbType.Int32).Value = objEntity.UserRoleid;
           cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntity.UserId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void InsertChildRoles(List<clsEntity_UserRol_ChilDefntion> objEmp)
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

            foreach (clsEntity_UserRol_ChilDefntion objEntityEmp in objEmp)
            {
                string[] strArrEmpRole = objEntityEmp.UserRol.Split(',');
                string[] strArrAppId = objEntityEmp.UserAppId.Split(',');
                int i = 0;
                foreach (string strItem in strArrEmpRole)
                {
                    string strQueryRead = "USERROLE_ASSIGN.SP_INSERT_HCM_CHILDROLE_PROVSN";
                    using (OracleCommand cmdReadPayGrd = new OracleCommand())
                    {

                        cmdReadPayGrd.CommandText = strQueryRead;
                        cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                        cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.UserId;
                        cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.Employeeid;
                        cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntityEmp.ChildRole;
                        cmdReadPayGrd.Parameters.Add("P_TEMSTS", OracleDbType.Int32).Value = objEntityEmp.UserRolTempSts;
                   
                        cmdReadPayGrd.Parameters.Add("P_USERROLE", OracleDbType.Int32).Value = strItem;
                        cmdReadPayGrd.Parameters.Add("P_APPID", OracleDbType.Int32).Value =Convert.ToInt32(strArrAppId[i]);
                        i++;
                        clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                    }

                    if (objEntityEmp.InsUpdSta == 0)
                    {

                        string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_INSERT_GN_USER_ROLES";
                        using (OracleCommand cmdReadPayGrd = new OracleCommand())
                        {

                            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.UserId;
                            cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.Employeeid;
                            cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Varchar2).Value = objEntityEmp.ChildRole.ToString();
                             cmdReadPayGrd.Parameters.Add("P_USERROLE", OracleDbType.Int32).Value = strItem;
                           
                            clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                        }
                    }
                    else
                    {
                        if (objEntityEmp.UserRolTempSts == 1)
                        {
                            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_UPDATE_GN_USER_ROLES";
                            using (OracleCommand cmdReadPayGrd = new OracleCommand())
                            {

                                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.UserId;
                                cmdReadPayGrd.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.Employeeid;
                                cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntityEmp.ChildRole;
                                cmdReadPayGrd.Parameters.Add("P_USERROLE", OracleDbType.Int32).Value = strItem;

                                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                            }
                        }

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



        public DataTable ReadUserFromChildRolProvsn(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_USERCHLD_ROLE_PROV";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.UserId;
              cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntity.ChildRole;
           // cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = objCommon.;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void UserRolesDeleteByAssgnUserid(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_DEL_USERCHLD_ROLE_PROV";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
               // OracleCommand cmdReadPayGrd = new OracleCommand();
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.Employeeid;
                cmdReadPayGrd.Parameters.Add("P_CHILDROLE", OracleDbType.Int32).Value = objEntity.ChildRole;
                cmdReadPayGrd.Parameters.Add("P_ASSGNUSERID", OracleDbType.Int32).Value = objEntity.AssgnUserid;

                cmdReadPayGrd.Parameters.Add("P_ASSGNUSRROL", OracleDbType.Int32).Value = objEntity.AssgnUsrRol;
                cmdReadPayGrd.Parameters.Add("P_ASSGNTMP", OracleDbType.Int32).Value = objEntity.AssgnTempSts;
            
                // cmdReadPayGrd.Parameters.Add("P_ALLBUSS_CHK", OracleDbType.Int32).Value = objCommon.;
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }


       
        public DataTable ReadUserRolProvsn(clsEntity_UserRol_ChilDefntion objEntity)
        {
            string strQueryReadPayGrd = "USERROLE_ASSIGN.SP_READ_USER_PROV_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.UserId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
       
       
    }
}
