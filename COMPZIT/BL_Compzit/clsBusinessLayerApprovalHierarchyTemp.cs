using System; 
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using CL_Compzit;

namespace BL_Compzit
{
    public class clsBusinessLayerApprovalHierarchyTemp
    {
        clsDataLayerApprovalHierarchyTemp ObjDataAcco = new clsDataLayerApprovalHierarchyTemp();

        public DataTable ReadDesgDDL(string strLikeName, clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadDesgDDL(strLikeName, objEntityAcco);
            return dtAccodetails;
        }
        public DataTable ReadEmployeeDDL(string strLikeName, clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadEmployeeDDL(strLikeName, objEntityAcco);
            return dtAccodetails;
        }
        public DataTable CheckDupName(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.CheckDupName(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable CheckDupName1(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.CheckDupName1(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable CheckEmpDup(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.CheckEmpDup(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable ReadList(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadList(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable ReadTemplatedtls(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadTemplatedtls(objEntityAcco);
            return dtAccodetails;
        }
        public DataTable ReadSubtableDtls(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadSubtableDtls(objEntityAcco);
            return dtAccodetails;
        }
        public void insertHierarchyData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            ObjDataAcco.insertHierarchyData(objentityPassport, objEntityTrficVioltnDetilsList, objEntitySubstituteList);
        }
        public void updateHierarchyData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            ObjDataAcco.updateHierarchyData(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);
        }
        public void updateHierarchyDataSub(List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList)
        {
            ObjDataAcco.updateHierarchyDataSub(objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);
        }
        public void CancelTemplate(clsEntityApprovalHierarchyTemp objentityPassport)
        {
            ObjDataAcco.CancelTemplate(objentityPassport);
        }

        //document workflow //


        public void insertDocwrkData(clsEntityApprovalHierarchyTemp objentityPass,  List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn)
        {
            ObjDataAcco.insertDocwrkData(objentityPass,  objEntityTrficVioltn);
        }
        public void insertDocwrkcnfm(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            ObjDataAcco.insertDocwrkcnfm(objentityPass, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele);
        }
       
        public void updateDocwrkcnfm(clsEntityApprovalHierarchyTemp objentityPass)
        {
            ObjDataAcco.updateDocwrkcnfm(objentityPass);
        }
        public DataTable Readwrkflwname(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            DataTable dtAccodetails = ObjDataAcco.Readwrkflwname(objentityPass1);
            return dtAccodetails;
        }

        public void updatehrchyemp(clsEntityApprovalHierarchyTemp objentityPass)
        {
            ObjDataAcco.updatehrchyemp(objentityPass);
        }
        public void cancelDocwrkData(clsEntityApprovalHierarchyTemp objentityPass)
        {
            ObjDataAcco.cancelDocwrkData(objentityPass);
        }
        
       
        public void insertDocumentDataDtlsSUB(List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList,  List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele)
        {
            ObjDataAcco.insertDocumentDataDtlsSUB(objEntityTrficVioltnDetilsList, objEntityTrficVioltnDele);
        }

        public void updateDocwrkDataconform(clsEntityApprovalHierarchyTemp objentityPass)
        {
            ObjDataAcco.updateDocwrkDataconform(objentityPass);
        }
        public DataTable ReadDocumentdtls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadDocumentdtls(objentityPass);
            return dtAccodetails;
        }
        public DataTable ReadSubtableDOCDtls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadSubtableDOCDtls(objentityPass);
            return dtAccodetails;
        }
        public void updateDocumentData(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            ObjDataAcco.updateDocumentData(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele);
        }
        public void insertdoccnfm(clsEntityApprovalHierarchyTemp objentityPassport, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele, clsEntityApprovalHierarchyTemp objentityPasspo)
        {
            ObjDataAcco.insertdoccnfm(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntityTrficVioltnDetilsList,objEntityTrficVioltnDele,objentityPasspo);
        }
        public void updateDocwrkDataReopen(clsEntityApprovalHierarchyTemp objentityPass)
        {
            ObjDataAcco.updateDocwrkDataReopen(objentityPass);
        }

        public DataTable ReadSubstutEmptls(clsEntityApprovalHierarchyTemp objentityPass)
        {
            DataTable dtAccodetails = ObjDataAcco.ReadSubstutEmptls(objentityPass);
            return dtAccodetails;
        }
    }
}
