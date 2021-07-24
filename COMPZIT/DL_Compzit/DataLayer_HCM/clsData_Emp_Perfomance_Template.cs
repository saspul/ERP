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
    public class clsData_Emp_Perfomance_Template
    {
        public void InsertPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPerfomanceTemplate, List<clsEntity_Emp_perfomance_Template> objSaveTempList, List<clsEntity_Emp_perfomance_Template> objEntityPerfomListGrps)
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
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_REF);
                    objEntityCommon.CorporateID = objEntityPerfomanceTemplate.CorpId;
                    objEntityCommon.Organisation_Id = objEntityPerfomanceTemplate.OrgId;
                    string strNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                  //  objEntityPerfomanceTemplate.PerfomanceId =Convert.ToInt32(strNextId);

                    string strQueryInsertIncident = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_INSERT_PRFMNC_TMPLTE";
                    using (OracleCommand cmdInsertIncident = new OracleCommand())
                    {

                     
                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE);
                        objEntityCommon.CorporateID = objEntityPerfomanceTemplate.CorpId;
                        objEntityCommon.Organisation_Id = objEntityPerfomanceTemplate.OrgId;
                        string strNextIdPER = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                        objEntityPerfomanceTemplate.PerfomanceId = Convert.ToInt32(strNextIdPER);

                        cmdInsertIncident.Transaction = tran;
                        cmdInsertIncident.Connection = con;
                        cmdInsertIncident.CommandText = strQueryInsertIncident;
                        cmdInsertIncident.CommandType = CommandType.StoredProcedure;
                        cmdInsertIncident.Parameters.Add("PRFMNCID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                        cmdInsertIncident.Parameters.Add("PRFMNCFRM", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.prfmncForm;
                        cmdInsertIncident.Parameters.Add("REFNO", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.REFNo;
                        cmdInsertIncident.Parameters.Add("PRFMNCNOTE", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.prfmncNote;
                        cmdInsertIncident.Parameters.Add("PRFMNCRATING", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.Rating;
                        cmdInsertIncident.Parameters.Add("PRFMNCSTS", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.Status;
                        cmdInsertIncident.Parameters.Add("INS_USR_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.UsrId;
                        cmdInsertIncident.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.OrgId;
                        cmdInsertIncident.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.CorpId;

                        cmdInsertIncident.ExecuteNonQuery(); 

                      //  clsDataLayer.ExecuteNonQuery(cmdInsertIncident);
                    }

                    foreach (clsEntity_Emp_perfomance_Template objSubDetailGrp in objEntityPerfomListGrps)
                    {
                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_GRP);
                        objEntityCommon.CorporateID = objEntityPerfomanceTemplate.CorpId;
                        objEntityCommon.Organisation_Id = objEntityPerfomanceTemplate.OrgId;
                        string strNextIdGrp = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                        objSubDetailGrp.GrpId = Convert.ToInt32(strNextIdGrp);


                        string strQuerySubDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_INSERT_PERFTEM_GRP";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                            cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                            cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                            cmdAddSubDetail.Parameters.Add("GRPID_NAME", OracleDbType.Varchar2).Value = objSubDetailGrp.GrpName;

                            cmdAddSubDetail.ExecuteNonQuery();
                        }


                        foreach (clsEntity_Emp_perfomance_Template objSubDetail in objSaveTempList)
                        {

                            if (objSubDetailGrp.GrpName == objSubDetail.GrpName)
                            {
                                string strQuerySubQstnDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_INSERT_PERFTEM_QUESTN";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubQstnDetails, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                    cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                                    cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                                    cmdAddSubDetail.Parameters.Add("QSTN_NAME", OracleDbType.Varchar2).Value = objSubDetail.QstnText;
                                    cmdAddSubDetail.Parameters.Add("KPI_TEXT", OracleDbType.Varchar2).Value = objSubDetail.KpiText;
                                    cmdAddSubDetail.Parameters.Add("RATSCALE_ID", OracleDbType.Int32).Value = objSubDetail.RateSclaeId;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                            }
                        }

                    }

             
                    //    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        public void UpdatePerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPerfomanceTemplate,List<clsEntity_Emp_perfomance_Template> objSaveTemp, List<clsEntity_Emp_perfomance_Template> objEntityPerfomListGrps, string[] strarrCancldtlIdsQst, string[] strarrCancldtlIdsGrp)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                  

                    string strQueryInsertIncident = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_UPDATE_PRFMNC_TMPLTE";
                    using (OracleCommand cmdInsertIncident = new OracleCommand())
                    {
                         cmdInsertIncident.Transaction = tran;
                        cmdInsertIncident.Connection = con;
                        cmdInsertIncident.CommandText = strQueryInsertIncident;
                        cmdInsertIncident.CommandType = CommandType.StoredProcedure;
                        cmdInsertIncident.Parameters.Add("PRFMNCID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                        cmdInsertIncident.Parameters.Add("PRFMNCFRM", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.prfmncForm;
                        cmdInsertIncident.Parameters.Add("REFNO", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.REFNo;
                        cmdInsertIncident.Parameters.Add("PRFMNCNOTE", OracleDbType.Varchar2).Value = objEntityPerfomanceTemplate.prfmncNote;
                        cmdInsertIncident.Parameters.Add("PRFMNCRATING", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.Rating;
                        cmdInsertIncident.Parameters.Add("PRFMNCSTS", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.Status;
                        cmdInsertIncident.Parameters.Add("UPD_USR_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.UsrId;
                        cmdInsertIncident.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.OrgId;
                        cmdInsertIncident.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.CorpId;



                        cmdInsertIncident.ExecuteNonQuery();
                    }



                    foreach (clsEntity_Emp_perfomance_Template objSubDetailGrp in objEntityPerfomListGrps)
                    {
                        if (objSubDetailGrp.EventText == "INS")
                        {
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_GRP);
                            objEntityCommon.CorporateID = objEntityPerfomanceTemplate.CorpId;
                            objEntityCommon.Organisation_Id = objEntityPerfomanceTemplate.OrgId;
                            string strNextIdGrp = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                            objSubDetailGrp.GrpId = Convert.ToInt32(strNextIdGrp);


                            string strQuerySubDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_INSERT_PERFTEM_GRP";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                                cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                                cmdAddSubDetail.Parameters.Add("GRPID_NAME", OracleDbType.Varchar2).Value = objSubDetailGrp.GrpName;

                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string strQuerySubDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_UPDATE_PERFTEM_GRP";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                                cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                                cmdAddSubDetail.Parameters.Add("GRPID_NAME", OracleDbType.Varchar2).Value = objSubDetailGrp.GrpName;

                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        
                        }


                        foreach (clsEntity_Emp_perfomance_Template objSubDetail in objSaveTemp)
                        {

                            if (objSubDetailGrp.GrpName == objSubDetail.GrpName)
                            {
                                if (objSubDetail.EventText == "INS")
                                {

                                    string strQuerySubQstnDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_INSERT_PERFTEM_QUESTN";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubQstnDetails, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                        cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                                        cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                                        cmdAddSubDetail.Parameters.Add("QSTN_NAME", OracleDbType.Varchar2).Value = objSubDetail.QstnText;
                                        cmdAddSubDetail.Parameters.Add("KPI_TEXT", OracleDbType.Varchar2).Value = objSubDetail.KpiText;
                                        cmdAddSubDetail.Parameters.Add("RATSCALE_ID", OracleDbType.Int32).Value = objSubDetail.RateSclaeId;
                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }
                                }
                                else
                                {

                                    string strQuerySubQstnDetails = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_UPDATE_PERFTEM_QUESTN";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubQstnDetails, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                        cmdAddSubDetail.Parameters.Add("PERFTEMPID_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.PerfomanceId;
                                        cmdAddSubDetail.Parameters.Add("GRPID_ID", OracleDbType.Int32).Value = objSubDetailGrp.GrpId;
                                        cmdAddSubDetail.Parameters.Add("QSTN_NAME", OracleDbType.Varchar2).Value = objSubDetail.QstnText;
                                        cmdAddSubDetail.Parameters.Add("KPI_TEXT", OracleDbType.Varchar2).Value = objSubDetail.KpiText;
                                        cmdAddSubDetail.Parameters.Add("RATSCALE_ID", OracleDbType.Int32).Value = objSubDetail.RateSclaeId;
                                        cmdAddSubDetail.Parameters.Add("QSTN_ID", OracleDbType.Int32).Value = objSubDetail.QstnId;
                                        
                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }
                                }

                            }
                        }

                    }

                    //Cancel the rows that have been cancelled when editing in Detail table(QUESTIONS)
                    foreach (string strDtlId in strarrCancldtlIdsQst)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_CANCEL_PERFTEM_QUESTN";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;

                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                             
                                cmdCancelDetail.Parameters.Add("P_QSTN_ID", OracleDbType.Int32).Value = intDtlId;
                                cmdCancelDetail.Parameters.Add("UPD_USR_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.UsrId;
                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
                    }


                    //Cancel the rows that have been cancelled when editing in Detail table(GROUPS)
                    foreach (string strDtlId in strarrCancldtlIdsGrp)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_CANCEL_PERFTEM_GROUP";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;

                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;

                                cmdCancelDetail.Parameters.Add("P_GROUP_ID", OracleDbType.Int32).Value = intDtlId;
                                cmdCancelDetail.Parameters.Add("UPD_USR_ID", OracleDbType.Int32).Value = objEntityPerfomanceTemplate.UsrId;
                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
                    }


                    //    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        public DataTable ReadPerfomanceTemplateList(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            DataTable dtReadPrfmcTmplt = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_READ_PRFMNC_TMPLTE_lIST";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("CNCL_STS", OracleDbType.Int32).Value = objEntityPermne_tmplt.cnclStatus;
              
                cmdReadPerfmncTmplt.Parameters.Add("STATIS", OracleDbType.Int32).Value = objEntityPermne_tmplt.ActStatus;
                cmdReadPerfmncTmplt.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcTmplt;
        }
        public DataTable ReadPerfomanceByIdByid(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            DataTable dtReadPrfmcTmplt = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_READ_PRFMNC_TMPLTE_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_PRFM_ID", OracleDbType.Int32).Value = objEntityPermne_tmplt.PerfomanceId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcTmplt;
        }

        public void CancelPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            string strQueryMemoRsnCncl = " HCM_EMP_PERFOMANCE_TEMPLATE.SP_CANCEL_PRFMNC_TMPLT";
            using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
            {
                cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
                cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdPerfmncTmplt.Parameters.Add("PRFMNCID", OracleDbType.Int32).Value = objEntityPermne_tmplt.PerfomanceId;
                cmdPerfmncTmplt.Parameters.Add("CNCL_USR_ID", OracleDbType.Int32).Value = objEntityPermne_tmplt.UsrId;
                cmdPerfmncTmplt.Parameters.Add("P_RSN_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityPermne_tmplt.CnclRsn;
                clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
            }
        }



        public DataTable ReadPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            DataTable dtReadPrfmcTmplt = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_READ_PRFMNC_TMPLTE";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
                //cmdReadPerfmncTmplt.Parameters.Add("P_PRFM_ID", OracleDbType.Int32).Value = objEntityPermne_tmplt.PerfomanceId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcTmplt;
        }

        public DataTable ReadGrupsandQstnById(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            DataTable dtReadPrfmcTmplt = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_READ_GRPS_QSTNS_BIID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_PRFM_ID", OracleDbType.Int32).Value = objEntityPermne_tmplt.PerfomanceId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcTmplt;
        }

        public DataTable DuplicationCheckGrp(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
        {
            DataTable dtReadPrfmcTmplt = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_TEMPLATE.SP_READ_GRP_NAME_DUPCHK";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_tmplt.GrpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_GRP_NAME", OracleDbType.Varchar2).Value = objEntityPermne_tmplt.GrpName;
                cmdReadPerfmncTmplt.Parameters.Add("P_TEMP_ID", OracleDbType.Varchar2).Value = objEntityPermne_tmplt.prfmncForm;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcTmplt;
        }
        

        
    }
}
