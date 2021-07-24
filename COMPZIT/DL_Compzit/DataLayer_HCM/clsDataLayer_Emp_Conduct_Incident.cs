using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using CL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Emp_Conduct_Incident
    {
        //INSERT CONDUCT INCIDENT DETAILS
        public void InsertConductIncident(clsEntity_Emp_conduct_Incident objEntityConductIncident)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                  
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONDUCT_INCIDENT_REF);
                    objEntityCommon.CorporateID = objEntityConductIncident.CorpId;
                    objEntityCommon.Organisation_Id = objEntityConductIncident.OrgId;
                    string strNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);


                    string strQueryInsertIncident = "EMP_CONDUCT_INCIDENT.SP_INSERT_CONDUCT_INCIDENT";
                    using (OracleCommand cmdInsertIncident = new OracleCommand())
                    {
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONDUCT_INCIDENT);
                        objEntCommon.CorporateID = objEntityConductIncident.CorpId;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityConductIncident.ConductIncident_Id = Convert.ToInt32(strNextNum);

                        cmdInsertIncident.Transaction = tran;
                        cmdInsertIncident.Connection = con;
                        cmdInsertIncident.CommandText = strQueryInsertIncident;
                        cmdInsertIncident.CommandType = CommandType.StoredProcedure;
                        cmdInsertIncident.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;
                        cmdInsertIncident.Parameters.Add("REFNO", OracleDbType.Varchar2).Value = objEntityConductIncident.REFNo;
                        cmdInsertIncident.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityConductIncident.OrgId;
                        cmdInsertIncident.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityConductIncident.CorpId;
                        if (objEntityConductIncident.DeptId != -1)
                            cmdInsertIncident.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objEntityConductIncident.DeptId;
                        else
                            cmdInsertIncident.Parameters.Add("DEPTID", OracleDbType.Int32).Value = null;
                        if (objEntityConductIncident.DivId != -1)
                            cmdInsertIncident.Parameters.Add("DIVID", OracleDbType.Int32).Value = objEntityConductIncident.DivId;
                        else
                            cmdInsertIncident.Parameters.Add("DIVID", OracleDbType.Int32).Value = null;
                        cmdInsertIncident.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityConductIncident.UsrId;
                        cmdInsertIncident.Parameters.Add("DESCRTN", OracleDbType.Varchar2).Value = objEntityConductIncident.IncidentDescripton;
                        cmdInsertIncident.Parameters.Add("ITYPE", OracleDbType.Int32).Value = objEntityConductIncident.IncidentType;

                        cmdInsertIncident.Parameters.Add("IDATE", OracleDbType.Date).Value = objEntityConductIncident.IncidentDate;
                        cmdInsertIncident.Parameters.Add("SEVER", OracleDbType.Int32).Value = objEntityConductIncident.Severity;
                        cmdInsertIncident.Parameters.Add("MEMO", OracleDbType.Int32).Value = objEntityConductIncident.MemoIssue;
                        if (objEntityConductIncident.CatgoryId != -1)
                            cmdInsertIncident.Parameters.Add("CATID", OracleDbType.Int32).Value = objEntityConductIncident.CatgoryId;
                        else
                            cmdInsertIncident.Parameters.Add("CATID", OracleDbType.Int32).Value = null;
                        cmdInsertIncident.Parameters.Add("CATRESON", OracleDbType.Varchar2).Value = objEntityConductIncident.CatgoryReson;
                        cmdInsertIncident.Parameters.Add("MAILNOT", OracleDbType.Int32).Value = objEntityConductIncident.MailNotify;
                        cmdInsertIncident.Parameters.Add("NOTIFY", OracleDbType.Int32).Value = objEntityConductIncident.OfficierNotify;
                        cmdInsertIncident.Parameters.Add("NOTIFYEMP", OracleDbType.Int32).Value = objEntityConductIncident.Employee;

                        cmdInsertIncident.Parameters.Add("INSU_ID", OracleDbType.Int32).Value = objEntityConductIncident.UserId;

                        cmdInsertIncident.Parameters.Add("INS_DATE", OracleDbType.Date).Value = objEntityConductIncident.InsertDate;
                        if (objEntityConductIncident.BussnessUnit != -1)
                            cmdInsertIncident.Parameters.Add("BUNSS_ID", OracleDbType.Int32).Value = objEntityConductIncident.BussnessUnit;
                        else
                            cmdInsertIncident.Parameters.Add("BUNSS_ID", OracleDbType.Int32).Value = null;
                     
                        clsDataLayer.ExecuteNonQuery(cmdInsertIncident);
                    }
                    //string strQueryInsertIncidentDtl = "EMP_CONDUCT_INCIDENT.SP_INSERT_CNDCTSUBDTLS";
                    //    using (OracleCommand cmdInsertIncidentDtl = new OracleCommand())
                    //    {
                    //        cmdInsertIncidentDtl.Transaction = tran;
                    //        cmdInsertIncidentDtl.Connection = con;
                    //        cmdInsertIncidentDtl.CommandText = strQueryInsertIncidentDtl;
                    //        cmdInsertIncidentDtl.CommandType = CommandType.StoredProcedure;
                    //        cmdInsertIncidentDtl.Parameters.Add("STATUS", OracleDbType.Int32).Value = objEntityConductIncident.ReplyExpln;
                    //           cmdInsertIncidentDtl.Parameters.Add("MSG", OracleDbType.Varchar2).Value = objEntityConductIncident.Message;
                    //        cmdInsertIncidentDtl.Parameters.Add("MSG_DATE", OracleDbType.Date).Value = objEntityConductIncident.InsertDate;
                    //        cmdInsertIncidentDtl.Parameters.Add("INC_ID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;
                    //        clsDataLayer.ExecuteNonQuery(cmdInsertIncidentDtl);
                    //    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                }
            }
        }
        //UPDATE CONDUCT INCIDENT DETAILS
        public void Update_ConductIncident(clsEntity_Emp_conduct_Incident objEntityConductIncident)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdUpdateIncident = new OracleCommand())
                    {
                        string strQueryUpdateIncident = "EMP_CONDUCT_INCIDENT.SP_UPDATE_CONDUCT_INCIDENT";
                        cmdUpdateIncident.Transaction = tran;
                        cmdUpdateIncident.Connection = con;
                        cmdUpdateIncident.CommandText = strQueryUpdateIncident;
                        cmdUpdateIncident.CommandType = CommandType.StoredProcedure;
                        cmdUpdateIncident.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;
                        cmdUpdateIncident.Parameters.Add("REFNO", OracleDbType.Varchar2).Value = objEntityConductIncident.REFNo;
                        cmdUpdateIncident.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityConductIncident.OrgId;
                        cmdUpdateIncident.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityConductIncident.CorpId;
                        if (objEntityConductIncident.DeptId != -1)
                            cmdUpdateIncident.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objEntityConductIncident.DeptId;
                        else
                            cmdUpdateIncident.Parameters.Add("DEPTID", OracleDbType.Int32).Value = null;
                        if (objEntityConductIncident.DivId != -1)
                            cmdUpdateIncident.Parameters.Add("DIVID", OracleDbType.Int32).Value = objEntityConductIncident.DivId;
                        else
                            cmdUpdateIncident.Parameters.Add("DIVID", OracleDbType.Int32).Value = null;
                        cmdUpdateIncident.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityConductIncident.UsrId;
                        cmdUpdateIncident.Parameters.Add("DESCRTN", OracleDbType.Varchar2).Value = objEntityConductIncident.IncidentDescripton;
                        cmdUpdateIncident.Parameters.Add("ITYPE", OracleDbType.Int32).Value = objEntityConductIncident.IncidentType;

                        cmdUpdateIncident.Parameters.Add("IDATE", OracleDbType.Date).Value = objEntityConductIncident.IncidentDate;
                        cmdUpdateIncident.Parameters.Add("SEVER", OracleDbType.Int32).Value = objEntityConductIncident.Severity;
                        cmdUpdateIncident.Parameters.Add("MEMO", OracleDbType.Int32).Value = objEntityConductIncident.MemoIssue;
                        if (objEntityConductIncident.CatgoryId != -1)
                            cmdUpdateIncident.Parameters.Add("CATID", OracleDbType.Int32).Value = objEntityConductIncident.CatgoryId;
                        else
                            cmdUpdateIncident.Parameters.Add("CATID", OracleDbType.Int32).Value = null;
                        cmdUpdateIncident.Parameters.Add("CATRESON", OracleDbType.Varchar2).Value = objEntityConductIncident.CatgoryReson;
                        cmdUpdateIncident.Parameters.Add("MAILNOT", OracleDbType.Int32).Value = objEntityConductIncident.MailNotify;
                        cmdUpdateIncident.Parameters.Add("NOTIFY", OracleDbType.Int32).Value = objEntityConductIncident.OfficierNotify;
                        cmdUpdateIncident.Parameters.Add("NOTIFYEMP", OracleDbType.Int32).Value = objEntityConductIncident.Employee;
                        cmdUpdateIncident.Parameters.Add("INSU_ID", OracleDbType.Int32).Value = objEntityConductIncident.UserId;

                        cmdUpdateIncident.Parameters.Add("INS_DATE", OracleDbType.Date).Value = objEntityConductIncident.InsertDate; 
                        if (objEntityConductIncident.BussnessUnit != -1)
                            cmdUpdateIncident.Parameters.Add("BUNSS_ID", OracleDbType.Int32).Value = objEntityConductIncident.BussnessUnit;
                        else
                            cmdUpdateIncident.Parameters.Add("BUNSS_ID", OracleDbType.Int32).Value = null; 
                      
                        clsDataLayer.ExecuteNonQuery(cmdUpdateIncident);
                    }
                    //using (OracleCommand cmdUpdateIncidentDtl = new OracleCommand())
                    //{
                    //    string strQueryUpdateIncidentDtl = "EMP_CONDUCT_INCIDENT.SP_UPDATE_CNDCTSUBDTLS";
                    //    cmdUpdateIncidentDtl.Transaction = tran;
                    //    cmdUpdateIncidentDtl.Connection = con;
                    //    cmdUpdateIncidentDtl.CommandText = strQueryUpdateIncidentDtl;
                    //    cmdUpdateIncidentDtl.CommandType = CommandType.StoredProcedure;
                    //    cmdUpdateIncidentDtl.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityConductIncident.UserId;
                    //    cmdUpdateIncidentDtl.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;
                    //    cmdUpdateIncidentDtl.Parameters.Add("STATUS", OracleDbType.Int32).Value = objEntityConductIncident.ReplyExpln;
                    //    cmdUpdateIncidentDtl.Parameters.Add("RECEIVE", OracleDbType.Int32).Value = objEntityConductIncident.RecieveOrNot;
                    //    cmdUpdateIncidentDtl.Parameters.Add("MSG", OracleDbType.Int32).Value = objEntityConductIncident.Message;
                    //    cmdUpdateIncidentDtl.Parameters.Add("MSG_DATE", OracleDbType.Int32).Value = objEntityConductIncident.InsertDate;
                    //    cmdUpdateIncidentDtl.Parameters.Add("INC_ID", OracleDbType.Int32).Value = objEntityConductIncident.IncidentDate;
                    //    clsDataLayer.ExecuteNonQuery(cmdUpdateIncidentDtl);
                    //    //cmdUpdateIncidentDtl.ExecuteNonQuery();
                    //}
                    if (objEntityConductIncident.Message != "")
                    {
                        string strQueryInsertIncidentDtl = "EMP_CONDUCT_INCIDENT.SP_INSERT_CNDCTSUBDTLS";
                        using (OracleCommand cmdInsertIncidentDtl = new OracleCommand())
                        {
                            cmdInsertIncidentDtl.Transaction = tran;
                            cmdInsertIncidentDtl.Connection = con;
                            cmdInsertIncidentDtl.CommandText = strQueryInsertIncidentDtl;
                            cmdInsertIncidentDtl.CommandType = CommandType.StoredProcedure;

                            cmdInsertIncidentDtl.Parameters.Add("MSG", OracleDbType.Varchar2).Value = objEntityConductIncident.Message;
                            cmdInsertIncidentDtl.Parameters.Add("MSG_DATE", OracleDbType.Date).Value = objEntityConductIncident.InsertDate;
                            cmdInsertIncidentDtl.Parameters.Add("INC_ID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;
                            clsDataLayer.ExecuteNonQuery(cmdInsertIncidentDtl);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public DataTable LoadBissnusUnit(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_BUSINESS_UNIT";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable LoadDepartment(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CORP_DEP";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("E_BUSSNSSID", OracleDbType.Int32).Value = objEntity.BussnessUnit;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable LoadDivision(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CORP_DIVISION";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("DEPID", OracleDbType.Int32).Value = objEntity.DeptId;
                cmdReadAcco.Parameters.Add("E_ALL_DIVISIONCHK", OracleDbType.Int32).Value = objEntity.AllDivisionChk;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable LoadEmployee(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_EMPLOYEES";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("DEPID", OracleDbType.Int32).Value = objEntity.DeptId;
                cmdReadAcco.Parameters.Add("E_ALL_DIVISIONCHK", OracleDbType.Int32).Value = objEntity.AllDivisionChk;
                if (objEntity.DivId == -1)
                {
                    cmdReadAcco.Parameters.Add("E_DIVID", OracleDbType.Int32).Value = null;
                }
                else {
                    cmdReadAcco.Parameters.Add("E_DIVID", OracleDbType.Int32).Value = objEntity.DivId;
                }
                cmdReadAcco.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = objEntity.DeptId;
                cmdReadAcco.Parameters.Add("E_BUSSID", OracleDbType.Int32).Value = objEntity.BussnessUnit;

                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable LoadCategoery(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CONDUCT_CATEGORY";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable LoadCategoryDescrption(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CATEGORY_DESCRP";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("CATGRY_ID", OracleDbType.Int32).Value = objEntity.CatgoryId;
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable ReadConductIncidentList(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CNDTINCT_MSTR_LIST";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                if (objEntity.BussnessUnit != -1)
                cmdReadAcco.Parameters.Add("E_BUSSUNIT", OracleDbType.Int32).Value = objEntity.BussnessUnit;
                else
                    cmdReadAcco.Parameters.Add("E_BUSSUNIT", OracleDbType.Int32).Value =null;
                if (objEntity.DeptId != -1)
                    cmdReadAcco.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objEntity.DeptId;
                else
                    cmdReadAcco.Parameters.Add("DEPTID", OracleDbType.Int32).Value = null;
                if (objEntity.DivId != -1)
                cmdReadAcco.Parameters.Add("DIVID", OracleDbType.Int32).Value = objEntity.DivId;
                else
                    cmdReadAcco.Parameters.Add("DIVID", OracleDbType.Int32).Value = null;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("E_ALLDIV_CHK", OracleDbType.Int32).Value = objEntity.AllDivisionChk;
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable ReadIncidentDetailsByid(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CNDTINCT_MSTR_BYID";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
              
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable ReadConductEmployee(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT.SP_READ_CONDUCT_EMPLOYEE";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("L_DM", OracleDbType.Int32).Value = objEntity.divisionManager;
                cmdReadAcco.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable readConductEmployeeById(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT.SP_READ_CONDUCT_EMPLY_BYID";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("L_CNDTINCID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
                cmdReadAcco.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable ReadMessage(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT.SP_READ_MSG";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;

                cmdReadAcco.Parameters.Add("L_CNDTINCID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
                cmdReadAcco.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public void InsertConductReplay(clsEntity_Emp_conduct_Incident objEntityConductIncident)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityConductIncident.Message != "")
                    {
                        string strQueryInsertIncident = "EMP_CONDUCT.SP_INSERT_CONDT_RPLY";
                        using (OracleCommand cmdInsertIncident = new OracleCommand())
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();


                            cmdInsertIncident.Transaction = tran;
                            cmdInsertIncident.Connection = con;
                            cmdInsertIncident.CommandText = strQueryInsertIncident;
                            cmdInsertIncident.CommandType = CommandType.StoredProcedure;

                            cmdInsertIncident.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityConductIncident.ReplyExpln;
                            cmdInsertIncident.Parameters.Add("L_MSG", OracleDbType.Varchar2).Value = objEntityConductIncident.Message;
                            cmdInsertIncident.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityConductIncident.InsertDate;
                            cmdInsertIncident.Parameters.Add("L_CNDTINC_ID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;

                            clsDataLayer.ExecuteNonQuery(cmdInsertIncident);
                        }
                    }

                    using (OracleCommand cmdInsertIncident = new OracleCommand())
                    {
                        string strQueryUpdateIncident = "EMP_CONDUCT.SP_UPDATE_CONDT_STS";
                        clsEntityCommon objEntCommon = new clsEntityCommon();

                        cmdInsertIncident.Transaction = tran;
                        cmdInsertIncident.Connection = con;
                        cmdInsertIncident.CommandText = strQueryUpdateIncident;
                        cmdInsertIncident.CommandType = CommandType.StoredProcedure;

                        cmdInsertIncident.Parameters.Add("L_CNDTINC_ID", OracleDbType.Int32).Value = objEntityConductIncident.ConductIncident_Id;

                        clsDataLayer.ExecuteNonQuery(cmdInsertIncident);
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }
        public DataTable ReadChatMessageByid(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_CNDCT_MESSG_BYID";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
              
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable ReadUsermail(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_EMP_MAIL_BYID";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("EMPID", OracleDbType.Int32).Value = objEntity.UsrId;
              
                 cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        public DataTable PdfEmployeeDetails(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_PDF_DATA";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }



        public void Confirm_ConductIncident(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_INS_CONFIRM";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                clsDataLayer.ExecuteNonQuery(cmdReadAcco);
            }
        }


        public void CloseConductIncident(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_INS_CLOSE_CONDUCT";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("CNDCTINDNTID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
                cmdReadAcco.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                clsDataLayer.ExecuteNonQuery(cmdReadAcco);
            }
        }
        public void CancelMessageBox(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_CANCEL_MSG";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("INDNTSUBID", OracleDbType.Int32).Value = objEntity.ConductSubIncident_Id;
                clsDataLayer.ExecuteNonQuery(cmdReadAcco);
            }
        }

        public DataTable CancelNotPossible(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_CANCEL_NOT_POSSIBLE";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("INDNTSUBID", OracleDbType.Int32).Value = objEntity.ConductIncident_Id;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable TerminationNotPossible(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_TERMITN_CHK";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }

        public DataTable TerminationNotPossibleConfrm(clsEntity_Emp_conduct_Incident objEntity)
        {
            string strQueryReadAcco = "EMP_CONDUCT_INCIDENT.SP_READ_TERMITN_CHK";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntity.UserId;
                cmdReadAcco.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
    }
}
