using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:15/03/2015
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit
{
    public class clsDataLayerTeamHierarchy
    {

        //Method TO READ ALL USER IN CORESSPONDING ORGANIZATION AND CORPORATE FOR TEAM LEAD
        public DataTable ReadUsersForTeamLead(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadLeader = "TEAM_HIERARCHY.SP_READ_TEAMLEAD";
            using (OracleCommand cmdReadLeader = new OracleCommand())
            {
                cmdReadLeader.CommandText = strQueryReadLeader;
                cmdReadLeader.CommandType = CommandType.StoredProcedure;
                cmdReadLeader.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                cmdReadLeader.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                cmdReadLeader.Parameters.Add("T_SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityTeamHierarchy.SearchText;

                cmdReadLeader.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeader = new DataTable();
                dtLeader = clsDataLayer.SelectDataTable(cmdReadLeader);
                return dtLeader;
            }
        }
        //Method  TO READ ALL DIVISION IN CORESSPONDING ORGANIZATION AND CORPORATE FOR SOR SEARCHING
        public DataTable ReadDivision(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadDivsion = "TEAM_HIERARCHY.SP_READ_DIVISION";
            using (OracleCommand cmdReadDivsn = new OracleCommand())
            {
                cmdReadDivsn.CommandText = strQueryReadDivsion;
                cmdReadDivsn.CommandType = CommandType.StoredProcedure;
                cmdReadDivsn.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                cmdReadDivsn.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                cmdReadDivsn.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDivsn = new DataTable();
                dtDivsn = clsDataLayer.SelectDataTable(cmdReadDivsn);
                return dtDivsn;
            }
        }

        //Method TO READ ALL USER IN CORESSPONDING ORGANIZATION AND CORPORATE FOR TEAM MEMBERS EXCEPT THE SELECTED TEAM LEAD
        public DataTable ReadUsersForMember(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadMembers = "TEAM_HIERARCHY.SP_READ_MEMBERS";
            using (OracleCommand cmdReadMembers = new OracleCommand())
            {
                cmdReadMembers.CommandText = strQueryReadMembers;
                cmdReadMembers.CommandType = CommandType.StoredProcedure;
                cmdReadMembers.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                cmdReadMembers.Parameters.Add("TLEAD_USERID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamLeadEmp_Id;
                cmdReadMembers.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                cmdReadMembers.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                cmdReadMembers.Parameters.Add("T_DIVSNID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Divsnid;
                cmdReadMembers.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMembers = new DataTable();
                dtMembers = clsDataLayer.SelectDataTable(cmdReadMembers);
                return dtMembers;
            }
        }

        // This Method checks Team name in the database for duplication.
        public string CheckTeamName(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {

            string strQueryCheckName = "TEAM_HIERARCHY.SP_CHECK_TEAM_NAME";
            OracleCommand cmdCheckName = new OracleCommand();
            cmdCheckName.CommandText = strQueryCheckName;
            cmdCheckName.CommandType = CommandType.StoredProcedure;
            cmdCheckName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
            cmdCheckName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTeamHierarchy.TeamName;
            cmdCheckName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
            cmdCheckName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
            cmdCheckName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckName);
            string strReturn = cmdCheckName.Parameters["T_COUNT"].Value.ToString();
            cmdCheckName.Dispose();
            return strReturn;
        }

        //insert Team details to  table
        public void InsertTeamDetail(clsEntityLayerTeamHierarchy objEntityTeamHierarchy, List<clsEntityLayerTeamMember> objEntityTeamMemberDetails)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();

            string strQueryInsertTeam = "TEAM_HIERARCHY.SP_INSERT_TEAM_MASTER";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertTeam = new OracleCommand(strQueryInsertTeam, con))
                    {
                        cmdInsertTeam.Transaction = tran;

                        cmdInsertTeam.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TEAM_HIERARCHY);
                        objEntCommon.CorporateID = objEntityTeamHierarchy.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityTeamHierarchy.TeamId = Convert.ToInt32(strNextNum);
                        cmdInsertTeam.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                        cmdInsertTeam.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTeamHierarchy.TeamName;
                        cmdInsertTeam.Parameters.Add("T_LEAD_EMPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamLeadEmp_Id;
                        cmdInsertTeam.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTeamHierarchy.Status;
                        cmdInsertTeam.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                        cmdInsertTeam.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                        cmdInsertTeam.Parameters.Add("T_INSUSERID", OracleDbType.Int32).Value = objEntityTeamHierarchy.User_Id;
                        cmdInsertTeam.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTeamHierarchy.D_Date;
                        cmdInsertTeam.ExecuteNonQuery();

                    }
                    //insert to  register Detail table
                    foreach (clsEntityLayerTeamMember objDetail in objEntityTeamMemberDetails)
                    {

                        string strQueryInsertDetail = "TEAM_HIERARCHY.SP_INSERT_TEAM_MEMBERS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;

                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                            cmdAddInsertDetail.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                            cmdAddInsertDetail.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                            cmdAddInsertDetail.Parameters.Add("T_MEMBER_ID", OracleDbType.Int32).Value = objDetail.TeamMemberEmp_Id;

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
        //Method for read Team for list view.
        public DataTable ReadTeamList(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadList = "TEAM_HIERARCHY.SP_READ_TEAMLIST";
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = strQueryReadList;
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                cmdReadList.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                cmdReadList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityTeamHierarchy.Status;
                cmdReadList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityTeamHierarchy.Cancel_Status;
                cmdReadList.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtTeam = new DataTable();
                dtTeam = clsDataLayer.SelectDataTable(cmdReadList);
                return dtTeam;
            }
        }

        //Method for Cancel team from team master table so update cancel related fields
        public void Cancel_Team(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryCancel = "TEAM_HIERARCHY.SP_CANCEL_TEAM";
            OracleCommand cmdCancel = new OracleCommand();
            cmdCancel.CommandText = strQueryCancel;
            cmdCancel.CommandType = CommandType.StoredProcedure;
            cmdCancel.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
            cmdCancel.Parameters.Add("T_CANCEL_USERID", OracleDbType.Int32).Value = objEntityTeamHierarchy.User_Id;
            cmdCancel.Parameters.Add("T_CANCEL_DATE", OracleDbType.Date).Value = objEntityTeamHierarchy.D_Date;
            cmdCancel.Parameters.Add("T_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityTeamHierarchy.Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancel);
         
        }
        //Method for read Team by Team ID.
        public DataTable ReadTeamById(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadTeam = "TEAM_HIERARCHY.SP_READ_TEAM_BYID";
            using (OracleCommand cmdReadTeam = new OracleCommand())
            {
                cmdReadTeam.CommandText = strQueryReadTeam;
                cmdReadTeam.CommandType = CommandType.StoredProcedure;
                cmdReadTeam.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                cmdReadTeam.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtTeam = new DataTable();
                dtTeam = clsDataLayer.SelectDataTable(cmdReadTeam);
                return dtTeam;
            }
        }
        //Method for read Team Members by Team ID.
        public DataTable ReadTeamMembersById(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strQueryReadTeamMembers = "TEAM_HIERARCHY.SP_READ_TEAM_MEMBERS_BYTEAMID";
            using (OracleCommand cmdReadTeamMembers = new OracleCommand())
            {
                cmdReadTeamMembers.CommandText = strQueryReadTeamMembers;
                cmdReadTeamMembers.CommandType = CommandType.StoredProcedure;
                cmdReadTeamMembers.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                cmdReadTeamMembers.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtTeam = new DataTable();
                dtTeam = clsDataLayer.SelectDataTable(cmdReadTeamMembers);
                return dtTeam;
            }
        }



        //insert Team details to  table
        public void Update_TeamDetail(clsEntityLayerTeamHierarchy objEntityTeamHierarchy, List<clsEntityLayerTeamMember> objEntityTeamMemberDetails, bool blMemberEdited)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();

            string strQueryUpdTeam = "TEAM_HIERARCHY.SP_UPDATE_TEAM_MASTER";
            OracleTransaction tran;
            //Update to main team table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdUpdateTeam = new OracleCommand(strQueryUpdTeam, con))
                    {
                        cmdUpdateTeam.Transaction = tran;

                        cmdUpdateTeam.CommandType = CommandType.StoredProcedure;
                        cmdUpdateTeam.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                        cmdUpdateTeam.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTeamHierarchy.TeamName;
                        cmdUpdateTeam.Parameters.Add("T_LEAD_EMPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamLeadEmp_Id;
                        cmdUpdateTeam.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTeamHierarchy.Status;
                        cmdUpdateTeam.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                        cmdUpdateTeam.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                        cmdUpdateTeam.Parameters.Add("T_UPDUSERID", OracleDbType.Int32).Value = objEntityTeamHierarchy.User_Id;
                        cmdUpdateTeam.Parameters.Add("T_UPDDATE", OracleDbType.Date).Value = objEntityTeamHierarchy.D_Date;
                        cmdUpdateTeam.ExecuteNonQuery();

                    }

                    // for checking if any editing done for members or not.This is if when editing team name only or team lead only without adding or removing team members then no need to delete and enter all again
                    //else delete all members and add again
                    if (blMemberEdited == true)
                    {
                        string strQueryDeleteMemberDetail = "TEAM_HIERARCHY.SP_DELETE_TEAM_MEMBERS";
                        using (OracleCommand cmdDeleteMember = new OracleCommand(strQueryDeleteMemberDetail, con))
                        {
                            cmdDeleteMember.Transaction = tran;

                            cmdDeleteMember.CommandType = CommandType.StoredProcedure;
                            cmdDeleteMember.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                            cmdDeleteMember.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                            cmdDeleteMember.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                            cmdDeleteMember.ExecuteNonQuery();
                        }
                        //insert to  register Detail table
                        foreach (clsEntityLayerTeamMember objDetail in objEntityTeamMemberDetails)
                        {

                            string strQueryInsertDetail = "TEAM_HIERARCHY.SP_INSERT_TEAM_MEMBERS";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;

                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTeamHierarchy.TeamId;
                                cmdAddInsertDetail.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTeamHierarchy.CorpOffice_Id;
                                cmdAddInsertDetail.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTeamHierarchy.Organisation_Id;
                                cmdAddInsertDetail.Parameters.Add("T_MEMBER_ID", OracleDbType.Int32).Value = objDetail.TeamMemberEmp_Id;

                                cmdAddInsertDetail.ExecuteNonQuery();
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
    }
}
