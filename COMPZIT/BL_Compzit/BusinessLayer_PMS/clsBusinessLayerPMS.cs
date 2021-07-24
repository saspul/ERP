using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
/// <summary>
/// Summary description for clsBusinessLayerPMS
/// </summary>
/// 
namespace BL_Compzit.BusinessLayer_PMS
{
public class clsBusinessLayerPMS
{
    
    clsDataLayerPMS objPMS = new clsDataLayerPMS();
		 public DataTable Read_Document()
        {
            
            DataTable dtdoc = new DataTable();
            dtdoc = objPMS.ReadDocument();
            return dtdoc;
        }
        public DataTable Read_Departments(clsEntityApprovalHierarchyTemp objEntity)
        {
             DataTable dtdc = new DataTable();
             dtdc = objPMS.ReadDepartments(objEntity);
             return dtdc;
         }
         public DataTable Read_Divisions(clsEntityApprovalHierarchyTemp objEntity)
         {

             DataTable dtdc = new DataTable();
             dtdc = objPMS.ReadDivisions(objEntity);
             return dtdc;
         }
         public DataTable Read_hrchyname()
         {

             DataTable dtdc = new DataTable();
             dtdc = objPMS.ReadHrchyName();
             return dtdc;
         }
         public DataTable ReadDocumentwrk()
         {

             DataTable dtdoc = new DataTable();
             dtdoc = objPMS.ReadDocumentwrk();
             return dtdoc;
         }
         public DataTable ReadDocwrkflw(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtdoc = new DataTable();
             dtdoc = objPMS.ReadDocwrkflw(objentityPass1);
             return dtdoc;
         }
         public DataTable ReadDocwrkflwsts(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtdoc = new DataTable();
             dtdoc = objPMS.ReadDocwrkflwsts(objentityPass1);
             return dtdoc;
         }
         public DataTable ReadDocwrkflwcncl()
         {

             DataTable dtdoc = new DataTable();
             dtdoc = objPMS.ReadDocwrkflwcncl();
             return dtdoc;
         }
         public DataTable Readwrkflwdtls11(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.Readwrkflwdtls(objentityPass1);
             return dtAccodetails;
         }
         public DataTable selectdep(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.selectdep(objentityPass1);
             return dtAccodetails;
         }
         public DataTable selectdiv(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.selectdiv(objentityPass1);
             return dtAccodetails;
         }
         public DataTable Readwrkflwdid1(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.Readwrkflwdid1(objentityPass1);
             return dtAccodetails;
         }
         public DataTable Readwrkflwdi(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.Readwrkflwdi(objentityPass1);
             return dtAccodetails;
         }
         public DataTable Readwrkflwparentid(clsEntityApprovalHierarchyTemp objentityPass1)
         {

             DataTable dtAccodetails = objPMS.Readwrkflwparentid(objentityPass1);
             return dtAccodetails;
         }
         public void StatusChangeDocwrk(clsEntityApprovalHierarchyTemp objentityPass1)
         {
             objPMS.StatusChangeDocwrk(objentityPass1);
         }
         public DataTable ReadDocwrkflwparent()
         {

             DataTable dtAccodetails = objPMS.ReadDocwrkflwparent();
             return dtAccodetails;
         }
         public DataTable ReadApprovalAss(clsEntityApprovalHierarchyTemp objentityPass1)
         {
             DataTable dtAccodetails = objPMS.ReadApprovalAss(objentityPass1);
             return dtAccodetails;
         }
         public DataTable ReadSubtableDtls(clsEntityApprovalHierarchyTemp objEntityAcco)
         {
             DataTable dtAccodetails = objPMS.ReadSubtableDtls(objEntityAcco);
             return dtAccodetails;
         }
         public void InsertDocumentWorkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowMainList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowSubList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesList)
         {
             objPMS.InsertDocumentWorkflow(objEntityWrkflow, objEntityWrkflowMainList, objEntityWrkflowSubList, objEntitySubstituteList, objEntityApprvlRulesList);
         }
         public DataTable ReadDocumentWrkflowList(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadDocumentWrkflowList(objEntityWrkflow);
             return dtAccodetails;
         }
         public void UpdateDocumentWorkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowUPDATEList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowDELETEList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowMainINSERTList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowSubINSERTList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesDELETEList)
         {
             objPMS.UpdateDocumentWorkflow(objEntityWrkflow, objEntityWrkflowUPDATEList, objEntityWrkflowDELETEList, objEntityWrkflowMainINSERTList, objEntityWrkflowSubINSERTList, objEntitySubstituteList, objEntityApprvlRulesList, objEntityApprvlRulesDELETEList);
         }
         public void ReopenWrkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             objPMS.ReopenWrkflow(objEntityWrkflow);
         }
         public DataTable ReadLowerHierarchyIds(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadLowerHierarchyIds(objEntityWrkflow);
             return dtAccodetails;
         }

         public DataTable ReadSubstutEmptls(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadSubstutEmptls(objEntityWrkflow);
             return dtAccodetails;
         }

         public DataTable ReadApprovalConditions(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadApprovalConditions(objEntityWrkflow);
             return dtAccodetails;
         }

         public DataTable ReadApprovalConditionVal(string Package, string Procedure, clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadApprovalConditionVal(Package, Procedure, objEntityWrkflow);
             return dtAccodetails;
         }

         public DataTable ReadConditionTyps(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadConditionTyps(objEntityWrkflow);
             return dtAccodetails;
         }

         public DataTable ReadApprovalRules(clsEntityApprovalHierarchyTemp objEntityWrkflow)
         {
             DataTable dtAccodetails = objPMS.ReadApprovalRules(objEntityWrkflow);
             return dtAccodetails;
         }

	}
}