using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
// CREATED BY:EVM-0002
// CREATED DATE:05/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit

{
    
    public class clsBusinesslayerCorpDept
    {
        //Creating object for datalayer
        clsDataLayerCorpDept objDataLayerCorpDept = new clsDataLayerCorpDept();
        //Method of passing corporate department table from datalayer to ui layer
        public DataTable ReadCorpDept(clsEntityCorpDept objEntityDept)
        {
            DataTable dtCorpDept = objDataLayerCorpDept.ReadCorporateDept(objEntityDept);
            return dtCorpDept;
        }
        
        //Method of passing department name count that have in the table.
        public string Check_Dept_Name(clsEntityCorpDept objEntityCorpdept)
        {
            string strCount = objDataLayerCorpDept.CheckDeptName(objEntityCorpdept);
            return strCount;
        }
        //mod EVM-0012
        //evm-0023
        //Method of passing data about department for insertion from ui layer to datalayer.
        public void Insert_Dept(clsEntityCorpDept objEntityCorpdept, List<clsEntityCorpIdListIns> objEntityCorpIdList, List<clsEntityDeptDivListIns> objEntityDeptDivListIns)
        {
            objDataLayerCorpDept.Insert_Dept(objEntityCorpdept, objEntityCorpIdList, objEntityDeptDivListIns);
            
        }


        public void Insert_DeptWelfare(List<clsEntityLayerDepartmentWelfareSrvc> objListDesgWelfare,clsEntityLayerDepartmentWelfareSrvc objEntityDept)
        {
            objDataLayerCorpDept.Insert_DeptWelfare(objListDesgWelfare, objEntityDept);

        }

        //Method for passing department master table from datalayer to uilayer for list view.
        public DataTable ReaddeptList(clsEntityCorpDept objEntityDept)
        {
            DataTable dtDeptList = objDataLayerCorpDept.ReadDeptList(objEntityDept);
            return dtDeptList;
        }
        //Passing the details about new status about the department 
        public void Update_Dept_Status(clsEntityCorpDept objEntityCorpdept)
        {
            if (objEntityCorpdept.Dept_Status == 1)
            {
                objEntityCorpdept.Dept_Status = 0;
            }
            else
            {
                objEntityCorpdept.Dept_Status = 1;
            }
            objDataLayerCorpDept.Update_Dept_Status(objEntityCorpdept);
        }
        //Method of passing department table from datalayer to ui layer with their id
        public DataTable ReadDeptById(clsEntityCorpDept objEntityCorpdept)
        {
            DataTable dtDeptById = objDataLayerCorpDept.ReadDeptListById(objEntityCorpdept);
            return dtDeptById;
        }
        //Method for passing data about department modification for updation ui layer to data layer
        public void Update_Dept(clsEntityCorpDept objEntityCorpdept, List<clsEntityCorpIdListIns> objEntityCorpIdListIns, List<clsEntityDeptDivListIns> objEntityDeptDivListIns)
        {
            objDataLayerCorpDept.Update_Dept(objEntityCorpdept, objEntityCorpIdListIns, objEntityDeptDivListIns);
        }
      
        //Method for cancel the department so passing data about department that get cancel
        public void Cancel_Department(clsEntityCorpDept objEntityCorpdept)
        {
            objDataLayerCorpDept.Cancel_Dept(objEntityCorpdept);
        }
        //EVM-0012
        //Method of passing corporate office (business units) table from datalayer to ui layer
        public DataTable ReadCorpOffice(clsEntityCorpDept objEntityCorpdept)
        {
            DataTable dtCorpOffice = objDataLayerCorpDept.ReadCorporateOffice(objEntityCorpdept);
            return dtCorpOffice;
        }
        //ReadBusinessUnitsById
        public DataTable ReadBusinessUnitsById(clsEntityCorpDept objEntityCorpdept)
        {
            DataTable dtBusinessUnitsById = objDataLayerCorpDept.ReadBusinessUnitsById(objEntityCorpdept);
            return dtBusinessUnitsById;
        }
        //EVM-0023
        //Read Corperate division offices
        public DataTable ReadCorporateDivisionOffice(clsEntityCorpDept objEntityCorpdept)
        {
            DataTable dtCorpDiv = objDataLayerCorpDept.ReadCorporateDivisionOffice(objEntityCorpdept);
            return dtCorpDiv;
        }
        //EVM-0023
        //Read ReadDivisionById
        public DataTable ReadDivisionById(clsEntityCorpDept objEntityCorpdept)
        {
            DataTable dtCorpDivision = objDataLayerCorpDept.ReadDivisionById(objEntityCorpdept);
            return dtCorpDivision;
        }
        public DataTable ReadDeptnWelfareSrvc(clsEntityCorpDept objEntityDeptnWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDeptnWelfareSrvc);
            return dtWelfareScvc;
        }
        public DataTable ReadDsgnWelfare(clsEntityLayerDepartmentWelfareSrvc objEntityDeptnWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerCorpDept.ReadDsgnWelfare(objEntityDeptnWelfareSrvc);
            return dtWelfareScvc;
        }
        public DataTable ReadDsgnWelfareById(clsEntityLayerDepartmentWelfareSrvc objEntityDeptnWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerCorpDept.ReadDsgnWelfareById(objEntityDeptnWelfareSrvc);
            return dtWelfareScvc;
        }
    }
}
