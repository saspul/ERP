using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayer_InterView_Panel
    {
       public DataTable ReadDivision(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadDiv = "INTERVIEW_PANEL.SP_READ_DIVISION";
            OracleCommand cmdReadDiv = new OracleCommand();
            cmdReadDiv.CommandText = strQueryReadDiv;
            cmdReadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadDiv.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntrPanel.User_Id;
            cmdReadDiv.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityIntrPanel.Deprt_Id;
            cmdReadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDiv);
            return dtDivision;
        }
        public DataTable ReadDepartment(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadDep = "INTERVIEW_PANEL.SP_READ_DEPRTMNT";
            OracleCommand cmdReadDep = new OracleCommand();
            cmdReadDep.CommandText = strQueryReadDep;
            cmdReadDep.CommandType = CommandType.StoredProcedure;
            cmdReadDep.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadDep.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadDep.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntrPanel.User_Id;
            cmdReadDep.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDep);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadPrjct = "INTERVIEW_PANEL.SP_READ_PROJECT";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityIntrPanel.DivId;
            cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityIntrPanel.User_Id;
            cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }
        public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadMnpwr = "INTERVIEW_PANEL.SP_READ_MAN_PWRRQST_LIST";
            OracleCommand cmdReadManPwr = new OracleCommand();
            cmdReadManPwr.CommandText = strQueryReadMnpwr;
            cmdReadManPwr.CommandType = CommandType.StoredProcedure;

            cmdReadManPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadManPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadManPwr.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntrPanel.User_Id;
            cmdReadManPwr.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityIntrPanel.DivId;
            cmdReadManPwr.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityIntrPanel.Deprt_Id;
            cmdReadManPwr.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityIntrPanel.PrjctId;
            cmdReadManPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadManPwr);
            return dtCategory;
        }
        public DataTable ReadManPwrReqstById(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadPayGrd = "INTERVIEW_PANEL.SP_READ_MAN_PWRRQST_BY_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityIntrPanel.ManPwrRqstId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadInterviewTempData(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadPayGrd = "INTERVIEW_PANEL.SP_READ_INTERV_TEMP_DATA";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityIntrPanel.ManPwrRqstId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        // This Method will fetCH AL THE EMPLOYEE
        public DataTable ReadEmployee(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadEmployee = "INTERVIEW_PANEL.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmployee;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityIntrPanel.Organisation_Id;
            cmdReadEmp.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityIntrPanel.CorpOffice_Id;
            cmdReadEmp.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        // This Method will fetCH IF DATA IN INTERVIEW PANEL
        public DataTable ReadInterViewPanel(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadEmployee = "INTERVIEW_PANEL.SP_READ_PANEL_DATA_BY_RQST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmployee;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityIntrPanel.ManPwrRqstId;
            cmdReadEmp.Parameters.Add("P_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        // This Method will fetCH AL DATA OF INTERVIEW PANEL
        public DataTable ReadInterViewPanelDetail(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            string strQueryReadEmployee = "INTERVIEW_PANEL.SP_READ_PANEL_DETAIL_BY_TEMP";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmployee;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_PANELID", OracleDbType.Int32).Value = objEntityIntrPanel.IntrvPanelId;
            cmdReadEmp.Parameters.Add("P_TEMPDETID", OracleDbType.Int32).Value = objEntityIntrPanel.TemplateDetailId;
            cmdReadEmp.Parameters.Add("P_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtCategory;
        }

        public int Insert_Interv_Panel(clsEntityLayer_InterViewPanel objEntityPanel, List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetail)
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
                    string strQueryAddPanel = "INTERVIEW_PANEL.SP_INSERT_INTERVW_PANEL";
                    using (OracleCommand cmdInsertPanel = new OracleCommand(strQueryAddPanel, con))
                    {
                        cmdInsertPanel.Transaction = tran;

                        cmdInsertPanel.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_PANEL);
                        objEntCommon.CorporateID = objEntityPanel.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityPanel.IntrvPanelId = Convert.ToInt32(strNextNum);

                        cmdInsertPanel.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPanel.IntrvPanelId;
                        cmdInsertPanel.Parameters.Add("P_RQST", OracleDbType.Int32).Value = objEntityPanel.ManPwrRqstId;
                        cmdInsertPanel.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objEntityPanel.TemplateId;
                        cmdInsertPanel.Parameters.Add("P_CORPID ", OracleDbType.Int32).Value = objEntityPanel.CorpOffice_Id;
                        cmdInsertPanel.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPanel.Organisation_Id;
                        cmdInsertPanel.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPanel.User_Id;
                        cmdInsertPanel.ExecuteNonQuery();

                    }
                    //insert to  Detail table
                    foreach (clsEntityLayer_InterViewPanel_Dtl objDetail in objEntityPanelDetail)
                    {

                        string strQueryInsertDetail = "INTERVIEW_PANEL.SP_INSERT_INTRV_PANEL_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPanel.IntrvPanelId;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objEntityPanel.TemplateId;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPDTLID", OracleDbType.Int32).Value = objEntityPanel.TemplateDetailId;
                            cmdAddInsertDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objDetail.EmpId;
                            cmdAddInsertDetail.Parameters.Add("P_STS_ID", OracleDbType.Int32).Value = objDetail.DfltStsId;
                            cmdAddInsertDetail.Parameters.Add("P_CORPID ", OracleDbType.Int32).Value = objEntityPanel.CorpOffice_Id;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return objEntityPanel.IntrvPanelId;
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }


        public void Update_Interv_Panel(List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailAdd, List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailUpdate)
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

                    //insert to  Detail table
                    foreach (clsEntityLayer_InterViewPanel_Dtl objDetail in objEntityPanelDetailAdd)
                    {

                        if (objDetail.DfltStsId==1)
                        {
                            string strQueryInsertDflt = "INTERVIEW_PANEL.SP_INSERT_DEL_DFLT";
                            using (OracleCommand cmdAddInsertDflt = new OracleCommand(strQueryInsertDflt, con))
                            {
                                cmdAddInsertDflt.Transaction = tran;
                                cmdAddInsertDflt.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDflt.Parameters.Add("P_ID", OracleDbType.Int32).Value = objDetail.Panelid;
                                cmdAddInsertDflt.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objDetail.TempId;
                                cmdAddInsertDflt.Parameters.Add("P_TEMPDTLID", OracleDbType.Int32).Value = objDetail.TempDtlId;
                                cmdAddInsertDflt.ExecuteNonQuery();
                            }

                        }


                        string strQueryInsertDetail = "INTERVIEW_PANEL.SP_INSERT_INTRV_PANEL_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objDetail.Panelid;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPDTLID", OracleDbType.Int32).Value = objDetail.TempDtlId;
                            cmdAddInsertDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objDetail.EmpId;
                            cmdAddInsertDetail.Parameters.Add("P_STS_ID", OracleDbType.Int32).Value = objDetail.DfltStsId;
                            cmdAddInsertDetail.Parameters.Add("P_CORPID ", OracleDbType.Int32).Value = objDetail.CorpId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    //insert to  Detail table
                    foreach (clsEntityLayer_InterViewPanel_Dtl objDetail in objEntityPanelDetailUpdate)
                    {

                        if (objDetail.DfltStsId == 1)
                        {
                            string strQueryInsertDflt = "INTERVIEW_PANEL.SP_INSERT_DEL_DFLT";
                            using (OracleCommand cmdAddInsertDflt = new OracleCommand(strQueryInsertDflt, con))
                            {
                                cmdAddInsertDflt.Transaction = tran;
                                cmdAddInsertDflt.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDflt.Parameters.Add("P_ID", OracleDbType.Int32).Value = objDetail.Panelid;
                                cmdAddInsertDflt.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objDetail.TempId;
                                cmdAddInsertDflt.Parameters.Add("P_TEMPDTLID", OracleDbType.Int32).Value = objDetail.TempDtlId;
                                cmdAddInsertDflt.ExecuteNonQuery();
                            }

                        }

                        string strQueryInsertDetail = "INTERVIEW_PANEL.SP_UPDATE_INTRV_PANEL_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objDetail.Panelid;
                            cmdAddInsertDetail.Parameters.Add("PDTL_ID", OracleDbType.Int32).Value = objDetail.PanelDtlId;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("P_TEMPDTLID", OracleDbType.Int32).Value = objDetail.TempDtlId;
                            cmdAddInsertDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objDetail.EmpId;
                            cmdAddInsertDetail.Parameters.Add("P_STS_ID", OracleDbType.Int32).Value = objDetail.DfltStsId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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

        public void Delete_Interv_Panel(List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailDel)
        {
            foreach (clsEntityLayer_InterViewPanel_Dtl objDetail in objEntityPanelDetailDel)
            {
                string strQueryDel = "INTERVIEW_PANEL.SP_DELETE_PANEL_DTL";
                OracleCommand cmdDelpan = new OracleCommand();
                cmdDelpan.CommandText = strQueryDel;
                cmdDelpan.CommandType = CommandType.StoredProcedure;
                cmdDelpan.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objDetail.PanelDtlId;
                clsDataLayer.ExecuteNonQuery(cmdDelpan);
            }
        }
    }
}
