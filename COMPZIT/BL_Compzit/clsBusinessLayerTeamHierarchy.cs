using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:15/03/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
   public class clsBusinessLayerTeamHierarchy
    {    //Creating object for datalayer
       clsDataLayerTeamHierarchy objDataLayerTeamHierarchy = new clsDataLayerTeamHierarchy();

       //Method  TO READ ALL USER IN CORESSPONDING ORGANIZATION AND CORPORATE FOR TEAM LEAD
       public DataTable ReadUsersForTeamLead(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
       {
           DataTable dtTeam = objDataLayerTeamHierarchy.ReadUsersForTeamLead(objEntityTeamHierarchy);
           return dtTeam;
       }
       //Method  TO READ ALL DIVISION IN CORESSPONDING ORGANIZATION AND CORPORATE FOR SOR SEARCHING
       public DataTable ReadDivision(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
       {
           DataTable dtTeam = objDataLayerTeamHierarchy.ReadDivision(objEntityTeamHierarchy);
           return dtTeam;
       }

       //Method  TO READ ALL USER IN CORESSPONDING ORGANIZATION AND CORPORATE FOR TEAM MEMBERS EXCEPT THE SELECTED TEAM LEAD
        public DataTable ReadUsersForMember(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            DataTable dtMembers = objDataLayerTeamHierarchy.ReadUsersForMember(objEntityTeamHierarchy);
            return dtMembers;
        }

        //Method of passing the count of TEAM name that exist in the table
        public string CheckTeamName(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            string strCount = objDataLayerTeamHierarchy.CheckTeamName(objEntityTeamHierarchy);
            return strCount;
        }
        //passing team details to datalayer for insertion
        public void InsertTeamDetail(clsEntityLayerTeamHierarchy objEntityTeamHierarchy, List<clsEntityLayerTeamMember> objEntityTeamMemberDetails)
        {
            objDataLayerTeamHierarchy.InsertTeamDetail(objEntityTeamHierarchy, objEntityTeamMemberDetails);
        }    //Method for passing team master table from datalayer to uilayer for list view.
        public DataTable ReadTeamList(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            DataTable dtList = objDataLayerTeamHierarchy.ReadTeamList(objEntityTeamHierarchy);
            return dtList;
        }
        //passing team details to datalayer for canelling
        public void Cancel_Team(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            objDataLayerTeamHierarchy.Cancel_Team(objEntityTeamHierarchy);
        }
        //Method for read Team by Team ID.
        public DataTable ReadTeamById(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            DataTable dtTeam = objDataLayerTeamHierarchy.ReadTeamById(objEntityTeamHierarchy);
            return dtTeam;
        }
        //Method for read Team Members by Team ID.
        public DataTable ReadTeamMembersById(clsEntityLayerTeamHierarchy objEntityTeamHierarchy)
        {
            DataTable dtTeamMembrs = objDataLayerTeamHierarchy.ReadTeamMembersById(objEntityTeamHierarchy);
            return dtTeamMembrs;
        }
        //passing team details to datalayer for Updation
        public void Update_TeamDetail(clsEntityLayerTeamHierarchy objEntityTeamHierarchy, List<clsEntityLayerTeamMember> objEntityTeamMemberDetails, bool blMemberEdited)
        {
            objDataLayerTeamHierarchy.Update_TeamDetail(objEntityTeamHierarchy, objEntityTeamMemberDetails, blMemberEdited);
        }  
    }
}
