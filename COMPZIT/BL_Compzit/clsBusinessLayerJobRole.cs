using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;

namespace BL_Compzit
{
    public class clsBusinessLayerJobRole
    {
        clsDataLayerJobRole objDataLayerJobRole = new clsDataLayerJobRole();
        //Fetch   the Compzit Modules by user id.Fetching modules only which is allowed for user.
        public DataTable DisplayCompzitModuleByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtDispCmpztModule = objDataLayerJobRole.DisplayCompzitModuleByUsrId(objEntityJobRl);
            return dtDispCmpztModule;
        }
        //Fetch Designation from table according to user logined and pass it to ui layer.
        public DataTable ReadDsgnDetails(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtDsgnTypeDetails = objDataLayerJobRole.ReadDsgnDetails(objEntityJobRl);
            return dtDsgnTypeDetails;
        }
        //Fetch Designation master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadDsgnMasterEdit(clsEntityLayerJobRole objEntDsgn)
        {
            DataTable dtReadDsgnMstrEdit = objDataLayerJobRole.ReadDsgnMasterEdit(objEntDsgn);
            return dtReadDsgnMstrEdit;
        }
        //Fetch Designation App Role master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerJobRole objEntDsgn)
        {
            DataTable dtReadDsgnAppMstrEdit = objDataLayerJobRole.ReadDsgnAppRoleByDsgnId(objEntDsgn);
            return dtReadDsgnAppMstrEdit;
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtReadUsrMstr = objDataLayerJobRole.ReadIfUserLimitedByUsrId(objEntityJobRl);
            return dtReadUsrMstr;
        }
        //Method of passing designationType id for finding desination Control from datalayer to uilayer.
        public char ReadDsgnControl(clsEntityLayerJobRole objEntityJobRl)
        {
            char charControl = Convert.ToChar(objDataLayerJobRole.ReadDsgnControl(objEntityJobRl));
            return charControl;
        }
        //Fetch  displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityLayerJobRole objEntityDsgn)
        {
            DataTable dtReadUsrolMstr = objDataLayerJobRole.DisplayUserolMstr(objEntityDsgn);
            return dtReadUsrolMstr;
        }
        public DataTable DisplayUserolMstrFramewrk(clsEntityLayerJobRole objEntityDsgn)
        {
            DataTable dtReadUsrolMstr = objDataLayerJobRole.DisplayUserolMstrFramewrk(objEntityDsgn);
            return dtReadUsrolMstr;
        }

        // This Method Check Designation Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupJobRlNameIns(clsEntityLayerJobRole objDsgn)
        {
            string strCnt = objDataLayerJobRole.CheckDupJobRlNameIns(objDsgn);
            return strCnt;
        }
        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityLayerJobRole objEntityDsgn)
        {
            DataTable dtReadnextId = objDataLayerJobRole.ReadNextId(objEntityDsgn);
            return dtReadnextId;
        }
        //Method passing all details of newly registering Designation from ui layer to datalayer.
        public void InsertJobRlDetail(clsEntityLayerJobRole objEntityDsgn, List<clsEntityLayerJobRlRole> objlisDsgnRolDtls, List<clsEntityLayerJobRlAppRole> objlisDsgnAppRolDtls)
        {
           
            objDataLayerJobRole.InsertJobRlDetail(objEntityDsgn, objlisDsgnRolDtls, objlisDsgnAppRolDtls);
        }
        // This Method displays Designation details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplayJobRole(clsEntityLayerJobRole objEntityDsgn)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerJobRole.GridDisplayJobRole(objEntityDsgn);
            return dtDisp;
        }

        public DataTable GridDisplayJobRolelist(clsEntityLayerJobRole objEntityDsgn)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerJobRole.GridDisplayJobRolelist(objEntityDsgn);
            return dtDisp;
        }

        //Fetch Designation master table from datalayer according to the id and pass to the ui layer. 
        //NO
        public DataTable ReadJobRLMasterById(clsEntityLayerJobRole objEntDsgn)
        {
            DataTable dtReadDsgnMstrEdit = objDataLayerJobRole.ReadJobRLMasterById(objEntDsgn);
            return dtReadDsgnMstrEdit;
        }
        ////Fetch Designation App Role master table from datalayer according to the id and pass to the ui layer. 
        //public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerJobRole objEntDsgn)
        //{
        //    DataTable dtReadDsgnAppMstrEdit = objDataLayerDesignationMaster.ReadDsgnAppRoleByDsgnId(objEntDsgn);
        //    return dtReadDsgnAppMstrEdit;
        //}


        
        public DataTable ReadJobRlRoles(clsEntityLayerJobRole objEntDsgn)
        {
            DataTable dtReadJobRlRoles = objDataLayerJobRole.ReadJobRlRoles(objEntDsgn);
            return dtReadJobRlRoles;
        }
        //ReadJobRlAppRoles
        public DataTable ReadJobRlAppRoles(clsEntityLayerJobRole objEntDsgn)
        {
            DataTable dtReadJobRlRoles = objDataLayerJobRole.ReadJobRlAppRoles(objEntDsgn);
            return dtReadJobRlRoles;
        }
        //Update JobRl Detail
        public void UpdateJobRlDetail(clsEntityLayerJobRole objEntityDsgn, List<clsEntityLayerJobRlRole> objlisDsgnRolDtls, List<clsEntityLayerJobRlAppRole> objlisDsgnAppRolDtls)
        {

            objDataLayerJobRole.UpdateJobRlDetail(objEntityDsgn, objlisDsgnRolDtls, objlisDsgnAppRolDtls);
        }
        // This Method Check JOB ROLE Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupJobRlNameUpd(clsEntityLayerJobRole objDsgn)
        {
            string strCnt = objDataLayerJobRole.CheckDupJobRlNameUpd(objDsgn);
            return strCnt;
        }
        //UpdatejobRlCancel
        public void UpdateJobRlCancel(clsEntityLayerJobRole objEntDsgn)
        {

            objDataLayerJobRole.UpdateJobRlCancel(objEntDsgn);
        }
        //Re call Job Role
        public void ReCallJobRl(clsEntityLayerJobRole objEntDsgn)
        {
            objDataLayerJobRole.ReCallJobRl(objEntDsgn);
        }

        public void CanclJobRl(clsEntityLayerJobRole objEntDsgn)
        {
            objDataLayerJobRole.CanclJobRl(objEntDsgn);
        }


           //Method for fetch Job rol App Role  master table by their  jobrl_id(primary key).
        public DataTable ReadJobRlAppRoleByJobRl(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtReadJobRlRoles = objDataLayerJobRole.ReadJobRlAppRoleByJobRl(objEntityJobRl);
            return dtReadJobRlRoles;
        }
       
    }
}
