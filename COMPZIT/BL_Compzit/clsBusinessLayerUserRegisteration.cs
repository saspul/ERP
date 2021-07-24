using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using System.Data;
using EL_Compzit;

namespace BL_Compzit
{
  public  class clsBusinessLayerUserRegisteration
    {
        //Creating object for data layer.
      clsDataLayeUserRegisteration objDataLayerUserReg = new clsDataLayeUserRegisteration();

        //Fetch Designation  details from table according to user logined and pass it to ui layer.
        public DataTable ReadDsgnDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadDesignationDetails(objEntityUsrReg);
            return dtDsgnDetails;
        }
        // This Method returns Desigantion Control by passing designation id of selected designation 
        public string ReadDsgnCntrl(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strDsgnCntrl = objDataLayerUserReg.ReadDsgnCntrl(objEntityUsrReg);
            return strDsgnCntrl;
        }
        //Fetch Corporate office  details from table  and pass it to ui layer.
        public DataTable ReadCrptOfficeDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrptDetails = objDataLayerUserReg.ReadCrptOfficeDetails(objEntityUsrReg);
            return dtCrptDetails;
        }
              // This Method reads accesible Corporate office in the database 
        public DataTable ReadAccessibleCorp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrptDetails = objDataLayerUserReg.ReadAccessibleCorp(objEntityUsrReg);
            return dtCrptDetails;
        }
        //Fetch Corporate Department  details from table  and pass it to ui layer.
        public DataTable ReadCrptDeptDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtCrptDetails = objDataLayerUserReg.ReadCrptDeptDetails(objEntityUsrReg);
            return dtCrptDetails;
        }
        // This Method Check User Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupUserEmailIns(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCnt = objDataLayerUserReg.CheckDupUserEmailIns(objEntityUsrReg);
            return strCnt;
        }
        // This Method Check User Name in updation in database  for duplicaton by passing details to Data Layer
        public string CheckDupUserEmailUpd(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCnt = objDataLayerUserReg.CheckDupUserEmailUpd(objEntityUsrReg);
            return strCnt;
        }
        //passing data about User cancel to data layer from ui layer.
        public void UpdateUsrCancel(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            objDataLayerUserReg.UpdateUsrCancel(objEntityUsrReg);
        }
        //Method passing all details of newly registering User from ui layer to datalayer.
        public int  InsertUserRegisterationDetail(clsEntityLayerUserRegistration objEntityUsrReg, List<clsEntityLayerUserCorporate> objEntityAccsCorporateList, List<clsEntityLayerUserCorporate> objlisUserCrprtDtls, List<clsEntityLayerUserDivision> objlisUserDivisionDtls, List<clsEntityLayerUserVhclType> objlisUseVhclLicTypDtls, List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls, List<clsEntityLayerEmployeeRole> objlisDsgnRol, List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol)//emp0025
        {
            int intID = 0;
           intID =  objDataLayerUserReg.InsertUserRegisterationDetail(objEntityUsrReg, objEntityAccsCorporateList, objlisUserCrprtDtls, objlisUserDivisionDtls, objlisUseVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);
           return intID;
        }
        //Method passing all details for updating  User from ui layer to datalayer.
        public void UpdateUserRegisterationDetail(clsEntityLayerUserRegistration objEntityUsrReg, List<clsEntityLayerUserCorporate> objEntityAccsCorporateList, List<clsEntityLayerUserCorporate> objlisUserCrprtDtls, List<clsEntityLayerUserDivision> objlisUserDivisionDtls, List<clsEntityLayerUserVhclType> objlisUseVhclLicTypDtls, List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls, List<clsEntityLayerEmployeeRole> objlisDsgnRol, List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol) //emp0025
        {
            objDataLayerUserReg.UpdateUserRegisterationDetail(objEntityUsrReg, objEntityAccsCorporateList, objlisUserCrprtDtls, objlisUserDivisionDtls, objlisUseVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);
        }
        //Fetch User master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadUsrMasterEdit(clsEntityLayerUserRegistration objEntityUsrReg)
        {
           DataTable dtReadUsrMstrEdit = objDataLayerUserReg.ReadUsrMasterEdit(objEntityUsrReg);
            return dtReadUsrMstrEdit;
        }
         //This Method displays User details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplay(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerUserReg.GridDisplay(objEntityUsrReg);
            return dtDisp;
        }
        // This Method Updates the Status of User  by Passing the User id, Status,updating userid and date.
        public void UpdateStat(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            if (objEntityUsrReg.UserStatus == 1)
            {
                objEntityUsrReg.UserStatus = 0;
            }
            else
            {
                objEntityUsrReg.UserStatus = 1;
            }

            objDataLayerUserReg.UpdateStatus(objEntityUsrReg);
        }
        // This Method reads Corporate divisions based on corporate id's in the database 
        public DataTable ReadCrptDivisionsDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDivsn = new DataTable();
            dtDivsn = objDataLayerUserReg.ReadCrptDivisionsDetails(objEntityUsrReg);
            return dtDivsn;
        }
        // This Method Check User LOGIN Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupUserLoginName(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCnt = objDataLayerUserReg.CheckDupUserLoginName(objEntityUsrReg);
            return strCnt;
        }
        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadnextId = objDataLayerUserReg.ReadNextId(objEntityUsrReg);
            return dtReadnextId;
        }
        //005 start
        //FOR READING USER DETAILS
        public DataTable ReadUsrDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadUsrDetails = objDataLayerUserReg.ReadUsrDetails(objEntityUsrReg);
            return dtReadUsrDetails;
        }
        // This Method Check User CODE in database  for duplicaton by passing details to Data Layer
        public string CheckDupUserCode(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strCnt = objDataLayerUserReg.CheckDupEmpCode(objEntityUsrReg);
            return strCnt;
        }

        // This Method will fetch License Type details based on corporate and organization
        public DataTable ReadLicenseType(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadLicenseType(objEntityUsrReg);
            return dtReadDetails;
        }
        // This Method will fetch Accommodation details based on corporate and organization
        public DataTable ReadAccommodationMstr(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadAccommodationMstr(objEntityUsrReg);
            return dtReadDetails;
        }

        // This Method will fetch  Vehicle License Type Based on UserId.
        public DataTable ReadLicenseType_ByUsrId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadLicenseType_ByUsrId(objEntityUsrReg);
            return dtReadDetails;
        }
        //0013
        //THIS METHOD IS FOR FETCHING JOB ROLE BY DESIGNATION ID
        public DataTable ReadJobRol(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadJobRol(objEntityUsrReg);
            return dtReadDetails;
        }
        //0013
        //THIS METHOD IS FOR FETCHING SUB BUSSINESS UNIT BY MAIN BUSSINESS ID
        public DataTable ReadSubBusUnt(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadSubBusUnt(objEntityUsrReg);
            return dtReadDetails;
        }
        public DataTable ReadJobRlRoles(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadJobRlRoles = objDataLayerUserReg.ReadJobRlRoles(objEntityUsrReg);
            return dtReadJobRlRoles;
        }
        //ReadJobRlAppRoles
        public DataTable ReadJobRlAppRoles(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadJobRlRoles = objDataLayerUserReg.ReadJobRlAppRoles(objEntityUsrReg);
            return dtReadJobRlRoles;
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtReadUsrMstr = objDataLayerUserReg.ReadIfUserLimitedByUsrId(objEntityJobRl);
            return dtReadUsrMstr;
        }
        public DataTable ReadSubBuss(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadDetails = objDataLayerUserReg.ReadSubBuss(objEntityUsrReg);
            return dtReadDetails;
        }
        //evm-0024
        //Method for read nextid from database not incremented
        public DataTable ShowNextId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadnextId = objDataLayerUserReg.ShowNextId(objEntityUsrReg);
            return dtReadnextId;
        }

        public DataTable ReadStaffWorkerBiDesgId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadnextId = objDataLayerUserReg.ReadStaffWorkerBiDesgId(objEntityUsrReg);
            return dtReadnextId;
        }
        public DataTable ReadAcsCorpBy_Usr(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtReadnextId = objDataLayerUserReg.ReadAcsCorpBy_Usr(objEntityUsrReg);
            return dtReadnextId;
        }

        public DataTable ReadEmpnWelfareSrvc(clsEntityLayerUserRegistration objEntityUsrReg)  //emp0025
        {
            DataTable dtwelfaresrvc = objDataLayerUserReg.ReadEmpnWelfareSrvc(objEntityUsrReg);
            return dtwelfaresrvc;
        }
        public DataTable ReadEmpnWelfare(clsEntityLayerEmployeeWelfareSrvc objEntityUsrReg)   //emp0025
        {
            DataTable dtwelfaresrvc = objDataLayerUserReg.ReadEmpnWelfare(objEntityUsrReg);
            return dtwelfaresrvc;
        }
        public DataTable ReadDsgnWelfareById(clsEntityLayerEmployeeWelfareSrvc objEntityEmpWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerUserReg.ReadDsgnWelfareById(objEntityEmpWelfareSrvc);
            return dtWelfareScvc;
        }
        public DataTable ReadEmpnWelfareDept(clsEntityLayerEmployeeWelfareSrvc objEntityEmpWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerUserReg.ReadEmpnWelfareDept(objEntityEmpWelfareSrvc);
            return dtWelfareScvc;
        }
        public DataTable ReadEmpnWelfareDesg(clsEntityLayerEmployeeWelfareSrvc objEntityEmpWelfareSrvc)   //EMP0025
        {
            DataTable dtWelfareScvc = objDataLayerUserReg.ReadEmpnWelfareDesg(objEntityEmpWelfareSrvc);
            return dtWelfareScvc;
        }
        public void Insert_EmpWelfare(List<clsEntityLayerEmployeeWelfareSrvc> objListEmpgWelfare, clsEntityLayerEmployeeWelfareSrvc objEntityEmp)
        {
            objDataLayerUserReg.Insert_EmpWelfare(objListEmpgWelfare, objEntityEmp);

        }
        public DataTable ReadReferenceFormatEmp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadReferenceFormatEmp(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadCrprtSts(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadCrprtSts(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public string CheckEmployeeCode(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string count = objDataLayerUserReg.CheckEmployeeCode(objEntityUsrReg);
            return count;
        }
        //end
        public DataTable ReadBusUnits(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadBusUnits(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadDept(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadDept(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadExportData(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadExportData(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadAddDed(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadAddDed(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadAddDedEmp(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadAddDedEmp(objEntityUsrReg);
            return dtDsgnDetails;
        }
        public DataTable ReadAddDedEmpDate(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtDsgnDetails = objDataLayerUserReg.ReadAddDedEmpDate(objEntityUsrReg);
            return dtDsgnDetails;
        }
        //0039
        public void StoreExistingId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            objDataLayerUserReg.StoreExistingId(objEntityUsrReg);
           
        }

        public void StoreNewId(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            objDataLayerUserReg.StoreNewId(objEntityUsrReg);
           
        }
        //end

    }
}
