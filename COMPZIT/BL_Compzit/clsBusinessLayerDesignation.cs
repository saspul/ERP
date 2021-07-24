using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

namespace BL_Compzit
{
    public class clsBusinessLayerDesignation
    {
        //Creating object for data layer.
        clsDataLayerDesignation objDataLayerDesignationMaster = new clsDataLayerDesignation();

        //Fetch Designation Type details from table according to user logined and pass it to ui layer.
        public DataTable ReadDsgnTypeDetails(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtDsgnTypeDetails = objDataLayerDesignationMaster.ReadDesignationTypeDetails(objEntityDsgn);
            return dtDsgnTypeDetails;
        }
        // This Method displays User Role details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplayUserRole()
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerDesignationMaster.GridDisplayUserRole();
            return dtDisp;

        }
        //Fetch Designation master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadDsgnMasterEdit(clsEntityLayerDesignation objEntDsgn)
        {
            DataTable dtReadDsgnMstrEdit = objDataLayerDesignationMaster.ReadDsgnMasterEdit(objEntDsgn);
            return dtReadDsgnMstrEdit;
        }
        // This Method displays Designation details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplayDesignation(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerDesignationMaster.GridDisplayDesignation(objEntityDsgn);
            return dtDisp;
        }

        // This Method Updates the Status of Designation by Passing the Designation id, Status,updating userid and date.
        public void UpdateStat(clsEntityLayerDesignation objEntityDsgn)
        {
            if (objEntityDsgn.DesignationStatus == 1)
            {
                objEntityDsgn.DesignationStatus = 0;
            }
            else
            {
                objEntityDsgn.DesignationStatus = 1;
            }

            objDataLayerDesignationMaster.UpdateStatus(objEntityDsgn);
        }
        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtReadnextId = objDataLayerDesignationMaster.ReadNextId(objEntityDsgn);
            return dtReadnextId;
        }
        //Method of passing designationType id for finding desination Control from datalayer to uilayer.
        public char ReadDsgnControl(clsEntityLayerDesignation objEntityDsgn)
        {
            char charControl = Convert.ToChar(objDataLayerDesignationMaster.ReadDsgnControl(objEntityDsgn));
            return charControl;
        }
        //Method passing all details of newly registering Designation from ui layer to datalayer.
        public void InsertDesignationDetail(clsEntityLayerDesignation objEntityDsgn, List<clsEntityLayerDesignationRole> objlisDsgnRolDtls, List<clsEntityLayerDesignationAppRole> objlisDsgnAppRolDtls, List<clsEntityLayerDesignationLeaveType> objlistLeaveType)
        {
            //List<int> lintWithParent = new List<int>();

            // lintWithParent = AddingParent(objlisDsgnRolDtls);



            objDataLayerDesignationMaster.InsertDesignationDetails(objEntityDsgn, objlisDsgnRolDtls, objlisDsgnAppRolDtls, objlistLeaveType);



        }
        // This Method Check Designation Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupDesignationNameIns(clsEntityLayerDesignation objDsgn)
        {
            string strCnt = objDataLayerDesignationMaster.CheckDupDesignationNamesIns(objDsgn);
            return strCnt;
        }
        // This Method Check Designation Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupDesignationNameUpd(clsEntityLayerDesignation objDsgn)
        {
            string strCnt = objDataLayerDesignationMaster.CheckDupDesignationNamesUpd(objDsgn);
            return strCnt;
        }
        //passing data about Designation cancel to data layer from ui layer.
        public void UpdateDsgnCancel(clsEntityLayerDesignation objEntDsgn)
        {
            objDataLayerDesignationMaster.UpdateDsgnCancel(objEntDsgn);
        }
        //Method passing all details for updation of Designation from ui layer to datalayer.
        public void UpdateDesignationDetail(clsEntityLayerDesignation objEntityDsgn, List<clsEntityLayerDesignationRole> objlisDsgnRolDtls, List<clsEntityLayerDesignationAppRole> objlisDsgnAppRolDtlsList, List<clsEntityLayerDesignationLeaveType> objlistLeaveType)
        {
          //  List<int> lintWithParent = new List<int>();

          //  lintWithParent = AddingParent(objlisDsgnRolDtls);
            objDataLayerDesignationMaster.UpdateDesignationDetails(objEntityDsgn, objlisDsgnRolDtls, objlisDsgnAppRolDtlsList, objlistLeaveType);
            
           // objDataLayerDesignationMaster.UpdateDesignationDetails(objEntityDsgn, lintWithParent);
        }




        //passing details 
        public List<int> AddingParent(List<clsEntityLayerDesignationRole> objlisDsgnRolDtls)
        {
            
            List<int> lintWithParent = new List<int>();
            foreach (clsEntityLayerDesignationRole objDesignationRole in objlisDsgnRolDtls)
            {
                if (objDesignationRole.UsrRolId !=0)
                {
                    lintWithParent.Add(objDesignationRole.UsrRolId);
                   
                }
                if (objDesignationRole.UsrRolParentlId != 0)
                {
                    lintWithParent.Add(objDesignationRole.UsrRolParentlId);

                }
                if (objDesignationRole.UsrRolRootId  != 0)
                {
                    lintWithParent.Add(objDesignationRole.UsrRolRootId);

                }

             
            }
            List<int> lintWithParentDistnct = lintWithParent.Distinct().ToList();
           //lintWithParent.Distinct().ToList();

            return lintWithParentDistnct;
        }


        //Fetch  displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtReadUsrolMstr = objDataLayerDesignationMaster.DisplayUserolMstr(objEntityDsgn);
            return dtReadUsrolMstr;
        }
        //Fetch   the Compzit Modules by user id.Fetching modules only which is allowed for user.
        public DataTable DisplayCompzitModuleByUsrId(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtDispCmpztModule = objDataLayerDesignationMaster.DisplayCompzitModuleByUsrId(objEntityDsgn);
            return dtDispCmpztModule;
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtReadUsrMstr = objDataLayerDesignationMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            return dtReadUsrMstr;
        }

        //Fetch Designation App Role master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerDesignation objEntDsgn)
        {
            DataTable dtReadDsgnAppMstrEdit = objDataLayerDesignationMaster.ReadDsgnAppRoleByDsgnId(objEntDsgn);
            return dtReadDsgnAppMstrEdit;
        }
        //started--EVM-0009
        //Fetch   the leave types from leave type master table and displayed to the checkboxlist.
        public DataTable DisplayLeaveType(clsEntityLayerDesignation objEntDsgnLeaveType)
        {
            DataTable dtLeaveType = objDataLayerDesignationMaster.DisplayLeaveType(objEntDsgnLeaveType);
            return dtLeaveType;
        }
        //Fetch Designation Leave Type master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadDsgnLeaveTypeByDsgnId(clsEntityLayerDesignationLeaveType objEntDsgnLeaveType)
        {
            DataTable dtReadDsgnLeaveType = objDataLayerDesignationMaster.ReadDsgnLeaveTypeByDsgnId(objEntDsgnLeaveType);
            return dtReadDsgnLeaveType;
        }
        //Fetch Designation Leave Type master table from datalayer according to the id and pass to the ui layer to enable or disable checkbox. 
        public DataTable ReadDsgnLeaveTypeEnableByDsgnId(clsEntityLayerDesignationLeaveType objEntDsgnLeaveType)
        {
            DataTable dtReadDsgnLeaveType = objDataLayerDesignationMaster.ReadDsgnLeaveTypeEnableByDsgnId(objEntDsgnLeaveType);
            return dtReadDsgnLeaveType;
        }

        public DataTable ReadDsgnWelfare(clsEntityLayerDesignationWelfareSrvc objEntityDsgnWelfareSrvc)   //EMP0025
        {
            DataTable dtReadDsgnLeaveType = objDataLayerDesignationMaster.ReadDsgnWelfare(objEntityDsgnWelfareSrvc);
            return dtReadDsgnLeaveType;
        }

        public DataTable ReadDsgnWelfareSrvc(clsEntityLayerDesignation objEntityDsgnWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerDesignationMaster.ReadDsgnWelfareSrvc(objEntityDsgnWelfareSrvc);
            return dtWelfareScvc;
        }
        public DataTable ReadDsgnWelfareById(clsEntityLayerDesignationWelfareSrvc objEntityDesgnWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerDesignationMaster.ReadDsgnWelfareById(objEntityDesgnWelfareSrvc);
            return dtWelfareScvc;
        }
        public void Insert_DesgWelfare(List<clsEntityLayerDesignationWelfareSrvc> objListDesgWelfare, clsEntityLayerDesignationWelfareSrvc objEntityDsgn)
        {
            objDataLayerDesignationMaster.Insert_DesgWelfare(objListDesgWelfare, objEntityDsgn);

        }
        public DataTable DisplayUserolMstrFramewrk(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtReadUsrolMstr = objDataLayerDesignationMaster.DisplayUserolMstrFramewrk(objEntityDsgn);
            return dtReadUsrolMstr;
        }
        //stopped
        public DataTable ReadDesignmasById(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtReadUsrolMstr = objDataLayerDesignationMaster.ReadDesignmasById(objEntityDsgn);
            return dtReadUsrolMstr;
        }
        public void UpdateStatus(clsEntityLayerDesignation objEntityDsgn)
        {

            objDataLayerDesignationMaster.UpdateStatus(objEntityDsgn);
        }
    }
}
